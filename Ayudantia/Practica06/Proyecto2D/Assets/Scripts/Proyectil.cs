using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidadBase = 10f;
    public float tiempoVida = 2f;
    public int daño = 1;

    private Vector2 direccion;
    private float velocidadExtra = 0f;

    public void Inicializar(Vector2 dir, float velocidadJugador)
    {
        direccion = dir.normalized;

        //Heredo la velocidad horizontal del jugador
        velocidadExtra = velocidadJugador * direccion.x;

        //Orientación visual del proyectil
        if (direccion.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        float velocidadFinal = velocidadBase + velocidadExtra;

        transform.position += (Vector3)(
            direccion * velocidadFinal * Time.deltaTime
        );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemigo"))
        {
            EnemigoIA enemigo = col.GetComponent<EnemigoIA>();

            if (enemigo != null)
            {
                enemigo.RecibirDaño(daño);
            }

            Destroy(gameObject);
        }

        if (col.CompareTag("Pared") ||
            col.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}