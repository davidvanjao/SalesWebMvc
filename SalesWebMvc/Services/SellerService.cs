using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context; //verificar importacao

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList(); //acessa os dados ta tabela vendedores e converte em lista. Operacao Sincrona. 
        }

        public void Insert(Seller obj)
        {
            //obj.Department = _context.Department.First();//adiciona ao campo departamento em vendedores, o primeiro registro encontrado na tabela departamento.
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id); //procura se existe um objeto no banco com o id passado.
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
