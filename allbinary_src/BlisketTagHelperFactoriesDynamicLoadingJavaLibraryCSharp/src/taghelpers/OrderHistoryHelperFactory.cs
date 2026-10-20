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
//using PageContext = javax.servlet.jsp.PageContext;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using HelperFactory = admin.taghelpers.HelperFactory;

namespace taghelpers;

public class OrderHistoryHelperFactory
{
    private static readonly string CLASSNAME = "taghelpers.OrderHistoryHelper";
    private static readonly string FACTORYNAME = "taghelpers.OrderHistoryHelperFactory";
    private OrderHistoryHelperFactory()
    {
    }

    // throws LicensingException
    public static object getInstance(HashMap<object, object> hashMap, PageContext pageContext)
    {
        return HelperFactory.getInstance(FACTORYNAME, CLASSNAME, hashMap, pageContext);
    }

}

