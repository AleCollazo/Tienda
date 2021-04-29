
GO
if not exists(select 1 from sys.databases where name = 'TIENDADB')
begin
	create database TIENDADB
end

GO
use TIENDADB

GO


GO
if object_id('Marca','U') is null
begin
	create table Marca (
		MarcaId numeric identity,
		Codigo numeric,
		Descripcion varchar(100),
		primary key(MarcaId)
	)
end

if object_id('TipoProducto','U') is null
begin
	create table TipoProducto (
		TipoProductoId numeric identity,
		Codigo numeric,
		Nombre varchar(50),
		primary key(TipoProductoId)
	)
end

if object_id('Producto','U') is null
begin
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
end


if object_id('Ticket','U') is null
begin
	create table Ticket (
		TicketId numeric identity,
		Fecha datetime,
		Subtotal money,
		Descuento money,
		Importe money,
		CantidadProductos numeric,
		primary key(TicketId)
	)
end


if object_id('TicketDetalle','U') is null
begin
	create table TicketDetalle (
		TicketDetalleId numeric identity,
		TicketId numeric,
		ProductoId numeric,
		primary key(TicketDetalleId),
		foreign key (TicketId) references Ticket (TicketId),
		foreign key (ProductoId) references Producto (ProductoId)
	)
end


declare @initInserts bit

set @initInserts = 1

if @initInserts = 1
begin
	insert into Marca (Codigo, Descripcion) 
	values (1, 'Levis') ,(2, 'H&M'), (3,'Jack&Jones')

	insert into TipoProducto (Codigo, Nombre)
	values (103,'Sombrero'), (104, 'Perfume'), (105, 'Jeans'), (106, 'Camiseta')

	insert into Producto (MarcaId, TipoProductoId, Descripcion, Talla, Color, Precio, Stock)
	values (1, 4, 'Camiseta', 'XL', 'Verde', 35, 6) ,
			(2, 2, 'Perfume hombre', '50ml', null, 80, 105),
			(3, 3, 'Pantalon Denim', '44', null, 75, 28)
end


ALTER TABLE Producto ALTER COLUMN Descripcion varchar(100)

if not exists (select 1 from TipoProducto where TipoProductoId = 7)
begin
	DBCC CHECKIDENT('TipoProducto', RESEED, 6)
	
	insert into TipoProducto values (107, 'Camiseta style')
end
	


declare @cnt int = 0;
declare @ind int;
declare @now datetime;
declare @color varchar(25);
declare @marca int;
declare @stock int;



while @cnt < 1000
begin
	set @ind = floor(rand() * 1000 +1);
	set @now = CURRENT_TIMESTAMP;
	set @color = case when DATEPART(SECOND,@now) = 0
						then 'Rojo'
					else
						case when DATEPART(SECOND,@now) %2 = 0 
							then 'Azul'
							else 'Blanco'
						end
					end;
	set @stock = DATEPART(MILLISECOND, @now)

	if @cnt < 500
	begin
		set @marca = 1
	end
	else
	begin
		set @marca = 2
	end

	
	insert into Producto
		(MarcaId, TipoProductoId, Descripcion, Talla, Color, Precio, Stock)
	values 
		(1, 7, 'CAMISETA STYLE art '+REPLICATE('0', 4- len(@ind))+cast(@ind as varchar(5)), 'L', @color,
		floor(rand()*25 +21), @stock)

	set @cnt = @cnt + 1
end



select * from Marca

select * from TipoProducto

select * from Producto