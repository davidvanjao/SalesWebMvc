using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context; //verificar importacao

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync(); //acessa os dados ta tabela vendedores e converte em lista. Operacao Sincrona. 
        }

        public async Task InsertAsync(Seller obj)
        {
            //obj.Department = _context.Department.First();//adiciona ao campo departamento em vendedores, o primeiro registro encontrado na tabela departamento.
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id); //Include funciona como um join
        }

        public async Task RemoveAsync(int id)
        {

            try
            {
                var obj = _context.Seller.Find(id); //procura se existe um objeto no banco com o id passado.
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) //erro vindo do banco
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            }
            catch(DbUpdateConcurrencyException e) //excecao vinda do bando de dados e sendo lançada na camada de servico.
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
