USE master
GO
ALTER DATABASE TRANSMETRO SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
DROP DATABASE TRANSMETRO
GO

CREATE DATABASE TRANSMETRO
GO
USE TRANSMETRO

-- Table structure for table `lineas`
CREATE TABLE lineas (
  ID_LINEA int NOT NULL IDENTITY(1,1),
  NOMBRE varchar(100) DEFAULT NULL,
  LONGITUD float DEFAULT NULL,
  PRIMARY KEY (ID_LINEA)
);

-- Table structure for table `parqueos`
CREATE TABLE parqueos (
  ID_PARQUEO int NOT NULL IDENTITY(1,1),
  UBICACION varchar(255) DEFAULT NULL,
  CAPACIDAD int DEFAULT NULL,
  PRIMARY KEY (ID_PARQUEO)
);

-- Table structure for table `puestos`
CREATE TABLE puestos (
  ID_PUESTO int NOT NULL IDENTITY(1,1),
  NOMBRE varchar(100) DEFAULT NULL,
  DESCRIPCION varchar(255) DEFAULT NULL,
  PRIMARY KEY (ID_PUESTO)
);

-- Table structure for table `municipalidades`
CREATE TABLE municipalidades (
  ID_MUNICIPALIDAD int NOT NULL IDENTITY(1,1),
  NOMBRE varchar(100) DEFAULT NULL,
  DIRECCION varchar(255) DEFAULT NULL,
  PRIMARY KEY (ID_MUNICIPALIDAD)
);

-- Table structure for table `estaciones`
CREATE TABLE estaciones (
  ID_ESTACION int NOT NULL IDENTITY(1,1),
  NOMBRE varchar(100) DEFAULT NULL,
  DIRECCION varchar(255) DEFAULT NULL,
  ID_MUNICIPALIDAD int DEFAULT NULL,
  PRIMARY KEY (ID_ESTACION)
);
ALTER TABLE estaciones ADD CONSTRAINT FK_estaciones_municipalidades FOREIGN KEY (ID_MUNICIPALIDAD) REFERENCES municipalidades (ID_MUNICIPALIDAD);

-- Table structure for table `accesos`
CREATE TABLE accesos (
  ID_ACCESO int NOT NULL IDENTITY(1,1),
  ID_ESTACION int DEFAULT NULL,
  DESCRIPCION varchar(255) DEFAULT NULL,
  PRIMARY KEY (ID_ACCESO)
);
ALTER TABLE accesos ADD CONSTRAINT FK_accesos_estaciones FOREIGN KEY (ID_ESTACION) REFERENCES estaciones (ID_ESTACION);

-- Table structure for table `buses`
CREATE TABLE buses (
  ID_BUS int NOT NULL IDENTITY(1,1),
  CAPACIDAD int DEFAULT NULL,
  ID_LINEA int DEFAULT NULL,
  ID_PARQUEO int DEFAULT NULL,
  PRIMARY KEY (ID_BUS)
);
ALTER TABLE buses ADD CONSTRAINT FK_buses_lineas FOREIGN KEY (ID_LINEA) REFERENCES lineas (ID_LINEA);
ALTER TABLE buses ADD CONSTRAINT FK_buses_parqueos FOREIGN KEY (ID_PARQUEO) REFERENCES parqueos (ID_PARQUEO);

-- Table structure for table `empleados`
CREATE TABLE empleados (
  ID_EMPLEADO int NOT NULL IDENTITY(1,1),
  NOMBRE varchar(100) DEFAULT NULL,
  DIRECCION varchar(255) DEFAULT NULL,
  TELEFONO varchar(20) DEFAULT NULL,
  ID_PUESTO int DEFAULT NULL,
  PRIMARY KEY (ID_EMPLEADO)
);
ALTER TABLE empleados ADD CONSTRAINT FK_empleados_puestos FOREIGN KEY (ID_PUESTO) REFERENCES puestos (ID_PUESTO);

-- Table structure for table `estacion_linea`
CREATE TABLE estacion_linea (
  ID_ESTACION int NOT NULL,
  ID_LINEA int NOT NULL,
  ORDEN int DEFAULT NULL,
  DISTANCIA_SIGUIENTE float DEFAULT NULL,
  PRIMARY KEY (ID_ESTACION,ID_LINEA)
);
ALTER TABLE estacion_linea ADD CONSTRAINT FK_estacion_linea_estaciones FOREIGN KEY (ID_ESTACION) REFERENCES estaciones (ID_ESTACION);
ALTER TABLE estacion_linea ADD CONSTRAINT FK_estacion_linea_lineas FOREIGN KEY (ID_LINEA) REFERENCES lineas (ID_LINEA);

