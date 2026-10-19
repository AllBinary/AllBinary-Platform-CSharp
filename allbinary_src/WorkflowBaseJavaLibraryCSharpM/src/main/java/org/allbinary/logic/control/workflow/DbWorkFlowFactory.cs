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
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.control.workflow;

public class DbWorkFlowFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly DbWorkFlowFactory instance = new DbWorkFlowFactory();
    public static DbWorkFlowFactory getInstance()
    {
        return DbWorkFlowFactory.instance;
    }

    private DbWorkFlowFactory()
    {
    }

    // throws Exception, LicensingException
    public virtual WorkFlowInterface getInstance(AbeClientInformationInterface abeClientInformation, HashMap hashMap)
    {
        try {
            string className = ((string) hashMap.get(DynamicObjectData.NAME));
            object[] @params = new object[1];
            Type[] classes = new Type[1];
            classes[0] = hashMap.GetType();
            @params[0] = ((object) hashMap);
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

}

