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
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoHttpComposite
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private TransformInfoHttpInterface transformInfoInterface;
    public TransformInfoHttpComposite(TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.transformInfoInterface = ((TransformInfoHttpInterface) transformInfoInterface);
    }

    // throws Exception
    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return this.transformInfoInterface;
    }

    public virtual WeblisketSession getWeblisketSession()
    {
        return new WeblisketSession(this.getPropertiesHashMap(), this.getPageContext());
    }

    public virtual PageContext getPageContext()
    {
        return this.transformInfoInterface.getPageContext();
    }

    public virtual HashMap<object, object> getPropertiesHashMap()
    {
        return this.transformInfoInterface.getPropertiesHashMap();
    }

}

