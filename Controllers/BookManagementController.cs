using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers;

using Bookish.Models;

public class BookManagement : Controller
{
    // public IActionResult Index()
    // {
    //      var booksList = new BooksCatalog().BooksList;
    //     return View(booksList);
    // }
    public IActionResult Index(int page = 0)
    {
        const int PageSize = 20;
        var booksList = new BooksCatalog().BooksList;
        var count = booksList.Count();
        Console.WriteLine($"****************{count}");
        var booksData = booksList.Skip(page * PageSize).Take(PageSize).ToList();
        ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
        ViewBag.Page = page;
        return View(booksData);
    }

    public IActionResult Search()
    {
        return View();
    }
}


// var Book1 = new Book
// {
//     ISBN = "0195153448",
//     BookTitle = "Classical Mythology",
//     BookAuthor = "Mark P. O. Morford",
//     YearOfPublication = 2002,
//     Publisher = "Oxford University Press",
//     ImageUrlS = "http://images.amazon.com/images/P/0195153448.01.THUMBZZZ.jpg",
//     ImageUrlM = "http://images.amazon.com/images/P/0195153448.01.MZZZZZZZ.jpg",
//     ImageUrlL = "http://images.amazon.com/images/P/0195153448.01.LZZZZZZZ.jpg"
// };

// var book2 = new Book
// {
//     ISBN = "0002005018",
//     BookTitle = "Clara Callan",
//     BookAuthor = "Richard Bruce Wright",
//     YearOfPublication = 2003,
//     Publisher = "HarperFlamingo Canada",
//     ImageUrlS = "http://images.amazon.com/images/P/0002005018.01.THUMBZZZ.jpg",
//     ImageUrlM = "http://images.amazon.com/images/P/0002005018.01.MZZZZZZZ.jpg",
//     ImageUrlL = "http://images.amazon.com/images/P/0002005018.01.LZZZZZZZ.jpg"
// };
// var book3 = new Book
// {
//     ISBN = "0060973129",
//     BookTitle = "Decision in Normandy",
//     BookAuthor = "Carlo D'Este",
//     YearOfPublication = 2004,
//     Publisher = "HarperPerennial",
//     ImageUrlS = "http://images.amazon.com/images/P/0060973129.01.THUMBZZZ.jpg",
//     ImageUrlM = "http://images.amazon.com/images/P/0060973129.01.MZZZZZZZ.jpg",
//     ImageUrlL = "http://images.amazon.com/images/P/0060973129.01.LZZZZZZZ.jpg"
// };

// List<Book> Booklist = [Book1, book2, book3];
