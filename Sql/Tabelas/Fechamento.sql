CREATE TABLE [dbo].[Fechamento]
(
	[Id_Fechamento]		INT				NOT NULL IDENTITY(1,1),
	[ValorTotal]		DECIMAL(10,2)	NOT NULL,
	CONSTRAINT [PK_Fechamento]	PRIMARY KEY ([Id_Fechamento]),
)
