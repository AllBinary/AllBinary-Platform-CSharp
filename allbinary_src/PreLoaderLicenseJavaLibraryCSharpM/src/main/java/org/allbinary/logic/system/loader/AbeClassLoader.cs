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
//using FileInputStream = java.io.FileInputStream;
//using IOException = java.io.IOException;
using java.util;
using StdUtil = org.allbinary.logic.StdUtil;
using LogBuffer = org.allbinary.logic.communication.log.LogBuffer;
using LogFactory = org.allbinary.logic.communication.log.LogFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbCryptUtil = org.allbinary.logic.system.security.AbCryptUtil;

namespace org.allbinary.logic.system.loader;

public class AbeClassLoader : ClassLoader
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbCryptUtil abCryptUtil = AbCryptUtil.getInstance();
    private readonly string LOAD_CLASS = "loadClass";
    private static Map<object, object> classes = StdUtil.getInstance().createHashMap();
    private readonly string ENCRYPTED_EXTENSION = AbPathData.getInstance().EXTENSION_SEP + "abc";
    private static string PATH;
    private string key;
    public AbeClassLoader(ClassLoader parent, string key) : base(parent)
    {
        // base(parent) is called from the constructor declaration
        this.key = key;
        AbeClassLoader.PATH = org.allbinary.globals.URLGLOBALS.getWebappPath() + "WEB-INF/classes/";
    }

    protected virtual Type findLoadedClass1(string name)
    {
        return ((Type) AbeClassLoader.classes.get(name));
    }

    // throws ClassNotFoundException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual Type loadClass(string name)
    {
        return this.loadClass(name, false);
    }

    // throws ClassNotFoundException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual Type loadClass(string name, bool resolve)
    {
        string loadedWith = "findLoadedClass1";
        LogBuffer logBuffer = new LogBuffer();
        try {
            Type myClass = this.findLoadedClass1(name);
            if (myClass == null) {
                try {
                    loadedWith = "super.loadClass";
                    Type normalClass = base.loadClass(name, resolve);
                    if (normalClass != null) {
                        return normalClass;
                    }
                } catch (ClassNotFoundException e) {
                    logBuffer.add(LogFactory.getInstance("Failed to Load Class: " + name + "\nwith: " + loadedWith, this, this.LOAD_CLASS, e));
                } catch (Exception e) {
                    logBuffer.add(LogFactory.getInstance("Failed to Load Class: " + name + "\nwith: " + loadedWith, this, this.LOAD_CLASS, e));
                } catch (NoClassDefFoundError e) {
                    logBuffer.add(LogFactory.getInstanceF("NoClassDefFoundError Failed Loaded Class: " + name + "\nwith: " + loadedWith, this, this.LOAD_CLASS));
                }
                sbyte[] classBytes = this.loadClassBytesFromFile(name);
                if (classBytes == null) {
                    throw new ClassNotFoundException("My Bytes not loaded for: " + name + "\nwith: " + "loadClassBytes");
                }
                myClass = defineClass(name, classBytes, 0, classBytes.Length);
                if (myClass == null) {
                    throw new ClassNotFoundException("My Class Not Defineable for: " + name + "\nwith: " + "loadClassBytes");
                }
                AbeClassLoader.classes.put(name, myClass);
            } else {
                logBuffer.add(LogFactory.getInstanceF("Already Loaded: " + name + "\nwith: " + loadedWith, this, this.LOAD_CLASS));
            }
            resolveClass(myClass);
            return myClass;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                logBuffer.logAll();
                this.logUtil.put("Failure loading: " + name + "\nwith: " + loadedWith, this, this.LOAD_CLASS, e);
            }
            return null;
        }
    }

    private sbyte[] loadClassBytesFromFile(string name)
    {
        FileInputStream @in = null;
        string cname = StringUtil.getInstance().EMPTY_STRING;
        try {
            cname = AbeClassLoader.PATH + name.Replace('.', AbPathData.getInstance().SEPARATORCHAR) + this.ENCRYPTED_EXTENSION;
            @in = new FileInputStream(cname);
            sbyte[] decrypted = this.abCryptUtil.decrypt(@in, this.key);
            return decrypted;
        } catch (IOException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                this.logUtil.put("(Before LogBuffer Output) Failure loading Encrypted: " + name + " File: " + cname, "AbeClassLoader", "loadClassBytes", e);
            }
            StreamUtil.getInstance().close(@in);
        } catch (Exception e) {
            string loadedWith = "loadClassBytes";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                this.logUtil.put("(Before LogBuffer Output) Failed to Loaded Class: " + name + " File: " + cname + "\nwith: " + loadedWith, this, "loadClassBytes", e);
            }
        } catch (NoClassDefFoundError e) {
            string loadedWith = "loadClassBytes";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                this.logUtil.putF("(Before LogBuffer Output) NoClassDefFoundError Failed Loaded Class: " + name + " File: " + cname + "\nwith: " + loadedWith, this, "loadClassBytes");
            }
        }
        return null;
    }

    // throws ClassNotFoundException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual Type oldLoadClass(string name, bool resolve)
    {
        string loadedWith = "findLoadedClass1";
        try {
            Type myClass = this.findLoadedClass1(name);
            if (myClass == null) {
                try {
                    loadedWith = "super.loadClass";
                    Type normalClass = base.loadClass(name, resolve);
                    if (normalClass != null) {
                        return normalClass;
                    }
                } catch (ClassNotFoundException e) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADER)) {
                        this.logUtil.putF("Failed Loaded Class: " + name + " with: " + loadedWith, this, this.LOAD_CLASS);
                    }
                } catch (Exception e) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADER)) {
                        this.logUtil.putF("Failed Loaded Class: " + name + " with: " + loadedWith, this, this.LOAD_CLASS);
                    }
                } catch (NoClassDefFoundError e) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADER)) {
                        this.logUtil.putF("Failed Loaded Class: " + name + " with: " + loadedWith, this, this.LOAD_CLASS);
                    }
                }
                loadedWith = "loadClassBytes";
                sbyte[] classBytes = this.loadClassBytesFromFile(name);
                if (classBytes == null) {
                    throw new ClassNotFoundException("Bytes not loaded for: " + name);
                }
                myClass = defineClass(name, classBytes, 0, classBytes.Length);
                if (myClass == null) {
                    throw new ClassNotFoundException("Class Not Defineable for: " + name);
                }
                AbeClassLoader.classes.put(name, myClass);
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADER)) {
                    this.logUtil.putF("Already Loaded: " + name + " with: " + loadedWith, this, this.LOAD_CLASS);
                }
            }
            resolveClass(myClass);
            return myClass;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                this.logUtil.put("Failure loading: " + name, "AbeClassLoader", this.LOAD_CLASS, e);
            }
            return null;
        }
    }

}

