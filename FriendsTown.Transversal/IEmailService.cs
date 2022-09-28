using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsTown.Transversal
{
    public interface IEmailService
    {
        void SendEmail(string from, string to, string subject, string message);
    }
}
