using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_DADOS_FECHAMENTO_LOG
{
    public int ID_CASO_DADOS_FECHAMENTO_LOG { get; set; }

    public int ID_CASO_DADOS_FECHAMENTO { get; set; }

    public int? ID_CASO { get; set; }

    public DateTime? DT_INICIO { get; set; }

    public DateTime? DT_FINAL { get; set; }

    public string? DS_SERVICO_REALIZADO { get; set; }

    public string? DS_EQUIPE_UTILIZADA { get; set; }

    public string? DS_MATERIAL_UTILIZADO { get; set; }

    public int? ID_MOTIVO_PROBLEMA { get; set; }

    public int? ID_SOLUCAO_PROBLEMA { get; set; }

    public string? DS_OBSERVACAO_FINAL { get; set; }

    public decimal? VL_SERVICO_REALIZADO { get; set; }

    public decimal? VL_EQUIPE_UTILIZADA { get; set; }

    public decimal? VL_MATERIAL_UTILIZADO { get; set; }

    public string? DS_EQUIPAMENTO_UTILIZADO { get; set; }

    public decimal? VL_EQUIPAMENTO_UTILIZADO { get; set; }

    public string? DS_DESLOCAMENTO_UTILIZADO { get; set; }

    public decimal? VL_DESLOCAMENTO_UTILIZADO { get; set; }

    public string? DS_RESPONSAVEL { get; set; }

    public string? DS_RESPONSAVEL_NOME { get; set; }

    public int ID_USUARIO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public string DS_ACAO { get; set; } = null!;

    public bool FL_SUCEDIDO { get; set; }

    public string? DS_MENSAGEM_ERRO { get; set; }
}
