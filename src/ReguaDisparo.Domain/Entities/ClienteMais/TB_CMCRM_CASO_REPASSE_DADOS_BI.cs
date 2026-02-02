using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_REPASSE_DADOS_BI
{
    public int ID_CASO_REPASSE_DADOS_BI { get; set; }

    public int? NR_SICAQ_APROVADO { get; set; }

    public int? NR_SICAQ_CONDICIONADO { get; set; }

    public int? NR_ERRO_RESTRICAO { get; set; }

    public int? NR_DOCUMENTOS_PENDENTES { get; set; }

    public int? NR_EM_ANALISE_AGENCIA { get; set; }

    public int? NR_SICAQ_REPROVADO { get; set; }

    public int? NR_UHS_BLOQUEADAS { get; set; }

    public decimal? VL_BLOQUEADO { get; set; }

    public decimal? VL_BLOQUEADO_SEMANA_ANTERIOR { get; set; }

    public int ID_EMPREENDIMENTO { get; set; }

    public int? NR_TOTAL_UNIDADES { get; set; }

    public int? ID_USUARIO { get; set; }

    public decimal? NR_TOTAL_PERMUTAS { get; set; }
}
