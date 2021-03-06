﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInventoryAPI" in both code and config file together.
    [ServiceContract]
    public interface IInventoryAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getItem")]
        List<Model.Item> getItem();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getItemDetails/{itemID}")]
        Model.Item getItemDetails(string itemID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getItemByCategory/{category}")]
        List<Model.Item> getItemByCategory(string category);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getItemByName/{itemName}")]
        List<Model.Item> getItemByName(string itemName);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                    BodyStyle = WebMessageBodyStyle.Bare,
                                    UriTemplate = "/createItem")]
        bool createItem(Model.Item item);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                    BodyStyle = WebMessageBodyStyle.Bare,
                                    UriTemplate = "/createItemPrice")]
        bool createItemPrice(List<Model.ItemPrice> ip);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getStockCard/{itemID}")]
        List<Model.StockCard> getStockCard(string itemID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                     RequestFormat = WebMessageFormat.Json,
                                     BodyStyle = WebMessageBodyStyle.Bare,
                                     UriTemplate = "/updateItem")]
        bool updateItem(Model.Item item);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                    BodyStyle = WebMessageBodyStyle.Bare,
                                    UriTemplate = "/updateItemPrice")]
        bool updateItemPrice(List<Model.ItemPrice> itemprice);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                    BodyStyle = WebMessageBodyStyle.Bare,
                                    UriTemplate = "/getItemPrice/{itemID}")]
        List<Model.ItemPrice> getItemPrice(string ItemID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                    BodyStyle = WebMessageBodyStyle.Bare,
                                    UriTemplate = "/deleteItem/{ItemID}")]
        bool deleteItem(string ItemID);
    }
}
