using RepoApi.Data.Entities;
using RepoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Book, int> BookRepository { get; set; } //generic-den gelen
        public ILibraryRepository LibraryRepository { get; set; } //ozel metodu olan
        public Task Commit();
    }
}
