using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;

namespace HSRC_RMS.Helpers
{
    public interface IRepository<T> where T : class
    {
        Task<List<LicenseSupplies>> GetSuppliesByUserIdAsync(int userId);
        Task<List<LicenseCapture>> GetLicensefieldsByUserIdAsync(int userId);
        Task<List<LicenseCapture>> GetLicenseViewByCaptureIdAsync(int captureId);
        Task<List<SelectListItem>> UsersOptionAsync();
        Task<List<SelectListItem>> TypeOptionsAsync();
        Task<List<SelectListItem>> SupplierOptionsAsync();
        Task<List<LicenseType>> GetTypeByUserIdAsync(int userId);
        Task<List<LicenseCapture>> GetLicenseIdAsync(int captureId);

        //List<string> GetLicenseCSuppliesList();
        //List<string> GetLicenseCTypeList();
        //List<string> GetLicenseCUserList();
        //public List<SelectListItem> typeOptions();
        //public List<SelectListItem> usersOption();
        //public List<SelectListItem> supplierOptions();

        List<LicenseType> GetTypeByUserId(int userId);

        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();

        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task SaveAsync();

    }
}
