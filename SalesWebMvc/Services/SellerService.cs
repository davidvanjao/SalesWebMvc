﻿using SalesWebMvc.Data;
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
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id); //Include funciona como um join
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id); //procura se existe um objeto no banco com o id passado.
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();

            }
            catch(DbUpdateConcurrencyException e) //excecao vinda do bando de dados e sendo lançada na camada de servico.
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
