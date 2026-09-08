using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (h != 0)
        {
            Debug.Log("Movimiento horizontal: " + h);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Salto detectado");
        }
    }
}
