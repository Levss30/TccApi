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
    [Cpf] bigint NOT NULL,
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
    [Nome_est] nvarchar(max) NULL,
    [Endereco] nvarchar(max) NULL,
    [CEP] int NOT NULL,
    [Complemento] int NOT NULL,
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
VALUES (CAST(1 AS bigint), CAST(50023022232 AS bigint), N'Agatha.linhares@gmail.com', NULL, N'Agatha', 0x0AE23C6EB8518A0C8A9DD39208748AA4108C02C6C9B08540B62CD0C7B20925C236FF4856248C06286D4CECFD3DF31B15CAC9C3BBBC01EBFBF323C53D00A87479, 0xA5E5A5935630B4D39D5678A736FD6D42A425BE2CEE6A1860E7F3C67F7181683440FBD9EE5A86EEF7C26C28BBB6DFCB16F7D60D1FC254DC1CAD2C497CBE94AE33A71E4844968C0E42725B55529C67196B6DDAB210C586347D5D54FB13560AF4C0E6C4A7659B50ECF0CD6BFC2CE8DB69FB24B7BFAB17838BF63607FF168541F598, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Email', N'Foto', N'Nome', N'Senha_hash', N'Senha_salt', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CEP', N'Cnpj', N'Complemento', N'Endereco', N'Nome_est', N'Numero_est', N'TipoUsuario', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Estabelecimentos]'))
    SET IDENTITY_INSERT [Estabelecimentos] ON;
INSERT INTO [Estabelecimentos] ([Id], [CEP], [Cnpj], [Complemento], [Endereco], [Nome_est], [Numero_est], [TipoUsuario], [UsuarioId])
VALUES (CAST(1 AS bigint), 2223001, N'12123456/0001-12', 4, N'Av. Ramiz Galvão', N'CutsCuts', 1082, 1, CAST(1 AS bigint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CEP', N'Cnpj', N'Complemento', N'Endereco', N'Nome_est', N'Numero_est', N'TipoUsuario', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Estabelecimentos]'))
    SET IDENTITY_INSERT [Estabelecimentos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'EstabelecimentoId', N'FormasDePagamento', N'Hora_ag', N'Local_ag', N'UsuarioId', N'data_ag') AND [object_id] = OBJECT_ID(N'[Agendamentos]'))
    SET IDENTITY_INSERT [Agendamentos] ON;
INSERT INTO [Agendamentos] ([Id], [EstabelecimentoId], [FormasDePagamento], [Hora_ag], [Local_ag], [UsuarioId], [data_ag])
VALUES (CAST(1 AS bigint), CAST(1 AS bigint), 0, '2023-11-08T18:39:20.2990880-03:00', N'Av. Ramiz Galvão', CAST(1 AS bigint), '2023-11-08T00:00:00.0000000-03:00');
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
VALUES (N'20231108213920_InitialCreate', N'7.0.7');
GO

COMMIT;
GO

