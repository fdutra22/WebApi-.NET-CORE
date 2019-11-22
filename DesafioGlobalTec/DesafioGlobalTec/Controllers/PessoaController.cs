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
    //[Authorize]
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class PessoaController : Controller
    {
        /// <summary>
        /// Busca uma pessoa.
        /// </summary>
        /// <returns>Objeto contendo valores de uma pessoa</returns>
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

        /// <summary>
        /// Busca uma pessoa.
        /// </summary>
        /// <param name="id"> id da pessoa</param>
        /// <returns>Objeto contendo valores de uma pessoa</returns>
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


        /// <summary>
        /// Busca um Estado.
        /// </summary>
        /// <param name="Uf">sigla do estado</param>
        /// <returns>Objeto contendo o estado buscado</returns>     
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

        /// <summary>
        /// Insere uma pessoa.
        /// </summary>
        /// <param name="pessoa">objeto pessoa</param>
        /// <returns>Objeto contendo valores de uma pessoa recém inserida</returns>  
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

        /// <summary>
        /// atualiza uma pessoa.
        /// </summary>
        /// <param name="pessoa">objeto pessoa</param>
        /// <returns>Objeto contendo valores de uma pessoa recém alterada</returns>  
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

        /// <summary>
        /// deleta uma pessoa.
        /// </summary>
        /// <param name="id">objeto pessoa</param>
        /// <returns>void</returns> 
        [HttpDelete("{id}")]
        [ActionName("ExcluirPessoa")]
        public void ExcluirPessoa(int id)
        {
            var index = Pessoa.pessoas.IndexOf(Pessoa.pessoas.FirstOrDefault(f => f.Codigo == id));
            Pessoa.pessoas.RemoveAt(index);
        }
    }
}
