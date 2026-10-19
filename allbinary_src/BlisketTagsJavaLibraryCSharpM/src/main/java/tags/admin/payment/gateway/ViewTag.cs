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

namespace tags.admin.payment.gateway;

public class ViewTag : StoreValidationTransformTag
{
    public ViewTag()
    {
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.getCommand() != null) {
                if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.VIEW) == 0) {
                    this.setName("Validation Gateway View");
                    this.setObjectFile("views.admin.payment.gateway.GatewayValidationView");
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

