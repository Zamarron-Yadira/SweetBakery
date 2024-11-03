using System;
using System.Collections.Generic;

namespace SweetBakery.Models.Entities;

public partial class Productos
{
    public int Id { get; set; }

    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual Categorias IdCategoriaNavigation { get; set; } = null!;
}
