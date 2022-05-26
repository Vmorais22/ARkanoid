# ARkanoid

![ARkanoid](https://ibb.co/crTpTM7)

## Introducción 

Este escrito recoge brevemente el propósito y la forma de interacción de una aplicación de realidad aumentada desarrollada para la asignatura de Sistemas Gráficos Interactivos (SGI) del Master de Ingeniería Informática (MEI) para la Facultad de Informática de Barcelona de la Universidad Politécnica de Catalunya. En primer lugar, se expondrá una breve descripción de lo que hace la aplicación y, en segundo lugar, el sistema de interacción implementado.

## Descripción de la aplicación 

ARkanoid es una aplicación inspirada en el famosísimo juego de arcade cuyo objetivo es el de destruir los bloques del mapa con una pelota e impedir que esta escape de la zona de juego mediante una plataforma horizontal.

Para esta remasterización del popular juego al mundo de la realidad aumentada se ha utilizado  la plataforma de desarrollo Vuforia que ha permitido integrar las funcionalidades y comportamientos del juego en un entorno real. Para ello se han diseñado una serie de marcadores específicos tanto para el reconocimiento de los mapas o niveles como el de los propios jugadores. Dichos marcadores son en realidad códigos bidimensionales (QR) y permiten la reproducción e interacción de múltiples modelos de forma simultánea. 

Es necesario distinguir dos tipos de elementos a renderizar. Los códigos QR que contienen mapas de juego son en sí la funcionalidad principal del sistema. Conforman la zona de juego, la pelota, los ladrillos a destruir y el resto de elementos existentes. De esta forma se asegura mediante animaciones que haya cierta aplicación de transformaciones geométricas respecto a la posición inicial, es decir, la del propio marcador. Algunas de estas transformaciones serían el propio comportamiento de la pelota por el mapa: colisiones, rebotes, destrucción de ladrillos, adquisición y reacción a bonus o power ups que modifiquen tanto el mapa como la bola. Cabe destacar que estos QRs arrancan, detienen y controlan el flujo de ejecución de la aplicación. Una partida no se inicia hasta que un mapa es detectado y, en caso de que deje de detectarse el marcador asignado, el juego es pausado hasta que se vuelva a detectar y recupera la ejecución en el estado en el que se encontraba.

Por otro lado, están los códigos QR que representan al jugador cuya funcionalidad es mucho más básica. Solamente representan la plataforma horizontal que interactúa con la pelota. El jugador desplazará el marcador en el entorno real para que este movimiento sea replicado en el entorno virtual. De esta forma se produce la interacción directa con los elementos virtuales.

Aunque este es el comportamiento idílico que se espera reproducir, la flexibilidad del sistema ofrecido permite ir más allá y renderizar a la vez más de un mapa y jugar simultáneamente en todos ellos con un solo jugador. Del mismo modo, la detección de más de un jugador permite partidas con más de una persona.

En cuanto a mecanismos de control, se ha implementado también  una interfaz en la que visualizar el sistema de vidas y la puntuación. Como en el Arkanoid original, el objetivo es conseguir la máxima puntuación sin perder todas las vidas y dicho objetivo se consigue destruyendo todos los bloques. El jugador pierde una vida cada vez que la pelota se sale de la zona de fuego y es destruida por el rayo de la parte inferior.

Antes se ha comentado que existen unos bonus o power ups que afectan al comportamiento del juego. Dichos bonus aparecen cada cierto tiempo aleatorio de un rango determinado y para ser activados el usuario ha de ser capaz de dirigir la pelota hacia ellos para que los capture. Pasado cierto tiempo, estos desaparecen si el usuario no es capaz de lograrlo. Entre los activables implementados están los que reducen o aumentan la velocidad de la pelota, ensanchan o estrechan la longitud de la plataforma del jugador, hacen recuperar una vida, aumentan la puntuación total conseguida y los que afectan al diseño del mapa volviéndolo temporalmente más complejo.

Se usaron los rectángulos básicos ofrecidos por el propio Unity. Se utilizaron Fragment Shaders para darles un aspecto más atractivo consiguiendo este efecto lumínico que va variando de color a medida que el tiempo avanza. También se añadió música de fondo, distinta en cada nivel, y efectos de sonido para mejorar la experiencia de juego.

## Sistema de interacción

Se ha importado al proyecto el paquete de integración de Vuforia (no se ha añadido a la entrega ni al GIT porque pesa 1,25 GB. Es necesario descargáserlo e importarlo para probar el proyecto en unity). Este paquete se encarga de toda la parte de detección y renderizado de los modelos. Fue necesario crear una cuenta en el portal web de Vuforia, crear una base de datos, subir las imágenes que serían usadas como marcadores a la susodicha base y luego importarla al proyecto de Unity. Al principio se intentó capturar imágenes más atractivas y que describieran mejor el modelo que supuestamente iban a renderizar (por ejemplo que el marcador del jugador fuera un texto que dijera “player”), pero se observó que un QR ofrecía mejores resultados durante el reconocimiento.

Al integrar Vuforia en Unity se amplían las opciones de creación que hay por defecto. Se nos permite generar “Image Targets” a los que asociar las imágenes almacenadas en la DB creada y que son la representación del marker en el entorno de desarrollo de Unity. Estos targets serán a efectos prácticos la transformada padre de todos los elementos que insertemos en su interior que serán, en efecto, los objetos renderizados en el mundo virtual cuando se detecta el marker en el mundo real. Hay que tener en cuenta que no solo se muestra un modelo si no todo un sistema funcional y que Vuforia en realidad renderiza siempre inicializa y carga todos los modelos independientemente de si el marcador está siendo detectado. Por tanto, el main loop de cada mapa empieza al arrancar la aplicación pero lo hace sin renderizar los modelos por lo que fue preciso definir un sistema para detener el juego y almacenar su estado cuando el marcador no está siendo detectado. Y, del mismo modo, retomarlo cuando el marker volviera a detectarse.

Siguiendo este sistema, se han implementado cuatro Image Targets. Tres de ellos para cada uno de los mapas creados y el cuarto para representar el jugador. Aparte se ha creado también la interfaz a visualizar en la pantalla del dispositivo móvil y el canvas del menú in game.

El jugador deberá colocar uno o más mapas sobre una superficie plana y una vez se renderice la zona de juego añadir el QR del jugador para poder interactuar con la pelota. Los marcadores son del mismo tamaño para evitar un funcionamiento incorrecto del sistema puesto que se ha detectado que QRs de tamaño distinto renderizan elementos en posiciones distintas y, más importante, a alturas distintas. Por otro lado, como que la superposición de los QR implicaría que uno dejara de verse, el hecho de que sean del mismo tamaño implica que el player no podrá ir nunca más arriba de la mitad del mapa lo cuál hace el juego más desafiante.
El sistema está preparado para condiciones ciertamente extremas de detección. Soporta con cierta elasticidad las oclusiones, enfoques torcidos, muy lejanos o demasiado cercanos y las sombras.

