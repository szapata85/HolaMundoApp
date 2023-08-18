using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundoApp.Data.Models
{
    public class MessageModel
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool IdOwnerMessage { get; set; }
    }
}
