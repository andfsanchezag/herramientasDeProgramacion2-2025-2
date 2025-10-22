# Explicación de la Base de Datos

Este proyecto, ClubSocialExample, puede funcionar inicialmente sin base de datos (los datos se guardan en memoria), pero para aplicaciones reales es importante usar una base de datos para guardar la información de socios, invitados y facturas.

## ¿Qué es una base de datos?
Una base de datos es un sistema que permite guardar, buscar y modificar información de manera organizada y segura. En este proyecto, podrías usar SQL Server, SQLite o cualquier otro sistema compatible con .NET.

## Tablas recomendadas
- **Socios (Partners):** Guarda la información de cada socio (nombre, documento, estado, etc.)
- **Invitados (Guests):** Guarda los invitados asociados a cada socio
- **Facturas (Invoices):** Registra los consumos y pagos de los socios

## Ejemplo de estructura de tabla Socios
| Id | Nombre | Documento | Estado |
|----|--------|-----------|--------|
| 1  | Juan   | 123456    | Activo |

## ¿Cómo se conecta el proyecto a la base de datos?
1. Se crea una interfaz en la carpeta `domain/ports` (por ejemplo, `IPartnerRepository`) que define los métodos para guardar y buscar socios.
2. Se implementa esa interfaz en la carpeta `infraestructure` usando una tecnología como Entity Framework, Dapper o ADO.NET.
3. Los casos de uso llaman a los métodos de la interfaz para guardar o buscar datos.

## Ejemplo de código para guardar un socio
```csharp
// En infraestructure/PartnerRepositoryEF.cs
public void Add(Partner partner) {
    _context.Partners.Add(partner);
    _context.SaveChanges();
}
```

## ¿Por qué es importante?
Usar una base de datos permite que la información no se pierda al cerrar la aplicación y que varios usuarios puedan acceder a los datos al mismo tiempo.