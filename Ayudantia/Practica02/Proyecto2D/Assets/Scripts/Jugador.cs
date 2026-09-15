using UnityEngine;

public class Jugador : MonoBehaviour
{
    public bool enSuelo = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colisión iniciada con: " + col.gameObject.name);

        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("Continúa la colisión con: " + col.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}