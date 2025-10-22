# Explicación de la Arquitectura

El proyecto ClubSocialExample está organizado usando "arquitectura limpia" (Clean Architecture). Esto significa que el código se divide en capas, cada una con una responsabilidad clara. Así el proyecto es más fácil de entender, mantener y mejorar.

## ¿Qué es Clean Architecture?
Es una forma de organizar el código para separar la lógica de negocio, la interfaz de usuario y la infraestructura (como la base de datos). Cada capa solo se comunica con las que necesita y no depende de detalles técnicos.

## Capas principales
1. **Dominio (domain):** Aquí está la lógica principal del negocio y las reglas que nunca cambian.
2. **Aplicación (application):** Aquí se definen los casos de uso, es decir, las acciones que puede hacer el usuario (crear socio, registrar invitado, etc.).
3. **Infraestructura (infraestructure):** Aquí se conecta el proyecto con el mundo exterior (base de datos, interfaz gráfica, archivos de configuración).

## ¿Por qué es útil?
- Permite cambiar la tecnología de la base de datos o la interfaz gráfica sin modificar la lógica de negocio.
- Hace que el código sea más fácil de probar y mantener.
- Ayuda a que el proyecto crezca sin volverse complicado.