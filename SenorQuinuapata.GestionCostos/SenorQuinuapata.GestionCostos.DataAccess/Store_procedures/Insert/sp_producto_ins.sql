USE [bd_sgcquinuapata]
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_edad]    Script Date: 04/09/2018 8:42:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Test: 
-- =============================================
create PROCEDURE [dbo].[sp_producto_ins] 	
(

@p_codigo varchar(10),
@p_nombre varchar(10)
)
AS
BEGIN

insert into producto(codigo,nombre) values (@p_codigo, @p_nombre)

	

END

