namespace library_management
{
    using library_management.Repositories;
    using library_management.Services;
    using Models;

    class Program
    {
        static void Main()
        {
            var context = new FileContext();

            var bookRepo = new BookRepository(context);
            var memberRepo = new MemberRepository(context);
            var recordRepo = new BorrowRecordRepository(context);

            ILibraryService library = new LibraryService(bookRepo, memberRepo, recordRepo);

            var member = new Member { Id = "1", Name = "Mohammed" };
            library.RegisterMember(member);

            var book = new Book { Id = "B1", Title = "C# Basics", Author = "Ahmed" };
            library.AddBook(book);

            library.BorrowBook("B1", "1");
            library.ReturnBook("B1", "1");
        }
    }

}
