using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PERFIL_FINANCEIRO_ACAO_TIPO_FILTRO
{
    public int ID_PERFIL_FINANCEIRO_ACAO_TIPO_FILTRO { get; set; }

    public string DS_VALOR { get; set; } = null!;

    public string DS_CAMPO { get; set; } = null!;

    public string? DS_TIPO { get; set; }

    public virtual ICollection<TB_CMCRM_PERFIL_FINANCEIRO_ACAO_FILTRO> TB_CMCRM_PERFIL_FINANCEIRO_ACAO_FILTROs { get; set; } = new List<TB_CMCRM_PERFIL_FINANCEIRO_ACAO_FILTRO>();
}
