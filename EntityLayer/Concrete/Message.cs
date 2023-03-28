using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public int MessageSender { get; set; }
        public int MessageSenderMail { get; set; }
        public string MessageSub { get; set; }
        public string MessageDesc { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
