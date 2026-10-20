using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 look { get; private set; }
    public Vector2 move { get; private set; }
    public float jump { get; private set; }
    public int crouch { get; private set; }
    public int attack { get; private set; }
    public int interact { get; private set; }

    public void OnLook(InputValue inputValue)
    {
        look = inputValue.Get<Vector2>();
    }

    public void OnMove(InputValue inputValue)
    {
        move = inputValue.Get<Vector2>();
        Debug.Log(move);
    }

    public void OnJump(InputValue inputValue)
    {
        jump = inputValue.Get<float>();
        SendMessage("Jump");
    }

    void Update()
    {
        // Debug.Log(jump);
    }
}
