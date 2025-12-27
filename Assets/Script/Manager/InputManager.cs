using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;



public class InputHandler : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] InputSystem_Actions _inputActions;

    InputSystem_Actions.PlayerActions _playerActions;

    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            this._inputActions = new InputSystem_Actions();

            this._playerActions = this._inputActions.Player;

            this._playerActions.AddCallbacks(this);

        }
        this._inputActions.Enable();  
    }

    private void OnDisable()
    {
        this._inputActions?.Disable();
    }


    public void OnPoint(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
              /*  Debug.Log("Point");*/
                GameEvent.InvokePoint(context.ReadValue<Vector2>());
                break;
            default:
                break;
        }

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                Debug.Log("Click");
                GameEvent.InvokeClick();
                break;
            default:
                break;
        }

    }

}
