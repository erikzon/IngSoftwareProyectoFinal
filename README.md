# proyectoIngSoftware

## requisitos
IDE Visual Studio 2022 \
.Net 8 \
Base de datos SQL Server \
\
instalar Entity framework con el siguiente comando: \
```dotnet tool install --global dotnet-ef```

## instrucciones para desarrollo
actualizar appsettings.json con la connection string de sql server de su computadora, preferiblemente conectarse con usuario SA. \
el script "script.sql" debe de haberse ejecutado en sql server antes de tratar de ejecutar el proyecto. 

si la aplicacion se ejecuta pero sale una pantalla de que requiere aplicar migraciones se debe dar click en "aplicar migraciones" si no funciona se debe ejecutar este comando en la raiz del projecto: \
```dotnet ef database update --context ApplicationDbContext```

## comando actualizacion modelos
este solo es necesario ejecutarlo si se desean actualizar los modelos en caso se han realizado cambios a la estructura de la base de datos (agregar tabla, relacion o columna)

```dotnet ef dbcontext scaffold "Name=ConnectionStrings:DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer -o Models --no-pluralize --data-annotations --force```
