using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_DOCUMENTO
{
    public int ID_TIPO_DOCUMENTO { get; set; }

    public string DS_TIPO_DOCUMENTO { get; set; } = null!;

    public int ID_CLASSIFICACAO_DOCUMENTO { get; set; }

    public bool FL_ATIVO { get; set; }

    public virtual TB_CMCRM_CLASSIFICACAO_DOCUMENTO ID_CLASSIFICACAO_DOCUMENTONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_DOCUMENTO> TB_CMCRM_CASO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_CASO_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_CONTATO_DOCUMENTO> TB_CMCRM_CONTATO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_CONTATO_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO_DOCUMENTO> TB_CMCRM_CONTA_PRODUTO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_DOCUMENTO_PRODUTO> TB_CMCRM_DOCUMENTO_PRODUTOs { get; set; } = new List<TB_CMCRM_DOCUMENTO_PRODUTO>();

    public virtual ICollection<TB_CMCRM_DOCUMENTO_TEMPLATE> TB_CMCRM_DOCUMENTO_TEMPLATEs { get; set; } = new List<TB_CMCRM_DOCUMENTO_TEMPLATE>();

    public virtual ICollection<TB_CMCRM_TIPO_DOCUMENTO_ETAPA_TIPO_CASO> TB_CMCRM_TIPO_DOCUMENTO_ETAPA_TIPO_CASOs { get; set; } = new List<TB_CMCRM_TIPO_DOCUMENTO_ETAPA_TIPO_CASO>();
}
