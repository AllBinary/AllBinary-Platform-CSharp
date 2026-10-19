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
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using StoreValidationTransformTag = tags.StoreValidationTransformTag;

namespace tags.generic.payment;

public class PaymentTag : StoreValidationTransformTag
{
    public PaymentTag()
    {
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            this.setName("Basic Payment View");
            this.setObjectFile("views.generic.payment.ValidationView");
            if (this.getCommand() != null) {
                if (this.getCommand().compareTo(PaymentData.VIEW) == 0 || this.getCommand().compareTo(PaymentData.CHANGE) == 0 || this.getCommand().compareTo(PaymentData.ADDNEW) == 0) {
                } else if (this.getCommand().compareTo(this.commonStrings.INSERT) == 0) {
                } else if (this.getCommand().compareTo(this.commonStrings.DELETE) == 0) {
                    return this.EVAL_BODY_INCLUDE;
                } else if (this.getCommand().compareTo(PaymentData.SELECT) == 0) {
                    return this.EVAL_BODY_INCLUDE;
                } else {
                    throw new Exception("No Such View Command: " + this.getCommand());
                }
                return base.doStartTag();
            }
            throw new Exception("Command Null");
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

