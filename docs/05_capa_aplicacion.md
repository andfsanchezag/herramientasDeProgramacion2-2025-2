# Capa de Aplicación (`application`)

La capa de aplicación se encarga de coordinar las acciones que puede realizar el usuario y de conectar la lógica de negocio con la interfaz de usuario y la infraestructura.

## ¿Qué contiene?
- **adapters/input/**: Recibe y valida la información que ingresa el usuario.
  - **builders/**: Clases que ayudan a construir objetos complejos, como socios.
  - **validators/**: Clases que verifican que los datos sean correctos antes de procesarlos.
- **usecases/**: Clases que representan los casos de uso del sistema, como crear socios (`PartnerUseCase.cs`), gestionar invitados (`GuestUseCase.cs`), administrar el sistema (`AdminUseCase.cs`).

## ¿Por qué es importante?
- Permite que la lógica de negocio se use de manera controlada y segura.
- Facilita la validación de datos y la organización de las acciones del sistema.

## ¿Cómo comprenderla y replicarla?
- Identifica las acciones principales que puede hacer el usuario y crea un caso de uso para cada una.
- Usa validadores para asegurar que los datos sean correctos.
- Utiliza builders para crear objetos complejos de manera ordenada.
- No incluyas detalles de la interfaz gráfica ni de la base de datos en esta capa.