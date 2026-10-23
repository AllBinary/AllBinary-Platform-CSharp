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
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using TaxFactory = org.allbinary.business.user.commerce.money.tax.TaxFactory;
using ShippingAddressesEntity = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntity;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.address.shipping;

public class UpdateTaxValidationView : ShippingAddressView, ValidationComponentInterface
{
    public UpdateTaxValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual bool? isValid()
    {
        this.streetAddress = new StreetAddress(this.getRequest());
        StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getTransformInfoInterface().getStoreName());
        if (TaxFactory.getInstance().getInstance(this.abeClientInformation, storeFrontInterface).isValid(this.streetAddress, storeFrontInterface) == false) {
            return false;
        }
        ShippingAddressesEntity billingAddressesEntity = new ShippingAddressesEntity(this.getWeblisketSession().getUserName());
        BasicArrayList streetAddressList = billingAddressesEntity.get();
        if (streetAddressList == null) {
            return false;
        }
        int count = 0;
        int size = streetAddressList.size();
        for (int index = 0; index < size; index++) {
            StreetAddress aStreetAddress = ((StreetAddress) streetAddressList.get(index));
            if (string.CompareOrdinal(aStreetAddress.getName(), ShippingAddressData.TAX) == 0) {
                count++;
            }
        }
        if (count != 1) {
            return false;
        }
        return true;
    }

    public virtual string validationInfo()
    {
        return "Unable to update tax location.";
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

