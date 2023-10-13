
 using UnityEngine;
// Class for controlling the player's movements and actions like attacking and gathering resources.
public class PlayerController : MonoBehaviour
{
    public delegate void HealthChangedEvent(int newHealth);
    public event HealthChangedEvent OnHealthChanged;

    int newHealth = 0;

    private void Update()
    {
        var vector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ;
        transform.position += vector.normalized * 5f * Time.deltaTime;
    }
    
    public void CollectResource() {}
}
