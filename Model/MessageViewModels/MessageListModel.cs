using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCustomerApp.Models.MessageViewModels
{
    public class MessageListModel
    {
        public string MessageText { get; set; }
        public List<string> PhoneNumber { get; set; }

        public MessageListModel(string text, List<string> recepientPhones)
        {
            MessageText = text;
            PhoneNumber = recepientPhones;
        }

    }
}