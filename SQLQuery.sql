--select * from ARTICULOS
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
