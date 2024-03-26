# Instrucciones para el funcionamiento

### Crear una base de datos con el siguiente nombre, usuario y contraseña.   
Nombre=pizzeria  
Username=pizza  
Password=pizza123

### Ejecutar los siguientes comando dentro del proyecto para generar las tablas de la base de datos

*dotnet ef migrations add InitialMigration -p Infraestructure -s Web.API -o Persistence/Migrations*  
*dotnet ef database update -p Infraestructure -s Web.API*

### Ejecutar el proyecto desde el Run and Debug de Visual