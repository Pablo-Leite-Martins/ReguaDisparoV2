using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PERFIL_FINANCEIRO_CLASSIFICACAO
{
    public int ID_PERFIL_FINANCEIRO_CLASSIFICACAO { get; set; }

    public string DS_CLASSIFICACAO { get; set; } = null!;

    public string? DS_DESCRICAO { get; set; }

    public int NR_ORDEM { get; set; }

    public virtual ICollection<TB_CMCRM_PERFIL_FINANCEIRO_ACAO_FILTRO> TB_CMCRM_PERFIL_FINANCEIRO_ACAO_FILTROs { get; set; } = new List<TB_CMCRM_PERFIL_FINANCEIRO_ACAO_FILTRO>();
}
