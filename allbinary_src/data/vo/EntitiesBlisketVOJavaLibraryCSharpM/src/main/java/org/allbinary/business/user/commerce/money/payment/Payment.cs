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
using java.util;
//using ServletRequest = javax.servlet.ServletRequest;
using EntryData = org.allbinary.business.entry.EntryData;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using SuperCrypt = org.allbinary.logic.control.crypt.SuperCrypt;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.money.payment;

public class Payment : PaymentInterface, DomNodeInterface
{
    private string name;
    private string expiration;
    private string encryption;
    private string number;
    private string id;
    private string type;
    private string tenderType;
    private string transactionType;
    private string aba;
    private string account;
    private string accountType;
    private string authorizationCode;
    private string checkNumber;
    private string checkType;
    private string driversLicense;
    private string magneticInkCheckReader;
    private bool isDefault = false;
    public Payment(HashMap payment)
    {
        this.name = ((string) payment.get(PaymentData.NAME));
        this.type = ((string) payment.get(PaymentData.TYPE));
        this.expiration = ((string) payment.get(PaymentData.EXPIRATION));
        this.encryption = ((string) payment.get(EntryData.getInstance().ENCRYPTION));
        this.number = ((string) new SuperCrypt(((int) this.encryption)).decrypt(((string) payment.get(PaymentData.NUMBER))));
        this.id = ((string) payment.get(PaymentData.ID));
        string def = ((string) payment.get(EntryData.getInstance().DEFAULT));
        if (def != null && string.CompareOrdinal(def, EntryData.getInstance().DEFAULT) == 0) {
            this.isDefault = true;
        } else {
            this.isDefault = false;
        }
        this.tenderType = ((string) payment.get(PaymentData.TENDERTYPE));
        this.transactionType = ((string) payment.get(PaymentData.TRANSACTIONTYPE));
        this.aba = ((string) payment.get(PaymentData.ABA));
        this.account = ((string) payment.get(PaymentData.ACCOUNT));
        this.accountType = ((string) payment.get(PaymentData.ACCOUNTTYPE));
        this.authorizationCode = ((string) payment.get(PaymentData.AUTHORIZATIONCODE));
        this.checkNumber = ((string) payment.get(PaymentData.CHECKNUMBER));
        this.checkType = ((string) payment.get(PaymentData.CHECKTYPE));
        this.driversLicense = ((string) payment.get(PaymentData.DRIVERSLICENSE));
        this.magneticInkCheckReader = ((string) payment.get(PaymentData.MAGNETICINKCHECKREADER));
    }

    public Payment(ServletRequest request)
    {
        this.name = request.getParameter(PaymentData.NAME);
        this.type = request.getParameter(PaymentData.TYPE);
        this.expiration = request.getParameter(PaymentData.EXPIRATION);
        this.number = request.getParameter(PaymentData.NUMBER);
        this.tenderType = request.getParameter(PaymentData.TENDERTYPE);
        this.transactionType = request.getParameter(PaymentData.TRANSACTIONTYPE);
        this.aba = request.getParameter(PaymentData.ABA);
        this.account = request.getParameter(PaymentData.ACCOUNT);
        this.accountType = request.getParameter(PaymentData.ACCOUNTTYPE);
        this.authorizationCode = request.getParameter(PaymentData.AUTHORIZATIONCODE);
        this.checkNumber = request.getParameter(PaymentData.CHECKNUMBER);
        this.checkType = request.getParameter(PaymentData.CHECKTYPE);
        this.driversLicense = request.getParameter(PaymentData.DRIVERSLICENSE);
        this.magneticInkCheckReader = request.getParameter(PaymentData.MAGNETICINKCHECKREADER);
    }

    public Payment()
    {
    }

