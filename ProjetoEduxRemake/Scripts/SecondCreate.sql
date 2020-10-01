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

CREATE TABLE [Categorias] (
    [IdCategoria] uniqueidentifier NOT NULL,
    [Tipo] nvarchar(max) NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([IdCategoria])
);

GO

CREATE TABLE [Dicas] (
    [IdDica] uniqueidentifier NOT NULL,
    [Texto] nvarchar(max) NULL,
    [Imagem] nvarchar(max) NULL,
    [IdUsuario] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Dicas] PRIMARY KEY ([IdDica]),
    CONSTRAINT [FK_Dicas_Usuarios_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario]) ON DELETE CASCADE
);

GO

CREATE TABLE [Instituicoes] (
    [IdInstituicao] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Logradouro] nvarchar(max) NULL,
    [Numero] nvarchar(max) NULL,
    [Complemento] nvarchar(max) NULL,
    [Bairro] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NULL,
    [UF] nvarchar(max) NULL,
    [CEP] nvarchar(max) NULL,
    CONSTRAINT [PK_Instituicoes] PRIMARY KEY ([IdInstituicao])
);

GO

CREATE TABLE [Objetivos] (
    [IdObjetivo] uniqueidentifier NOT NULL,
    [Descricao] nvarchar(max) NULL,
    [IdCategoria] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Objetivos] PRIMARY KEY ([IdObjetivo]),
    CONSTRAINT [FK_Objetivos_Categorias_IdCategoria] FOREIGN KEY ([IdCategoria]) REFERENCES [Categorias] ([IdCategoria]) ON DELETE CASCADE
);

GO

CREATE TABLE [Curtidas] (
    [IdCurtida] uniqueidentifier NOT NULL,
    [IdUsuario] uniqueidentifier NOT NULL,
    [IdDica] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Curtidas] PRIMARY KEY ([IdCurtida]),
    CONSTRAINT [FK_Curtidas_Dicas_IdDica] FOREIGN KEY ([IdDica]) REFERENCES [Dicas] ([IdDica]) ON DELETE CASCADE,
    CONSTRAINT [FK_Curtidas_Usuarios_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario]) ON DELETE CASCADE
);

GO

CREATE TABLE [Cursos] (
    [IdCurso] uniqueidentifier NOT NULL,
    [Titulo] nvarchar(max) NULL,
    [IdInstituicao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([IdCurso]),
    CONSTRAINT [FK_Cursos_Instituicoes_IdInstituicao] FOREIGN KEY ([IdInstituicao]) REFERENCES [Instituicoes] ([IdInstituicao]) ON DELETE CASCADE
);

GO

CREATE TABLE [Turmas] (
    [IdTurma] uniqueidentifier NOT NULL,
    [Descricao] nvarchar(max) NULL,
    [IdCurso] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Turmas] PRIMARY KEY ([IdTurma]),
    CONSTRAINT [FK_Turmas_Cursos_IdCurso] FOREIGN KEY ([IdCurso]) REFERENCES [Cursos] ([IdCurso]) ON DELETE CASCADE
);

GO

CREATE TABLE [AlunosTurmas] (
    [IdAlunoTurma] uniqueidentifier NOT NULL,
    [Matricula] nvarchar(max) NULL,
    [IdUsuario] uniqueidentifier NOT NULL,
    [IdTurma] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AlunosTurmas] PRIMARY KEY ([IdAlunoTurma]),
    CONSTRAINT [FK_AlunosTurmas_Turmas_IdTurma] FOREIGN KEY ([IdTurma]) REFERENCES [Turmas] ([IdTurma]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlunosTurmas_Usuarios_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProfessoresTurmas] (
    [IdProfessorTurma] uniqueidentifier NOT NULL,
    [Descricao] nvarchar(max) NULL,
    [IdUsuario] uniqueidentifier NOT NULL,
    [IdTurma] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ProfessoresTurmas] PRIMARY KEY ([IdProfessorTurma]),
    CONSTRAINT [FK_ProfessoresTurmas_Turmas_IdTurma] FOREIGN KEY ([IdTurma]) REFERENCES [Turmas] ([IdTurma]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProfessoresTurmas_Usuarios_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario]) ON DELETE CASCADE
);

GO

CREATE TABLE [ObjetivosAlunos] (
    [IdObjetivoAluno] uniqueidentifier NOT NULL,
    [Nota] decimal(18,2) NOT NULL,
    [DataAlcancado] datetime2 NOT NULL,
    [IdAlunoTurma] uniqueidentifier NOT NULL,
    [IdObjetivo] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ObjetivosAlunos] PRIMARY KEY ([IdObjetivoAluno]),
    CONSTRAINT [FK_ObjetivosAlunos_AlunosTurmas_IdAlunoTurma] FOREIGN KEY ([IdAlunoTurma]) REFERENCES [AlunosTurmas] ([IdAlunoTurma]) ON DELETE CASCADE,
    CONSTRAINT [FK_ObjetivosAlunos_Objetivos_IdObjetivo] FOREIGN KEY ([IdObjetivo]) REFERENCES [Objetivos] ([IdObjetivo]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AlunosTurmas_IdTurma] ON [AlunosTurmas] ([IdTurma]);

GO

CREATE INDEX [IX_AlunosTurmas_IdUsuario] ON [AlunosTurmas] ([IdUsuario]);

GO

CREATE INDEX [IX_Cursos_IdInstituicao] ON [Cursos] ([IdInstituicao]);

GO

CREATE INDEX [IX_Curtidas_IdDica] ON [Curtidas] ([IdDica]);

GO

CREATE INDEX [IX_Curtidas_IdUsuario] ON [Curtidas] ([IdUsuario]);

GO

CREATE INDEX [IX_Dicas_IdUsuario] ON [Dicas] ([IdUsuario]);

GO

CREATE INDEX [IX_Objetivos_IdCategoria] ON [Objetivos] ([IdCategoria]);

GO

CREATE INDEX [IX_ObjetivosAlunos_IdAlunoTurma] ON [ObjetivosAlunos] ([IdAlunoTurma]);

GO

CREATE INDEX [IX_ObjetivosAlunos_IdObjetivo] ON [ObjetivosAlunos] ([IdObjetivo]);

GO

CREATE INDEX [IX_ProfessoresTurmas_IdTurma] ON [ProfessoresTurmas] ([IdTurma]);

GO

CREATE INDEX [IX_ProfessoresTurmas_IdUsuario] ON [ProfessoresTurmas] ([IdUsuario]);

GO

CREATE INDEX [IX_Turmas_IdCurso] ON [Turmas] ([IdCurso]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200930110307_AlterTables', N'3.1.8');

GO

