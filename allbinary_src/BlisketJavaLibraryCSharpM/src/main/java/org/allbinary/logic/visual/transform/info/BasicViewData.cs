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

namespace org.allbinary.logic.visual.transform.info;

public class BasicViewData
{
    private static readonly BasicViewData instance = new BasicViewData();
    public static BasicViewData getInstance()
    {
        return BasicViewData.instance;
    }

    private BasicViewData()
    {
        this.USERDIR = this.GENERICDIR + "user/";
        this.ADDRESSDIR = this.USERDIR + "address/";
        this.BILLINGADDRESSDIR = this.ADDRESSDIR + "billing/";
        this.SHIPPINGADDRESSDIR = this.ADDRESSDIR + "shipping/";
        this.COMMERCEDIR = this.USERDIR + "commerce/";
        this.INVENTORYDIR = this.COMMERCEDIR + "inventory/";
        this.BASKETDIR = this.INVENTORYDIR + "basket/";
        this.ITEMDIR = this.INVENTORYDIR + "item/";
        this.MONEYDIR = this.COMMERCEDIR + "money/";
        this.SHIPPINGDIR = this.COMMERCEDIR + "shipping/";
        this.ORDERDIR = this.INVENTORYDIR + "order/";
        this.ORDEREMAILDIR = this.ORDERDIR + "email/";
        this.ORDERHISTORYDIR = this.ORDERDIR + "history/";
        this.ORDERREVIEWDIR = this.ORDERDIR + "review/";
        this.PAYMENTDIR = this.MONEYDIR + "payment/";
        this.GENERATIONDIR = this.GENERICDIR + "generation/";
        this.PRODUCTSDIR = this.GENERICDIR + "products/";
        this.IGNOREXMLXSL = this.GENERICDIR + "ignoreXmlView.xsl";
        this.REVIEWORDERVIEWXSL = this.ORDERREVIEWDIR + "reviewOrderView.xsl";
        this.ORDERVIEWXSL = this.REVIEWORDERVIEWXSL;
        this.INVENTORYXSL = this.INVENTORYDIR + "inventory.xsl";
        this.BASKETXSL = this.BASKETDIR + "basket.xsl";
        this.CHECKOUTBASKETXSL = this.BASKETDIR + "staticBasket.xsl";
        this.MINIBASKETXSL = this.BASKETDIR + "miniBasket.xsl";
        this.BILLINGADDRESSCHANGEFORMXSL = this.BILLINGADDRESSDIR + "billingAddressChangeForm.xsl";
        this.BILLINGADDRESSINPUTFORMXSL = this.BILLINGADDRESSDIR + "billingAddressInputForm.xsl";
        this.BILLINGADDRESSVIEWXSL = this.BILLINGADDRESSDIR + "billingAddressView.xsl";
        this.SHIPPINGADDRESSCHANGEFORMXSL = this.SHIPPINGADDRESSDIR + "shippingAddressChangeForm.xsl";
        this.SHIPPINGADDRESSINPUTFORMXSL = this.SHIPPINGADDRESSDIR + "shippingAddressInputForm.xsl";
        this.SHIPPINGADDRESSVIEWXSL = this.SHIPPINGADDRESSDIR + "shippingAddressView.xsl";
        this.NEWTAXADDRESSXSL = this.SHIPPINGADDRESSDIR + "newTaxAddressView.xsl";
        this.EDITTAXADDRESSXSL = this.SHIPPINGADDRESSDIR + "editTaxAddressView.xsl";
        this.SHIPPINGMETHODSXSL = this.SHIPPINGDIR + "shippingMethods.xsl";
        this.ORDERCUSTOMEREMAILVIEWXSL = this.ORDEREMAILDIR + "orderCustomerEmailView.xsl";
        this.ORDERMANAGEREMAILVIEWXSL = this.ORDEREMAILDIR + "orderManagerEmailView.xsl";
        this.EDITCUSTOMERXSL = this.USERDIR + "editCustomerInputForm.xsl";
        this.ORDERHISTORYXSL = this.ORDERHISTORYDIR + "orderHistory.xsl";
        this.PAYMENTVIEWXSL = this.PAYMENTDIR + "paymentView.xsl";
        this.SUMMARYXSL = this.ITEMDIR + "summary/summary.xsl";
        this.PAYMENTGATEWAYOPTIONSXSL = this.PAYMENTDIR + "paymentGatewayOptions.xsl";
        this.MAKEPAYMENTVIEWXSL = this.PAYMENTDIR + "invoice/" + "makePayment.xsl";
    }

    public readonly string GENERICDIR = "generic/";
    public readonly string USERDIR;
    public readonly string ADDRESSDIR;
    public readonly string BILLINGADDRESSDIR;
    public readonly string SHIPPINGADDRESSDIR;
    public readonly string COMMERCEDIR;
    public readonly string INVENTORYDIR;
    public readonly string BASKETDIR;
    public readonly string ITEMDIR;
    public readonly string MONEYDIR;
    public readonly string SHIPPINGDIR;
    public readonly string ORDERDIR;
    public readonly string ORDEREMAILDIR;
    public readonly string ORDERHISTORYDIR;
    public readonly string ORDERREVIEWDIR;
    public readonly string PAYMENTDIR;
    public readonly string GENERATIONDIR;
    public readonly string PRODUCTSDIR;
    public readonly string IGNOREXMLXSL;
    public readonly string REVIEWORDERVIEWXSL;
    public readonly string ORDERVIEWXSL;
    public readonly string INVENTORYXSL;
    public readonly string BASKETXSL;
    public readonly string CHECKOUTBASKETXSL;
    public readonly string MINIBASKETXSL;
    public readonly string BILLINGADDRESSCHANGEFORMXSL;
    public readonly string BILLINGADDRESSINPUTFORMXSL;
    public readonly string BILLINGADDRESSVIEWXSL;
    public readonly string SHIPPINGADDRESSCHANGEFORMXSL;
    public readonly string SHIPPINGADDRESSINPUTFORMXSL;
    public readonly string SHIPPINGADDRESSVIEWXSL;
    public readonly string NEWTAXADDRESSXSL;
    public readonly string EDITTAXADDRESSXSL;
    public readonly string SHIPPINGMETHODSXSL;
    public readonly string ORDERCUSTOMEREMAILVIEWXSL;
    public readonly string ORDERMANAGEREMAILVIEWXSL;
    public readonly string EDITCUSTOMERXSL;
    public readonly string ORDERHISTORYXSL;
    public readonly string PAYMENTVIEWXSL;
    public readonly string SUMMARYXSL;
    public readonly string PAYMENTGATEWAYOPTIONSXSL;
    public readonly string MAKEPAYMENTVIEWXSL;
}

