<div align="center">
<img src="logo.png"  style="width: 30%"  />
<br>
<br>
<img src="departamento-logo.png" style="width: 30%"  />
</div>

# Juego 3D para Reto Diciembre 2023 (2ºCurso)
Repositorio para hacer control del versiones del juego 3D para el Reto de Diciembre del 2º Curso del Ciclo de DAM (Desarrollo de Aplicaciones Multiplataforma)
## Integrantes
* [Albano Díez de Paulino](https://github.com/TerciodeMarte) - Albano Díez de Paulino
* [Carmen Barrios Fernández](https://github.com/CarmenBarrios) - Carmen Barrios Fernández
* [Daniel Espinosa García](https://github.com/Daniel-Espinosa) - Daniel Espinosa García
* [Ramiro Gutiérrez Valverde](https://github.com/ramirogvalverde) - Ramiro Gutiérrez Valverde

## Licencia 📄

Este proyecto está bajo la Licencia (GNU V3) - mira el archivo [LICENSE](LICENSE) para detalles

## Game Document Design (GDD)
### Resumen del juego

Realizaremos un Rogue-Like en el cual dados de 6 caras representaran las armas que utiliza el personaje 
y sus habilidades de clase a medida que avanza por el mapa generado proceduralmente y enfrenta enemigos, 
al derrotarlos obtendrá oro el cual podrá emplear para mejorar los dados. Al morir se calculará la experiencia obtenida 
y esto desbloqueará nuevos dados con los cuales volver a empezar la partida.

### Creación de personaje antes de entrar.

El jugador seleccionara 3 dados:
* Dado mano 1
* Dado mano 2
* Dado Habilidades Especiales (clase)

### Recursos del juego

* Oro

A medida que se desarrolla el juego por los diferentes niveles el jugador obtendrá ORO de los enemigos que podrá 
utilizar en esa RUN para comprar mejoras para sus dados.

* Puntos de Experiencia

Al terminar la partida morir y completar el juego el jugador obtendrá experiencia que le 
permitirán comprar nuevas armas y dados de clase con los que podrá modificar la creación de personaje.

Combate simple (Enemigos Min 1 - Max 3)

### Inicio Escena

Al entrar a la sala los personajes se colocan en su lugar.

Aparecen los enemigos.

* Desarrollo de turnos

  * Se lanzan automáticamente los dados del Jugador.
  * Se lanzan los dados del enemigo.
* Turno del Jugador
  * El jugador puede o no relanzar uno de sus dados utilizando un botón para relanzar y otro para quedarse con la tirada inicial.
  * El dado especial mostrara actualizara los valores de los dados a los que este afecte aumentando su valor y pintándolo de VERDE
  * Uso de dados en combate, se realizará arrastrando el dado al objetivo, el objetivo dando un aura de color este. Esto bloqueara el relanzar dados si aún no se había realizado.
    * Dado Ataque: Arrastrando el dado al enemigo que se quiere golpear, aura Roja
    * Dado Defensa: Se arrastra el dado de defensa al personaje que se le quiere aplicar la defensa. (esto puede ser a un aliado) Aura Azul
  * Es necesario presionar un botón para terminar el turno del Jugador
* Turno del Enemigo
  * Los enemigos utilizaran el valor del dado obtenido atacando, defendiendo o utilizando habilidad especial.
  * La defensa que utilizan los enemigos se guardará hasta el siguiente turno para poder defenderse del jugador, al inicio del siguiente turno del enemigo luego desaparecerá
  * Al terminar todos los dados del enemigo termina automáticamente su turno.

Si quedan Jugadores o Enemigos vivos se reinicia el desarrollo de los turnos.

## Expresiones de Gratitud 🎁

* Comenta a otros sobre este proyecto 📢
* Invita una cerveza 🍺 o un café ☕ a los integrantes.
* Da las gracias públicamente 🤓.