 --select * from ARTICULOSj
--select * from CATEGORIAS
--select * from FAVORITOS
--select * from MARCAS
--select * from USERS

--CREATE PROCEDURE storedListar as
--SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.IdMarca, A.IdCategoria, A.Precio 
--FROM ARTICULOS A, MARCAS M, CATEGORIAS C 
--WHERE A.IdMarca = M.Id and A.IdCategoria = C.Id

--insert into ARTICULOS (Codigo, Nombre,Descripcion,IdMarca, IdCategoria, ImagenUrl,Precio)
--VALUES ('ABC', 'River', 'Plate', 3,1,'no hay', 3452.6457)

--delete from ARTICULOS where id = 6

--create procedure storedArticulo @id int as
--SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.IdMarca, A.IdCategoria, A.Precio 
--FROM ARTICULOS A, MARCAS M, CATEGORIAS C 
--WHERE A.IdMarca = M.Id and A.IdCategoria = C.Id and A.Id = @id

--INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (1,2)

--create procedure storedFavoritos @id int as
--SELECT F.Id, U.email Usuario,A.Nombre Articulo 
--FROM FAVORITOS F, USERS U, ARTICULOS A 
--WHERE U.Id = F.IdUser and A.Id = F.IdArticulo and U.Id = @id

--create procedure nuevoUsuario @email varchar, @pass varchar as
--INSERT INTO USERS (email, pass, admin) output inserted.id VALUES (@email, @pass, 0)