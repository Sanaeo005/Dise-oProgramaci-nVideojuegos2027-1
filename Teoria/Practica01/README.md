# Práctica 1 (Teoría): Pong en OpenGL

Implementación básica del juego clásico **Pong** utilizando **C++**, **OpenGL** y **FreeGLUT**.

El proyecto permite que dos jugadores controlen una paleta cada uno, mientras una pelota se desplaza por la pantalla, rebota contra las paletas y suma puntos cuando alguno de los jugadores no logra interceptarla.

## Requisitos

El proyecto fue desarrollado y probado en **Ubuntu**.

Dependencias necesarias:

- `g++`
- OpenGL
- FreeGLUT
- GLU

## Compilación

Desde la carpeta `Teoria/Practica01`, ejecutar:

```bash
g++ -o Pong Base_Pong.cpp -lGL -lglut -lGLU
```

Si la compilación termina sin errores, se generará el ejecutable:

```text
Pong
```

## Ejecución

Ejecutar el programa con:

```bash
./Pong
```

Se abrirá la ventana del juego y el marcador se mostrará en la terminal, desde aquí ya se puede jugar

## Controles

### Jugador 1 — paleta izquierda

- `W`: mover hacia arriba
- `S`: mover hacia abajo

### Jugador 2 — paleta derecha

- `↑`: mover hacia arriba
- `↓`: mover hacia abajo

Las paletas están limitadas para no salir del área visible del juego

## Funcionamiento

- La pelota se mueve horizontal y verticalmente.
- Rebota al tocar los límites superior e inferior de la pantalla.
- Rebota al colisionar con cualquiera de las dos paletas.
- Si la pelota sale por el lado izquierdo, se suma un punto al **Jugador 2**.
- Si la pelota sale por el lado derecho, se suma un punto al **Jugador 1**.
- Después de cada punto la pelota regresa al centro de la pantalla.
- El marcador se imprime en la terminal.
- El fondo del juego es negro, las paletas son verdes y la pelota es blanca.

## Archivo principal

```text
Base_Pong.cpp
```

Este archivo contiene la lógica del juego, el dibujo de la pelota y las paletas, el manejo del teclado, las colisiones y el sistema de puntuación.

## Estructura

```text
Teoria/
└── Practica01/
    ├── Base_Pong.cpp
    └── README.md
```

## Notas

El ejecutable `Pong` se genera al compilar el proyecto y no es necesario almacenarlo en el repositorio.
