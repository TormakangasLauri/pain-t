using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "EntityValues/PlayerData")]
public class PlayerValues : ScriptableObject
{
    [Header("Movement")]
    public float maxSpeed;
    public float minSpeed;
    public float acceleration;
    public float deceleration;
    [Tooltip("How fast the player can change movement direction")]
    public float turnSpeed;

    [Header("Jump")]
    public float jumpForce;
    [Tooltip("Extra force in the movement direction")]
    public float jumpForwardForce;

    [Header("Walljump")]
    public float walljumpUpForce;
    [Tooltip("Extra force in the movement direction")]
    public float walljumpForwardForce;
    [Tooltip("Extra force away from the wall")]
    public float walljumpAwayForce;

    [Header("Camera")]
    public float mouseSensitivity;

    // Non-static values
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public Vector3 currentMovement;
}
