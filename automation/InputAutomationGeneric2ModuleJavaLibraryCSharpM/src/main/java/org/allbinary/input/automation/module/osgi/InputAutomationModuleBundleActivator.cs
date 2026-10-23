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
using ServiceFactory = org.osgi.framework.ServiceFactory;
using ServiceReference = org.osgi.framework.ServiceReference;
using InputAutomationModuleServiceInterface = bundle.input.automation.module.InputAutomationModuleServiceInterface;
using InputAutomationConfigurationModuleChangeListener = bundle.input.automation.module.configuration.InputAutomationConfigurationModuleChangeListener;
using InputAutomationConfigurationModuleChangeEvent = org.allbinary.input.automation.configuration.InputAutomationConfigurationModuleChangeEvent;
using InputAutomationConfigurationUtil = org.allbinary.input.automation.configuration.InputAutomationConfigurationUtil;
using InputAutomationModuleFactoryInterface = org.allbinary.input.automation.module.InputAutomationModuleFactoryInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using OSGIActivatorUtil = org.allbinary.osgi.OSGIActivatorUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.module.osgi;

public class InputAutomationModuleBundleActivator : BundleActivator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private InputAutomationModuleFactoryInterface[] inputAutomationModuleInterface = null;
    private ServiceFactory serviceFactory = null;
    public InputAutomationModuleBundleActivator()
    {
        this.init();
    }

    // throws Exception
    public virtual void init()
    {
        throw new SystemException();
    }

    // throws Exception
    private InputAutomationConfigurationModuleChangeListener getInputAutomationConfigurationModuleChangeListener(BundleContext context)
    {
        ServiceReference serviceReference = context.getServiceReference(typeof(InputAutomationConfigurationModuleChangeListener).getName());
        if (serviceReference != null) {
            InputAutomationConfigurationModuleChangeListener inputAutomationConfigurationModuleChangeListener = ((InputAutomationConfigurationModuleChangeListener) context.getService(serviceReference));
            if (inputAutomationConfigurationModuleChangeListener == null) {
                throw new Exception("No Service For ServiceReference");
            }
            return inputAutomationConfigurationModuleChangeListener;
        } else {
            this.logUtil.putF("No ServiceReference: " + typeof(InputAutomationConfigurationModuleChangeListener).getName(), this, "addModules");
            return null;
        }
    }

    private void addModules(BundleContext context)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "addModules");
            InputAutomationConfigurationModuleChangeListener inputAutomationConfigurationModuleChangeListener = this.getInputAutomationConfigurationModuleChangeListener(context);
            if (inputAutomationConfigurationModuleChangeListener != null) {
                for (int index = 0; index < this.getInputAutomationModuleInterface().Length; index++) {
                    InputAutomationConfigurationModuleChangeEvent inputAutomationConfigurationModuleChangeEvent = InputAutomationConfigurationUtil.getChangeEvent(this.getInputAutomationModuleInterface()[index]);
                    inputAutomationConfigurationModuleChangeListener.onAdd(inputAutomationConfigurationModuleChangeEvent);
                }
            }
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION, this, "addModules");
        }
    }

    // throws Exception
    public virtual void registerAsService(BundleContext bundleContext)
    {
        OSGIActivatorUtil.registerAsService(bundleContext, getServiceFactory(), typeof(InputAutomationModuleServiceInterface).getName());
    }

    private void removeModules(BundleContext context)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "removeModules");
            InputAutomationConfigurationModuleChangeListener inputAutomationConfigurationModuleChangeListener = this.getInputAutomationConfigurationModuleChangeListener(context);
            if (inputAutomationConfigurationModuleChangeListener != null) {
                for (int index = 0; index < this.getInputAutomationModuleInterface().Length; index++) {
                    InputAutomationConfigurationModuleChangeEvent inputAutomationConfigurationModuleChangeEvent = InputAutomationConfigurationUtil.getChangeEvent(this.getInputAutomationModuleInterface()[index]);
                    inputAutomationConfigurationModuleChangeListener.onRemove(inputAutomationConfigurationModuleChangeEvent);
                }
            }
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION, this, "removeModules");
        }
    }

    // throws Exception
    public virtual void start(BundleContext context)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.START);
        this.addModules(context);
        this.registerAsService(context);
    }

    // throws Exception
    public virtual void stop(BundleContext context)
    {
        this.logUtil.putF(this.commonStrings.START, this, "stop");
        this.removeModules(context);
    }

    public virtual InputAutomationModuleFactoryInterface[] getInputAutomationModuleInterface()
    {
        return this.inputAutomationModuleInterface;
    }

    public virtual void setInputAutomationModuleInterface(InputAutomationModuleFactoryInterface[] inputAutomationModuleInterface)
    {
        this.inputAutomationModuleInterface = inputAutomationModuleInterface;
    }

    public virtual object getServiceFactory()
    {
        return this.serviceFactory;
    }

    public virtual void setServiceFactory(ServiceFactory serviceObject)
    {
        this.serviceFactory = serviceObject;
    }

}

