USE [bd_sgcquinuapata]
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_edad]    Script Date: 02/09/2018 19:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Test: exec sp_actualizar_edad
-- =============================================
ALTER PROCEDURE [dbo].[sp_actualizar_edad] 	
AS
BEGIN
set dateformat ymd
declare @v_hoy date = getdate()

	--select * from Movimiento_departamento;	

	update Movimiento_departamento
	set 	
	edad=DATEDIFF(day,@v_hoy,fecha) 
	,avance=ROUND((((DATEDIFF(day,@v_hoy,fecha)+1)*100/85+75)),0)
	where ingreso>0
END
