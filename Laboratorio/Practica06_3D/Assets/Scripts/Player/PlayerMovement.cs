using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public Transform cameraTransform;

    public float speed = 6f;
    public float runSpeed = 10f;
    public float gravity = -9.8f;
    public float jumpForce = 8f;

    CharacterController controller;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		//Direcciones de la cámara
		Vector3 camForward = cameraTransform.forward;
		Vector3 camRight = cameraTransform.right;

		//Componente vertical
		camForward.y = 0f;
		camRight.y = 0f;

		//Normalizar los vectores
		camForward.Normalize();
		camRight.Normalize();

		//Movimiento relativo a la cámara
		Vector3 move = camForward * z + camRight * x;

		move = Vector3.ClampMagnitude(move, 1f);

		bool isRunning = Input.GetKey(KeyCode.LeftShift);
		float currentSpeed = isRunning ? runSpeed : speed;

		bool grounded = controller.isGrounded;

		if (grounded && velocity.y < 0)
		    velocity.y = -2f;

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		    velocity.y = jumpForce;

		controller.Move(move * currentSpeed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
    }
    
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
	Rigidbody rb = hit.collider.attachedRigidbody;

	if (rb == null || rb.isKinematic)
	    return;

	Vector3 pushDir = new Vector3(
	hit.moveDirection.x,
	0,
	hit.moveDirection.z
	);

	rb.velocity = pushDir * 4f;
    }
}
