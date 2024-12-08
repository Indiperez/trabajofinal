using System;
using System.Collections.Generic;

namespace VetClinic.Models;

public partial class Mascota
{
    public int IdMascota { get; set; }

    public string Nombre { get; set; } 

    public string Especie { get; set; } 

    public string? Raza { get; set; }

    public int? Edad { get; set; }

    public decimal? Peso { get; set; }

    public int IdDueño { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Dueño IdDueñoNavigation { get; set; }
}
