using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Titulo = "When Harry Met Sally",
                         DataLancamento = DateTime.Parse("1989-1-11"),
                         Genero = "Romantic Comedy",
                         Preco = 7.99M,
                         Avaliacao = "R"
                     },

                     new Movie
                     {
                         Titulo = "Ghostbusters ",
                         DataLancamento = DateTime.Parse("1984-3-13"),
                         Genero = "Comedy",
                         Preco = 8.99M,
                         Avaliacao = "B"
                     },

                     new Movie
                     {
                         Titulo = "Ghostbusters 2",
                         DataLancamento = DateTime.Parse("1986-2-23"),
                         Genero = "Comedy",
                         Preco = 9.99M,
                         Avaliacao = "R"
                     },

                   new Movie
                   {
                       Titulo = "Rio Bravo",
                       DataLancamento = DateTime.Parse("1959-4-15"),
                       Genero = "Western",
                       Preco = 3.99M,
                       Avaliacao = "B"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}