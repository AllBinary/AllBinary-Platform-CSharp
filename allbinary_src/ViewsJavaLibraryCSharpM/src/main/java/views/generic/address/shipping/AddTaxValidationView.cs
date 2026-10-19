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
using TaxModuleInterface = org.allbinary.business.user.commerce.money.tax.modules.TaxModuleInterface;
using ShippingAddressesEntity = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntity;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.address.shipping;

public class AddTaxValidationView : ShippingAddressView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public AddTaxValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual bool? isValid()
    {
        try {
            this.streetAddress = new StreetAddress(this.getRequest());
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getTransformInfoInterface().getStoreName());
            TaxModuleInterface taxInterface = TaxFactory.getInstance().getInstance(this.abeClientInformation, storeFrontInterface);
            if (taxInterface == null) {
                return false;
            }
            if (taxInterface.isValid(this.streetAddress, storeFrontInterface) == false) {
                return false;
            }
            ShippingAddressesEntity billingAddressesEntity = new ShippingAddressesEntity(this.getWeblisketSession().getUserName());
            BasicArrayList streetAddressList = billingAddressesEntity.get();
            if (streetAddressList == null) {
                return false;
            }
            int size = streetAddressList.size();
            for (int index = 0; index < size; index++) {
                StreetAddress aStreetAddress = ((StreetAddress) streetAddressList.get(index));
                if (aStreetAddress.getName().compareTo(ShippingAddressData.TAX) == 0) {
                    return false;
                }
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    // throws Exception
    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getTransformInfoInterface().getStoreName());
            TaxModuleInterface taxInterface = TaxFactory.getInstance().getInstance(this.abeClientInformation, storeFrontInterface);
            if (taxInterface == null) {
                stringBuffer.append("Unable to Load Tax Component<br/>");
            } else {
                if (taxInterface.isValid(this.streetAddress, storeFrontInterface) == false) {
                    stringBuffer.append("Unable to validate address with Tax Component<br/>");
                }
            }
            ShippingAddressesEntity billingAddressesEntity = new ShippingAddressesEntity(this.getWeblisketSession().getUserName());
            BasicArrayList streetAddressList = billingAddressesEntity.get();
            int size = streetAddressList.size();
            for (int index = 0; index < size; index++) {
                StreetAddress aStreetAddress = ((StreetAddress) streetAddressList.get(index));
                if (aStreetAddress.getName().compareTo(ShippingAddressData.TAX) == 0) {
                    stringBuffer.append("Not a valid tax location<br/>");
                }
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to create validateInfo", this, "validationInfo()", e);
            }
            return "Error Creating ValidationInfo";
        }
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

