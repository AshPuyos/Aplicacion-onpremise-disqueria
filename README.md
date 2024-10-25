# Aplicación de Gestión de Ventas para Disquería

Este proyecto es una aplicación de escritorio desarrollada para una disquería, diseñada para permitir a los empleados registrar la venta de productos, específicamente vinilos y CDs. La aplicación incluye un sistema de gestión de usuarios, donde los empleados pueden iniciar sesión utilizando un usuario y contraseña, con la información de los usuarios almacenada en un archivo XML y las contraseñas encriptadas.

La aplicación también gestiona productos, vendedores, géneros musicales y ventas, almacenando esta información en una base de datos SQL Server. Los empleados pueden realizar operaciones de ABM (Alta, Baja, Modificación) en todas las clases, incluida la de usuarios.

Además, se generan informes visuales que muestran los productos vendidos por artistas y las ganancias totales de los empleados que hayan registrado ventas.

## Características

- **Interfaz gráfica MDI**: Interfaz de múltiples documentos para una mejor gestión de ventanas.
- **Sistema de autenticación**: Login para empleados con usuarios y contraseñas encriptadas.
- **Base de datos SQL Server**: Uso de procedimientos almacenados y parámetros para la gestión de datos.
- **Operaciones ABM**: Gestión de productos, vendedores, géneros musicales y usuarios.
- **Descuentos**: Aplicación automática de descuentos del 10% para vinilos usados y 5% para CDs.
- **Informes gráficos**: Visualización de productos vendidos por artistas y ganancias totales a través de gráficos.
- **Manejo de errores**: Captura de excepciones en toda la aplicación.
- **Almacenamiento en XML**: Lectura, escritura y búsqueda en archivos XML para la gestión de usuarios.
- **Control de usuario**: Implementación de un control personalizado para la interfaz.

## Tecnologías Utilizadas

- C# .NET Framework
- SQL Server
- XML
- ADO.NET
- Gráficos (Charts o ReportViewer)
