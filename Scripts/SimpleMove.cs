using UnityEngine;

/// <summary>
/// حركة اللاعب المحسّنة - يدير حركة اللاعب والرسوميات
/// Enhanced Player Movement - Manages player movement and animations
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class SimpleMove : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float sprintSpeed = 12f;
    [SerializeField] private float groundDrag = 0.1f;
    [SerializeField] private float gravityScale = 1f;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundDrag_Jump = 0.05f;

    [Header("Ground Detection")]
    [SerializeField] private float groundDrag_Normal = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private CharacterController cc;
    private Vector3 velocity = Vector3.zero;
    private float currentSpeed;
    private bool isGrounded;
    private bool canJump = true;

    // Animation
    private Animator animator;
    private bool isMoving;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (cc == null)
            Debug.LogError("CharacterController not found!");
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        ApplyGravity();
        MoveCharacter();
        UpdateAnimations();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // حساب الاتجاه
        Vector3 move = transform.right * x + transform.forward * z;

        // السرعة الحالية
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        // تطبيق الحركة
        velocity.x = move.x * currentSpeed;
        velocity.z = move.z * currentSpeed;

        // تحديث حالة الحركة
        isMoving = move.magnitude > 0;
    }

    void HandleJump()
    {
        // فحص إذا كان اللاعب على الأرض
        isGrounded = cc.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
            canJump = true;
        }

        // القفز
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y * gravityScale);
            canJump = false;
            isGrounded = false;
        }
    }

    void ApplyGravity()
    {
        // تطبيق الجاذبية
        velocity.y += Physics.gravity.y * gravityScale * Time.deltaTime;

        // الحد الأقصى للسقوط
        velocity.y = Mathf.Clamp(velocity.y, -20f, 20f);
    }

    void MoveCharacter()
    {
        cc.Move(velocity * Time.deltaTime);
    }

    void UpdateAnimations()
    {
        if (animator != null)
        {
            animator.SetBool("IsMoving", isMoving);
            animator.SetBool("IsGrounded", isGrounded);
            animator.SetFloat("Speed", isMoving ? 1f : 0f);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetSprintSpeed(float newSprintSpeed)
    {
        sprintSpeed = newSprintSpeed;
    }

    public Vector3 GetVelocity()
    {
        return velocity;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
