# Sistema-de-Inventario
Este proyecto es un Sistema de Inventario que utiliza una base de datos SQLite para la gestión de productos y almacenes.

El sistema incluye las siguientes pantallas principales:
Inicio de Sesión 
Pantalla Principal 
Gestión de Productos 
Gestión de Almacenes 

El sistema permite la gestión completa del inventario con las siguientes capacidades:
Solo tres usuarios tienen acceso al sistema. El inicio de sesión exitoso muestra un mensaje de bienvenida con el rol asignado.
Admin=admin23 
productos=producto19 
almacen=almacen11 

Al intentar acceder con credenciales incorrectas, se muestra un "Error de autenticación".
La opción de "¿Olvidaste tu contraseña?" no permite modificar la contraseña. Simplemente muestra una foto y te obliga a regresar al inicio de sesión.

Gestión de Productos:
La interfaz de productos permite: 
Ver la lista de 91 productos en la tabla. 
Filtrar productos por nombre, cantidad, precio, departamento, y fechas. 
Agregar/Modificar Producto (disponible para Admin y productos) y eliminar producto (disponible para Admin y productos).

Permisos: Un usuario como almacén puede ver y filtrar los productos, pero no puede modificar, agregar o eliminar.

Gestión de Almacenes: La interfaz de almacenes permite: 
Ver la lista de almacenes. 
Agregar/Modificar Almacenes (disponible para Admin y almacén). 
Eliminar almacén (disponible para Admin y almacen). 

Requisito para Modificar/Eliminar: Se debe seleccionar un almacén de la tabla antes de intentar modificar o eliminar.


