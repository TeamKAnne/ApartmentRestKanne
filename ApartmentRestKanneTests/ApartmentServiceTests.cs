using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApartmentRestKanne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRestKanne.Tests
{
    [TestClass()]
    public class ApartmentServiceTests
    {
        [TestMethod()]
        public void GetAllApartmentTest()
        {
            //Arrange

            ApartmentService ap = new ApartmentService();
            
            //Act

            IList<Apartment> aplist = ap.GetAllApartment();
            string actual;
            if (aplist.Count > 0)
            {
                actual = "Ja";
            }
            else
            {
                actual = "Nej";
            }
            

            //Assert
            Assert.AreEqual("Ja", actual);
        }

        [TestMethod()]
        public void CreateAppartmentTest()
        {
            //Arrange 

            ApartmentService ap = new ApartmentService();

            var newApartment = new Apartment{Price = 5000, Location = "WHAAAAT", PostalCode = 9999, Size = 555, NoRoom = 777, WashingMachine = false, Dishwasher = false};
            ap.CreateAppartment(newApartment);
            IList<Apartment> testList = ap.GetAllApartment();
            string actuel;
            string expected = "WHAAAAT";

            //Act&Assert
            foreach (var appApartment in testList)
            {
                if (appApartment.Location == "WHAAAAT")
                {
                    actuel = appApartment.Location;
                    Assert.AreEqual(expected,actuel);
                }
                
            }

        }

        [TestMethod()]
        public void DeleteAppartmentTest()
        {
            //Arrange 

            ApartmentService ap = new ApartmentService();
            string actual;
            //Act

            ap.DeleteAparment("20");

            IList<Apartment> testList = ap.GetAllApartment();
            
           //Assert

            foreach (var appApartment in testList)
            {
                if (appApartment.Id == 20)
                {
                    actual = "Denne findes";
                }
                else
                {
                    actual = "Findes ikke";
                }
                Assert.AreEqual("Findes ikke", actual);
            }

        }
        [TestMethod()]
        public void PutAppartmentTest()
        {
            //Arrange 

            ApartmentService ap = new ApartmentService();

            var newApartment = new Apartment { Price = 5000, Location = "KallePotte", PostalCode = 9999, Size = 555, NoRoom = 777, WashingMachine = false, Dishwasher = false };
            ap.UpdateApartment("14", newApartment);
            IList<Apartment> testList = ap.GetAllApartment();
            string actuel;
            string expected = "KallePotte";

            //Act&Assert
            foreach (var appApartment in testList)
            {
                if (appApartment.Id == 14)
                {
                    actuel = appApartment.Location;
                    Assert.AreEqual(expected, actuel);
                }

            }

        }


    }



}