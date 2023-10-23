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
    [Nome] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Foto] varbinary(max) NULL,
    [Cpf] nvarchar(max) NULL,
    [Preferencia] int NOT NULL,
    [TipoUsuario] int NOT NULL,
    [Senha_hash] varbinary(max) NULL,
    [Senha_salt] varbinary(max) NULL,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Estacionamentos] (
    [Id] bigint NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Url] nvarchar(max) NULL,
    [UsuarioId] bigint NOT NULL,
    CONSTRAINT [PK_Estacionamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Estacionamentos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Vagas] (
    [Id] bigint NOT NULL IDENTITY,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    [Secao] nvarchar(max) NULL,
    [Disponibilidade] int NOT NULL,
    [Andar] int NOT NULL,
    [Numero] float NOT NULL,
    [Preferencia] int NOT NULL,
    [EstacionamentoId] bigint NOT NULL,
    CONSTRAINT [PK_Vagas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vagas_Estacionamentos_EstacionamentoId] FOREIGN KEY ([EstacionamentoId]) REFERENCES [Estacionamentos] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Sensores] (
    [Id] bigint NOT NULL IDENTITY,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    [VagaId] bigint NOT NULL,
    CONSTRAINT [PK_Sensores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sensores_Vagas_VagaId] FOREIGN KEY ([VagaId]) REFERENCES [Vagas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UsuarioVagas] (
    [CodData] bigint NOT NULL,
    [CodVaga] bigint NOT NULL,
    [CodUsuario] bigint NOT NULL,
    [Forma_pagamento] int NOT NULL,
    [Data] datetime2 NOT NULL,
    [Receptor_pagamento] nvarchar(max) NULL,
    [Emissor_pagamento] nvarchar(max) NULL,
    [Ocupacao_inicial] datetime2 NOT NULL,
    [Ocupacao_final] datetime2 NOT NULL,
    [VagaId] bigint NULL,
    [UsuarioId] bigint NULL,
    CONSTRAINT [PK_UsuarioVagas] PRIMARY KEY ([CodData], [CodUsuario], [CodVaga]),
    CONSTRAINT [FK_UsuarioVagas_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]),
    CONSTRAINT [FK_UsuarioVagas_Vagas_VagaId] FOREIGN KEY ([VagaId]) REFERENCES [Vagas] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CodData', N'CodUsuario', N'CodVaga', N'Data', N'Emissor_pagamento', N'Forma_pagamento', N'Ocupacao_final', N'Ocupacao_inicial', N'Receptor_pagamento', N'UsuarioId', N'VagaId') AND [object_id] = OBJECT_ID(N'[UsuarioVagas]'))
    SET IDENTITY_INSERT [UsuarioVagas] ON;
INSERT INTO [UsuarioVagas] ([CodData], [CodUsuario], [CodVaga], [Data], [Emissor_pagamento], [Forma_pagamento], [Ocupacao_final], [Ocupacao_inicial], [Receptor_pagamento], [UsuarioId], [VagaId])
VALUES (CAST(1 AS bigint), CAST(1 AS bigint), CAST(1 AS bigint), '2023-10-23T09:07:23.1493314-03:00', N'Anilmar', 1, '2023-10-23T09:07:23.1493324-03:00', '2023-10-23T09:07:23.1493324-03:00', N'Auto Park', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CodData', N'CodUsuario', N'CodVaga', N'Data', N'Emissor_pagamento', N'Forma_pagamento', N'Ocupacao_final', N'Ocupacao_inicial', N'Receptor_pagamento', N'UsuarioId', N'VagaId') AND [object_id] = OBJECT_ID(N'[UsuarioVagas]'))
    SET IDENTITY_INSERT [UsuarioVagas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Email', N'Foto', N'Latitude', N'Longitude', N'Nome', N'Preferencia', N'Senha_hash', N'Senha_salt', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Cpf], [Email], [Foto], [Latitude], [Longitude], [Nome], [Preferencia], [Senha_hash], [Senha_salt], [TipoUsuario])
VALUES (CAST(1 AS bigint), N'12345678910', N'anilmar@gmail.com', NULL, NULL, NULL, N'anilmar', 1, 0xD31F406DE187A8D553DFFF1B74CCC5817CED5289BB47C034D76A7A84E13763DFF4FAAA3F98D32870C9DC106B4508FABF6300CBED17D8019D37DF44AC11A5C36B, 0xC5DD5D98E2D6A38B620605EC8FEA72816F90DA30EFB7794BBA6D669B0D59BF860F6A511623AA6CEED1F8EDBCF73EB51E87FCFDE85EE7345199D54238B0E89DC487B20643C1004305E28D78ED2A842BB6056ECB9913BEEC0CDE5AA79E8D91B555AC890452A4289E21A313BA149FF1C9CFB47BD1C10B7E4F8E565015053FFB2212, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'Email', N'Foto', N'Latitude', N'Longitude', N'Nome', N'Preferencia', N'Senha_hash', N'Senha_salt', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'Url', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Estacionamentos]'))
    SET IDENTITY_INSERT [Estacionamentos] ON;
INSERT INTO [Estacionamentos] ([Id], [Nome], [Url], [UsuarioId])
VALUES (CAST(1 AS bigint), N'Auto Park', NULL, CAST(1 AS bigint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'Url', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Estacionamentos]'))
    SET IDENTITY_INSERT [Estacionamentos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Andar', N'Disponibilidade', N'EstacionamentoId', N'Latitude', N'Longitude', N'Numero', N'Preferencia', N'Secao') AND [object_id] = OBJECT_ID(N'[Vagas]'))
    SET IDENTITY_INSERT [Vagas] ON;
INSERT INTO [Vagas] ([Id], [Andar], [Disponibilidade], [EstacionamentoId], [Latitude], [Longitude], [Numero], [Preferencia], [Secao])
VALUES (CAST(1 AS bigint), 1, 1, CAST(1 AS bigint), N'68.4908', N'-61.2506', 1.0E0, 1, N'A1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Andar', N'Disponibilidade', N'EstacionamentoId', N'Latitude', N'Longitude', N'Numero', N'Preferencia', N'Secao') AND [object_id] = OBJECT_ID(N'[Vagas]'))
    SET IDENTITY_INSERT [Vagas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Latitude', N'Longitude', N'VagaId') AND [object_id] = OBJECT_ID(N'[Sensores]'))
    SET IDENTITY_INSERT [Sensores] ON;
INSERT INTO [Sensores] ([Id], [Latitude], [Longitude], [VagaId])
VALUES (CAST(1 AS bigint), N'68.4908', N'-61.2506', CAST(1 AS bigint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Latitude', N'Longitude', N'VagaId') AND [object_id] = OBJECT_ID(N'[Sensores]'))
    SET IDENTITY_INSERT [Sensores] OFF;
GO

CREATE INDEX [IX_Estacionamentos_UsuarioId] ON [Estacionamentos] ([UsuarioId]);
GO

CREATE UNIQUE INDEX [IX_Sensores_VagaId] ON [Sensores] ([VagaId]);
GO

CREATE INDEX [IX_UsuarioVagas_UsuarioId] ON [UsuarioVagas] ([UsuarioId]);
GO

CREATE INDEX [IX_UsuarioVagas_VagaId] ON [UsuarioVagas] ([VagaId]);
GO

CREATE INDEX [IX_Vagas_EstacionamentoId] ON [Vagas] ([EstacionamentoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231023120723_InitialCreate', N'7.0.12');
GO

COMMIT;
GO

