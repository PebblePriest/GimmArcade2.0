/// <summary> Copyright (c) 2015, Felix Kate
/// All rights reserved.
///
/// Redistribution and use in source and binary forms, with or without
/// modification, are permitted provided that the following conditions are met:
///
/// * Redistributions of source code must retain the above copyright notice, this
/// list of conditions and the following disclaimer.
///
/// * Redistributions in binary form must reproduce the above copyright notice,
/// this list of conditions and the following disclaimer in the documentation
/// and/or other materials provided with the distribution.
///
/// * Neither the name of Unity_ColorWheel nor the names of its
/// contributors may be used to endorse or promote products derived from
/// this software without specific prior written permission.
///
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
/// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
/// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
/// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
/// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
/// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
/// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
/// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
/// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
/// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
/// </summary>


/// <summary>
/// This is a URP adaptation (the rendering is in ShaderGraph) of Felix Kate's Color Wheel:
/// https://github.com/fkate/Unity_ColorWheel/
/// There's a lot of maths here to make things work,
/// which is why I did the whole thing in ShaderGraph
/// so you can see a all of the trigonometry in action creating this faerie magic.
/// </summary>

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEngine.XR.Interaction.Toolkit;

namespace ColorPicker
{
	public class ColorWheelControl : MonoBehaviour {

		//Output Color
		public Color Selection;

		//Output Hex Value to outText.text
		//Input Hex Value from inText.text
		[SerializeField] private Text outputText;
		[SerializeField] private InputField inputText;

		//Hook up the Outer and Inner selectors to these
		[SerializeField]
		private RectTransform selectorOuter, selectorInner;

		//For Changing the rotation of the Selector
		[SerializeField] [Range(0f,20f)] private float rotationSpeed = 3.6f;
		[SerializeField] private Rotation rotation = Rotation.Clockwise;
		[SerializeField] private bool rotateInner = false;
		[SerializeField] private Color outlineColor = Color.black;
		[SerializeField] private bool dynamicOutline = false;
		[Tooltip("Dynamic Saturation and Value")]
		[SerializeField] private bool dynamicSV = false;
		private bool dynamicSaturation, dynamicValue = false;

		//Control values
		private float outer;
		private Vector2 inner;

		private FPSControlls controller;

		private bool dragOuter, dragInner;

		//The Components of the wheel
		private Material mat, outerSelector_mat, innerSelector_mat;
		private RectTransform RectTrans;

		private float halfSize;

		//Saving CPU Memory by storing these values instead of calculating them
		private static readonly int _Color = Shader.PropertyToID("_Color");
		private static readonly int _OutlineColor = Shader.PropertyToID("_OutlineColor");
		private static readonly int _Saturation = Shader.PropertyToID("_Saturation");
		private static readonly int _Lightness = Shader.PropertyToID("_Lightness");
		private const float PI_2 = 0.63661977236f; // PI/2
		private const float TAU = 6.28318530718f;

		private void OnEnable() => controller.Enable();

		private void OnDisable() => controller.Disable();

		private XRRayInteractor leftInteractor;
		private XRRayInteractor rightInteractor;

		private bool vrUser = false;
		private bool rightHand = true;
		

		private void Awake()
		{
			controller = new FPSControlls();

			if(transform.parent.TryGetComponent<TrackedDeviceGraphicRaycaster>(out TrackedDeviceGraphicRaycaster raycasterInfo))
            {
				vrUser = true;
				//raycastData = raycasterInfo;
				controller.FPSPlayer.RightTriggerPull.performed += TriggerPulled;
				controller.FPSPlayer.LeftTriggerPull.performed += TriggerPulled;
				controller.FPSPlayer.RightTriggerPull.canceled += TriggerReleased;
				controller.FPSPlayer.LeftTriggerPull.canceled += TriggerReleased;

				XRRayInteractor[] interactors = FindObjectsOfType<XRRayInteractor>();

				foreach(XRRayInteractor interactor in interactors)
                {
                    if (interactor.name.Contains("Right"))
                    {
						rightInteractor = interactor;
                    }
					else if (interactor.name.Contains("Left"))
                    {
						leftInteractor = interactor;
                    }
                }
            }
            else
            {
				controller.FPSPlayer.MouseConfirm.performed += OnClick;
			}
		}

		//Set up the transforms
		private void Start()
		{
			//Get the rect transform and make x and y the same to avoid streching
			RectTrans = GetComponent<RectTransform>();
			Vector2 sizeDelta = RectTrans.sizeDelta;
		
			//Set the sizes of the Cursors
			selectorOuter.sizeDelta =  sizeDelta / 5.0f;
			selectorInner.sizeDelta =  sizeDelta / 20.0f;

			//Calculate the half size
			halfSize = sizeDelta.x / 2;

			//Update the material of the box to red
			UpdateMaterial();
		}

