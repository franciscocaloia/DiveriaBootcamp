# SQL

## <u> Crear una DB</u>

    Al crear una base de datos se pide un nombre y este es propuesto como nombre de los archivos donde se guardara la base de datos en el equipo. Tiene un archivo de datos principal y un archivo de registro de transacciones que luego pueden ampliarse con archivos secundarios. Los registros de transacciones contienen la informacion de registro que se utiliza para recuperar la base de datos. 

Se puede especificar el crecimiento de la base de datos de manera manual o automatica.

### Arquitectura Fisica

    LDF: Bloque de transacciones

    MDF: Archivo de datos 

    Secondary Data: Pueden existir varios y tienen extencion NDF

    logs: Tienen extencion de archivo .ldf 

    Files Groups: Se crean grupos de archivos para su administracion y asignacion.

## Bases de datos del Sistema

#### Master:

    Registra toda la informacion del sistema para una instancia de SQL server. Por ejemplo, la creacion de bases de datos se registra en la DB Master.

#### MSDB:

#### Model:

    Se utiliza como plantilla para crear bases de datos instancias de SQL Server.

#### TempDB:

    Es el area de trabajo que contiene objetos temporales o conjuntos de resultados intermedios.

## Tipos de datos

<img src="file:///C:/Users/franc/AppData/Roaming/marktext/images/2023-03-22-09-28-07-image.png" title="" alt="" width="597">

## Scripts

Declaracion de variables

```sql
declare @<nombre-variable> as <tipo-de-dato>
```

Asignacion de variables

```sql
set @<nombre-variable> = <valor>
```

Ejemplo 

```sql
declare @nombre as varchar(50);
set @nombre = 'hola';
print @nombre
```

resultado: 

<img src="file:///C:/Users/franc/AppData/Roaming/marktext/images/2023-03-22-10-42-03-image.png" title="" alt="" width="725">

## Consulta de datos

Sintaxis

```sql
SELECT [TOP] [DISTINCT] select_list [ INTO new_table ]
[ FROM table_source ]
[ WHERE search_condition ]
[ GROUP BY group_by_expression ]
[ HAVING search_condition ]
[ ORDER BY order_expression [ ASC I DESC ] ]
```

```sql
CREATE TABLE TIPOCLIENTE (
TipoCliente int IDENTITY[(1, 1)]  NOT NULL,
Tipo varchar(50),
 CONSTRAINT PK_TIPOCLIENTE PRIMARY KEY (TipoCliente)
)
```

```sql
INSERT INTO [DBEjemplo].[dbo].[TIPOCLIENTE]
           (Tipo)
     VALUES
           ('Standard'),('Especial'),('Premium')
```

```sql
ALTER TABLE CLIENTES ADD TipoCliente int
ALTER TABLE CLIENTES
ADD CONSTRAINT FK_CLIENTE_TIPOCLIENTE
FOREIGN KEY (TipoCliente) REFERENCES TIPOCLIENTE(TipoCliente);
)
```

3

```sql
CREATE TABLE  LOCALIDADES (
    IdLocalidad int IDENTITY(1,1) NOT NULL,
    Nombre varchar(50),
    CONSTRAINT PK_LOCALIDADES PRIMARY KEY (IdLocalidad)
)
CREATE TABLE  PROVINCIAS (
    IdProvincia int IDENTITY(1,1) NOT NULL,
    Nombre varchar(50),
    CONSTRAINT PK_PROVINCIA PRIMARY KEY (IdProvincia)
)
CREATE TABLE  PAISES (
    IdPais int IDENTITY(1,1) NOT NULL,
    Nombre varchar(50),
    CONSTRAINT PK_PAISES PRIMARY KEY (IdPais)
)
```

```sql
ALTER TABLE PERSONAS
ALTER COLUMN IdLocalidad int;
ALTER TABLE PERSONAS
ALTER COLUMN IdProvincia int;
ALTER TABLE PERSONAS
ALTER COLUMN IdPais int;

ALTER TABLE PERSONAS
ADD CONSTRAINT FK_PERSONAS_LOCALIDADS
FOREIGN KEY (IdLocalidad) REFERENCES LOCALIDADES(IdLocalidad);
ALTER TABLE PERSONAS
ADD CONSTRAINT FK_PERSONAS_PROVINCIAS
FOREIGN KEY (IdProvincia) REFERENCES PROVINCIAS(IdProvincia);
ALTER TABLE PERSONAS
ADD CONSTRAINT FK_PERSONAS_PAISES
FOREIGN KEY (IdPais) REFERENCES PAISES(IdPais);
```

```sql
CREATE TABLE #TEMP (
    [Month] int,
    [Year] int,
    Total decimal(18,2),
    Category varchar(50)
)

INSERT INTO #TEMP ([Month],[Year],[Total])
SELECT 
        MONTH(Fecha),
        YEAR(Fecha),
        SUM(VENTAS.ValorUnitario*VENTAS.Cantidad)

  FROM [dbo].[VENTAS] GROUP BY MONTH(Fecha), YEAR(Fecha);

UPDATE #TEMP
SET Category = 'Malo'
WHERE Total <= 1000;

UPDATE #TEMP
SET Category = 'Normal'
WHERE Total > 1000 AND Total <=5000;

UPDATE #TEMP
SET Category = 'Muy bueno'
WHERE #TEMP.Total > 5000 ;

SELECT * FROM #TEMP

DROP TABLE #TEMP
```

4

```sql
CREATE PROCEDURE sp_clientes_insert
@IdPersona int,
@FechaAlta datetime ,
@FechaBaja datetime ,
@LimiteCredito money,
@TipoCliente int
AS
INSERT INTO CLIENTES VALUES (@IdPersona,@FechaAlta,@FechaBaja,@LimiteCredito,@TipoCliente);
```

```sql
CREATE PROCEDURE sp_personas_insert @Nombres varchar(100),
@Apellidos varchar(100),
@TipoDocumento char(3),
@NroDocumento int,
@Domicilio varchar(100),
@IdLocalidad int,
@IdProvincia int,
@IdPais int 
AS 
INSERT INTO PERSONAS VALUES(@Nombres, @Apellidos,@TipoDocumento,@NroDocumento,@Domicilio,@IdLocalidad,@IdProvincia,@IdPais);
```

```sql
CREATE PROCEDURE sp_localidades_insert @Nombre varchar(50) AS 
INSERT INTO dbo.LOCALIDADES values (@Nombre);
```
