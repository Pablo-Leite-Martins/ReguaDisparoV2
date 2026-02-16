using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ITERUP_FATO_RESPOSTA
{
    public int ID_ITERUAP_FATO_RESPOSTA { get; set; }

    public int? NumDialogo { get; set; }

    public int? NumEtapa { get; set; }

    public string? TextoEtapa { get; set; }

    public string? TextoEtapaOriginal { get; set; }

    public string? Titulo { get; set; }

    public string? IdUsuario { get; set; }

    public int? NumResposta { get; set; }

    public string? Link { get; set; }

    public string? Observacao { get; set; }

    public string? ValorArmazenado { get; set; }

    public string? Tipo { get; set; }

    public string? Canal { get; set; }

    public decimal? Score { get; set; }

    public string? EnviadaRecebida { get; set; }

    public DateTime? DataHora { get; set; }

    public string? Grupo { get; set; }

    public string? RespWhatsappNum { get; set; }

    public int? PartitionKey { get; set; }

    public string? RowKey { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? ETag { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
