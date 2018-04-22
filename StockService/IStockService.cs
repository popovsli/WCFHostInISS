﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;

namespace StockService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [XmlSerializerFormat]
    [ServiceContract(SessionMode = SessionMode.Required)]
    //    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        //[NetDataContractFormat]
        StockPrice GetPrice(string ticker);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "StockService.ContractType".
    public class StockPrice
    {
        //    [DataMember]
        [XmlAttribute]
        public double price;

        //    [DataMember]
        [XmlAttribute]
        public int calls;

        [XmlAttribute]
        public string RequestedBy;
    }
}
