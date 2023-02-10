namespace JSN_Log.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"{this.Brand} {this.Model}";
        }
    }
}
