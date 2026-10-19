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
//using TagSupport = javax.servlet.jsp.tagext.TagSupport;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace workflows.template.data;

public class Properties
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private HashMap propertiesHashMap;
    public Properties()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF("Start/Tag", this, this.commonStrings.CONSTRUCTOR);
        }
        this.propertiesHashMap = StdUtil.getInstance().createHashMap();
    }

    protected virtual HashMap getPropertiesHashMap()
    {
        return this.propertiesHashMap;
    }

    public virtual int doEndTag()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF("Tag Ended", this, "doEndTag");
        }
        this.propertiesHashMap = StdUtil.getInstance().createHashMap();
        return TagSupport.EVAL_PAGE;
    }

}

