namespace SweetBakery.Models.ViewModels
{
    public class ProductosViewModel
    {
     
        public string Categoria { get; set; } = null!;
        public IEnumerable<PostreModel> Postres { get; set; } = null!;
    }

    public class PostreModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }

}
