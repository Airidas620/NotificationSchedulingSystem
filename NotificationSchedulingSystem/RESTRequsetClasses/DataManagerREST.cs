using NotificationSchedulingSystem.DBTableModels;
using System.Text;

namespace NotificationSchedulingSystem.RESTRequsetClasses
{
    public class DataManagerREST
    {
        private int maxCompanyNumberSymbolSize = 10;

        private HashSet<String> availableMarkets = new HashSet<String>() { "Denmark", "Norway", "Sweden", "Finland" };
        private HashSet<String> availableTypes = new HashSet<String>() { "small", "medium", "large" };

        private Dictionary<String, int[]> notificationDates = new Dictionary<String, int[]>(){
            {"Denmark",new int[]{1,5,10,15,20}},
            {"Norway",new int[]{1,5,10,20}},
            {"Sweden",new int[]{1,7,14,28}},
            {"Finland",new int[]{1,5,10,15,20}},
        };

        //Holds what company types can have notification dates
        private Dictionary<String, HashSet<String>> notificationsForType = new Dictionary<String, HashSet<String>>(){
            {"Denmark",new HashSet<string>(){"small", "medium","large"} },
            {"Norway",new HashSet<string>(){"small", "medium","large"}},
            {"Sweden",new HashSet<string>(){"small", "medium"}},
            {"Finland",new HashSet<string>(){"large"}},
        };

        public CompanyInformationPOST cmpInfPOST { get; set; }

        public CompanyInformation CreateCompanyDetails()
        {
            return new CompanyInformation()
            {
                ID = cmpInfPOST.CompanyID,
                Name = cmpInfPOST.CompanyName,
                Number = cmpInfPOST.CompanyNumber.PadLeft(10, '0'),//Adds number with zeros if it's too small
                Market = cmpInfPOST.CompanyMarket,
                Type = cmpInfPOST.CompanyType
            };
        }

        public CompanyNotificationSchedule CreateCompanyNotificationSchedule()
        {
            return new CompanyNotificationSchedule
            {
                ID = cmpInfPOST.CompanyID,
                Dates = CreateNotificationDates()
            };
        }

        /// <summary>
        /// Notification dates in the table are stored in a single string separated by ";"
        /// </summary>
        private string CreateNotificationDates()
        {
            int[] dates = notificationDates[cmpInfPOST.CompanyMarket];

            StringBuilder sb = new StringBuilder(DateTime.Now.AddDays(dates[0]).ToString("dd/M/yyyy"));

            for (int i = 1; i < dates.Length; i++)
            {
                sb.Append(";" + DateTime.Now.AddDays(dates[i]).ToString("dd/M/yyyy"));
            }

            return sb.ToString();
        }


        /// <summary>
        /// Checks if Data submited via POST request is valid
        /// </summary>
        public bool IsDataValid()
        {
            if (!(cmpInfPOST.CompanyNumber.Length <= maxCompanyNumberSymbolSize &&
                IsComponyNumberAnInterger(cmpInfPOST.CompanyNumber)))
            {
                return false;
            }

            if (!(availableMarkets.Contains(cmpInfPOST.CompanyMarket) &&
                availableTypes.Contains(cmpInfPOST.CompanyType)))
            {
                return false;
            }
            return true;
        }

        private bool IsComponyNumberAnInterger(String componyNumber)
        {
            foreach (char character in componyNumber)
            {
                if (!Char.IsDigit(character))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if a company needs a schedule
        /// </summary>
        public bool HasASchedule()
        {
            return notificationsForType[cmpInfPOST.CompanyMarket].Contains(cmpInfPOST.CompanyType);
        }

    }
}
