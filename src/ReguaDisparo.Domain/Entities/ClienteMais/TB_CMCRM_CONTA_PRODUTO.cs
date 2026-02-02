using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_PRODUTO
{
    public int ID_CONTA_PRODUTO { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_PRODUTO { get; set; }

    public int QTD_PRODUTO { get; set; }

    public decimal VLR_UNITARIO_PRODUTO { get; set; }

    public DateTime DT_VENDA { get; set; }

    public decimal VLR_TOTAL_PRODUTO { get; set; }

    public bool FL_STATUS_VENDA { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_USUARIO_VENDA { get; set; }

    public int? ID_PROPOSTA_ACEITA { get; set; }

    public bool? FL_CONFIRMACAO_SINAL { get; set; }

    public string? ID_TITULO_SIENGE { get; set; }

    public string? ID_STATUS_VENDA_ERP { get; set; }

    public string? DS_STATUS { get; set; }

    public int? ID_ETAPA_JORNADA { get; set; }

    public virtual TB_CMCRM_CONTum ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_ETAPA_JORNADum? ID_ETAPA_JORNADANavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PROPOSTum? ID_PROPOSTA_ACEITANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO_DOCUMENTO> TB_CMCRM_CONTA_PRODUTO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO_PROPONENTE> TB_CMCRM_CONTA_PRODUTO_PROPONENTEs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO_PROPONENTE>();
}
