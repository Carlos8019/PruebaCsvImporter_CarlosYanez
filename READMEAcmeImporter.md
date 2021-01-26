# PruebaCsvImporter_CarlosYanez
Import CVS file from public azure storage without credentials to SQLServer local database, Acme Corporation company

Desarrollador: Carlos Yanez
Tecnologia utilizada:
Ubuntu 20.04.1 LTS
Visual Studio Code
.NET Core 3.1
SQLServer 2016 for Ubuntu
Plugins:  desde https://www.nuget.org/packages
dotnet add package CsvTextFieldParser --version 1.2.1
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.2
dotnet add package Microsoft.EntityFrameworkCore.tools --version 5.0.2
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.2
dotnet add package Microsoft.Extensions.Configuration --version 5.0.0
dotnet add package Microsoft.Extensions.Configuration.FileExtensions --version 5.0.0
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables --version 5.0.0
dotnet add package Microsoft.Extensions.Configuration.Json --version 5.0.0
dotnet add package Microsoft.Extensions.DependencyInjection --version 5.0.1

Comando de creacion de los proyectos y solucion
mkdir acmeSln
cd acmeSln/
dotnet new sln -n "vscodeAcmeSln"
dotnet new console -n "acmeProgram"
dotnet new console -n acmeDB
dotnet sln vscodeAcmeSln.sln add ./acmeProgram/acmeProgram.csproj
dotnet sln vscodeAcmeSln.sln add ./acmeDB/acmeDB.csproj
cd acmeProgram/
dotnet add reference ../acmeDB/acmeDB.csproj 
cd acmeProgram/
Code .


Solucion implementada
Se desarrollo el programa, con el siguiente analisis:
1.-Debido a la gran cantidad de datos 17millones de registros, se propone descargar los datos hacia un stream.
2.-Una vez extraido, se crean lotes de informacion con un numero parametrizable de filas por cada lote, para ser
   enviados a la base de datos.
3.-Se serializa los datos extraidos a formato JSON para agilitar el envio, y que por medio de SQL se deserialize
   e inserte en una tabla con datos en formato texto sin conversiones, dentro de las pruebas realizadas no se crearon
   indices, pero se podrian crear dependiendo del flujo de informacion.

Opciones descartadas.
1.-La solucion mas optima es utilizar ETL's para otener la informacion, pero debido al requerimiento se utilizara C#
2.-Se intento obtener todos los datos en una lista de strings directo, sin exito.
3.-Se utilizo el plugin ChoETL, para la serializacion de los datos, obteniendo un consumo excesivo de recursos de memoria
   y espocio en disco.
4.-Para controlar el contenido de una posible previa importacion se utiliza un try catch en lugar de una sentencia
   if para evitar complicar la extraccion de los datos

Organizacion de la solucion:
Existen 3 proyectos en la solucion:
1.-ACMEDB, proyecto de manejo del ORM Entity Framework core, y metodos de insercion hacia a base, contiene tambien
   la clase POCO que se utiliza para mapear la informacion obtenida en las 4 columnas. Se utiliza la funcion ExecuteSqlRawAsync
   de EF que permite la insercion asincrona de los datos.
2.-ACMEProgram, proyecto que contiene la funcionalidad de extraccion del archivo CSV desde azure y la generacion de los datos por lotes
   para ser enviados a la base de datos en formato JSON, por medio de la clase clCsvImporter que utiliza una interface para
   implementar el metodo "readFileAsync".
3.-AcmeTest, proyecto para realizar pruebas de insercion de datos con poco informacion en la clase Program.cs se encuentra
  un proceso detallado para validar la insercion.


Funcionamiento del programa:
Se describe el funcionamiento con los siguientes pasos:
1.-El programa se conecta por medio de un URLStream al repositorio de azure y realiza la descarga, de esta manera
   se evita el consumo excesivo de memoria RAM, ya que se tiene una descarga de bytes aun no descifrados con un tipo
   de dato mas pesado (string, int, etc).
2.-Se utiliza el plugin TextFieldParser para transformar el formato csv a un string recorriendo cada fila obtenida
   por medio de la funcion "csvReader.ReadFields()", este componente esta parametrizado con el separador o delimitador
3.-Se crea el POCO Product que es una clase con el mapping de los 4 campos o columnas del archivo cvs,creando una lista
   de objetos Product.
4.-Se controla en numero de filas que seran insertados en la lista de POCO's para enviar por lotes hacia la base de 
   datos de manera asyncrona para ganar tiempo de insercion y descarga de datos.
5.-Una vez se llegue al numero de filas parametrizados por medio del archivo Parameters.json entrada "batchProcess->numRows"
   se serializa los objetos de la lista de POCO's a formato JSON por medio de "JsonConvert.SerializeObject", para optimizar
   el envio de parametros hacia la base de datos
6.-Una vez serializado se invoca la funcion "insertDataACMEAsync" del proyecot acmeDB (methods.ManageACMEData.class) para 
   el envío de los datos mediante la invocacion de un procedimiento almacenado "[dbo].[sp_InsertProductsACME]"
7.-El procedimiento almacenado descifra los datos en JSON por medio de la funcion "OPENJSON" de SQL Server y los inserta en
   la tabla tblProductsACME, controlando mediante un try catch el proceso, si existe algun problema de insercion, se inserta
   el JSON "crudo" hacia la tabla "tblErrorInsertACME" para su posterior validacion y que el proceso continue.
 8.-El SP genera una respuesta por medio de un parametro de salida (out) que es recibido por Entity Framework.
 9.-Con esta respuesta se envia a consola la informacion del estado de la carga, notificando al usuario.

Datos Adcionales
1.-Se tiene el archivo Parameters.json en donde se encuentra parametrizado el numero de filas por lote, la URL y las
   credenciales de la base de datos.
2.-La creacion de las tablas se encuentra en el archivo createTableProductsACME.sql, la creacion del procedimiento almacenado
   en sp_InsertProductsACME.sql y la creacion de la base de datos ACMEDB en createDataBase.sql
  
