# Práctica 5 - Unity 2D

Carrillo Sánchez Rafael Esteban 320053786

## Implementación

- Se creó la superclase `Personaje` con atributos de velocidad y vida, referencias a componentes y métodos para recibir daño y morir.
- Se modificó `Jugador` para heredar de `Personaje`, conservando el movimiento, salto y animaciones de la práctica anterior.
- Se creó `EnemigoIA`, que también hereda de `Personaje` y se desplaza automáticamente mediante `Rigidbody2D`.
- Se implementó el patrullaje tipo Goomba: el enemigo cambia de dirección al chocar con objetos etiquetados como `Pared` u `Obstaculo`.
- Se agregó detección de colisiones con el jugador para aplicar daño al contacto lateral y derrotar al enemigo al saltar sobre él.
- Se sustituyó el sprite inicial del enemigo por Dry Bones y se crearon las animaciones `Enemigocaminar` y `EnemigoIdle`, controladas mediante el parámetro `Caminando` del Animator.

## Ejecución

1. Abrir el proyecto con Unity 2022.3.62f3.
2. Abrir `Assets/Scenes/SampleScene`.
3. Presionar `Play`.
4. Probar:
   - `A` / `D` o flechas izquierda/derecha para desplazarse.
   - Barra espaciadora para saltar.
   - Verificar que el enemigo patrulle y cambie de dirección al tocar las paredes.
   - Observar la animación de caminata de Dry Bones.
   - Comprobar que el contacto lateral con el enemigo reduzca la vida del jugador.
   - Saltar sobre el enemigo para derrotarlo.

## Resultado esperado

El jugador debe conservar sus controles y animaciones, mientras Dry Bones patrulla automáticamente entre obstáculos y reproduce su animación de caminata. Al chocar lateralmente con el enemigo, el jugador pierde vida; al caer sobre él, el enemigo es derrotado y desaparece.
