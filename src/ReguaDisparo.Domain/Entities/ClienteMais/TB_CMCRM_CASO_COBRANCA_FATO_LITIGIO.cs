using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_FATO_LITIGIO
{
    public int ID_CASO_COBRANCA_FATO_LITIGIO { get; set; }

    public string ID_CHAVE_ERP { get; set; } = null!;

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int ID_VENDA { get; set; }

    public DateTime DT_CONTRATO { get; set; }

    public string DS_CLIENTE { get; set; } = null!;

    public string? DS_IDENTIFICADOR { get; set; }

    public string? NR_AREA_TERRENO { get; set; }

    public decimal VL_UNIDADE { get; set; }

    public string ST_ESCRITURA { get; set; } = null!;

    public string DS_STATUS_ESCRITURA { get; set; } = null!;

    public string ST_COBRANCA { get; set; } = null!;

    public string DS_STATUS_COBRANCA { get; set; } = null!;

    public int NR_FREQUENCIA_NOVE_MESES { get; set; }

    public decimal NR_FREQUENCIA_MEDIA { get; set; }

    public int NR_RECEBIMENTO_DOIS_MESES { get; set; }

    public int NR_PARCELAS_EM_ABERTO { get; set; }

    public decimal VL_PARCELAS_EM_ABERTO { get; set; }

    public string DS_CLASSIFICACAO_CONTRATO { get; set; } = null!;

    public DateTime DT_MES_REFERENCIA { get; set; }

    public decimal? VL_RECEBIDO_VGV { get; set; }

    public decimal? VL_JUROS_ATRASO { get; set; }

    public decimal? VL_MULTA_ATRASO { get; set; }

    public decimal? VL_CORRECAO_ATRASO { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }

    public int? ID_CODIGO_LITIGIO { get; set; }
}
