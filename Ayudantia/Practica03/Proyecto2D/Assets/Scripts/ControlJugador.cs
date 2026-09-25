using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidadActual = 0f;
    public float velocidadMax = 4f;
    public float aceleracion = 5f;
    public float desaceleracion = 12f;

    public float velocidadVertical = 0f;
    public float gravedad = -20f;
    public float gravedadCaida = -30f;
    public float tiempoCoyote = 0.4f;
    public float tiempoBufferSalto = 0.1f;
    public float tiempoMaxSalto = 0.2f;
    public bool estaCaminando;
    public bool estaSaltando;
    public bool estaCayendo;

    private float tiempoSaltoActual = 0f;
    private float tiempoAnterior;
    private float coyoteTimer = 0f;
    private float bufferTimer = 0f;

    private Jugador jugador;

    void Awake()
    {
        jugador = GetComponent<Jugador>();
    }

    void Start()
    {
        tiempoAnterior = Time.time;
    }

    void Update()
    {
        // Calculo manual de deltaTime
        float delta = Time.time - tiempoAnterior;
        tiempoAnterior = Time.time;

        // Movimiento horizontal
        float h = Input.GetAxisRaw("Horizontal");

        if (h == 0)
        {
            // Frenado progresivo sin sobrepasar el cero
            velocidadActual = Mathf.MoveTowards(
                velocidadActual,
                0f,
                desaceleracion * delta
            );
        }
        else
        {
            // Si el jugador intenta cambiar de direccion,
            // frenamos mas fuerte
            if (Mathf.Sign(h) != Mathf.Sign(velocidadActual) &&
                Mathf.Abs(velocidadActual) > 0.1f)
            {
                velocidadActual += h * desaceleracion * delta;
            }
            else
            {
                velocidadActual += h * aceleracion * delta;
            }
        }

        velocidadActual = Mathf.Clamp(
            velocidadActual,
            -velocidadMax,
            velocidadMax
        );

        transform.position += new Vector3(
            velocidadActual * delta,
            0,
            0
        );

        // Coyote Time
        if (jugador.enSuelo)
        {
            coyoteTimer = tiempoCoyote;
        }
        else
        {
            coyoteTimer -= delta;
        }

        // Jump Buffering
        if (Input.GetAxis("Jump") > 0)
        {
            bufferTimer = tiempoBufferSalto;
        }
        else
        {
            bufferTimer -= delta;
        }

        // Salto con Coyote Time y Jump Buffering
        if (bufferTimer > 0 && coyoteTimer > 0)
        {
            velocidadVertical = 10f;
            jugador.enSuelo = false;
            tiempoSaltoActual = 0f;

            bufferTimer = 0f;
            coyoteTimer = 0f;
        }

        // Mientras se mantenga presionado Jump,
        // el personaje puede seguir ganando altura
        if (!jugador.enSuelo && Input.GetAxis("Jump") > 0)
        {
            if (tiempoSaltoActual < tiempoMaxSalto)
            {
                velocidadVertical += 20f * delta;
                tiempoSaltoActual += delta;
            }
        }

        // Si sse suelta el botón, se termina el impulso adicional
        if (Input.GetAxis("Jump") == 0)
        {
            tiempoSaltoActual = tiempoMaxSalto;
        }

        // Gravedad mejorada
        if (jugador.enSuelo)
        {
            velocidadVertical = 0f;
        }
        else
        {
            if (velocidadVertical < 0)
                velocidadVertical += gravedadCaida * delta;
            else
                velocidadVertical += gravedad * delta;
        }

        // Movimiento vertical
        transform.position += new Vector3(
            0,
            velocidadVertical * delta,
            0
        );

        // Estados para animaciones
        estaCaminando = Mathf.Abs(velocidadActual) > 0.1f;
        estaSaltando = velocidadVertical > 0.1f;
        estaCayendo = velocidadVertical < -0.1f;
    }
}
