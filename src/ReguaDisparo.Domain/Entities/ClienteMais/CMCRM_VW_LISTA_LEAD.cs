using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_LISTA_LEAD
{
    public int ID_CONTA { get; set; }

    public string DS_NOME { get; set; } = null!;

    public int ID_TIPO_CONTA { get; set; }

    public int? ID_USUARIO_PROPRIETARIO { get; set; }

    public int? ID_USUARIO_CADASTRO { get; set; }

    public int? ID_ORIGEM_LEAD { get; set; }

    public string? NR_CPF { get; set; }

    public string? DS_EMAIL { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }

    public string? DS_ORIGEM_LEAD_COMP { get; set; }

    public int? ID_CASO { get; set; }

    public DateTime? DT_FIM_CASO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public string? DS_ETAPA_TIPO_CASO { get; set; }

    public int? ID_USUARIO_CASO { get; set; }

    public int? ID_PRODUTO_VENDA { get; set; }

    public string? DS_PRODUTO_VENDA { get; set; }

    public string? ID_CHAVE_ERP_CONTA_PRODUTO { get; set; }

    public string? NR_TELEFONE { get; set; }

    public string? DS_PRODUTO { get; set; }

    public int? ID_PRODUTO_INTERESSE { get; set; }

    public string? DS_USUARIO_PROPRIETARIO { get; set; }

    public int? ID_GERENTE_PROPRIETARIO { get; set; }

    public int? ID_COORDENADOR_VENDAS_PROPRIETARIO { get; set; }

    public int? ID_GERENTE_REGIONAL_PROPRIETARIO { get; set; }

    public int? ID_GERENTE_COMERCIAL_PROPRIETARIO { get; set; }

    public int? ID_SUPERINTENDENTE_PROPRIETARIO { get; set; }

    public int? ID_DIRETOR_PROPRIETARIO { get; set; }

    public int? ID_COORDENADOR_MARKETING_PROPRIETARIO { get; set; }

    public int? ID_EQUIPE_VENDAS { get; set; }

    public string? DS_EQUIPE_VENDAS { get; set; }

    public int? ID_GERENTE_RESPONSAVEL { get; set; }

    public string? DS_NOME_GERENTE_RESPONSAVEL { get; set; }

    public string? DS_USUARIO_CADASTRO { get; set; }

    public string? DS_USUARIO_CASO { get; set; }

    public string? DS_STATUS_ETAPA { get; set; }
}
