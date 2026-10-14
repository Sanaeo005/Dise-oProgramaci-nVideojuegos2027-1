# Práctica 05 - Cámara TPS Avanzada (Orbit, Follow, Collision)

Carrillo Sánchez Rafael Esteban - 320053786

## Versión de Unity

Unity 2022.3.62f3 LTS

## Objetivo

Implementar una cámara en tercera persona que siga al personaje, permita rotar alrededor de él con el mouse y evite atravesar obstáculos mediante detección de colisiones.

## Funcionamiento

- Se creó la escena `Practica05_3D` a partir del proyecto de la práctica anterior.
- Se creó un prefab del personaje `PlayerBody`.
- Se construyó un sistema independiente con `CameraRig`, `CameraPivot` y `Main Camera`.
- El script `CameraController.cs` permite girar la cámara horizontalmente y limita su inclinación vertical.
- La cámara sigue al personaje mientras camina, corre o salta.
- `CameraCollision.cs` utiliza `Physics.Raycast` para detectar obstáculos y ajustar suavemente la distancia de la cámara.
- Se conservaron los controles, animaciones y colisiones del personaje de las prácticas anteriores.

## Cómo ejecutar el proyecto

1. Abrir el proyecto `Practica05_3D` desde Unity Hub.
2. Abrir la escena:

   `Assets/Scenes/Practica05_3D.unity`

3. Presionar el botón `Play`.
4. Probar los siguientes controles:
   - `WASD` para caminar.
   - `Shift + WASD` para correr.
   - `Espacio` para saltar.
   - Mover el mouse para girar la cámara alrededor del personaje.

## Estructura

```text
Assets/
├── Animations/
├── Imports/
├── Materials/
├── Prefabs/
│   └── PlayerBody.prefab
├── Scenes/
│   └── Practica05_3D.unity
├── Scripts/
│   ├── Camera/
│   │   ├── CameraController.cs
│   │   └── CameraCollision.cs
│   └── Player/
│       ├── PlayerMovement.cs
│       └── PlayerMovementAnim.cs
└── Textures/
```

## Pruebas realizadas

Se verificó que:

- La cámara gira 360° horizontalmente y respeta los límites verticales.
- La cámara sigue al personaje al caminar, correr y saltar.
- Es posible mover al personaje y girar la cámara simultáneamente usando un mouse físico.
- La cámara se acerca al personaje cuando detecta paredes u obstáculos y recupera su distancia al despejarse.
- El movimiento, las animaciones y las colisiones del personaje continúan funcionando.
- No se presentaron errores en la consola durante las pruebas.
