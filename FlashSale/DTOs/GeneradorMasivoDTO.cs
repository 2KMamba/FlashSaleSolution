namespace FlashSale.DTOs
{
    public class GeneradorMasivoDTO
    {
        public string ProductoId { get; set; } = string.Empty;

        public string Modo { get; set; } = "Individual";

        public int CantidadEventos { get; set; }

        public int CantidadPorCompra { get; set; }
    }
}
