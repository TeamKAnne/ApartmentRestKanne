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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IApartmentService" in both code and config file together.
    [ServiceContract]
    public interface IApartmentService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/")]
        IList<Apartment> GetAllApartment();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/postalcode/{code}")]
        IList<Apartment> GetAllApartmentByPostalCode(String code);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/location/{location}")]
        IList<Apartment> GetAllApartmentByLocation(String location);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "apartment/price/{minprice}/{maxprice}")]
        //IList<Apartment> GetPriceRangeApartment(int minprice, int maxprice);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    RequestFormat = WebMessageFormat.Json,
        //    UriTemplate = "apartment/washingmachine/{true}")]
        //IList<Apartment> GetWash(bool washingMachine);

        [OperationContract]
        Apartment ReadApartment(SqlDataReader reader);


        /// <summary>
        /// Yderligere CRUD metoder:
        /// </summary>
        /// <param name="apartment"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartments/")]
        void CreateAppartment(Apartment apartment);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartments/{id}")]
        void DeleteAparment(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartments/{id}")]
        void UpdateApartment(string id, Apartment newApartment);


        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
