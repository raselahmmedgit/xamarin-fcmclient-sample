using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XFCMAPP.Chat.Models;
using XFCMAPP.Chat.ViewCells;

namespace XFCMAPP.Chat.Helpers
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Message;
            if (messageVm == null)
            { 
                return null;
            }

            if (messageVm.User == MessageUserEnum.UserHealthBuddy.ToDescriptionAttr())
            {
                return outgoingDataTemplate;
            }
            else if (messageVm.User == MessageUserEnum.UserLogin.ToDescriptionAttr())
            {
                return incomingDataTemplate;
            }
            else if (messageVm.User == MessageUserEnum.UserAnonymous.ToDescriptionAttr())
            {
                return incomingDataTemplate;
            }
            else
            {
                return outgoingDataTemplate;
            }
        }

    }
}
