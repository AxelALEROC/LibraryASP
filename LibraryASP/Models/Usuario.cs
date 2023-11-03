using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryASP.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;
 
    public string Email { get; set; } = null!;

    public string Passwd { get; set; } = null!;

    public string? Direccion { get; set; } = null!;

    public string? Telefono { get; set; } = null!;

    public string? Rol { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
