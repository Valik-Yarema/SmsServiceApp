using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interface;
using DAL.DB;
using Microsoft.AspNetCore.Mvc;
using Models.PhoneRecViewModels;
using WebCustomerApp.Models;
namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("Phone/[action]")]
    public class PhoneController
    {
        
       
            private IUnitOfWork _unitOfWork;

            public PhoneController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            // GET: /<controller>/
            public IActionResult Phones()
            {
                return View();
            }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        [Route("~/Phone/GetPhones")]
            [HttpGet]
            public ICollection<PhoneVieweModel> GetPhones()
            {
                List<Phone> phones = _unitOfWork._phoneRepository.GetByUserId(_unitOfWork._userManager.GetUserId(User));
                List<RecepientModel> recepientModels = new List<PhoneVieweModel>();
                foreach (var phone in phones)
                {
                PhoneVieweModel recepientModel = new PhoneVieweModel { id = phone.PhoneId, FullName = phone.FullName, PhoneNumber = phone.PhoneNumber };
                    recepientModels.Add(recepientModel);
                }
                return recepientModels;
            }

            [HttpGet("{id}")]
            public PhoneVieweModel Get(int id)
            {
                Phone phone = _unitOfWork._phoneRepository.GetById(id);
            PhoneVieweModel recepientModel = new PhoneVieweModel { id = phone.PhoneId, FullName = phone.FullName, PhoneNumber = phone.PhoneNumber };
                return recepientModel;
            }

            [Route("~/Phone/AddPhone")]
            [HttpPost]
            public IActionResult AddPhone(PhoneVieweModel obj)
            {
                PhoneRec phone = new PhoneRec();
                phone.UserId = _unitOfWork._userManager.GetUserId(User);
                phone.PhoneNumber = obj.PhoneNumber;
            
                _unitOfWork.PhoneRecRepository.Create(phone);
                _unitOfWork.Save();
                return new ObjectResult("Employee added successfully!");
            }

            [Route("~/Phone/UpdatePhone")]
            [HttpPut]
            public IActionResult UpdatePhone(PhoneVieweModel obj)
            {
                PhoneRec phone = new PhoneRec();
                phone.PhoneId = obj.id;
                phone.UserId = _unitOfWork._userManager.GetUserId(User);
                phone.PhoneNumber = obj.PhoneNumber;
                phone.FullName = obj.FullName;
                _unitOfWork._phoneRepository.Update(phone);
                return new ObjectResult("Employee modified successfully!");
            }

            [Route("~/Phone/DeletePhone/{id}")]
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                List<RecepientMessage> recepientMessages = _unitOfWork._recepientMessageRepository.GetRecepientsMessagesByRecipientId(id);
                foreach (var recepientMessage in recepientMessages)
                {
                    _unitOfWork._recepientMessageRepository.Delete(recepientMessage);
                }
                _unitOfWork._phoneRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new ObjectResult("Employee deleted successfully!");
            }
        
    }
}
