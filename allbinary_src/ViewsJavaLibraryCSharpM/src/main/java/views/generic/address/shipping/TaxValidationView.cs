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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using ShippingAddressesEntity = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntity;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.address.shipping;

public class TaxValidationView : ShippingAddressView, ValidationComponentInterface
{
    public TaxValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        ShippingAddressesEntity billingAddressesEntity = new ShippingAddressesEntity(this.getWeblisketSession().getUserName());
        BasicArrayList streetAddressList = billingAddressesEntity.get();
        if (streetAddressList == null) {
            return false;
        }
        int size = streetAddressList.size();
        for (int index = 0; index < size; index++) {
            StreetAddress aStreetAddress = ((StreetAddress) streetAddressList.get(index));
            if (aStreetAddress.getName().compareTo(ShippingAddressData.TAX) == 0) {
                this.streetAddress = aStreetAddress;
                return true;
            }
        }
        return false;
    }

    public virtual string validationInfo()
    {
        return StringUtil.getInstance().EMPTY_STRING;
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

