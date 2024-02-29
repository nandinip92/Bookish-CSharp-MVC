namespace Bookish.Models;

public class Book{
    public required string ISBN{get;set;}
    public required string BookTitle{get;set;}
    public required string BookAuthor{get;set;}	
    public required int YearOfPublication{get;set;}	
    public required string Publisher{get;set;}	
    public required string ImageUrlS{get;set;}	
    public required string ImageUrlM{get;set;}	
    public required string ImageUrlL{get;set;}

}