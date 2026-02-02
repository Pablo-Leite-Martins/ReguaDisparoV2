using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_CONFIRMACAO_CADASTRAL
{
    public int ID_CONFIRMACAO_CADASTRAL { get; set; }

    public string DS_LOGIN { get; set; } = null!;

    public string DS_NOME { get; set; } = null!;

    public string DS_EMAIL { get; set; } = null!;

    public string DS_SENHA { get; set; } = null!;

    public string ID_ORGANIZACAO { get; set; } = null!;

    public string? DS_CPF { get; set; }

    public string? DS_RG { get; set; }

    public string? DS_CRECI { get; set; }

    public bool? FL_ATIVO { get; set; }

    public int? ID_RESPONSAVEL_ATIVACAO { get; set; }

    public DateTime? DT_ATIVACAO { get; set; }

    public int? ID_EQUIPE_VENDAS { get; set; }

    public string? NR_TELEFONE { get; set; }

    public virtual TB_CMC_USUARIO? ID_RESPONSAVEL_ATIVACAONavigation { get; set; }
}
