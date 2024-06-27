# MENU PERSONAJES ![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/66023bab-95eb-4961-886f-11ca74e63c8e)


Hola profes, buenas tardes. Vuelvo a empezar de 0, mi idea sigue la rama de lo que había planteado anteriormente, ahora con el concepto de PERSONAJE y de eso nacen HUMANO, ORCO y ELFO.

## ¿Qué hace mi EXAMEN?

Este programa es una aplicación de Windows Forms diseñada para gestionar el acceso de usuarios mediante un inicio de sesión con correo electrónico y contraseña. Su propósito principal es autenticar a los usuarios y, en caso de éxito, permitirles acceder a una ventana principal donde se pueden realizar diversas operaciones como crear tu propio personaje de roleplay/modificarlo/eliminarlo, todo depende de los permisos que tengas(ya seas vendedor/supervisor/administrador).
como anteriormente dije en el menu ademas podras ver los LOGS de los usuarios que se han registrado en todo este tiempo!

### Clase PERSONAJE y sus descendientes

Todos los personajes (HUMANO, ORCO, ELFO) derivan de la clase base PERSONAJE. Cada uno tiene características y funcionalidades específicas que los distinguen.

## Presentacion
Mi nombre es Agustin Lopez, tengo 20 años y desarrolle este programa para la materia de Laboratorio De Computacion 2 en UTN

