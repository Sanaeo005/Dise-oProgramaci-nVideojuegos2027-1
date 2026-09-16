# Práctica 02 - Terreno y Navegación (NavMesh)

Carrillo Sánchez Rafael Esteban - 320053786

## Versión de Unity

Unity 2022.3.62f3 LTS

## Objetivo

Crear un entorno 3D con terreno, obstáculos y un agente que utilice `NavMesh` para desplazarse de forma autónoma dentro de la escena.

## Funcionamiento

- Se creó un terreno de 50 x 50 unidades.
- Se agregaron 5 obstáculos distribuidos en la escena.
- Se configuró un `NavMeshSurface` sobre el terreno.
- Se generó la malla de navegación con `Bake`.
- Se creó un agente con `NavMeshAgent`.
- El agente selecciona destinos aleatorios dentro del terreno y se desplaza evitando los obstáculos.

## Cómo ejecutar el proyecto

1. Abrir el proyecto `Practica02_3D` desde Unity Hub.
2. Abrir la escena:

   `Assets/Scenes/Practica02_3D.unity`

3. Presionar el botón `Play`.
4. Observar el movimiento automático del agente por el terreno.

## Estructura

```text
Assets/
├── Scenes/
│   └── Practica02_3D.unity
└── Scripts/
    └── Agent/
        └── AgentMovement.cs
```

## Pruebas realizadas

Se verificó que el agente:

- Se mueve correctamente entre destinos aleatorios.
- Evita los obstáculos de la escena.
- Permanece dentro del área navegable del terreno.
