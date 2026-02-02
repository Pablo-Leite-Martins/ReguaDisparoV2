using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_VALORES_AT
{
    public int ID_TOTVS_FATO_VALORES_AT { get; set; }

    public string? IDLAN { get; set; }

    public string? CODCCUSTO { get; set; }

    public string? NOME_CENTRO_CUSTO { get; set; }

    public string? VALOR_LIQUIDO { get; set; }

    public string? COD_CLASS_FIN { get; set; }

    public string? DESC_CLASS_FIN { get; set; }

    public string? DATABAIXA { get; set; }

    public string? COD_FORNECEDOR { get; set; }

    public string? NOME_FORNECEDOR { get; set; }

    public string? NOME_FANTASIA_FORNECEDOR { get; set; }

    public string? CPF_CNPJ_FORNECEDOR { get; set; }

    public string? ORIGEM_IDMOV { get; set; }

    public string? ORIGEM_USUARIOCRIACAO { get; set; }

    public string? ORIGEM_DATACRIACAO { get; set; }

    public string? ORIGEM_USUARIOAPROVACAO { get; set; }

    public string? ORIGEM_CODTMV { get; set; }

    public string? NUMERODOCUMENTO { get; set; }

    public string? RATEIO { get; set; }

    public string? FLAN_HISTORICO { get; set; }

    public string? CLASS_DEFAULT_FORNECEDOR { get; set; }

    public string? DESC_CLASS_DEFAULT_FORNECEDOR { get; set; }

    public string? DATAEMISSAO { get; set; }

    public string? VALOR_ORIGINAL { get; set; }

    public string? QUALIFICACAO_CLIFOR { get; set; }

    public string? FLANRATCCU_HISTORICO { get; set; }

    public string? USUARIOCRIACAO { get; set; }

    public string? DATACRIACAO { get; set; }

    public string? IDMOV { get; set; }

    public string? ORIGEM_DATAAPROVACAO { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
