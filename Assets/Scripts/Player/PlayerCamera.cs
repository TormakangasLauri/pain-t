using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] PlayerValues values;

    void Start()
    {
        // Hide and lock cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get input
        Vector2 mouseInput = input.look;

        // Rotate player
        transform.parent.Rotate(new Vector3(0, mouseInput.x * values.mouseSensitivity, 0));
        // Rotate camera
        transform.Rotate(-mouseInput.y * values.mouseSensitivity, 0, 0);
    }
}
