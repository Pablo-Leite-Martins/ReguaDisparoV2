using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_UAU_FATO_IMPORTACAO_CONTA_PROPONENTE_SECUNDARIO
{
    public DateTime? DT_MES_REFERENCIA { get; set; }

    public string? DS_NOME { get; set; }

    public string? NR_CPF { get; set; }

    public string? ID_CHAVE_ERP_CONTATO { get; set; }

    public string? ID_CHAVE_ERP_EMPRESA { get; set; }

    public string? ID_CHAVE_ERP_OBRA { get; set; }

    public string? ID_CHAVE_ERP_VENDA { get; set; }

    public int ID_TIPO_RELACAO { get; set; }

    public string? NR_TELEFONE { get; set; }

    public string? COD_DDD { get; set; }

    public string? DS_EMAIL { get; set; }
}
