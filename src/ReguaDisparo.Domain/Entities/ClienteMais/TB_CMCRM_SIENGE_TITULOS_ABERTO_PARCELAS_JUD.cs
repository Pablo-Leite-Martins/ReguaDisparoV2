using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_TITULOS_ABERTO_PARCELAS_JUD
{
    public long ID_TITULO_ABERTO_JUD { get; set; }

    public long? receivableBillId { get; set; }

    public DateTime? recordDate { get; set; }

    /// <summary>
    /// Situação da atividade (N- normal, C- em cobrança, J- sub-judice, I- inadimplente).
    /// </summary>
    public string? situation { get; set; }

    public string? concluded { get; set; }

    public string? observation { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
