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
    [CEP] int NOT NULL,
    [Complemento] int NOT NULL,
    [Senha_hash] varbinary(max) NULL,
    [Senha_salt] varbinary(max) NULL,
    [Numero_est] int NOT NULL,
    [UsuarioId] bigint NOT NULL,
    [TipoUsuario] int NOT NULL,
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
VALUES (CAST(1 AS bigint), N'500.230.222-32', N'Agatha.linhares@gmail.com', NULL, N'Agatha', 0x055E734EBCF5491D17B3E219A331DDE8DB2F70017A1DC4E33E863E29ACDE68927974B17B99BCC8DFA8B737CF198C5111CFB7B07FBA056E65CBE0EBDD8C23BF5D, 0xE8C87A180A6015650C4F30ABC35A4172A43B31DB0C4C67A5E950B2AB24C08646C82673DE28D318AC281347C890BBD0C5C876ADD5935EB2986D18A835E4063B12FCD2E6F794EE468275135154E147A8BDBD103B0B8249F43AD7E959D942E58E310DFD5D91C9667290671E2160006FC825A19251F4308AC84A1F3D792A22A838DA, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Email', N'Foto', N'Nome', N'Senha_hash', N'Senha_salt', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CEP', N'Cnpj', N'Complemento', N'Email', N'Endereco', N'Nome_est', N'Numero_est', N'Senha_hash', N'Senha_salt', N'TipoUsuario', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Estabelecimentos]'))
    SET IDENTITY_INSERT [Estabelecimentos] ON;
INSERT INTO [Estabelecimentos] ([Id], [CEP], [Cnpj], [Complemento], [Email], [Endereco], [Nome_est], [Numero_est], [Senha_hash], [Senha_salt], [TipoUsuario], [UsuarioId])
VALUES (CAST(1 AS bigint), 2223001, N'12123456/0001-12', 4, NULL, N'Av. Ramiz Galvão', N'CutsCuts', 1082, NULL, NULL, 1, CAST(1 AS bigint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CEP', N'Cnpj', N'Complemento', N'Email', N'Endereco', N'Nome_est', N'Numero_est', N'Senha_hash', N'Senha_salt', N'TipoUsuario', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Estabelecimentos]'))
    SET IDENTITY_INSERT [Estabelecimentos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'EstabelecimentoId', N'FormasDePagamento', N'Hora_ag', N'Local_ag', N'UsuarioId', N'data_ag') AND [object_id] = OBJECT_ID(N'[Agendamentos]'))
    SET IDENTITY_INSERT [Agendamentos] ON;
INSERT INTO [Agendamentos] ([Id], [EstabelecimentoId], [FormasDePagamento], [Hora_ag], [Local_ag], [UsuarioId], [data_ag])
VALUES (CAST(1 AS bigint), CAST(1 AS bigint), 0, '2023-12-05T23:48:11.8103767-03:00', N'Av. Ramiz Galvão', CAST(1 AS bigint), '2023-12-05T00:00:00.0000000-03:00');
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
VALUES (N'20231206024812_InitialCreate', N'7.0.7');
GO

COMMIT;
GO

