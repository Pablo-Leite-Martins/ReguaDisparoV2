using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_GRUPO
{
    public int ID_GRUPO { get; set; }

    public string DS_GRUPO { get; set; } = null!;

    public int? ID_SISTEMA { get; set; }

    public bool FL_ATIVO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public bool? FL_GERENCIAR_PRODUTOS { get; set; }

    public bool? FL_ANALISAR_CREDITO { get; set; }

    public virtual TB_CMC_SISTEMA? ID_SISTEMANavigation { get; set; }

    public virtual ICollection<TB_CMC_GRUPO_FUNCAO> TB_CMC_GRUPO_FUNCAOs { get; set; } = new List<TB_CMC_GRUPO_FUNCAO>();

    public virtual ICollection<TB_CMC_GRUPO_MODULO> TB_CMC_GRUPO_MODULOs { get; set; } = new List<TB_CMC_GRUPO_MODULO>();

    public virtual ICollection<TB_CMC_GRUPO_TELA> TB_CMC_GRUPO_TELAs { get; set; } = new List<TB_CMC_GRUPO_TELA>();

    public virtual ICollection<TB_CMC_GRUPO_USUARIO> TB_CMC_GRUPO_USUARIOs { get; set; } = new List<TB_CMC_GRUPO_USUARIO>();
}
