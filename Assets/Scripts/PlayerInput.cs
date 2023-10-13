using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector2 HandleMovementInput() => playerInputActions.Player.Move.ReadValue<Vector2>();
}
