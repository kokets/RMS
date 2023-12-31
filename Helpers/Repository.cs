﻿using System;
using System.Linq;
using System.Linq.Expressions;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace HSRC_RMS.Helpers
{
    public class  Repository<T> : IRepository<T> where T : class
    {
        private readonly RmsDbConnect _dbConnect;

        public Repository(RmsDbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }
        public async Task<List<LicenseSupplies>> GetSuppliesByUserIdAsync(int userId)
        {
            return await _dbConnect.Set<LicenseSupplies>()
                .Where(supply => supply.UserId == userId)
                .ToListAsync();
        }
        public List<string> GetLicenseCSuppliesList()
        {
            return _dbConnect.LicenseSupply.Select(s => s.Supplier).ToList();
        }
        public List<string> GetLicenseCUserList()
        {
            return _dbConnect.Users.Select(s => s.Username).ToList();
        }
        public List<string> GetLicenseCTypeList()
        {
            return _dbConnect.LicenseType.Select(s => s.Type).ToList();
        }
        public List<LicenseType> GetTypeByUserId(int userId)
        {
            return _dbConnect.Set<LicenseType>().Where(type => type.UserId == userId).ToList();
        }
        public async Task<List<LicenseType>> GetTypeByUserIdAsync(int userId)
        {
            return await _dbConnect.Set<LicenseType>().Where(type => type.UserId == userId).ToListAsync();
        }
        public async Task<List<SelectListItem>> UsersOptionAsync()
        {
            var usersOptions = await _dbConnect.Users
                .Select(type => new SelectListItem
                {
                    Value = type.Username,
                    Text = type.Username
                })
                .ToListAsync();

            return usersOptions;
        }

        public async Task<List<SelectListItem>> TypeOptionsAsync()
        {
            var typeOptions = await _dbConnect.LicenseType
                .Select(type => new SelectListItem
                {
                    Value = type.Type,
                    Text = type.Type
                })
                .ToListAsync();

            return typeOptions;
        }
        public async Task<List<SelectListItem>> SupplierOptionsAsync()
        {
            var supplierOptions = await _dbConnect.LicenseSupply
                .Select(type => new SelectListItem
                {
                    Value = type.Supplier,
                    Text = type.Supplier
                })
                .ToListAsync();

            return supplierOptions;
        }
        public async Task<List<LicenseCapture>> GetLicensefieldsByUserIdAsync(int userId)
    {
        return await _dbConnect.LicenseCapture
            .Where(capture => capture.UserId == userId)
            .Select(capture => new LicenseCapture
            {
                CaptureId = capture.CaptureId,

                LicenseOwner = capture.LicenseOwner,
                ProductName = capture.ProductName,
                LicenseType = capture.LicenseType,
                AcquiredDate = capture.AcquiredDate,
                ExpiryDate = capture.ExpiryDate,
                Activations = capture.Activations,
                LicenseStatus = capture.LicenseStatus,
            })
            .ToListAsync();


        }
        public   async Task<List<LicenseCapture>> GetLicenseViewByCaptureIdAsync(int captureId)
        {
            return await _dbConnect.LicenseCapture
           .Where(capture => capture.CaptureId == captureId)
           .Select(capture => new LicenseCapture
           {

               LicenseOwner = capture.LicenseOwner,

               ProductName = capture.ProductName,
               ProductKey = capture.ProductKey,
               LicenseType = capture.LicenseType,

               AcquiredDate = capture.AcquiredDate,
               ExpiryDate = capture.ExpiryDate,
               Activations = capture.Activations,
               LicenseStatus = capture.LicenseStatus,
               Supplier = capture.Supplier,
               PurchasePrice = capture.PurchasePrice,
               CommentPrice = capture.CommentPrice,

           })
           .ToListAsync();
            //return await _dbConnect.Set<LicenseCapture>().Where(type => type.CaptureId == captureId).ToListAsync();

        }
        public async Task<List<LicenseCapture>> GetLicenseIdAsync(int captureId)
        {
            return await _dbConnect.LicenseCapture
           .Where(capture => capture.CaptureId == captureId)
           .Select(capture => new LicenseCapture
           {

               LicenseOwner = capture.LicenseOwner,

               ProductName = capture.ProductName,
             
               Supplier = capture.Supplier,
          

           })
           .ToListAsync();
            //return await _dbConnect.Set<LicenseCapture>().Where(type => type.CaptureId == captureId).ToListAsync();

        }
        public async Task<List<LicenseActivation>> GetLicenseActivations(int captureId)
        {
            return await _dbConnect.LicenseActivation
                .Where(activation =>  activation.CaptureId == captureId)
                .ToListAsync();
        }
        public async Task<List<LicenseRemainder>> GetRemindersForUser(int userId)
        {
            var reminders = await _dbConnect.LicenseRemainder
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return reminders;
        }
        public async Task<bool> DeleteActivationIdAsync(int activationId)
        {
            try
            {
                // Find the entity by CreateId
                var entity = await _dbConnect.LicenseActivation.FindAsync(activationId);

                if (entity != null)
                {
                    _dbConnect.LicenseActivation.Remove(entity);

                    await _dbConnect.SaveChangesAsync();
                    return true; // Deletion was successful
                }
                else
                {
                    return false; // Entity not found
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                // Example: Logging the error and returning false
                return false;
            }
        }



        public async Task<bool> DeleteByCreateIdAsync(int createId)
        {
            try
            {
                // Find the entity by CreateId
                var entity = await _dbConnect.MouCreate.FindAsync(createId);

                if (entity != null)
                {
                    _dbConnect.MouCreate.Remove(entity);

                    await _dbConnect.SaveChangesAsync();
                    return true; // Deletion was successful
                }
                else
                {
                    return false; // Entity not found
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                // Example: Logging the error and returning false
                return false;
            }
        }



        /**EVENT REGISTRATION MODULE START**/
  
    public async Task<List<Event>> GetEvents()
    {
        var eventGet = await _dbConnect.Event
            .Select(events => new Event
            {
                EventId = events.EventId,
                EventType = events.EventType,
                Unit = events.Unit,
                Title = events.Title,
                SubmissionDate = events.SubmissionDate,
                EventDate = events.EventDate,
                EventComments = events.EventComments,
                
                FirstContent = events.FirstContent,
                SecondContent = events.SecondContent,
                ThirdContent = events.ThirdContent,
                FourthContent = events.FourthContent,
                FifthContent = events.FifthContent,
            })
            .ToListAsync();

        return eventGet;
    }


    public T GetById(int id)
        {
            try
            {
                return _dbConnect.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<T> GetAll()
        {
            return _dbConnect.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _dbConnect.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbConnect.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var entity = _dbConnect.Set<T>().Find(id);
            if (entity != null)
            {
                _dbConnect.Set<T>().Remove(entity);
            }
        }
        public void Save()
        {
            _dbConnect.SaveChanges();
        }
     



        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbConnect.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbConnect.Entry(entity).State = EntityState.Modified;
            await _dbConnect.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbConnect.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _dbConnect.Set<T>().Remove(entity);
                await _dbConnect.SaveChangesAsync();
            }
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbConnect.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbConnect.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbConnect.Set<T>().AddAsync(entity);
            await _dbConnect.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _dbConnect.SaveChangesAsync();
        }

    }

}
