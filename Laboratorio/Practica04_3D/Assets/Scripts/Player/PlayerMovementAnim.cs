using UnityEngine;

public class PlayerMovementAnim : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private Transform playerRoot;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponentInParent<CharacterController>();
        playerRoot = controller.transform;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isGrounded = controller.isGrounded;
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        bool isJumping = jumpPressed || !isGrounded;

        anim.SetBool("IsJumping", isJumping);

        float inputMagnitude = new Vector2(x, z).magnitude;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float speedValue = 0f;

        // Solo caminar/correr cuando estamos tocando el suelo
        if (isGrounded && !jumpPressed && inputMagnitude > 0.1f)
        {
            speedValue = isRunning ? 1.0f : 0.5f;
        }

        anim.SetFloat("Speed", speedValue);

        Vector3 direction = new Vector3(x, 0, z);

        if (direction.magnitude > 0.1f)
        {
            playerRoot.rotation = Quaternion.Slerp(
                playerRoot.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * 10f
            );
        }
    }

    void OnAnimatorMove()
    {
        if (anim == null)
            return;

        // Root Motion es procesado por el script,
        // pero el desplazamiento físico sigue a cargo de PlayerMovement.
    }
}