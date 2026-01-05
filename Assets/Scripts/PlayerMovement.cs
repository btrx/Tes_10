using UnityEngine;
using UnityEngine.InputSystem; // Namespace wajib untuk Input System baru

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;

    [Header("Input Setup")]
    // Referensi ke Action Asset yang sudah dibuat di Editor
    public InputActionReference moveActionRef;

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
    }

    void OnDisable()
    {
        // TODO 2: Matikan (Disable) action reference untuk mencegah memory leak/error
        // ...
    }

    void Update()
    {
        // TODO 3: Baca nilai Vector2 dari Input Action
        // Hint: Gunakan .action.ReadValue<Vector2>()
        // moveInput = ...
    }

    void FixedUpdate()
    {
        // TODO 4: Gerakkan karakter menggunakan Rigidbody Position
        // Rumus: Posisi Saat Ini + (Input * Kecepatan * FixedDeltaTime)
        // rb.MovePosition(...);
    }
}