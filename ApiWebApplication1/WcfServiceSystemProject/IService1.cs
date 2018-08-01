//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.ServiceModel.Web;
//using System.Text;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Runtime.Serialization;


namespace WcfServiceSystemProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        //[OperationContract]
        //string InsertDetails(Users usInfo);

        //[OperationContract]
        //string DeleteDetails(Users usInfo);
        //// TODO: Add your service operations here

        [OperationContract]
        CustomerData Get();

        [OperationContract]
        void Insert(string name, string country);

        [OperationContract]
        void Update(int customerId, string name, string country);

        [OperationContract]
        void Delete(int customerId);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class CustomerData
    {
        public CustomerData()
        {
            this.CustomersTable = new DataTable("CustomersData");
        }

        [DataMember]
        public DataTable CustomersTable { get; set; }
    }



    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}

    //[DataContract]
    //public class UserDetails
    //{
    //    string username = string.Empty;
    //    string password = string.Empty;
    //    string country = string.Empty;
    //    string email = string.Empty;

    //    [DataMember]
    //    public string UserName
    //    {
    //        get { return username; }
    //        set { username = value; }
    //    }
    //    [DataMember]
    //    public string Password
    //    {
    //        get { return password; }
    //        set { password = value; }
    //    }
    //    [DataMember]
    //    public string Country
    //    {
    //        get { return country; }
    //        set { country = value; }
    //    }
    //    [DataMember]
    //    public string Email
    //    {
    //        get { return email; }
    //        set { email = value; }
    //    }
    //}
    
    //[DataContract]
    //public class Users
    //{
    //    int id = 0;
    //    string lastname = string.Empty;
    //    float price = 0;
    //    //DateTime email = string.Empty;

    //    [DataMember]
    //    public int ID
    //    {
    //        get { return id; }
    //        set { id = value; }
    //    }
    //    [DataMember]
    //    public string LastName
    //    {
    //        get { return lastname; }
    //        set { lastname = value; }
    //    }
    //    //[DataMember]
    //    //public float Price
    //    //{
    //    //    get { return price; }
    //    //    set { price = value; }
    //    //}
    //    //[DataMember]
    //    //public string Email
    //    //{
    //    //    get { return email; }
    //    //    set { email = value; }
    //    //}
    //}
}
