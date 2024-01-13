using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestwithASPNETUdemy.Model;
using RestwithASPNETUdemy.Model.Context;
using RestwithASPNETUdemy.Repository;
using System;

namespace RestwithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }
        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
