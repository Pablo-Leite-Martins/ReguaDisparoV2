using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_FILA_ENTREGA
{
    public int ID_CONTA_FILA_ENTREGA { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int ID_VENDA { get; set; }

    public int NR_CONTRATO { get; set; }

    public int NR_FILA_GERAL { get; set; }

    public int NR_FILA { get; set; }

    public string DS_TIPOLOGIA { get; set; } = null!;

    public DateTime DT_ENTRADA_FILA { get; set; }

    public virtual TB_CMCRM_CONTum ID_CONTANavigation { get; set; } = null!;
}
