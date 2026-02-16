using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReguaDisparo.Domain.Entities.ControleAcesso;

namespace ReguaDisparo.Infrastructure;

/// <summary>
/// DbContext para a base CLIENTEMAIS_CONTROLE_ACESSO
/// </summary>
public partial class ControleAcessoDbContext : DbContext
{
    public ControleAcessoDbContext(DbContextOptions<ControleAcessoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TB_CMC_ALCADA_CONFIGURACAO> TB_CMC_ALCADA_CONFIGURACAOs { get; set; }

    public virtual DbSet<TB_CMC_ALCADA> TB_CMC_ALCADAs { get; set; }

    public virtual DbSet<TB_CMC_CARGO> TB_CMC_CARGOs { get; set; }

    public virtual DbSet<TB_CMC_CARGO_USUARIO> TB_CMC_CARGO_USUARIOs { get; set; }

    public virtual DbSet<TB_CMC_CONFIRMACAO_CADASTRAL> TB_CMC_CONFIRMACAO_CADASTRALs { get; set; }

    public virtual DbSet<TB_CMC_FUNCAO> TB_CMC_FUNCAOs { get; set; }

    public virtual DbSet<TB_CMC_GRUPO> TB_CMC_GRUPOs { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_20220805> TB_CMC_GRUPO_20220805s { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_20230119> TB_CMC_GRUPO_20230119s { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_FUNCAO> TB_CMC_GRUPO_FUNCAOs { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_FUNCAO_20230119> TB_CMC_GRUPO_FUNCAO_20230119s { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_MODULO> TB_CMC_GRUPO_MODULOs { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_TELA> TB_CMC_GRUPO_TELAs { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_TELA_LOG> TB_CMC_GRUPO_TELA_LOGs { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_USUARIO> TB_CMC_GRUPO_USUARIOs { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_USUARIO_20220204> TB_CMC_GRUPO_USUARIO_20220204s { get; set; }

    public virtual DbSet<TB_CMC_GRUPO_USUARIO_20241029> TB_CMC_GRUPO_USUARIO_20241029s { get; set; }

    public virtual DbSet<TB_CMC_MODULO> TB_CMC_MODULOs { get; set; }

    public virtual DbSet<TB_CMC_MODULO_PRODUCAO> TB_CMC_MODULO_PRODUCAOs { get; set; }

    public virtual DbSet<TB_CMC_MUDANCA_SENHA> TB_CMC_MUDANCA_SENHAs { get; set; }

    public virtual DbSet<TB_CMC_PERFIL_USUARIO> TB_CMC_PERFIL_USUARIOs { get; set; }

    public virtual DbSet<TB_CMC_SISTEMA> TB_CMC_SISTEMAs { get; set; }

    public virtual DbSet<TB_CMC_TELA> TB_CMC_TELAs { get; set; }

    public virtual DbSet<TB_CMC_USUARIO> TB_CMC_USUARIOs { get; set; }

    public virtual DbSet<TB_CMC_USUARIO_20210823> TB_CMC_USUARIO_20210823s { get; set; }

    public virtual DbSet<TB_CMC_USUARIO_ORGANIZACAO> TB_CMC_USUARIO_ORGANIZACAOs { get; set; }

    public virtual DbSet<TB_CMC_USUARIO_PREFERENCIA> TB_CMC_USUARIO_PREFERENCIAs { get; set; }

    public virtual DbSet<TB_CMC_USUARIO_TELEFONE> TB_CMC_USUARIO_TELEFONEs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<TB_CMC_ALCADA_CONFIGURACAO>(entity =>
        {
            entity.HasKey(e => e.ID_ALCADA_CONFIGURACAO);

            entity.ToTable("TB_CMC_ALCADA_CONFIGURACAO");

            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.VL_ALCADA_MAXIMO).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VL_ALCADA_MINIMO).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ID_ALCADANavigation).WithMany(p => p.TB_CMC_ALCADA_CONFIGURACAOs)
                .HasForeignKey(d => d.ID_ALCADA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_ALCADA_CONFIGURACAO_TB_CMC_ALCADA");

            entity.HasOne(d => d.ID_USUARIONavigation).WithMany(p => p.TB_CMC_ALCADA_CONFIGURACAOs)
                .HasForeignKey(d => d.ID_USUARIO)
                .HasConstraintName("FK_TB_CMC_ALCADA_CONFIGURACAO_TB_CMC_USUARIO");
        });

        modelBuilder.Entity<TB_CMC_ALCADA>(entity =>
        {
            entity.HasKey(e => e.ID_ALCADA);

            entity.ToTable("TB_CMC_ALCADA");

            entity.Property(e => e.DS_ALCADA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_CATEGORIA_ALCADA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_OBSERVACAO)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_SISTEMANavigation).WithMany(p => p.TB_CMC_ALCADa)
                .HasForeignKey(d => d.ID_SISTEMA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_ALCADA_TB_CMC_SISTEMA");
        });

        modelBuilder.Entity<TB_CMC_CARGO>(entity =>
        {
            entity.HasKey(e => e.ID_CARGO);

            entity.ToTable("TB_CMC_CARGO");

            entity.Property(e => e.DS_CARGO)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.ID_CHAVE_ERP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_CARGO_USUARIO>(entity =>
        {
            entity.HasKey(e => e.ID_CARGO_USUARIO);

            entity.ToTable("TB_CMC_CARGO_USUARIO");

            entity.HasIndex(e => new { e.ID_CARGO, e.ID_USUARIO, e.ID_ORGANIZACAO }, "UC_CMC_CARGO_USUARIO").IsUnique();

            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_CARGONavigation).WithMany(p => p.TB_CMC_CARGO_USUARIOs)
                .HasForeignKey(d => d.ID_CARGO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_CARGO_USUARIO_TB_CMC_CARGO");

            entity.HasOne(d => d.ID_USUARIONavigation).WithMany(p => p.TB_CMC_CARGO_USUARIOs)
                .HasForeignKey(d => d.ID_USUARIO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_CARGO_USUARIO_TB_CMC_USUARIO");
        });

        modelBuilder.Entity<TB_CMC_CONFIRMACAO_CADASTRAL>(entity =>
        {
            entity.HasKey(e => e.ID_CONFIRMACAO_CADASTRAL);

            entity.ToTable("TB_CMC_CONFIRMACAO_CADASTRAL");

            entity.Property(e => e.DS_CPF)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_CRECI)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DT_ATIVACAO).HasColumnType("datetime");
            entity.Property(e => e.FL_ATIVO).HasDefaultValue(false);
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NR_TELEFONE)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_RESPONSAVEL_ATIVACAONavigation).WithMany(p => p.TB_CMC_CONFIRMACAO_CADASTRALs)
                .HasForeignKey(d => d.ID_RESPONSAVEL_ATIVACAO)
                .HasConstraintName("FK_TB_CMC_CONFIRMACAO_CADASTRAL_TB_CMC_USUARIO");
        });

        modelBuilder.Entity<TB_CMC_FUNCAO>(entity =>
        {
            entity.HasKey(e => e.ID_FUNCAO);

            entity.ToTable("TB_CMC_FUNCAO");

            entity.Property(e => e.ID_FUNCAO).ValueGeneratedNever();
            entity.Property(e => e.DS_FUNCAO)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NM_FUNCAO)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_SISTEMANavigation).WithMany(p => p.TB_CMC_FUNCAOs)
                .HasForeignKey(d => d.ID_SISTEMA)
                .HasConstraintName("FK__TB_CMC_FU__ID_SI__59C55456");
        });

        modelBuilder.Entity<TB_CMC_GRUPO>(entity =>
        {
            entity.HasKey(e => e.ID_GRUPO);

            entity.ToTable("TB_CMC_GRUPO");

            entity.Property(e => e.DS_GRUPO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_SISTEMANavigation).WithMany(p => p.TB_CMC_GRUPOs)
                .HasForeignKey(d => d.ID_SISTEMA)
                .HasConstraintName("FK_TB_CMC_GRUPO_TB_CMC_SISTEMA");
        });

        modelBuilder.Entity<TB_CMC_GRUPO_20220805>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMC_GRUPO_20220805");

            entity.Property(e => e.DS_GRUPO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ID_GRUPO).ValueGeneratedOnAdd();
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_GRUPO_20230119>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMC_GRUPO_20230119");

            entity.Property(e => e.DS_GRUPO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ID_GRUPO).ValueGeneratedOnAdd();
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_GRUPO_FUNCAO>(entity =>
        {
            entity.HasKey(e => e.ID_GRUPO_FUNCAO);

            entity.ToTable("TB_CMC_GRUPO_FUNCAO");

            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_FUNCAONavigation).WithMany(p => p.TB_CMC_GRUPO_FUNCAOs)
                .HasForeignKey(d => d.ID_FUNCAO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_GRUPO_FUNCAO_TB_CMC_FUNCAO");

            entity.HasOne(d => d.ID_GRUPONavigation).WithMany(p => p.TB_CMC_GRUPO_FUNCAOs)
                .HasForeignKey(d => d.ID_GRUPO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_GRUPO_FUNCAO_TB_CMC_GRUPO");
        });

        modelBuilder.Entity<TB_CMC_GRUPO_FUNCAO_20230119>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMC_GRUPO_FUNCAO_20230119");

            entity.Property(e => e.ID_GRUPO_FUNCAO).ValueGeneratedOnAdd();
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_GRUPO_MODULO>(entity =>
        {
            entity.HasKey(e => e.ID_GRUPO_SISTEMA).HasName("PK__TB_CMC_G__894D6A0A18B6AB08");

            entity.ToTable("TB_CMC_GRUPO_MODULO");

            entity.HasOne(d => d.ID_GRUPONavigation).WithMany(p => p.TB_CMC_GRUPO_MODULOs)
                .HasForeignKey(d => d.ID_GRUPO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRUPO");

            entity.HasOne(d => d.ID_MODULONavigation).WithMany(p => p.TB_CMC_GRUPO_MODULOs)
                .HasForeignKey(d => d.ID_MODULO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_MODULO_TB_CMC_GRUPO_MODULO");
        });

        modelBuilder.Entity<TB_CMC_GRUPO_TELA>(entity =>
        {
            entity.HasKey(e => e.ID_GRUPO_TELA);

            entity.ToTable("TB_CMC_GRUPO_TELA", tb => tb.HasTrigger("ACTIVITY_ON_GRUPO_TELA"));

            entity.HasIndex(e => e.ID_GRUPO, "Missing_IXNC_TB_CMC_GRUPO_TELA_ID_GRUPO_4CA12").HasFillFactor(80);

            entity.HasIndex(e => e.ID_GRUPO, "Missing_IXNC_TB_CMC_GRUPO_TELA_ID_GRUPO_52023").HasFillFactor(80);

            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_GRUPONavigation).WithMany(p => p.TB_CMC_GRUPO_TELAs)
                .HasForeignKey(d => d.ID_GRUPO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_GRUPO_TELA_TB_CMC_GRUPO");

            entity.HasOne(d => d.ID_TELANavigation).WithMany(p => p.TB_CMC_GRUPO_TELAs)
                .HasForeignKey(d => d.ID_TELA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_GRUPO_TELA_TB_CMC_TELA");
        });

        modelBuilder.Entity<TB_CMC_GRUPO_TELA_LOG>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMC_GRUPO_TELA_LOG");

            entity.Property(e => e.DS_ATIVIDADE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DT_ATIVIDADE).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_GRUPO_USUARIO>(entity =>
        {
            entity.HasKey(e => e.ID_GRUPO_USUARIO);

            entity.ToTable("TB_CMC_GRUPO_USUARIO");

            entity.HasIndex(e => e.ID_GRUPO, "Missing_IXNC_TB_CMC_GRUPO_USUARIO_ID_GRUPO_7E40F").HasFillFactor(80);

            entity.HasIndex(e => new { e.ID_GRUPO, e.ID_USUARIO }, "Missing_IXNC_TB_CMC_GRUPO_USUARIO_ID_GRUPO_ID_USUARIO_B3D9B").HasFillFactor(80);

            entity.HasIndex(e => e.ID_USUARIO, "Missing_IXNC_TB_CMC_GRUPO_USUARIO_ID_USUARIO_9F04B").HasFillFactor(80);

            entity.HasIndex(e => new { e.ID_GRUPO, e.ID_USUARIO, e.ID_ORGANIZACAO }, "UC_GRUPO_USUARIO").IsUnique();

            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_GRUPONavigation).WithMany(p => p.TB_CMC_GRUPO_USUARIOs)
                .HasForeignKey(d => d.ID_GRUPO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_GRUPO_USUARIO_TB_CMC_GRUPO");

            entity.HasOne(d => d.ID_USUARIONavigation).WithMany(p => p.TB_CMC_GRUPO_USUARIOs)
                .HasForeignKey(d => d.ID_USUARIO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_GRUPO_USUARIO_TB_CMC_USUARIO");
        });

        modelBuilder.Entity<TB_CMC_GRUPO_USUARIO_20220204>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMC_GRUPO_USUARIO_20220204");

            entity.Property(e => e.ID_GRUPO_USUARIO).ValueGeneratedOnAdd();
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_GRUPO_USUARIO_20241029>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMC_GRUPO_USUARIO_20241029");

            entity.Property(e => e.ID_GRUPO_USUARIO).ValueGeneratedOnAdd();
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_MODULO>(entity =>
        {
            entity.HasKey(e => e.ID_MODULO);

            entity.ToTable("TB_CMC_MODULO");

            entity.Property(e => e.ID_MODULO).ValueGeneratedNever();
            entity.Property(e => e.DS_DESCRICAO)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.DS_MODULO)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_MODULO_PRODUCAO>(entity =>
        {
            entity.HasKey(e => new { e.ID_SISTEMA, e.ID_MODULO, e.ID_ORGANIZACAO }).HasName("PK_MODULO_PRODUCAO");

            entity.ToTable("TB_CMC_MODULO_PRODUCAO");

            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DT_INICIO).HasColumnType("datetime");

            entity.HasOne(d => d.ID_MODULONavigation).WithMany(p => p.TB_CMC_MODULO_PRODUCAOs)
                .HasForeignKey(d => d.ID_MODULO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_MODULO_TB_CMC_MODULO_PRODUCAO");

            entity.HasOne(d => d.ID_SISTEMANavigation).WithMany(p => p.TB_CMC_MODULO_PRODUCAOs)
                .HasForeignKey(d => d.ID_SISTEMA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_SISTEMA_TB_CMC_MODULO_PRODUCAO");
        });

        modelBuilder.Entity<TB_CMC_MUDANCA_SENHA>(entity =>
        {
            entity.HasKey(e => e.ID_GUID);

            entity.ToTable("TB_CMC_MUDANCA_SENHA");

            entity.Property(e => e.ID_GUID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DT_VALIDADE).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_PERFIL_USUARIO>(entity =>
        {
            entity.HasKey(e => e.ID_PERFIL_USUARIO).HasName("PK__TB_CMC_P__B2E37D024A4E069C");

            entity.ToTable("TB_CMC_PERFIL_USUARIO");

            entity.Property(e => e.DS_PERFIL_USUARIO)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_SISTEMA>(entity =>
        {
            entity.HasKey(e => e.ID_SISTEMA);

            entity.ToTable("TB_CMC_SISTEMA");

            entity.Property(e => e.ID_SISTEMA).ValueGeneratedNever();
            entity.Property(e => e.DS_DESCRICAO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_SISTEMA)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_TELA>(entity =>
        {
            entity.HasKey(e => e.ID_TELA);

            entity.ToTable("TB_CMC_TELA");

            entity.Property(e => e.DS_DESCRICAO_TELA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_TELA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_URL_TELA)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_SISTEMANavigation).WithMany(p => p.TB_CMC_TELAs)
                .HasForeignKey(d => d.ID_SISTEMA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_TELA_TB_CMC_SISTEMA");

            entity.HasOne(d => d.ID_TELA_PAINavigation).WithMany(p => p.InverseID_TELA_PAINavigation)
                .HasForeignKey(d => d.ID_TELA_PAI)
                .HasConstraintName("FK_TB_CMC_TELA_TB_CMC_TELA");
        });

        modelBuilder.Entity<TB_CMC_USUARIO>(entity =>
        {
            entity.HasKey(e => e.ID_USUARIO);

            entity.ToTable("TB_CMC_USUARIO");

            entity.HasIndex(e => new { e.DS_LOGIN, e.DS_SENHA, e.FL_ATIVO }, "Missing_IXNC_TB_CMC_USUARIO_DS_LOGIN_DS_SENHA_FL_ATIVO_1C14F").HasFillFactor(80);

            entity.HasIndex(e => new { e.DS_LOGIN, e.FL_ATIVO }, "Missing_IXNC_TB_CMC_USUARIO_DS_LOGIN_FL_ATIVO_769EE").HasFillFactor(80);

            entity.HasIndex(e => new { e.FL_ATIVO, e.ID_ORGANIZACAO }, "Missing_IXNC_TB_CMC_USUARIO_FL_ATIVO_ID_ORGANIZACAO_2F41D").HasFillFactor(80);

            entity.HasIndex(e => new { e.FL_ATIVO, e.ID_ORGANIZACAO, e.ID_EQUIPE_VENDAS }, "Missing_IXNC_TB_CMC_USUARIO_FL_ATIVO_ID_ORGANIZACAO_ID_EQUIPE_VENDAS_A7A0A").HasFillFactor(80);

            entity.HasIndex(e => e.ID_ORGANIZACAO, "Missing_IXNC_TB_CMC_USUARIO_ID_ORGANIZACAO_3D009").HasFillFactor(80);

            entity.HasIndex(e => e.ID_ORGANIZACAO, "Missing_IXNC_TB_CMC_USUARIO_ID_ORGANIZACAO_4A17B").HasFillFactor(80);

            entity.HasIndex(e => e.ID_ORGANIZACAO, "Missing_IXNC_TB_CMC_USUARIO_ID_ORGANIZACAO_4BD17").HasFillFactor(80);

            entity.HasIndex(e => e.ID_ORGANIZACAO, "Missing_IXNC_TB_CMC_USUARIO_ID_ORGANIZACAO_BE337").HasFillFactor(80);

            entity.Property(e => e.DS_BAIRRO)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DS_COMPLEMENTO_ENDERECO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_CPF)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_CRECI)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_EMAIL_ASSINATURA).IsUnicode(false);
            entity.Property(e => e.DS_EMAIL_NOME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_ESTADO_CIVIL)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN_AGENTE_DISCADOR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN_UAU)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGRADOURO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_NACIONALIDADE)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_IMPORTACAO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_PROFISSAO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG_CATEGORIA)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG_ORGAO_EMISSOR)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG_TIPO)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG_UF_EMISSOR)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DS_SENHA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_AGENTE_DISCADOR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_UAU)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DT_RG_EMISSAO).HasColumnType("datetime");
            entity.Property(e => e.DT_RG_VALIDADE).HasColumnType("datetime");
            entity.Property(e => e.DT_ULTIMO_ACESSO).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IM_FOTO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NR_CEP)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NR_CPF_IMPORTACAO)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.NR_RG)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NR_TELEFONE)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_PERFIL_USUARIONavigation).WithMany(p => p.TB_CMC_USUARIOs)
                .HasForeignKey(d => d.ID_PERFIL_USUARIO)
                .HasConstraintName("FK_TB_CMC_USUARIO_TB_CMC_PERFIL_USUARIO");
        });

        modelBuilder.Entity<TB_CMC_USUARIO_20210823>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_CMC_USUARIO_20210823");

            entity.Property(e => e.DS_BAIRRO)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DS_COMPLEMENTO_ENDERECO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_CPF)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_CRECI)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_EMAIL_ASSINATURA).IsUnicode(false);
            entity.Property(e => e.DS_EMAIL_NOME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_ESTADO_CIVIL)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN_AGENTE_DISCADOR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN_UAU)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGRADOURO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_NACIONALIDADE)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME_IMPORTACAO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_PROFISSAO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG_CATEGORIA)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG_ORGAO_EMISSOR)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG_TIPO)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.DS_RG_UF_EMISSOR)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DS_SENHA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_AGENTE_DISCADOR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_UAU)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DT_RG_EMISSAO).HasColumnType("datetime");
            entity.Property(e => e.DT_RG_VALIDADE).HasColumnType("datetime");
            entity.Property(e => e.DT_ULTIMO_ACESSO).HasColumnType("datetime");
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ID_USUARIO).ValueGeneratedOnAdd();
            entity.Property(e => e.IM_FOTO)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NR_CEP)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NR_CPF_IMPORTACAO)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.NR_RG)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NR_TELEFONE)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_CMC_USUARIO_ORGANIZACAO>(entity =>
        {
            entity.HasKey(e => e.ID_USUARIO_ORGANIZACAO).HasName("PK__TB_CMC_U__F9A093C21E6F845E");

            entity.ToTable("TB_CMC_USUARIO_ORGANIZACAO");

            entity.HasIndex(e => new { e.ID_USUARIO, e.ID_ORGANIZACAO }, "CK_VALIDACAO_USUARIO_ORGANIZACAO").IsUnique();

            entity.Property(e => e.DS_LOGIN_AGENTE_DISCADOR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_LOGIN_UAU)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_AGENTE_DISCADOR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA_UAU)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ID_ORGANIZACAO)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_USUARIONavigation).WithMany(p => p.TB_CMC_USUARIO_ORGANIZACAOs)
                .HasForeignKey(d => d.ID_USUARIO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO");
        });

        modelBuilder.Entity<TB_CMC_USUARIO_PREFERENCIA>(entity =>
        {
            entity.HasKey(e => new { e.ID_USUARIO, e.DS_PREFERENCIA });

            entity.ToTable("TB_CMC_USUARIO_PREFERENCIA");

            entity.Property(e => e.DS_PREFERENCIA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.VL_PREFERENCIA)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_USUARIONavigation).WithMany(p => p.TB_CMC_USUARIO_PREFERENCIa)
                .HasForeignKey(d => d.ID_USUARIO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_USUARIO_PREFERENCIA_TB_CMC_USUARIO");
        });

        modelBuilder.Entity<TB_CMC_USUARIO_TELEFONE>(entity =>
        {
            entity.HasKey(e => e.ID_USUARIO_TELEFONE);

            entity.ToTable("TB_CMC_USUARIO_TELEFONE");

            entity.Property(e => e.COD_DDD)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.COD_DDI)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DS_OBS)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NR_TELEFONE)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_USUARIONavigation).WithMany(p => p.TB_CMC_USUARIO_TELEFONEs)
                .HasForeignKey(d => d.ID_USUARIO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_CMC_USUARIO_TELEFONE_TB_CMC_USUARIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
