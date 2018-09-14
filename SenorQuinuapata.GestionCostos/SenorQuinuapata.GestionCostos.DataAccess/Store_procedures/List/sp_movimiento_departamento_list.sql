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
-- Test: exec sp_movimiento_departamento_list 1
-- =============================================
alter PROCEDURE [dbo].[sp_movimiento_departamento_list] 	
(
@p_id_departamento int
)
AS
BEGIN
set dateformat ymd
declare @v_hoy date = getdate()

	select d.nombre as departamento,md.*
	from Movimiento_departamento md
	inner join Departamento d
	on md.id_departamento=@p_id_departamento
	where d.id=@p_id_departamento
	order by md.fecha desc
END
