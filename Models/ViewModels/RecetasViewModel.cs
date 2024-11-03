namespace SweetBakery.Models.ViewModels
{
    public class RecetasViewModel
    {
        public IEnumerable<RecetaModel> Recetas { get; set; } = null!;
    }

    public class RecetaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
