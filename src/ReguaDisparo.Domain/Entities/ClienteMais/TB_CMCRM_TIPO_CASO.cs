using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_CASO
{
    public int ID_TIPO_CASO { get; set; }

    public string DS_TIPO_CASO { get; set; } = null!;

    public string? DS_URL_TELA { get; set; }

    public bool FL_DINAMICO { get; set; }

    public bool FL_CUSTOMIZADO { get; set; }

    public bool FL_CRM { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_ACAO> TB_CMCRM_CASO_ACAOs { get; set; } = new List<TB_CMCRM_CASO_ACAO>();

    public virtual ICollection<TB_CMCRM_CASO> TB_CMCRM_CASOs { get; set; } = new List<TB_CMCRM_CASO>();

    public virtual ICollection<TB_CMCRM_CATEGORIA_ATENDIMENTO_TIPO_CASO> TB_CMCRM_CATEGORIA_ATENDIMENTO_TIPO_CASOs { get; set; } = new List<TB_CMCRM_CATEGORIA_ATENDIMENTO_TIPO_CASO>();

    public virtual ICollection<TB_CMCRM_EMAIL_CONTA_CONFIG> TB_CMCRM_EMAIL_CONTA_CONFIGs { get; set; } = new List<TB_CMCRM_EMAIL_CONTA_CONFIG>();

    public virtual ICollection<TB_CMCRM_ETAPA_TIPO_CASO> TB_CMCRM_ETAPA_TIPO_CASOs { get; set; } = new List<TB_CMCRM_ETAPA_TIPO_CASO>();

    public virtual ICollection<TB_CMCRM_FORMULARIO_MODULO> TB_CMCRM_FORMULARIO_MODULOs { get; set; } = new List<TB_CMCRM_FORMULARIO_MODULO>();

    public virtual ICollection<TB_CMCRM_MOTIVO_CANCELAMENTO> TB_CMCRM_MOTIVO_CANCELAMENTOs { get; set; } = new List<TB_CMCRM_MOTIVO_CANCELAMENTO>();
}
