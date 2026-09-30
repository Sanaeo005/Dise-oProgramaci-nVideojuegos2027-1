# Práctica 03 - Física, Colisiones e Interacción (Unity 3D)

Carrillo Sánchez Rafael Esteban - 320053786

## Versión de Unity

Unity 2022.3.62f3 LTS

## Objetivo

Implementar interacción física en 3D mediante `Rigidbody`, `Colliders` y `Triggers`, permitiendo al jugador empujar objetos, recoger objetos y activar mecanismos simples.

## Funcionamiento

- El jugador puede empujar objetos físicos con `Rigidbody`.
- Se agregaron varias cajas `PushBox` distribuidas en la escena.
- Se creó un objeto recogible `PickupItem` mediante un `Trigger`.
- Al tocar el `PickupItem`, el objeto desaparece y se muestra el mensaje `Objeto recogido` en la consola.
- Se creó una puerta activable mediante un `DoorTrigger`.
- La puerta se abre al entrar el jugador en la zona del trigger y se cierra al salir.
- La puerta fue guardada como `Prefab`.

## Cómo ejecutar el proyecto

1. Abrir el proyecto `Practica03_3D` desde Unity Hub.
2. Abrir la escena:

   `Assets/Scenes/Practica03_3D.unity`

3. Presionar el botón `Play`.
4. Probar las siguientes interacciones:
   - Empujar las cajas `PushBox`.
   - Tocar el `PickupItem` para recogerlo.
   - Entrar y salir de la zona `DoorTrigger` para abrir y cerrar la puerta.

## Estructura

```text
Assets/
├── Scenes/
│   └── Practica03_3D.unity
├── Scripts/
│   ├── Player/
│   │   └── PlayerMovement.cs
│   └── Interaction/
│       ├── PickupItem.cs
│       └── DoorTrigger.cs
└── Prefabs/
    └── DoorPrefab.prefab
```

## Pruebas realizadas

Se verificó que:

- El jugador mantiene el movimiento, salto y colisiones de la práctica anterior.
- Las cajas caen por gravedad y pueden ser empujadas por el jugador.
- Las cajas colisionan correctamente con los obstáculos.
- El `PickupItem` desaparece al ser tocado por el jugador.
- La consola muestra el mensaje `Objeto recogido`.
- La puerta se abre al entrar al `DoorTrigger`.
- La puerta se cierra al salir del `DoorTrigger`.
