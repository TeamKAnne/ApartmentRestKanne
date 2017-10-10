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

        /// <summary>
        /// Yderligere CRUD metoder:
        /// </summary>
        /// <param name="apartment"></param>
        public void CreateAppartment(Apartment apartment)
        {
           // IList<Apartment> alist = new List<Apartment>();

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string sql =
                    "INSERT INTO APARTMENT (Price, Location, PostalCode, Size, NoRoom, WashingMachine, Dishwasher)values(@Price, @Location, @Postalcode, @Size, @NoRoom, @WashingMachine, @Dishwasher)";
                SqlCommand postCommand = new SqlCommand(sql,conn);

                postCommand.Parameters.AddWithValue("@Price", apartment.Price);
                postCommand.Parameters.AddWithValue("@Location", apartment.Location);
                postCommand.Parameters.AddWithValue("@PostalCode", apartment.PostalCode);
                postCommand.Parameters.AddWithValue("@Size", apartment.Size);
                postCommand.Parameters.AddWithValue("@NoRoom", apartment.NoRoom);
                postCommand.Parameters.AddWithValue("@WashingMachine", apartment.WashingMachine);
                postCommand.Parameters.AddWithValue("@Dishwasher", apartment.Dishwasher);

                postCommand.ExecuteNonQuery();
                
            }
        }

        public void DeleteAparment(string id)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string sql = "DELETE FROM APARTMENT WHERE Id = @Id";

                SqlCommand deleteCommand = new SqlCommand(sql,conn);

                deleteCommand.Parameters.AddWithValue("@Id", id);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public void UpdateApartment(string id, Apartment newApartment)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string sql = "UPDATE APARTMENT SET Price = @Price, Location = @Location, PostalCode = @PostalCode, Size = @Size, NoRoom = @NoRoom, WashingMachine = @WashingMachine, Dishwasher = @Dishwasher WHERE Id = @Id";
                
                SqlCommand updateCommand = new SqlCommand(sql,conn);

                updateCommand.Parameters.AddWithValue("@Id", Int32.Parse(id));
                
                updateCommand.Parameters.AddWithValue("@Price", newApartment.Price);
                updateCommand.Parameters.AddWithValue("@Location", newApartment.Location);
                updateCommand.Parameters.AddWithValue("@PostalCode", newApartment.PostalCode);
                updateCommand.Parameters.AddWithValue("@Size", newApartment.Size);
                updateCommand.Parameters.AddWithValue("@NoRoom", newApartment.NoRoom);
                updateCommand.Parameters.AddWithValue("@WashingMachine", newApartment.WashingMachine);
                updateCommand.Parameters.AddWithValue("@Dishwasher", newApartment.Dishwasher);

                updateCommand.ExecuteNonQuery();

            }
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
