using UnityEngine;

public class PlayerMovementAnim : MonoBehaviour
{
    public Transform cameraTransform;

    private Animator anim;
    private CharacterController controller;
    private Transform playerRoot;
    private Vector3 moveDir;

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

        
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        //componente vertical
        camForward.y = 0f;
        camRight.y = 0f;

        // Normalizacion de los vectores
        camForward.Normalize();
        camRight.Normalize();

        //Dirección relativa a la cámara
        //Vector3 moveDir = camForward * z + camRight * x;
        moveDir = camForward * z + camRight * x;
        moveDir = Vector3.ClampMagnitude(moveDir, 1f);

        // Rotacion del personaje hacia donde se mueve
        if (moveDir.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            playerRoot.rotation = Quaternion.Slerp(
                playerRoot.rotation,
                targetRotation,
                Time.deltaTime * 10f
            );
        }

}

    void OnAnimatorMove()
    {
        if (anim == null)
            return;

    }
}