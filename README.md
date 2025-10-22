## Detalle de la Estructura de Carpetas y Capas

### 1. Carpeta `domain/`
Contiene el núcleo de la lógica de negocio y las entidades principales del sistema.
- **model/**: Clases que representan los objetos del dominio (Socio, Invitado, Factura, etc.).
- **ports/**: Interfaces que definen los contratos para la comunicación con otras capas (por ejemplo, repositorios, servicios externos).
- **services/**: Implementaciones de reglas de negocio y operaciones sobre las entidades.

### 2. Carpeta `application/`
Orquesta los casos de uso y coordina la interacción entre la interfaz de usuario y el dominio.
- **adapters/input/**: Recibe y valida la información que ingresa el usuario.
  - **builders/**: Implementa patrones de construcción de objetos complejos.
  - **validators/**: Validaciones específicas para cada tipo de dato o entidad.
- **usecases/**: Casos de uso que representan acciones concretas del sistema (crear socio, registrar invitado, generar factura, etc.).

### 3. Carpeta `infraestructure/`
Implementa detalles técnicos y dependencias externas.
- **config/**: Archivos de configuración de la aplicación.
- **GUI/**: Formularios y componentes visuales de la interfaz de usuario.

### 4. Archivos raíz
- **Program.cs**: Punto de entrada de la aplicación.
- **Form1.cs**: Formulario principal o de ejemplo.

---

## Conexión a la Base de Datos

Actualmente el proyecto no implementa persistencia, pero para agregarla siguiendo Clean Architecture se recomienda:

1. Crear una interfaz en `domain/ports/` (por ejemplo, `IPartnerRepository`) que defina los métodos para acceder a los datos (CRUD).
2. Implementar la interfaz en la capa de infraestructura (`infraestructure/`), usando Entity Framework, Dapper o ADO.NET para conectarse a la base de datos.
3. Inyectar la implementación del repositorio en los casos de uso de la capa de aplicación.

**Ejemplo de interfaz de repositorio:**
```csharp
// domain/ports/IPartnerRepository.cs
public interface IPartnerRepository {
  void Add(Partner partner);
  Partner GetById(int id);
  IEnumerable<Partner> GetAll();
  void Update(Partner partner);
  void Delete(int id);
}
```

**Ejemplo de implementación con Entity Framework:**
```csharp
// infraestructure/PartnerRepositoryEF.cs
public class PartnerRepositoryEF : IPartnerRepository {
  private readonly ClubDbContext _context;
  public PartnerRepositoryEF(ClubDbContext context) {
    _context = context;
  }
  public void Add(Partner partner) => _context.Partners.Add(partner);
  public Partner GetById(int id) => _context.Partners.Find(id);
  public IEnumerable<Partner> GetAll() => _context.Partners.ToList();
  public void Update(Partner partner) => _context.Partners.Update(partner);
  public void Delete(int id) {
    var partner = _context.Partners.Find(id);
    if (partner != null) _context.Partners.Remove(partner);
  }
}
```

## Manejo de Consultas

Las consultas a la base de datos se realizan a través de los repositorios definidos en la capa de infraestructura, pero siempre usando las interfaces de la capa de dominio. Esto permite cambiar la tecnología de persistencia sin afectar el resto del sistema.

**Ejemplo de uso en un caso de uso:**
```csharp
// application/usecases/PartnerUseCase.cs
public class PartnerUseCase {
  private readonly IPartnerRepository _repository;
  public PartnerUseCase(IPartnerRepository repository) {
    _repository = repository;
  }
  public IEnumerable<Partner> ListAllPartners() {
    return _repository.GetAll();
  }
}
```

---
# Club Social Example - Aplicación de Escritorio en C#

Este proyecto es una aplicación de escritorio desarrollada en C# que implementa un sistema de gestión para un club social. El proyecto está estructurado siguiendo una arquitectura limpia (Clean Architecture) para facilitar el mantenimiento y la escalabilidad del código.

## Requisitos Previos

- Visual Studio 2022 o superior
- .NET 8.0
- Conocimientos básicos de C# y Windows Forms

## Arquitectura del Proyecto

El proyecto está organizado en diferentes capas siguiendo los principios de Clean Architecture:

### 1. Capa de Dominio (`domain/`)
Esta es la capa más interna y contiene las reglas de negocio principales. No depende de ninguna otra capa.

#### Modelos (`domain/model/`)
- `Person.cs`: Clase base que contiene los atributos comunes de todas las personas
- `User.cs`: Representa los usuarios del sistema
- `Partner.cs`: Representa a los socios del club
- `Guest.cs`: Representa a los invitados de los socios
- `InvoiceHeader.cs`: Encabezado de las facturas
- `InvoiceDetail.cs`: Detalles de las facturas

#### Puertos (`domain/ports/`)
Interfaces que definen los contratos para operaciones:
- `GuestPort.cs`: Define operaciones para gestionar invitados
- `PartnertPort.cs`: Define operaciones para gestionar socios

#### Servicios (`domain/services/`)
Implementación de la lógica de negocio:
- `ActivateGuest.cs`: Maneja la activación de invitados
- `AmountIncrement.cs`: Gestiona los incrementos de montos
- `CreateGuest.cs`: Lógica para crear nuevos invitados
- `CreatePartner.cs`: Lógica para crear nuevos socios

### 2. Capa de Aplicación (`application/`)
Coordina las operaciones entre la interfaz de usuario y el dominio.

#### Adaptadores de Entrada (`application/adapters/input/`)
- `AdminInputs.cs`: Maneja las entradas del administrador

##### Constructores (`application/adapters/input/builders/`)
- `PartnerBuilder.cs`: Implementa el patrón Builder para crear socios

##### Validadores (`application/adapters/input/validators/`)
- `PartnerValidator.cs`: Valida datos de socios
- `PersonValidator.cs`: Valida datos de personas
- `SimpleValidator.cs`: Validaciones básicas
- `UserValidator.cs`: Valida datos de usuarios

#### Casos de Uso (`application/usecases/`)
- `AdminUseCase.cs`: Implementa funcionalidades del administrador
  - Creación y gestión de socios
  - Gestión de facturas
- `GuestUseCase.cs`: Maneja operaciones relacionadas con invitados
  - Registro de consumos
  - Activación/desactivación de invitados
- `PartnerUseCase.cs`: Gestiona operaciones de socios
  - Registro de facturas
  - Gestión de invitados

### 3. Capa de Infraestructura (`infraestructure/`)
Contiene la implementación de interfaces externas y configuraciones.

#### Configuración (`infraestructure/config/`)
- `Config.cs`: Gestiona la configuración de la aplicación

#### Interfaz Gráfica (`infraestructure/GUI/`)
- `AdminForm.cs`: Formulario principal del administrador
- `CreatePartnerForm.cs`: Formulario para crear nuevos socios

## Patrones de Diseño Utilizados

1. **Builder Pattern**: Implementado en `PartnerBuilder.cs` para la creación de socios
2. **Clean Architecture**: Separación clara de responsabilidades en capas
3. **Dependency Injection**: Usado para mantener bajo acoplamiento entre componentes
4. **Repository Pattern**: Para el manejo de datos (pendiente de implementar para persistencia)

## Funcionalidades Implementadas

### Gestión de Socios
- Creación de nuevos socios con validación de datos
- Asignación de números de identificación únicos
- Gestión de estado de los socios

### Gestión de Invitados
- Registro de invitados asociados a socios
- Control de acceso y estado de invitados
- Registro de consumos de invitados

### Facturación
- Generación de facturas para socios
- Registro de consumos
- Cálculo de montos y cargos

## Cómo Empezar

1. Clona el repositorio
2. Abre la solución `ClubSocialExample.sln` en Visual Studio
3. Restaura los paquetes NuGet si es necesario
4. Compila la solución
5. Ejecuta la aplicación

## Puntos de Extensión

El proyecto está diseñado para ser extendido en las siguientes áreas:

1. Persistencia de datos (actualmente en memoria)
2. Nuevos tipos de socios
3. Sistemas de facturación adicionales
4. Reportes y estadísticas

## Consideraciones para Estudiantes

Este proyecto sirve como ejemplo de:
1. Implementación de Clean Architecture en C#
2. Uso de Windows Forms para interfaces gráficas
3. Implementación de patrones de diseño
4. Validación de datos y lógica de negocio
5. Separación de responsabilidades

Se recomienda:
1. Estudiar la estructura de carpetas y la organización del código
2. Entender cómo se comunican las diferentes capas
3. Analizar los patrones de diseño implementados
4. Practicar agregando nuevas funcionalidades

## Estado Actual del Proyecto

El proyecto implementa las funcionalidades básicas del enunciado de ejemplo, incluyendo:

Pendiente por implementar:
  
---

## Estructura de Carpetas

```
ClubSocialExample/
├── application/
│   ├── adapters/
│   │   └── input/
│   │       ├── builders/
│   │       └── validators/
│   └── usecases/
├── domain/
│   ├── model/
│   ├── ports/
│   └── services/
├── infraestructure/
│   ├── config/
│   └── GUI/
├── Program.cs
├── Form1.cs
└── ...
```

## Ejemplo de Flujo de Trabajo

1. El usuario abre la aplicación y accede al formulario de administración (`AdminForm`).
2. Desde el formulario, puede crear un nuevo socio usando el caso de uso correspondiente (`PartnerUseCase`).
3. El socio se valida mediante los validadores y se construye usando el builder.
4. El socio puede registrar invitados, quienes también son validados y gestionados por los servicios de dominio.
5. Se pueden generar facturas y registrar consumos, todo desde la interfaz gráfica.

## Buenas Prácticas Recomendadas

- Mantén la separación de responsabilidades entre capas.
- Utiliza validadores para asegurar la integridad de los datos.
- Extiende el proyecto agregando nuevas clases en la capa correspondiente.
- Realiza pruebas manuales desde la interfaz gráfica para verificar el flujo.
- Documenta cualquier cambio importante en el código.

## Preguntas Frecuentes (FAQ)

**¿Puedo agregar nuevos tipos de socios o invitados?**
Sí, puedes crear nuevas clases en la carpeta `domain/model` y extender los casos de uso y servicios.

**¿Cómo persisto los datos?**
Actualmente los datos se mantienen en memoria. Para persistencia, puedes implementar repositorios y conectarlos a una base de datos.

**¿Qué hago si la aplicación no compila?**
Verifica que tienes la versión correcta de .NET y que todos los archivos están incluidos en el proyecto.

**¿Cómo agrego una nueva funcionalidad?**
Identifica la capa donde debe ir la lógica (dominio, aplicación, infraestructura) y sigue el patrón de diseño usado en el proyecto.

**¿Dónde puedo aprender más sobre Clean Architecture?**
Revisa recursos como el libro "Clean Architecture" de Robert C. Martin y tutoriales en línea sobre arquitectura de software en C#.