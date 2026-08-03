namespace FlashSale.Models
{
    public class Producto
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public decimal Precio { get; set; }

        public int StockDisponible { get; set; }
    }
}
