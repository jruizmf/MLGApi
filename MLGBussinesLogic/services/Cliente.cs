using MLGBussinesLogic.interfaces;
using MLGBussinesLogic.models;
using System;
using System.Collections.Generic;
using MLGDataAccessLayer;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MLGBussinesLogic.services
{
    public class ClienteRepository : IClienteRepository
    {
        private IAppDBContext _dbcontext;
        public ClienteRepository(IAppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Guid> Add(ClienteModelo cliente)
        {
            _dbcontext.Clientes.Add(cliente);
            await _dbcontext.SaveChangesAsync();
            return Cliente.Id;
        }
        public async Task<List<ClienteModelo>> GetAll()
        {
            var clientes = await _dbcontext.Clientes.ToListAsync<ClienteModelo>();
            return clientes;
        }
        public async Task<ClienteModelo> GetOne(Guid id)
        {
            var cliente = await _dbcontext.Clientes.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return cliente;
        }
        public async Task<string> Update(Guid id, ClienteModelo cliente)
        {
            var _cliente = await _dbcontext.Clientes.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (_cliente == null)
            {
                return "El cliente no existe";
            }

            _cliente.Nombre = cliente.Nombre;
            _cliente.Apellidos = cliente.Apellidos;
            _cliente.Direccion = cliente.Direccion;


            await _dbcontext.SaveChanges();
            return "Cliente modificado exitosamente";
        }
        public async Task<string> Delete(Guid id)
        {
            var _cliente = _dbcontext.Clientes.Where(empid => empid.Id == id).FirstOrDefault();
            if (_cliente == null) { 
                return "Employee does not exists"; 
            }
            _dbcontext.Clientes.Remove(_cliente);
            await _dbcontext.SaveChanges();
            return "Cliente eliminado exitosamente";
        }
    }
}
