using NotificationSchedulingSystem.DBTableModels;

namespace NotificationSchedulingSystem.RESTRequsetClasses
{
    public class CompanyScheduleGET
    {
        public String CompanyId { get; set; }

        public String[] Notifications { get; set; }

        public CompanyScheduleGET(CompanyNotificationSchedule companyNotificationDates)
        {
            CompanyId = companyNotificationDates.ID;
            Notifications = companyNotificationDates.Dates.Split(";"); //Separate dates written in string
        }
    }
}
