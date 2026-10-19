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

namespace tags;

public class HelperTag : PropertiesTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly TagHelperFactoryInterface tagHelperFactoryInterface;
    private object anyType = null;
    public HelperTag(TagHelperFactoryInterface tagHelperFactoryInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
        this.tagHelperFactoryInterface = tagHelperFactoryInterface;
    }

    // throws Exception
    protected virtual void setHelper()
    {
        if (this.anyType == null) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF("Creating TagHelper with: \n" + this.getPropertiesHashMap().ToString(), this, "doStartTag");
            }
            this.anyType = this.tagHelperFactoryInterface.getInstance(this.getPropertiesHashMap(), this.pageContext);
        }
    }

    public virtual object getHelper()
    {
        return this.anyType;
    }

    public virtual int doEndTag()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF("Tag Ended", this, "doEndTag");
        }
        this.anyType = null;
        return base.doEndTag();
    }

}

