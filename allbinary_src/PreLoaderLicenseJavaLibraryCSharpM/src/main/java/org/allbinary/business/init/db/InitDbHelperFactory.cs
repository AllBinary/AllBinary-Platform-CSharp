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
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace org.allbinary.business.init.db;

public class InitDbHelperFactory
{
    private static readonly string CLASSNAME = "org.allbinary.business.installer.InitDbCrypted";
    private InitDbHelperFactory()
    {
    }

    // throws LicensingException
    public static object getInstance(AbeClientInformationInterface abeClientInformation, DatabaseConnectionInfoInterface databaseConnectionInfoInterface)
    {
        object[] @params = new object[1];
        Type[] classes = new Type[1];
        classes[0] = typeof(DatabaseConnectionInfoInterface);
        @params[0] = ((object) databaseConnectionInfoInterface);
        object anyType = AbeFactory.getInstance().getInstance(abeClientInformation, CLASSNAME, classes, @params);
        return anyType;
    }

    // throws LicensingException
    public static object getInstance(AbeClientInformationInterface abeClientInformation)
    {
        object anyType = AbeFactory.getInstance().getInstance(abeClientInformation, CLASSNAME, null, null);
        return anyType;
    }

}

