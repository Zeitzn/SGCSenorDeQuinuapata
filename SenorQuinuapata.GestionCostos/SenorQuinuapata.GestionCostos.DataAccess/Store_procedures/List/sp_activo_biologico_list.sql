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
alter PROCEDURE [dbo].[sp_activo_biologico_list] 	

AS
BEGIN
set dateformat ymd
declare @v_hoy date = getdate()

	select * from Activo_biologico
END
