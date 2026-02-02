using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_2024_03_26
{
    public int ID_PRODUTO { get; set; }

    public string DS_PRODUTO { get; set; } = null!;

    public int ID_CLASSIFICACAO_PRODUTO { get; set; }

    public int? ID_PRODUTO_PAI { get; set; }

    public string? DS_PRODUTO_COMP { get; set; }

    public int? ID_ESTADO { get; set; }

    public int? ID_CIDADE { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public DateTime? DT_INICIO_GARANTIA { get; set; }

    public string? DS_PAIS { get; set; }

    public string? DS_ESTADO { get; set; }

    public string? DS_CIDADE { get; set; }

    public string? DS_BAIRRO { get; set; }

    public string? DS_LOGRADOURO { get; set; }

    public string? DS_CEP { get; set; }

    public int? NR_NUMERO { get; set; }

    public int? ID_LUGAR { get; set; }

    public string? DS_STATUS { get; set; }

    public int? NR_QUARTOS { get; set; }

    public int? NR_VAGAS { get; set; }

    public int? NR_QUADRAS { get; set; }

    public string? NR_QUADRA { get; set; }

    public int? NR_ANDARES { get; set; }

    public int? NR_ANDAR { get; set; }

    public string? DS_BLOCO { get; set; }

    public string? DS_TORRE { get; set; }

    public decimal? VL_METROS_QUADRADOS { get; set; }

    public decimal? VL_FRACAO_IDEAL { get; set; }

    public decimal? VL_PRECO { get; set; }

    public int? ID_TIPO_PRODUTO { get; set; }

    public string? DS_SPE_NOME { get; set; }

    public string? NR_SPE_CNPJ { get; set; }

    public string? DS_SPE_TELEFONE { get; set; }

    public string? DS_SPE_EMAIL { get; set; }

    public string? DS_SPE_PAIS { get; set; }

    public string? DS_SPE_ESTADO { get; set; }

    public string? DS_SPE_CIDADE { get; set; }

    public string? DS_SPE_BAIRRO { get; set; }

    public string? DS_SPE_LOGRADOURO { get; set; }

    public string? DS_SPE_CEP { get; set; }

    public int? NR_SPE_NUMERO { get; set; }

    public string? ID_SPE_LUGAR { get; set; }

    public string? NR_ALVARA { get; set; }

    public DateTime? DT_PREVISAO_CONCLUSAO { get; set; }

    public string? DS_REGISTRO_INCORPORACAO { get; set; }

    public string? DS_FICHA_TECNICA { get; set; }

    public DateTime? DT_RESERVA_FIM { get; set; }

    public int? ID_RESERVA_USUARIO { get; set; }

    public int? ID_RESERVA_CONTA { get; set; }

    public string? DS_VAGAS { get; set; }

    public decimal? VL_AVALIACAO_CAIXA { get; set; }

    public string? DS_MATRICULA_IMOVEL { get; set; }

    public DateTime? DT_RESERVA_INICIO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public string? DS_SPE_COMPLEMENTO { get; set; }

    public bool? FL_PRODUTO_ATIVO_VENDAS { get; set; }

    public string? NR_MATRICULA { get; set; }

    public string? ID_CHAVE_ERP_PRODUTO { get; set; }

    public string? ID_CHAVE_ERP_CONTRATO { get; set; }

    public string? DS_CAMINHO_IMAGEM_LOGO { get; set; }

    public string? DS_BONIFICACAO { get; set; }

    public DateTime? DT_INICIO_BONIFICACAO { get; set; }

    public DateTime? DT_FIM_BONIFICACAO { get; set; }

    public decimal? VL_AREA_PRIVATIVA { get; set; }

    public decimal? VL_AREA_COMUM { get; set; }

    public DateTime? DT_HABITESE { get; set; }

    public bool? FL_MIRROR { get; set; }

    public decimal? VL_PERCENTUAL_EMPRESA { get; set; }

    public decimal? VL_PERCENTUAL_TERRENEIRO { get; set; }

    public string? DS_IMAGEM_IMPLANTACAO { get; set; }

    public decimal? VL_IMAGEM_IMPLANTACAO_MARGEM_VERTICAL { get; set; }

    public decimal? VL_IMAGEM_IMPLANTACAO_MARGEM_HORIZONTAL { get; set; }

    public int? ID_CHAVE_ERP_PERSONALIZACAO { get; set; }

    public string? DS_TIPO_GARANTIA { get; set; }

    public string? DS_TAG_IMPORTACAO { get; set; }

    public int? NR_RESERVA_HORAS { get; set; }

    public string? NR_PRODUTO { get; set; }

    public string? DS_LOGRADOURO_PRODUTO { get; set; }

    public decimal? VL_MEDIDA_FRENTE { get; set; }

    public decimal? VL_MEDIDA_FUNDOS { get; set; }

    public decimal? VL_MEDIDA_DIREITA { get; set; }

    public decimal? VL_MEDIDA_ESQUERDA { get; set; }

    public string? DS_CONFRONTANTE_FRENTE { get; set; }

    public string? DS_CONFRONTANTE_FUNDOS { get; set; }

    public string? DS_CONFRONTANTE_DIREITA { get; set; }

    public string? DS_CONFRONTANTE_ESQUERDA { get; set; }

    public bool? FL_RESERVA_ESPELHO { get; set; }

    public decimal? VL_IPTU { get; set; }

    public decimal? VL_CONDOMINIO { get; set; }

    public bool? FL_MANTER_STATUS { get; set; }

    public int? NR_TAMANHO_PIXEL_MAPA { get; set; }

    public int? NR_TAMANHO_FONTE_MAPA { get; set; }

    public string? DS_INFO_HABITESE { get; set; }

    public string? DS_ESCANINHO { get; set; }

    public decimal? VL_ESCANINHO { get; set; }

    public decimal? VL_ACESSAO { get; set; }

    public bool? FL_PRODUTO_ATIVO_VISTORIA { get; set; }

    public string? DS_CIDADE_COMARCA { get; set; }

    public int? NR_VAGAS_PCD { get; set; }

    public decimal? VL_METRAGEM_UNIDADE { get; set; }

    public int? ID_ETAPA_JORNADA { get; set; }

    public DateTime? DT_ENTREGA_CHAVES { get; set; }

    public DateTime? DT_RAI { get; set; }

    public DateTime? DT_DEMANDA_MININA { get; set; }
}
