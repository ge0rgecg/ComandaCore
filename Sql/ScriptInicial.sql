INSERT INTO LimiteProduto (Produto_Id, QuantidadeLimite)
SELECT p.Id_Produto, 3 FROM produto p WHERE p.nome = 'Suco' 
AND NOT EXISTS ( SELECT * FROM limiteproduto WHERE produto_id = p.Id_Produto)
GO


INSERT INTO Combo (nome)
SELECT ('Cerveja com suco') 
WHERE NOT EXISTS (SELECT * FROM COMBO WHERE NOME = 'Cerveja com suco')

INSERT INTO Combo (nome)
SELECT ('Conhaque com cerveja')
WHERE NOT EXISTS (SELECT * FROM COMBO WHERE NOME = 'Conhaque com cerveja')

declare @idCerveja int
declare @idSuco int
declare @idConhaque int
declare @idAgua int

select @idCerveja = Id_produto from produto where nome = 'Cerveja'
select @idConhaque = Id_produto from produto where nome = 'Conhaque'
select @idSuco = Id_produto from produto where nome = 'Suco'
select @idAgua = Id_produto from produto where nome = 'Água'

INSERT INTO COMBOITEM (Combo_Id, Produto_Id, Quantidade)
select c.id_combo, @idCerveja, 1 from combo c where c.nome = 'Cerveja com suco'
and not exists (select * from comboitem ci where ci.Combo_Id = c.Id_Combo and ci.Produto_Id = @idCerveja )

INSERT INTO COMBOITEM (Combo_Id, Produto_Id, Quantidade)
select c.id_combo, @idSuco, 1 from combo c where c.nome = 'Cerveja com suco'
and not exists (select * from comboitem ci where ci.Combo_Id = c.Id_Combo and ci.Produto_Id = @idSuco )

INSERT INTO ComboDesconto(Combo_Id, Produto_Id, Porcentagem)
select c.id_combo, @idCerveja, 40 from combo c where c.nome = 'Cerveja com suco'
and not exists (select * from ComboDesconto ci where ci.Combo_Id = c.Id_Combo and ci.Produto_Id = @idCerveja )

INSERT INTO COMBOITEM (Combo_Id, Produto_Id, Quantidade)
select c.id_combo, @idCerveja, 2 from combo c where c.nome = 'Conhaque com cerveja'
and not exists (select * from comboitem ci where ci.Combo_Id = c.Id_Combo and ci.Produto_Id = @idCerveja )

INSERT INTO COMBOITEM (Combo_Id, Produto_Id, Quantidade)
select c.id_combo, @idConhaque, 3 from combo c where c.nome = 'Conhaque com cerveja'
and not exists (select * from comboitem ci where ci.Combo_Id = c.Id_Combo and ci.Produto_Id = @idConhaque )

INSERT INTO COMBOITEM (Combo_Id, Produto_Id, Quantidade)
select c.id_combo, @idAgua, 1 from combo c where c.nome = 'Conhaque com cerveja'
and not exists (select * from comboitem ci where ci.Combo_Id = c.Id_Combo and ci.Produto_Id = @idAgua )

INSERT INTO ComboDesconto(Combo_Id, Produto_Id, Porcentagem)
select c.id_combo, @idAgua, 100 from combo c where c.nome = 'Conhaque com cerveja'
and not exists (select * from ComboDesconto ci where ci.Combo_Id = c.Id_Combo and ci.Produto_Id = @idAgua )


GO