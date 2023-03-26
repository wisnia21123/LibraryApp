namespace LibraryApp.Entities
{
    public class Employee : Book
    {
        public override string ToString() => base.ToString() + "( Employee )";
    }
}
