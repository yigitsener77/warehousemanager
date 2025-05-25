using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Microsoft.AspNet.Identity;

namespace BusinessLogic.Middlewares
{
    public class RoleNameResolver : IValueResolver<Employee, EmployeeDTO, string>
    {
        private readonly UserManager<Employee> _userManager;
        public RoleNameResolver(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        public string Resolve(Employee source, EmployeeDTO destination, string destMember, ResolutionContext context)
        {
            var roles = _userManager.GetRoles(source.Id);
            return roles.FirstOrDefault();
        }
    }
}
