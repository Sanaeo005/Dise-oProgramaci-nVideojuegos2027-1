# Práctica 4 - Unity 2D

Carrillo Sánchez Rafael Esteban 320053786

## Implementación

- Se incorporaron animaciones para los estados principales del personaje: `Idle`, `Walk`, `Jump` y `Fall`.
- Se configuró un `Animator Controller` para controlar las transiciones entre las distintas animaciones.
- Se utilizaron las variables `estaCaminando`, `estaSaltando` y `estaCayendo` para actualizar los parámetros del Animator según el movimiento del personaje.
- Se ajustaron las transiciones entre `Idle`, `Walk`, `Jump` y `Fall` para que respondan correctamente al estado actual del jugador.
- Se corrigió la transición de salto a caída para que la animación `Fall` comience cuando el personaje empieza a descender.
- Se ajustaron algunos sprites y pivotes para evitar saltos visuales entre animaciones.
- Se agregó un efecto de sonido al realizar el salto mediante un componente `Audio Source`.
- Se mantuvieron las mecánicas implementadas previamente, como aceleración, desaceleración, Coyote Time, Jump Buffering y gravedad mejorada.

## Ejecución

1. Abrir el proyecto con Unity 2022.3.62f3.
2. Abrir `Assets/Scenes/SampleScene`.
3. Presionar `Play`.
4. Probar:
   - `A` / `D` o flechas izquierda/derecha para desplazarse.
   - Barra espaciadora para saltar.
   - Verificar que se reproduzcan correctamente las animaciones `Idle`, `Walk`, `Jump` y `Fall`.
   - Comprobar que la animación de caída aparezca cuando el personaje comienza a descender.
   - Verificar que al tocar el suelo el personaje regrese a `Idle` o `Walk`, según corresponda.
   - Escuchar el efecto de sonido al realizar un salto.

## Resultado esperado

El personaje debe desplazarse y saltar manteniendo las mecánicas implementadas anteriormente, mientras las animaciones cambian de forma correcta entre reposo, caminata, salto y caída. Al iniciar un salto debe reproducirse el efecto de sonido correspondiente y, al aterrizar, el personaje debe regresar al estado visual adecuado sin cambios bruscos entre sprites.
