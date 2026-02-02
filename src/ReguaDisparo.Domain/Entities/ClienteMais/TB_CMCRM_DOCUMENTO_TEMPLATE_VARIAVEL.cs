using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_TEMPLATE_VARIAVEL
{
    public int ID_DOCUMENTO_TEMPLATE_VARIAVEL { get; set; }

    public string DS_TIPO { get; set; } = null!;

    public string DS_DESCRICAO { get; set; } = null!;

    public string DS_TABELA { get; set; } = null!;

    public string DS_PARAMETRO { get; set; } = null!;

    public string DS_CAMPO { get; set; } = null!;
}