		public void SetDefaultColor()
		{
			if (!mat)
			{
				mat = GetComponent<Image>().material;
			}
			if (!outerSelector_mat)
			{
				outerSelector_mat = selectorOuter.GetComponent<Image>().material;
			}
			if (!innerSelector_mat)
			{
				innerSelector_mat = selectorInner.GetComponent<Image>().material;
			}
			//Set first selected value to red (0° rotation and upper right corner in the box)
			Selection = Color.white;
			outerSelector_mat.SetColor(_Color,Color.white);
			innerSelector_mat.SetColor(_Color, Color.black);

			mat.SetFloat(_Lightness, 1);
			mat.SetFloat(_Saturation, 1);
			if (dynamicOutline)
			{
				outlineColor = Selection;
				mat.SetColor(_OutlineColor, Color.black);
			}
			else
			{
				mat.SetColor(_OutlineColor, outlineColor);
			}
		}



		//Update the selectors
		void Update(){
			//Drag selector of outer circle
			Vector2 readValue = Vector2.zero;

			if (vrUser)
			{
				XRRayInteractor interactor;

				if (rightHand)
				{
					interactor = rightInteractor;
				}
				else
				{
					interactor = leftInteractor;
				}

				if (interactor.TryGetHitInfo(out Vector3 pos, out Vector3 normal, out int posInLine, out bool validTarget))
				{
					if (validTarget)
					{
						print(transform.InverseTransformPoint(pos));

						readValue = transform.InverseTransformPoint(pos);
					}
				}
			}
			else
			{
				readValue = Mouse.current.position.ReadValue();
			}

			if(dragOuter){
				//Get mouse direction
				Vector2 dir = new Vector2(RectTrans.position.x, RectTrans.position.y) -
							  readValue;
				dir.Normalize();

				//Calculate the radians
				outer = Mathf.Atan2 (-dir.x, -dir.y);

				//And update
				UpdateMaterial();
				UpdateColor();

				//On mouse release also release the drag
				if(Mouse.current.leftButton.wasReleasedThisFrame)dragOuter = false;
		
				//Drag selector of inner box
			}else if(dragInner){
				//Get position inside the box
				Vector2 dir = new Vector2(RectTrans.position.x, RectTrans.position.y) - readValue;
				dir.x = Mathf.Clamp(dir.x, -halfSize / 2,  halfSize / 2) + halfSize / 2;
				dir.y = Mathf.Clamp(dir.y, -halfSize / 2,  halfSize / 2) + halfSize / 2;

				//Scale the value to 0 - 1;
				inner = dir / halfSize;

				UpdateColor();

				//On mouse release also releaste the drag
				if(Mouse.current.leftButton.wasReleasedThisFrame)dragInner = false;
			}

			//Set the selectors positions
			selectorOuter.localPosition = new Vector3(Mathf.Sin(outer) * halfSize * 0.85f, Mathf.Cos(outer) * halfSize * 0.85f, -1.5f);
			selectorInner.localPosition = new Vector3(halfSize * 0.5f - inner.x * halfSize, halfSize * 0.5f - inner.y * halfSize, -1.5f);
		}

		public void ToggleDynamicSL()
		{
			if (dynamicSV)
			{
				dynamicSaturation = dynamicValue = true;
			}
			else
			{
				dynamicSaturation = dynamicValue = false;
			}
			UpdateColor();
		}

		private Color GetUpdatedColor()
		{
			Color c = Color.white;

			//Calculation of rgb from degree with a modified 3 wave function
			//Check out http://en.wikipedia.org/wiki/File:HSV-RGB-comparison.svg to understand how it should look
			//Or just look at the shader in ShaderGraph
			c.r = Mathf.Clamp(Mathf.Asin(Mathf.Cos(outer)) + 0.5f, 0, 1);
			c.g = Mathf.Clamp(Mathf.Asin(Mathf.Cos(TAU * 0.33333333f - outer)) + 0.5f, 0, 1);
			c.b = Mathf.Clamp(Mathf.Asin(Mathf.Cos(TAU * 0.66666666f - outer)) + 0.5f, 0, 1);
			
			return c;
		}

		//Update the material of the inner box to match the hue color
		public void UpdateMaterial()
		{
			Color c = GetUpdatedColor();

			if (!mat)
			{
				mat = GetComponent<Image>().material;
			}

			mat.SetColor(_Color, c);
		}

