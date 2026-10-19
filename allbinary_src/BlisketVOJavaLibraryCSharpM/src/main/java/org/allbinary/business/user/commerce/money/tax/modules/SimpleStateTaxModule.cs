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
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using StreetAddressData = org.allbinary.business.user.address.StreetAddressData;
using TaxData = org.allbinary.business.user.commerce.money.tax.components.TaxData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoObjectConfigData = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigData;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.business.user.commerce.money.tax.modules;

public class SimpleStateTaxModule : TaxModuleInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private StreetAddress streetAddress = null;
    private StoreFrontInterface storeFrontInterface = null;
    private readonly string ALL = CommonPhoneStrings.getInstance().STAR;
    private readonly string STATETAXPATH = "/generic/taxes/";
    private readonly string STATETAXFILE = "stateTaxation.xml";
    private Document document = null;
    public SimpleStateTaxModule()
    {
    }

    // throws Exception
    public virtual float? getTaxRate(StreetAddress streetAddress, StoreFrontInterface storeFrontInterface)
    {
        this.streetAddress = streetAddress;
        this.storeFrontInterface = storeFrontInterface;
        AbPath fileAbPath = new AbPath(URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH + this.storeFrontInterface.getName() + this.STATETAXPATH, this.STATETAXFILE);
        string data = new CryptFileReader(TransformInfoObjectConfigData.getInstance().UNCRYPTED_EXTENSION, TransformInfoObjectConfigData.getInstance().ENCRYPTED_EXTENSION).get(fileAbPath);
        this.document = DomDocumentHelper.create(data);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAX)) {
            this.logUtil.putF("Tax Doc: " + XmlDocumentHelper.toString(this.document), this, "getTaxRate");
        }
        string state = this.streetAddress.getState();
        string country = this.streetAddress.getCountry();
        state = state.ToUpper();
        NodeList nodeList = this.document.getElementsByTagName(TaxData.NAME);
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node node = nodeList.item(index);
            NodeList taxNodeChildren = node.getChildNodes();
            Node streetAddressNode = DomSearchHelper.getNode(StreetAddressData.NAME, taxNodeChildren);
            StreetAddress taxableStreetAddress = new StreetAddress(streetAddressNode);
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (!stringValidationUtil.isEmpty(country) && !stringValidationUtil.isEmpty(taxableStreetAddress.getCountry()) && string.CompareOrdinal(country, taxableStreetAddress.getCountry()) == 0) {
                if (state != null && taxableStreetAddress.getState() != null && string.CompareOrdinal(state, taxableStreetAddress.getState()) == 0) {
                    Node rateNode = DomSearchHelper.getNode(TaxData.RATE, taxNodeChildren);
                    string taxRate = DomNodeHelper.getTextNodeValue(rateNode);
                    float? taxRateFloat = ((float) taxRate) * .01;
                    return taxRateFloat;
                }
            }
        }
        return 0;
    }

    public virtual bool? isValid(StreetAddress streetAddress, StoreFrontInterface storeFrontInterface)
    {
        try {
            this.streetAddress = streetAddress;
            this.storeFrontInterface = storeFrontInterface;
            AbPath fileAbPath = new AbPath(URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH + this.storeFrontInterface.getName() + this.STATETAXPATH, this.STATETAXFILE);
            string data = new CryptFileReader(TransformInfoObjectConfigData.getInstance().UNCRYPTED_EXTENSION, TransformInfoObjectConfigData.getInstance().ENCRYPTED_EXTENSION).get(fileAbPath);
            this.document = DomDocumentHelper.create(data);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAX)) {
                this.logUtil.putF("Tax Doc: " + XmlDocumentHelper.toString(this.document), this, this.commonStrings.IS_VALID);
            }
            string country = this.streetAddress.getCountry();
            Node rootNode = this.document.getElementsByTagName(TransformInfoObjectConfigData.getInstance().NAME).item(0);
            NodeList nodeList = this.document.getElementsByTagName(TaxData.NAME);
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node node = nodeList.item(index);
                NodeList taxNodeChildren = node.getChildNodes();
                Node streetAddressNode = DomSearchHelper.getNode(StreetAddressData.NAME, taxNodeChildren);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAX)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("StreetAddress Node: ");
                    stringBuffer.append(streetAddressNode.getNodeName());
                    stringBuffer.append(" Value: ");
                    stringBuffer.append(streetAddressNode.getNodeValue());
                    stringBuffer.append(" Number Of Children: ");
                    stringBuffer.appendint(((int) streetAddressNode.getChildNodes().getLength()));
                    this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
                }
                StreetAddress taxableStreetAddress = new StreetAddress(streetAddressNode);
                StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
                if (!stringValidationUtil.isEmpty(country) && !stringValidationUtil.isEmpty(taxableStreetAddress.getCountry()) && taxableStreetAddress.getCountry().compareTo(this.ALL) == 0) {
                    return true;
                }
                if (!stringValidationUtil.isEmpty(country) && !stringValidationUtil.isEmpty(taxableStreetAddress.getCountry()) && string.CompareOrdinal(country, taxableStreetAddress.getCountry()) == 0) {
                    string state = this.streetAddress.getState();
                    if (state != null) {
                        return true;
                    }
                }
            }
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

}

