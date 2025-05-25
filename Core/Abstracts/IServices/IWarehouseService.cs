using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDTO>> GetWarehousesAsync();
        Task<WarehouseDTO> GetWarehouseAsync(int id);
        Task NewWarehouseAsync(string name, string location);
        Task ChangeWarehouseAsync(int id, string name = null, string location = null);
        Task<bool> ToggleActivationWarehouseAsync(int id);
        Task<bool> ToggleRecyclingWarehouseAsync(int id);
    }
}
