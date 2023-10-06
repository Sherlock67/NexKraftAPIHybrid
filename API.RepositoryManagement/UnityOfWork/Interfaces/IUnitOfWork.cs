using API.RepositoryManagement.Repositories.Interfaces;

namespace API.RepositoryManagement.UnityOfWork.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        #region Properties

        ICustomerRepository CustomerRepository { get; }
        ILoginRepository UserLoginRepository { get; }
        IModuleRepository ModuleRepository { get; }

        #endregion

        #region Methods

        Task CompleteAsync();

        #endregion
    }
}
