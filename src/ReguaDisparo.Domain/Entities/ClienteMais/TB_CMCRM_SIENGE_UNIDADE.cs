using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_UNIDADE
{
    public int ID_UNIDADE { get; set; }

    public int? id { get; set; }

    public int? enterpriseId { get; set; }

    public string? name { get; set; }

    public string? propertyType { get; set; }

    public string? note { get; set; }

    public string? commercialStock { get; set; }

    public string? latitude { get; set; }

    public string? longitude { get; set; }

    public string? legalRegistrationNumber { get; set; }

    public string? deliveryDate { get; set; }

    public decimal? commonArea { get; set; }

    public decimal? terrainArea { get; set; }

    public decimal? nonProportionalCommonArea { get; set; }

    public decimal? idealFraction { get; set; }

    public decimal? generalSaleValueFraction { get; set; }

    public decimal? indexedQuantity { get; set; }

    public decimal? terrainValue { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