    public virtual bool? isValid()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        bool? aFalse = false;
        if (this.name == null || string.CompareOrdinal(this.name, stringUtil.EMPTY_STRING) == 0) {
            return aFalse;
        }
        if (this.type == null || string.CompareOrdinal(this.type, stringUtil.EMPTY_STRING) == 0) {
            return aFalse;
        }
        if (this.expiration == null || string.CompareOrdinal(this.expiration, stringUtil.EMPTY_STRING) == 0) {
            return aFalse;
        }
        if (this.number == null || string.CompareOrdinal(this.number, stringUtil.EMPTY_STRING) == 0) {
            return aFalse;
        }
        if (this.number.Length > org.allbinary.business.user.commerce.money.payment.types.CreditCardType.MAXLEN) {
            return aFalse;
        }
        return true;
    }

    public virtual void setTenderType(string value)
    {
        this.tenderType = value;
    }

    public virtual void setTransactionType(string value)
    {
        this.transactionType = value;
    }

    public virtual void setAuthorizationCode(string value)
    {
        this.authorizationCode = value;
    }

    public virtual void setCheckType(string value)
    {
        this.checkType = value;
    }

    public virtual void setCheckNumber(string value)
    {
        this.checkNumber = value;
    }

    public virtual void setDriversLicense(string value)
    {
        this.driversLicense = value;
    }

    public virtual void setMagneticInkCheckReader(string value)
    {
        this.magneticInkCheckReader = value;
    }

    public virtual void setAba(string value)
    {
        this.aba = value;
    }

    public virtual void setAccountType(string value)
    {
        this.accountType = value;
    }

    public virtual void setName(string value)
    {
        this.name = value;
    }

    public virtual void setType(string value)
    {
        this.type = value;
    }

    public virtual void setExpiration(string value)
    {
        this.expiration = value;
    }

    public virtual void setNumber(string value)
    {
        this.number = value;
    }

    public virtual string getId()
    {
        return this.id;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getType()
    {
        return this.type;
    }

    public virtual string getExpiration()
    {
        return this.expiration;
    }

    public virtual string getEncryption()
    {
        return this.encryption;
    }

    public virtual string getNumber()
    {
        return this.number;
    }

    public virtual string getTenderType()
    {
        return this.tenderType;
    }

    public virtual string getTransactionType()
    {
        return this.transactionType;
    }

    public virtual string getAba()
    {
        return this.aba;
    }

    public virtual string getAccount()
    {
        return this.account;
    }

    public virtual string getAccountType()
    {
        return this.accountType;
    }

    public virtual string getAuthorizationCode()
    {
        return this.authorizationCode;
    }

    public virtual string getCheckNumber()
    {
        return this.checkNumber;
    }

    public virtual string getCheckType()
    {
        return this.checkType;
    }

    public virtual string getDriversLicense()
    {
        return this.driversLicense;
    }

    public virtual string getMagneticInkCheckReader()
    {
        return this.magneticInkCheckReader;
    }

    public virtual string getLastFour()
    {
        if (this.number.Length > PaymentData.MIN && this.number.Length <= PaymentData.MAX) {
            return this.number.Substring(this.number.Length - 4);
        } else {
            return "Invalid #";
        }
    }

    public virtual bool isDefault()
    {
        return this.isDefault;
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(PaymentData.NAME, this.name);
        hashMap.put(PaymentData.TYPE, this.type);
        hashMap.put(PaymentData.EXPIRATION, this.expiration);
        hashMap.put(PaymentData.NUMBER, this.getLastFour());
        hashMap.put(PaymentData.TENDERTYPE, this.tenderType);
        hashMap.put(PaymentData.TRANSACTIONTYPE, this.transactionType);
        hashMap.put(PaymentData.ABA, this.aba);
        hashMap.put(PaymentData.ACCOUNT, this.account);
        hashMap.put(PaymentData.ACCOUNTTYPE, this.accountType);
        hashMap.put(PaymentData.AUTHORIZATIONCODE, this.authorizationCode);
        hashMap.put(PaymentData.CHECKNUMBER, this.checkNumber);
        hashMap.put(PaymentData.DRIVERSLICENSE, this.driversLicense);
        hashMap.put(PaymentData.MAGNETICINKCHECKREADER, this.magneticInkCheckReader);
        if (this.isDefault) {
            hashMap.put(EntryData.getInstance().DEFAULT, EntryData.getInstance().DEFAULT);
        } else {
            hashMap.put(EntryData.getInstance().DEFAULT, StringUtil.getInstance().EMPTY_STRING);
        }
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap hashMap = this.toHashMap();
        Node node = ModDomHelper.createNameValueNodes(document, PaymentData.PAYMENT, hashMap);
        return node;
    }

    public virtual Document toXmlDoc()
    {
        return null;
    }

    public virtual string view()
    {
        return null;
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    public virtual string validationInfo()
    {
        return null;
    }

}

