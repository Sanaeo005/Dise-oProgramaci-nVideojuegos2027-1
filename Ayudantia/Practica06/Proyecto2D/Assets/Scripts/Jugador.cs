using UnityEngine;

public class Jugador : Personaje
{
    public bool enSuelo = false;

    [Header("Sistema de disparo")]
    public GameObject prefabProyectil;
    public Transform puntoDisparo;

    private ControlJugador controlJugador;
    private float direccionDisparo = 1f;
    private Animator anim;
    [Header("Audio del disparo")]
    public AudioClip sonidoDisparo;

    private AudioSource audioSrc;

    protected override void Awake()
    {
        base.Awake();

        controlJugador = GetComponent<ControlJugador>();
        anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Determinamos hacia donde mira el jugador
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            direccionDisparo = Mathf.Sign(horizontal);
        }

        //Dispara al presionar el boton Fire1
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        if (prefabProyectil == null || puntoDisparo == null)
        {
            Debug.LogWarning("Falta configurar el sistema de disparo.");
            return;
        }

        if (anim != null)
        {
            anim.SetTrigger("Disparando");
        }

        if (audioSrc != null && sonidoDisparo != null)
        {
            audioSrc.PlayOneShot(sonidoDisparo);
        }

        Vector2 direccion = direccionDisparo > 0
            ? Vector2.right
            : Vector2.left;

        //Colocamos el punto de disparo delante del jugador
        Vector3 posicionLocal = puntoDisparo.localPosition;

        posicionLocal.x =
            Mathf.Abs(posicionLocal.x) * direccionDisparo;

        puntoDisparo.localPosition = posicionLocal;

        //Creación del proyectil
        GameObject proyectil = Instantiate(
            prefabProyectil,
            puntoDisparo.position,
            Quaternion.identity
        );

        //Obtener la velocidad horizontal actual del jugador.
        float velocidadJugador = controlJugador != null
            ? controlJugador.velocidadActual
            : 0f;

        //Inicializar el proyectil.
        Proyectil scriptProyectil =
            proyectil.GetComponent<Proyectil>();

        if (scriptProyectil != null)
        {
            scriptProyectil.Inicializar(
                direccion,
                velocidadJugador
            );
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        RevisarContactoSuelo(col);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        RevisarContactoSuelo(col);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Suelo") ||
            col.gameObject.CompareTag("Plataforma"))
        {
            enSuelo = false;
        }
    }

    void RevisarContactoSuelo(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Suelo") &&
            !col.gameObject.CompareTag("Plataforma"))
        {
            return;
        }

        foreach (ContactPoint2D contacto in col.contacts)
        {
            if (contacto.normal.y > 0.5f)
            {
                enSuelo = true;
                return;
            }
        }
    }
}