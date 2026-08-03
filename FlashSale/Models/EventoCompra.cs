using System;

namespace FlashSale.Models
{
    public class EventoCompra
    {
        public string Id { get; set; }

        public string ProductoId { get; set; }

        public string ClienteId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public string Categoria { get; set; }

        public DateTime FechaHora { get; set; }

        public string Estado { get; set; }
    }
}
