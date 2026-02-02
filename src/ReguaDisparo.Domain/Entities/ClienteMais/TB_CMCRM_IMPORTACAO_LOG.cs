using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_IMPORTACAO_LOG
{
    public int ID_IMPORTACAO_LOG { get; set; }

    public string? DS_EMPREENDIMENTO { get; set; }

    public string? DS_BLOCO { get; set; }

    public string? DS_UNIDADE { get; set; }

    public string? DS_NOME { get; set; }

    public string? DS_CPF { get; set; }

    public string? DS_FIXO { get; set; }

    public string? DS_CELULAR { get; set; }

    public string? DS_COMERCIAL { get; set; }

    public string? DS_EMAIL { get; set; }

    public string? DS_CEP { get; set; }

    public double? NR_VALORVENDA { get; set; }

    public DateTime? DT_DATAVENDA { get; set; }

    public string? DS_CODPES { get; set; }

    public string? DS_OBRAVEN { get; set; }

    public string? DS_CHAVE { get; set; }

    public string? DS_OBRAPRODUTOIDENTIFICADOR { get; set; }

    public string? DS_STATENAME { get; set; }

    public string? DS_TIPOCONTA { get; set; }

    public DateTime? DT_IMPORTACAO { get; set; }

    public int? ID_USUARIO { get; set; }
}
