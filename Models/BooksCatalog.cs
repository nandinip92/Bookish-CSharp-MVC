using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Bookish.Models;

public class BooksCatalog
{
    public List<Book> BooksList { get; private set; } = [];
    public Dictionary<string, Book> BooksLookup { get; private set; } = [];

    public BooksCatalog()
    {
        ReadBooksDataFromCSVFile("Data/BooksTest.csv");
    }

    public void ReadBooksDataFromCSVFile(string fileName)
    {
        try
        {
            using var fileReader = new StreamReader(fileName);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ReadingExceptionOccurred = args =>
                {
                    if (args.Exception is TypeConverterException)
                    {
                        // _logger.LogWarning($"Bad Record Found {args.Exception.Context.Parser.RawRecord}");
                        return false;
                    }
                    return true;
                }
            };
            using var csvData = new CsvReader(fileReader, csvConfig);
            foreach (var book in csvData.GetRecords<Book>())
            {
                BooksList.Add(book);
                BooksLookup[book.BookTitle] = book;
            }
            Console.WriteLine("Loaded the Books Data.........");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Sorry, {fileName} was not found");
        }
        // } catch (IOException)
        // {
        //     Console.WriteLine(
        //         $"Sorry cannot open {fileName}, Please close the file if it is open in another process."
        //     );
        // }
    }

    public Book? SearchBook(string title)
    {
        if (BooksLookup.ContainsKey(title))
        {
            return BooksLookup[title];
        }
        return null;
    }
    // public T SearchBook<T>(string title)
    //     if(BooksLookup.ContainsKey(title)){
    //         return BooksLookup[title];
    //     }
    //     return "No Book Found";
    // }
}
