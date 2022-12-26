using Microsoft.EntityFrameworkCore;
using NotificationSchedulingSystem.DBTableModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NotificationSchedulingSystem.DBAccess
{
    public class CompanyContext : DbContext
    {
        //Two database tables were used to store data
        //One is for company information and the other is for notification schedule
        public DbSet<CompanyInformation> Company { get; set; }
        public DbSet<CompanyNotificationSchedule> NotificationSchedule { get; set; }

        public CompanyContext(DbContextOptions options) : base(options) { }


        public void AddCompany(CompanyInformation companyInformation)
        {
            Add(companyInformation);
            SaveChanges();
        }

        public void AddCompanychedule(CompanyNotificationSchedule companyNotificationDates)
        {
            Add(companyNotificationDates);
            SaveChanges();
        }

        public CompanyNotificationSchedule GetNotificationSchedule(string id)
        {
            return NotificationSchedule.Find(id);
        }
        public bool DoesCompanyIdExist(string ID)
        {
            return Company.Any(company => company.ID == ID);
        }

        public bool DoesCompanyScheduleIdExist(string ID)
        {
            return NotificationSchedule.Any(company => company.ID == ID);
        }

    }
}
