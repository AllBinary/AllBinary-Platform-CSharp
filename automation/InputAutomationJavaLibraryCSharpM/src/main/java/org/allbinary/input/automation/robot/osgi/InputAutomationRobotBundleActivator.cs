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
using InputAutomationRobotChangeListener = bundle.input.automation.robot.InputAutomationRobotChangeListener;
using InputAutomationRobotServiceInterface = bundle.input.automation.robot.InputAutomationRobotServiceInterface;
using InputRobotInterface = org.allbinary.input.automation.robot.InputRobotInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using OSGIActivatorUtil = org.allbinary.osgi.OSGIActivatorUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.robot.osgi;

public class InputAutomationRobotBundleActivator : BundleActivator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private InputRobotInterface[] inputRobotInterface = null;
    private ServiceFactory serviceFactory = null;
    public InputAutomationRobotBundleActivator()
    {
        this.init();
    }

    // throws Exception
    public virtual void init()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void registerAsService(BundleContext bundleContext)
    {
        OSGIActivatorUtil.registerAsService(bundleContext, getServiceFactory(), typeof(InputAutomationRobotServiceInterface).getName());
    }

    // throws Exception
    private InputAutomationRobotChangeListener getInputAutomationRobotChangeListener(BundleContext context)
    {
        ServiceReference serviceReference = context.getServiceReference(typeof(InputAutomationRobotChangeListener).getName());
        if (serviceReference != null) {
            InputAutomationRobotChangeListener inputAutomationRobotChangeListener = ((InputAutomationRobotChangeListener) context.getService(serviceReference));
            if (inputAutomationRobotChangeListener == null) {
                throw new Exception("No Service For ServiceReference");
            }
            return inputAutomationRobotChangeListener;
        } else {
            this.logUtil.putF("No ServiceReference: " + typeof(InputAutomationRobotChangeListener).getName(), this, "getInputAutomationRobotChangeListener");
            return null;
        }
    }

    private void addRobots(BundleContext context)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "addRobots");
            InputAutomationRobotChangeListener inputAutomationRobotChangeListener = this.getInputAutomationRobotChangeListener(context);
            if (inputAutomationRobotChangeListener != null) {
                for (int index = 0; index < this.getInputRobotInterface().Length; index++) {
                    InputAutomationRobotChangeEvent inputAutomationRobotChangeEvent = InputAutomationRobotUtil.getChangeEvent(this.getInputRobotInterface()[index]);
                    inputAutomationRobotChangeListener.onAdd(inputAutomationRobotChangeEvent);
                }
            }
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION, this, "addModules");
        }
    }

    private void removeRobots(BundleContext context)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "removeRobots");
            InputAutomationRobotChangeListener inputAutomationRobotChangeListener = this.getInputAutomationRobotChangeListener(context);
            if (inputAutomationRobotChangeListener != null) {
                for (int index = 0; index < this.getInputRobotInterface().Length; index++) {
                    InputAutomationRobotChangeEvent inputAutomationRobotChangeEvent = InputAutomationRobotUtil.getChangeEvent(this.getInputRobotInterface()[index]);
                    inputAutomationRobotChangeListener.onRemove(inputAutomationRobotChangeEvent);
                }
            }
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION, this, "removeRobots");
        }
    }

    // throws Exception
    public virtual void start(BundleContext context)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.START);
        this.addRobots(context);
        this.registerAsService(context);
    }

    // throws Exception
    public virtual void stop(BundleContext context)
    {
        this.logUtil.putF("Stop", this, this.commonStrings.START);
        this.removeRobots(context);
    }

    public virtual object getServiceFactory()
    {
        return this.serviceFactory;
    }

    public virtual void setServiceFactory(ServiceFactory serviceObject)
    {
        this.serviceFactory = serviceObject;
    }

    public virtual InputRobotInterface[] getInputRobotInterface()
    {
        return this.inputRobotInterface;
    }

    public virtual void setInputRobotInterface(InputRobotInterface[] inputRobotInterface)
    {
        this.inputRobotInterface = inputRobotInterface;
    }

}

