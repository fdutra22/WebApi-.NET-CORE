
using System;
using System.Collections.Generic;

namespace DesafioGlobalTec.Models
{
    public class Pessoa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Uf { get; set; }
        public DateTime DataNascimento { get; set; }

        public static List<Pessoa> pessoas = new List<Pessoa>()
        {

           new Pessoa { Codigo = 1, Nome = "Alberto Miguel", Cpf = "458.789.963-41", DataNascimento = DateTime.Parse("14-01-1977"), Uf = "SP" },
           new Pessoa { Codigo = 2, Nome = "Bento Rodrigues", Cpf = "145.784.961-02", DataNascimento = DateTime.Parse("23-11-1978"), Uf = "RJ" },
           new Pessoa { Codigo = 3, Nome = "Carlos Santos", Cpf = "005.048.950-12", DataNascimento = DateTime.Parse("25-06-1979"), Uf = "GO" },
           new Pessoa { Codigo = 4, Nome = "Danilo Gonçalves", Cpf = "458.789.963-41", DataNascimento = DateTime.Parse("18-10-1980"), Uf = "TO" },
           new Pessoa { Codigo = 5, Nome = "Eduardo Abravanel", Cpf = "458.789.963-41", DataNascimento = DateTime.Parse("31-01-1981"), Uf = "MA" },
           new Pessoa { Codigo = 6, Nome = "Feliciano Quintino", Cpf = "458.789.963-41", DataNascimento = DateTime.Parse("29-04-1982"), Uf = "PA" },
           new Pessoa { Codigo = 7, Nome = "Guilherme Tavares", Cpf = "458.789.963-41", DataNascimento = DateTime.Parse("15-09-1983"), Uf = "BA" },
           new Pessoa { Codigo = 8, Nome = "Hugo Rocha", Cpf = "458.789.963-41", DataNascimento = DateTime.Parse("16-03-1984"), Uf = "SC" },
           new Pessoa { Codigo = 9, Nome = "Igor Batista", Cpf = "458.789.963-41", DataNascimento = DateTime.Parse("19-08-1985"), Uf = "RN" },
           new Pessoa { Codigo = 10, Nome = "João Peixe", Cpf = "458.789.963-41", DataNascimento = DateTime.Parse("06-02-1986"), Uf = "AM" }

        };
    }
}
