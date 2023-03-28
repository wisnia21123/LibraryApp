using LibraryApp.Data;
using LibraryApp.Entities;
using LibraryApp.Repositories;
using LibraryApp.Repositories.Extensions;

var bookRepository = new SqlRepository<Book>(new LibraryDbContext(), BookAdded);
bookRepository.ItemAdded += BookRepositoryOnItemAdded;

static void BookRepositoryOnItemAdded(object? sender, Book e)
{
    Console.WriteLine($"Book added => {e.Title} - Date:{DateTime.UtcNow} from {sender?.GetType().Name}");
    var auditFile = File.AppendText(@"auditBook.txt");
    using (auditFile)
    {
        auditFile.WriteLine($"{DateTime.UtcNow} Added book: {e}");
        auditFile.Dispose();
    }
}

static void BookRepostoryOnItemRemove(object? sender, Book e)
{
    Console.WriteLine($"Book remove => {e.Title}- Date:{DateTime.UtcNow} from  {sender?.GetType().Name}");
}

AddBooks(bookRepository);
WriteAllToConsole(bookRepository);

static void BookAdded(Book item)
{
    Console.WriteLine($"{item.Title} added");
}

static void AddClients(IRepository<Client> bookRepository)
{
    var books = new[]
    {
        new Client { FirstName = "Sara" },
        new Client { FirstName = "Maks" },
    };

    bookRepository.AddBatch(books);
}

static void AddBooks(IRepository<Book> clientRepository)
{
    var clients = new[]
    {
        new Book { Title = "Stary człowiek i morze", Author = "Ernest Hemingway", PublicationYear = 1986, ProductsAvailable = "5", Price = 10.5m },
        new Book { Title = "Alicja w krainie czarów", Author = "C.K. Lewis", PublicationYear = 1998, ProductsAvailable = "1", Price = 20.99m },
        new Book { Title = "Lalka", Author = "Bolesław Prus", PublicationYear = 2002, ProductsAvailable = "3", Price = 15 },
    };

    clientRepository.AddBatch(clients);
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}



//----------------------------------------------------------------------------------------------------------------------------------------------------------------------

//static void RemoveEntity(SqlRepository<Book> repository, int id)
//{
//    var itemToRemove = repository?.GetById(id);
//    if (itemToRemove is not null)
//    {
//        repository?.Remove(itemToRemove);
//        repository?.Save();
//    }
//    else
//    {
//        Console.WriteLine("There is no item to remove");
//    }
//}








//static void BookRepositoryOnItemAdded(object? sender, Book e)
//{
//    Console.WriteLine($"Book added =>{e.Title} from {sender?.GetType().Name}");
//}



//bookRepository.AddBatch(books);

//AddBatch(bookRepository,books);

//static void AddBatch<T>(IRepository<T> repository, T[] items) where T : class, IEntity
//{
//    foreach (var item in items)
//    {
//        repository.Add(item);
//    }

//    repository.Save();
//}







//bookRepository.Add(new Book { Title = "Stary człowiek i morze", Author = "Ernest Hemingway", PublicationYear = 1986, ProductsAvailable = "5", Price = 10.5m });
//bookRepository.Add(new Book { Title = "Alicja w krainie czarów", Author = "C.K. Lewis", PublicationYear = 1998, ProductsAvailable = "1", Price = 20.99m });
//bookRepository.Add(new Book { Title = "Lalka", Author = "Bolesław Prus", PublicationYear = 2002, ProductsAvailable = "3", Price = 15 });
//bookRepository.Save();





//new Book { Title = "Stary człowiek i morze", Author = "Ernest Hemingway", PublicationYear = 1986, ProductsAvailable = "5", Price = 10.5m },
//        new Book { Title = "Alicja w krainie czarów", Author = "C.K. Lewis", PublicationYear = 1998, ProductsAvailable = "1", Price = 20.99m },
//        new Book { Title = "Lalka", Author = "Bolesław Prus", PublicationYear = 2002, ProductsAvailable = "3", Price = 15 },



