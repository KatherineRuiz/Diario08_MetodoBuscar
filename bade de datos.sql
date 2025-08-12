Create database Negocio
go
use Negocio;
go

create table Categoria(
idCategoria int primary key identity(1,1),
nombreCategoria varchar (30) not null
);
go

create table Producto(
idProducto int primary key identity(1,1),
nombreProducto varchar (30) not null,
cantidad int not null,
id_Categoria int not null,
constraint fkCategoria foreign key (id_Categoria) references Categoria(idCategoria) on delete cascade
);
go

insert into Categoria values ('Frutas'), ('Verduras'), ('Granos');

insert into Producto values ('Manzana', 5, 1), ('Zanahoria', 9, 2), ('Arroz', 7, 3);

select *from Categoria
select *from Producto

select idProducto As Num, nombreProducto As Producto, cantidad as Cantidad, nombreCategoria as Categoria from Producto P
INNER JOIN 
Categoria C on C.idCategoria = P.id_Categoria 