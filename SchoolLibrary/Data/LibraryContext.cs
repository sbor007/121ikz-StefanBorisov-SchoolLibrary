using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Models;
using System.Collections.Generic;

namespace SchoolLibrary.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<LibraryEvent> LibraryEvents { get; set; }
    }
}
