using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_TELA
{
    public int ID_TELA { get; set; }

    public string DS_NOME_TELA { get; set; } = null!;

    public string DS_URL_TELA { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public int ID_SISTEMA { get; set; }

    public int? ID_TELA_PAI { get; set; }

    public bool FL_MENU_ATIVO { get; set; }

    public bool FL_NOVA_TELA { get; set; }

    public int NR_ORDEM { get; set; }

    public string? DS_DESCRICAO_TELA { get; set; }

    public virtual TB_CMC_SISTEMA ID_SISTEMANavigation { get; set; } = null!;

    public virtual TB_CMC_TELA? ID_TELA_PAINavigation { get; set; }

    public virtual ICollection<TB_CMC_TELA> InverseID_TELA_PAINavigation { get; set; } = new List<TB_CMC_TELA>();

    public virtual ICollection<TB_CMC_GRUPO_TELA> TB_CMC_GRUPO_TELAs { get; set; } = new List<TB_CMC_GRUPO_TELA>();
}
