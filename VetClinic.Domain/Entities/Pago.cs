using System;
using System.Collections.Generic;

namespace VetClinic.Domain;

public partial class Pago
{
    public int IdPago { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal Monto { get; set; }

    public int? IdCita { get; set; }

    public virtual Cita? IdCitaNavigation { get; set; }
}
