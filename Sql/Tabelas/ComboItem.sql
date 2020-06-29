CREATE TABLE [dbo].[ComboItem]
(
	[Id_ComboItem]			INT			NOT NULL	IDENTITY(1,1),
	[Combo_Id]				INT			NOT NULL,
	[Produto_Id]			INT			NOT NULL,
	[Quantidade]			INT			NOT NULL,
	CONSTRAINT [PK_Combo_Item]		PRIMARY KEY ([Id_ComboItem]),
	CONSTRAINT [FK_Combo_Item_Produto]	FOREIGN KEY ([Produto_Id]) REFERENCES [dbo].[Produto] ([Id_Produto]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_Combo_Item_Combo]	FOREIGN KEY ([Combo_Id]) REFERENCES [dbo].[Combo] ([Id_Combo]) ON DELETE CASCADE ON UPDATE CASCADE
)
