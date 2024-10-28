using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    [Header("Running")]
    [SerializeField] private bool canRun = true;
    [SerializeField] private float runSpeed = 9;
    public bool IsRunning { get; private set; }
    public KeyCode runningKey = KeyCode.LeftShift;

    new Rigidbody rigidbody;


    void Awake()
    {
        // Get the rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get moving speed - if running is true movement speed = run speed, else moving speed stays normal
        float targetMovingSpeed = IsRunning ? runSpeed : speed; 

        // Get targetVelocity
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
}