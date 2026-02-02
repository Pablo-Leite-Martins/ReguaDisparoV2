using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ETL
{
    public int ID_ETL { get; set; }

    public string? DS_ETL { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public DateTime DT_HORA_EXECUCAO { get; set; }

    public DateTime? DT_HORARIO_ULTIMA_EXECUCAO { get; set; }

    public int? NR_TIMEOUT { get; set; }

    public int? NR_BATCHSIZE { get; set; }

    public bool FL_SERVICO_ATIVO { get; set; }

    public bool FL_ETL_ATIVO { get; set; }

    public bool FL_ETL_SECUNDARIO { get; set; }

    public virtual ICollection<TB_CMCORP_ETL_ITERUP> TB_CMCORP_ETL_ITERUPs { get; set; } = new List<TB_CMCORP_ETL_ITERUP>();

    public virtual ICollection<TB_CMCORP_ETL_LOG_USUARIO> TB_CMCORP_ETL_LOG_USUARIOs { get; set; } = new List<TB_CMCORP_ETL_LOG_USUARIO>();

    public bool EtlExecutadoHoje()
    {
        if (!DT_HORARIO_ULTIMA_EXECUCAO.HasValue)
            return false;
        return DT_HORARIO_ULTIMA_EXECUCAO.Value.Date == DateTime.Now.Date;
    }
}
