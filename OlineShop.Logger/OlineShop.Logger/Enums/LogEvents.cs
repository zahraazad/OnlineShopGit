using System;
using System.Collections.Generic;
using System.Text;

namespace OlineShop.Logger.Enums
{
    public enum LogEvents
    {
        GenerateItems = 1000,
        ListItems = 1001,
        GetItem = 1002,
        AddItem = 1003,
        UpdateItem = 1004,
        DeleteItem = 1005,
        UploadFile = 1006,

        GetItemNotFound = 4000,
        UpdateItemNotFound = 4001,
        UploadFileNotFound = 4002,
        Exception = 4003
    }
}
