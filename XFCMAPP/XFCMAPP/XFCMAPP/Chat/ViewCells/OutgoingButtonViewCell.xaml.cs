using System;
using System.Collections.Generic;
using XFCMAPP.Chat.ViewModels;
using Xamarin.Forms;

namespace XFCMAPP.Chat.ViewCells
{
    public partial class OutgoingButtonViewCell : ViewCell
    {
        public OutgoingButtonViewCell()
        {
            InitializeComponent();
        }

        private void OnActionSendCommand(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("OutgoingButtonViewCell - OnActionSendCommand");

                var chatPageViewModel = (this.Parent.Parent.BindingContext as ChatPageViewModel);

                Button btnActionSendCommand = (Button)sender;
                if (btnActionSendCommand != null)
                {
                    chatPageViewModel.MessageId = btnActionSendCommand.ClassId.Trim().ToString();
                    chatPageViewModel.ActionInputText = btnActionSendCommand.Text.Trim().ToString();
                }
                chatPageViewModel.OnActionSendCommand.Execute(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OutgoingButtonViewCell - OnActionSendCommand: Exception - {ex.Message.ToString()}");
            }
        }
    }
}