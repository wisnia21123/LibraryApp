namespace LibraryApp.Entities
{
    public class Book: EntityBase
    {
        public Book()
        {
            
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ProductsAvailable { get; set; }
        public decimal Price { get; set; }

        public override string ToString()=>$"Id:{Id}, Title:{Title}, Author:{Author}, PublicationYear:{PublicationYear}, ProductsAvailable:{ProductsAvailable}, Price:{Price},";

    }
}
