create database Recursos_Humanos
go
use Recursos_Humanos

create table Empleados(
IdEmpleado int not null  primary key identity(1,1),
Codigo int not null,
Nombre varchar(20),
Apellido varchar (20),
Telefono varchar (15),
Departamento int,--foreign key (Departamento) references Departamentos(IdDepartamento),
Cargo int,--foreign key (Departamento) references Departamentos(IdDepartamento),
FechaIngreso date,
Salario float,
Estatus varchar (20),--activo/inactivo
CHECK (Estatus in ('Activo' ,'Inactivo'))
)

select * from Empleados
--check
ALTER TABLE Empleados 
ADD CHECK (Estatus in ('Activo' ,'Inactivo'))

go



create table Departamentos(
IdDepartamento int not null identity primary key,
CodigoDep int not null,
Nombre varchar(20),
Encargado varchar(30),
)
go
drop table Departamentos
select * from departamentos

create table Cargos(
IdCargos int not null identity(1,1) primary key,
CodigoCargo int not null,
Cargo varchar (20)
)
go

drop table Cargos



create table Nomina(
IdNomina int not null primary key identity(1,1),
Año int not null, --un check que solo se introduzca 4 numeros--check (Año>2017)
Mes int not null, -- un check que solo se intruduzca 2 numeros--check (Mes>=1 and Mes<=12)
MontoTotal int  

)
go
alter table Nomina 
add constraint checkaño
check (Año>2017)
go

------BUSCAR LA FORMA DE PODER INSERTAR EL TOTAL SALARIO A LA TABLA
alter table Nomina 
add constraint checkMes
check (Mes>=1 and Mes<=12)

-----------------------------------------------------------------------------------
--Falta crearlo
create table SalidaEmpleado(
IdSalidaEmpleado int not null primary key identity(1,1),
Empleado int,
TipoSalida varchar(10) not null,--check despido, renuncia, desahucio
Motivo varchar(40),
FechaSalida date --salida de un empleado es inactivarlo
)
go


alter table SalidaEmpleado
add constraint checkTipoSalida
check (TipoSalida in ('Renuncia','Despido','Desahucio'))

drop Table CkecSalida(
idTipoSalida int not null primary key identity(1,1),
TipoSalida2 varchar(11)

)
insert into CkecSalida values ('Renuncia')
insert into CkecSalida values ('Despido')
insert into CkecSalida values ('Desaucio')


---------------------------------------------------------------

GO
create table Vacaciones(
IdVacaciones int not null primary key identity(1,1),
Empleado int not null,
Desde date,
Hasta date,
Comentario varchar(50)
)

create table Permisos(
IdPermiso int not null primary key identity(1,1),
Empleado int not null,
Desde date,
Hasta date,
Comentarios varchar (50)
)


create table Licencias(
IdLicencias int not null primary key identity(1,1),
Empleado int not null,
Desde date,
Hasta date,
motivo varchar (50),
Comentarios varchar(50)
)



create table Usuario(
IdUser int not null primary key identity(1,1),
Nombre varchar(15),
contrasenia varchar(15)

)
select * from Usuario


-------------------------------------------------------------------------------------
--foreing key

--departementos con empleados
ALTER TABLE Empleados
ADD CONSTRAINT FK_IdEmpleadoDepartamentos
foreign key (Departamento) references Departamentos(IdDepartamento);
go
-----------
--cargos con empleados
ALTER TABLE Empleados
ADD CONSTRAINT FK_IdEmpleadoCargos
foreign key (Cargo) references Cargos(IdCargos);

-------------------------
--Vacacines con empleado
ALTER TABLE Vacaciones
ADD CONSTRAINT FK_IdEmpleadoVacaciones
foreign key (Empleado) references Empleados(IdEmpleado);
---------------------------------
--permisos empleados
ALTER TABLE Permisos
ADD CONSTRAINT FK_EmpleadoPermiso
foreign key (Empleado) references Empleados(IdEmpleado);

----------------------------------
--licencias empleado
ALTER TABLE Licencias
ADD CONSTRAINT FK_empleadoLicencia
foreign key (Empleado) references Empleados(IdEmpleado);
--------------------------------------------------
--salida empleado
ALTER TABLE SalidaEmpleado
ADD CONSTRAINT FK_SalidaEmpleado
foreign key (Empleado) references Empleados(IdEmpleado);


-------------------------------------------SELECTS-----------------------------------------------------------

select * from  Empleados
go
select * from  Departamentos
go
select * from Cargos
go
select * from Nomina
go
select * from Vacaciones
go 
select * from Permisos
go
select * from Licencias
go
select * from SalidaEmpleado

ALTER TABLE Empleados
DROP CONSTRAINT [FK_IdEmpleadoDepartamentos]


------------INSERT-------------------------------------------------
--empleado
insert into Empleados values (001,'Jonathan','Santana','829-278-8736',1,2,'11/16/2018',60000,'Activo')
go
insert into Empleados values (002,'Eve','Nuñez','829-278-8486',1,3,'06/20/2019',60000,'Activo')
go
insert into Empleados values (003,'Esteban','Santana','849-288-8156',1,1,'06/20/2018',80000,'Activo')
go
insert into Empleados values (004,'Nieves','Santana','829-288-8156',2,1,'06/20/2018',80000,'Activo')
go
insert into Empleados values (005,'Gerardo','Bauista','849-288-8156',3,1,'06/20/2018',80000,'Activo')

--departamentos
insert into Departamentos values (001,'TI','Esteban')

insert into Departamentos values (002,'Contabilidad','Nieves')

insert into Departamentos values (003,'Financiero','Gerardo')

--cargos
insert into Cargos values (001,'Encargado')
go
insert into Cargos values (002,'Gerente')
go
insert into Cargos values (003,'Developer')
go
insert into Cargos values (004,'Contador')

---------------------pruebas---------------------
--consulta para la suma de el monto total
create view pruebaMontoTotal
as
select sum (Salario) as TotalSalario from Empleados

select * from pruebaMontoTotal
------
select * from Nomina
insert into Nomina values(2018,5,)




-----------------------CONSULTAS--------
select Empleados.Nombre from Empleados where Empleados.Estatus = 'Activo' and Empleados.Nombre = 'Nieves'
select Empleados.Nombre from Empleados inner join Departamentos on
Empleados.IdEmpleado = Departamentos.IdDepartamento  where Empleados.Estatus = 'Activo' and Departamentos.IdDepartamento = 1;


select * from Departamentos
select * from Cargos

select Departamentos.Nombre from Departamentos

select Cargos.Cargo from Cargos




