using API.RepositoryManagement.Base;
using API.RepositoryManagement.Base.Interfaces;
using API.RepositoryManagement.Repositories.Interfaces;
using API.Data.ORM.MsSQLDataModels;
using API.ViewModel.ViewModels.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Crud;
using Azure;
using System.Drawing.Printing;

namespace API.RepositoryManagement.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private NexKraftDbContext? NexKraftDbContext => _dbContext as NexKraftDbContext;
        public CustomerRepository(NexKraftDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Customer?> GetCustomerInfo(int customerId)
        {
            return (await GetManyAsync(filter: u => u.CustomerId == customerId)).FirstOrDefault();
        }

        public async Task<List<Customer>> GetCustomerList(CustomerData param)
        {
            return (await GetManyAsync(
                filter: x => (
                
                x.CustomerName == param.Search
                
                ),
                orderBy: x => x.OrderBy(t => t.CustomerName),
                top: param.PageSize,
                skip: (param.PageNumber - 1) * param.PageSize
                )).ToList();
        }
    }
}
