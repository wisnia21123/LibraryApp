namespace LibraryApp.Entities
{
    public class Client : EntityBase
    {
        public string? Name { get; set; }
        public override string ToString() => $"Id:{Id}, Name:{ Name }";
    }
}
