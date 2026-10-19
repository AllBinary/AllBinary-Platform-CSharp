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
using BundleContext = org.osgi.framework.BundleContext;
using ServiceReference = org.osgi.framework.ServiceReference;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using OSGIServiceInterface = org.allbinary.osgi.OSGIServiceInterface;
using OSGIServiceVisitorInterface = org.allbinary.osgi.OSGIServiceVisitorInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.osgi.service;

public class InputAutomationServiceConsumer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly OSGIServiceUtil osgiServiceUtil = OSGIServiceUtil.getInstance();
    private string registryName = null;
    private BundleContext bundleContext = null;
    private OSGIServiceVisitorInterface osgiServiceVisitorInterface = null;
    public InputAutomationServiceConsumer(string registryName, BundleContext bundleContext, OSGIServiceVisitorInterface osgiServiceVisitorInterface)
    {
        this.setRegistryName(registryName);
        this.setBundleContext(bundleContext);
        this.setOsgiServiceVisitorInterface(osgiServiceVisitorInterface);
    }

    // throws Exception
    public virtual void process()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.PROCESS);
        BasicArrayList vector = this.osgiServiceUtil.getServicesObjectVector(this.getBundleContext(), this.getServiceReferences());
        this.logUtil.putF("Processing " + vector.size() + " Services", this, this.commonStrings.PROCESS);
        int size = vector.size();
        OSGIServiceInterface osgiServiceInterface = null;
        for (int index = 0; index < size; index++) {
            osgiServiceInterface = ((OSGIServiceInterface) vector.get(index));
            if (!getOsgiServiceVisitorInterface().visit(osgiServiceInterface)) {
                throw new Exception("Unable to process service: " + osgiServiceInterface);
            }
        }
    }

    // throws Exception
    private ServiceReference[] getServiceReferences()
    {
        return this.getBundleContext().getServiceReferences(this.getRegistryName(), null);
    }

    public virtual BundleContext getBundleContext()
    {
        return this.bundleContext;
    }

    public virtual void setBundleContext(BundleContext aBundleContext)
    {
        this.bundleContext = aBundleContext;
    }

    public virtual string getRegistryName()
    {
        return this.registryName;
    }

    public virtual void setRegistryName(string registryName)
    {
        this.registryName = registryName;
    }

    public virtual OSGIServiceVisitorInterface getOsgiServiceVisitorInterface()
    {
        return this.osgiServiceVisitorInterface;
    }

    public virtual void setOsgiServiceVisitorInterface(OSGIServiceVisitorInterface osgiServiceVisitorInterface)
    {
        this.osgiServiceVisitorInterface = osgiServiceVisitorInterface;
    }

}

