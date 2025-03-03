using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBDD.Models;

[Table("Usuario")]
[Index("Email", Name = "UQ__Usuario__AB6E61649CB31F21", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("apellido")]
    [StringLength(50)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("telefono")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
