using System;
using System.Collections.Generic;
using System.Linq;
using Livros.Models;
using Livros.Data;
using Microsoft.AspNetCore.Mvc;

namespace Livros.Controllers{

    // Rota para usa da classe
    [ApiController]
    [Route("livros/livrosestante")]
    public class LivrosController : ControllerBase{

        private readonly DataContext _context;
        
        public LivrosController(DataContext context) => _context = context;

        //POST: livros/livrosestante/iniciar
        [HttpPost]
        [Route("iniciar")]
        //Método para inclusão de livros
        public IActionResult LivrosInclude(){
            AdicionarLivros(_context, 1, "Crime e Castigo", "Fiódor Dostóievski", "Romance", 1866);
            AdicionarLivros(_context, 2, "Boneco de neve", "Jo Nesbo", "Suspense", 2007);
            AdicionarLivros(_context, 3, "O iluminado", "Stephen King", "Terror", 1977);
            AdicionarLivros(_context, 4, "Grau 26", "Antonie E. Zuiker", "Suspense", 2009);
            AdicionarLivros(_context, 5, "Palavras para desatar nós", "Rubem Alves","Crônicas", 2012); 

            _context.SaveChanges();   

            return Ok();       
        }
        private static void AdicionarLivros(DataContext _context, int id, string titulo, string autor, string genero, int ano){
            _context.Livro.Add( new Models.Livro(){
                Id = id,
                Titulo = titulo,
                Autor = autor,
                Genero = genero,
                Ano = ano
            });
        }

        // GET: livros/livrosestante/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult ListLivros() => Ok(_context.Livro.ToList());

        // POST: livros/livrosestante/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Livro livro) {           
                _context.Livro.Add(livro);
                _context.SaveChanges();
                return Created("", livro);
        }

    }
}