using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_CLIENTE
{
    public int ID_SIENGE_CLIENTE { get; set; }

    public int? id { get; set; }

    public string? personType { get; set; }

    public DateTime? createdAt { get; set; }

    public DateTime? modifiedAt { get; set; }

    public string? name { get; set; }

    public string? email { get; set; }

    public DateTime? birthDate { get; set; }

    public string? birthPlace { get; set; }

    public string? civilStatus { get; set; }

    public string? cpf { get; set; }

    public string? fatherName { get; set; }

    public string? sex { get; set; }

    public DateTime? issueDateIdentityCard { get; set; }

    public string? matrimonialRegime { get; set; }

    public DateTime? marriageDate { get; set; }

    public string? nationality { get; set; }

    public string? numberIdentityCard { get; set; }

    public string? motherName { get; set; }

    public string? profession { get; set; }

    public string? cityRegistrationNumber { get; set; }

    public string? cnaeNumber { get; set; }

    public string? cnpj { get; set; }

    public string? contactName { get; set; }

    public string? creaNumber { get; set; }

    public DateTime? establishmentDate { get; set; }

    public string? fantasyName { get; set; }

    public string? note { get; set; }

    public string? site { get; set; }

    public decimal? shareCapital { get; set; }

    public string? stateRegistrationNumber { get; set; }

    public string? technicalManager { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