		//Gets called after GUI of the color gradient changes
		public void UpdateColor()
		{
			Color c = GetUpdatedColor();

			//Add the colors of the inner box
			c = Color.Lerp(c, Color.white, inner.x);
			c = Color.Lerp(c, Color.black, inner.y);

			Selection = c;
			if (dynamicOutline)
			{
				outlineColor = c;
				mat.SetColor(_OutlineColor, c);
			}

			if (dynamicSaturation)
			{
				mat.SetFloat(_Saturation, 1-inner.x);
			}
			else
			{
				mat.SetFloat(_Saturation, 1);
			}

			if (dynamicValue)
			{
				mat.SetFloat(_Lightness, 1-inner.y);
			}
			else
			{
				mat.SetFloat(_Lightness, 1);
			}

			if (!outerSelector_mat)
			{
				outerSelector_mat = selectorOuter.GetComponent<Image>().material;
			}

			if (!innerSelector_mat)
			{
				innerSelector_mat = selectorInner.GetComponent<Image>().material;
			}

			//Set the color of the outer selector to match color selection
			outerSelector_mat.SetColor(_Color,c);

			//Rotate the selectors
			RotateSelectors();

			//Set the color of the inner selector to the inverse of it's greyscale value so it's always easily visible
			Color inverseGreyscale = Color.Lerp(Color.black, Color.white, inner.y);
			innerSelector_mat.SetColor(_Color,inverseGreyscale);

			ConvertToString(Selection);
		}

		private void RotateSelectors()
		{
			int direction;
			switch (rotation)
			{
				case Rotation.Clockwise:
					direction = -1;
					break;
				case Rotation.Counterclockwise:
					direction = 1;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			selectorOuter.Rotate(0,0,direction * 90f * (rotationSpeed * Time.deltaTime), Space.Self);
			if (rotateInner)
			{
				selectorInner.Rotate(0, 0, direction * 180f * (rotationSpeed * Time.deltaTime), Space.Self);
			}
		}

		private void ConvertToString(Color col)
		{
			if (!outputText) return;
			outputText.text = "#" + ColorUtility.ToHtmlStringRGB(col);
		}

		public void TryColorFromHex()
		{
			//If the user doesn't start with a '#' let's add it for them
			string input;
			if (inputText.text[0] != '#')
			{
				input = "#" + inputText.text;
			}
			else
			{
				input = inputText.text;
			}
			if (!ColorUtility.TryParseHtmlString(input, out Color color)) return;
			Selection = color;
			PickColor(color);
			UpdateMaterial();
			UpdateColor();
			inputText.text = "";
		}

		//Method for setting the picker to a given color
		public void PickColor(Color c){
			//Get hsb color from the rgb values
			float max = Mathf.Max (c.r, c.g, c.b);
			float min = Mathf.Min (c.r, c.g, c.b);
		
			float sat = (1 - min);

			//basically if (max == min) sat = 0;
			if(Math.Abs(max - min) < 0.001f){
				sat = 0;
			}

			const float root3 = 1.73205080757f;
			float hue = Mathf.Atan2(root3 *(c.g-c.b), 2* c.r-c.g-c.b);

			//Set the sliders
			outer = hue;
			inner.x = 1 - sat;
			inner.y = 1 - max;

			//And update them once
			UpdateMaterial();
		}


		//Gets called by an event trigger at a click
		private void OnClick(InputAction.CallbackContext context)
		{
			Vector2 mousePos = Mouse.current.position.ReadValue();
			//Check if click was in outer circle
			if(Vector2.Distance(new Vector2(RectTrans.position.x, RectTrans.position.y), mousePos) <= halfSize &&
			   Vector2.Distance(new Vector2(RectTrans.position.x, RectTrans.position.y), mousePos) >= halfSize - halfSize / 4){
				dragOuter = true;
				return;
			}
			//Check if click was in inner box
			if (!(Mathf.Abs(RectTrans.position.x - mousePos.x) <= halfSize / 2) ||
			    !(Mathf.Abs(RectTrans.position.y - mousePos.y) <= halfSize / 2)) return;
			dragInner = true;
		}

		private void TriggerPulled(InputAction.CallbackContext context)
        {

			XRRayInteractor interactor = null;

            if (context.action.name.Contains("Right"))
            {
				print("Right pressed");

				interactor = rightInteractor;
				rightHand = true;

			}
			else if (context.action.name.Contains("Left"))
            {
				print("Left pressed");

				interactor = leftInteractor;
				rightHand = false;
			}



			if (interactor.TryGetHitInfo(out Vector3 pos, out Vector3 normal, out int posInLine, out bool validTarget))
			{
				if (validTarget)
				{
					print(transform.InverseTransformPoint(pos));

					Vector2 rayPos = transform.InverseTransformPoint(pos);

					if (Vector2.Distance(new Vector2(RectTrans.position.x, RectTrans.position.y), rayPos) <= halfSize &&
			   Vector2.Distance(new Vector2(RectTrans.position.x, RectTrans.position.y), rayPos) >= halfSize - halfSize / 4)
					{
						print("drag outter");
						dragOuter = true;
						return;
					}
					//Check if click was in inner box
					if (!(Mathf.Abs(RectTrans.position.x - rayPos.x) <= halfSize / 2) ||
						!(Mathf.Abs(RectTrans.position.y - rayPos.y) <= halfSize / 2)) return;
					dragInner = true;
				}
			}

		}

		private void TriggerReleased(InputAction.CallbackContext context)
        {
			dragOuter = false;
			dragInner = false;
        }
	}

	public enum Rotation
	{
		Clockwise,
		Counterclockwise
	}
}
