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
        float currentAngle = transform.localRotation.x;

        float newAngle = currentAngle + diff;
        if (clampRotation)
        {
            newAngle = Mathf.Clamp(newAngle, -upperAngleLimit, lowerAngleLimit);
        }

        // Vector3 cameraRotation = transform.localEulerAngles;
        // cameraRotation.x = 180;
        // transform.localEulerAngles = cameraRotation;

        transform.localRotation = Quaternion.Euler(newAngle, 0, 0);
    }
}
