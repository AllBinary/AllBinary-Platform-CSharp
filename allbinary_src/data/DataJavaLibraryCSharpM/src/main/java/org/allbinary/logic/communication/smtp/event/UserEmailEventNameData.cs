/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using java.util;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.logic.communication.smtp.@event;

public class UserEmailEventNameData
{
    private static HashMap<object, object> userNameEvenNameHashMap = StdUtil.getInstance().createHashMap();
    private static int nextId = 0;
    private int eventNameId = 0;
    private string eventHandlerName;
    public UserEmailEventNameData(string eventHandlerName)
    {
        this.eventHandlerName = eventHandlerName;
        this.initNextId();
        UserEmailEventNameData.userNameEvenNameHashMap.put(this.eventHandlerName, this);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private void initNextId()
    {
        this.eventNameId = UserEmailEventNameData.nextId;
        UserEmailEventNameData.nextId++;
    }

    public static readonly UserEmailEventNameData INSTALLER = new UserEmailEventNameData("Installer");
    public static readonly UserEmailEventNameData EXCEPTION = new UserEmailEventNameData("Exception");
    public static readonly UserEmailEventNameData LOGGEDEXCEPTION = new UserEmailEventNameData("Logged Exception");
    public static readonly UserEmailEventNameData ERROR = new UserEmailEventNameData("Error");
    public static readonly UserEmailEventNameData OUTOFMEMORY = new UserEmailEventNameData("Out Of Memory Error");
    public static readonly UserEmailEventNameData ADMINGENERATINGSTATICPAGES = new UserEmailEventNameData("Admin Generating Static Pages");
    public static readonly UserEmailEventNameData STOREERROROCCURRED = new UserEmailEventNameData("Store Error Occurred");
    public static readonly UserEmailEventNameData STOREOUTOFMEMORY = new UserEmailEventNameData("Store Out Of Memory Error");
    public static readonly UserEmailEventNameData STORECREATED = new UserEmailEventNameData("Store Created");
    public static readonly UserEmailEventNameData STOREOPENED = new UserEmailEventNameData("Store Opened");
    public static readonly UserEmailEventNameData STORECLOSED = new UserEmailEventNameData("Store Closed");
    public static readonly UserEmailEventNameData STOREGENERATINGSTATICPAGES = new UserEmailEventNameData("Store Generating Static Pages");
    public static readonly UserEmailEventNameData PRODUCTISOUT = new UserEmailEventNameData("Product Is Out");
    public static readonly UserEmailEventNameData PRODUCTISAVAILABLE = new UserEmailEventNameData("Product Is Available");
    public static readonly UserEmailEventNameData PRODUCTISOLD = new UserEmailEventNameData("Product Is Old");
    public static readonly UserEmailEventNameData PRODUCTISONSALE = new UserEmailEventNameData("Product Is On Sale");
    public static readonly UserEmailEventNameData PRODUCTSALEISOVER = new UserEmailEventNameData("Product Sale Is Over");
    public static readonly UserEmailEventNameData ORDERPREPROCESSING = new UserEmailEventNameData(OrderHistoryData.PREPROCESSING);
    public static readonly UserEmailEventNameData ORDERPROCESSING = new UserEmailEventNameData(OrderHistoryData.PROCESSING);
    public static readonly UserEmailEventNameData ORDERCANCELLED = new UserEmailEventNameData(OrderHistoryData.CANCELLED);
    public static readonly UserEmailEventNameData ORDERPARTIALLYSHIPPED = new UserEmailEventNameData(OrderHistoryData.PARTIALLYSHIPPED);
    public static readonly UserEmailEventNameData ORDERSHIPPED = new UserEmailEventNameData(OrderHistoryData.SHIPPED);
    public static readonly UserEmailEventNameData QUOTEREQUEST = new UserEmailEventNameData("Quote Request");
    public static readonly UserEmailEventNameData NEWPASSWORD = new UserEmailEventNameData("New Password");
    public virtual bool isEvent(string userEmailEventNameString)
    {
        return UserEmailEventNameData.userNameEvenNameHashMap.containsKey(userEmailEventNameString);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static UserEmailEventNameData getInstance(string userEmailEventNameString)
    {
        UserEmailEventNameData userEmailEventNameData = ((UserEmailEventNameData) UserEmailEventNameData.userNameEvenNameHashMap.get(userEmailEventNameString));
        if (userEmailEventNameData == null) {
            throw new Exception();
        } else {
            return userEmailEventNameData;
        }
    }

    public override string ToString()
    {
        return this.eventHandlerName;
    }

}

