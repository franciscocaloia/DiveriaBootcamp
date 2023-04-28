namespace webapi
{

    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Beer(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
    }
}