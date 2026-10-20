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
using java.util;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;

namespace org.allbinary.business.user.commerce.inventory.item;

public class ItemFactoryUnused
{
    private ItemFactoryUnused()
    {
    }

    // throws MoneyException
    public static TableMappingInterface getInstance(HashMap<object, object> hashMap)
    {
        return ((TableMappingInterface) new Item(hashMap));
    }

    // throws Exception, MoneyException
    public static TableMappingInterface getInstance(HttpServletRequest request)
    {
        return ((TableMappingInterface) new Item(new RequestParams(request).toHashMap()));
    }

}