![Imagen1](https://github.com/Agusslo/Lopez.Agustin.PrimerParcial/assets/98591977/9a358e8b-2022-4c63-ad1b-484486bdf094) ![Imagen2](https://github.com/Agusslo/Lopez.Agustin.PrimerParcial/assets/98591977/fe7707b1-1c26-4729-8148-92ea6d6afaf9) ![Imagen3](https://github.com/Agusslo/Lopez.Agustin.PrimerParcial/assets/98591977/645ae954-a900-4398-b01f-0f1949f39a2b)

## Diagrama de Clase

Aquí está el diagrama de clase de mi proyecto:

![Diagrama de Clase](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/1ee6dbae-29b3-444a-a6bb-8ac86ec00de8)


## **Explicacion de mis WindowsForms**

## LOGIN

El formulario de inicio de sesión (`Login`) es una parte esencial de la aplicación, diseñada para gestionar el acceso de usuarios mediante correo electrónico y contraseña. Su objetivo principal es autenticar a los usuarios y permitirles el acceso seguro a la aplicación. A continuación, se detallan sus funciones principales:

- **Carga de Usuarios**: Al iniciar, el formulario carga una lista de usuarios desde un archivo JSON (`MOCK_DATA.json`). Esta lista contiene los datos de los usuarios registrados, como correo electrónico, contraseña, nombre, apellido, y perfil.
- **Autenticación de Usuarios**: Cuando un usuario intenta iniciar sesión, el formulario verifica las credenciales ingresadas contra la lista de usuarios cargada. Si las credenciales son correctas, se permite el acceso y se muestra la ventana principal del menú (`Menu`).
- **Registro de Accesos**: Cada inicio de sesión exitoso se registra en un archivo de log (`logs.log`). Este registro incluye información como el correo electrónico del usuario, su nombre, apellido, legajo y perfil, junto con la fecha y hora del acceso.
- **Seguridad y Usabilidad**: El formulario permite a los usuarios mostrar u ocultar la contraseña ingresada mediante una casilla de verificación. Esto mejora la seguridad durante la entrada de datos.
- **Acceso Rápido**: Se proporciona una funcionalidad de acceso rápido con credenciales predefinidas para facilitar pruebas y demostraciones. Este acceso rápido también se registra en el archivo de log.
- **Manejo de Errores**: El formulario incluye manejadores de excepciones para diversos escenarios, como la falta de archivos, errores de deserialización JSON, y problemas de permisos, asegurando que se informe adecuadamente al usuario de cualquier problema.

Este formulario garantiza un acceso seguro y controlado a la aplicación, permitiendo únicamente a usuarios autenticados interactuar con las funcionalidades principales de la misma.


![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/1b5cf483-ef41-4012-8e35-e1898c4b6d6e)


## INICIO RAPIDO

El formulario de inicio rápido (`FormContraseñaRapida`) permite a los usuarios acceder de manera rápida a la aplicación utilizando una contraseña predefinida. Sus funciones principales son:

- **Verificación de Contraseña**: Permite a los usuarios ingresar una contraseña rápida (predefinida como "2004"). Si la contraseña es correcta, se cierra el formulario con un resultado exitoso; de lo contrario, muestra un mensaje de error indicando que la contraseña es incorrecta.
- **Alternar Visibilidad de Contraseña**: Permite a los usuarios mostrar u ocultar la contraseña ingresada mediante una casilla de verificación.
- **Confirmación de Cierre**: Pregunta a los usuarios si están seguros de que desean cerrar el formulario cuando intentan salir, asegurando que no se cierre accidentalmente.
- **Acceso Rápido con Enter**: Permite a los usuarios confirmar la contraseña presionando la tecla Enter, mejorando la facilidad de uso.


![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/274a01bc-7d86-4f9a-88b7-74f4e24a16d6)


## MENU

El formulario `Menu` gestiona diversas funciones de la aplicación, enfocándose en la manipulación de personajes. Sus características principales son:

- **Configuración Inicial**: 
  - Establece la ruta de una carpeta específica en "Mis Documentos" para guardar configuraciones.
  - Configura una imagen de fondo si está disponible.
  - Configura un temporizador que actualiza la hora actual en el formulario cada segundo.
  - Muestra información del usuario (correo, hora de inicio de sesión y perfil).
- **Gestión de Personajes**:
  - Permite agregar, modificar y eliminar personajes. 
  - Restringe estas acciones según el perfil del usuario (supervisor o vendedor).
- **ListBox**:
  - Configura el ListBox para mostrar personajes con una barra de desplazamiento horizontal.
  - Actualiza la lista de personajes mostrados según los filtros seleccionados (Humano, Orco, Elfo).
- **Guardar y Abrir**:
  - Guarda la colección de personajes en un archivo XML.
  - Abre un archivo XML para cargar la colección de personajes.
- **Ordenamiento**:
  - Permite ordenar la lista de personajes por edad, nombre y tamaño en orden ascendente o descendente.
- **Logs**:
  - Permite ver logs guardados en una ruta especificada.
- **Eventos de Cierre**:
  - Pregunta al usuario si está seguro de que desea cerrar la aplicación al intentar salir.

Cada una de estas funciones se implementa mediante métodos y eventos asociados a controles específicos del formulario.


![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/c660e79f-28d2-45c5-95a5-03874c9c9260)


## FRM LOG

El formulario `FrmLog` está diseñado para visualizar logs almacenados en un archivo específico. Sus funcionalidades principales son las siguientes:

- **Carga de Logs**:
  - Al inicializarse, lee el contenido del archivo de logs ubicado en la ruta especificada.
  - Si el archivo existe, muestra los logs en un área de texto (`RTextBox`) dentro del formulario.
  - Si el archivo no existe, muestra un mensaje informativo indicando que no se encontraron logs.

Este formulario proporciona una manera simple y segura de visualizar logs almacenados, manejar errores potenciales durante la lectura de archivos, y ofrece una experiencia de usuario intuitiva al interactuar con los registros de logs ademas de poseer una scrollbar en vertical.


![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/0080c5b8-357b-4b78-beb0-e0f8fd99cf9a)


## FRM ELECCION

El formulario `FrmEleccion` permite al usuario elegir entre diferentes tipos de personajes (Humano, Orco, Elfo) y agregar uno seleccionado a través de formularios secundarios especializados.

- **Selección de Personaje**:
  - Contiene tres opciones de RadioButton para seleccionar entre Humano, Orco o Elfo.
  - Implementa un método `ResetearOtrosRadioButton` para desmarcar los RadioButton que no están seleccionados cuando se marca uno nuevo.

- **Eventos de RadioButton**:
  - Los eventos `CheckedChanged` de cada RadioButton (`rbtnHumano`, `rbtnOrco`, `rbtnElfo`) llaman al método `ResetearOtrosRadioButton` para asegurar que solo uno esté marcado a la vez.

Este formulario facilita la selección y creación de diferentes tipos de personajes dentro de la aplicación, asegurando que solo se pueda seleccionar un tipo a la vez y proporcionando manejo de errores y confirmación al cerrar.


![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/b473a4ac-5b37-45ff-87bb-e96649168ce5)


## AgregarPersonaje y sus hijos

### Funcionamiento de la Clase AgregarPersonaje

La clase `AgregarPersonaje` es una forma abstracta para la creación de diferentes tipos de personajes en una aplicación de formularios Windows. Provee funcionalidades básicas y comunes para la creación de personajes, como la selección de edad y característicasy si esta resucitado.

### AgregarOrco

#### Funcionamiento de la Clase AgregarOrco

La clase `AgregarOrco` extiende `AgregarPersonaje` y está diseñada para agregar y modificar personajes tipo "Orco". Permite al usuario especificar la especie del orco y su capacidad caníbal mediante controles de interfaz

### AgregarElfo

#### Funcionamiento de la Clase AgregarElfo

La clase `AgregarElfo` extiende `AgregarPersonaje` y está destinada a agregar y modificar personajes tipo "Elfo". Permite al usuario especificar la especie del elfo y su estado de inmortalidad mediante controles de interfaz

### AgregarHumano

#### Funcionamiento de la Clase AgregarHumano

La clase `AgregarHumano` extiende `AgregarPersonaje` y facilita la creación y modificación de personajes tipo "Humano". Permite al usuario seleccionar el color de piel y pelo del humano entre opciones predefinidas


![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/1c0d47c8-a48b-4e99-a426-4217deda18de) ![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/ad03e9f7-552d-4c90-8fd5-28ab8d054cc3) ![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/509d4a5e-466e-4007-a6ca-343b000d7313) ![image](https://github.com/Agusslo/Lopez.Agustin.SegundoParcial/assets/98591977/e4bef063-4d76-4a27-93ad-d933e8e09928)













