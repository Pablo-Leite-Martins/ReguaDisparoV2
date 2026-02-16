using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CATEGORIA_ATENDIMENTO
{
    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public string DS_CATEGORIA_ATENDIMENTO { get; set; } = null!;

    public int? ID_CATEGORIA_ATENDIMENTO_PAI { get; set; }

    public int? NR_SLA { get; set; }

    public string? DS_CATEGORIA_ATENDIMENTO_COMP { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public int? NR_GARANTIA_MESES { get; set; }

    public bool? FL_ATIVO { get; set; }

    public int? NR_GARANTIA_MESES_NOVA { get; set; }

    public int? NR_SLA_AREA_COMUM { get; set; }

    public bool? FL_ATIVO_PORTAL { get; set; }

    public int? NR_URGENCIA { get; set; }

    public int? NR_IMPACTO { get; set; }

    public string? DS_MENSAGEM_ORIENTATIVA { get; set; }

    public bool? FL_BLOCK_ABERTURA_ATENDIMENTO_CONTA_PRODUTO_CATEGORIA { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTO_PAINavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CATEGORIA_ATENDIMENTO> InverseID_CATEGORIA_ATENDIMENTO_PAINavigation { get; set; } = new List<TB_CMCRM_CATEGORIA_ATENDIMENTO>();

    public virtual ICollection<TB_CMCRM_CASO> TB_CMCRM_CASOs { get; set; } = new List<TB_CMCRM_CASO>();

    public virtual ICollection<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC> TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TECID_CATEGORIA_ATENDIMENTO_ABERTURANavigations { get; set; } = new List<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC>();

    public virtual ICollection<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC> TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TECID_CATEGORIA_ATENDIMENTO_FECHAMENTONavigations { get; set; } = new List<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC>();

    public virtual ICollection<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC> TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TECID_CATEGORIA_ATENDIMENTO_REPARONavigations { get; set; } = new List<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC>();

    public virtual ICollection<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC> TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TECID_CATEGORIA_ATENDIMENTO_VISTORIANavigations { get; set; } = new List<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC>();

    public virtual ICollection<TB_CMCRM_CATEGORIA_ATENDIMENTO_TIPO_CASO> TB_CMCRM_CATEGORIA_ATENDIMENTO_TIPO_CASOs { get; set; } = new List<TB_CMCRM_CATEGORIA_ATENDIMENTO_TIPO_CASO>();

    public virtual ICollection<TB_CMCRM_CONFIGS_URA> TB_CMCRM_CONFIGS_URAs { get; set; } = new List<TB_CMCRM_CONFIGS_URA>();

    public virtual ICollection<TB_CMCRM_CONFIG_GERAL> TB_CMCRM_CONFIG_GERALs { get; set; } = new List<TB_CMCRM_CONFIG_GERAL>();

    public virtual ICollection<TB_CMCRM_CONTA> TB_CMCRM_CONTa { get; set; } = new List<TB_CMCRM_CONTA>();

    public virtual ICollection<TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIO> TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIOs { get; set; } = new List<TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIO>();

    public virtual ICollection<TB_CMCRM_EMAIL_CONTA_CONFIG> TB_CMCRM_EMAIL_CONTA_CONFIGs { get; set; } = new List<TB_CMCRM_EMAIL_CONTA_CONFIG>();

    public virtual ICollection<TB_CMCRM_GARANTIA_PRODUTO> TB_CMCRM_GARANTIA_PRODUTOs { get; set; } = new List<TB_CMCRM_GARANTIA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_SUBCATEGORIA_ATENDIMENTO> TB_CMCRM_SUBCATEGORIA_ATENDIMENTOs { get; set; } = new List<TB_CMCRM_SUBCATEGORIA_ATENDIMENTO>();
}
