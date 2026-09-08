using UnityEngine;

public class Jugador : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colisión iniciada con: " + col.gameObject.name);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("Continua la colisión con: " + col.gameObject.name);
    }
}
