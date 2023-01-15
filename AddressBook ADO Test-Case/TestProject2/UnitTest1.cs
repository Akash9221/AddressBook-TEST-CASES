using AddressBook_ADO_Test_Case;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookService addressBook1 = new AddressBookService();
        [TestMethod]
        public void TestAddAddressBookInDB()
        {
            AddressBook address1 = new AddressBook()
            {
                FirstName = "Vaibhav",
                LastName = "Mane",
                Address = "Bhigwan",
                City = "Pune",
                State = "Maha",
                Zip = 7865,
                MobNo = 724962454,
                Email = "maneakash3938@gmail.com",
                Type = "Novel",
                AddressBookName = "ABC",
            };

            string result = addressBook1.TestAddAddressBookInDB(address1);
            Assert.AreEqual("Saved", result);
        }
       
    }
}
