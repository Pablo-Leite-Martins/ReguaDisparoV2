using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_UAU_FATO_IMPORTACAO
{
    public int ID_UAU_FATO_IMPORTACAO { get; set; }

    public string? DS_NOME { get; set; }

    public string? NR_CPF { get; set; }

    public string? DS_EMAIL { get; set; }

    public string? ID_CHAVE_ERP_CLIENTE { get; set; }

    public string? DS_BAIRRO { get; set; }

    public string? DS_LOGRADOURO { get; set; }

    public string? NR_ENDERECO { get; set; }

    public string? DS_COMPLEMENTO_ENDERECO { get; set; }

    public string? NR_CEP { get; set; }

    public int? ID_TIPO_TELEFONE { get; set; }

    public string? NR_TELEFONE { get; set; }

    public string? COD_DDI { get; set; }

    public string? COD_DDD { get; set; }

    public string? NR_RAMAL { get; set; }

    public string? ID_CHAVE_ERP_PRODUTO { get; set; }

    public string? DS_PRODUTO { get; set; }

    public string? ID_CHAVE_ERP_UNIDADE { get; set; }

    public string? DS_UNIDADE { get; set; }

    public string? ID_CHAVE_ERP_OBRA { get; set; }

    public string? DS_OBRA { get; set; }

    public string? ID_CHAVE_ERP_EMPRESA { get; set; }

    public string? DS_EMPRESA { get; set; }

    public DateTime DT_MES_REFERENCIA { get; set; }

    public string? ID_CHAVE_ERP_VENDA { get; set; }

    public DateTime? DT_VENDA { get; set; }

    public decimal? VL_VENDA { get; set; }

    public string? ID_STATUS_VENDA_ERP { get; set; }

    public int? NR_PARCELAS { get; set; }

    public decimal? VL_RECEBIDO { get; set; }

    public string? NR_RG { get; set; }

    public string? DS_RG_ORGAO_EMISSOR { get; set; }

    public string? DS_RG_UF_EMISSOR { get; set; }

    public DateTime? DT_RG_EMISSAO { get; set; }

    public string? DS_NOME_PAI { get; set; }

    public string? DS_NOME_MAE { get; set; }
}
