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
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace admin.taghelpers;

public class CustomLoaderHelperFactory : TagHelperFactoryInterface
{
    private static readonly string CLASSNAME = "admin.taghelpers.CustomLoaderHelper";
    private static readonly string FACTORYNAME = "CustomLoaderHelperFactory";
    public CustomLoaderHelperFactory()
    {
    }

    // throws LicensingException
    public virtual object getInstance(HashMap<object, object> hashMap, PageContext pageContext)
    {
        AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
        return HelperFactory.getInstance(abeClientInformation, FACTORYNAME, CLASSNAME, hashMap, pageContext);
    }

    // throws LicensingException
    public virtual object getInstance(AbeClientInformationInterface abeClientInformation)
    {
        return HelperFactory.getInstance(abeClientInformation, FACTORYNAME, CustomLoaderHelperFactory.CLASSNAME);
    }

}

