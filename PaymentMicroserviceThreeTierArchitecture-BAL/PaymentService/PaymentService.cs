using PaymentMicroserviceThreeTierArchitecture_BAL.IPaymentService;
using PaymentMicroserviceThreeTierArchitecture_DAL.Entities;
using PaymentMicroserviceThreeTierArchitecture_DAL.IPaymentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMicroserviceThreeTierArchitecture_BAL.PaymentService
{
    public class PaymentService : ICustomService<Payment>
    {
        private readonly IRepository<Payment> _studentRepository;
        public PaymentService(IRepository<Payment> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Delete(Payment entity)
        {
            try
            {
                if(entity != null)
                {
                    _studentRepository.Delete(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        public Payment Get(int Id)
        {
            try
            {
                var obj = _studentRepository.Get(Id);
                if(obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception)
            {

                throw;
            }
        }

        public IEnumerable<Payment> GetAll()
        {
            try
            {
                var obj = _studentRepository.GetAll();
                if(obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        public void Insert(Payment entity)
        {
            try
            {
                if(entity != null)
                {
                    _studentRepository.Insert(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        public void Remove(Payment entity)
        {
            try
            {
                if(entity != null)
                {
                    _studentRepository.Remove(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }
        public void Update(Payment entity)
        {
            try
            {
                if(entity != null)
                {
                    _studentRepository.Update(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}
