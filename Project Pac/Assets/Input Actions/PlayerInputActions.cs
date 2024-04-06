// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""2bd5d3f6-a947-4d82-80be-9ecfd48de6ee"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a993b82a-ef25-4b58-8b8a-c64ce828b49f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone,NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""e60cb285-f180-4345-99f2-396e816cafca"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DodgeRoll"",
                    ""type"": ""Button"",
                    ""id"": ""552a98e6-f834-420d-86a2-b1aaffe18fc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""8bec8344-8298-4d0d-8916-006f1b3628f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""72dc4810-7456-46ba-8da2-96223aecd47f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""da9c6ce9-9a2e-498c-8b22-f4ac4118256f"",
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
                    ""id"": ""995c031b-0ba0-4db7-8521-9b53a22c5a57"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06e1f5d9-c732-442b-b4b3-c0fdfb483f05"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f40b2e4d-4ad1-4de8-b543-c62442fec3e3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c323936e-daa8-4656-8bab-f820e7fa347f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""fd935890-407a-47c4-8e32-62a6fe0cc90f"",
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
                    ""id"": ""22417d40-a7f3-402c-aa35-7611de4fd378"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1732ce3b-4053-49b6-978c-624cf75d4e11"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4973c04c-c013-4816-8843-a3623c68239f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0c5e0af5-7e58-4274-b129-c3082df4974a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6e73b36c-11bb-49a8-92a3-efd4e62019c3"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cb6820e-7e4d-445a-b240-da0b468c8408"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4a44233-78b2-4e03-ac97-95b45add9257"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bcc418c-e226-4aa9-a95c-58408c31fdd3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b4d409d-5c1b-4a95-8ac7-0e244faf3cda"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Movement = m_CharacterControls.FindAction("Movement", throwIfNotFound: true);
        m_CharacterControls_Look = m_CharacterControls.FindAction("Look", throwIfNotFound: true);
        m_CharacterControls_DodgeRoll = m_CharacterControls.FindAction("DodgeRoll", throwIfNotFound: true);
        m_CharacterControls_Attack = m_CharacterControls.FindAction("Attack", throwIfNotFound: true);
        m_CharacterControls_Throw = m_CharacterControls.FindAction("Throw", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Movement;
    private readonly InputAction m_CharacterControls_Look;
    private readonly InputAction m_CharacterControls_DodgeRoll;
    private readonly InputAction m_CharacterControls_Attack;
    private readonly InputAction m_CharacterControls_Throw;
    public struct CharacterControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public CharacterControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterControls_Movement;
        public InputAction @Look => m_Wrapper.m_CharacterControls_Look;
        public InputAction @DodgeRoll => m_Wrapper.m_CharacterControls_DodgeRoll;
        public InputAction @Attack => m_Wrapper.m_CharacterControls_Attack;
        public InputAction @Throw => m_Wrapper.m_CharacterControls_Throw;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnLook;
                @DodgeRoll.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDodgeRoll;
                @DodgeRoll.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDodgeRoll;
                @DodgeRoll.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDodgeRoll;
                @Attack.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @Throw.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnThrow;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @DodgeRoll.started += instance.OnDodgeRoll;
                @DodgeRoll.performed += instance.OnDodgeRoll;
                @DodgeRoll.canceled += instance.OnDodgeRoll;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnDodgeRoll(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
    }
}
