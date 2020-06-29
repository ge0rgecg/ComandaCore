CREATE TABLE [dbo].[ControleComanda]
(
	[Id_ControleComanda]	INT					NOT NULL  IDENTITY(1,1),
	[NumeroComanda]			INT					NOT NULL,
	[Produto_Id]			INT					NOT NULL,
	[Fechamento_Id]			INT					NULL,
	[Desconto]				DECIMAL(10,2)		NOT NULL	DEFAULT 0, 
    CONSTRAINT [PK_Controle_Comanda]	PRIMARY KEY ([Id_ControleComanda]),
	CONSTRAINT [FK_Controle_Comanda_Produto]	FOREIGN KEY ([Produto_Id])	REFERENCES [dbo].[Produto] ([Id_Produto]) ON DELETE NO ACTION ON UPDATE CASCADE,	
	CONSTRAINT [FK_Controle_Comanda_Fechamento]	FOREIGN KEY ([Fechamento_Id])	REFERENCES [dbo].[Fechamento] ([Id_Fechamento]) ON DELETE NO ACTION ON UPDATE CASCADE	
)