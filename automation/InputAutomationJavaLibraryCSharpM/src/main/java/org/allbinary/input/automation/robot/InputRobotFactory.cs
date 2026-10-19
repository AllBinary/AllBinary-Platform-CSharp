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
//using GraphicsDevice = java.awt.GraphicsDevice;
//using GraphicsEnvironment = java.awt.GraphicsEnvironment;
//using Collection = java.util.Collection;
//using Iterator = java.util.Iterator;
//using Set = java.util.Set;
//using HelpSet = javax.help.HelpSet;
//using HelpSetEvent = javax.help.@event.HelpSetEvent;
//using HelpSetListener = javax.help.@event.HelpSetListener;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using JavaHelpSetNotifier = org.allbinary.logic.java.help.JavaHelpSetNotifier;
using InterfaceUtil = org.allbinary.logic.java.anyType.InterfaceUtil;
using SecuredNativeLibraryInterface = org.allbinary.logic.system.loader.SecuredNativeLibraryInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;

namespace org.allbinary.input.automation.robot;

public class InputRobotFactory
{
    private static readonly InputRobotFactory inputRobotFactory = new InputRobotFactory();
    // throws Exception
    public static InputRobotFactory getInstance()
    {
        return InputRobotFactory.inputRobotFactory;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private HelpSetListener helpSetListenerInterface = null;
    private InputRobotFactory()
    {
        try {
            GraphicsEnvironment graphenv = GraphicsEnvironment.getLocalGraphicsEnvironment();
            GraphicsDevice[] screens = graphenv.getScreenDevices();
            InputRobotInterface inputRobotInterface = null;
            for (int i = 0; i < screens.Length; i++) {
                inputRobotInterface = ((InputRobotInterface) new InputRobot(screens[i]));
                this.logUtil.putF("Adding Robot: " + inputRobotInterface.getName(), this, "getRobots");
                this.get().put(inputRobotInterface.getName(), inputRobotInterface);
            }
            this.logUtil.putF("Number Of Robots: " + this.hashtable.size(), this, "getRobots");
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public virtual void addListener(HelpSetListener helpSetListenerInterface)
    {
        this.helpSetListenerInterface = helpSetListenerInterface;
    }

    // throws Exception
    public virtual void add(InputRobotInterface inputRobotInterface)
    {
        this.logUtil.putF("Adding InputRobotInterface: " + inputRobotInterface.getName(), this, "add");
        this.get().put(inputRobotInterface.getName(), inputRobotInterface);
        HelpSet helpSet = inputRobotInterface.getHelpSet();
        if (this.helpSetListenerInterface != null) {
            if (helpSet != null) {
                if (!JavaHelpSetNotifier.isNotified(helpSet)) {
                    HelpSetEvent helpSetEvent = new HelpSetEvent(this, helpSet, HelpSetEvent.HELPSET_ADDED);
                    this.helpSetListenerInterface.helpSetAdded(helpSetEvent);
                }
            } else {
                this.logUtil.putF("Null HelpSet For: " + inputRobotInterface.getName(), this, "add");
            }
        } else {
            this.logUtil.putF("No HelpSet Listener", this, "add");
        }
    }

    // throws Exception
    public virtual void loadLibraries()
    {
        Set set = this.get().keySet();
        this.logUtil.putF("Loading Libraries", this, "loadLibraries");
        object[] nameArray = set.toArray();
        int size = nameArray.Length;
        for (int index = 0; index < size; index++) {
            InputRobotInterface inputRobotInterface = InputRobotFactory.getInstance().get(((string) nameArray[index]));
            InputRobotFactory.loadLibrary(inputRobotInterface);
        }
    }

    // throws Exception
    public static void loadLibraries(Collection collection)
    {
        LogUtil logUtil = LogUtil.getInstance();
        logUtil.putF("Loading Libraries", "InputRobotFactory", "loadLibraries");
        Iterator iterator = collection.iterator();
        while (iterator.hasNext()) {
            InputRobotFactory.loadLibrary(((InputRobotInterface) iterator.next()));
        }
    }

    // throws Exception
    public static void loadLibrary(InputRobotInterface inputRobotInterface)
    {
        LogUtil logUtil = LogUtil.getInstance();
        if (InterfaceUtil.isImplemented(typeof(SecuredNativeLibraryInterface), inputRobotInterface)) {
            logUtil.putF("Loading Library: " + inputRobotInterface.getName(), "InputRobotFactory", "loadLibraries");
            SecuredNativeLibraryInterface securedNativeLibraryInterface = ((SecuredNativeLibraryInterface) inputRobotInterface);
            securedNativeLibraryInterface.load();
        }
    }

    // throws Exception
    public virtual void unloadLibraries()
    {
        this.logUtil.putF("Unloading Libraries", this, "unloadLibraries");
        Set set = this.get().keySet();
        InputRobotInterface inputRobotInterface = null;
        object[] inputRobotArray = set.toArray();
        int size = inputRobotArray.Length;
        for (int index = 0; index < size; index++) {
            inputRobotInterface = this.get(((string) inputRobotArray[index]));
            if (InterfaceUtil.isImplemented(typeof(SecuredNativeLibraryInterface), inputRobotInterface)) {
                this.logUtil.putF("Unloading Library: " + inputRobotInterface.getName(), this, "unloadLibraries");
                SecuredNativeLibraryInterface securedNativeLibraryInterface = ((SecuredNativeLibraryInterface) inputRobotInterface);
                securedNativeLibraryInterface.unload();
            }
        }
    }

    // throws Exception
    public virtual ABHashtable<object, object> get()
    {
        return this.hashtable;
    }

    public virtual InputRobotInterface get(string name)
    {
        this.logUtil.putF("Getting Robot: " + name, this, "getRobots");
        return ((InputRobotInterface) this.hashtable.get(name));
    }

}

