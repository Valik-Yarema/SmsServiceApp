using BAL.Interface;
using DAL.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCustomerApp.Models.MessageViewModels;

namespace WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class MessagesController: Controller
    {
        private  IUnitOfWork _unitOfWork;

        public MessagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult MessageCreate(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MessageCreate(MessageModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                UserMessage message = new UserMessage() { MessageText = model.MessageText, Id = _unitOfWork.UserRepository.GetUserId(User) };
                PhoneRec phone = new PhoneRec() { PhoneNumber = model.PhoneNumber };
                _unitOfWork.UserMessageRepository.Add(message);
                _unitOfWork.PhoneRecRepository.Add(phone);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Home");
            }

            return View("");

        }

    }
}
