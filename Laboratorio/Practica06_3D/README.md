# Práctica 06 - Movimiento Relativo a la Cámara (Camera-Relative Movement)

Carrillo Sánchez Rafael Esteban - 320053786

## Versión de Unity

Unity 2022.3.62f3 LTS

## Objetivo

Implementar el movimiento del personaje en función de la orientación de la cámara en tercera persona, con rotación suave y conservando las animaciones y funcionalidades de las prácticas anteriores.

## Funcionamiento

- Se creó `Practica06_3D` a partir del proyecto de la Práctica 05.
- Se prepararon los prefabs `CameraRig` y `PlayerCharacter` y se conservó el personaje de la escena.
- `PlayerMovement.cs` calcula el desplazamiento con los vectores `forward` y `right` de `CameraRig`, sin componente vertical.
- `PlayerMovementAnim.cs` orienta suavemente al personaje hacia la dirección de movimiento mediante `Quaternion.Slerp` y actualiza el `Animator`.
- `WASD` permite moverse según la orientación de la cámara; `Shift` permite correr y `Espacio` saltar.
- Se conservaron la cámara orbital, su seguimiento y la detección de obstáculos.
- **Nota sobre Root Motion:** las animaciones se reproducen mediante el `Animator`, pero el desplazamiento físico horizontal continúa controlado por `CharacterController.Move()` en `PlayerMovement.cs`; no se aplica `anim.deltaPosition`.

## Cómo ejecutar el proyecto

1. Abrir el proyecto `Practica06_3D` desde Unity Hub.
2. Abrir la escena:

   `Assets/Scenes/Practica06_3D.unity`

3. Presionar el botón `Play`.
4. Probar los siguientes controles:
   - `WASD` para caminar en relación con la cámara.
   - `Shift + WASD` para correr.
   - `Espacio` para saltar.
   - Mover el mouse para girar la cámara; al cambiar su orientación, cambia la dirección de avance.

## Estructura

```text
Assets/
├── Animations/
├── Imports/
├── Materials/
├── Prefabs/
│   ├── CameraRig.prefab
│   ├── PlayerBody.prefab
│   └── PlayerCharacter.prefab
├── Scenes/
│   └── Practica06_3D.unity
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

- El personaje se mueve según la orientación horizontal de la cámara con `WASD`.
- La rotación hacia la dirección de desplazamiento es suave.
- Las animaciones `Idle`, `Walk`, `Run` y `Jump` funcionan correctamente.
- El personaje puede caminar, correr, saltar y mover la cámara simultáneamente.
- La cámara mantiene su seguimiento, rotación orbital y colisiones con obstáculos.
