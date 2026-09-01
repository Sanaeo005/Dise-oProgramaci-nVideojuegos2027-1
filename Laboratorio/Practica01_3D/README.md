# Práctica 01 - Movimiento y Cámara (Unity 3D)

Carrillo Sánchez Rafael Esteban - 320053786

## Versión de Unity

Unity 2022.3.62f3 LTS

## Objetivo

Implementar un controlador básico para un personaje 3D usando `CharacterController`, junto con dos cámaras intercambiables:

- Cámara en tercera persona (TPS)
- Cámara en primera persona (FPS)

## Controles:

- `W A S D`: mover al personaje
- `Shift izquierdo`: correr
- `Espacio`: saltar
- `Mouse`: controlar la vista
- `Tab`: alternar entre cámara TPS y FPS

## Cómo ejecutar el proyecto: 

1. Abrir el proyecto `Practica01_3D` desde Unity Hub
2. Abrir la escena:

   `Assets/Scenes/Practica01_3D.unity`

3. Presionar el botón `Play`
4. Hacer clic dentro de la ventana `Game`
5. Utilizar los controles indicados anteriormente

## Estructura 

Assets/
├── Scenes/
│   └── Practica01_3D.unity
└── Scripts/
    ├── Camera/
    │   └── CameraSwitcher.cs
    ├── Player/
    │   └── PlayerMovement.cs
    ├── CameraLook.cs
    └── SmoothFollow.cs


## Problema con el salto

Durante las pruebas, el personaje podía moverse correctamente con `WASD`, pero no saltaba al presionar la barra espaciadora.
El problema era que `CharacterController.isGrounded` se consultaba después de ejecutar un movimiento horizontal con 
`controller.Move(...)`, entonces en ese momento podía devolver false aunque el personaje estuviera sobre el piso.

Lo que hice fue guardar primero el estado de `isGrounded` en una variable y usar ese valor para comprobar el salto antes de realizar el movimiento horizontal, después de cambiar este orden, el personaje ya podía saltar.