using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO
{
    public int ID_CASO_COBRANCA_REGUA_HISTORICO_ENVIO { get; set; }

    public string? DS_EMAIL { get; set; }

    public string? COD_DDD { get; set; }

    public string? NR_TELEFONE { get; set; }

    public string? DS_PRODUTO { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public int? ID_EMPRESA { get; set; }

    public string? ID_OBRA { get; set; }

    public int? ID_VENDA { get; set; }

    public string? DS_CLIENTE { get; set; }

    public string? DS_IDENTIFICADOR { get; set; }

    public string? DS_CLASSIFICACAO_CONTRATO { get; set; }

    public int? NR_AGING_DIAS_CONTRATO { get; set; }

    public DateTime? DT_ENVIO { get; set; }

    public int? ID_CASO_COBRANCA_REGUA_ETAPA_ACAO { get; set; }

    public int? ID_DOCUMENTO_TEMPLATE { get; set; }

    public bool? FL_REGUA_VALIDADA { get; set; }

    public string? DS_CONTEUDO_ENVIADO { get; set; }

    public bool FL_EMAIL_LIDO { get; set; }
}
