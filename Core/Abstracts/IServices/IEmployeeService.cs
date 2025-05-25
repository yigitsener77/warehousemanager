using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(int? warehouseId = null);
        Task<EmployeeDTO> GetEmployeeAsync(string employeeId);
        Task AssignWarehouseAsync(string employeeId, int newWarehouseId);
        Task<bool> ToggleActivationAsync(string employeeId);
        Task<bool> ToggleRecyclingAsync(string employeeId);
        Task UpdateEmployeeInformationAsync(EmployeeDTO employeeDTO);
    }
}
