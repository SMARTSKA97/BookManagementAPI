using BookManagementAPI.Models.Dto;

namespace BookManagementAPI.Data
{
    public static class BookStore
    {
        public static List<BookDTO> BookList = new List<BookDTO>
        {
            new BookDTO { Id = 1,Title = "Macbeth", Author = "William Shakespeare", Year=1890, Genre = "Novel"},
            new BookDTO  { Id = 2, Title = "Happy Prince", Author = "Oscar Wilde", Year=1940, Genre="Story"},
            new BookDTO {Id = 3, Title = "Hound of Baskerville", Author = "Sir Arthur Conan Doyle", Year=1890, Genre="Mystery"}
        };
    }
}