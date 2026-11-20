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
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StoreValidationTransformTag = tags.StoreValidationTransformTag;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace tags.admin;

public class DateRangeOrderHistoryTag : StoreValidationTransformTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string status = null;
    public DateRangeOrderHistoryTag() : base()
    {
        // base() is called from the constructor declaration
    }

    public virtual void setStatus(string value)
    {
        this.status = value;
    }

    // throws JspTagException
    public override int doStartTag()
    {
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF("Tag Start", this, tagStrings.DO_START_TAG);
            }
            this.setName("Range Order History View");
            this.setObjectFile("views.admin.orderhistory.DateRangeOrderHistoryView");
            if (this.getCommand() != null) {
                if (this.getCommand().compareTo(GLOBALS2.VIEW) == 0) {
                } else {
                    throw new Exception("No Such View Command: " + this.getCommand());
                }
                return base.doStartTag();
            }
            throw new Exception("Command Null");
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

