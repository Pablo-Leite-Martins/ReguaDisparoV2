using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_VARIAVEL_TEMPLATE_MENSAGEM_ATIVA
{
    public int ID_CMCRM_VARIAVEL_TEMPLATE_MENSAGEM_ATIVA { get; set; }

    public int NR_POSICAO_VARIAVEL { get; set; }

    public string? DS_LOCAL_VALOR { get; set; }

    public string? DS_TIPO_VARIAVEL { get; set; }

    public int ID_DOCUMENTO_TEMPLATE { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_TEMPLATE ID_DOCUMENTO_TEMPLATENavigation { get; set; } = null!;
}
