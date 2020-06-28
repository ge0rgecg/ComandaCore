CREATE TABLE [dbo].[ComboDesconto]
(
	[Id_ComboDesconto]			INT			NOT NULL	IDENTITY(1,1),
	[Combo_Id]					INT			NOT NULL,
	[Produto_Id]				INT			NOT NULL,
	[Porcentagem]				INT			NOT NULL,
	CONSTRAINT [PK_Combo_Desconto]		PRIMARY KEY ([Id_ComboDesconto]),
	CONSTRAINT [FK_Combo_Desconto_Produto]	FOREIGN KEY ([Produto_Id]) REFERENCES [dbo].[Produto] ([Id_Produto]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_Combo_Desconto_Combo]	FOREIGN KEY ([Combo_Id]) REFERENCES [dbo].[Combo] ([Id_Combo]) ON DELETE CASCADE ON UPDATE CASCADE
)
