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
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectFactory = org.allbinary.logic.visual.transform.info.TransformInfoObjectFactory;

namespace org.allbinary.logic.visual.transform.template;

public class TransformTemplateFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformTemplateFactory instance = new TransformTemplateFactory();
    public static TransformTemplateFactory getInstance()
    {
        return TransformTemplateFactory.instance;
    }

    private TransformTemplateFactory()
    {
    }

    // throws Exception
    public virtual TransformTemplateInterface getInstance(AbeClientInformationInterface abeClientInformation, string templateName, HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        try {
            TransformInfoEntity transformInfoEntity = TransformInfoEntityBuilder.getInstance();
            TransformInfoInterface transformInfoInterface = transformInfoEntity.get(templateName, propertiesHashMap, pageContext);
            return ((TransformTemplateInterface) TransformInfoObjectFactory.getInstance().getInstance(abeClientInformation, transformInfoInterface));
        } catch (Exception e) {
            string error = "Failed To Get Instance";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                this.logUtil.put(error + templateName + "->TemplateFactory", this, "getInstance(viewName, HashMap, PageContext)", e);
            }
            throw e;
        }
    }

}

