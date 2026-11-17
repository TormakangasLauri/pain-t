using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] PlayerValues values;

    [SerializeField] bool clampRotation = true;
    [SerializeField] [Range(0, 180)] float upperAngleLimit = 90;
    [SerializeField] [Range(0, 180)] float lowerAngleLimit = 90;

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
        float diff = -mouseInput.y * values.mouseSensitivity;
        float newAngle = transform.rotation.x + diff;
        // Clamp if needed
        if (clampRotation) Mathf.Clamp(newAngle, lowerAngleLimit, -upperAngleLimit);
        // Rotation itself
        transform.rotation = Quaternion.Euler(newAngle, transform.rotation.y, transform.rotation.z);
    }
}
