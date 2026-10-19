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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.control.workflow;

public class NewWorkFlowFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly NewWorkFlowFactory instance = new NewWorkFlowFactory();
    public static NewWorkFlowFactory getInstance()
    {
        return NewWorkFlowFactory.instance;
    }

    private NewWorkFlowFactory()
    {
    }

    // throws Exception, LicensingException
    public virtual WorkFlowInterface getInstance(AbeClientInformationInterface abeClientInformation, HashMap hashMap, PageContext pageContext)
    {
        try {
            string className = ((string) hashMap.get(DynamicObjectData.NAME));
            object[] @params = new object[2];
            Type[] classes = new Type[2];
            classes[0] = hashMap.GetType();
            classes[1] = AbeFactory.getInstance().getClass(abeClientInformation, "javax.servlet.jsp.PageContext");
            @params[0] = ((object) hashMap);
            @params[1] = ((object) pageContext);
            object anyType = AbeFactory.getInstance().getInstance(abeClientInformation, className, classes, @params);
            return ((WorkFlowInterface) new WorkFlowWrapper(anyType));
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(HashMap)", e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(HashMap)", e);
            }
            throw e;
        }
    }

    // throws Exception, LicensingException
    public virtual WorkFlowInterface getInstance(AbeClientInformationInterface abeClientInformation, string className)
    {
        try {
            StringUtil stringUtil = StringUtil.getInstance();
            if (className != null && string.CompareOrdinal(className, stringUtil.EMPTY_STRING) != 0) {
                object anyType = AbeFactory.getInstance().getInstance(abeClientInformation, className, null, null);
                return ((WorkFlowInterface) new WorkFlowWrapper(anyType));
            } else {
                throw new Exception("No WorkFlow ClassName");
            }
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

