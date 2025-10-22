# Capa de Dominio (`domain`)

La capa de dominio es el corazón del proyecto. Aquí se define la lógica principal y las reglas del negocio del club social.

## ¿Qué contiene?
- **model/**: Clases que representan los objetos principales del sistema, como Socio (`Partner.cs`), Invitado (`Guest.cs`), Factura (`InvoiceHeader.cs`, `InvoiceDetail.cs`), Persona (`Person.cs`), Usuario (`User.cs`).
- **ports/**: Interfaces que definen cómo otras partes del sistema pueden interactuar con el dominio. Por ejemplo, `GuestPort.cs` y `PartnertPort.cs` definen operaciones para gestionar invitados y socios.
- **services/**: Clases que implementan reglas de negocio, como activar invitados (`ActivateGuest.cs`), crear socios (`CreatePartner.cs`), calcular montos (`AmountIncrement.cs`).

## ¿Por qué es importante?
- Aquí se definen las reglas que nunca deben cambiar, sin importar la tecnología usada.
- Permite que el sistema sea fácil de entender y mantener.

## ¿Cómo comprenderla y replicarla?
- Identifica los objetos principales del sistema y crea una clase para cada uno.
- Define interfaces para las operaciones importantes.
- Implementa servicios para la lógica de negocio.
- No incluyas detalles técnicos (como base de datos o interfaz gráfica) en esta capa.