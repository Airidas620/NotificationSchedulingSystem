using NotificationSchedulingSystem.RESTRequsetClasses;

namespace NotificationSchedulingSystemTest
{
    [TestClass]
    public class DataManagerRESTTest
    {
        [TestMethod]
        public void TestValidDataMethod()
        {
            CompanyInformationPOST companyInformationPOST1 = new CompanyInformationPOST()
            {
                CompanyID = "test1",
                CompanyName = "test1",
                CompanyNumber = "0",
                CompanyMarket = "Denmark",
                CompanyType = "small"
            };

            CompanyInformationPOST companyInformationPOST2 = new CompanyInformationPOST()
            {
                CompanyID = "test2",
                CompanyName = "test2",
                CompanyNumber = "0a",
                CompanyMarket = "Denmark",
                CompanyType = "small"
            };

            CompanyInformationPOST companyInformationPOST3 = new CompanyInformationPOST()
            {
                CompanyID = "test3",
                CompanyName = "test3",
                CompanyNumber = "0",
                CompanyMarket = "Denmark",
                CompanyType = "NoSize"
            };

            DataManagerREST dataManagerREST = new DataManagerREST();

            dataManagerREST.cmpInfPOST = companyInformationPOST1;
            Assert.AreEqual(dataManagerREST.IsDataValid(), true);

            dataManagerREST.cmpInfPOST = companyInformationPOST2;
            Assert.AreEqual(dataManagerREST.IsDataValid(), false);

            dataManagerREST.cmpInfPOST = companyInformationPOST3;
            Assert.AreEqual(dataManagerREST.IsDataValid(), false);
        }

        [TestMethod]
        public void TestPadLeftMethod()
        {
            String testNumber = "4561";

            Assert.AreEqual(testNumber.PadLeft(10, '0'), "0000004561");
        }
    }
}