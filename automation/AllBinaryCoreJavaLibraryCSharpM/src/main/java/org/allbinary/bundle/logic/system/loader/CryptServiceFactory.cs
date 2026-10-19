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
using Bundle = org.osgi.framework.Bundle;
using ServiceFactory = org.osgi.framework.ServiceFactory;
using ServiceRegistration = org.osgi.framework.ServiceRegistration;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.bundle.logic.system.loader;

public class CryptServiceFactory : ServiceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private CryptService cryptService = new CryptService();
    public CryptServiceFactory()
    {
    }

    public virtual object getService(Bundle bundle, ServiceRegistration registration)
    {
        this.logUtil.putF(this.commonStrings.START, this, "getService");
        return this.cryptService;
    }

    public virtual void ungetService(Bundle bundle, ServiceRegistration registration, object service)
    {
    }

}

