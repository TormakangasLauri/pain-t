using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput input;
    Rigidbody rb;
    [SerializeField] PlayerValues values;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Transform player = transform.parent;
        // Convert movement input to relative movement
        Vector3 movementInput = player.forward * input.move.y + player.right * input.move.x;
        

        // Accelerate
        if (movementInput != Vector3.zero){
            values.currentSpeed += Time.fixedDeltaTime * values.acceleration;
        }
        // Decelerate
        else {
            values.currentSpeed -= Time.fixedDeltaTime * values.deceleration;
        }
        // Clamp speed
        values.currentSpeed = Mathf.Clamp(values.currentSpeed, 0, values.maxSpeed);

        // Movement direction
        values.currentMovement = Vector3.Lerp(values.currentMovement, movementInput, Time.fixedDeltaTime * values.turnSpeed);

        // Applying the movement to the rigidbody
        rb.linearVelocity = values.currentMovement * values.currentSpeed;
    }

    public void Jump()
    {
        // Jumping
    }
}
