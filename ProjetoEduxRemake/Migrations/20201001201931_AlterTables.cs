using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEduxRemake.Migrations
{
    public partial class AlterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    IdInstituicao = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    IdPerfil = table.Column<Guid>(nullable: false),
                    Permissao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Objetivos",
                columns: table => new
                {
                    IdObjetivo = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdCategoria = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetivos", x => x.IdObjetivo);
                    table.ForeignKey(
                        name: "FK_Objetivos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    IdInstituicao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK_Cursos_Instituicoes_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicoes",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataUltimoAcesso = table.Column<DateTime>(nullable: false),
                    IdPerfil = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfis_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfis",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    IdTurma = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdCurso = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.IdTurma);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dicas",
                columns: table => new
                {
                    IdDica = table.Column<Guid>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    UrlImagem = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dicas", x => x.IdDica);
                    table.ForeignKey(
                        name: "FK_Dicas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosTurmas",
                columns: table => new
                {
                    IdAlunoTurma = table.Column<Guid>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    IdTurma = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosTurmas", x => x.IdAlunoTurma);
                    table.ForeignKey(
                        name: "FK_AlunosTurmas_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosTurmas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessoresTurmas",
                columns: table => new
                {
                    IdProfessorTurma = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    IdTurma = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoresTurmas", x => x.IdProfessorTurma);
                    table.ForeignKey(
                        name: "FK_ProfessoresTurmas_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessoresTurmas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curtidas",
                columns: table => new
                {
                    IdCurtida = table.Column<Guid>(nullable: false),
                    IdDica = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtidas", x => x.IdCurtida);
                    table.ForeignKey(
                        name: "FK_Curtidas_Dicas_IdDica",
                        column: x => x.IdDica,
                        principalTable: "Dicas",
                        principalColumn: "IdDica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curtidas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "ObjetivosAlunos",
                columns: table => new
                {
                    IdObjetivoAluno = table.Column<Guid>(nullable: false),
                    Nota = table.Column<decimal>(nullable: false),
                    DataAlcancado = table.Column<DateTime>(nullable: false),
                    IdAlunoTurma = table.Column<Guid>(nullable: false),
                    IdObjetivo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosAlunos", x => x.IdObjetivoAluno);
                    table.ForeignKey(
                        name: "FK_ObjetivosAlunos_AlunosTurmas_IdAlunoTurma",
                        column: x => x.IdAlunoTurma,
                        principalTable: "AlunosTurmas",
                        principalColumn: "IdAlunoTurma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjetivosAlunos_Objetivos_IdObjetivo",
                        column: x => x.IdObjetivo,
                        principalTable: "Objetivos",
                        principalColumn: "IdObjetivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosTurmas_IdTurma",
                table: "AlunosTurmas",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosTurmas_IdUsuario",
                table: "AlunosTurmas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdInstituicao",
                table: "Cursos",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_IdDica",
                table: "Curtidas",
                column: "IdDica");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_IdUsuario",
                table: "Curtidas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Dicas_IdUsuario",
                table: "Dicas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivos_IdCategoria",
                table: "Objetivos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosAlunos_IdAlunoTurma",
                table: "ObjetivosAlunos",
                column: "IdAlunoTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosAlunos_IdObjetivo",
                table: "ObjetivosAlunos",
                column: "IdObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresTurmas_IdTurma",
                table: "ProfessoresTurmas",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresTurmas_IdUsuario",
                table: "ProfessoresTurmas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_IdCurso",
                table: "Turmas",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curtidas");

            migrationBuilder.DropTable(
                name: "ObjetivosAlunos");

            migrationBuilder.DropTable(
                name: "ProfessoresTurmas");

            migrationBuilder.DropTable(
                name: "Dicas");

            migrationBuilder.DropTable(
                name: "AlunosTurmas");

            migrationBuilder.DropTable(
                name: "Objetivos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Instituicoes");
        }
    }
}
