using System;
using System.Collections.Generic;

namespace Subir_Archivo_API.Models;

public partial class Archivo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public double Tamaño { get; set; }

    public string Ubicacion { get; set; } = null!;
}
