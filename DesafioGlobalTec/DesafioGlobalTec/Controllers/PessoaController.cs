using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DesafioGlobalTec.Models;
using DesafioGlobalTec.Properties.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioGlobalTec.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class PessoaController : Controller
    {
        // GET: api/Pessoa/GetPessoas
        [HttpGet]
        [ActionName("GetPessoas")]
        public List<Pessoa> GetPessoas()
        {          
            try
            {
                 return Pessoa.pessoas;
            }catch(Exception ex)
            {
                Console.WriteLine("Error PessoaController: " + ex.Message + " - " + ex.StackTrace);
            }
            return null;
        }

        // GET: api/Pessoa/GetPessoa/5
        [HttpGet("{id}", Name = "GetPessoa")]
        [ActionName("GetPessoa")]
        public Pessoa GetPessoa(int id)
        {
            try
            {           
                return Pessoa.pessoas?.FirstOrDefault( k => k.Codigo == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error PessoaController: " + ex.Message + " - " + ex.StackTrace);
            }
            return null;
        }


       // GET: api/Pessoa/GetUf/GO     
        [HttpGet("{uf}", Name = "GetUf")]
        [ActionName("GetUf")]
        public List<Pessoa> Get(string Uf)
        {
            try
            {
                return Pessoa.pessoas?.Where(k => k.Uf == Uf).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error PessoaController: " + ex.Message + " - " + ex.StackTrace);
            }
            return null;
        }

        // POST: api/Pessoa/InserirPessoa
        [HttpPost]
        [ActionName("InserirPessoa")]
        public Pessoa InserirPessoa([FromBody]Pessoa pessoa)
        {
            try
            {
                if (pessoa != null)
                {
                    if (ValidaCpf.ECpf(pessoa.Cpf))
                    {
                        Pessoa.pessoas.Add(pessoa);
                        return pessoa;
                    }
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error PessoaController: " + ex.Message + " - " + ex.StackTrace);
            }
            return null;
        }
        
        // PUT: api/Pessoa/AtualizarPessoa/5
        [HttpPut("{id}")]
        [ActionName("AtualizarPessoa")]
        public Pessoa AtualizarPessoa(int id, [FromBody]Pessoa pessoa)
        {
            try
            {
                if (pessoa != null)
                {
                    Console.WriteLine("Pessoa");
                    if (ValidaCpf.ECpf(pessoa.Cpf))
                    {
                        foreach(var item in Pessoa.pessoas)
                        {
                            if(item.Codigo == id)
                            {
                                Console.WriteLine(item.Codigo);
                                item.Cpf = pessoa.Cpf;
                                item.DataNascimento = pessoa.DataNascimento;
                                item.Nome = pessoa.Nome;
                                item.Uf = pessoa.Uf;
                                break;
                            }
                        }
                        
                    }
                }
                return Pessoa.pessoas.FirstOrDefault(h => h.Codigo == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error PessoaController: " + ex.Message + " - " + ex.StackTrace);
            }
            return null;
        }
        
        // DELETE: api/Pessoa/ExcluirPessoa/5
        [HttpDelete("{id}")]
        [ActionName("ExcluirPessoa")]
        public void ExcluirPessoa(int id)
        {
            var index = Pessoa.pessoas.IndexOf(Pessoa.pessoas.FirstOrDefault(f => f.Codigo == id));
            Pessoa.pessoas.RemoveAt(index);
        }
    }
}
