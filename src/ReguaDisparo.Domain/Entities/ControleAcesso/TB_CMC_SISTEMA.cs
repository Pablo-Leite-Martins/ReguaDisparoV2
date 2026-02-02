using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_SISTEMA
{
    public int ID_SISTEMA { get; set; }

    public string DS_NOME_SISTEMA { get; set; } = null!;

    public string DS_DESCRICAO { get; set; } = null!;

    public virtual ICollection<TB_CMC_ALCADum> TB_CMC_ALCADa { get; set; } = new List<TB_CMC_ALCADum>();

    public virtual ICollection<TB_CMC_FUNCAO> TB_CMC_FUNCAOs { get; set; } = new List<TB_CMC_FUNCAO>();

    public virtual ICollection<TB_CMC_GRUPO> TB_CMC_GRUPOs { get; set; } = new List<TB_CMC_GRUPO>();

    public virtual ICollection<TB_CMC_MODULO_PRODUCAO> TB_CMC_MODULO_PRODUCAOs { get; set; } = new List<TB_CMC_MODULO_PRODUCAO>();

    public virtual ICollection<TB_CMC_TELA> TB_CMC_TELAs { get; set; } = new List<TB_CMC_TELA>();
}
