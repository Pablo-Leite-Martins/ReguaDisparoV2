using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_USUARIO_20210823
{
    public int ID_USUARIO { get; set; }

    public string DS_LOGIN { get; set; } = null!;

    public string DS_NOME { get; set; } = null!;

    public string DS_EMAIL { get; set; } = null!;

    public string DS_SENHA { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public bool FL_ADMINISTRADOR { get; set; }

    public DateTime? DT_ULTIMO_ACESSO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public string? IM_FOTO { get; set; }

    public string? DS_CPF { get; set; }

    public string? DS_RG { get; set; }

    public string? DS_CRECI { get; set; }

    public int? ID_EQUIPE_VENDAS { get; set; }

    public int? ID_GERENTE { get; set; }

    public int? ID_GERENTE_REGIONAL { get; set; }

    public int? ID_DIRETOR { get; set; }

    public int? ID_CONTA_VINCULADA { get; set; }

    public string? NR_TELEFONE { get; set; }

    public int? ID_EMAIL_CONTA { get; set; }

    public string? DS_EMAIL_NOME { get; set; }

    public string? DS_EMAIL_ASSINATURA { get; set; }

    public int? ID_COORDENADOR_VENDAS { get; set; }

    public string? DS_NOME_IMPORTACAO { get; set; }

    public string? NR_CPF_IMPORTACAO { get; set; }

    public string? DS_LOGIN_UAU { get; set; }

    public string? DS_SENHA_UAU { get; set; }

    public int? NR_AGENTE_DISCADOR { get; set; }

    public int? ID_COORDENADOR_MARKETING { get; set; }

    public string? DS_SENHA_AGENTE_DISCADOR { get; set; }

    public int? ID_RAMAL_DISCADOR { get; set; }

    public string? DS_NACIONALIDADE { get; set; }

    public string? DS_ESTADO_CIVIL { get; set; }

    public int? ID_PROFISSAO { get; set; }

    public string? DS_PROFISSAO { get; set; }

    public string? NR_RG { get; set; }

    public string? DS_RG_ORGAO_EMISSOR { get; set; }

    public string? DS_RG_UF_EMISSOR { get; set; }

    public DateTime? DT_RG_EMISSAO { get; set; }

    public string? DS_RG_TIPO { get; set; }

    public string? DS_RG_CATEGORIA { get; set; }

    public DateTime? DT_RG_VALIDADE { get; set; }

    public int? ID_CIDADE { get; set; }

    public string? DS_BAIRRO { get; set; }

    public string? DS_LOGRADOURO { get; set; }

    public int? NR_ENDERECO { get; set; }

    public string? DS_COMPLEMENTO_ENDERECO { get; set; }

    public string? NR_CEP { get; set; }

    public int? ID_GERENTE_COMERCIAL { get; set; }

    public int? ID_SUPERINTENDENTE { get; set; }

    public int? ID_CLASSIFICACAO_HORAS_REAL { get; set; }

    public string? DS_LOGIN_AGENTE_DISCADOR { get; set; }
}
