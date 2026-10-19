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
//using Set = java.util.Set;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.address;

public class StreetAddress
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string id;
    private string name;
    private string street;
    private string city;
    private string state;
    private string code;
    private string country;
    private bool isDefault = false;
    public StreetAddress()
    {
    }

    public StreetAddress(Node node)
    {
        Node nameNode = DomSearchHelper.getNode(StreetAddressData.NAME, node.getChildNodes());
        this.name = DomNodeHelper.getTextNodeValue(nameNode);
        Node streetNode = DomSearchHelper.getNode(StreetAddressData.STREET, node.getChildNodes());
        this.street = DomNodeHelper.getTextNodeValue(streetNode);
        Node cityNode = DomSearchHelper.getNode(StreetAddressData.CITY, node.getChildNodes());
        this.city = DomNodeHelper.getTextNodeValue(cityNode);
        Node stateNode = DomSearchHelper.getNode(StreetAddressData.STATE, node.getChildNodes());
        this.state = DomNodeHelper.getTextNodeValue(stateNode);
        Node codeNode = DomSearchHelper.getNode(StreetAddressData.CODE, node.getChildNodes());
        this.code = DomNodeHelper.getTextNodeValue(codeNode);
        Node countryNode = DomSearchHelper.getNode(StreetAddressData.COUNTRY, node.getChildNodes());
        this.country = DomNodeHelper.getTextNodeValue(countryNode);
        this.log();
    }

    public StreetAddress(StreetAddress streetAddress)
    {
        this.id = streetAddress.getId();
        this.name = streetAddress.getName();
        this.street = streetAddress.getStreet();
        this.city = streetAddress.getCity();
        this.state = streetAddress.getState();
        this.code = streetAddress.getCode();
        this.country = streetAddress.getCountry();
        this.isDefault = streetAddress.isDefault();
        this.log();
    }

    public StreetAddress(HttpServletRequest request)
    {
        this.setId(request.getParameter(StreetAddressData.ID));
        this.setName(request.getParameter(StreetAddressData.NAME));
        this.setStreet(request.getParameter(StreetAddressData.STREET));
        this.setCity(request.getParameter(StreetAddressData.CITY));
        this.setState(request.getParameter(StreetAddressData.STATE));
        this.setCode(request.getParameter(StreetAddressData.CODE));
        this.setCountry(request.getParameter(StreetAddressData.COUNTRY));
        this.log();
    }

    public StreetAddress(string name, string street, string city, string state, string code, string country)
    {
        this.name = name;
        this.street = street;
        this.city = city;
        this.state = state;
        this.code = code;
        this.country = country;
        this.log();
    }

    public StreetAddress(HashMap address)
    {
        this.id = ((string) address.get(StreetAddressData.ID));
        this.name = ((string) address.get(StreetAddressData.NAME));
        this.street = ((string) address.get(StreetAddressData.STREET));
        this.city = ((string) address.get(StreetAddressData.CITY));
        this.state = ((string) address.get(StreetAddressData.STATE));
        this.code = ((string) address.get(StreetAddressData.CODE));
        this.country = ((string) address.get(StreetAddressData.COUNTRY));
        string def = ((string) address.get(StreetAddressData.DEFAULT));
        if (def != null && string.CompareOrdinal(def, StreetAddressData.DEFAULT) == 0) {
            this.isDefault = true;
        } else {
            this.isDefault = false;
        }
        this.log();
    }

    private void log()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
            this.logUtil.putF("Created Address: \n" + this.toHashMap(), this, "log");
        }
    }

    public virtual void setId(string id)
    {
        this.id = id;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public virtual void setStreet(string value)
    {
        this.street = value;
    }

    public virtual void setCity(string value)
    {
        this.city = value;
    }

    public virtual void setState(string value)
    {
        this.state = value;
    }

    public virtual void setCode(string value)
    {
        this.code = value;
    }

    public virtual void setCountry(string value)
    {
        this.country = value;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getStreet()
    {
        return this.street;
    }

    public virtual string getCity()
    {
        return this.city;
    }

    public virtual string getState()
    {
        return this.state;
    }

    public virtual string getCode()
    {
        return this.code;
    }

    public virtual string getCountry()
    {
        return this.country;
    }

    public virtual string getId()
    {
        return this.id;
    }

    public virtual bool isDefault()
    {
        return this.isDefault;
    }

    public virtual bool? isEmpty()
    {
        string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
        if (this.getName() == null && this.getName().compareTo(EMPTY_STRING) == 0 && this.getStreet() == null && this.getStreet().compareTo(EMPTY_STRING) == 0 && this.getCity() == null && this.getCity().compareTo(EMPTY_STRING) == 0 && this.getState() == null && this.getState().compareTo(EMPTY_STRING) == 0 && this.getCode() == null && this.getCode().compareTo(EMPTY_STRING) == 0 && this.getCountry() == null && this.getCountry().compareTo(EMPTY_STRING) == 0) {
            return true;
        }
        return false;
    }

    public virtual bool? isValid()
    {
        string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
        if (this.getName() == null || this.getName().compareTo(EMPTY_STRING) == 0 || this.getStreet() == null || this.getStreet().compareTo(EMPTY_STRING) == 0 || this.getCity() == null || this.getCity().compareTo(EMPTY_STRING) == 0 || this.getState() == null || this.getState().compareTo(EMPTY_STRING) == 0 || this.getCode() == null || this.getCode().compareTo(EMPTY_STRING) == 0 || this.getCountry() == null || this.getCountry().compareTo(EMPTY_STRING) == 0) {
            return false;
        }
        return true;
    }

    public virtual string validationInfo()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Address Failed To Validate - All fields must contain data.<br></br>");
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isValidRequired(this.getName(), StreetAddressData.MIN, StreetAddressData.MAX)) {
            stringBuffer.append("Please enter a valid name");
            stringBuffer.append("<br></br>");
        }
        if (!stringValidationUtil.isValidRequired(this.getStreet(), StreetAddressData.MIN, StreetAddressData.MAX)) {
            stringBuffer.append("Please enter a valid street");
            stringBuffer.append("<br></br>");
        }
        if (!stringValidationUtil.isValidRequired(this.getCity(), StreetAddressData.MIN, StreetAddressData.MAX)) {
            stringBuffer.append("Please enter a valid city");
            stringBuffer.append("<br></br>");
        }
        if (!stringValidationUtil.isValidRequired(this.getState(), StreetAddressData.MIN, StreetAddressData.MAX)) {
            stringBuffer.append("Please enter a valid state");
            stringBuffer.append("<br></br>");
        }
        if (!stringValidationUtil.isValidRequired(this.getCode(), StreetAddressData.MIN, StreetAddressData.MAX)) {
            stringBuffer.append("Please enter a valid zipcode");
            stringBuffer.append("<br></br>");
        }
        if (!stringValidationUtil.isValidRequired(this.getCountry(), StreetAddressData.MIN, StreetAddressData.MAX)) {
            stringBuffer.append("Please enter a valid country");
            stringBuffer.append("<br></br>");
        }
        return stringBuffer.ToString();
    }

    private Document toValidationInfoDoc()
    {
        return null;
    }

    private Node toValidationInfoNode(Document document)
    {
        try {
            Node node = document.createElement(StreetAddressData.FORM);
            node.appendChild(this.toXmlNode(document));
            return node;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "toValidationInfoNode", e);
            }
            return null;
        }
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(StreetAddressData.ID, this.id);
        hashMap.put(StreetAddressData.NAME, this.name);
        hashMap.put(StreetAddressData.STREET, this.street);
        hashMap.put(StreetAddressData.CITY, this.city);
        hashMap.put(StreetAddressData.STATE, this.state);
        hashMap.put(StreetAddressData.CODE, this.code);
        hashMap.put(StreetAddressData.COUNTRY, this.country);
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        StringUtil stringUtil = StringUtil.getInstance();
        HashMap hashMap = this.toHashMap();
        Set keySet = hashMap.keySet();
        object[] keyArray = keySet.toArray();
        int size = keyArray.Length;
        Node node = document.createElement(StreetAddressData.ADDRESS);
        for (int i = 0; i < size; i++) {
            string name = ((string) keyArray[i]);
            string value = stringUtil.getNonNull(((string) hashMap.get(name)));
            node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
        }
        return node;
    }

}

