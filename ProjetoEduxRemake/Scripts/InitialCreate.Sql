IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Perfis] (
    [IdPerfil] uniqueidentifier NOT NULL,
    [Permissao] nvarchar(max) NULL,
    CONSTRAINT [PK_Perfis] PRIMARY KEY ([IdPerfil])
);

GO

CREATE TABLE [Usuarios] (
    [IdUsuario] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Senha] nvarchar(max) NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataUltimoAcesso] datetime2 NOT NULL,
    [IdPerfil] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([IdUsuario]),
    CONSTRAINT [FK_Usuarios_Perfis_IdPerfil] FOREIGN KEY ([IdPerfil]) REFERENCES [Perfis] ([IdPerfil]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Usuarios_IdPerfil] ON [Usuarios] ([IdPerfil]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200930044109_InitialCreate', N'3.1.8');

GO

