IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Usuarios] (
    [Id] bigint NOT NULL IDENTITY,
    [Cpf] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Foto] varbinary(max) NULL,
    [TipoUsuario] int NOT NULL,
    [Senha_hash] varbinary(max) NULL,
    [Senha_salt] varbinary(max) NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Estabelecimentos] (
    [Id] bigint NOT NULL IDENTITY,
    [Cnpj] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Nome_est] nvarchar(max) NULL,
    [Endereco] nvarchar(max) NULL,
    [Telefone] int NOT NULL,
    [CEP] nvarchar(max) NULL,
    [Complemento] int NOT NULL,
    [Senha_hash] varbinary(max) NULL,
    [Senha_salt] varbinary(max) NULL,
    [Numero_est] int NOT NULL,
    [UsuarioId] bigint NOT NULL,
    CONSTRAINT [PK_Estabelecimentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Estabelecimentos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id])
);
GO

CREATE TABLE [Agendamentos] (
    [Id] bigint NOT NULL IDENTITY,
    [Hora_ag] datetime2 NOT NULL,
    [Local_ag] nvarchar(max) NULL,
    [data_ag] datetime2 NOT NULL,
    [UsuarioId] bigint NOT NULL,
    [EstabelecimentoId] bigint NOT NULL,
    [FormasDePagamento] int NOT NULL,
    CONSTRAINT [PK_Agendamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Agendamentos_Estabelecimentos_EstabelecimentoId] FOREIGN KEY ([EstabelecimentoId]) REFERENCES [Estabelecimentos] ([Id]),
    CONSTRAINT [FK_Agendamentos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Email', N'Foto', N'Nome', N'Senha_hash', N'Senha_salt', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Cpf], [Email], [Foto], [Nome], [Senha_hash], [Senha_salt], [TipoUsuario])
VALUES (CAST(1 AS bigint), N'500.230.222-32', N'Agatha.linhares@gmail.com', NULL, N'Agatha', 0xB8E1F30159167A56D1619491C6F0E1982419DCA03225C0484D4F095CBBDE6005E7514A1C3EACA870D1C1BD98449875FA9E15B27EA88C4FA608A5B2DD249B024C, 0x25FF3EF82A9F4831A5CB02C3A1E6B1A3A7D93CAD07FE307C68B03085ACCE22FC304A0BC17CEC38BC30DEFBE1091782DF649CED9CBA159F776741C753C8C2A7D8F7ABB69C0E7BB793188EAB631E45C17B2013600998F20CE0308FBB812814D82FA30744FD20030A63BD668A2B0592C7AD724A10E83636F4EC50BA6E949D88E791, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Email', N'Foto', N'Nome', N'Senha_hash', N'Senha_salt', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CEP', N'Cnpj', N'Complemento', N'Email', N'Endereco', N'Nome_est', N'Numero_est', N'Senha_hash', N'Senha_salt', N'Telefone', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Estabelecimentos]'))
    SET IDENTITY_INSERT [Estabelecimentos] ON;
INSERT INTO [Estabelecimentos] ([Id], [CEP], [Cnpj], [Complemento], [Email], [Endereco], [Nome_est], [Numero_est], [Senha_hash], [Senha_salt], [Telefone], [UsuarioId])
VALUES (CAST(1 AS bigint), N'02223001', N'12123456/0001-12', 4, NULL, N'Av. Ramiz Galvão', N'CutsCuts', 1082, NULL, NULL, 934958271, CAST(1 AS bigint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CEP', N'Cnpj', N'Complemento', N'Email', N'Endereco', N'Nome_est', N'Numero_est', N'Senha_hash', N'Senha_salt', N'Telefone', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Estabelecimentos]'))
    SET IDENTITY_INSERT [Estabelecimentos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'EstabelecimentoId', N'FormasDePagamento', N'Hora_ag', N'Local_ag', N'UsuarioId', N'data_ag') AND [object_id] = OBJECT_ID(N'[Agendamentos]'))
    SET IDENTITY_INSERT [Agendamentos] ON;
INSERT INTO [Agendamentos] ([Id], [EstabelecimentoId], [FormasDePagamento], [Hora_ag], [Local_ag], [UsuarioId], [data_ag])
VALUES (CAST(1 AS bigint), CAST(1 AS bigint), 0, '2023-12-06T03:27:28.4597530-03:00', N'Av. Ramiz Galvão', CAST(1 AS bigint), '2023-12-06T00:00:00.0000000-03:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'EstabelecimentoId', N'FormasDePagamento', N'Hora_ag', N'Local_ag', N'UsuarioId', N'data_ag') AND [object_id] = OBJECT_ID(N'[Agendamentos]'))
    SET IDENTITY_INSERT [Agendamentos] OFF;
GO

CREATE INDEX [IX_Agendamentos_EstabelecimentoId] ON [Agendamentos] ([EstabelecimentoId]);
GO

CREATE INDEX [IX_Agendamentos_UsuarioId] ON [Agendamentos] ([UsuarioId]);
GO

CREATE INDEX [IX_Estabelecimentos_UsuarioId] ON [Estabelecimentos] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231206062728_InitialCreate', N'7.0.7');
GO

COMMIT;
GO

