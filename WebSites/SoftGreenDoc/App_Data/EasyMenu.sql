CREATE TABLE [EasyMenu] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[ParentId] [int] NULL ,
	[InnerHtml] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Level] [int] NULL 
) ON [PRIMARY]
GO


