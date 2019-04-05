using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.Models
{
    public class MessageDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MsgId { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
        public string ConnectionId { get; set; }
        public string Message { get; set; }

        public MessageDetails() {
            MsgId = 0;
        }
    }
}
