using System;
using System.Collections.Generic;

namespace VetClinic.Domain;

public partial class Tratamiento
{
    public int IdTratamiento { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Costo { get; set; }
}
