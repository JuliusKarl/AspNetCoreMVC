using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks() {
            return DataSource();
        }
        public BookModel GetBookById(int id) {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string authorName) {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }
        private List<BookModel> DataSource() {
            return new List<BookModel>() {
                new BookModel(){ Id=1, Title="Angular", Author="Julius Macrohon", Description="Managing user experience design of Athena at the University of Auckland.", Category="Front End Development", Pages=69, Language="English"},
                new BookModel(){ Id=2, Title="Spring Boot", Author="Gillian Ng", Description="Building and migrating new API's to updated cloud server.", Category="Back End Development", Pages=420, Language="Chinese"},
                new BookModel(){ Id=3, Title="Java", Author="Joel Clarke", Description="Printing service management allocating independent departmental control", Category="Back End Security", Pages=999, Language="English"},
                new BookModel(){ Id=4, Title="Angular & Ionic", Author="Yang Cui", Description="Grade conversion for international applicants.", Category="Full Stack Development", Pages=12345, Language="Chinese"},
                new BookModel(){ Id=5, Title="Angular & Ionic", Author="Cole Maguire", Description="I forgot what Cole was doing but he has a nice beard. sPrInGbEuAt", Category="Full Stack Development", Pages=0, Language="English"}
            };
        }
    }
}
