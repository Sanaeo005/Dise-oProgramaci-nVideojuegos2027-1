# Práctica 2 - Unity 2D

Carrillo Sánchez Rafael Esteban 320053786

## Implementación

- Se agregó movimiento horizontal manual usando velocidad, aceleración y `deltaTime`.
- Se implementó el cálculo manual de `deltaTime` con `Time.time`.
- Se agregó salto con `Input.GetAxis("Jump")`.
- Se implementó gravedad manual mediante una velocidad vertical.
- `Jugador.cs` controla si el personaje está tocando el suelo mediante la variable `enSuelo`.
- `ControlJugador.cs` obtiene el componente `Jugador` con `GetComponent<Jugador>()`.
- El jugador solo puede iniciar un salto cuando está tocando un objeto con la etiqueta `Suelo`.
- El `Rigidbody 2D` mantiene `Gravity Scale = 0` y la rotación en Z está bloqueada.

## Ejecución

1. Abrir el proyecto con Unity 2022.3.62f3.
2. Abrir `Assets/Scenes/SampleScene`.
3. Presionar `Play`.
4. Probar:
   - `A` / `D` o flechas izquierda/derecha para desplazarse.
   - Barra espaciadora para saltar.
   - Mantener brevemente la barra espaciadora para prolongar el impulso del salto.

## Resultado esperado

El personaje debe desplazarse horizontalmente con aceleración, saltar únicamente al estar en el suelo y volver a caer por efecto de la gravedad manual.