-- Table structure for table `turnos_bus`
CREATE TABLE turnos_bus (
  ID_TURNO int NOT NULL IDENTITY(1,1),
  ID_EMPLEADO int DEFAULT NULL,
  ID_BUS int DEFAULT NULL,
  FECHA_INICIO datetime DEFAULT NULL,
  FECHA_FIN datetime DEFAULT NULL,
  PRIMARY KEY (ID_TURNO)
);
ALTER TABLE turnos_bus ADD CONSTRAINT FK_turnos_bus_empleados FOREIGN KEY (ID_EMPLEADO) REFERENCES empleados (ID_EMPLEADO);
ALTER TABLE turnos_bus ADD CONSTRAINT FK_turnos_bus_buses FOREIGN KEY (ID_BUS) REFERENCES buses (ID_BUS);


GO

--valores de ejemplo:
-- Inserts for table `lineas`
INSERT INTO lineas (NOMBRE, LONGITUD) VALUES ('Linea 1', 10.5);
INSERT INTO lineas (NOMBRE, LONGITUD) VALUES ('Linea 2', 15.0);
INSERT INTO lineas (NOMBRE, LONGITUD) VALUES ('Linea 3', 12.3);

-- Inserts for table `parqueos`
INSERT INTO parqueos (UBICACION, CAPACIDAD) VALUES ('Parqueo zona 1', 100);
INSERT INTO parqueos (UBICACION, CAPACIDAD) VALUES ('Parqueo zona 2', 200);
INSERT INTO parqueos (UBICACION, CAPACIDAD) VALUES ('Parqueo zona 3', 150);

-- Inserts for table `puestos`
INSERT INTO puestos (NOMBRE, DESCRIPCION) VALUES ('Guardia', 'Guardian de linea');
INSERT INTO puestos (NOMBRE, DESCRIPCION) VALUES ('Piloto', 'Piloto de bus');

-- Inserts for table `municipalidades`
INSERT INTO municipalidades (NOMBRE, DIRECCION) VALUES ('Municipalidad 1', 'Direccion 1');
INSERT INTO municipalidades (NOMBRE, DIRECCION) VALUES ('Municipalidad 2', 'Direccion 2');
INSERT INTO municipalidades (NOMBRE, DIRECCION) VALUES ('Municipalidad 3', 'Direccion 3');

-- Inserts for table `estaciones`
INSERT INTO estaciones (NOMBRE, DIRECCION, ID_MUNICIPALIDAD) VALUES ('Estacion 1', 'Direccion zona 1', 1);
INSERT INTO estaciones (NOMBRE, DIRECCION, ID_MUNICIPALIDAD) VALUES ('Estacion 2', 'Direccion zona 2', 2);
INSERT INTO estaciones (NOMBRE, DIRECCION, ID_MUNICIPALIDAD) VALUES ('Estacion 3', 'Direccion zona 3', 3);

-- Inserts for table `accesos`
INSERT INTO accesos (ID_ESTACION, DESCRIPCION) VALUES (1, 'Acceso 1');
INSERT INTO accesos (ID_ESTACION, DESCRIPCION) VALUES (2, 'Acceso 2');
INSERT INTO accesos (ID_ESTACION, DESCRIPCION) VALUES (3, 'Acceso 3');

-- Inserts for table `buses`
INSERT INTO buses (CAPACIDAD, ID_LINEA, ID_PARQUEO) VALUES (50, 1, 1);
INSERT INTO buses (CAPACIDAD, ID_LINEA, ID_PARQUEO) VALUES (60, 2, 2);
INSERT INTO buses (CAPACIDAD, ID_LINEA, ID_PARQUEO) VALUES (70, 3, 3);

-- Inserts for table `empleados`
INSERT INTO empleados (NOMBRE, DIRECCION, TELEFONO, ID_PUESTO) VALUES ('Miranda', 'Direccion ciudad', '545222200', 1);
INSERT INTO empleados (NOMBRE, DIRECCION, TELEFONO, ID_PUESTO) VALUES ('Nestor', 'Direccion ciudad', '25362244',2);
-- Inserts for table `estacion_linea`
INSERT INTO estacion_linea (ID_ESTACION, ID_LINEA, ORDEN, DISTANCIA_SIGUIENTE) VALUES (1, 1, 1, 2.5);
INSERT INTO estacion_linea (ID_ESTACION, ID_LINEA, ORDEN, DISTANCIA_SIGUIENTE) VALUES (2, 2, 2, 3.0);
INSERT INTO estacion_linea (ID_ESTACION, ID_LINEA, ORDEN, DISTANCIA_SIGUIENTE) VALUES (3, 3, 3, 1.5);

-- Inserts for table `turnos_bus`
INSERT INTO turnos_bus (ID_EMPLEADO, ID_BUS, FECHA_INICIO, FECHA_FIN) VALUES (1, 1, '2024-05-01T08:00:00', '2024-05-01T16:00:00');
INSERT INTO turnos_bus (ID_EMPLEADO, ID_BUS, FECHA_INICIO, FECHA_FIN) VALUES (2, 2, '2024-05-02T08:00:00', '2024-05-02T16:00:00');
