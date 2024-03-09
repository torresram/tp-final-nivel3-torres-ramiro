--select * from ARTICULOS
--select * from CATEGORIAS
--select * from FAVORITOS
--select * from MARCAS
--select * from USERS

--SELECT Id, email,pass,nombre,apellido,urlImagenPerfil, admin FROM USERS

--select IdUser, IdArticulo from FAVORITOS where IdUser=3

--UPDATE USERS SET urlImagenPerfil = '' WHERE Id = 1
--UPDATE USERS SET pass = 'pedro' WHERE Id = 4
--UPDATE USERS SET nombre = '', apellido = '' WHERE id = 1

--CREATE PROCEDURE storedListar as
--SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.IdMarca, A.IdCategoria, A.Precio 
--FROM ARTICULOS A, MARCAS M, CATEGORIAS C 
--WHERE A.IdMarca = M.Id and A.IdCategoria = C.Id

--insert into ARTICULOS (Codigo, Nombre,Descripcion,IdMarca, IdCategoria, ImagenUrl,Precio)
--VALUES ('ABC', 'River', 'Plate', 3,1,'no hay', 3452.6457)

--delete from USERS where id = 7

--create procedure storedArticulo @id int as
--SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.IdMarca, A.IdCategoria, A.Precio 
--FROM ARTICULOS A, MARCAS M, CATEGORIAS C 
--WHERE A.IdMarca = M.Id and A.IdCategoria = C.Id and A.Id = @id

--INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (1,2)

--CREATE PROCEDURE storedAgregar 
--@codigo varchar(50), @nombre varchar (50), @descripcion varchar (150), @idMarca int, @idCategoria int,
--@imagenUrl varchar(1000), @precio money as
--INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) 
--VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)

--CREATE PROCEDURE storedModificar
--@id int,@codigo varchar(50), @nombre varchar (50), @desc varchar (150), @idMarca int, @idCategoria int,
--@imagenUrl varchar(1000), @precio money as
--UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio
--WHERE Id = @id

--alter procedure nuevoUsuario @email varchar(100), @pass varchar(20) as
--INSERT INTO USERS (email, pass, admin) output inserted.id VALUES (@email, @pass, 0)

--SELECT Id, email, pass,nombre,apellido, urlImagenPerfil, admin FROM USERS WHERE email= '' and pass = ''

--CREATE PROCEDURE storedFavs @id int as
--SELECT F.IdUser, F.IdArticulo,A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl,A.Precio,C.Descripcion Categoria, M.Descripcion Marca
--from FAVORITOS F, ARTICULOS A, MARCAS M, CATEGORIAS C
--WHERE F.IdArticulo = A.Id and M.Id = A.IdMarca and A.IdCategoria = C.Id and F.IdUser = @id

--INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (1,3)
--DELETE FROM FAVORITOS WHERE IdUser = 1 and IdArticulo = 3