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

        /**LICENSE MODULE START**/
        Task<List<LicenseSupplies>> GetSuppliesByUserIdAsync(int userId);
        Task<List<LicenseCapture>> GetLicensefieldsByUserIdAsync(int userId);
        Task<List<LicenseCapture>> GetLicenseViewByCaptureIdAsync(int captureId);
        Task<List<SelectListItem>> UsersOptionAsync();
        Task<List<SelectListItem>> TypeOptionsAsync();
        Task<List<SelectListItem>> SupplierOptionsAsync();
        Task<List<LicenseType>> GetTypeByUserIdAsync(int userId);
        Task<List<LicenseCapture>> GetLicenseIdAsync(int captureId);
        Task<List<LicenseActivation>> GetLicenseActivations(int captureId);
        Task<List<LicenseRemainder>> GetRemindersForUser(int userId);
        List<LicenseType> GetTypeByUserId(int userId);
        Task<bool> DeleteActivationIdAsync(int activationId);

        /**LICENSE MODULE END**/


        /**MEMORUNDUM OF UNDERSTANDING  MODULE START**/

        Task<bool> DeleteByCreateIdAsync(int createId);

        /**MEMORUNDUM OF UNDERSTANDING  MODULE END**/


        Task<List<Event>> GetEvents();


        /**FUNCTIONS START**/

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
        /**FUNCTIONS END**/

    }
}
