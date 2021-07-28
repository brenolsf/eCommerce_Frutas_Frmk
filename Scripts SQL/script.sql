cREATE TABLE [dbo].[Frutas](
  FrutasId int IDENTITY(3,1) NOT NULL,
  Nome nvarchar(80) NOT NULL,
  Foto nvarchar(500) NOT NULL,
  Descricao nvarchar(100) NOT NULL,
  Valor decimal(12,2) NOT NULL,
  PRIMARY KEY (FrutasId)
);
CREATE TABLE [dbo].[Estoque]
(
  EstoqueId int IDENTITY(3,1) NOT NULL,
  FrutasId int NOT NULL,
  QtdeAtual nvarchar(100) NOT NULL,
  PRIMARY KEY (EstoqueId),
  FOREIGN KEY (FrutasId) REFERENCES Frutas(FrutasId)
);

CREATE TABLE [dbo].[Carrinho]
(
  CarrinhoId int IDENTITY(3,1) NOT NULL,
  CodCarrinho int Not Null,
  FrutasId int NOT NULL,
  QtdeSolicitada int NOT NULL,
  PRIMARY KEY (CodCarrinho),
  FOREIGN KEY (FrutasId) REFERENCES Frutas(FrutasId)
);

CREATE TABLE [dbo].[Status]
(
  StatusId int IDENTITY(3,1) NOT NULL,
  CodStatus int Not null,
  DescStatus nvarchar(50) NOT NULL
  PRIMARY KEY (CodStatus)  
);

CREATE TABLE [dbo].[Pedido]
(
  PedidoId int IDENTITY(3,1) NOT NULL,
  CodPedido int Not null,
  CodCarrinho int NOT NULL,  
  CodStatus int NOT NULL,
  DataPedido Date,
  PRIMARY KEY (CodPedido),  
  FOREIGN KEY (CodStatus) REFERENCES Status(CodStatus),
  FOREIGN KEY (CodCarrinho) REFERENCES Carrinho(CodCarrinho)
);


insert into Frutas values ('Pêssego', 'https://www.pngfind.com/pngs/m/303-3039927_249526565016212-r1024x1024-imagenes-de-frutas-durazno-hd-png.png', 'Fruta amarela com um caroço no meio', 5);
insert into Frutas values ('Pêra', 'https://www.pngfind.com/pngs/m/380-3809071_imagem-de-frutas-pera-6-png-still-life.png', 'Fruta esverdeada', 10);
insert into Frutas values ('Laranja', 'https://www.pngfind.com/pngs/m/190-1908555_imagem-de-frutas-laranja-8-png-transparent-png.png', 'Fruta alaranjada', 15);
insert into Frutas values ('Avocado', 'https://www.pngfind.com/pngs/m/461-4610355_organic-avocados-bag-imagenes-de-fruta-de-aguacate.png', 'Fruta verde', 20);

insert into Estoque values (3,2000);
insert into Estoque values (4,1000);
insert into Estoque values (5,3000);
insert into Estoque values (6,500);

select * from Frutas inner join Estoque on Frutas.FrutasId = Estoque.FrutasId;            