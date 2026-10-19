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
//using javax.swing;
using Bundle = org.osgi.framework.Bundle;
using BundleContext = org.osgi.framework.BundleContext;
using InputAutomationBundleActivator = bundle.input.automation.InputAutomationBundleActivator;
using BasicTextJDialog = org.allbinary.gui.dialog.BasicTextJDialog;

namespace org.allbinary.input.automation.osgi;

public class DesktopBundle
{
    private static readonly string DESKTOP_SYMBOLIC_NAME = "org.knopflerfish.bundle.desktop";
    private Bundle bundle = null;
    public DesktopBundle()
    {
        BundleContext bundleContext = InputAutomationBundleActivator.getBundleContext();
        if (bundleContext != null) {
            Bundle[] bundleArray = bundleContext.getBundles();
            for (int index = 0; index < bundleArray.Length; index++) {
                Bundle bundle = bundleArray[index];
                string symbolicName = bundle.getSymbolicName();
                if (string.CompareOrdinal(symbolicName, DesktopBundle.DESKTOP_SYMBOLIC_NAME) == 0) {
                    this.bundle = bundle;
                }
            }
        } else {
            JDialog textJDialog = new BasicTextJDialog("BundlContext is Null");
            textJDialog.setVisible(true);
        }
    }

    // throws Exception
    public virtual void start()
    {
        this.bundle.start();
    }

}

