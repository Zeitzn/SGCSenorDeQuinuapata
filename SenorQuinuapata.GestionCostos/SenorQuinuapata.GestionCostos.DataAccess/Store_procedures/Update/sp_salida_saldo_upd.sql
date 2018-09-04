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
create PROCEDURE [dbo].[sp_salida_saldo_upd] 	
(
@p_id_movimiento_departamento int,
@p_salida int,
@p_saldo int
)
AS
BEGIN
set dateformat ymd
declare @v_hoy date = getdate()

	update movimiento_departamento
	set salida=@p_salida,saldo=@p_saldo
	where id=@p_id_movimiento_departamento
END

