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
- Gestión completa de socios
- Sistema de facturación básico
- Control de invitados
- Interfaz de administración

Pendiente por implementar:
- Persistencia de datos
- Reportes detallados
- Sistema de autenticación
- Histórico de transacciones