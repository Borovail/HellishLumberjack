using UnityEngine.InputSystem;
using UnityEngine;
// Class for controlling the player's movements and actions like attacking and gathering resources.
public class PlayerController : MonoBehaviour
{
    public delegate void HealthChangedEvent(int newHealth);
    public event HealthChangedEvent OnHealthChanged;

    int newHealth = 0;
    //private PlayerInput playerInput;
    //private PlayerInputActions playerInputActions;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float speed;

    private void Awake() {
        //playerInput = GetComponent<PlayerInput>();
        //playerInputActions = new PlayerInputActions();
        //playerInputActions.Player.Enable();
    }

    private void Update() {
        Move();
    }

    /*private Vector2 HandleMovementInput() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }*/
    private void Move(){
        // Calculate the target position based on input
        Vector3 targetPosition = transform.position + new Vector3(playerInput.HandleMovementInput().x, playerInput.HandleMovementInput().y, 0) * speed * Time.deltaTime;

        // Smoothly interpolate towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f); // Adjust the last parameter to control the smoothing amount
    }

    // Logic when player takes damage
    public void TakeDamage(int amount)
    {
        // Update health
        OnHealthChanged?.Invoke(newHealth);
    }

    // Logic for collecting resources
    public void CollectResource() {}
}
