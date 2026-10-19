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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoObjectFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformInfoObjectFactory instance = new TransformInfoObjectFactory();
    public static TransformInfoObjectFactory getInstance()
    {
        return TransformInfoObjectFactory.instance;
    }

    private TransformInfoObjectFactory()
    {
    }

    // throws Exception
    public virtual TransformInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.putF("Creating View: " + transformInfoInterface.getName(), this, commonStrings.GET_INSTANCE);
            }
            object[] @params = new object[1];
            Type[] classes = new Type[1];
            classes[0] = typeof(TransformInfoInterface);
            @params[0] = ((object) transformInfoInterface);
            TransformInterface anyType = ((TransformInterface) AbeFactory.getInstance().getInstance(abeClientInformation, transformInfoInterface.getObjectFile(), classes, @params));
            if (anyType == null) {
                if (transformInfoInterface != null) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("\nNo Such View Name: ");
                    stringBuffer.append(transformInfoInterface.getName());
                    stringBuffer.append("\nNo Such View Object: ");
                    stringBuffer.append(transformInfoInterface.getObjectFile());
                    throw new Exception(stringBuffer.ToString());
                } else {
                    throw new Exception("No Such View Object since transformInfo is null");
                }
            }
            return anyType;
        } catch (LicensingException e) {
            string error = "Failed To Get Instance: ";
            if (transformInfoInterface != null) {
                error = error + transformInfoInterface.getName();
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(error, this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        } catch (Exception e) {
            string error = "Failed To Get Instance: ";
            if (transformInfoInterface != null) {
                error = error + transformInfoInterface.getName();
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(error, this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

