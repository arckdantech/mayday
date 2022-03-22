using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Domain.Models.Relacional;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ArckDan.MayDay.Repositorio.Context
{
    public class MayDayContext : DbContext
    {
        #region atributos

        readonly IConfiguration _configuration;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe MayDayContext
        /// </summary>
        public MayDayContext() { }

        /// <summary>
        /// construtor da classe MayDayContext
        /// </summary>
        /// <param name="configuration">configuração de acesso aos recursos do sistema</param>
        public MayDayContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region métodos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MayDayDev"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // tabela de relacionamento entre formulário e campos
            modelBuilder.Entity<FormularioCampoModel>(
                entity => 
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdFormulario).HasColumnName("ID_FORMULARIO");
                    entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_FORMULARIO_CAMPO");
                }
            );

            // tabela de cadastro no sistema
            modelBuilder.Entity<CadastroSistemaModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdFormulario).HasColumnName("ID_FORMULARIO");
                    entity.Property(e => e.IdLogin).HasColumnName("ID_LOGIN");
                    entity.Property(e => e.DadosUsuario).HasColumnName("DADOS_USUARIO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_CADASTRO_SISTEMA");
                }
            );

            // tabela de credenciais do jwt
            modelBuilder.Entity<TokenModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.UserId).HasColumnName("CHAVE_ACESSO");
                    entity.Property(e => e.Senha).HasColumnName("SENHA");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_TOKEN");
                }
            );

            // tabela de login
            modelBuilder.Entity<LoginModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
                    entity.Property(e => e.ChaveUsuario).HasColumnName("CHAVE_USUARIO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_LOGIN")
                        .HasMany(p => p.Senha)
                        .WithOne()
                        .HasForeignKey(k => k.IdLogin)
                        .OnDelete(DeleteBehavior.NoAction);
                    entity.ToTable("TB_MAYDAY_LOGIN")
                        .HasOne(p => p.Cadastro)
                        .WithOne()
                        .HasForeignKey<CadastroSistemaModel>(k => k.IdLogin);
                }
            );

            // tabela de campos
            modelBuilder.Entity<CampoModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.Nome).HasColumnName("NOME");
                    entity.Property(e => e.NomeTecnico).HasColumnName("NOME_TECNICO");
                    entity.Property(e => e.Tipo).HasColumnName("TIPO");
                    entity.Property(e => e.Tamanho).HasColumnName("TAMANHO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_CAMPO");
                }
            );

            // tabela de perfis
            modelBuilder.Entity<PerfilModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.Nome).HasColumnName("NOME");
                    entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");
                    entity.Property(e => e.Ativo).HasColumnName("ATIVO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_PERFIL")
                        .HasMany(p => p.Formulario)
                        .WithOne()
                        .HasForeignKey(p => p.IdPerfil)
                        .OnDelete(DeleteBehavior.NoAction);
                }
            );

            // tabela de usuários
            modelBuilder.Entity<UsuarioModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.Nome).HasColumnName("NOME");
                    entity.Property(e => e.Ativo).HasColumnName("ATIVO");
                    entity.Property(e => e.CPF).HasColumnName("CPF");
                    entity.Property(e => e.Nascimento).HasColumnName("DATA_NASCIMENTO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_USUARIO")
                        .HasMany(p => p.Login)
                        .WithOne()
                        .HasForeignKey(p => p.IdUsuario)
                        .OnDelete(DeleteBehavior.NoAction);
                    entity.ToTable("TB_MAYDAY_USUARIO")
                        .HasMany(p => p.Endereco)
                        .WithOne()
                        .HasForeignKey(p => p.IdUsuario)
                        .OnDelete(DeleteBehavior.NoAction);
                }
            );

            // tabela de senhas
            modelBuilder.Entity<SenhaModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdLogin).HasColumnName("ID_LOGIN");
                    entity.Property(e => e.Chave).HasColumnName("CHAVE");
                    entity.Property(e => e.Expiracao).HasColumnName("DATA_EXPIRACAO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_SENHA");
                }
            );

            // tabela de endereços
            modelBuilder.Entity<EnderecoModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
                    entity.Property(e => e.CEP).HasColumnName("CEP");
                    entity.Property(e => e.Logradouro).HasColumnName("LOGRADOURO");
                    entity.Property(e => e.Numero).HasColumnName("NUMERO");
                    entity.Property(e => e.Complemento).HasColumnName("COMPLEMENTO");
                    entity.Property(e => e.Bairro).HasColumnName("BAIRRO");
                    entity.Property(e => e.Cidade).HasColumnName("CIDADE");
                    entity.Property(e => e.UF).HasColumnName("UF");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_ENDERECO");
                }
            );

            // tabela de formulários
            modelBuilder.Entity<FormularioModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL");
                    entity.Property(e => e.Nome).HasColumnName("NOME");
                    entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_FORMULARIO");
                }
            );
        }

        #endregion

        #region tabelas

        public DbSet<PerfilModel> TB_MAYDAY_PERFIL { get; set; }
        public DbSet<LoginModel> TB_MAYDAY_LOGIN { get; set; }
        public DbSet<TokenModel> TB_MAYDAY_TOKEN { get; set; }
        public DbSet<CampoModel> TB_MAYDAY_CAMPO { get; set; }
        public DbSet<UsuarioModel> TB_MAYDAY_USUARIO { get; set; }
        public DbSet<SenhaModel> TB_MAYDAY_SENHA { get; set; }
        public DbSet<EnderecoModel> TB_MAYDAY_ENDERECO { get; set; }
        public DbSet<FormularioCampoModel> TB_MAYDAY_FORMULARIO_CAMPO { get; set; }
        public DbSet<CadastroSistemaModel> TB_MAYDAY_CADASTRO_SISTEMA { get; set; }
        public DbSet<FormularioModel> TB_MAYDAY_FORMULARIO { get; set; }

        #endregion

        #region propriedades

        public SqlConnection SqlConn => new SqlConnection(_configuration.GetConnectionString("MayDayDev"));

        #endregion
    }
}