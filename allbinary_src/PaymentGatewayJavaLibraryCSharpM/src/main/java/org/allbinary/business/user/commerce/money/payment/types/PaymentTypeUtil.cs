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
using EntryData = org.allbinary.business.entry.EntryData;
using PaymentGatewaysData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewaysData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoObjectConfigData = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigData;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.business.user.commerce.money.payment.types;

public class PaymentTypeUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly PaymentTypeUtil instance = new PaymentTypeUtil();
    static PaymentTypeUtil()
    {
    }
    public static PaymentTypeUtil getInstance()
    {
        return PaymentTypeUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string PAYMENTGATEWAYFILEPATHSTRING;
    private readonly string SHIPPINGMETHODSFILENAME = "paymentGatewayTypes.xml";
    private string defaultName = null;
    private BasicArrayList paymentTypeVector = new BasicArrayListD();
    private PaymentTypeUtil()
    {
        StringMaker stringBuffer = new StringMaker();
        string sep = AbPathData.getInstance().SEPARATOR;
        stringBuffer.append(sep);
        stringBuffer.append("generic");
        stringBuffer.append(sep);
        stringBuffer.append("user");
        stringBuffer.append(sep);
        stringBuffer.append("commerce");
        stringBuffer.append(sep);
        stringBuffer.append("money");
        stringBuffer.append(sep);
        stringBuffer.append("payment");
        stringBuffer.append(sep);
        stringBuffer.append("gateway");
        stringBuffer.append(sep);
        this.PAYMENTGATEWAYFILEPATHSTRING = stringBuffer.ToString();
    }

    public virtual void add(PaymentType paymentType)
    {
        this.paymentTypeVector.add(paymentType);
    }

    // throws Exception
    public virtual PaymentType get(string paymentTypeString)
    {
        int size = this.paymentTypeVector.size();
        for (int i = 0; i < size; i++) {
            PaymentType paymentType = ((PaymentType) this.paymentTypeVector.get(i));
            if (paymentType.getBasicPaymentType().getName().compareTo(paymentTypeString) == 0) {
                return paymentType;
            }
        }
        throw new Exception("Unknown PaymentType: " + paymentTypeString);
    }

    // throws Exception
    public virtual void initDefault(string storeName)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENT)) {
            this.logUtil.putF("initDefault Payment: " + this.defaultName, this, "initDefault");
        }
        if (StringValidationUtil.getInstance().isEmpty(this.defaultName)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(URLGLOBALS.getMainPath());
            stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
            stringBuffer.append(storeName);
            stringBuffer.append(AbPathData.getInstance().SEPARATOR);
            stringBuffer.append(this.PAYMENTGATEWAYFILEPATHSTRING);
            AbPath abPath = ((AbPath) new AbPath(stringBuffer.ToString(), this.SHIPPINGMETHODSFILENAME));
            string data = new CryptFileReader(TransformInfoObjectConfigData.getInstance().UNCRYPTED_EXTENSION, TransformInfoObjectConfigData.getInstance().ENCRYPTED_EXTENSION).get(abPath);
            Document document = DomDocumentHelper.create(data);
            NodeList nodeList = document.getElementsByTagName(PaymentGatewaysData.NAME);
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node node = nodeList.item(index);
                Node defaultPaymentGatewayNode = DomSearchHelper.getNode(EntryData.getInstance().DEFAULT, node.getChildNodes());
                string defaultPaymentGatewayNodeValue = DomNodeHelper.getTextNodeValue(defaultPaymentGatewayNode);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENT)) {
                    this.logUtil.putF("DefaultPaymentGatewayNodeValue: " + defaultPaymentGatewayNodeValue, this, "initDefault");
                }
                if (!StringValidationUtil.getInstance().isEmpty(defaultPaymentGatewayNodeValue)) {
                    this.defaultName = defaultPaymentGatewayNodeValue;
                }
            }
        }
    }

    // throws Exception
    public virtual PaymentType getDefault(string storeName)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENT)) {
            this.logUtil.putF(this.commonStrings.START, this, "getDefault");
        }
        this.initDefault(storeName);
        if (!StringValidationUtil.getInstance().isEmpty(this.defaultName)) {
            return this.get(this.defaultName);
        }
        throw new Exception("No Default: " + this.defaultName);
    }

    public virtual bool isContain(PaymentType paymentType)
    {
        return this.paymentTypeVector.contains(paymentType);
    }

    public virtual BasicArrayList difference(BasicArrayList a_PaymentTypeVector)
    {
        BasicArrayList diff = new BasicArrayListD();
        int size = this.paymentTypeVector.size();
        for (int i = 0; i < size; i++) {
            PaymentType paymentType = ((PaymentType) this.paymentTypeVector.get(i));
            if (!a_PaymentTypeVector.contains(paymentType)) {
                diff.add(paymentType);
            }
        }
        return diff;
    }

}

