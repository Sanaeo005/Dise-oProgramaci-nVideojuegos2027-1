# Práctica 6 - Unity 2D

Carrillo Sánchez Rafael Esteban 320053786

## Implementación

- Se creó el prefab `Proyectil` con `Sprite Renderer`, `Circle Collider 2D` y `Rigidbody2D`, junto con el script `Proyectil` para controlar su dirección, velocidad, daño y tiempo de vida.
- Se agregó el sistema de disparo a `Jugador`, utilizando `PuntoDisparo` y heredando la velocidad horizontal del personaje.
- Se implementaron las colisiones de los proyectiles con paredes, obstáculos y enemigos, aplicando daño mediante `RecibirDaño`.
- Se crearon plataformas móviles horizontales y verticales con el script `PlataformaMovil`, que se desplazan entre dos puntos.
- Se agregó el transporte del jugador sobre las plataformas para que pueda desplazarse junto con ellas y saltar desde su superficie.
- Se creó la animación `Disparo` y se incorporó un efecto de sonido, conservando las animaciones y el sonido de salto anteriores.

## Ejecución

1. Abrir el proyecto con Unity 2022.3.62f3.
2. Abrir `Assets/Scenes/SampleScene`.
3. Presionar `Play`.
4. Probar:
   - `A` / `D` o flechas izquierda/derecha para desplazarse.
   - Barra espaciadora para saltar.
   - `Ctrl` izquierdo o clic izquierdo para disparar hacia ambos lados.
   - Disparar mientras se camina o salta y comprobar la animación y el sonido.
   - Impactar al enemigo con proyectiles para reducir su vida y derrotarlo.
   - Subir a las plataformas horizontal y vertical, comprobar que transporten al jugador y saltar desde ellas.

## Resultado esperado

El jugador debe conservar las mecánicas de las prácticas anteriores y poder disparar proyectiles con animación y sonido. Los disparos deben dañar enemigos y desaparecer al impactar o al terminar su tiempo de vida. Las plataformas deben moverse entre sus puntos de referencia y transportar al jugador mientras permanece sobre ellas.
