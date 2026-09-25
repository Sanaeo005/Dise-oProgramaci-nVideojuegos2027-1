# Práctica 3 - Unity 2D

Carrillo Sánchez Rafael Esteban 320053786

## Implementación

- Se agregó desaceleración automática cuando no hay entrada horizontal.
- Se ajustó el cambio de dirección para que el personaje frene antes de acelerar en sentido contrario.
- Se utilizó `Input.GetAxisRaw("Horizontal")` para obtener una respuesta más inmediata al mover al personaje.
- Se implementó Coyote Time para permitir saltar durante un breve intervalo después de abandonar una plataforma.
- Se implementó Jump Buffering para recordar una pulsación de salto realizada poco antes de tocar el suelo.
- Se mejoró la gravedad durante la caída usando una gravedad mayor cuando la velocidad vertical es negativa.
- Se agregaron las variables `estaCaminando`, `estaSaltando` y `estaCayendo` para preparar futuras animaciones.
- Se mantiene la comunicación entre `Jugador.cs` y `ControlJugador.cs` para detectar si el personaje está en el suelo.

## Ejecución

1. Abrir el proyecto con Unity 2022.3.62f3.
2. Abrir `Assets/Scenes/SampleScene`.
3. Presionar `Play`.
4. Probar:
   - `A` / `D` o flechas izquierda/derecha para desplazarse.
   - Barra espaciadora para saltar.
   - Salir de una plataforma y presionar salto poco después para probar el Coyote Time.
   - Presionar salto poco antes de tocar el suelo para probar el Jump Buffering.
   - Observar en el Inspector los estados `Esta Caminando`, `Esta Saltando` y `Esta Cayendo`.

## Resultado esperado

El personaje debe desplazarse horizontalmente con aceleración y frenado progresivo, cambiar de dirección de forma controlada, saltar con Coyote Time y Jump Buffering, caer con una gravedad más fuerte y actualizar correctamente sus estados de movimiento para futuras animaciones.
