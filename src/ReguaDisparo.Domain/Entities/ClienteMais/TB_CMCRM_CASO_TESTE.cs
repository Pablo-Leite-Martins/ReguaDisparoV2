using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_TESTE
{
    public int ID_CASO { get; set; }

    public string DS_CASO { get; set; } = null!;

    public int? ID_PRODUTO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int ID_TIPO_CANAL_ATENDIMENTO { get; set; }

    public bool FL_CASO_RECORRENTE { get; set; }

    public int? ID_TIPO_RECORRENCIA { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public int ID_TIPO_CASO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public bool FL_GARANTIA { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public int ID_CONTA { get; set; }

    public int? ID_CONTATO { get; set; }

    public bool? FL_NAO_PROCEDENTE { get; set; }

    public int? ID_MOTIVO_CANCELAMENTO { get; set; }

    public int? ID_MOTIVO_NAO_PROCEDENCIA { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public bool? FL_SINCRONIZADO { get; set; }

    public int? NUM_ATENDIMENTO_UAU { get; set; }

    public int? ID_SUBCATEGORIA_ATENDIMENTO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL_ACOMPANHAMENTO { get; set; }

    public int? ID_TIPO_PESO_ATENDIMENTO { get; set; }
}
