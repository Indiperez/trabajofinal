using System;
using System.Collections.Generic;

namespace VetClinic.Models;

public partial class Cita
{
    public int IdCita { get; set; }

    public DateTime FechaHora { get; set; }

    public string? Motivo { get; set; }

    public int IdMascota { get; set; }

    public virtual Mascota IdMascotaNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
