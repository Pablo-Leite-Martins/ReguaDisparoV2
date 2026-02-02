using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Infrastructure;

/// <summary>
/// DbContext para a base CLIENTEMAIS_CORPORATIVO
/// </summary>
public partial class CorporativoDbContext : DbContext
{
    public CorporativoDbContext(DbContextOptions<CorporativoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TB_CMCORP_APP> TB_CMCORP_APPs { get; set; }

    public virtual DbSet<TB_CMCORP_BANCO> TB_CMCORP_BANCOs { get; set; }

    public virtual DbSet<TB_CMCORP_CIDADE> TB_CMCORP_CIDADEs { get; set; }

    public virtual DbSet<TB_CMCORP_CONSULTA_UAUCLOUD> TB_CMCORP_CONSULTA_UAUCLOUDs { get; set; }

    public virtual DbSet<TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETRO> TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETROs { get; set; }

    public virtual DbSet<TB_CMCORP_ESTADO> TB_CMCORP_ESTADOs { get; set; }

    public virtual DbSet<TB_CMCORP_ETL> TB_CMCORP_ETLs { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_CONEXO> TB_CMCORP_ETL_CONEXOEs { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_CONSULTA> TB_CMCORP_ETL_CONSULTAs { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_ITERUP> TB_CMCORP_ETL_ITERUPs { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_LOG> TB_CMCORP_ETL_LOGs { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_LOG_USUARIO> TB_CMCORP_ETL_LOG_USUARIOs { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_TABELA> TB_CMCORP_ETL_TABELAs { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_TABELAS_20210414> TB_CMCORP_ETL_TABELAS_20210414s { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_TABELAS_20220221> TB_CMCORP_ETL_TABELAS_20220221s { get; set; }

    public virtual DbSet<TB_CMCORP_ETL_TABELAS_20230426> TB_CMCORP_ETL_TABELAS_20230426s { get; set; }

    public virtual DbSet<TB_CMCORP_FASE_IMPLANTACAO> TB_CMCORP_FASE_IMPLANTACAOs { get; set; }

    public virtual DbSet<TB_CMCORP_FERIADO> TB_CMCORP_FERIADOs { get; set; }

    public virtual DbSet<TB_CMCORP_INDICE> TB_CMCORP_INDICEs { get; set; }

    public virtual DbSet<TB_CMCORP_INTEGRACAO_BUG> TB_CMCORP_INTEGRACAO_BUGs { get; set; }

    public virtual DbSet<TB_CMCORP_INTEGRACAO_FACEBOOK> TB_CMCORP_INTEGRACAO_FACEBOOKs { get; set; }

    public virtual DbSet<TB_CMCORP_LOG_ERRO_APLICACAO> TB_CMCORP_LOG_ERRO_APLICACAOs { get; set; }

    public virtual DbSet<TB_CMCORP_MODULO_VARIAVEL_TEMPLATE> TB_CMCORP_MODULO_VARIAVEL_TEMPLATEs { get; set; }

    public virtual DbSet<TB_CMCORP_ORGANIZACAO> TB_CMCORP_ORGANIZACAOs { get; set; }

    public virtual DbSet<TB_CMCORP_ORGANIZACAO_FASE_IMPLANTACAO> TB_CMCORP_ORGANIZACAO_FASE_IMPLANTACAOs { get; set; }

    public virtual DbSet<TB_CMCORP_PAI> TB_CMCORP_PAIs { get; set; }

    public virtual DbSet<TB_CMCORP_PRODUTO_CAPY> TB_CMCORP_PRODUTO_CAPYs { get; set; }

    public virtual DbSet<TB_CMCORP_PROFISSAO> TB_CMCORP_PROFISSAOs { get; set; }

    public virtual DbSet<TB_CMCORP_REGIAO> TB_CMCORP_REGIAOs { get; set; }

    public virtual DbSet<TB_CMCORP_REGISTRO_UAU_WEB> TB_CMCORP_REGISTRO_UAU_WEBs { get; set; }

    public virtual DbSet<TB_CMCORP_REQUEST_API> TB_CMCORP_REQUEST_APIs { get; set; }

    public virtual DbSet<TB_CMCORP_SERVICO> TB_CMCORP_SERVICOs { get; set; }

    public virtual DbSet<TB_CMCORP_SPRINT> TB_CMCORP_SPRINTs { get; set; }

    public virtual DbSet<TB_CMCORP_SPRINT_ITEM> TB_CMCORP_SPRINT_ITEMs { get; set; }

    public virtual DbSet<TB_CMCORP_SPRINT_VISUALIZACAO> TB_CMCORP_SPRINT_VISUALIZACAOs { get; set; }

    public virtual DbSet<TB_CMCORP_TIPO_FERIADO> TB_CMCORP_TIPO_FERIADOs { get; set; }

    public virtual DbSet<TB_CMCORP_TIPO_INTEGRACAO> TB_CMCORP_TIPO_INTEGRACAOs { get; set; }

    public virtual DbSet<TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTO> TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTOs { get; set; }

    public virtual DbSet<TB_CMCORP_TIPO_TELEFONE> TB_CMCORP_TIPO_TELEFONEs { get; set; }

    public virtual DbSet<TB_CMCORP_VARIAVEL_TEMPLATE> TB_CMCORP_VARIAVEL_TEMPLATEs { get; set; }

    // ========================================
    // DbSets para Stored Procedures
    // ========================================
    
    public virtual DbSet<CMCORP_sp_BuscaConsultaPorNome_Result> CMCORP_sp_BuscaConsultaPorNome_Results { get; set; }
    public virtual DbSet<CMCORP_sp_BuscaEtlPorOrganizacao_Result> CMCORP_sp_BuscaEtlPorOrganizacao_Results { get; set; }
    public virtual DbSet<CMCORP_sp_BuscaProdutoCapysOrganizacao_Result> CMCORP_sp_BuscaProdutoCapysOrganizacao_Results { get; set; }
    public virtual DbSet<CMCORP_sp_BuscaServico_Result> CMCORP_sp_BuscaServico_Results { get; set; }
    public virtual DbSet<CMCORP_sp_ListaEtlLogUsuario_Result> CMCORP_sp_ListaEtlLogUsuario_Results { get; set; }
    public virtual DbSet<CMCORP_sp_ListaIntegracaoBug_Result> CMCORP_sp_ListaIntegracaoBug_Results { get; set; }
    public virtual DbSet<CMCORP_sp_ListaParametroConsultaUAUCloud_Result> CMCORP_sp_ListaParametroConsultaUAUCloud_Results { get; set; }
    public virtual DbSet<CMCORP_sp_ListaRotinaNomesClientesDiferentes_Result> CMCORP_sp_ListaRotinaNomesClientesDiferentes_Results { get; set; }
    public virtual DbSet<CMCORP_sp_ListaServico_Result> CMCORP_sp_ListaServico_Results { get; set; }
    public virtual DbSet<CMCORP_sp_ListaTipoIntegracao_Result> CMCORP_sp_ListaTipoIntegracao_Results { get; set; }
    public virtual DbSet<CMCORP_sp_ListaTipoIntegracaoAtributo_Result> CMCORP_sp_ListaTipoIntegracaoAtributo_Results { get; set; }
    public virtual DbSet<CMCORP_sp_GetConsultaUAUCloud_Result> CMCORP_sp_GetConsultaUAUCloud_Results { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<TB_CMCORP_APP>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMCORP_APP");

            entity.Property(e => e.DS_DESCRICAO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_IDENTIFICADOR_APP)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_ULTIMA_VERSAO_NAME_APPLE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_ULTIMA_VERSAO_NAME_CODE_APPLE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_ULTIMA_VERSAO_NAME_CODE_GOOGLE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_ULTIMA_VERSAO_NAME_GOOGLE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DT_ULTIMA_VERSAO_APPLE).HasColumnType("datetime");
            entity.Property(e => e.DT_ULTIMA_VERSAO_GOOGLE).HasColumnType("datetime");
            entity.Property(e => e.ID_APP).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TB_CMCORP_BANCO>(entity =>
        {
            entity.HasKey(e => e.ID_BANCO);

            entity.ToTable("TB_CMCORP_BANCO");

            entity.Property(e => e.ID_BANCO).ValueGeneratedNever();
            entity.Property(e => e.DS_BANCO)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_CIDADE>(entity =>
        {
            entity.HasKey(e => e.ID_CIDADE);

            entity.ToTable("TB_CMCORP_CIDADE");

            entity.Property(e => e.DS_CIDADE)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.ID_ESTADONavigation).WithMany(p => p.TB_CMCORP_CIDADEs)
                .HasForeignKey(d => d.ID_ESTADO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMCORP_CIDADE_TB_CMCORP_ESTADO");
        });

        modelBuilder.Entity<TB_CMCORP_CONSULTA_UAUCLOUD>(entity =>
        {
            entity.HasKey(e => e.ID_CONSULTA_UAUCLOUD);

            entity.ToTable("TB_CMCORP_CONSULTA_UAUCLOUD");

            entity.Property(e => e.DS_CONSULTA)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ID_CONSULTA_UAU)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETRO>(entity =>
        {
            entity.HasKey(e => e.ID_CONSULTA_UAUCLOUD_PARAMETRO);

            entity.ToTable("TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETRO");

            entity.Property(e => e.DS_CAMPO)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.DS_PARAMETRO)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_CONSULTA_UAUCLOUDNavigation).WithMany(p => p.TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETROs)
                .HasForeignKey(d => d.ID_CONSULTA_UAUCLOUD)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMCCORP_UAUCLOUD_PARAMETRO_TB_CMCORP_UAUCLOUD");
        });

        modelBuilder.Entity<TB_CMCORP_ESTADO>(entity =>
        {
            entity.HasKey(e => e.ID_ESTADO);

            entity.ToTable("TB_CMCORP_ESTADO");

            entity.Property(e => e.ID_ESTADO).ValueGeneratedNever();
            entity.Property(e => e.DS_ESTADO)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_SIGLA)
                .HasMaxLength(2)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.ID_PAISNavigation).WithMany(p => p.TB_CMCORP_ESTADOs)
                .HasForeignKey(d => d.ID_PAIS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMCORP_ESTADO_TB_CMCORP_PAIS");
        });

        modelBuilder.Entity<TB_CMCORP_ETL>(entity =>
        {
            entity.HasKey(e => e.ID_ETL);

            entity.ToTable("TB_CMCORP_ETL", tb => tb.HasTrigger("TR_TB_CMCORP_ETL_AFTER_UPDATE"));

            entity.Property(e => e.DS_ETL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DT_HORARIO_ULTIMA_EXECUCAO).HasColumnType("datetime");
            entity.Property(e => e.DT_HORA_EXECUCAO).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_ETL_CONEXO>(entity =>
        {
            entity.HasKey(e => e.ID_ETL_CONEXOES);

            entity.ToTable("TB_CMCORP_ETL_CONEXOES");

            entity.Property(e => e.DS_NOME_BANCO_DADOS)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_CONEXAO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_SERVIDOR)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_USUARIO)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_ETL_CONSULTA>(entity =>
        {
            entity.HasKey(e => e.ID_ETL_CONSULTAS);

            entity.ToTable("TB_CMCORP_ETL_CONSULTAS");

            entity.Property(e => e.DS_NOME_CONSULTA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_SQL_CONSULTA).IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_ETL_ITERUP>(entity =>
        {
            entity.HasKey(e => e.ID_ETL_ITERUP);

            entity.ToTable("TB_CMCORP_ETL_ITERUP");

            entity.Property(e => e.DS_SENHA)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.DS_USUARIO)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_ETLNavigation).WithMany(p => p.TB_CMCORP_ETL_ITERUPs)
                .HasForeignKey(d => d.ID_ETL)
                .HasConstraintName("FK_TB_CMCORP_ETL_TB_CMCORP_ETL_ITERUP");
        });

        modelBuilder.Entity<TB_CMCORP_ETL_LOG>(entity =>
        {
            entity.HasKey(e => e.ID_ETL_LOG);

            entity.ToTable("TB_CMCORP_ETL_LOG");

            entity.Property(e => e.DS_LOG_EXECUCAO).IsUnicode(false);
            entity.Property(e => e.DT_HORARIO).HasColumnType("datetime");
        });

        modelBuilder.Entity<TB_CMCORP_ETL_LOG_USUARIO>(entity =>
        {
            entity.HasKey(e => e.ID_ETL_LOG_USUARIO);

            entity.ToTable("TB_CMCORP_ETL_LOG_USUARIO");

            entity.Property(e => e.DT_EXECUCAO).HasColumnType("datetime");

            entity.HasOne(d => d.ID_ETLNavigation).WithMany(p => p.TB_CMCORP_ETL_LOG_USUARIOs)
                .HasForeignKey(d => d.ID_ETL)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMCORP_ETL_LOG_USUARIO_TB_CMCORP_ETL");
        });

        modelBuilder.Entity<TB_CMCORP_ETL_TABELA>(entity =>
        {
            entity.HasKey(e => e.ID_ETL_TABELAS);

            entity.ToTable("TB_CMCORP_ETL_TABELAS");

            entity.Property(e => e.DS_NOME_CONEXAO_DESTINO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_CONEXAO_ORIGEM)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_SQL_CONSULTA).IsUnicode(false);
            entity.Property(e => e.DS_TABELA)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_TIPO_CHAMADA)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_ETL_TABELAS_20210414>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMCORP_ETL_TABELAS_20210414");

            entity.Property(e => e.DS_NOME_CONEXAO_DESTINO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_CONEXAO_ORIGEM)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_SQL_CONSULTA).IsUnicode(false);
            entity.Property(e => e.DS_TABELA)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_TIPO_CHAMADA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ID_ETL_TABELAS).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TB_CMCORP_ETL_TABELAS_20220221>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMCORP_ETL_TABELAS_20220221");

            entity.Property(e => e.DS_NOME_CONEXAO_DESTINO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_CONEXAO_ORIGEM)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_SQL_CONSULTA).IsUnicode(false);
            entity.Property(e => e.DS_TABELA)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_TIPO_CHAMADA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ID_ETL_TABELAS).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TB_CMCORP_ETL_TABELAS_20230426>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMCORP_ETL_TABELAS_20230426");

            entity.Property(e => e.DS_NOME_CONEXAO_DESTINO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_CONEXAO_ORIGEM)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_SQL_CONSULTA).IsUnicode(false);
            entity.Property(e => e.DS_TABELA)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_TIPO_CHAMADA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ID_ETL_TABELAS).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TB_CMCORP_FASE_IMPLANTACAO>(entity =>
        {
            entity.HasKey(e => e.ID_FASE_IMPLANTACAO);

            entity.ToTable("TB_CMCORP_FASE_IMPLANTACAO");

            entity.Property(e => e.ID_FASE_IMPLANTACAO).ValueGeneratedNever();
            entity.Property(e => e.DS_FASE_IMPLANTACAO)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_FERIADO>(entity =>
        {
            entity.HasKey(e => e.ID_FERIADO);

            entity.ToTable("TB_CMCORP_FERIADO");

            entity.Property(e => e.DS_FERIADO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_INDICE>(entity =>
        {
            entity.HasKey(e => e.ID_INDICE);

            entity.ToTable("TB_CMCORP_INDICE");

            entity.Property(e => e.DS_INDICE)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_INTEGRACAO_BUG>(entity =>
        {
            entity.HasKey(e => e.ID_INTEGRACAO_BUG).HasName("PK_CMCORP_INTEGRACAO_BUG");

            entity.ToTable("TB_CMCORP_INTEGRACAO_BUG");

            entity.Property(e => e.DS_MENSAGEM).IsUnicode(false);
            entity.Property(e => e.DS_VERSAO).HasMaxLength(20);

            entity.HasOne(d => d.ID_TIPO_INTEGRACAONavigation).WithMany(p => p.TB_CMCORP_INTEGRACAO_BUGs)
                .HasForeignKey(d => d.ID_TIPO_INTEGRACAO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMCORP_INTEGRACAO_BUG_TB_CMCORP_TIPO_INTEGRACAO");
        });

        modelBuilder.Entity<TB_CMCORP_INTEGRACAO_FACEBOOK>(entity =>
        {
            entity.HasKey(e => e.ID_INTEGRACAO_FACEBOOK);

            entity.ToTable("TB_CMCORP_INTEGRACAO_FACEBOOK");

            entity.Property(e => e.DS_TOKEN).IsUnicode(false);
            entity.Property(e => e.DT_VALIDADE_TOKEN).HasColumnType("datetime");
            entity.Property(e => e.ID_FORMULARIO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ID_PAGINA)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_LOG_ERRO_APLICACAO>(entity =>
        {
            entity.HasKey(e => e.ID_ERRO);

            entity.ToTable("TB_CMCORP_LOG_ERRO_APLICACAO");

            entity.Property(e => e.DS_ERRO).IsUnicode(false);
            entity.Property(e => e.DS_INNER_EX).IsUnicode(false);
            entity.Property(e => e.DS_LOGIN).IsUnicode(false);
            entity.Property(e => e.DS_PAGINA).IsUnicode(false);
            entity.Property(e => e.DS_PILHA_EX).IsUnicode(false);
            entity.Property(e => e.DS_SOURCE).IsUnicode(false);
            entity.Property(e => e.DT_ERRO).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_MODULO_VARIAVEL_TEMPLATE>(entity =>
        {
            entity.HasKey(e => e.ID_MODULO_VARIAVEL_TEMPLATE).HasName("PK__TB_CMCOR__D599C67F6225902D");

            entity.ToTable("TB_CMCORP_MODULO_VARIAVEL_TEMPLATE");

            entity.HasOne(d => d.ID_VARIAVEL_TEMPLATENavigation).WithMany(p => p.TB_CMCORP_MODULO_VARIAVEL_TEMPLATEs)
                .HasForeignKey(d => d.ID_VARIAVEL_TEMPLATE)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CMCORP_VARIAVEL_TEMPLATE_MODULO_VARIAVEL_TEMPLATE");
        });

        modelBuilder.Entity<TB_CMCORP_ORGANIZACAO>(entity =>
        {
            entity.HasKey(e => e.ID_ORGANIZACAO);

            entity.ToTable("TB_CMCORP_ORGANIZACAO");

            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.COD_ERP_INTEGRACAO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_BAIRRO)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_COMPLEMENTO_ENDERECO)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_COR_LOGO)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_COR_SECUNDARIA_PORTALV2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_COR_TEXTO_PRIMARIA_PORTALV2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_COR_TEXTO_SECUNDARIA_PORTALV2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_DNS_PORTALV2)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.DS_EMAIL)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_EMAIL_SERVICO_SINC_ATENDIMENTO_UAU)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN_AD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN_GATEWAY)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN_UAU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_LOGRADOURO)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_NOME_FANTASIA)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_RAZAO_SOCIAL)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_REMETENTE_EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_AD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_GATEWAY)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_UAU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_SITE)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_SMTP_EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_TOKEN).IsUnicode(false);
            entity.Property(e => e.DS_TOKEN_CAPYS).IsUnicode(false);
            entity.Property(e => e.DS_URL_APP_APPLE_STORE).IsUnicode(false);
            entity.Property(e => e.DS_URL_APP_GOOGLE_PLAY).IsUnicode(false);
            entity.Property(e => e.DS_URL_CRM_CAPYS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_GALERIA1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_GALERIA2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_GALERIA3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_GATEWAY)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_IMAGEM_ASSISTENTE_VIRTUAL_PORTALV2)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_IMAGEM_PLANO_FUNDO_TELA_HOME_PORTALV2)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_IMAGEM_PLANO_FUNDO_TELA_LOGIN_PORTALV2)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_ACOMPANHAMENTOOBRA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_ANTECIPACAOPARCELAS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_ASSISTENCIATECNICA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_ATENDIMENTO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_ATUALIZACAOCADASTRAL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_BOLETOVENCIDO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_DOCUMENTOSCLIENTE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_DUVIDASFREQUENTES)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_EXTRATO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_EXTRATOIRRF)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_IMAGENS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_MEUIMOVEL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_SEGUNDAVIA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_LOGO_ULTIMASNOTICIAS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_WEBSERVICE)
                .HasMaxLength(200)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DS_URL_WEBSERVICE_CAPYS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_USUARIO_EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DT_EXPIRACAO_CONTRATO).HasColumnType("datetime");
            entity.Property(e => e.FL_ATIVO).HasDefaultValue(true);
            entity.Property(e => e.FL_CRM_INTEGRADO_ERP).HasDefaultValue(false);
            entity.Property(e => e.FL_PORTAL_EMBUTIDO_SITE).HasDefaultValue(false);
            entity.Property(e => e.FL_SERVICO_TRIAGEM_AUTOMATICA).HasDefaultValue(false);
            entity.Property(e => e.FL_SINC_PRECO_UAU).HasDefaultValue(false);
            entity.Property(e => e.ID_ONESIGNAL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ID_SERVICO_SINC_ATENDIMENTO_UAU)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.NOME_BANCO_CRM)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NR_CNPJ)
                .HasMaxLength(18)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NR_TELEFONE)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.ID_CIDADENavigation).WithMany(p => p.TB_CMCORP_ORGANIZACAOs)
                .HasForeignKey(d => d.ID_CIDADE)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMCORP_ORGANIZACAO_TB_CMCORP_CIDADE");
        });

        modelBuilder.Entity<TB_CMCORP_ORGANIZACAO_FASE_IMPLANTACAO>(entity =>
        {
            entity.HasKey(e => e.ID_ORGANIZACAO_FASE_IMPLANTACAO).HasName("PK_TB_CMCORP_ORGANIZCAO_FASE_IMPLANTACAO");

            entity.ToTable("TB_CMCORP_ORGANIZACAO_FASE_IMPLANTACAO");

            entity.Property(e => e.DS_EMAIL_RESPONSAVEL_NEGOCIO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_EMAIL_RESPONSAVEL_TI)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_FASE_IMPLANTACAO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_RESPONSAVEL_IMPLANTACAO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_RESPONSAVEL_NEGOCIO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_RESPONSAVEL_TI)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_PRODUTO_CAPYS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_RAZAO_SOCIAL)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DT_INICIO_PROJETO).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<TB_CMCORP_PAI>(entity =>
        {
            entity.HasKey(e => e.ID_PAIS).HasName("PK_TB_CM_PAIS");

            entity.ToTable("TB_CMCORP_PAIS");

            entity.Property(e => e.DS_PAIS)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<TB_CMCORP_PRODUTO_CAPY>(entity =>
        {
            entity.HasKey(e => e.ID_PRODUTO_CAPYS);

            entity.ToTable("TB_CMCORP_PRODUTO_CAPYS");

            entity.Property(e => e.ID_PRODUTO_CAPYS).ValueGeneratedNever();
            entity.Property(e => e.DS_PRODUTO_CAPYS)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_PROFISSAO>(entity =>
        {
            entity.HasKey(e => e.ID_PROFISSAO);

            entity.ToTable("TB_CMCORP_PROFISSAO");

            entity.Property(e => e.DS_PROFISSAO)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_REGIAO>(entity =>
        {
            entity.HasKey(e => e.ID_REGIAO).HasName("PK__TB_CMCOR__D8BAF6413429BB53");

            entity.ToTable("TB_CMCORP_REGIAO");

            entity.Property(e => e.DS_REGIAO)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_REGISTRO_UAU_WEB>(entity =>
        {
            entity.HasKey(e => e.ID_REG_UAU);

            entity.ToTable("TB_CMCORP_REGISTRO_UAU_WEB");

            entity.Property(e => e.DS_VERSAO_UAU_API)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DT_HORA_EXECUCAO_GERMODULOS).HasColumnType("datetime");
            entity.Property(e => e.DT_HORA_EXECUCAO_REG).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_REQUEST_API>(entity =>
        {
            entity.HasKey(e => e.ID_REQUEST_API);

            entity.ToTable("TB_CMCORP_REQUEST_API");

            entity.Property(e => e.DS_REQUEST_AUTHORITY)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DS_REQUEST_PATH)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DS_REQUEST_QUERY)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DS_REQUEST_URL)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DT_REQUEST).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.ID_ORGANIZACAONavigation).WithMany(p => p.TB_CMCORP_REQUEST_APIs)
                .HasForeignKey(d => d.ID_ORGANIZACAO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMCORP_REQUEST_API_TB_CMCORP_ORGANIZACAO");
        });

        modelBuilder.Entity<TB_CMCORP_SERVICO>(entity =>
        {
            entity.HasKey(e => e.ID_SERVICO);

            entity.ToTable("TB_CMCORP_SERVICO");

            entity.Property(e => e.DS_SERVICO)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_SPRINT>(entity =>
        {
            entity.HasKey(e => e.ID_SPRINT).HasName("PK__TB_CMCOR__6E0DC4327908F585");

            entity.ToTable("TB_CMCORP_SPRINT");

            entity.Property(e => e.DS_NOME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DT_CADASTRO).HasColumnType("datetime");
        });

        modelBuilder.Entity<TB_CMCORP_SPRINT_ITEM>(entity =>
        {
            entity.HasKey(e => e.ID_SPRINT_ITEM).HasName("PK__TB_CMCOR__1A065EE07CD98669");

            entity.ToTable("TB_CMCORP_SPRINT_ITEM");

            entity.Property(e => e.DS_DESCRICAO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_TIPO)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_SPRINTNavigation).WithMany(p => p.TB_CMCORP_SPRINT_ITEMs)
                .HasForeignKey(d => d.ID_SPRINT)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_CMCORP__ID_SP__7EC1CEDB");
        });

        modelBuilder.Entity<TB_CMCORP_SPRINT_VISUALIZACAO>(entity =>
        {
            entity.HasKey(e => e.ID_SPRINT_VISUALIZACAO).HasName("PK__TB_CMCOR__0C06A079019E3B86");

            entity.ToTable("TB_CMCORP_SPRINT_VISUALIZACAO");

            entity.Property(e => e.DS_OBSERVACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DT_CADASTRO).HasColumnType("datetime");

            entity.HasOne(d => d.ID_SPRINTNavigation).WithMany(p => p.TB_CMCORP_SPRINT_VISUALIZACAOs)
                .HasForeignKey(d => d.ID_SPRINT)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_CMCORP__ID_SP__038683F8");
        });

        modelBuilder.Entity<TB_CMCORP_TIPO_FERIADO>(entity =>
        {
            entity.HasKey(e => e.ID_TIPO_FERIADO);

            entity.ToTable("TB_CMCORP_TIPO_FERIADO");

            entity.Property(e => e.ID_TIPO_FERIADO).ValueGeneratedNever();
            entity.Property(e => e.DS_TIPO_FERIADO)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_TIPO_INTEGRACAO>(entity =>
        {
            entity.HasKey(e => e.ID_TIPO_INTEGRACAO).HasName("PK_TB_CMCORP_INTEGRACAO");

            entity.ToTable("TB_CMCORP_TIPO_INTEGRACAO");

            entity.Property(e => e.DS_OBSERVACAO).IsUnicode(false);
            entity.Property(e => e.DS_TIPO_INTEGRACAO)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTO>(entity =>
        {
            entity.HasKey(e => e.ID_TIPO_INTEGRACAO_ATRIBUTO);

            entity.ToTable("TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTO");

            entity.Property(e => e.DS_FORMATO)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("STRING");
            entity.Property(e => e.DS_TIPO_INTEGRACAO_ATRIBUTO)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_TIPO_INTEGRACAONavigation).WithMany(p => p.TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTOs)
                .HasForeignKey(d => d.ID_TIPO_INTEGRACAO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTO_TB_CMCORP_TIPO_INTEGRACAO");
        });

        modelBuilder.Entity<TB_CMCORP_TIPO_TELEFONE>(entity =>
        {
            entity.HasKey(e => e.ID_TIPO_TELEFONE);

            entity.ToTable("TB_CMCORP_TIPO_TELEFONE");

            entity.Property(e => e.ID_TIPO_TELEFONE).ValueGeneratedNever();
            entity.Property(e => e.DS_TIPO_TELEFONE)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMCORP_VARIAVEL_TEMPLATE>(entity =>
        {
            entity.HasKey(e => e.ID_VARIAVEL_TEMPLATE).HasName("PK__TB_CMCOR__DA6C822F5E54FF49");

            entity.ToTable("TB_CMCORP_VARIAVEL_TEMPLATE");

            entity.Property(e => e.DS_PARAMETRO_VARIAVEL_TEMPLATE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_TABLE_VARIAVEL_TEMPLATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_TIPO_PARAMETRO_VARIAVEL_TEMPLATE)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.DS_VARIAVEL_TEMPLATE)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        // ========================================
        // Configuração de Stored Procedures Results (Keyless Entities)
        // ========================================
        
        modelBuilder.Entity<CMCORP_sp_BuscaConsultaPorNome_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_BuscaEtlPorOrganizacao_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_BuscaProdutoCapysOrganizacao_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_BuscaServico_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_ListaEtlLogUsuario_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_ListaIntegracaoBug_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_ListaParametroConsultaUAUCloud_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_ListaRotinaNomesClientesDiferentes_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_ListaServico_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_ListaTipoIntegracao_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_ListaTipoIntegracaoAtributo_Result>().HasNoKey().ToView(null);
        modelBuilder.Entity<CMCORP_sp_GetConsultaUAUCloud_Result>().HasNoKey().ToView(null);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

// ========================================
// Classes de Resultado de Stored Procedures
// ========================================

public class CMCORP_sp_BuscaConsultaPorNome_Result
{
    public int? ID_CONSULTA { get; set; }
    public string? DS_NOME_CONSULTA { get; set; }
    public string? DS_SQL { get; set; }
    public string? ID_ORGANIZACAO { get; set; }
}

public class CMCORP_sp_BuscaEtlPorOrganizacao_Result
{
    public int ID_ETL { get; set; }
    public string? DS_ETL { get; set; }
    public string? ID_ORGANIZACAO { get; set; }
    public bool? FL_ATIVO { get; set; }
}

public class CMCORP_sp_BuscaProdutoCapysOrganizacao_Result
{
    public int ID_PRODUTO_CAPYS { get; set; }
    public string? DS_PRODUTO_CAPYS { get; set; }
    public string? ID_ORGANIZACAO { get; set; }
    public bool? FL_ATIVO { get; set; }
}

public class CMCORP_sp_BuscaServico_Result
{
    public int ID_SERVICO { get; set; }
    public string? DS_SERVICO { get; set; }
    public bool? FL_ATIVO { get; set; }
}

public class CMCORP_sp_ListaEtlLogUsuario_Result
{
    public int ID_ETL_LOG { get; set; }
    public int? ID_ETL { get; set; }
    public string? DS_ETL { get; set; }
    public string? ID_ORGANIZACAO { get; set; }
    public string? DS_MENSAGEM { get; set; }
    public DateTime? DT_LOG { get; set; }
    public string? DS_USUARIO { get; set; }
}

public class CMCORP_sp_ListaIntegracaoBug_Result
{
    public int ID_INTEGRACAO_BUG { get; set; }
    public int? ID_TIPO_INTEGRACAO { get; set; }
    public string? DS_TIPO_INTEGRACAO { get; set; }
    public string? DS_VERSAO { get; set; }
    public string? DS_MENSAGEM { get; set; }
}

public class CMCORP_sp_ListaParametroConsultaUAUCloud_Result
{
    public int ID_PARAMETRO { get; set; }
    public int? ID_CONSULTA_UAU_CLOUD { get; set; }
    public string? DS_PARAMETRO { get; set; }
    public string? DS_TIPO { get; set; }
}

public class CMCORP_sp_ListaRotinaNomesClientesDiferentes_Result
{
    public string? ID_ORGANIZACAO { get; set; }
    public string? DS_NOME_FANTASIA { get; set; }
    public int? TOTAL_DIVERGENCIAS { get; set; }
}

public class CMCORP_sp_ListaServico_Result
{
    public int ID_SERVICO { get; set; }
    public string? DS_SERVICO { get; set; }
    public bool? FL_ATIVO { get; set; }
}

public class CMCORP_sp_ListaTipoIntegracao_Result
{
    public int ID_TIPO_INTEGRACAO { get; set; }
    public string? DS_TIPO_INTEGRACAO { get; set; }
    public string? DS_OBSERVACAO { get; set; }
}

public class CMCORP_sp_ListaTipoIntegracaoAtributo_Result
{
    public int ID_TIPO_INTEGRACAO_ATRIBUTO { get; set; }
    public int? ID_TIPO_INTEGRACAO { get; set; }
    public string? DS_ATRIBUTO { get; set; }
    public string? DS_TIPO { get; set; }
}

public class CMCORP_sp_GetConsultaUAUCloud_Result
{
    public int ID_CONSULTA_UAU_CLOUD { get; set; }
    public string? ID_ORGANIZACAO { get; set; }
    public string? DS_CONSULTA { get; set; }
    public string? DS_SQL { get; set; }
}

