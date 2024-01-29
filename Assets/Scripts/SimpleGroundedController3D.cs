using UnityEngine;


/**
 * This component allows a character to move and jump, but only when touching the ground.
 * 
 * SOURCE: Unity examples:
 * https://github.com/Unity-Technologies/PhysicsExamples2D/blob/master/Assets/Scripts/SceneSpecific/Miscellaneous/SimpleGroundedController.cs
 */
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TouchDetector))]
public class SimpleGroundedController3D : MonoBehaviour
{
    [SerializeField] float JumpImpulse = 7f;
    [SerializeField] float SideSpeed = 2f;
    [SerializeField] float RotateSpeed = 100f;
    [SerializeField] float _speed;

    private Animator _animator;
    private Rigidbody rigidBody;
    private TouchDetector touchDetector;
    private bool playerWantsToJump;
    private float horizontalSpeed;
    private float vertcialSpeed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        touchDetector = GetComponent<TouchDetector>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Keyboard events are tested each frame, so we should check them here.
        if (Input.GetKeyDown(KeyCode.Space))
            playerWantsToJump = true;

        if (vertcialSpeed > 0 || horizontalSpeed > 0)
        {
            _animator.SetBool("Walking", true);
        }
        else
        {
            _animator.SetBool("Walking", false);
        }


        WalkPosition();
    }

    // this controls the player when he rotates or walks//
    void WalkPosition()
    {
        vertcialSpeed = Input.GetAxis("Vertical") * _speed;
        horizontalSpeed = Input.GetAxis("Horizontal") * RotateSpeed;
        vertcialSpeed *= Time.deltaTime;
        horizontalSpeed *= Time.deltaTime;
        transform.Translate(0, 0, vertcialSpeed);
        transform.Rotate(0, horizontalSpeed, 0);

    }

    void FixedUpdate()
    {
        // Handle jump.
        // NOTE: If instructed to jump, we'll check if we're grounded.
        if (playerWantsToJump && touchDetector.IsTouching())
            rigidBody.AddForce(Vector3.up * JumpImpulse, ForceMode.Impulse);

        // Set velocity.
        rigidBody.velocity = new Vector3(horizontalSpeed, rigidBody.velocity.y, vertcialSpeed);

        // Reset movement.
        playerWantsToJump = false;
        horizontalSpeed = 0f;
    }
}
