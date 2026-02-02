using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PERFIL_FINANCEIRO_ACAO_FILTRO
{
    public int ID_PERFIL_FINANCEIRO_ACAO_FILTRO { get; set; }

    public int ID_PERFIL_FINANCEIRO_CLASSIFICACAO { get; set; }

    public int ID_PERFIL_FINANCEIRO_ACAO_TIPO_FILTRO { get; set; }

    public string DS_OPERACAO { get; set; } = null!;

    public string DS_VALOR { get; set; } = null!;

    public virtual TB_CMCRM_PERFIL_FINANCEIRO_ACAO_TIPO_FILTRO ID_PERFIL_FINANCEIRO_ACAO_TIPO_FILTRONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PERFIL_FINANCEIRO_CLASSIFICACAO ID_PERFIL_FINANCEIRO_CLASSIFICACAONavigation { get; set; } = null!;
}
