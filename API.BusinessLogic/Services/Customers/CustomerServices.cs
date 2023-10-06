using API.ViewModel.ViewModels.Common;
using API.ViewModel.ViewModels.Customers;
using API.Data.ORM.MsSQLDataModels;
using API.BusinessLogic.Interface.Customer;
using API.RepositoryManagement.UnityOfWork.Interfaces;

namespace API.BusinessLogic.Services.Customers
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerServices(IUnitOfWork _unitOfWork) {
            this._unitOfWork = _unitOfWork;
        }
        public async Task<object?> GetCustomerList(CustomerData cmnParam)
        {
            
            List<Customer>? listCustomer = new List<Customer>();
            try
            {
                listCustomer = await _unitOfWork.CustomerRepository.GetCustomerList(cmnParam);

            }
            catch (Exception ex)
            {

            }
            return new
            {
                listCustomer
            };
        }
        public async Task<object?> GetCustomerByCustomerID(int id)
        {           
            vmCustomer? customer = new vmCustomer();            
            try
            {
                CommonData cmnParam = new CommonData();
                cmnParam.Id = id;
               
            }
            catch (Exception ex)
            {

            }
            return customer;
        }
        public async Task<object?> DeleteCustomer(int id)
        {            
            string message = string.Empty; bool resstate = false; int response = 0;
            try
            {

                if (response > 0)
                {
                    message = "Deleted Successfully.";
                    resstate = true;
                }
                else
                {
                    message = "Failed.";
                }
            }
            catch (Exception ex)
            {

            }
            return new { message, resstate };
        }
        public async Task<object?> CreateCustomer(CreateCustomerModel objCtomer)
        {
            
            string message = string.Empty; bool resstate = false; int response = 0;
            try
            {             

                if (response > 0)
                {
                    message = "Created Successfully.";
                    resstate = true;
                }
                else
                {
                    message = "Failed.";
                }
            }
            catch (Exception ex)
            {

            }
            return new { message, resstate };
        }
        public async Task<object?> UpdateCustomer(vmCustomerUpdate? objCtomer)
        {            
            string message = string.Empty; bool resstate = false; int response = 0;
            try
            {  
                
                if (response > 0)
                {
                    message = "Updated Successfully.";
                    resstate = true;
                }
                else
                {
                    message = "Failed.";
                }
            }
            catch (Exception ex)
            {

            }
            return new { message, resstate };
        }
    }
}
