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
create PROCEDURE [dbo].[sp_ingreso_departamento_ins] 	
(
@p_id_movimiento_departamento int,
@p_salida int,
@p_saldo int,
@p_id_sgte_departamento int,
@p_genero varchar(7)
)
AS
BEGIN
set dateformat ymd
declare @v_hoy date = getdate()

	update movimiento_departamento
	set salida=@p_salida,saldo=@p_saldo
	where id=@p_id_movimiento_departamento

	insert into movimiento_departamento(fecha,edad,genero,id_departamento,ingreso,salida,saldo,avance,q_equivalente,cu_md,cu_mod,cu_cif,cu_total,costo_total)
	values(@v_hoy,0,@p_genero,@p_id_sgte_departamento,@p_salida,0,0,0,0,0,0,0,0,0)

END

