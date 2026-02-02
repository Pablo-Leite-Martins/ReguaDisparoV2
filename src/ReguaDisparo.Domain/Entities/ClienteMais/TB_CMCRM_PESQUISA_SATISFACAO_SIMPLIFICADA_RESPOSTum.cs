using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_RESPOSTum
{
    public int ID_PESQUISA_SATISFACAO_SIMPLIFICADA_RESPOSTA { get; set; }

    public DateTime DT_HORARIO_RESPOSTA { get; set; }

    public string? DS_MENSAGEM_RESPOSTA { get; set; }

    public int ID_PESQUISA_SATISFACAO_SIMPLIFICADA_ENVIO { get; set; }

    public virtual TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_ENVIO ID_PESQUISA_SATISFACAO_SIMPLIFICADA_ENVIONavigation { get; set; } = null!;
}
