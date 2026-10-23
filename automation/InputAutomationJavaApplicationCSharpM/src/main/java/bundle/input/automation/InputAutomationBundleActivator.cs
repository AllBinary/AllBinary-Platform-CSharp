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
using InputAutomationConfigurationModuleChangeListener = bundle.input.automation.module.configuration.InputAutomationConfigurationModuleChangeListener;
using InputAutomationRobotChangeListener = bundle.input.automation.robot.InputAutomationRobotChangeListener;
using InputAutomationJFrame = org.allbinary.input.automation.InputAutomationJFrame;
using InputAutomationModuleServiceConsumer = org.allbinary.input.automation.module.osgi.InputAutomationModuleServiceConsumer;
using InputAutomationNewBundleRunnable = org.allbinary.input.automation.module.osgi.InputAutomationNewBundleRunnable;
using InputAutomationServiceFactory = org.allbinary.input.automation.osgi.InputAutomationServiceFactory;
using InputAutomationRobotServiceConsumer = org.allbinary.input.automation.robot.osgi.InputAutomationRobotServiceConsumer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using OSGIActivatorUtil = org.allbinary.osgi.OSGIActivatorUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace bundle.input.automation;

public class InputAutomationBundleActivator : BundleActivator, InputAutomationBundleActivatorListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private static global::org.allbinary.thread.NullThread moduleManagementThread = null;
    private static BundleContext bundleContext = null;
    public static BundleContext getBundleContext()
    {
        return InputAutomationBundleActivator.bundleContext;
    }

    // throws Exception
    public virtual void start(BundleContext bundleContext)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.START);
            this.bundleContext = bundleContext;
            InputAutomationBundleActivator.moduleManagementThread = new global::org.allbinary.thread.NullThread(new InputAutomationNewBundleRunnable(this));
            InputAutomationBundleActivator.moduleManagementThread.start();
            InputAutomationJFrame.create(this);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.START, e);
            throw e;
        }
    }

    // throws Exception
    public virtual void registerAsService()
    {
        OSGIActivatorUtil.registerAsService(this.getBundleContext(), InputAutomationServiceFactory.getInstance(), typeof(InputAutomationConfigurationModuleChangeListener).getName());
        OSGIActivatorUtil.registerAsService(this.getBundleContext(), InputAutomationServiceFactory.getInstance(), typeof(InputAutomationRobotChangeListener).getName());
    }

    // throws Exception
    public virtual void useServices()
    {
        new InputAutomationRobotServiceConsumer(this.getBundleContext()).process();
        new InputAutomationModuleServiceConsumer(this.getBundleContext()).process();
    }

    // throws Exception
    public virtual void stop(BundleContext context)
    {
        this.logUtil.putF(this.commonStrings.START, this, "stop");
        if (InputAutomationJFrame.getInstance() != null) {
            InputAutomationJFrame.destroy();
        } else {
            this.logUtil.putF("Nothing to stop", this, "stop");
        }
    }

}

