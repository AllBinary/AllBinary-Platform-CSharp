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
//using Constructor = java.lang.reflect.Constructor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ConstructorUtil = org.allbinary.logic.java.anyType.ConstructorUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbKeys = org.allbinary.logic.system.security.AbKeys;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.system.loader;

public class AbeFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AbeFactory instance = new AbeFactory();
    public static AbeFactory getInstance()
    {
        return AbeFactory.instance;
    }

    private bool useCustomLoader = false;
    private AbeFactory()
    {
    }

    // throws LicensingException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual object getInstance(AbeClientInformationInterface abeClientInformation, string className)
    {
        try {
            return this.getClass(abeClientInformation, className).newInstance();
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                this.logUtil.put("Failure for: " + className, this, "getInstance(classname)", e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                this.logUtil.put("Failure for: " + className, this, "getInstance(classname)", e);
            }
            return null;
        }
    }

    // throws LicensingException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual object getInstance(AbeClientInformationInterface abeClientInformation, string className, Type[] classes, object[] @params)
    {
        Constructor constructor = null;
        try {
            ClassLoader parent = WebappClassLoaderInfo.getLoader();
            if (this.useCustomLoader) {
                ClassLoader loader = new AbeClassLoader(parent, AbKeys.getInstance().getKey(abeClientInformation, className));
                Type myClass = loader.loadClass(className);
                constructor = myClass.getConstructor(classes);
                return constructor.newInstance(@params);
            } else {
                Type myClass = parent.loadClass(className);
                constructor = myClass.getConstructor(classes);
                return constructor.newInstance(@params);
            }
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Failure for: ");
                stringBuffer.append(className);
                stringBuffer.append(CommonSeps.getInstance().SPACE);
                stringBuffer.append(ConstructorUtil.view(constructor, CommonSeps.getInstance().NEW_LINE));
                this.logUtil.put(stringBuffer.ToString(), this, "getInstance(className,params)", e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Failure for: ");
                stringBuffer.append(className);
                stringBuffer.append(CommonSeps.getInstance().SPACE);
                stringBuffer.append(ConstructorUtil.view(constructor, CommonSeps.getInstance().NEW_LINE));
                this.logUtil.put(stringBuffer.ToString(), this, "getInstance(className,params)", e);
            }
            return null;
        }
    }

    // throws LicensingException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual Type getClass(AbeClientInformationInterface abeClientInformation, string className)
    {
        try {
            ClassLoader parent = WebappClassLoaderInfo.getLoader();
            if (this.useCustomLoader) {
                ClassLoader loader = new AbeClassLoader(parent, AbKeys.getInstance().getKey(abeClientInformation, className));
                Type c = loader.loadClass(className);
                return c;
            } else {
                Type c = parent.loadClass(className);
                return c;
            }
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                this.logUtil.put("Failure for: " + className, this, "getClass(className)", e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LOADERERROR)) {
                this.logUtil.put("Failure for: " + className, this, "getClass(className)", e);
            }
            return null;
        }
    }

}

