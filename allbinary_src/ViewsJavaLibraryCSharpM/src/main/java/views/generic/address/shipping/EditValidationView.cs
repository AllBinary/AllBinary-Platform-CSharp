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
using StreetAddressData = org.allbinary.business.user.address.StreetAddressData;
using ShippingAddressesEntity = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntity;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.address.shipping;

public class EditValidationView : ShippingAddressView, ValidationComponentInterface
{
    private string value;
    public EditValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) this.getTransformInfoInterface());
        this.value = httpTransformInfoInterface.getPageContext().getRequest().getParameter(StreetAddressData.ID);
    }

    public virtual bool? isValid()
    {
        if (this.getWeblisketSession().getUserName() != null) {
            return false;
        }
        ShippingAddressesEntity billingAddressesEntity = new ShippingAddressesEntity(this.getWeblisketSession().getUserName());
        this.streetAddress = billingAddressesEntity.get(this.value);
        if (this.streetAddress == null) {
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

