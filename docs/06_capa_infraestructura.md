# Capa de Infraestructura (`infraestructure`)

La capa de infraestructura conecta el sistema con el mundo exterior, como la base de datos, la interfaz gráfica y la configuración.

## ¿Qué contiene?
- **config/**: Archivos y clases para la configuración de la aplicación (por ejemplo, datos de conexión a la base de datos).
- **GUI/**: Formularios y componentes visuales que permiten al usuario interactuar con el sistema (`AdminForm.cs`, `CreatePartnerForm.cs`).
- **repositorios** (pueden agregarse): Clases que implementan el acceso a la base de datos usando las interfaces definidas en la capa de dominio.

## ¿Por qué es importante?
- Permite que el sistema guarde y recupere datos de manera permanente.
- Proporciona la interfaz visual para que el usuario use el sistema.
- Centraliza la configuración y los detalles técnicos.

## ¿Cómo comprenderla y replicarla?
- Implementa los repositorios usando la tecnología de base de datos elegida.
- Crea formularios claros y sencillos para el usuario.
- Mantén la configuración en archivos separados para facilitar cambios.
- No incluyas lógica de negocio en esta capa, solo detalles técnicos y de conexión.