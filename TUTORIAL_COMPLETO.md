# Tutorial Completo: Sistema de Gestión de Partidos
## Aplicación Web con ASP.NET Core Razor Pages y MySQL

---

**Autor:** Tutorial para EOI - Curso C#  
**Fecha:** 2026  
**Nivel:** Iniciación a Programación Web  
**Requisitos previos:** Conocimientos de C#, POO y aplicaciones de consola

---

## Índice

1. [Introducción](#introducción)
2. [Requisitos del Sistema](#requisitos-del-sistema)
3. [Instalación de MySQL](#instalación-de-mysql)
4. [Creación del Proyecto](#creación-del-proyecto)
5. [Instalación de Librerías](#instalación-de-librerías)
6. [Configuración de la Base de Datos](#configuración-de-la-base-de-datos)
7. [Creación del Modelo](#creación-del-modelo)
8. [Creación de la Capa de Datos (DAO)](#creación-de-la-capa-de-datos-dao)
9. [Configuración de Sesiones](#configuración-de-sesiones)
10. [Creación de la Página de Login](#creación-de-la-página-de-login)
11. [Creación del Menú Principal](#creación-del-menú-principal)
12. [Creación del CRUD de Partidos](#creación-del-crud-de-partidos)
13. [Pruebas de la Aplicación](#pruebas-de-la-aplicación)
14. [Conclusiones](#conclusiones)

---

## Introducción

En este tutorial aprenderás a crear una aplicación web completa desde cero utilizando:

- **ASP.NET Core 10** con Razor Pages
- **MySQL** como base de datos
- **Programación Orientada a Objetos** (POO)
- **ADO.NET** para acceso a datos (sin Entity Framework)
- **Bootstrap 5** para diseño responsive

### ¿Qué vamos a construir?

Un sistema web para gestionar partidos de fútbol que incluye:
- ✅ Pantalla de login con usuario y contraseña
- ✅ Menú principal con opciones
- ✅ CRUD completo (Crear, Leer, Actualizar, Eliminar) de partidos
- ✅ Gestión de sesiones de usuario

### Campos de la tabla Partidos

- `id_partido` - Identificador único (autoincremental)
- `equipo_l` - Nombre del equipo local
- `equipo_v` - Nombre del equipo visitante
- `fecha` - Fecha del partido
- `asistencia` - Número de asistentes
- `resultado_l` - Goles del equipo local
- `resultado_v` - Goles del equipo visitante

---

## Requisitos del Sistema

### Software Necesario

1. **Visual Studio 2026 Community** (o superior)
   - Descarga: https://visualstudio.microsoft.com/es/
   - Componentes necesarios:
	 - Desarrollo de ASP.NET y web
	 - .NET 10.0 SDK

2. **MySQL Server** (versión 8.0 o superior)
   - Descarga: https://dev.mysql.com/downloads/mysql/
   - Incluye MySQL Workbench para gestión visual

3. **Navegador web moderno** (Chrome, Edge, Firefox)

### Conocimientos Previos

- C# básico (variables, tipos de datos, condicionales, bucles)
- Programación Orientada a Objetos (clases, objetos, propiedades, métodos)
- HTML y CSS básico (opcional pero recomendado)

---

## Instalación de MySQL

### Paso 1: Descargar MySQL

1. Ve a https://dev.mysql.com/downloads/mysql/
2. Selecciona tu sistema operativo (Windows)
3. Descarga el instalador MSI (mysql-installer-community-X.X.XX.msi)

### Paso 2: Instalar MySQL Server

1. Ejecuta el instalador descargado
2. Selecciona **"Developer Default"** (instalación completa para desarrollo)
3. Haz clic en **"Execute"** para descargar e instalar componentes
4. En la configuración del servidor:
   - **Type and Networking**: deja los valores por defecto (Puerto 3306)
   - **Authentication Method**: selecciona "Use Strong Password Encryption"
   - **Accounts and Roles**: 
	 - Establece una contraseña para el usuario `root` (¡anótala!)
	 - Ejemplo: `root123` (cámbiala en producción)
   - **Windows Service**: deja marcado "Start MySQL Server at System Startup"
5. Haz clic en **"Execute"** para aplicar la configuración
6. Finaliza la instalación

### Paso 3: Verificar la Instalación

1. Abre **MySQL Workbench** (se instaló junto con MySQL)
2. Haz clic en la conexión **"Local instance MySQL80"**
3. Ingresa la contraseña de root
4. Si ves la interfaz de MySQL Workbench, ¡la instalación fue exitosa!

---

## Creación del Proyecto

### Paso 1: Crear Proyecto en Visual Studio

1. Abre **Visual Studio 2026**
2. Haz clic en **"Crear nuevo proyecto"**
3. Busca y selecciona **"Aplicación web de ASP.NET Core"**
4. Haz clic en **"Siguiente"**

### Paso 2: Configurar el Proyecto

1. **Nombre del proyecto**: `WebApplication1`
2. **Ubicación**: Elige una carpeta (por ejemplo: `C:\Users\TuUsuario\Documents\2026\EOI\cursoCsharp\`)
3. **Nombre de la solución**: `WebApplication1`
4. Haz clic en **"Siguiente"**

### Paso 3: Configuración Adicional

1. **Marco de trabajo**: `.NET 10.0 (Soporte a largo plazo)`
2. **Tipo de autenticación**: Ninguno
3. **Configurar para HTTPS**: ✅ (marcado)
4. **Habilitar Docker**: ❌ (desmarcado)
5. **Plantilla**: Selecciona **"Web Application"** (Razor Pages)
6. Haz clic en **"Crear"**

### Estructura del Proyecto Creado

Visual Studio creará automáticamente esta estructura:

```
WebApplication1/
├── Pages/
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── Privacy.cshtml
│   ├── Error.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
├── appsettings.json
├── Program.cs
└── WebApplication1.csproj
```

---

## Instalación de Librerías

### ¿Qué es NuGet?

NuGet es el gestor de paquetes para .NET. Permite instalar librerías de terceros fácilmente.

### Instalar MySql.Data

**MySql.Data** es la librería oficial para conectar aplicaciones .NET con MySQL.

#### Opción 1: Usando la Consola de NuGet

1. En Visual Studio, ve a **"Herramientas"** → **"Administrador de paquetes NuGet"** → **"Consola del Administrador de paquetes"**
2. Ejecuta el siguiente comando:

```powershell
Install-Package MySql.Data
```

#### Opción 2: Usando la Interfaz Gráfica

1. Haz clic derecho en el proyecto **"WebApplication1"**
2. Selecciona **"Administrar paquetes NuGet..."**
3. Haz clic en la pestaña **"Examinar"**
4. Busca **"MySql.Data"**
5. Selecciona el paquete y haz clic en **"Instalar"**
6. Acepta las licencias

#### Opción 3: Usando Terminal

1. Abre una terminal en Visual Studio (**Ver** → **Terminal**)
2. Ejecuta:

```bash
dotnet add package MySql.Data
```

### Verificar la Instalación

1. Abre el archivo **WebApplication1.csproj**
2. Deberías ver una línea similar a:

```xml
<PackageReference Include="MySql.Data" Version="9.7.0" />
```

---

## Configuración de la Base de Datos

### Paso 1: Crear el Script SQL

1. En el **Explorador de soluciones**, haz clic derecho en la solución
2. Selecciona **"Agregar"** → **"Nuevo elemento"**
3. Busca **"Archivo de texto"**
4. Nómbralo: `script_mysql.sql`
5. Copia y pega el siguiente contenido:

```sql
-- Script para crear la base de datos y tabla en MySQL

-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS gestionpartidos;

-- Usar la base de datos
USE gestionpartidos;

-- Crear la tabla partidos
CREATE TABLE IF NOT EXISTS partidos (
	id_partido INT AUTO_INCREMENT PRIMARY KEY,
	equipo_l VARCHAR(100) NOT NULL,
	equipo_v VARCHAR(100) NOT NULL,
	fecha DATE NOT NULL,
	asistencia INT NOT NULL,
	resultado_l INT NOT NULL,
	resultado_v INT NOT NULL
);

-- Insertar algunos datos de ejemplo
INSERT INTO partidos (equipo_l, equipo_v, fecha, asistencia, resultado_l, resultado_v) VALUES
('Real Madrid', 'Barcelona', '2024-03-15', 75000, 2, 1),
('Atlético Madrid', 'Sevilla', '2024-03-16', 45000, 1, 1),
('Valencia', 'Athletic Bilbao', '2024-03-17', 35000, 3, 2);
```

### Paso 2: Ejecutar el Script

#### Opción A: Usando MySQL Workbench (Recomendado)

1. Abre **MySQL Workbench**
2. Conéctate a tu instancia local
3. Haz clic en **"File"** → **"Open SQL Script"**
4. Selecciona el archivo `script_mysql.sql`
5. Haz clic en el icono del rayo ⚡ para ejecutar todo el script
6. Verifica que aparezca el mensaje: "action completed successfully"

#### Opción B: Usando línea de comandos

```bash
mysql -u root -p < script_mysql.sql
```

### Paso 3: Verificar la Base de Datos

En MySQL Workbench:

1. En el panel izquierdo, haz clic en **"Schemas"**
2. Haz clic derecho y selecciona **"Refresh All"**
3. Expande **"gestionpartidos"** → **"Tables"** → **"partidos"**
4. Haz clic derecho en `partidos` → **"Select Rows - Limit 1000"**
5. Deberías ver los 3 partidos de ejemplo

### Paso 4: Configurar la Cadena de Conexión

1. Abre el archivo **appsettings.json**
2. Verás algo como esto:

```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Information",
	  "Microsoft.AspNetCore": "Warning"
	}
  },
  "AllowedHosts": "*"
}
```

3. Modifícalo para agregar la conexión a MySQL:

```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Information",
	  "Microsoft.AspNetCore": "Warning"
	}
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
	"MySqlConnection": "Server=localhost;Database=gestionpartidos;User=root;Password=root123;"
  }
}
```

⚠️ **IMPORTANTE**: Reemplaza `root123` con tu contraseña de MySQL.

---

## Creación del Modelo

### ¿Qué es un Modelo?

Un **modelo** es una clase que representa los datos de nuestra aplicación. En POO, es una clase con propiedades que reflejan las columnas de la tabla.

### Paso 1: Crear la Carpeta Models

1. Haz clic derecho en el proyecto **"WebApplication1"**
2. Selecciona **"Agregar"** → **"Nueva carpeta"**
3. Nómbrala: `Models`

### Paso 2: Crear la Clase Partido

1. Haz clic derecho en la carpeta **"Models"**
2. Selecciona **"Agregar"** → **"Clase..."**
3. Nombre: `Partido.cs`
4. Haz clic en **"Agregar"**

### Paso 3: Código de la Clase Partido

Reemplaza el contenido con:

```csharp
namespace WebApplication1.Models
{
	public class Partido
	{
		public int IdPartido { get; set; }
		public string EquipoL { get; set; } = string.Empty;
		public string EquipoV { get; set; } = string.Empty;
		public DateTime Fecha { get; set; }
		public int Asistencia { get; set; }
		public int ResultadoL { get; set; }
		public int ResultadoV { get; set; }
	}
}
```

### Explicación del Código

- **namespace**: Organiza el código en espacios de nombres
- **public class Partido**: Define una clase pública llamada Partido
- **Propiedades**:
  - `IdPartido`: Identificador único (int = número entero)
  - `EquipoL` y `EquipoV`: Nombres de equipos (string = texto)
  - `Fecha`: Fecha del partido (DateTime = fecha y hora)
  - `Asistencia`, `ResultadoL`, `ResultadoV`: Números enteros
- **{ get; set; }**: Propiedades automáticas (getter y setter)
- **= string.Empty**: Inicialización para evitar valores null

---

## Creación de la Capa de Datos (DAO)

### ¿Qué es un DAO?

**DAO** (Data Access Object) es un patrón de diseño que encapsula toda la lógica de acceso a datos. Separa la lógica de negocio de la lógica de base de datos.

### Paso 1: Crear la Carpeta Data

1. Haz clic derecho en el proyecto
2. **"Agregar"** → **"Nueva carpeta"**
3. Nombre: `Data`

### Paso 2: Crear la Clase PartidoDAO

1. Haz clic derecho en **"Data"**
2. **"Agregar"** → **"Clase..."**
3. Nombre: `PartidoDAO.cs`

### Paso 3: Código de PartidoDAO

```csharp
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Data
{
	public class PartidoDAO
	{
		private readonly string _connectionString;

		// Constructor: recibe la cadena de conexión
		public PartidoDAO(string connectionString)
		{
			_connectionString = connectionString;
		}

		// Método 1: Obtener todos los partidos
		public List<Partido> ObtenerTodos()
		{
			List<Partido> partidos = new List<Partido>();

			// Patrón using: cierra automáticamente la conexión
			using (MySqlConnection conexion = new MySqlConnection(_connectionString))
			{
				conexion.Open(); // Abre la conexión

				string sql = "SELECT id_partido, equipo_l, equipo_v, fecha, asistencia, resultado_l, resultado_v FROM partidos";
				MySqlCommand comando = new MySqlCommand(sql, conexion);

				// Ejecuta la consulta y obtiene resultados
				using (MySqlDataReader lector = comando.ExecuteReader())
				{
					while (lector.Read()) // Lee cada fila
					{
						Partido partido = new Partido
						{
							IdPartido = lector.GetInt32("id_partido"),
							EquipoL = lector.GetString("equipo_l"),
							EquipoV = lector.GetString("equipo_v"),
							Fecha = lector.GetDateTime("fecha"),
							Asistencia = lector.GetInt32("asistencia"),
							ResultadoL = lector.GetInt32("resultado_l"),
							ResultadoV = lector.GetInt32("resultado_v")
						};
						partidos.Add(partido);
					}
				}
			}

			return partidos;
		}

		// Método 2: Obtener un partido por ID
		public Partido? ObtenerPorId(int id)
		{
			Partido? partido = null;

			using (MySqlConnection conexion = new MySqlConnection(_connectionString))
			{
				conexion.Open();

				string sql = "SELECT id_partido, equipo_l, equipo_v, fecha, asistencia, resultado_l, resultado_v FROM partidos WHERE id_partido = @id";
				MySqlCommand comando = new MySqlCommand(sql, conexion);

				// Parámetros: previenen inyección SQL
				comando.Parameters.AddWithValue("@id", id);

				using (MySqlDataReader lector = comando.ExecuteReader())
				{
					if (lector.Read())
					{
						partido = new Partido
						{
							IdPartido = lector.GetInt32("id_partido"),
							EquipoL = lector.GetString("equipo_l"),
							EquipoV = lector.GetString("equipo_v"),
							Fecha = lector.GetDateTime("fecha"),
							Asistencia = lector.GetInt32("asistencia"),
							ResultadoL = lector.GetInt32("resultado_l"),
							ResultadoV = lector.GetInt32("resultado_v")
						};
					}
				}
			}

			return partido;
		}

		// Método 3: Insertar un partido
		public void Insertar(Partido partido)
		{
			using (MySqlConnection conexion = new MySqlConnection(_connectionString))
			{
				conexion.Open();

				string sql = "INSERT INTO partidos (equipo_l, equipo_v, fecha, asistencia, resultado_l, resultado_v) " +
							 "VALUES (@equipoL, @equipoV, @fecha, @asistencia, @resultadoL, @resultadoV)";
				MySqlCommand comando = new MySqlCommand(sql, conexion);

				// Agregar parámetros
				comando.Parameters.AddWithValue("@equipoL", partido.EquipoL);
				comando.Parameters.AddWithValue("@equipoV", partido.EquipoV);
				comando.Parameters.AddWithValue("@fecha", partido.Fecha);
				comando.Parameters.AddWithValue("@asistencia", partido.Asistencia);
				comando.Parameters.AddWithValue("@resultadoL", partido.ResultadoL);
				comando.Parameters.AddWithValue("@resultadoV", partido.ResultadoV);

				comando.ExecuteNonQuery(); // Ejecuta INSERT
			}
		}

		// Método 4: Actualizar un partido
		public void Actualizar(Partido partido)
		{
			using (MySqlConnection conexion = new MySqlConnection(_connectionString))
			{
				conexion.Open();

				string sql = "UPDATE partidos SET equipo_l = @equipoL, equipo_v = @equipoV, fecha = @fecha, " +
							 "asistencia = @asistencia, resultado_l = @resultadoL, resultado_v = @resultadoV " +
							 "WHERE id_partido = @id";
				MySqlCommand comando = new MySqlCommand(sql, conexion);

				comando.Parameters.AddWithValue("@id", partido.IdPartido);
				comando.Parameters.AddWithValue("@equipoL", partido.EquipoL);
				comando.Parameters.AddWithValue("@equipoV", partido.EquipoV);
				comando.Parameters.AddWithValue("@fecha", partido.Fecha);
				comando.Parameters.AddWithValue("@asistencia", partido.Asistencia);
				comando.Parameters.AddWithValue("@resultadoL", partido.ResultadoL);
				comando.Parameters.AddWithValue("@resultadoV", partido.ResultadoV);

				comando.ExecuteNonQuery(); // Ejecuta UPDATE
			}
		}

		// Método 5: Eliminar un partido
		public void Eliminar(int id)
		{
			using (MySqlConnection conexion = new MySqlConnection(_connectionString))
			{
				conexion.Open();

				string sql = "DELETE FROM partidos WHERE id_partido = @id";
				MySqlCommand comando = new MySqlCommand(sql, conexion);
				comando.Parameters.AddWithValue("@id", id);

				comando.ExecuteNonQuery(); // Ejecuta DELETE
			}
		}
	}
}
```

### Explicación de Conceptos Clave

#### MySqlConnection
- Representa una conexión a MySQL
- Se debe abrir antes de usarla y cerrar después
- El patrón `using` cierra automáticamente la conexión

#### MySqlCommand
- Representa un comando SQL a ejecutar
- Puede ser SELECT, INSERT, UPDATE, DELETE

#### MySqlDataReader
- Lee resultados de una consulta SELECT
- Lee fila por fila con `Read()`
- Accede a columnas con `GetString()`, `GetInt32()`, etc.

#### Parámetros (@id, @equipoL, etc.)
- Evitan inyección SQL (seguridad)
- Reemplazan valores en la consulta de forma segura

---

## Configuración de Sesiones

### ¿Qué son las Sesiones?

Las **sesiones** permiten almacenar datos del usuario entre peticiones HTTP. Usaremos sesiones para saber si un usuario ha iniciado sesión.

### Modificar Program.cs

1. Abre **Program.cs**
2. Busca la línea: `builder.Services.AddRazorPages();`
3. Agrega DESPUÉS de esa línea:

```csharp
// Agregar soporte para sesiones
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // Sesión expira en 30 minutos
	options.Cookie.HttpOnly = true; // Seguridad: solo accesible por HTTP
	options.Cookie.IsEssential = true; // Necesaria para el funcionamiento
});
```

4. Busca la línea: `app.UseRouting();`
5. Agrega DESPUÉS de esa línea:

```csharp
// Habilitar sesiones
app.UseSession();
```

### Código Completo de Program.cs

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Agregar soporte para sesiones
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// Habilitar sesiones
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
```

---

## Creación de la Página de Login

### ¿Qué son las Razor Pages?

Una **Razor Page** consta de dos archivos:
- **`.cshtml`**: Contiene HTML y codigo Razor (vista)
- **`.cshtml.cs`**: Contiene código C# (lógica)

### Paso 1: Modificar Index.cshtml (Vista)

1. Abre **Pages/Index.cshtml**
2. Reemplaza TODO el contenido con:

```html
@page
@model IndexModel
@{
	ViewData["Title"] = "Inicio de Sesión";
}

<div class="text-center">
	<h1 class="display-4">Sistema de Gestión de Partidos</h1>
	<p class="lead">Ingrese sus credenciales para acceder</p>
</div>

<div class="row justify-content-center mt-5">
	<div class="col-md-4">
		<div class="card">
			<div class="card-body">
				<h5 class="card-title text-center mb-4">Iniciar Sesión</h5>

				@if (Model.MensajeError != null)
				{
					<div class="alert alert-danger">@Model.MensajeError</div>
				}

				<form method="post">
					<div class="mb-3">
						<label for="usuario" class="form-label">Usuario</label>
						<input type="text" class="form-control" id="usuario" name="usuario" required>
					</div>
					<div class="mb-3">
						<label for="contrasena" class="form-label">Contraseña</label>
						<input type="password" class="form-control" id="contrasena" name="contrasena" required>
					</div>
					<button type="submit" class="btn btn-primary w-100">Ingresar</button>
				</form>
			</div>
		</div>
	</div>
</div>
```

### Paso 2: Modificar Index.cshtml.cs (Lógica)

1. Abre **Pages/Index.cshtml.cs**
2. Reemplaza el contenido con:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
	public class IndexModel : PageModel
	{
		public string? MensajeError { get; set; }

		// GET: Mostrar formulario de login
		public void OnGet()
		{
		}

		// POST: Procesar formulario de login
		public IActionResult OnPost(string usuario, string contrasena)
		{
			// Validación simple (usuario: admin, contraseña: 1234)
			if (usuario == "admin" && contrasena == "1234")
			{
				// Guardar usuario en sesión
				HttpContext.Session.SetString("Usuario", usuario);

				// Redirigir al menú principal
				return RedirectToPage("/Menu");
			}

			// Credenciales incorrectas
			MensajeError = "Usuario o contraseña incorrectos";
			return Page();
		}
	}
}
```

### Explicación del Código

#### Razor (Vista)
- `@page`: Indica que es una Razor Page
- `@model IndexModel`: Vincula la vista con el modelo (clase .cs)
- `@{ }`: Bloque de código C#
- `@if`: Condicional en Razor
- `<form method="post">`: Formulario que se envía al servidor

#### C# (Lógica)
- `OnGet()`: Se ejecuta cuando se carga la página (GET)
- `OnPost()`: Se ejecuta cuando se envía el formulario (POST)
- `HttpContext.Session.SetString()`: Guarda datos en la sesión
- `RedirectToPage()`: Redirige a otra página
- `Page()`: Devuelve la misma página

---

## Creación del Menú Principal

### Paso 1: Crear Menu.cshtml

1. Haz clic derecho en **Pages**
2. **"Agregar"** → **"Elemento de Razor"**
3. Selecciona **"Razor Page"**
4. Nombre: `Menu`
5. Haz clic en **"Agregar"**

✅ Se crearán dos archivos: `Menu.cshtml` y `Menu.cshtml.cs`

### Paso 2: Código de Menu.cshtml

Reemplaza el contenido con:

```html
@page
@model MenuModel
@{
	ViewData["Title"] = "Menú Principal";
}

<div class="text-center">
	<h1 class="display-4">Bienvenido, @Model.Usuario</h1>
	<p class="lead">Sistema de Gestión de Partidos</p>
</div>

<div class="row justify-content-center mt-5">
	<div class="col-md-6">
		<div class="card">
			<div class="card-body">
				<h5 class="card-title text-center mb-4">Opciones del Sistema</h5>
				<div class="d-grid gap-3">
					<a href="/Partidos/Listar" class="btn btn-primary btn-lg">
						Ver Partidos
					</a>
					<a href="/Partidos/Crear" class="btn btn-success btn-lg">
						Crear Partido
					</a>
					<a href="/Logout" class="btn btn-danger btn-lg">
						Cerrar Sesión
					</a>
				</div>
			</div>
		</div>
	</div>
</div>
```

### Paso 3: Código de Menu.cshtml.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
	public class MenuModel : PageModel
	{
		public string Usuario { get; set; } = string.Empty;

		public IActionResult OnGet()
		{
			// Verificar si el usuario está logueado
			var usuario = HttpContext.Session.GetString("Usuario");

			if (string.IsNullOrEmpty(usuario))
			{
				// No hay sesión: redirigir al login
				return RedirectToPage("/Index");
			}

			Usuario = usuario;
			return Page();
		}
	}
}
```

### Paso 4: Crear Logout.cshtml

1. Haz clic derecho en **Pages**
2. **"Agregar"** → **"Elemento de Razor"** → **"Razor Page"**
3. Nombre: `Logout`

### Paso 5: Código de Logout.cshtml

```html
@page
@model LogoutModel
@{
	ViewData["Title"] = "Cerrar Sesión";
}
```

### Paso 6: Código de Logout.cshtml.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
	public class LogoutModel : PageModel
	{
		public IActionResult OnGet()
		{
			// Limpiar toda la sesión
			HttpContext.Session.Clear();

			// Redirigir al login
			return RedirectToPage("/Index");
		}
	}
}
```

---

## Creación del CRUD de Partidos

### Paso 1: Crear Carpeta Partidos

1. Haz clic derecho en **Pages**
2. **"Agregar"** → **"Nueva carpeta"**
3. Nombre: `Partidos`

---

### LISTAR PARTIDOS

### Paso 2: Crear Listar.cshtml

1. Haz clic derecho en **Pages/Partidos**
2. **"Agregar"** → **"Elemento de Razor"** → **"Razor Page"**
3. Nombre: `Listar`

### Código de Listar.cshtml

```html
@page
@model ListarModel
@{
	ViewData["Title"] = "Lista de Partidos";
}

<div class="container mt-4">
	<h1>Lista de Partidos</h1>

	<div class="mb-3">
		<a href="/Partidos/Crear" class="btn btn-success">Crear Nuevo Partido</a>
		<a href="/Menu" class="btn btn-secondary">Volver al Menú</a>
	</div>

	@if (Model.Partidos.Count == 0)
	{
		<div class="alert alert-info">No hay partidos registrados.</div>
	}
	else
	{
		<table class="table table-striped table-bordered">
			<thead>
				<tr>
					<th>ID</th>
					<th>Equipo Local</th>
					<th>Equipo Visitante</th>
					<th>Fecha</th>
					<th>Resultado</th>
					<th>Asistencia</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				@foreach (var partido in Model.Partidos)
				{
					<tr>
						<td>@partido.IdPartido</td>
						<td>@partido.EquipoL</td>
						<td>@partido.EquipoV</td>
						<td>@partido.Fecha.ToString("dd/MM/yyyy")</td>
						<td>@partido.ResultadoL - @partido.ResultadoV</td>
						<td>@partido.Asistencia</td>
						<td>
							<a href="/Partidos/Editar?id=@partido.IdPartido" class="btn btn-sm btn-primary">Editar</a>
							<a href="/Partidos/Eliminar?id=@partido.IdPartido" class="btn btn-sm btn-danger">Eliminar</a>
						</td>
					</tr>
				}
			</tbody>
		</table>
	}
</div>
```

### Código de Listar.cshtml.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Partidos
{
	public class ListarModel : PageModel
	{
		private readonly IConfiguration _configuration;
		public List<Partido> Partidos { get; set; } = new List<Partido>();

		// Inyección de dependencias: recibe configuración
		public ListarModel(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IActionResult OnGet()
		{
			// Verificar sesión
			var usuario = HttpContext.Session.GetString("Usuario");
			if (string.IsNullOrEmpty(usuario))
			{
				return RedirectToPage("/Index");
			}

			// Obtener cadena de conexión
			string connectionString = _configuration.GetConnectionString("MySqlConnection") ?? "";

			// Crear instancia del DAO
			PartidoDAO dao = new PartidoDAO(connectionString);

			// Obtener todos los partidos
			Partidos = dao.ObtenerTodos();

			return Page();
		}
	}
}
```

---

### CREAR PARTIDOS

### Paso 3: Crear Crear.cshtml

1. Haz clic derecho en **Pages/Partidos**
2. **"Agregar"** → **"Elemento de Razor"** → **"Razor Page"**
3. Nombre: `Crear`

### Código de Crear.cshtml

```html
@page
@model CrearModel
@{
	ViewData["Title"] = "Crear Partido";
}

<div class="container mt-4">
	<h1>Crear Nuevo Partido</h1>

	@if (Model.MensajeError != null)
	{
		<div class="alert alert-danger">@Model.MensajeError</div>
	}

	<form method="post">
		<div class="mb-3">
			<label for="EquipoL" class="form-label">Equipo Local</label>
			<input type="text" class="form-control" id="EquipoL" name="Partido.EquipoL" required>
		</div>

		<div class="mb-3">
			<label for="EquipoV" class="form-label">Equipo Visitante</label>
			<input type="text" class="form-control" id="EquipoV" name="Partido.EquipoV" required>
		</div>

		<div class="mb-3">
			<label for="Fecha" class="form-label">Fecha</label>
			<input type="date" class="form-control" id="Fecha" name="Partido.Fecha" required>
		</div>

		<div class="mb-3">
			<label for="Asistencia" class="form-label">Asistencia</label>
			<input type="number" class="form-control" id="Asistencia" name="Partido.Asistencia" min="0" required>
		</div>

		<div class="mb-3">
			<label for="ResultadoL" class="form-label">Resultado Local</label>
			<input type="number" class="form-control" id="ResultadoL" name="Partido.ResultadoL" min="0" required>
		</div>

		<div class="mb-3">
			<label for="ResultadoV" class="form-label">Resultado Visitante</label>
			<input type="number" class="form-control" id="ResultadoV" name="Partido.ResultadoV" min="0" required>
		</div>

		<button type="submit" class="btn btn-success">Guardar</button>
		<a href="/Partidos/Listar" class="btn btn-secondary">Cancelar</a>
	</form>
</div>
```

### Código de Crear.cshtml.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Partidos
{
	public class CrearModel : PageModel
	{
		private readonly IConfiguration _configuration;

		// BindProperty: vincula el formulario con esta propiedad
		[BindProperty]
		public Partido Partido { get; set; } = new Partido();

		public string? MensajeError { get; set; }

		public CrearModel(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IActionResult OnGet()
		{
			// Verificar sesión
			var usuario = HttpContext.Session.GetString("Usuario");
			if (string.IsNullOrEmpty(usuario))
			{
				return RedirectToPage("/Index");
			}

			return Page();
		}

		public IActionResult OnPost()
		{
			// Verificar sesión
			var usuario = HttpContext.Session.GetString("Usuario");
			if (string.IsNullOrEmpty(usuario))
			{
				return RedirectToPage("/Index");
			}

			try
			{
				string connectionString = _configuration.GetConnectionString("MySqlConnection") ?? "";
				PartidoDAO dao = new PartidoDAO(connectionString);

				// Insertar partido en la base de datos
				dao.Insertar(Partido);

				// Redirigir a la lista
				return RedirectToPage("/Partidos/Listar");
			}
			catch (Exception ex)
			{
				MensajeError = "Error al crear el partido: " + ex.Message;
				return Page();
			}
		}
	}
}
```

---

### EDITAR PARTIDOS

### Paso 4: Crear Editar.cshtml

1. Haz clic derecho en **Pages/Partidos**
2. **"Agregar"** → **"Elemento de Razor"** → **"Razor Page"**
3. Nombre: `Editar`

### Código de Editar.cshtml

```html
@page
@model EditarModel
@{
	ViewData["Title"] = "Editar Partido";
}

<div class="container mt-4">
	<h1>Editar Partido</h1>

	@if (Model.MensajeError != null)
	{
		<div class="alert alert-danger">@Model.MensajeError</div>
	}

	@if (Model.Partido == null)
	{
		<div class="alert alert-warning">Partido no encontrado.</div>
		<a href="/Partidos/Listar" class="btn btn-secondary">Volver</a>
	}
	else
	{
		<form method="post">
			<input type="hidden" name="Partido.IdPartido" value="@Model.Partido.IdPartido" />

			<div class="mb-3">
				<label for="EquipoL" class="form-label">Equipo Local</label>
				<input type="text" class="form-control" id="EquipoL" name="Partido.EquipoL" value="@Model.Partido.EquipoL" required>
			</div>

			<div class="mb-3">
				<label for="EquipoV" class="form-label">Equipo Visitante</label>
				<input type="text" class="form-control" id="EquipoV" name="Partido.EquipoV" value="@Model.Partido.EquipoV" required>
			</div>

			<div class="mb-3">
				<label for="Fecha" class="form-label">Fecha</label>
				<input type="date" class="form-control" id="Fecha" name="Partido.Fecha" value="@Model.Partido.Fecha.ToString("yyyy-MM-dd")" required>
			</div>

			<div class="mb-3">
				<label for="Asistencia" class="form-label">Asistencia</label>
				<input type="number" class="form-control" id="Asistencia" name="Partido.Asistencia" value="@Model.Partido.Asistencia" min="0" required>
			</div>

			<div class="mb-3">
				<label for="ResultadoL" class="form-label">Resultado Local</label>
				<input type="number" class="form-control" id="ResultadoL" name="Partido.ResultadoL" value="@Model.Partido.ResultadoL" min="0" required>
			</div>

			<div class="mb-3">
				<label for="ResultadoV" class="form-label">Resultado Visitante</label>
				<input type="number" class="form-control" id="ResultadoV" name="Partido.ResultadoV" value="@Model.Partido.ResultadoV" min="0" required>
			</div>

			<button type="submit" class="btn btn-primary">Actualizar</button>
			<a href="/Partidos/Listar" class="btn btn-secondary">Cancelar</a>
		</form>
	}
</div>
```

### Código de Editar.cshtml.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Partidos
{
	public class EditarModel : PageModel
	{
		private readonly IConfiguration _configuration;

		[BindProperty]
		public Partido? Partido { get; set; }

		public string? MensajeError { get; set; }

		public EditarModel(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		// Parámetro id de la URL: /Partidos/Editar?id=1
		public IActionResult OnGet(int id)
		{
			// Verificar sesión
			var usuario = HttpContext.Session.GetString("Usuario");
			if (string.IsNullOrEmpty(usuario))
			{
				return RedirectToPage("/Index");
			}

			// Obtener el partido por ID
			string connectionString = _configuration.GetConnectionString("MySqlConnection") ?? "";
			PartidoDAO dao = new PartidoDAO(connectionString);
			Partido = dao.ObtenerPorId(id);

			return Page();
		}

		public IActionResult OnPost()
		{
			// Verificar sesión
			var usuario = HttpContext.Session.GetString("Usuario");
			if (string.IsNullOrEmpty(usuario))
			{
				return RedirectToPage("/Index");
			}

			if (Partido == null)
			{
				return RedirectToPage("/Partidos/Listar");
			}

			try
			{
				string connectionString = _configuration.GetConnectionString("MySqlConnection") ?? "";
				PartidoDAO dao = new PartidoDAO(connectionString);

				// Actualizar partido
				dao.Actualizar(Partido);

				return RedirectToPage("/Partidos/Listar");
			}
			catch (Exception ex)
			{
				MensajeError = "Error al actualizar el partido: " + ex.Message;
				return Page();
			}
		}
	}
}
```

---

### ELIMINAR PARTIDOS

### Paso 5: Crear Eliminar.cshtml

1. Haz clic derecho en **Pages/Partidos**
2. **"Agregar"** → **"Elemento de Razor"** → **"Razor Page"**
3. Nombre: `Eliminar`

### Código de Eliminar.cshtml

```html
@page
@model EliminarModel
@{
	ViewData["Title"] = "Eliminar Partido";
}

<div class="container mt-4">
	<h1>Eliminar Partido</h1>

	@if (Model.Partido == null)
	{
		<div class="alert alert-warning">Partido no encontrado.</div>
		<a href="/Partidos/Listar" class="btn btn-secondary">Volver</a>
	}
	else
	{
		<div class="alert alert-danger">
			<h4>¿Está seguro que desea eliminar este partido?</h4>
		</div>

		<div class="card">
			<div class="card-body">
				<h5 class="card-title">Detalles del Partido</h5>
				<p><strong>ID:</strong> @Model.Partido.IdPartido</p>
				<p><strong>Equipo Local:</strong> @Model.Partido.EquipoL</p>
				<p><strong>Equipo Visitante:</strong> @Model.Partido.EquipoV</p>
				<p><strong>Fecha:</strong> @Model.Partido.Fecha.ToString("dd/MM/yyyy")</p>
				<p><strong>Resultado:</strong> @Model.Partido.ResultadoL - @Model.Partido.ResultadoV</p>
				<p><strong>Asistencia:</strong> @Model.Partido.Asistencia</p>
			</div>
		</div>

		<form method="post" class="mt-3">
			<input type="hidden" name="id" value="@Model.Partido.IdPartido" />
			<button type="submit" class="btn btn-danger">Confirmar Eliminación</button>
			<a href="/Partidos/Listar" class="btn btn-secondary">Cancelar</a>
		</form>
	}
</div>
```

### Código de Eliminar.cshtml.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Partidos
{
	public class EliminarModel : PageModel
	{
		private readonly IConfiguration _configuration;

		public Partido? Partido { get; set; }

		public EliminarModel(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IActionResult OnGet(int id)
		{
			// Verificar sesión
			var usuario = HttpContext.Session.GetString("Usuario");
			if (string.IsNullOrEmpty(usuario))
			{
				return RedirectToPage("/Index");
			}

			// Obtener el partido
			string connectionString = _configuration.GetConnectionString("MySqlConnection") ?? "";
			PartidoDAO dao = new PartidoDAO(connectionString);
			Partido = dao.ObtenerPorId(id);

			return Page();
		}

		public IActionResult OnPost(int id)
		{
			// Verificar sesión
			var usuario = HttpContext.Session.GetString("Usuario");
			if (string.IsNullOrEmpty(usuario))
			{
				return RedirectToPage("/Index");
			}

			try
			{
				string connectionString = _configuration.GetConnectionString("MySqlConnection") ?? "";
				PartidoDAO dao = new PartidoDAO(connectionString);

				// Eliminar partido
				dao.Eliminar(id);

				return RedirectToPage("/Partidos/Listar");
			}
			catch (Exception)
			{
				return Page();
			}
		}
	}
}
```

---

## Pruebas de la Aplicación

### Paso 1: Ejecutar la Aplicación

1. En Visual Studio, presiona **F5** o haz clic en el botón **▶ WebApplication1**
2. Se abrirá un navegador con la aplicación
3. La URL será algo como: `https://localhost:7XXX`

### Paso 2: Probar el Login

1. Verás la pantalla de login
2. Ingresa:
   - **Usuario**: `admin`
   - **Contraseña**: `1234`
3. Haz clic en **"Ingresar"**
4. Deberías ver el menú principal con tu nombre de usuario

### Paso 3: Probar el Menú

1. Verás tres botones:
   - Ver Partidos
   - Crear Partido
   - Cerrar Sesión

### Paso 4: Listar Partidos

1. Haz clic en **"Ver Partidos"**
2. Deberías ver una tabla con los 3 partidos de ejemplo
3. Cada fila tiene botones "Editar" y "Eliminar"

### Paso 5: Crear Partido

1. Haz clic en **"Crear Nuevo Partido"**
2. Llena el formulario:
   - Equipo Local: `Sevilla`
   - Equipo Visitante: `Real Betis`
   - Fecha: `2024-04-20`
   - Asistencia: `42000`
   - Resultado Local: `2`
   - Resultado Visitante: `2`
3. Haz clic en **"Guardar"**
4. Deberías volver a la lista con el nuevo partido

### Paso 6: Editar Partido

1. En la lista, haz clic en **"Editar"** de cualquier partido
2. Modifica algún campo (por ejemplo, la asistencia)
3. Haz clic en **"Actualizar"**
4. Verifica que el cambio se refleje en la lista

### Paso 7: Eliminar Partido

1. En la lista, haz clic en **"Eliminar"** de cualquier partido
2. Verás la confirmación con los detalles del partido
3. Haz clic en **"Confirmar Eliminación"**
4. El partido desaparecerá de la lista

### Paso 8: Cerrar Sesión

1. Ve al menú principal
2. Haz clic en **"Cerrar Sesión"**
3. Deberías volver al login
4. Intenta acceder a `https://localhost:XXXX/Menu` directamente
5. Deberías ser redirigido al login (sesión cerrada)

---

## Solución de Problemas Comunes

### Error: "Unable to connect to any of the specified MySQL hosts"

**Causa**: No se puede conectar a MySQL.

**Soluciones**:
1. Verifica que MySQL Server esté ejecutándose:
   - Abre "Servicios" en Windows (services.msc)
   - Busca "MySQL80" y verifica que esté "En ejecución"
2. Verifica que la contraseña en `appsettings.json` sea correcta
3. Verifica el puerto (por defecto 3306)

### Error: "Table 'gestionpartidos.partidos' doesn't exist"

**Causa**: La base de datos o tabla no existe.

**Solución**:
1. Abre MySQL Workbench
2. Ejecuta el script `script_mysql.sql` completo

### Error: "Session has not been configured"

**Causa**: Falta configurar las sesiones.

**Solución**:
1. Verifica que en `Program.cs` esté:
   - `builder.Services.AddSession(...)`
   - `app.UseSession();`

### Error de compilación en PartidoDAO

**Causa**: Falta la referencia a MySql.Data.

**Solución**:
1. Verifica que el paquete MySql.Data esté instalado
2. Recompila el proyecto (Ctrl+Shift+B)

---

## Conceptos Clave Aprendidos

### 1. Arquitectura en Capas

La aplicación está organizada en capas:

- **Presentación** (Pages): Interfaz de usuario (Razor Pages)
- **Lógica de Negocio** (PageModel): Validaciones y flujo
- **Acceso a Datos** (DAO): Comunicación con la base de datos
- **Modelo** (Partido): Representación de datos

### 2. Patrón MVC/MVVM Simplificado

- **Model** (Modelo): Clase Partido
- **View** (Vista): Archivos .cshtml
- **Controller** (Controlador): Clases PageModel (.cshtml.cs)

### 3. Programación Orientada a Objetos

- **Clases**: Partido, PartidoDAO, PageModels
- **Encapsulación**: Propiedades con get/set
- **Métodos**: ObtenerTodos(), Insertar(), etc.
- **Inyección de dependencias**: IConfiguration en constructores

### 4. Acceso a Datos (ADO.NET)

- **MySqlConnection**: Conexión a la base de datos
- **MySqlCommand**: Ejecución de comandos SQL
- **MySqlDataReader**: Lectura de resultados
- **Parámetros**: Seguridad contra inyección SQL

### 5. Gestión de Sesiones

- **HttpContext.Session.SetString()**: Guardar datos
- **HttpContext.Session.GetString()**: Recuperar datos
- **HttpContext.Session.Clear()**: Eliminar sesión

---

## Mejoras Futuras (Ejercicios para Alumnos)

### Nivel Básico

1. **Validaciones mejoradas**:
   - Validar que los equipos no estén vacíos
   - Validar que la fecha no sea futura
   - Validar que los resultados no sean negativos

2. **Mensajes de confirmación**:
   - Mostrar mensaje "Partido creado con éxito"
   - Mostrar mensaje "Partido actualizado con éxito"

3. **Búsqueda simple**:
   - Agregar un campo de búsqueda por nombre de equipo

### Nivel Intermedio

4. **Múltiples usuarios**:
   - Crear tabla `usuarios` en MySQL
   - Validar contra la base de datos en lugar de hardcodear "admin/1234"
   - Almacenar contraseñas hasheadas

5. **Ordenamiento**:
   - Permitir ordenar la tabla por columna (fecha, asistencia, etc.)

6. **Paginación**:
   - Mostrar 10 partidos por página
   - Agregar botones "Anterior" y "Siguiente"

### Nivel Avanzado

7. **Estadísticas**:
   - Página de estadísticas con total de partidos, promedio de asistencia, etc.

8. **Exportar datos**:
   - Botón para exportar la lista a CSV o Excel

9. **Validación del lado del cliente**:
   - JavaScript para validar formularios antes de enviar

10. **API REST**:
	- Crear endpoints API para consumir desde otras aplicaciones

---

## Recursos Adicionales

### Documentación Oficial

- **ASP.NET Core**: https://learn.microsoft.com/es-es/aspnet/core/
- **Razor Pages**: https://learn.microsoft.com/es-es/aspnet/core/razor-pages/
- **MySQL**: https://dev.mysql.com/doc/
- **MySql.Data Connector**: https://dev.mysql.com/doc/connector-net/en/

### Tutoriales Recomendados

- **C# Fundamentals**: https://learn.microsoft.com/es-es/dotnet/csharp/
- **Bootstrap 5**: https://getbootstrap.com/docs/5.3/getting-started/introduction/
- **SQL Básico**: https://www.w3schools.com/sql/

### Herramientas Útiles

- **Visual Studio Code**: Alternativa ligera a Visual Studio
- **DBeaver**: Cliente universal de bases de datos (alternativa a MySQL Workbench)
- **Postman**: Para probar APIs REST (futuro)

---

## Conclusiones

¡Felicidades! Has creado tu primera aplicación web completa con:

✅ **Backend**: ASP.NET Core con C#  
✅ **Frontend**: HTML, CSS (Bootstrap), Razor  
✅ **Base de Datos**: MySQL  
✅ **Autenticación**: Sistema de login con sesiones  
✅ **CRUD Completo**: Crear, Leer, Actualizar, Eliminar  

### Habilidades Adquiridas

- Configuración de proyectos ASP.NET Core
- Conexión a bases de datos MySQL
- Uso de ADO.NET para acceso a datos
- Razor Pages para páginas web dinámicas
- Gestión de sesiones de usuario
- Validación de formularios
- Manejo de errores
- Bootstrap para diseño responsive

### Próximos Pasos

1. Experimenta agregando nuevas funcionalidades
2. Prueba las mejoras sugeridas
3. Personaliza el diseño con CSS
4. Aprende sobre Entity Framework Core (ORM)
5. Explora autenticación con ASP.NET Core Identity

---

## Apéndice A: Comandos Útiles

### Comandos de dotnet CLI

```bash
# Crear nuevo proyecto Razor Pages
dotnet new webapp -n NombreProyecto

# Agregar paquete NuGet
dotnet add package NombrePaquete

# Compilar proyecto
dotnet build

# Ejecutar proyecto
dotnet run

# Limpiar proyecto
dotnet clean

# Restaurar paquetes
dotnet restore
```

### Comandos de MySQL

```sql
-- Ver bases de datos
SHOW DATABASES;

-- Usar una base de datos
USE gestionpartidos;

-- Ver tablas
SHOW TABLES;

-- Ver estructura de tabla
DESCRIBE partidos;

-- Ver todos los registros
SELECT * FROM partidos;

-- Eliminar base de datos (¡CUIDADO!)
DROP DATABASE gestionpartidos;
```

---

## Apéndice B: Estructura Final del Proyecto

```
WebApplication1/
├── Data/
│   └── PartidoDAO.cs                  # Acceso a datos
├── Models/
│   └── Partido.cs                     # Modelo de datos
├── Pages/
│   ├── Partidos/
│   │   ├── Crear.cshtml              # Vista crear
│   │   ├── Crear.cshtml.cs           # Lógica crear
│   │   ├── Editar.cshtml             # Vista editar
│   │   ├── Editar.cshtml.cs          # Lógica editar
│   │   ├── Eliminar.cshtml           # Vista eliminar
│   │   ├── Eliminar.cshtml.cs        # Lógica eliminar
│   │   ├── Listar.cshtml             # Vista listar
│   │   └── Listar.cshtml.cs          # Lógica listar
│   ├── Shared/
│   │   └── _Layout.cshtml            # Layout principal
│   ├── Index.cshtml                  # Login vista
│   ├── Index.cshtml.cs               # Login lógica
│   ├── Menu.cshtml                   # Menú vista
│   ├── Menu.cshtml.cs                # Menú lógica
│   ├── Logout.cshtml                 # Logout vista
│   ├── Logout.cshtml.cs              # Logout lógica
│   └── _ViewStart.cshtml
├── wwwroot/                          # Archivos estáticos
│   ├── css/
│   ├── js/
│   └── lib/
├── appsettings.json                  # Configuración
├── Program.cs                        # Punto de entrada
├── script_mysql.sql                  # Script SQL
└── WebApplication1.csproj            # Archivo de proyecto
```

---

## Apéndice C: Glosario de Términos

- **ADO.NET**: Tecnología de acceso a datos de Microsoft
- **ASP.NET Core**: Framework para aplicaciones web
- **Bootstrap**: Framework CSS para diseño responsive
- **CRUD**: Create, Read, Update, Delete (operaciones básicas)
- **DAO**: Data Access Object (objeto de acceso a datos)
- **HTML**: HyperText Markup Language (lenguaje de marcado)
- **HTTP**: HyperText Transfer Protocol (protocolo web)
- **HTTPS**: HTTP Secure (versión segura)
- **IConfiguration**: Interfaz para configuración en .NET
- **Inyección de Dependencias**: Patrón de diseño para gestionar dependencias
- **Model Binding**: Vincular datos del formulario con objetos C#
- **MySQL**: Sistema de gestión de bases de datos
- **NuGet**: Gestor de paquetes para .NET
- **PageModel**: Clase que contiene la lógica de una Razor Page
- **POO**: Programación Orientada a Objetos
- **Razor**: Motor de plantillas de ASP.NET Core
- **Razor Pages**: Modelo de programación basado en páginas
- **Session**: Almacenamiento temporal de datos del usuario
- **SQL**: Structured Query Language (lenguaje de consultas)

---

**Fin del Tutorial**

Este documento puede ser convertido a DOCX usando:
- Microsoft Word (Archivo → Abrir → seleccionar este .md)
- Pandoc: `pandoc TUTORIAL_COMPLETO.md -o TUTORIAL_COMPLETO.docx`
- Convertidores online: https://www.markdowntopdf.com/

¡Éxito con tu curso! 🚀
