using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interface;
using DAL.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebCustomerApp.Models;
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
      /* [HttpGet]
        public IActionResult MessageCreate(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        */
        public IActionResult MessageCreate()
        {
            return View();
        }

        /*
                [HttpPost]
                [ValidateAntiForgeryToken]
                public IActionResult MessageCreate(MessageModel model, string returnUrl = null)
                {  if (ModelState.IsValid)
                    {
                        UserMessage message = new UserMessage() { MessageText = model.MessageText, Id = _unitOfWork.UserRepository.GetUserId(User) };
                        foreach (var phoneNamber in model.PhoneNumber)
                        {
                            PhoneRec phone = new PhoneRec() { PhoneNumber = phoneNamber };


                        _unitOfWork.UserMessageRepository.Add(message);
                        _unitOfWork.PhoneRecRepository.Add(phone);
                        }

                        _unitOfWork.Save();
                        return RedirectToAction("Index", "Home");
                    }

                    return View("");
                    }
                    //https://www.w3schools.com/howto/howto_css_list_group.asp
                    //https://www.w3schools.com/howto/howto_js_snackbar.asp
                    //https://www.w3schools.com/howto/howto_js_active_element.asp
                    //https://www.w3schools.com/howto/howto_js_treeview.asp
                    //https://www.w3schools.com/howto/howto_js_typewriter.asp

                    //add phone https://www.w3schools.com/howto/howto_js_close_list_items.asp or https://www.w3schools.com/howto/howto_js_list_grid_view.asp
                    //position move https://www.w3schools.com/howto/howto_js_draggable.asp
                    //Bootstrap https://www.w3schools.com/howto/howto_make_a_website.asp
                */
        [HttpPost]
      
        public IActionResult MessageCreate(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                UserMessage message = new UserMessage() { MessageText = model.MessageText, Id = _unitOfWork.UserRepository.GetUserId(User) };
                _unitOfWork.UserMessageRepository.Add(message);

                foreach (var phone in model.PhoneNumber)
                {
                    PhoneRec currentPhone;
                    currentPhone = _unitOfWork.PhoneRecRepository.SearchByPhone(phone);

                    if (currentPhone == null)
                    {
                        currentPhone = new PhoneRec() { PhoneNumber = phone , UserId= _unitOfWork.UserRepository.GetUserId(User) };
                        _unitOfWork.PhoneRecRepository.Add(currentPhone);
                    }

                    _unitOfWork.MessageRepository.Create(message.UserMesId, currentPhone.PhoneId);
                }

                _unitOfWork.Save();
                return View("MessageList");
            }
            else
            {
                return View(model);
            }
        }
     
        public IActionResult MessageList()
        {
            string userID = _unitOfWork.UserRepository.GetUserId(User);
            var messages = _unitOfWork.UserMessageRepository.GetAll(f => f.Id == userID);

            List<MessageListModel> messageList = new List<MessageListModel>();

            foreach (var mes in messages)
            {
                List<string> phones = new List<string>();
                var recepientMessages = _unitOfWork.MessageRepository.GetAll(m => m.UserMesId == mes.UserMesId);
                foreach (var recepientMes in recepientMessages)
                {
                    phones.Add(_unitOfWork.PhoneRecRepository.GetByID(recepientMes.PhoneId).PhoneNumber);
                }
                messageList.Add(new MessageListModel(mes.MessageText, phones));
            }
            ViewBag.MessagesList = messageList;

          

            return View();
        }

        public IActionResult ContactList()
        {
            return View();
        }

       
    }
}
