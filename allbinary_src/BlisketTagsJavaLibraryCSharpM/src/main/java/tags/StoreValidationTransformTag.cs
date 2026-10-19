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
//using JspTagException = javax.servlet.jsp.JspTagException;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace tags;

public class StoreValidationTransformTag : ValidationTransformTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string storeName = null;
    public StoreValidationTransformTag() : base()
    {
        // base() is called from the constructor declaration
    }

    public virtual void setStoreName(string value)
    {
        this.storeName = value;
        this.getPropertiesHashMap().put(StoreFrontData.getInstance().NAME, this.storeName);
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF("Tag Start", this, tagStrings.DO_START_TAG);
            }
            return base.doStartTag();
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

