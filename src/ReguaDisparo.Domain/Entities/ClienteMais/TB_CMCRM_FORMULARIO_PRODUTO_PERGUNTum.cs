using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTum
{
    public int ID_FORMULARIO_PRODUTO_PERGUNTA { get; set; }

    public string DS_PERGUNTA { get; set; } = null!;

    public int NR_ORDEM { get; set; }

    public int ID_TIPO_PERGUNTA { get; set; }

    public int ID_FORMULARIO_PRODUTO { get; set; }

    public int? ID_PERGUNTA_PAI { get; set; }

    public bool FL_ATIVO { get; set; }

    public virtual TB_CMCRM_FORMULARIO_PRODUTO ID_FORMULARIO_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTum? ID_PERGUNTA_PAINavigation { get; set; }

    public virtual TB_CMCRM_TIPO_PERGUNTum ID_TIPO_PERGUNTANavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTum> InverseID_PERGUNTA_PAINavigation { get; set; } = new List<TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTum>();

    public virtual ICollection<TB_CMCRM_FORMULARIO_PRODUTO_RESPOSTum> TB_CMCRM_FORMULARIO_PRODUTO_RESPOSTa { get; set; } = new List<TB_CMCRM_FORMULARIO_PRODUTO_RESPOSTum>();
}
