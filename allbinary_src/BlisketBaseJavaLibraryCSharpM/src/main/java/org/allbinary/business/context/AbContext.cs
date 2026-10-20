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
using WeblisketSessionInterface = org.allbinary.logic.communication.http.request.session.WeblisketSessionInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.context;

public class AbContext
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private HashMap<object, object> propertiesHashMap;
    private PageContext pageContext;
    public AbContext(HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + propertiesHashMap.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.propertiesHashMap = propertiesHashMap;
        this.pageContext = pageContext;
    }

    public virtual WeblisketSessionInterface getWeblisketSession()
    {
        return new WeblisketSession(this.propertiesHashMap, pageContext);
    }

    public virtual PageContext getPageContext()
    {
        return this.pageContext;
    }

    public virtual HashMap<object, object> getPropertiesHashMap()
    {
        return this.propertiesHashMap;
    }

}

