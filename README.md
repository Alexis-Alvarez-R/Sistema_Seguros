# Sistema de Emisión de Poliza de Seguros - API 

Este es el Backend del Sistema de Emisión de Seguros desarrollado en **.NET 8**

---

## Requisitos Previos

Antes de comenzar, asegúrarse de tener instalado lo siguiente en su equipo:
* **SDK de .NET 8** (Versión 8.0 o superior)
* **SQL Server** (Express o LocalDB)
* **Visual Studio 2022** (con la carga de trabajo *Desarrollo de ASP.NET y web*) o **VS Code**.

---

##  Pasos para Instalar y Correr el Proyecto Localmente

Sigue estos pasos en orden para configurar el entorno y ejecutar la API:

## 1. Clonar el Repositorio
Abre tu terminal favorita, navega a tu carpeta de proyectos y ejecuta:
```
git clone https://github.com/Alexis-Alvarez-R/Sistema_Seguros.git
```
## 2. Configurar la Cadena de Conexión
Por motivos de seguridad y flexibilidad, el proyecto está configurado para conectarse a la base de datos local utilizando la Autenticación de Windows.

Abre el archivo "appsettings.json" ubicado en la raíz del proyecto.

Modifica la propiedad ConexionSql con el nombre de tu servidor local de SQL Server:

```
  "ConnectionStrings": {
    "ConexionSql": "Server=TU_SERVER;Database=SistemaSegurosLAFISE;Trusted_Connection=True;TrustServerCertificate=True;"
  },
```

## 3. Restaurar los Paquetes NuGet
Para descargar e instalar todas las dependencias del proyecto (como Entity Framework y AutoMapper), ejecuta el siguiente comando en la terminal:

```
dotnet restore
```
(Nota: Si usas Visual Studio 2022, este paso se realiza automáticamente al compilar o abrir la solución por primera vez).

## 4. Crear la Base de Datos (Ejecutar Migraciones)
El proyecto ya cuenta con las migraciones necesarias para estructurar las tablas de Clientes, Vehículos, Coberturas, Pólizas y sus relaciones intermedias. Para impactar tu servidor local ejecuta:

Desde la Consola de Administrador de Paquetes (en Visual Studio):

PowerShell:
```
Update-Database
```
O Desde la Terminal de Comandos estándar:
```
dotnet ef database update
```


## 5. Ejecutar la Aplicación
Una vez configurada la base de datos, inicia el servidor web de desarrollo corriendo:

```
dotnet run
```
O simplemente presiona F5 (o el botón de Play) dentro de Visual Studio 2022.

Se abrira el swagger en el cual se podran probar los enpoint.

## Pruebas con Postman

En el correo de entrega se adjunta la colección de Postman (`.json`) con los endpoints listos para probar. 

* Asegúrarse de cambiar el puerto en tu Postman por el puerto local que te asigne `dotnet run` (por ejemplo: `https://localhost:7123` o `http://localhost:5123`).




