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
-- Test: exec sp_persona_list
-- =============================================
alter PROCEDURE [dbo].[sp_persona_list] 	

AS
BEGIN

	select p.*,c.descripcion as cargo
	from Persona p
	inner join Cargo c
	on p.id_cargo=c.id

END
