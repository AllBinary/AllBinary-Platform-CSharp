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
using TransformInfoEntity = org.allbinary.data.tables.transform.info.TransformInfoEntity;
using TransformInfoEntityBuilder = org.allbinary.data.tables.transform.info.TransformInfoEntityBuilder;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoHttpFactory = org.allbinary.logic.visual.transform.info.TransformInfoHttpFactory;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectFactory = org.allbinary.logic.visual.transform.info.TransformInfoObjectFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform;

public class TransformFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformFactory instance = new TransformFactory();
    public static TransformFactory getInstance()
    {
        return TransformFactory.instance;
    }

    private TransformFactory()
    {
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception
    public virtual TransformInterface getInstance(AbeClientInformationInterface abeClientInformation, string viewName, TransformInfoInterface ownerTransformInfoInterface)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF("Creating Transform: " + viewName, this, this.commonStrings.GET_INSTANCE);
            }
            TransformInfoHttpInterface ownerTransformInfoHttpInterface = ((TransformInfoHttpInterface) ownerTransformInfoInterface);
            TransformInfoEntity transformInfoEntity = TransformInfoEntityBuilder.getInstance();
            TransformInfoInterface transformInfoInterface = transformInfoEntity.get(viewName, ownerTransformInfoHttpInterface.getPropertiesHashMap(), ownerTransformInfoHttpInterface.getPageContext());
            if (transformInfoInterface == null) {
                throw new Exception("No Such View In DB: " + viewName);
            }
            transformInfoInterface.setChild();
            object anyType = TransformInfoObjectFactory.getInstance().getInstance(abeClientInformation, transformInfoInterface);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF("Created Transform: " + viewName, this, this.commonStrings.GET_INSTANCE);
            }
            return ((TransformInterface) anyType);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, this.commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual TransformInterface getInstance(AbeClientInformationInterface abeClientInformation, HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        try {
            TransformInfoData transformInfoData = TransformInfoData.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF("Creating Transform: " + propertiesHashMap.get(transformInfoData.NAME), this, this.commonStrings.GET_INSTANCE);
            }
            TransformInfoEntity transformInfoEntity = TransformInfoEntityBuilder.getInstance();
            TransformInfoInterface transformInfoInterface = transformInfoEntity.get(((string) propertiesHashMap.get(transformInfoData.NAME)), propertiesHashMap, pageContext);
            if (transformInfoInterface != null) {
                transformInfoInterface.@override(propertiesHashMap);
            } else {
                transformInfoInterface = ((TransformInfoInterface) TransformInfoHttpFactory.getInstance(propertiesHashMap, pageContext));
            }
            object anyType = TransformInfoObjectFactory.getInstance().getInstance(abeClientInformation, transformInfoInterface);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF("Created Transform: " + propertiesHashMap.get(transformInfoData.NAME), this, this.commonStrings.GET_INSTANCE);
            }
            return ((TransformInterface) anyType);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Failed To Get Instance: ");
                stringBuffer.append(((string) propertiesHashMap.get(TransformInfoData.getInstance().NAME)));
                stringBuffer.append("->TransformFactory");
                this.logUtil.put(stringBuffer.ToString(), this, this.commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual TransformInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF("Creating Transform: " + transformInfoInterface.getName(), this, "getInstance(TransformInfoInterface)");
            }
            object anyType = TransformInfoObjectFactory.getInstance().getInstance(abeClientInformation, transformInfoInterface);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
                this.logUtil.putF("Created Transform: " + transformInfoInterface.getName(), this, "getInstance(TransformInfoInterface)");
            }
            return ((TransformInterface) anyType);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(TransformInfoInterface)", e);
            }
            throw e;
        }
    }

}

