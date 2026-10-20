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

namespace org.allbinary.logic.control.workflow;

public class TagWorkFlowFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TagWorkFlowFactory instance = new TagWorkFlowFactory();
    public static TagWorkFlowFactory getInstance()
    {
        return TagWorkFlowFactory.instance;
    }

    private TagWorkFlowFactory()
    {
    }

    // throws Exception, LicensingException
    public virtual WorkFlowInterface getInstance(AbeClientInformationInterface abeClientInformation, HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        try {
            string workFlowClassName = ((string) propertiesHashMap.get(DynamicObjectData.NAME));
            object[] @params = new object[2];
            Type[] classes = new Type[2];
            classes[0] = propertiesHashMap.GetType();
            classes[1] = AbeFactory.getInstance().getClass(abeClientInformation, "javax.servlet.jsp.PageContext");
            @params[0] = ((object) propertiesHashMap);
            @params[1] = ((object) pageContext);
            return ((WorkFlowInterface) AbeFactory.getInstance().getInstance(abeClientInformation, workFlowClassName, classes, @params));
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                string workFlowClassName = ((string) propertiesHashMap.get(DynamicObjectData.NAME));
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Failed To Get Instance: ");
                stringBuffer.append(workFlowClassName);
                stringBuffer.append("->");
                stringBuffer.append(TagWorkFlowFactory.instance.GetType().FullName);
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(stringBuffer.ToString(), this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                string workFlowClassName = ((string) propertiesHashMap.get(DynamicObjectData.NAME));
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Failed To Get Instance: ");
                stringBuffer.append(workFlowClassName);
                stringBuffer.append("->");
                stringBuffer.append(TagWorkFlowFactory.instance.GetType().FullName);
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(stringBuffer.ToString(), this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

