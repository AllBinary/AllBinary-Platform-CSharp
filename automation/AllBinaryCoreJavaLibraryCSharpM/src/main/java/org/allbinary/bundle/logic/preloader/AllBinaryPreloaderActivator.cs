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
using BundleActivator = org.osgi.framework.BundleActivator;
using BundleContext = org.osgi.framework.BundleContext;
using ServiceReference = org.osgi.framework.ServiceReference;
using ServiceRegistration = org.osgi.framework.ServiceRegistration;
using CryptServiceFactory = org.allbinary.bundle.logic.system.loader.CryptServiceFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;

namespace org.allbinary.bundle.logic.preloader;

public class AllBinaryPreloaderActivator : BundleActivator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static BundleContext context = null;
    public AllBinaryPreloaderActivator()
    {
    }

    private static readonly string CRYPT_REGISTRY_NAME = "bundle.abcs.logic.system.loader.CryptService";
    public static BundleContext getBundleContext()
    {
        return AllBinaryPreloaderActivator.context;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception
    public virtual void start(BundleContext context)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "start");
            AllBinaryPreloaderActivator.context = context;
            this.registerAsService();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "start", e);
            throw e;
        }
    }

    // throws Exception
    public virtual void registerAsService()
    {
        ABHashtable<object, object> properties = StdUtil.getInstance().createHashtable();
        ServiceRegistration serviceRegistration = AllBinaryPreloaderActivator.context.registerService(CRYPT_REGISTRY_NAME, new CryptServiceFactory(), properties);
        ServiceReference serviceReference = serviceRegistration.getReference();
        serviceReference = AllBinaryPreloaderActivator.context.getServiceReference(CRYPT_REGISTRY_NAME);
        if (serviceReference == null) {
            throw new Exception("No Such Service Reference");
        }
    }

    // throws Exception
    public virtual void stop(BundleContext context)
    {
        this.logUtil.putF(this.commonStrings.START, this, "stop");
    }

}

