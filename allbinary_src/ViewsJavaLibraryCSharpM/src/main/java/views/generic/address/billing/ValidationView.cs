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
using BillingAddressesEntity = org.allbinary.data.tables.user.address.billing.BillingAddressesEntity;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.address.billing;

public class ValidationView : BillingAddressesView, ValidationComponentInterface
{
    public ValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        BillingAddressesEntity billingAddressesEntity = new BillingAddressesEntity(this.getWeblisketSession().getUserName());
        this.streetAddresses = billingAddressesEntity.get();
        if (this.streetAddresses == null) {
            return false;
        }
        if (this.streetAddresses.size() < 1) {
            return false;
        }
        return true;
    }

    public virtual string validationInfo()
    {
        return "No Billing Addresses to display.<br />";
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

