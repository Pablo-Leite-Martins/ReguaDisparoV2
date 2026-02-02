using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL_BLACKLIST
{
    public int ID_EMAIL_BLACKLIST { get; set; }

    public string DS_EMAIL { get; set; } = null!;
}
