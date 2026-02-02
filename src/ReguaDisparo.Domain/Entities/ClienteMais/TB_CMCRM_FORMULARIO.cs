using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FORMULARIO
{
    public int ID_FORMULARIO { get; set; }

    public string DS_FORMULARIO { get; set; } = null!;

    public string? DS_INFORMACOES { get; set; }

    public int? ID_PRODUTO { get; set; }

    public bool? FL_NPS { get; set; }

    public string? DS_IDENTIFICADOR { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO> TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>();

    public virtual ICollection<TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIO> TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIOs { get; set; } = new List<TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIO>();

    public virtual ICollection<TB_CMCRM_EMAIL_REGUA_PESQUISA> TB_CMCRM_EMAIL_REGUA_PESQUISAs { get; set; } = new List<TB_CMCRM_EMAIL_REGUA_PESQUISA>();

    public virtual ICollection<TB_CMCRM_EQUIPE_HELP_DESK> TB_CMCRM_EQUIPE_HELP_DESKs { get; set; } = new List<TB_CMCRM_EQUIPE_HELP_DESK>();

    public virtual ICollection<TB_CMCRM_FORMULARIO_MODULO> TB_CMCRM_FORMULARIO_MODULOs { get; set; } = new List<TB_CMCRM_FORMULARIO_MODULO>();

    public virtual ICollection<TB_CMCRM_FORMULARIO_UNIDADE> TB_CMCRM_FORMULARIO_UNIDADEs { get; set; } = new List<TB_CMCRM_FORMULARIO_UNIDADE>();

    public virtual ICollection<TB_CMCRM_PERGUNTum> TB_CMCRM_PERGUNTa { get; set; } = new List<TB_CMCRM_PERGUNTum>();
}
