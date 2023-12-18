--select * from ARTICULOS
--select * from CATEGORIAS
--select * from FAVORITOS
--select * from MARCAS
--select * from USERS

CREATE PROCEDURE storedListar as
SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.IdMarca, A.IdCategoria, A.Precio 
FROM ARTICULOS A, MARCAS M, CATEGORIAS C 
WHERE A.IdMarca = M.Id and A.IdCategoria = C.Id