namespace SweetBakery.Models.ViewModels
{
    public class RecetaViewModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ingredientes { get; set; }
        public string? Procedimiento { get; set; }
        public string? Reseña { get; set; }

        public IEnumerable<RecetaModel> Recetas { get; set; } = null!;

    }
}
