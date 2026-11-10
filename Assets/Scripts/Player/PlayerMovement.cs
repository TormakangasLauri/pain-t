using System.Collections;
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

        float speed = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude;

        // Convert movement input to relative movement
        Vector3 movementInput = player.forward * input.move.y + player.right * input.move.x;
        

        // When given input
        if (movementInput != Vector3.zero){
            // Increase speed
            values.currentSpeed += Time.fixedDeltaTime * values.acceleration;

            // Set current movement direction if not set
            if (values.currentMoveDirection == Vector3.zero) values.currentMoveDirection = movementInput;
            // Change desired movement direction
            values.currentMoveDirection = Vector3.Lerp(values.currentMoveDirection, movementInput, Time.fixedDeltaTime * values.turnSpeed);
        }
        // No input
        else {
            // Decrease speed
            values.currentSpeed -= Time.fixedDeltaTime * values.deceleration;
            
            // Reset movement direction
            if (values.currentSpeed < 0.01) values.currentMoveDirection = Vector3.zero;
        }


        // Clamp speed
        values.currentSpeed = Mathf.Clamp(values.currentSpeed, 0, values.maxSpeed);

        // Apply the movement to the rigidbody
        rb.linearVelocity = values.currentMoveDirection * values.currentSpeed;
    }

    public void Jump()
    {
        StartCoroutine(WaitForJumping());
    }

    IEnumerator WaitForJumping()
    {
        yield return null;
    }
}
