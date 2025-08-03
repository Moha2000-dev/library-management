using System;
using library_management;
using library_management.Models;
using library_management.Repositories;
using library_management.Services;

class Program
{
    static void Main()
    {
        var context = new FileContext();
        var bookRepo = new BookRepository(context);
        var memberRepo = new MemberRepository(context);
        var recordRepo = new BorrowRecordRepository(context);
        ILibraryService library = new LibraryService(bookRepo, memberRepo, recordRepo);

        while (true)
        {
            Console.Clear();
            Console.ResetColor();
            //Title
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                     YANQULE LIBRARY                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            //Menu
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║               MAIN MENU                      ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Register Member                           ║");
            Console.WriteLine("║ 2. Add Book                                  ║");
            Console.WriteLine("║ 3. Borrow Book                               ║");
            Console.WriteLine("║ 4. Return Book                               ║");
            Console.WriteLine("║ 5. View All Books                            ║");
            Console.WriteLine("║ 6. Exit                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("👉 Choose an option (1–6): ");
            string choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(" Register Member");
                    Console.Write("Enter Member ID: ");
                    string memberId = Console.ReadLine();
                    Console.Write("Enter Member Name: ");
                    string memberName = Console.ReadLine();
                    var member = new Member { Id = memberId, Name = memberName };
                    library.RegisterMember(member);
                    Console.WriteLine(" Member registered successfully.");
                    break;

                case "2":
                    Console.WriteLine(" Add Book");
                    Console.Write("Enter Book ID: ");
                    string bookId = Console.ReadLine();
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    var book = new Book { Id = bookId, Title = title, Author = author };
                    library.AddBook(book);
                    Console.WriteLine(" Book added successfully.");
                    break;

                case "3":
                    Console.WriteLine(" Borrow Book");
                    Console.Write("Enter Book ID: ");
                    string borrowBookId = Console.ReadLine();
                    Console.Write("Enter Member ID: ");
                    string borrowerId = Console.ReadLine();
                    library.BorrowBook(borrowBookId, borrowerId);
                    break;

                case "4":
                    Console.WriteLine(" Return Book");
                    Console.Write("Enter Book ID: ");
                    string returnBookId = Console.ReadLine();
                    Console.Write("Enter Member ID: ");
                    string returnerId = Console.ReadLine();
                    library.ReturnBook(returnBookId, returnerId);
                    break;

                case "5":
                    Console.WriteLine(" List of Books:");
                    foreach (var b in bookRepo.GetAll())
                    {
                        Console.WriteLine($"- {b.Id}: {b.Title} by {b.Author} — {(b.IsAvailable ? "Available" : "Borrowed")}");
                    }
                    break;

                case "6":
                    Console.WriteLine(" Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\n Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
