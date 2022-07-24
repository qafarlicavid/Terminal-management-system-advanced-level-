using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;

namespace Terminal_management_system.Database.Repository
{
    class ReportRepository
    {
        public static List<Report> Reports { get; set; } = new List<Report>();

        public static Report Add(string fromEmail, string toEmail, string text)
        {
            Report report = new Report(fromEmail, toEmail, text);
            Reports.Add(report);
            return report;
        }

        public static List<Report> GetReports()
        {
            foreach (Report report in Reports)
            {
                report.FromUser = UserRepository.GetUserByEmail(report.FromEmail);
                report.ToUser = UserRepository.GetUserByEmail(report.ToEmail);
            }
            return Reports;
        }
    }
}
