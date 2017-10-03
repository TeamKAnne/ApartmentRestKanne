using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ApartmentRestKanne
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ApartmentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ApartmentService.svc or ApartmentService.svc.cs at the Solution Explorer and start debugging.
    public class ApartmentService : IApartmentService
    {
        private const string connstr =
                "Server=tcp:annesazure.database.windows.net,1433;Initial Catalog=EasjDBasw;Persist Security Info=False;User ID=anne55x9;Password=Easj2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            ;

        public IList<Apartment> GetAllApartment()
        {
            IList<Apartment> apartments = new List<Apartment>();

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string sql = "SELECT * FROM APARTMENT";

                SqlCommand getCommand = new SqlCommand(sql,conn);

                SqlDataReader reader = getCommand.ExecuteReader();

                while (reader.Read())
                {
                    Apartment apartmentElement = ReadApartment(reader);
                    apartments.Add(apartmentElement);
                }

                return apartments;
            }
        }

        public IList<Apartment> GetAllApartmentByLocation(string location)
        {
            IList<Apartment> apartments = new List<Apartment>();

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string sql = "SELECT * FROM APARTMENT ORDER BY LOCATION ASC";
                SqlCommand getCommand = new SqlCommand(sql,conn);

                SqlDataReader reader = getCommand.ExecuteReader();

                while (reader.Read())
                {
                    Apartment apartmentElement = ReadApartment(reader);
                    apartments.Add(apartmentElement);
                }

                return apartments;
            }
           
        }

        public Apartment ReadApartment(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            int price = reader.GetInt32(1);
            string location = reader.GetString(2);
            int postalCode = reader.GetInt32(3);
            int size = reader.GetInt32(4);
            int noRoom = reader.GetInt32(5);
            bool washingMachine = reader.GetBoolean(6);
            bool dishwasher = reader.GetBoolean(7);

            Apartment apartment = new Apartment()
            {
                Id = id,
                Price = price,
                Location = location,
                PostalCode = postalCode,
                Size = size,
                NoRoom = noRoom,
                WashingMachine = washingMachine,
                Dishwasher = dishwasher
            
            };
            return apartment;
        }

        public IList<Apartment> GetAllApartmentByPostalCode(string code)
        {
            IList<Apartment> apartments = new List<Apartment>();

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string sql = "SELECT * FROM APARTMENT ORDER BY POSTALCODE";

                SqlCommand getCommand = new SqlCommand(sql,conn);

                SqlDataReader reader = getCommand.ExecuteReader();

                while (reader.Read())
                {
                    Apartment apartmentElement = ReadApartment(reader);
                    apartments.Add(apartmentElement);
                }
            }
            return apartments;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
