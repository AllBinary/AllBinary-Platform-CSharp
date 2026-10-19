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
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.address.billing;

public class UpdateValidationView : BillingAddressView, ValidationComponentInterface
{
    public UpdateValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual bool? isValid()
    {
        this.streetAddress = new StreetAddress(this.getRequest());
        if (this.streetAddress.isValid() == false) {
            return false;
        }
        return this.streetAddress.isValid();
    }

    public virtual string validationInfo()
    {
        return this.streetAddress.validationInfo();
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

}

