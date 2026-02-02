using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_IMPORTACAO_CASO_COBRANCA
{
    public int ID_IMPORTACAO { get; set; }

    public int? ID_USUARIO { get; set; }

    public int? ID_EMPRESA { get; set; }

    public string? ID_OBRA { get; set; }

    public int? ID_VENDA { get; set; }

    public string? DS_RESULTADO_CONTATO { get; set; }

    public string? DS_MOTIVO_INADIMPLENCIA { get; set; }

    public string? DS_DESCRICAO { get; set; }

    public string? DS_CANAL_ATENDIMENTO { get; set; }

    public DateTime? DT_ATENDIMENTO { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public int? ID_CASO { get; set; }

    public string? DS_RESULTADO { get; set; }
}
