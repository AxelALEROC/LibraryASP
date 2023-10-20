using System;
using System.Collections.Generic;

namespace LibraryASP.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Editorial { get; set; } = null!;

    public int AnioPublicacion { get; set; }

    public string? Genre { get; set; }

    public int? NumPages { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
