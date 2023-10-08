namespace PlantNursery.Models
{
    public class CartItem
    {
        public CartItem()
        {
        }
        public CartItem(Plants plant)
        {
            PlantId = plant.PlantId;
            PlantName = plant.PlantName;
            Price = plant.Price;
            Quantity = 1;
        }
        public string PlantId { get; set; }
        public string PlantName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total
        {
            get { return Quantity* Price; }
        }
    }
}
