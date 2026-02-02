using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_ENVIO
{
    public int ID_PESQUISA_SATISFACAO_SIMPLIFICADA_ENVIO { get; set; }

    public int ID_CONTA_CHAT { get; set; }

    public DateTime DT_ENVIO_PESQUISA { get; set; }

    public string? DS_MENSAGEM_ENVIADA { get; set; }

    public int ID_USUARIO_ENVIO { get; set; }

    public virtual TB_CMCRM_CONTA_CHAT ID_CONTA_CHATNavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_RESPOSTum> TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_RESPOSTa { get; set; } = new List<TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_RESPOSTum>();
}
