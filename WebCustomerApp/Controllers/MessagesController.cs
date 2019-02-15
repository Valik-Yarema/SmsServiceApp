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
            //https://www.w3schools.com/howto/howto_css_list_group.asp
            //https://www.w3schools.com/howto/howto_js_snackbar.asp
            //https://www.w3schools.com/howto/howto_js_active_element.asp
            //https://www.w3schools.com/howto/howto_js_treeview.asp
            //https://www.w3schools.com/howto/howto_js_typewriter.asp

            //add phone https://www.w3schools.com/howto/howto_js_close_list_items.asp or https://www.w3schools.com/howto/howto_js_list_grid_view.asp
            //position move https://www.w3schools.com/howto/howto_js_draggable.asp
            //Bootstrap https://www.w3schools.com/howto/howto_make_a_website.asp
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
