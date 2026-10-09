using UnityEngine;

public class EnemigoIA : Personaje
{
    public float direccion = -1f;

    private Animator anim;

    protected override void Awake()
    {
        base.Awake();

        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Movimiento horizontal del enemigo
        rb.velocity = new Vector2(
            direccion * velocidad,
            rb.velocity.y
        );
    }

    void Update()
    {
        // Animación Drybone
        if (anim != null)
        {
            bool caminando = Mathf.Abs(rb.velocity.x) > 0.1f;
            anim.SetBool("Caminando", caminando);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Patrullaje 
        if (col.gameObject.CompareTag("Pared") ||
            col.gameObject.CompareTag("Obstaculo"))
        {
            direccion *= -1f;
            sr.flipX = !sr.flipX;
        }

        // Interacción con el jugador
        if (col.gameObject.CompareTag("Player"))
        {
            Jugador jugador = col.gameObject.GetComponent<Jugador>();

            if (jugador == null)
                return;

            bool golpeDesdeArriba = false;

            foreach (ContactPoint2D contacto in col.contacts)
            {
                if (contacto.normal.y < -0.5f)
                {
                    golpeDesdeArriba = true;
                    break;
                }
            }

            if (golpeDesdeArriba)
            {
                Debug.Log("¡El jugador ha derrotado al enemigo!");
                RecibirDaño(1);
            }
            else
            {
                Debug.Log("¡El enemigo ha dañado al jugador!");
                jugador.RecibirDaño(1);
            }
        }
    }
}