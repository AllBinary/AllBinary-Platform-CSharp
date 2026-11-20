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
//using PageContext = javax.servlet.jsp.PageContext;
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.control.workflow;

public class StoreTagWorkFlowFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly StoreTagWorkFlowFactory instance = new StoreTagWorkFlowFactory();
    public static StoreTagWorkFlowFactory getInstance()
    {
        return StoreTagWorkFlowFactory.instance;
    }

    private StoreTagWorkFlowFactory()
    {
    }

    // throws Exception, LicensingException
    public virtual StoreWorkFlowInterface getInstance(AbeClientInformationInterface abeClientInformation, HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        try {
            string workFlowClassName = ((string) propertiesHashMap.get(DynamicObjectData.NAME));
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Creating WorkFlow: ");
                stringBuffer.append(workFlowClassName);
                stringBuffer.append("->");
                stringBuffer.append(StoreTagWorkFlowFactory.instance.GetType().FullName);
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.putF(stringBuffer.ToString(), this, commonStrings.GET_INSTANCE);
            }
            object[] @params = new object[2];
            Type[] classes = new Type[2];
            classes[0] = propertiesHashMap.GetType();
            classes[1] = AbeFactory.getInstance().getClass(abeClientInformation, "javax.servlet.jsp.PageContext");
            @params[0] = ((object) propertiesHashMap);
            @params[1] = ((object) pageContext);
            return ((StoreWorkFlowInterface) AbeFactory.getInstance().getInstance(abeClientInformation, workFlowClassName, classes, @params));
        } catch (LicensingException e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                string workFlowClassName = ((string) propertiesHashMap.get(DynamicObjectData.NAME));
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Error Creating WorkFlow: ");
                stringBuffer.append(workFlowClassName);
                stringBuffer.append("->");
                stringBuffer.append(StoreTagWorkFlowFactory.instance.GetType().FullName);
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(stringBuffer.ToString(), this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                string workFlowClassName = ((string) propertiesHashMap.get(DynamicObjectData.NAME));
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Error Creating WorkFlow: ");
                stringBuffer.append(workFlowClassName);
                stringBuffer.append("->");
                stringBuffer.append(StoreTagWorkFlowFactory.instance.GetType().FullName);
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(stringBuffer.ToString(), this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

