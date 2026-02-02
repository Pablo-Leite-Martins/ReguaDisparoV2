using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONFIG_GERAL_VENDA
{
    public int ID_CONFIG_GERAL_VENDAS { get; set; }

    public string? DS_CONFIGURACAO { get; set; }

    public string VL_CONFIGURACAO { get; set; } = null!;

    public string? VL_ITEM_CONFIGURACAO { get; set; }

    public string? DS_CATEGORIA_CONFIGURACAO { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public string? DS_ENDPOINT { get; set; }

    public string? DS_TIPO_CAMPO { get; set; }

    public string? DS_VALOR_CAMPO { get; set; }

    public string? DS_ID_CAMPO { get; set; }
}
