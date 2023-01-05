# SAT Recruitment

El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.


## Requisitos 

- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.

## Comentarios del desarrollador

### Consideraciones

Se asume que es un proyecto de pruebas y que puede modificarse la interfaz de los servicios.
Se simplifica el desarrollo de capas (common, business, interfaces, dal u otros) en un mismo proyecto para poner foco en el refactoring.

### Cambios

- Se corrige launchSettings para que levante Swagger por defecto
- Se estructuran las capas y componentes en carpetas (models, interfaces, implementations, repositories, etc); se desglosa la lógica usando el principio de SOLID
- Se crea el UserDto para desacomplar el dato del request del modelo de datos; tambien se agregan validaciones usando Data Annotation en el DTO; se usa AutoMapper para mapear las entidades
- Siguiendo nomenclatura RESTful se corrige url de servicio; tambien se utiliza los códigos HTTP para responder segun el caso (400 cuando hay error de la invocación del request, 500 en caso de excepción no controlada); se crea una FunctionalException para manejo diferencial en las validaciones de negocio
- Se utiliza Dependency Injection para inyectar las dependencias por constructor
- Se utiliza async await para la llamada al sistema que requiere levantar el archivo
- Se utiliza un serealizador para deserealizar los datos del archivo en entidades
- Se utiliza Moq para simular respuesta de las dependencia que no se quieren probar en los test unitarios
- Se pueden crear mas test unitarios y mas casos (como en todo proyecto real), pero considero que con esos que se crearon se entiende su uso y las validaciones principales