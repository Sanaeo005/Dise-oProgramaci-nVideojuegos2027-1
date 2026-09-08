# Práctica 1 - Unity 2D

Carrillo Sánchez Rafael Esteban 320053786

## Estructura principal

```text
Assets/
├── Prefabs/
│   └── Jugador.prefab
├── Scenes/
│   └── SampleScene
├── Scripts/
│   ├── Jugador.cs
│   └── ControlJugador.cs
└── Sprites/
```

## Implementación

- Se importó y cortó un spritesheet (de ibuki de street fighter 3dstrike) usando `Sprite Mode = Multiple`
- Se creó un GameObject llamado `Jugador`
- El jugador contiene:
  - `Sprite Renderer`
  - `Box Collider 2D`
  - `Rigidbody 2D`
  - `Gravity Scale = 0`
- El jugador fue convertido en un prefab
- `Jugador.cs` detecta:
  - `OnCollisionEnter2D`
  - `OnCollisionStay2D`
- `ControlJugador.cs` detecta dentro de `Update()`:
  - movimiento horizontal
  - salto con la barra espaciadora
- Los eventos detectados se muestran en la consola mediante `Debug.Log()`

## Ejecución

1. Abrir el proyecto con Unity 2022.3.62f3
2. Abrir `Assets/Scenes/SampleScene`
3. Abrir la pestaña `Console`
4. Presionar `Play`
5. Probar:
   - `A` / `D` o flechas izquierda/derecha para detectar movimiento horizontal
   - Barra espaciadora para detectar el salto
   - Contacto del jugador con la pared para comprobar los mensajes de colisión

## Resultado esperado

En la consola deben aparecer mensajes como:

```text
Colisión iniciada con: Pared
Continúa la colisión con: Pared
Movimiento horizontal: ...
Salto detectado
```
