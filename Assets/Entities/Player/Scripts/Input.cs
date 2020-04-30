// GENERATED AUTOMATICALLY FROM 'Assets/Entities/Player/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Player2D"",
            ""id"": ""fca18afe-a535-4bc0-a7a6-5bb26e97fba0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""93243d4d-ceee-4f60-bb79-98fd5f6d7242"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2cc47a97-963b-4677-a404-56967e35459d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""e6a3d4e3-1826-4aa8-8081-f65d72406951"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7b381611-191b-4685-80f5-0261f5fe1b70"",
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
                    ""id"": ""c4fcc5d0-83ae-4f1b-828c-90a8973c8a35"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2f839fbd-1941-4229-a48a-19df999a7fc0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""03fd37fd-b4b1-4b2f-a187-9fae626544c6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""62222d8b-5827-4e17-8a35-940b67e00568"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8910c91b-255b-47cd-a86a-e5bd8b0090f9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afbc1cdf-2a64-493c-8329-d79eaf585b05"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerManager"",
            ""id"": ""06d060aa-1b97-45da-8a76-c996470a3d16"",
            ""actions"": [
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""f0a67f56-25f9-46ec-a505-c3aa68172fee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""315842a9-73fe-4016-b6cf-83a22a9ff832"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player2D
        m_Player2D = asset.FindActionMap("Player2D", throwIfNotFound: true);
        m_Player2D_Movement = m_Player2D.FindAction("Movement", throwIfNotFound: true);
        m_Player2D_Jump = m_Player2D.FindAction("Jump", throwIfNotFound: true);
        // PlayerManager
        m_PlayerManager = asset.FindActionMap("PlayerManager", throwIfNotFound: true);
        m_PlayerManager_Switch = m_PlayerManager.FindAction("Switch", throwIfNotFound: true);
        m_Player2D_Interaction = m_Player2D.FindAction("Interaction", throwIfNotFound: true);
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

    // Player2D
    private readonly InputActionMap m_Player2D;
    private IPlayer2DActions m_Player2DActionsCallbackInterface;
    private readonly InputAction m_Player2D_Movement;
    private readonly InputAction m_Player2D_Jump;
    private readonly InputAction m_Player2D_Interaction;
    public struct Player2DActions
    {
        private @Input m_Wrapper;
        public Player2DActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player2D_Movement;
        public InputAction @Jump => m_Wrapper.m_Player2D_Jump;
        public InputAction @Interaction => m_Wrapper.m_Player2D_Interaction;
        public InputActionMap Get() { return m_Wrapper.m_Player2D; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2DActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2DActions instance)
        {
            if (m_Wrapper.m_Player2DActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player2DActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player2DActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player2DActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_Player2DActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player2DActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player2DActionsCallbackInterface.OnJump;
                @Interaction.started -= m_Wrapper.m_Player2DActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_Player2DActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_Player2DActionsCallbackInterface.OnInteraction;
            }
            m_Wrapper.m_Player2DActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
            }
        }
    }
    public Player2DActions @Player2D => new Player2DActions(this);

    // PlayerManager
    private readonly InputActionMap m_PlayerManager;
    private IPlayerManagerActions m_PlayerManagerActionsCallbackInterface;
    private readonly InputAction m_PlayerManager_Switch;
    public struct PlayerManagerActions
    {
        private @Input m_Wrapper;
        public PlayerManagerActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Switch => m_Wrapper.m_PlayerManager_Switch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerManager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerManagerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerManagerActions instance)
        {
            if (m_Wrapper.m_PlayerManagerActionsCallbackInterface != null)
            {
                @Switch.started -= m_Wrapper.m_PlayerManagerActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_PlayerManagerActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_PlayerManagerActionsCallbackInterface.OnSwitch;
            }
            m_Wrapper.m_PlayerManagerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
            }
        }
    }
    public PlayerManagerActions @PlayerManager => new PlayerManagerActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    public interface IPlayer2DActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
    }
    public interface IPlayerManagerActions
    {
        void OnSwitch(InputAction.CallbackContext context);
    }
}
