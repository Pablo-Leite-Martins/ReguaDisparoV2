using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_IMPORTACAO
{
    public int ID_TOTVS_FATO_IMPORTACAO { get; set; }

    public int? ID_FATO_IMPORTACAO { get; set; }

    public string? DS_NOME { get; set; }

    public string? NR_CPF { get; set; }

    public string? DS_EMAIL { get; set; }

    public string? ID_CHAVE_ERP_CLIENTE { get; set; }

    public string? DS_BAIRRO { get; set; }

    public string? DS_LOGRADOURO { get; set; }

    public string? NR_ENDERECO { get; set; }

    public string? DS_COMPLEMENTO_ENDERECO { get; set; }

    public string? NR_CEP { get; set; }

    public string? COD_DDI { get; set; }

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

    public string? STATUS_VENDA { get; set; }

    public int? ID_TIPO_TELEFONE { get; set; }

    public string? NR_TELEFONE { get; set; }

    public string? TIPO_UNIDADE { get; set; }

    public string? DS_NOME_MAE { get; set; }

    public DateTime? DT_NASCIMENTO { get; set; }

    public int? ID_BOLETO_PIX { get; set; }

    public string? BANCOCEDIDO { get; set; }

    public DateTime? DATA_CESSAO { get; set; }
}
