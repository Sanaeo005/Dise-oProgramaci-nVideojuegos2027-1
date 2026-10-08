# Práctica 04 - Animación de Personaje 3D (Unity 3D)

Carrillo Sánchez Rafael Esteban - 320053786

## Versión de Unity

Unity 2022.3.62f3 LTS

## Objetivo

Integrar un personaje humanoide animado en Unity 3D utilizando `Animator`, `Blend Tree` y animaciones importadas desde Mixamo, permitiendo reproducir estados de reposo, caminata, carrera y salto de acuerdo con las acciones del jugador.

## Funcionamiento

- Se importó un personaje humanoide desde Mixamo y se configuró con rig `Humanoid`.
- Se configuró un `Animator Controller` para controlar las animaciones del personaje.
- Se agregaron los parámetros `Speed` e `IsJumping`.
- Se creó un `Blend Tree` para alternar entre caminata y carrera.
- El personaje permanece en `Idle` cuando no se mueve.
- Con `WASD` el personaje camina.
- Con `WASD + Shift` el personaje corre.
- Con la barra espaciadora el personaje salta.
- Mientras el personaje está en el aire no se reproducen las animaciones de caminar o correr.
- Se conservaron el movimiento, colisiones, cámara e interacciones de las prácticas anteriores.
- El manejo de las animaciones se realiza mediante el script `PlayerMovementAnim.cs`.

## Cómo ejecutar el proyecto

1. Abrir el proyecto `Practica04_3D` desde Unity Hub.
2. Abrir la escena:

   `Assets/Scenes/Practica04_3D.unity`

3. Presionar el botón `Play`.
4. Probar los siguientes controles:
   - `WASD` para caminar.
   - `Shift + WASD` para correr.
   - `Espacio` para saltar.
   - Mover el mouse para controlar la cámara.

## Estructura

```text
Assets/
├── Animations/
│   └── Player/
│       ├── Idle.fbx
│       ├── Walk.fbx
│       ├── Run.fbx
│       ├── Jump.fbx
│       └── PlayerAnimatorController.controller
├── Imports/
├── Materials/
├── Prefabs/
├── Scenes/
│   └── Practica04_3D.unity
├── Scripts/
│   └── Player/
│       ├── PlayerMovement.cs
│       └── PlayerMovementAnim.cs
└── Textures/
```

## Pruebas realizadas

Se verificó que:

- El personaje cambia correctamente entre `Idle`, `Walk` y `Run`.
- La caminata se activa con `WASD`.
- La carrera se activa al mantener `Shift`.
- La animación de salto se reproduce al presionar la barra espaciadora.
- El personaje no cambia a caminar o correr mientras está en el aire.
- Al aterrizar, el personaje regresa correctamente a su estado de movimiento.
- La cámara continúa siguiendo al jugador correctamente.
- El `CharacterController` mantiene las colisiones con el escenario y los obstáculos.
- Las interacciones de las prácticas anteriores continúan funcionando.
- No se presentan errores críticos en consola durante la ejecución.
