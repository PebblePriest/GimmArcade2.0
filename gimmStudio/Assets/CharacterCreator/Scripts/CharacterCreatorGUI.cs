using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using ColorPicker;
using UnityEngine.UI;

public class CharacterCreatorGUI : MonoBehaviour
{

    [SerializeField] private CharacterCreatorSO characterData;

    [SerializeField] private List<Button> colorButtons;

    [SerializeField] private Transform headAnchor;
    [SerializeField] private Transform bodyAnchor;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject colorPickerCanvasPrefab;
    private ColorWheelControl colorWheelControl;
    private GameObject _activeColorPickerCanvas;
    private bool colorOpen;
    private int spinDirection = -3;
    [SerializeField] private int colorIndex;
    private bool vrUser;
    [SerializeField] private Transform colorPickerLocation;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("vrEnabled") == 0)
        {
            vrUser = true;
        }

        else if (PlayerPrefs.GetInt("vrEnabled") == 1)
        {
            vrUser = false;
        }
    }
    public void OpenColorPicker(int i)
    {
        Debug.Log("step 1: opencolorpicker");
        if (colorPickerCanvasPrefab == null || _activeColorPickerCanvas != null) return;
        Debug.Log("step 2: not null");
        colorOpen = true;
        if (vrUser)
        {
            _activeColorPickerCanvas = Instantiate(colorPickerCanvasPrefab, colorPickerLocation);
        }
        else
        {
            _activeColorPickerCanvas = Instantiate(colorPickerCanvasPrefab);
        }

        Debug.Log("step 3: Instantiate");
        _activeColorPickerCanvas.transform.GetChild(0).Find("CloseButton").GetComponent<Button>().onClick.AddListener(CloseColorPicker);
        Debug.Log("step 4: addListener");
        colorIndex = i;
        /* colorIndex ints:
         * 0 = hair
         * 1 = eyes
         * 2 = top
         * 3 = bottom
         * 4 = hat
         * 5 = mask
         * 6 = body
         * 7 = hands
         */
        colorWheelControl = _activeColorPickerCanvas.transform.GetChild(0).GetComponent<ColorWheelControl>();
        Debug.Log("step 5: set colorWheelControl");
        Color c = characterData.GetLastColor(i);
        Debug.Log("step 6: Set Color: " + c);
        if (c == Color.white) colorWheelControl.SetDefaultColor();
        colorWheelControl.PickColor(c);
        colorWheelControl.UpdateMaterial();
        colorWheelControl.UpdateColor();
    }

    private void CloseColorPicker()
    {
        colorOpen = false;
        characterData.ApplyColor(colorIndex, colorWheelControl.Selection);
        colorButtons[colorIndex].GetComponent<Image>().color = colorWheelControl.Selection;
        Destroy(_activeColorPickerCanvas);
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    private void Start()
    {
        characterData.LoadCharacterOnCreator(bodyAnchor, true);
    }

    private void Update()
    {
        if (colorOpen)
        {
            characterData.ApplyColor(colorIndex, colorWheelControl.Selection);
        }

        spinDirection = colorOpen ? 1 : -3;
        transform.Rotate(Vector3.up, Time.deltaTime * 10f * spinDirection);
    }

    private void SaveFile()
    {
        string destination = Application.persistentDataPath + "/charprefs.dat";

        FileStream file = File.Exists(destination) ? File.OpenWrite(destination) : File.Create(destination);

        CharacterPreferences charPrefs = new CharacterPreferences(
            characterData._hairIndex, characterData._hairColor,
            characterData._eyesIndex, characterData._eyeColor,
            characterData._topIndex, characterData._topColor,
            characterData._bottomIndex, characterData._bottomColor,
            characterData._hatIndex, characterData._hatColor,
            characterData._maskIndex, characterData._maskColor,
            characterData._baseIndex, characterData._baseColor,
            characterData._handsIndex, characterData._handsColor
        );
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, charPrefs);
        file.Close();
    }

    public void ExecuteButtonHandler()
    {
        SaveFile();
    }

    public void BoolHair()
    {
        characterData._hair = !characterData._hair;
        characterData.ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAIR, characterData._hair, characterData._hairIndex, headAnchor);
    }

    public void BoolEyes()
    {
        characterData._hat = !characterData._eyes;
    }

    public void BoolTop()
    {
        characterData._top = !characterData._top;
        characterData.ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.TOP, characterData._top, characterData._topIndex, bodyAnchor);
    }

    public void BoolBottom()
    {
        characterData._bottom = !characterData._bottom;
        characterData.ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BOTTOM, characterData._bottom, characterData._bottomIndex, bodyAnchor);
    }

    public void BoolHat()
    {
        characterData._hat = !characterData._hat;
        characterData.ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAT, characterData._hat, characterData._hatIndex, headAnchor);
    }

    public void BoolMask()
    {
        characterData._mask = !characterData._mask;
        characterData.ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.MASK, characterData._mask, characterData._maskIndex, headAnchor);
    }

    public void BoolBase()
    {
        characterData._base = !characterData._base;
        characterData.ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BASE, characterData._base, characterData._baseIndex, bodyAnchor);
    }

    public void BoolHands()
    {
        characterData._hands = !characterData._hands;
        characterData.ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HANDS, characterData._hands, characterData._handsIndex, headAnchor);
    }
}