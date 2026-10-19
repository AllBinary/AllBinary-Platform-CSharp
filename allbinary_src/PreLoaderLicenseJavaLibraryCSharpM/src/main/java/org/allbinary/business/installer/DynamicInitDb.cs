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
using DatabaseConnectionInfoInterface = org.allbinary.business.init.db.DatabaseConnectionInfoInterface;
using InitDbHelperFactory = org.allbinary.business.init.db.InitDbHelperFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace org.allbinary.business.installer;

//Warning you must have sql root access
public class DynamicInitDb : InitDb
{
    public DynamicInitDb(AbeClientInformationInterface abeClientInformation)
    {
        this.setHelper(InitDbHelperFactory.getInstance(abeClientInformation));
    }

    public DynamicInitDb(AbeClientInformationInterface abeClientInformation, DatabaseConnectionInfoInterface databaseConnectionInfoInterface)
    {
        this.setHelper(InitDbHelperFactory.getInstance(abeClientInformation, databaseConnectionInfoInterface));
    }

}

