using BusinessLogic.Middlewares;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationUserManager userManager;

        public EmployeeService(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task AssignWarehouseAsync(string employeeId, int newWarehouseId)
        {
            var employee = await userManager.Users.FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee != null)
            {
                employee.WarehouseId = newWarehouseId;
                await userManager.UpdateAsync(employee);
            }
        }

        public async Task<EmployeeDTO> GetEmployeeAsync(string employeeId)
        {
            var employee = await userManager.Users.FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee != null)
            {
                return MapperConfig.Mapper.Map<EmployeeDTO>(employee);
            }
            return null;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(int? warehouseId = null)
        {
            return await Task.Run(() => MapperConfig.Mapper.Map<IEnumerable<EmployeeDTO>>(userManager.Users));
        }

        public Task<bool> ToggleActivationAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ToggleRecyclingAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeInformationAsync(EmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
