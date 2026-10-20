using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] PlayerValues values;

    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Movement
    }

    public void Jump()
    {
        // Jumping
    }
}
