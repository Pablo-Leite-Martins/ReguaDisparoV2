using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TECNICO_CATEGORIA_ATENDIMENTO
{
    public int ID_TECNICO_CATEGORIA_ATENDIMENTO { get; set; }

    public int ID_USUARIO { get; set; }

    public string? DS_USUARIO { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public string? DS_CATEGORIA_ATENDIMENTO { get; set; }
}
