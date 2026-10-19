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
using StoreValidationTransformTag = tags.StoreValidationTransformTag;

namespace tags.generic.order;

public class OrderTag : StoreValidationTransformTag
{
    public OrderTag()
    {
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            this.setName("Basic Order View");
            this.setObjectFile("views.generic.order.ValidationView");
            if (this.getCommand() != null) {
                if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.VIEW) == 0) {
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

