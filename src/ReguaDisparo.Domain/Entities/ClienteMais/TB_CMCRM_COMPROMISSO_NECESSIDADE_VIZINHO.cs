using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMPROMISSO_NECESSIDADE_VIZINHO
{
    public int ID_NECESSIDADE_VIZINHO { get; set; }

    public int ID_COMPROMISSO { get; set; }

    public bool FL_VIZINHO { get; set; }

    public string? DS_UNIDADE_VIZINHO { get; set; }

    public string? NR_TELEFONE_VIZINHO { get; set; }

    public string? DS_NOME { get; set; }

    public virtual TB_CMCRM_COMPROMISSO ID_COMPROMISSONavigation { get; set; } = null!;
}
