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
using java.util;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace admin.taghelpers;

public class HelperFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public HelperFactory()
    {
    }

    // throws LicensingException
    public static object getInstance(AbeClientInformationInterface abeClientInformation, string factoryName, string className, HashMap<object, object> hashMap, HttpServletRequest httpServletRequest)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            object[] @params = new object[2];
            Type[] classes = new Type[2];
            AbeFactory abeFactory = AbeFactory.getInstance();
            classes[0] = hashMap.GetType();
            classes[1] = abeFactory.getClass(abeClientInformation, "javax.servlet.http.HttpServletRequest");
            @params[0] = ((object) hashMap);
            @params[1] = ((object) httpServletRequest);
            object anyType = abeFactory.getInstance(abeClientInformation, className, classes, @params);
            return anyType;
        } catch (LicensingException e) {
            string error = "Failed To Get Instance Args: HashMap=" + hashMap.ToString() + " HttpServletRequest=" + httpServletRequest;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                logUtil.put(error, factoryName + "->HelperFactory", "getInstance(String, String, HashMap, PageContext)", e);
            }
            throw e;
        } catch (Exception e) {
            string error = "Failed To Get Instance";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                logUtil.put(error, factoryName + "->HelperFactory", "getInstance(String, String, HashMap, PageContext)", e);
            }
            return null;
        }
    }

    // throws LicensingException
    public static object getInstance(AbeClientInformationInterface abeClientInformation, string factoryName, string className, HashMap<object, object> hashMap, PageContext pageContext)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            object[] @params = new object[2];
            Type[] classes = new Type[2];
            AbeFactory abeFactory = AbeFactory.getInstance();
            classes[0] = hashMap.GetType();
            classes[1] = abeFactory.getClass(abeClientInformation, "javax.servlet.jsp.PageContext");
            @params[0] = ((object) hashMap);
            @params[1] = ((object) pageContext);
            object anyType = abeFactory.getInstance(abeClientInformation, className, classes, @params);
            return anyType;
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                string error = "Failed To Get Instance Args: HashMap=" + hashMap.ToString() + " PageContext=" + pageContext;
                logUtil.put(error, factoryName + "->HelperFactory", "getInstance(String, String, HashMap, PageContext)", e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, factoryName + "->HelperFactory", "getInstance(String, String, HashMap, PageContext)", e);
            }
            return null;
        }
    }

    // throws LicensingException
    public static object getInstance(AbeClientInformationInterface abeClientInformation, string factoryName, string className, HashMap<object, object> hashMap, HashMap<object, object> specialhashMap, PageContext pageContext)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            object[] @params = new object[3];
            Type[] classes = new Type[3];
            AbeFactory abeFactory = AbeFactory.getInstance();
            classes[0] = hashMap.GetType();
            classes[1] = specialhashMap.GetType();
            classes[2] = abeFactory.getClass(abeClientInformation, "javax.servlet.jsp.PageContext");
            @params[0] = ((object) hashMap);
            @params[1] = ((object) specialhashMap);
            @params[2] = ((object) pageContext);
            object anyType = abeFactory.getInstance(abeClientInformation, className, classes, @params);
            return anyType;
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                string error = "Failed To Get Instance Args: HashMap=" + hashMap.ToString() + " PageContext=" + pageContext;
                logUtil.put(error, factoryName + "->HelperFactory", "getInstance(String, String, HashMap, PageContext)", e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, factoryName + "->HelperFactory", "getInstance(String, String, HashMap, PageContext)", e);
            }
            return null;
        }
    }

    // throws LicensingException
    public static object getInstance(AbeClientInformationInterface abeClientInformation, string factoryName, string className)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            object anyType = AbeFactory.getInstance().getInstance(abeClientInformation, className);
            return anyType;
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, factoryName + "->HelperFactory", "getInstance(String, String, HashMap, PageContext)", e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, factoryName + "->HelperFactory", "getInstance(String, String, HashMap, PageContext)", e);
            }
            return null;
        }
    }

}

