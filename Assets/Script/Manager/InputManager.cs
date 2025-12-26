using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, InputSystem_Actions.IPlayerActions 
{
    public static InputManager Instance;

    public event UnityAction Interact = delegate { };

    InputSystem_Actions inputActions;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);

        this.inputActions = new InputSystem_Actions();

        inputActions.Player.AddCallbacks(this);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnDestroy()
    {
        inputActions.Dispose();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed) Interact.Invoke();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }
}
