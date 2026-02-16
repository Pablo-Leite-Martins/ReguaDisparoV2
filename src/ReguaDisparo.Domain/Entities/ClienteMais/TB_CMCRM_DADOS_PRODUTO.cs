using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DADOS_PRODUTO
{
    public int ID_DADOS_PRODUTO { get; set; }

    public int ID_PRODUTO { get; set; }

    public DateTime? DT_LANCAMENTO { get; set; }

    public DateTime? DT_PATRIMONIO_AFETACAO { get; set; }

    public DateTime? DT_AGI { get; set; }

    public DateTime? DT_RECEBIMENTO_AREA_COMUM { get; set; }

    public int? NR_TORRES { get; set; }

    public int? NR_UNIDADES_TORRE { get; set; }

    public string? DS_TIPO_VAGA { get; set; }

    public string? DS_MURO { get; set; }

    public string? DS_PLANTA { get; set; }

    public int? NR_ANDAMENTO_OBRA { get; set; }

    public int? ID_OPCAO_PLANTA { get; set; }

    public bool? FL_VISTORIA_ANTECIPADA { get; set; }

    public virtual TB_CMCRM_OPCAO_PLANTA? ID_OPCAO_PLANTANavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
