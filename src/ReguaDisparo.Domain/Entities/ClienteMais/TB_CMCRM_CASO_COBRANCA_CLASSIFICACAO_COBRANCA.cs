using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_CLASSIFICACAO_COBRANCA
{
    public int ID_CASO_COBRANCA_CLASSIFICACAO_COBRANCA { get; set; }

    public string DS_CASO_COBRANCA_CLASSIFICACAO_COBRANCA { get; set; } = null!;

    public bool FL_PERMITE_NEGOCIACAO { get; set; }

    public string DS_LEGENDA { get; set; } = null!;

    public int? ID_CASO_COBRANCA_CLASSIFICACAO_GRUPO_EXCECAO { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_RESULTADO_CONTATO> TB_CMCRM_CASO_COBRANCA_RESULTADO_CONTATOs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_RESULTADO_CONTATO>();
}
