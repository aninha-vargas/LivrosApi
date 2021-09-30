using Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Livros.Data {
    public class DataContext : DbContext {
        public DataContext()
        {
        }

        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options){}  

        //Lista de propriedades das classes que vão virar tabelas no banco
        public DbSet<Livro> Livro {get; set;}

    }
}