using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO
{
    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO { get; set; }

    public string DS_NOME_ACAO { get; set; } = null!;

    public int ID_TIPO_ACAO { get; set; }

    public int? ID_TEMPLATE_EMAIL { get; set; }

    public int? ID_TEMPLATE_SMS { get; set; }

    public int? ID_CASO_COBRANCA_REGUA_ETAPA { get; set; }

    public string? DS_NOME_ARQUIVO { get; set; }

    public int? ID_TEMPLATE_DISTRIBUICAO { get; set; }

    public int? ID_GRUPO_DISTRIBUICAO { get; set; }

    public int? ID_FORMULARIO { get; set; }

    public bool? FL_DISCADOR { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int? ID_EQUIPE_HELPDESK { get; set; }

    public string? ID_TEMPLATE_MRS { get; set; }

    public string? ID_TIPO_POSTAGEM { get; set; }

    public bool? FL_ENVIO_UNICO_CONTA { get; set; }

    public virtual TB_CMCRM_EQUIPE_HELP_DESK? ID_EQUIPE_HELPDESKNavigation { get; set; }

    public virtual TB_CMCRM_FORMULARIO? ID_FORMULARIONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum> TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDa { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum>();

    public virtual ICollection<TB_CMCRM_EMAIL_REGUA_PESQUISA> TB_CMCRM_EMAIL_REGUA_PESQUISAs { get; set; } = new List<TB_CMCRM_EMAIL_REGUA_PESQUISA>();
}
