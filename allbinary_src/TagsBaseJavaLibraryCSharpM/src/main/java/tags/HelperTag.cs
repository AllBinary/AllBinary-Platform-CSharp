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
using TagHelperFactoryInterface = admin.taghelpers.TagHelperFactoryInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace tags;

public class HelperTag : PropertiesTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly TagHelperFactoryInterface tagHelperFactoryInterface;
    private object anyType = null;
    public HelperTag(TagHelperFactoryInterface tagHelperFactoryInterface)
    {
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
        this.tagHelperFactoryInterface = tagHelperFactoryInterface;
    }

    // throws Exception
    public virtual void setHelper()
    {
        if (this.anyType == null) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF("Creating TagHelper with: \n" + this.getPropertiesHashMap().ToString(), this, "doStartTag");
            }
            this.anyType = this.tagHelperFactoryInterface.getInstance(this.getPropertiesHashMap(), this.pageContext);
        }
    }

    public virtual object getHelper()
    {
        return this.anyType;
    }

    public override int doEndTag()
    {
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF("Tag Ended", this, "doEndTag");
        }
        this.anyType = null;
        return base.doEndTag();
    }

}

