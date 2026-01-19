using UnityEngine;
using UnityEngine.InputSystem; // Namespace wajib untuk Input System baru

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;

    [Header("Input Setup")]
    // Referensi ke Action Asset yang sudah dibuat di Editor
    public InputActionReference moveActionRef;

    [Header("Animations")]
    public Animator animator;
    private Vector2 lastMove;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // --- PENTING: Input Action harus di-Enable/Disable manual ---
    void OnEnable()
    {
        // TODO 1: Aktifkan (Enable) action reference agar input bisa terbaca
        // ...
        moveActionRef.action.Enable();
    }

    void OnDisable()
    {
        // TODO 2: Matikan (Disable) action reference untuk mencegah memory leak/error
        // ...
        moveActionRef.action.Disable();
    }

    void Update()
    {
        // TODO 3: Baca nilai Vector2 dari Input Action
        // Hint: Gunakan .action.ReadValue<Vector2>()
        // moveInput = ...
        moveInput = moveActionRef.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // TODO 4: Gerakkan karakter menggunakan Rigidbody Position
        // Rumus: Posisi Saat Ini + (Input * Kecepatan * FixedDeltaTime)
        // rb.MovePosition(...);
        Move();
        AnimationUpdate();
    }

    void Move()
    {
        // Fungsi ini bisa diisi jika ingin menambahkan logika tambahan saat bergerak
         rb.MovePosition(rb.position + (moveInput * moveSpeed * Time.fixedDeltaTime));
    }

    void AnimationUpdate()
    {
        float moveMagnitude = moveInput.magnitude;
        animator.SetFloat("Speed", moveMagnitude);

        // Update arah animasi berdasarkan input
        if (moveMagnitude > 0.01f){
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
            animator.SetFloat("LastMoveX", moveInput.x);
            animator.SetFloat("LastMoveY", moveInput.y);
        } else {
            animator.SetFloat("MoveX", lastMove.x);
            animator.SetFloat("MoveY", lastMove.y);
            animator.SetFloat("LastMoveX", lastMove.x);
            animator.SetFloat("LastMoveY", lastMove.y);
        }
    }
}