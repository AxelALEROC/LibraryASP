using System;
using System.Collections.Generic;

namespace LibraryASP.Models;

public partial class Prestamo
{
    public int PrestamoId { get; set; }

    public int UsuarioId { get; set; }

    public int LibroId { get; set; }

    public DateTime FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public DateTime FechaEsperadaDevolucion { get; set; }

    public bool Devuelto { get; set; }

    public virtual Libro Libro { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
