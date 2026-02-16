using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_ALCADA
{
    public int ID_ALCADA { get; set; }

    public string? DS_ALCADA { get; set; }

    public string? DS_CATEGORIA_ALCADA { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public int ID_SISTEMA { get; set; }

    public virtual TB_CMC_SISTEMA ID_SISTEMANavigation { get; set; } = null!;

    public virtual ICollection<TB_CMC_ALCADA_CONFIGURACAO> TB_CMC_ALCADA_CONFIGURACAOs { get; set; } = new List<TB_CMC_ALCADA_CONFIGURACAO>();
}
