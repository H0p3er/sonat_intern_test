using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, InputSystem_Actions.IUIActions
{
    public static InputManager Instance;

    public event UnityAction Click = delegate { };

    public Vector2 MousePosition => _uiWrapper.Point.ReadValue<Vector2>();

    InputSystem_Actions _inputActions;

    InputSystem_Actions.UIActions _uiWrapper;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            this._inputActions = new InputSystem_Actions();

            _uiWrapper = this._inputActions.UI;

            _uiWrapper.AddCallbacks(this);

        }
        _uiWrapper.Enable();
    }

    private void OnDisable()
    {
        _inputActions?.Disable();
    }


    public void OnNavigate(InputAction.CallbackContext context)
    {
  
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
     
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
/*        Debug.Log("Perform");*/
        if (context.performed) Click.Invoke();
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        
    }
}
