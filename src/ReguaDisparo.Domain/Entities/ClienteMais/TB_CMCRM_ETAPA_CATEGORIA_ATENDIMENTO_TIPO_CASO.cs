using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO
{
    public int ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public string DS_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; } = null!;

    public int NR_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public bool? FL_ETAPA_INICIAL { get; set; }

    public bool? FL_ETAPA_FINAL { get; set; }

    public int? NR_SLO { get; set; }

    public string? DS_MACRO_ETAPA { get; set; }

    public bool FL_ATIVO { get; set; }

    public bool FL_NOTIFICAR_CLIENTE { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO_TIPO_CASO ID_CATEGORIA_ATENDIMENTO_TIPO_CASONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_ACAO_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO> TB_CMCRM_ACAO_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASOID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASONavigations { get; set; } = new List<TB_CMCRM_ACAO_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO>();

    public virtual ICollection<TB_CMCRM_ACAO_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO> TB_CMCRM_ACAO_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASOID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO_DESTINONavigations { get; set; } = new List<TB_CMCRM_ACAO_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO>();

    public virtual ICollection<TB_CMCRM_ATRIBUTO_ETAPA_TIPO_CASO> TB_CMCRM_ATRIBUTO_ETAPA_TIPO_CASOs { get; set; } = new List<TB_CMCRM_ATRIBUTO_ETAPA_TIPO_CASO>();

    public virtual ICollection<TB_CMCRM_CASO_SLO> TB_CMCRM_CASO_SLOs { get; set; } = new List<TB_CMCRM_CASO_SLO>();

    public virtual ICollection<TB_CMCRM_CASO> TB_CMCRM_CASOs { get; set; } = new List<TB_CMCRM_CASO>();

    public virtual ICollection<TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO_GRUPO> TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO_GRUPOs { get; set; } = new List<TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO_GRUPO>();

    public virtual ICollection<TB_CMCRM_STATUS_ETAPA> TB_CMCRM_STATUS_ETAPAs { get; set; } = new List<TB_CMCRM_STATUS_ETAPA>();

    public virtual ICollection<TB_CMCRM_TIPO_DOCUMENTO_ETAPA_TIPO_CASO> TB_CMCRM_TIPO_DOCUMENTO_ETAPA_TIPO_CASOs { get; set; } = new List<TB_CMCRM_TIPO_DOCUMENTO_ETAPA_TIPO_CASO>();
}
