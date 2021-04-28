create database TIENDADB

use TIENDADB

create table Marca (
	MarcaId numeric identity,
	Codigo numeric,
	Descripcion varchar(100),
	primary key(MarcaId)
)


create table TipoProducto (
	TipoProductoId numeric identity,
	Codigo numeric,
	Nombre varchar(50),
	primary key(TipoProductoId)
)


create table Producto (
	ProductoId numeric identity,
	MarcaId numeric,
	TipoProductoId numeric,
	Descripcion varchar(20),
	Talla varchar(20),
	Color varchar(20),
	Precio money,
	Stock numeric,
	primary key(ProductoId),
	foreign key (MarcaId) references Marca(MarcaId),
	foreign key (TipoProductoId) references TipoProducto(TipoProductoId)
)


create table Ticket (
	TicketId numeric identity,
	Fecha datetime,
	Subtotal money,
	Descuento money,
	Importe money,
	CantidadProductos numeric,
	primary key(TicketId)
)

create table TicketDetalle (
	TicketDetalleId numeric identity,
	TicketId numeric,
	ProductoId numeric,
	primary key(TicketDetalleId),
	foreign key (TicketId) references Ticket (TicketId),
	foreign key (ProductoId) references Producto (ProductoId)
)


insert into Marca (Codigo, Descripcion) 
values (1, 'Levis') ,(2, 'H&M'), (3,'Jack&Jones')

insert into TipoProducto (Codigo, Nombre)
values (103,'Sombrero'), (104, 'Perfume'), (105, 'Jeans'), (106, 'Camiseta')

insert into Producto (MarcaId, TipoProductoId, Descripcion, Talla, Color, Precio, Stock)
values (1, 4, 'Camiseta', 'XL', 'Verde', 35, 6) ,
		(2, 2, 'Perfume hombre', '50ml', null, 80, 105),
		(3, 3, 'Pantalon Denim', '44', null, 75, 28)


select * from Marca

select * from TipoProducto

select * from Producto