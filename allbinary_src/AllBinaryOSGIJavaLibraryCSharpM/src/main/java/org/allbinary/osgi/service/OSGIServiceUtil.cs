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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using BundleContext = org.osgi.framework.BundleContext;
using ServiceReference = org.osgi.framework.ServiceReference;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using OSGIServiceInterface = org.allbinary.osgi.OSGIServiceInterface;

namespace org.allbinary.osgi.service;

public class OSGIServiceUtil
{
    private static readonly OSGIServiceUtil instance = new OSGIServiceUtil();
    public static OSGIServiceUtil getInstance()
    {
        return OSGIServiceUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private OSGIServiceUtil()
    {
    }

    // throws Exception
    public virtual BasicArrayList getServicesObjectVector(BundleContext bundleContext, ServiceReference[] serviceReferences)
    {
        BasicArrayList vector = new BasicArrayListD();
        if (serviceReferences != null) {
            int size = serviceReferences.Length;
            this.logUtil.putF("Service References: " + size, this, "getServicesObjectVector");
            for (int index = 0; index < size; index++) {
                ServiceReference serviceReference = serviceReferences[index];
                if (serviceReference != null) {
                    OSGIServiceInterface osgiServiceInterface = ((OSGIServiceInterface) bundleContext.getService(serviceReference));
                    if (osgiServiceInterface == null) {
                        throw new Exception("No Service For Reference");
                    }
                    vector.add(osgiServiceInterface);
                }
            }
        }
        return vector;
    }

}

