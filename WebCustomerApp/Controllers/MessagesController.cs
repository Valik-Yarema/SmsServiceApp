using BAL.Interface;
using DAL.DB;
using Microsoft.AspNetCore.Mvc;
using Model.MessageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult MessageCreate(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MessageCreate(MessageModel model, string returnUrl = null)
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

            return View(model);

        }

    }
}
