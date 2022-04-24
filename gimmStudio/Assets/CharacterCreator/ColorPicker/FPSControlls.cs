// GENERATED AUTOMATICALLY FROM 'Assets/FPSControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FPSControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FPSControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FPSControlls"",
    ""maps"": [
        {
            ""name"": ""FPSPlayer"",
            ""id"": ""275fc1c9-6227-47e6-8c04-8f1660449b50"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a06a3ce7-79aa-45d6-9666-0f0c46be274f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""3c3d00c4-24b7-4763-8022-25477fef83de"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e74c9b06-ac04-4a2b-bcf1-796586d4901e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MouseConfirm"",
                    ""type"": ""Button"",
                    ""id"": ""d99397d3-e114-471e-906e-122091066489"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""MouseCancel"",
                    ""type"": ""Button"",
                    ""id"": ""66931b2a-f816-4572-a471-a503da7510d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""InteractCancel"",
                    ""type"": ""Button"",
                    ""id"": ""93014a1d-3ea2-47f5-9158-656c99d41dda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""9e0eee0c-35fc-4733-8d90-15defce9b9cf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Chat"",
                    ""type"": ""Button"",
                    ""id"": ""7e0b39e6-43d4-4683-a48a-eeb10498e129"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d1a2b2d7-d208-4b3c-9742-c26473f82b06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MenuToggle"",
                    ""type"": ""Button"",
                    ""id"": ""a04406e2-ea8c-43f2-8d88-d82e2e30b3e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MapCamera"",
                    ""type"": ""Button"",
                    ""id"": ""3c1fe8ec-1236-4463-8880-5441173f03ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Questing"",
                    ""type"": ""Button"",
                    ""id"": ""cd2f55fd-b07e-4cc4-9182-8f38c7d1f81e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RightTriggerPull"",
                    ""type"": ""Button"",
                    ""id"": ""604009de-60a6-4dac-908d-24a43a513ab7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LeftTriggerPull"",
                    ""type"": ""Button"",
                    ""id"": ""12303658-5b25-403c-969b-8855db0d5388"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""da5b16eb-20b6-4bf0-8913-97b8f8c11439"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2695df28-db05-4a88-9398-ad4ca8d1883b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4a4b5f73-af8f-4dd0-b0a6-78b8e9767915"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""446ad519-4d92-4e5e-91e6-5adfb665dd5d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""70c3d07c-fd0e-473a-ac27-6ad4f1984bdb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""667c873c-e293-4f79-9158-2828acf79f69"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4fed0afb-3567-4d26-a272-0fee088635ae"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""36f005fb-fc7d-4cb1-997d-999db6abcc19"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d6b669a5-0418-428b-8fa1-f4990c5946bd"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5ccf90f0-225b-4f90-bccb-b46c539f7254"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""99661c29-8f64-4b45-8757-7f2c6f455c13"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3d3bdd0c-07ff-42d8-b09f-272a7e208ac8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7266e1dd-3058-45f5-881e-ae023d6e5dc5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2cea429a-f1d9-4bf5-adc5-3bdca1066fbe"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""79f2efc7-1049-422d-887b-fa7b8f55ddec"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0d4cfac8-20ad-4125-a4c5-1a3efd73a542"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89780de5-5f20-424c-addb-68f30f060768"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e233d6dc-0744-4975-b62f-96a5c96a90ac"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MouseConfirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65f79882-4130-4af0-bd5d-064a07053f78"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MouseCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""586e4823-ae5b-457a-8bed-e1ba4cf08b9d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""InteractCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16fc240c-8af1-42eb-a058-5c7acd721d79"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9266a03-89d1-479d-9fa8-88bca8e89919"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Chat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca9b58f0-bc26-473b-a76a-3c3a492b048b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3922fe12-34a1-4305-b570-b334dcf161d9"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controlls"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d8361ef-6f83-48d0-849f-1a8e69e52f54"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MenuToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bebfe9c9-bb06-47f3-b1dd-3044da0fd083"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controlls"",
                    ""action"": ""MenuToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6c9d289-d304-4aa3-b998-a7c29a402eeb"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MapCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5935c5b9-dc2d-45cf-a317-ffdfe31a2032"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Questing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e071ad50-50f2-46a1-825a-05d3ce30a2c4"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controlls"",
                    ""action"": ""RightTriggerPull"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adf525c1-1a4b-4861-a3dd-a3b79b5c6ae5"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controlls"",
                    ""action"": ""LeftTriggerPull"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR Controlls"",
            ""bindingGroup"": ""XR Controlls"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // FPSPlayer
        m_FPSPlayer = asset.FindActionMap("FPSPlayer", throwIfNotFound: true);
        m_FPSPlayer_Movement = m_FPSPlayer.FindAction("Movement", throwIfNotFound: true);
        m_FPSPlayer_MouseLook = m_FPSPlayer.FindAction("MouseLook", throwIfNotFound: true);
        m_FPSPlayer_Interact = m_FPSPlayer.FindAction("Interact", throwIfNotFound: true);
        m_FPSPlayer_MouseConfirm = m_FPSPlayer.FindAction("MouseConfirm", throwIfNotFound: true);
        m_FPSPlayer_MouseCancel = m_FPSPlayer.FindAction("MouseCancel", throwIfNotFound: true);
        m_FPSPlayer_InteractCancel = m_FPSPlayer.FindAction("InteractCancel", throwIfNotFound: true);
        m_FPSPlayer_MousePosition = m_FPSPlayer.FindAction("MousePosition", throwIfNotFound: true);
        m_FPSPlayer_Chat = m_FPSPlayer.FindAction("Chat", throwIfNotFound: true);
        m_FPSPlayer_Jump = m_FPSPlayer.FindAction("Jump", throwIfNotFound: true);
        m_FPSPlayer_MenuToggle = m_FPSPlayer.FindAction("MenuToggle", throwIfNotFound: true);
        m_FPSPlayer_MapCamera = m_FPSPlayer.FindAction("MapCamera", throwIfNotFound: true);
        m_FPSPlayer_Questing = m_FPSPlayer.FindAction("Questing", throwIfNotFound: true);
        m_FPSPlayer_RightTriggerPull = m_FPSPlayer.FindAction("RightTriggerPull", throwIfNotFound: true);
        m_FPSPlayer_LeftTriggerPull = m_FPSPlayer.FindAction("LeftTriggerPull", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // FPSPlayer
    private readonly InputActionMap m_FPSPlayer;
    private IFPSPlayerActions m_FPSPlayerActionsCallbackInterface;
    private readonly InputAction m_FPSPlayer_Movement;
    private readonly InputAction m_FPSPlayer_MouseLook;
    private readonly InputAction m_FPSPlayer_Interact;
    private readonly InputAction m_FPSPlayer_MouseConfirm;
    private readonly InputAction m_FPSPlayer_MouseCancel;
    private readonly InputAction m_FPSPlayer_InteractCancel;
    private readonly InputAction m_FPSPlayer_MousePosition;
    private readonly InputAction m_FPSPlayer_Chat;
    private readonly InputAction m_FPSPlayer_Jump;
    private readonly InputAction m_FPSPlayer_MenuToggle;
    private readonly InputAction m_FPSPlayer_MapCamera;
    private readonly InputAction m_FPSPlayer_Questing;
    private readonly InputAction m_FPSPlayer_RightTriggerPull;
    private readonly InputAction m_FPSPlayer_LeftTriggerPull;
    public struct FPSPlayerActions
    {
        private @FPSControlls m_Wrapper;
        public FPSPlayerActions(@FPSControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_FPSPlayer_Movement;
        public InputAction @MouseLook => m_Wrapper.m_FPSPlayer_MouseLook;
        public InputAction @Interact => m_Wrapper.m_FPSPlayer_Interact;
        public InputAction @MouseConfirm => m_Wrapper.m_FPSPlayer_MouseConfirm;
        public InputAction @MouseCancel => m_Wrapper.m_FPSPlayer_MouseCancel;
        public InputAction @InteractCancel => m_Wrapper.m_FPSPlayer_InteractCancel;
        public InputAction @MousePosition => m_Wrapper.m_FPSPlayer_MousePosition;
        public InputAction @Chat => m_Wrapper.m_FPSPlayer_Chat;
        public InputAction @Jump => m_Wrapper.m_FPSPlayer_Jump;
        public InputAction @MenuToggle => m_Wrapper.m_FPSPlayer_MenuToggle;
        public InputAction @MapCamera => m_Wrapper.m_FPSPlayer_MapCamera;
        public InputAction @Questing => m_Wrapper.m_FPSPlayer_Questing;
        public InputAction @RightTriggerPull => m_Wrapper.m_FPSPlayer_RightTriggerPull;
        public InputAction @LeftTriggerPull => m_Wrapper.m_FPSPlayer_LeftTriggerPull;
        public InputActionMap Get() { return m_Wrapper.m_FPSPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPSPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IFPSPlayerActions instance)
        {
            if (m_Wrapper.m_FPSPlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMovement;
                @MouseLook.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseLook;
                @Interact.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnInteract;
                @MouseConfirm.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseConfirm;
                @MouseConfirm.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseConfirm;
                @MouseConfirm.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseConfirm;
                @MouseCancel.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseCancel;
                @MouseCancel.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseCancel;
                @MouseCancel.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMouseCancel;
                @InteractCancel.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnInteractCancel;
                @InteractCancel.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnInteractCancel;
                @InteractCancel.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnInteractCancel;
                @MousePosition.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMousePosition;
                @Chat.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnChat;
                @Chat.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnChat;
                @Chat.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnChat;
                @Jump.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnJump;
                @MenuToggle.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMenuToggle;
                @MenuToggle.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMenuToggle;
                @MenuToggle.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMenuToggle;
                @MapCamera.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMapCamera;
                @MapCamera.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMapCamera;
                @MapCamera.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnMapCamera;
                @Questing.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnQuesting;
                @Questing.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnQuesting;
                @Questing.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnQuesting;
                @RightTriggerPull.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnRightTriggerPull;
                @RightTriggerPull.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnRightTriggerPull;
                @RightTriggerPull.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnRightTriggerPull;
                @LeftTriggerPull.started -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnLeftTriggerPull;
                @LeftTriggerPull.performed -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnLeftTriggerPull;
                @LeftTriggerPull.canceled -= m_Wrapper.m_FPSPlayerActionsCallbackInterface.OnLeftTriggerPull;
            }
            m_Wrapper.m_FPSPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @MouseConfirm.started += instance.OnMouseConfirm;
                @MouseConfirm.performed += instance.OnMouseConfirm;
                @MouseConfirm.canceled += instance.OnMouseConfirm;
                @MouseCancel.started += instance.OnMouseCancel;
                @MouseCancel.performed += instance.OnMouseCancel;
                @MouseCancel.canceled += instance.OnMouseCancel;
                @InteractCancel.started += instance.OnInteractCancel;
                @InteractCancel.performed += instance.OnInteractCancel;
                @InteractCancel.canceled += instance.OnInteractCancel;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Chat.started += instance.OnChat;
                @Chat.performed += instance.OnChat;
                @Chat.canceled += instance.OnChat;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MenuToggle.started += instance.OnMenuToggle;
                @MenuToggle.performed += instance.OnMenuToggle;
                @MenuToggle.canceled += instance.OnMenuToggle;
                @MapCamera.started += instance.OnMapCamera;
                @MapCamera.performed += instance.OnMapCamera;
                @MapCamera.canceled += instance.OnMapCamera;
                @Questing.started += instance.OnQuesting;
                @Questing.performed += instance.OnQuesting;
                @Questing.canceled += instance.OnQuesting;
                @RightTriggerPull.started += instance.OnRightTriggerPull;
                @RightTriggerPull.performed += instance.OnRightTriggerPull;
                @RightTriggerPull.canceled += instance.OnRightTriggerPull;
                @LeftTriggerPull.started += instance.OnLeftTriggerPull;
                @LeftTriggerPull.performed += instance.OnLeftTriggerPull;
                @LeftTriggerPull.canceled += instance.OnLeftTriggerPull;
            }
        }
    }
    public FPSPlayerActions @FPSPlayer => new FPSPlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_XRControllsSchemeIndex = -1;
    public InputControlScheme XRControllsScheme
    {
        get
        {
            if (m_XRControllsSchemeIndex == -1) m_XRControllsSchemeIndex = asset.FindControlSchemeIndex("XR Controlls");
            return asset.controlSchemes[m_XRControllsSchemeIndex];
        }
    }
    public interface IFPSPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMouseConfirm(InputAction.CallbackContext context);
        void OnMouseCancel(InputAction.CallbackContext context);
        void OnInteractCancel(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnChat(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMenuToggle(InputAction.CallbackContext context);
        void OnMapCamera(InputAction.CallbackContext context);
        void OnQuesting(InputAction.CallbackContext context);
        void OnRightTriggerPull(InputAction.CallbackContext context);
        void OnLeftTriggerPull(InputAction.CallbackContext context);
    }
}
