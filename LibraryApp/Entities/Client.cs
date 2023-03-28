namespace LibraryApp.Entities
{
    public class Client : EntityBase
    {
        public string? FirstName { get; set; }
        public override string ToString() => $"Id:{Id}, Name:{ FirstName }";
    }
}
