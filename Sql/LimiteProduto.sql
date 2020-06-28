CREATE TABLE [dbo].[LimiteProduto]
(
	[Id_LimiteProduto]		INT			NOT NULL	IDENTITY(1,1),
	[Produto_Id]			INT			NOT NULL,
	[QuantidadeLimite]		INT			NOT NULL,
	CONSTRAINT [PK_Limite_Produto]		PRIMARY KEY ([Id_LimiteProduto]),
	CONSTRAINT [FK_Limite_Produto_Produto]	FOREIGN KEY ([Produto_Id]) REFERENCES [dbo].[Produto] ([Id_Produto]) ON DELETE CASCADE ON UPDATE CASCADE
)
