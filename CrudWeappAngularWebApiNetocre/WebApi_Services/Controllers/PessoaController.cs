using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Services.ContextoDB;
using WebApi_Services.Models;

namespace WebApi_Services.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly WebApiContext _context;

        public PessoaController(WebApiContext context)
        {
            _context = context;
        }

        [HttpGet("litartodos")]
        public async Task<IActionResult> BuscarPessoas()
        {
            var pessoas = await _context.pessoas.ToListAsync();
            return Ok(pessoas);
        }

        [HttpGet("buscar-pessoa-por-id/{id}")]
        public async Task<IActionResult> BuscarPessoaPorId(Guid id)
        {
            var pessoas = await _context.pessoas.FindAsync(id);
            if (pessoas == null) return NotFound();
     
            return Ok(pessoas);
        }

        [HttpPost("adicionar-pessoa")]
        public async Task<IActionResult> AdicionarPessoa(Pessoa pessoa)
        {
            var pessoas = await _context.pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
            17 981687976
        }

        [HttpPut("atualizar-pessoa")]
        public async Task<IActionResult> AtualizarPessoa(Pessoa pessoa)
        {
            var pessoas =  _context.pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("delete-pessoa/{id}")]
        public async Task<IActionResult> DeletarPessoaPorId(Guid id)
        {
            var pessoas = await _context.pessoas.FindAsync(id);
            if (pessoas == null) return NotFound();

            _context.Remove(pessoas);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
