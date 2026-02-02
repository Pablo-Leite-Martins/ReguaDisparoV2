using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG
{
    public int ID_CASO_COBRANCA_REGUA_CONFIG { get; set; }

    public int? ID_CONTA_EMAIL_ENVIO { get; set; }

    public string? DS_EMAIL_RECEPTIVO_TESTE { get; set; }

    public string? NR_HORA_INICIAL { get; set; }

    public string? NR_HORA_FINAL { get; set; }

    public int? ID_SERVICO_SMS { get; set; }

    public string? DS_USUARIO_SMS { get; set; }

    public string? DS_SENHA_SMS { get; set; }

    public string? NR_TELEFONE_RECEPTIVO_TESTE { get; set; }

    public int? ID_CASO_COBRANCA_REGUA { get; set; }

    public string? DS_EMAIL_COPIA_OCULTA { get; set; }

    public string? DS_ID_AGRUPAMENTO { get; set; }

    public int? NR_MAX_EMAIL { get; set; }

    public int? NR_MAX_SMS { get; set; }

    public string? DS_TOKEN_SMS { get; set; }
}
