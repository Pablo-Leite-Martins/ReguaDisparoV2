using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SERASA_DADOS_API
{
    public int ID_SERASA_DADOS_API { get; set; }

    public string? NR_CNPJ { get; set; }

    public string? DS_USUARIO { get; set; }

    public string? DS_SENHA { get; set; }
}
