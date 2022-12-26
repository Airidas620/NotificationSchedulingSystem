using NotificationSchedulingSystem.DBTableModels;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NotificationSchedulingSystem.RESTRequsetClasses
{
    public class CompanyInformationPOST
    {
        //Properties used to store CompanyInformation POST data
        //Setters are used to avoid null values
        private string companyID = "";
        public string CompanyID { get { return companyID; } set { if (value != null) companyID = value; } }

        private string companyName = "";
        public string CompanyName { get { return companyName; } set { if (value != null) companyName = value; } }

        private string companyNumber = "";
        public string CompanyNumber { get { return companyNumber; } set { if (value != null) companyNumber = value; } }

        private string companyMarket = "";
        public string CompanyMarket { get { return companyMarket; } set { if (value != null) companyMarket = value; } }

        private string companyType = "";
        public string CompanyType { get { return companyType; } set { if (value != null) companyType = value; } }

    }
}
