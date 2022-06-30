using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService22
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string InsertUserDetails(UserDetails userInfo);

        [OperationContract]
        bool DeleteUserDetails(UserDetails userInfo);

        [OperationContract]
        DataSet UpdateUserDetails(UserDetails userInfo);

        [OperationContract]
        void UpdateCustomerTable(UserDetails userInfo);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService22.ContractType".
    [DataContract]
    public class UserDetails
    {
        int UserID;
        string Name = string.Empty;
        string Email = string.Empty;

        [DataMember]
        public int userID
        {
            get { return UserID; }
            set { UserID = value; }
        }

        [DataMember]
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        [DataMember]
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }
       

    }
}