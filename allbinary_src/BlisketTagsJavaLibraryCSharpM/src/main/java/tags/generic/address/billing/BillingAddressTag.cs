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
using BillingAddressData = org.allbinary.business.user.address.BillingAddressData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using StoreValidationTransformTag = tags.StoreValidationTransformTag;

namespace tags.generic.address.billing;

public class BillingAddressTag : StoreValidationTransformTag
{
    public BillingAddressTag()
    {
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.getCommand() != null) {
                if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.VIEW) == 0) {
                    this.setName("Basic Billing Address View");
                    this.setObjectFile("views.generic.address.billing.ValidationView");
                } else if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.EDIT) == 0) {
                    this.setName("Basic Billing Address View");
                    this.setObjectFile("views.generic.address.billing.EditValidationView");
                } else if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.NEW) == 0) {
                    this.setName("Basic Billing Address View");
                    this.setObjectFile("views.generic.address.billing.NewValidationView");
                } else if (this.getCommand().compareTo(this.commonStrings.INSERT) == 0) {
                    this.setName("Basic Billing Address View");
                    this.setObjectFile("views.generic.address.billing.AddValidationView");
                } else if (this.getCommand().compareTo(this.commonStrings.DELETE) == 0) {
                    this.setName("Basic Billing Address View");
                    this.setObjectFile("views.generic.address.billing.DeleteValidationView");
                } else if (this.getCommand().compareTo(BillingAddressData.SELECT) == 0) {
                    this.setName("Basic Billing Address View");
                    this.setObjectFile("views.generic.address.billing.SelectValidationView");
                } else if (this.getCommand().compareTo(BillingAddressData.SETTOSHIPPINGADDRESS) == 0) {
                    this.setName("Basic Billing Address View");
                    this.setObjectFile("views.generic.address.billing.SetValidationView");
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

