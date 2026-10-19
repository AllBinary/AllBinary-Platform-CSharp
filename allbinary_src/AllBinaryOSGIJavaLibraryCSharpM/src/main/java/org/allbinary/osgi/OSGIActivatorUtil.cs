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
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;
using BundleContext = org.osgi.framework.BundleContext;
using NullServiceReferenceFactory = org.osgi.framework.NullServiceReferenceFactory;
using ServiceReference = org.osgi.framework.ServiceReference;
using ServiceRegistration = org.osgi.framework.ServiceRegistration;

namespace org.allbinary.osgi;

public class OSGIActivatorUtil
{
    private OSGIActivatorUtil()
    {
    }

    // throws Exception
    public static void registerAsService(BundleContext bundleContext, object anyType, string serviceName)
    {
        OSGIActivatorUtil.registerAsService(bundleContext, anyType, serviceName, StdUtil.getInstance().createHashtable());
    }

    // throws Exception
    public static void registerAsService(BundleContext bundleContext, object anyType, string serviceName, ABHashtable<object, object> properties)
    {
        ServiceRegistration serviceRegistration = bundleContext.registerService(serviceName, anyType, properties);
        ServiceReference serviceReference = serviceRegistration.getReference();
        serviceReference = bundleContext.getServiceReference(serviceName);
        if (serviceReference == NullServiceReferenceFactory.getInstance().NULL_SERVICE_REFERENCE) {
            throw new Exception("No Such Service Reference");
        }
    }

}

