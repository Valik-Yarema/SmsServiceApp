using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interface;
using DAL.DB;
using Microsoft.AspNetCore.Mvc;
using WebCustomerApp.Models.PhoneRecViewModels;
using WebCustomerApp.Models;



namespace WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class PhoneController : Controller
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

      

        [Route("~/Phone/GetPhones")]
            [HttpGet]
            public ICollection<PhoneVieweModel> GetPhones()
            {
               
                List<PhoneRec> phones = _unitOfWork.PhoneRecRepository.GetByUserId(_unitOfWork.UserRepository.GetUserId(User));
                List<PhoneVieweModel> recepientModels = new List<PhoneVieweModel>();
                foreach (var phone in phones)
                {
                    PhoneVieweModel recepient= new PhoneVieweModel { id = phone.PhoneId, PhoneNumber = phone.PhoneNumber };
                    recepientModels.Add(recepient);
                }
                return recepientModels;
            
            }

            [HttpGet("{id}")]
            public PhoneVieweModel Get(string userId)
            {
                PhoneRec phone = _unitOfWork.PhoneRecRepository.GetByID(userId);

            PhoneVieweModel recepient = new PhoneVieweModel { id = phone.PhoneId, PhoneNumber = phone.PhoneNumber };
                return recepient;
            }

        //  [Route("~/Phone/CreatePhone")]
        [HttpGet]
        public IActionResult CreatePhone()
        {
            return View();
        }

            [HttpPost]
            public IActionResult CreatePhone(PhoneVieweModel obj)
            {
            if ((_unitOfWork.PhoneRecRepository.SearchByPhone(obj.PhoneNumber)==null)||
                   (_unitOfWork.PhoneRecRepository.SearchByPhone(obj.PhoneNumber).UserId != _unitOfWork.UserRepository.GetUserId(User))) 
            {
                PhoneRec phone = new PhoneRec() { UserId = _unitOfWork.UserRepository.GetUserId(User), PhoneNumber = obj.PhoneNumber };
                _unitOfWork.PhoneRecRepository.Add(phone);
                _unitOfWork.Save();
            }
            else
            {
                return new ObjectResult("Resipient already exists");
            }
            return View();
            }

            [Route("~/Phone/UpdatePhone")]
            [HttpPut]
            public IActionResult UpdatePhone(PhoneVieweModel obj)
            {
                PhoneRec phone = new PhoneRec();
                phone.PhoneId = obj.id;
                phone.UserId = _unitOfWork.UserRepository.GetUserId(User);
                phone.PhoneNumber = obj.PhoneNumber;
            
                _unitOfWork.PhoneRecRepository.Update(phone);
                return new ObjectResult("Employee modified successfully!");
            }

           /* [Route("~/Phone/DeletePhone/{id}")]
            [HttpDelete]
            public IActionResult Delete(string phone)
            {
            List<PhoneRec> recepientMessages = _unitOfWork.PhoneRecRepository.SearchByPhone(phone);
                foreach (var recepientMessage in recepientMessages)
                {
                    _unitOfWork.MessageRepository.Delete(recepientMessage);
                }
                _unitOfWork.PhoneRecRepository.Delete(phoneid);
                _unitOfWork.Save();
                return new ObjectResult("Employee deleted successfully!");
            }*/
        
    }
}
