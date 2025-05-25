using BusinessLogic.Middlewares;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWorks unitOfWorks = new UnitOfWorks();

        public async Task ChangeWarehouseAsync(int id, string name = null, string location = null)
        {
            var item = await unitOfWorks.WarehouseRepository.ReadOneAsync(id);
            if (item != null)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    item.Name = name;
                }
                if (!string.IsNullOrEmpty(location))
                {
                    item.Location = location;
                }
                await unitOfWorks.WarehouseRepository.UpdateAsync(item);
                await unitOfWorks.CommitAsync();
            }
        }

        public async Task<WarehouseDTO> GetWarehouseAsync(int id)
        {
            var data = await unitOfWorks.WarehouseRepository.ReadOneAsync(id);
            return MapperConfig.Mapper.Map<WarehouseDTO>(data);
        }

        public async Task<IEnumerable<WarehouseDTO>> GetWarehousesAsync()
        {
            var data = await unitOfWorks.WarehouseRepository.ReadManyAsync();
            return MapperConfig.Mapper.Map<IEnumerable<WarehouseDTO>>(data);
        }

        public async Task NewWarehouseAsync(string name, string location)
        {
            await unitOfWorks.WarehouseRepository.CreateAsync(new Warehouse { Name = name, Location = location });
            await unitOfWorks.CommitAsync();
        }

        public async Task<bool> ToggleActivationWarehouseAsync(int id)
        {
            var item = await unitOfWorks.WarehouseRepository.ReadOneAsync(id);
            item.Active = !item.Active;
            await unitOfWorks.WarehouseRepository.UpdateAsync(item);
            await unitOfWorks.CommitAsync();
            return item.Active;
        }

        public async Task<bool> ToggleRecyclingWarehouseAsync(int id)
        {
            var item = await unitOfWorks.WarehouseRepository.ReadOneAsync(id);
            item.Deleted = !item.Deleted;
            await unitOfWorks.WarehouseRepository.UpdateAsync(item);
            await unitOfWorks.CommitAsync();
            return item.Deleted;
        }
    }
}
