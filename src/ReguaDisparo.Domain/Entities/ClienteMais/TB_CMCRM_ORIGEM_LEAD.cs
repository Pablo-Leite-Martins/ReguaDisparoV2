using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ORIGEM_LEAD
{
    public int ID_ORIGEM_LEAD { get; set; }

    public string DS_ORIGEM_LEAD { get; set; } = null!;

    public int? ID_ORIGEM_LEAD_PAI { get; set; }

    public string? DS_ORIGEM_LEAD_COMP { get; set; }

    public string? DS_NOME_FORMULARIO_FACEBOOK_LEADS { get; set; }

    public bool? FL_ORIGEM_FACEBOOK_LEADS { get; set; }

    public bool? FL_ORIGEM_INSTAGRAM_LEADS { get; set; }

    public bool? FL_DIGITAL { get; set; }

    public int? ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_ORIGEM_LEAD? ID_ORIGEM_LEAD_PAINavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD> InverseID_ORIGEM_LEAD_PAINavigation { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD>();

    public virtual ICollection<TB_CMCRM_ATENDIMENTO_CHAT> TB_CMCRM_ATENDIMENTO_CHATs { get; set; } = new List<TB_CMCRM_ATENDIMENTO_CHAT>();

    public virtual ICollection<TB_CMCRM_CHAT_TO_LEAD> TB_CMCRM_CHAT_TO_LEADs { get; set; } = new List<TB_CMCRM_CHAT_TO_LEAD>();

    public virtual ICollection<TB_CMCRM_CONTum> TB_CMCRM_CONTa { get; set; } = new List<TB_CMCRM_CONTum>();

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDum> TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDa { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDum>();

    public virtual ICollection<TB_CMCRM_FILA_ATENDIMENTO> TB_CMCRM_FILA_ATENDIMENTOs { get; set; } = new List<TB_CMCRM_FILA_ATENDIMENTO>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD_CONVERSAO> TB_CMCRM_ORIGEM_LEAD_CONVERSAOs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD_CONVERSAO>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD_EQUIPE_VENDA> TB_CMCRM_ORIGEM_LEAD_EQUIPE_VENDAs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD_EQUIPE_VENDA>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD_FILA_ATENDIMENTO> TB_CMCRM_ORIGEM_LEAD_FILA_ATENDIMENTOs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD_FILA_ATENDIMENTO>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD_PRODUTO> TB_CMCRM_ORIGEM_LEAD_PRODUTOs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD_PRODUTO>();
}
