using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Transform objetivo;
    private Rigidbody2D rb;

    private Rigidbody2D jugadorRB;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        objetivo = puntoA;
    }

    void FixedUpdate()
    {
        if (puntoA == null || puntoB == null || rb == null)
        {
            return;
        }

        Vector2 posicionAnterior = rb.position;

        Vector2 nuevaPosicion = Vector2.MoveTowards(
            posicionAnterior,
            objetivo.position,
            velocidad * Time.fixedDeltaTime
        );

        Vector2 desplazamiento = nuevaPosicion - posicionAnterior;

        rb.MovePosition(nuevaPosicion);

        //Transportar al jugador junto con la plataforma
        if (jugadorRB != null)
        {
            jugadorRB.MovePosition(
                jugadorRB.position + desplazamiento
            );
        }

        if (Vector2.Distance(nuevaPosicion, objetivo.position) < 0.1f)
        {
            objetivo = (objetivo == puntoA) ? puntoB : puntoA;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
        {
            return;
        }

        RevisarJugadorSobrePlataforma(col);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
        {
            return;
        }

        RevisarJugadorSobrePlataforma(col);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Rigidbody2D cuerpo = col.rigidbody;

            if (jugadorRB == cuerpo)
            {
                jugadorRB = null;
            }
        }
    }

    void RevisarJugadorSobrePlataforma(Collision2D col)
    {
        bool estaEncima = false;

        foreach (ContactPoint2D contacto in col.contacts)
        {
            if (contacto.normal.y < -0.5f)
            {
                estaEncima = true;
                break;
            }
        }

        if (estaEncima)
        {
            jugadorRB = col.rigidbody;
        }
        else if (jugadorRB == col.rigidbody)
        {
            jugadorRB = null;
        }
    }
}