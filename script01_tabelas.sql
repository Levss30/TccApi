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
VALUES (CAST(1 AS bigint), CAST(50023022232 AS bigint), N'Agatha.linhares@gmail.com', NULL, N'Agatha', 0x6313C583AFA9E7394E746F77FD248B4B0C6EBF3A51B70B7FD2C2DDE265AB51ADCB70835E87381A198A5F3788ACEFB7D5B225886F2321A73FB02BD573707EBEE0, 0x991220352038D6B0BE20E2BF19A1BC1E16DE6F7174C03C7D1D903C6926FAFCA85F18527D0D467AD1DD666BFB95CD20A68B3A287BDCA1C95D81ACD4C81169166CCBB80E801A34001CA7354DF07748B1ACB9519751513FEE8C680E80AEE587DAC882E1999942D97CCC9A446B4D99F95A0A898E05AD81E1E7EF34D20D7D96B41CF8, 0);
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
VALUES (CAST(1 AS bigint), CAST(1 AS bigint), 0, '2023-12-05T23:25:42.0963410-03:00', N'Av. Ramiz Galvão', CAST(1 AS bigint), '2023-12-05T00:00:00.0000000-03:00');
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
VALUES (N'20231206022542_InitialCreate', N'7.0.7');
GO

COMMIT;
GO

