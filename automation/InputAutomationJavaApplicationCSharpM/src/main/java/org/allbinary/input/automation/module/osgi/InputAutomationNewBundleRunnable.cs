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
using System.Runtime.CompilerServices;
//using File = java.io.File;
//using FileFilter = java.io.FileFilter;
//using FileInputStream = java.io.FileInputStream;
//using URL = java.net.URL;
using java.util;
//using JarInputStream = java.util.jar.JarInputStream;
//using Manifest = java.util.jar.Manifest;
using Bundle = org.osgi.framework.Bundle;
using BundleContext = org.osgi.framework.BundleContext;
using Constants = org.osgi.framework.Constants;
using InputAutomationBundleActivator = bundle.input.automation.InputAutomationBundleActivator;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using FileWrapperUtil = org.allbinary.logic.io.file.FileWrapperUtil;
using SubDirectory = org.allbinary.logic.io.file.directory.SubDirectory;
using BasicFileFilterUtil = org.allbinary.logic.io.file.filter.BasicFileFilterUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using RunnableInterface = org.allbinary.thread.RunnableInterface;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.input.automation.module.osgi;

public class InputAutomationNewBundleRunnable : RunnableInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private static readonly string FILE = "file:";
    private static readonly string JAR_DIR_PROP = "org.knopflerfish.gosg.jars";
    private static readonly string INPUT_AUTMATION_MODULE_BUNDLE_JAR_PATH = "ia/auto";
    private static readonly int MODULES_START_LEVEL = 8;
    private readonly InputAutomationBundleActivator inputAutomationBundleActivator;
    private bool running = false;
    private BasicArrayList fileBasicArrayList;
    public InputAutomationNewBundleRunnable(InputAutomationBundleActivator inputAutomationBundleActivator)
    {
        this.inputAutomationBundleActivator = inputAutomationBundleActivator;
        this.fileBasicArrayList = new BasicArrayListD();
    }

    // throws Exception
    public virtual void setThread(Thread thread)
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isRunning()
    {
        return this.running;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setRunning(bool running)
    {
        this.running = running;
    }

    // throws Exception
    private void updateModules()
    {
        this.logUtil.putF(this.commonStrings.START, this, "updateModules");
        BasicArrayList list = this.findNewModules();
        int size = list.size();
        Bundle bundle = null;
        for (int index = 0; index < size; index++) {
            bundle = this.install(((URL) list.get(index)));
            if (bundle != null) {
                bundle.start(InputAutomationNewBundleRunnable.MODULES_START_LEVEL);
            }
        }
    }

    // throws Exception
    private HashMap getAllJarSymbolicNameHashMap()
    {
        this.logUtil.putF(this.commonStrings.START, this, "getAllJarSymbolicNameHashMap");
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        BasicArrayList jarFileBasicArrayList = this.getJarModuleFileBasicArrayList();
        this.logUtil.putF("Jar Module Files: " + jarFileBasicArrayList, this, "getAllJarSymbolicNameHashMap");
        int size = jarFileBasicArrayList.size();
        File file = null;
        for (int index = 0; index < size; index++) {
            file = ((File) jarFileBasicArrayList.get(index));
            if (!file.isDirectory()) {
                FileInputStream fileInputStream = new FileInputStream(file);
                JarInputStream jarInputStream = new JarInputStream(fileInputStream);
                Manifest manifest = jarInputStream.getManifest();
                if (manifest == null) {
                } else {
                    string symbolicName = manifest.getMainAttributes().getValue(Constants.BUNDLE_SYMBOLICNAME);
                    if (symbolicName != null) {
                        hashMap.put(symbolicName, new URL(InputAutomationNewBundleRunnable.FILE + file.getAbsolutePath()));
                    }
                }
            }
        }
        return hashMap;
    }

    private BasicArrayList getJarModuleFileBasicArrayList()
    {
        this.logUtil.putF(this.commonStrings.START, this, "getJarModuleFileBasicArrayList");
        string baseJarPath = global::java.lang.JavaSystem.getProperty(JAR_DIR_PROP);
        if (baseJarPath.StartsWith(InputAutomationNewBundleRunnable.FILE)) {
            baseJarPath = baseJarPath.Substring(InputAutomationNewBundleRunnable.FILE.length());
        }
        FileFilter jarFileFilter = BasicFileFilterUtil.getInstance(".jar");
        string path = baseJarPath + InputAutomationNewBundleRunnable.INPUT_AUTMATION_MODULE_BUNDLE_JAR_PATH;
        this.logUtil.putF("Path: " + path, this, "getJarModuleFileBasicArrayList");
        File file = new File(path);
        this.logUtil.putF("File: " + file.getAbsolutePath() + " isDirectory: " + file.isDirectory(), this, "getJarModuleFileBasicArrayList");
        return SubDirectory.getInstance().search(jarFileFilter, FileWrapperUtil.wrapFile(file));
    }

    // throws Exception
    private BasicArrayList getInstalledJarSymbolicNameBasicArrayList()
    {
        this.logUtil.putF(this.commonStrings.START, this, "getInstalledJarSymbolicNameBasicArrayList");
        BasicArrayList vector = new BasicArrayListD();
        BundleContext bundleContext = InputAutomationBundleActivator.getBundleContext();
        Bundle[] bundleArray = bundleContext.getBundles();
        if (bundleArray != null) {
            this.logUtil.putF("bundleArray: " + bundleArray.Length, this, "getInputAutomationModuleServices");
            for (int index = 0; index < bundleArray.Length; index++) {
                Bundle bundle = bundleArray[index];
                vector.add(bundle.getSymbolicName());
            }
        }
        return vector;
    }

    // throws Exception
    private bool isInstalled(string symbolicName)
    {
        this.logUtil.putF(CommonLabels.getInstance().START + symbolicName, this, "isInstalled");
        BasicArrayList list = this.getInstalledJarSymbolicNameBasicArrayList();
        int size = list.size();
        string nextSymbolicName = null;
        for (int index = 0; index < size; index++) {
            nextSymbolicName = ((string) list.get(index));
            if (string.CompareOrdinal(nextSymbolicName, symbolicName) == 0) {
                return true;
            }
        }
        return false;
    }

    // throws Exception
    private BasicArrayList findNewModules()
    {
        this.logUtil.putF(this.commonStrings.START, this, "findNewModules");
        BasicArrayList vector = new BasicArrayListD();
        HashMap hashMap = this.getAllJarSymbolicNameHashMap();
        this.logUtil.putF("All: " + hashMap, this, "findNewModules");
        Set set = hashMap.keySet();
        object[] symbolicNameArray = set.toArray();
        int size = symbolicNameArray.Length;
        for (int index = 0; index < size; index++) {
            string symbolicName = ((string) symbolicNameArray[index]);
            if (!this.isInstalled(symbolicName)) {
                vector.add(hashMap.get(symbolicName));
            }
        }
        return vector;
    }

    // throws Exception
    private Bundle install(URL url)
    {
        this.logUtil.putF(CommonLabels.getInstance().START + url, this, "install");
        BundleContext bundleContext = InputAutomationBundleActivator.getBundleContext();
        return bundleContext.installBundle(url.ToString());
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.RUN);
            this.setRunning(true);
            TimeDelayHelper timeHelper = new TimeDelayHelper(1000);
            while (this.isRunning()) {
                timeHelper.setStartTimeTNT();
                this.logUtil.putF(CommonLabels.getInstance().ELAPSED + timeHelper.getElapsedTNT(), this, this.commonStrings.RUN);
                this.updateModules();
                break;
            }
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

