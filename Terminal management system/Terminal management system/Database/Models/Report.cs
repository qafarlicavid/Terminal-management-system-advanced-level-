using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_management_system.Database.Models
{
    class Report
    {
        public Person FromUser { get; set; }
        public Person ToUser { get; set; }


        public static int _rowNumber;
        public static int RowNumber { get; private set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }

        public string Text { get; set; }


        public Report(string fromEmail, string toEmail, string text)
        {
            RowNumber = _rowNumber;
            FromEmail = fromEmail;
            ToEmail = toEmail;
            Text = text;
            _rowNumber++;
        }
    }
}
