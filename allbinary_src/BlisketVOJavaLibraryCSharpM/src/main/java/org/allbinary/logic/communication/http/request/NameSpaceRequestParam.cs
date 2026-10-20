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
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Tokenizer = org.allbinary.logic.@string.tokens.Tokenizer;
using HtmlNameMathData = org.allbinary.logic.visual.dhtml.html.name.HtmlNameMathData;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.communication.http.request;

public class NameSpaceRequestParam
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private BasicArrayList nameSpaceVector;
    private HashMap<object, object> nameSpacePropertiesHashMap;
    private string value;
    public NameSpaceRequestParam(string nameSpace, string value)
    {
        this.nameSpaceVector = new BasicArrayListD();
        this.nameSpacePropertiesHashMap = StdUtil.getInstance().createHashMap();
        this.value = value;
        int beginIndex = nameSpace.IndexOf(NameSpaceRequestParamData.NAME);
        if (beginIndex < 0) {
            throw new Exception("Not a NameSpaceRequest");
        }
        string packages = nameSpace.Substring(beginIndex + NameSpaceRequestParamData.NAME.length() + NameSpaceRequestParamData.SEP.length());
        Tokenizer sepTokenizer = new Tokenizer(NameSpaceRequestParamData.SEP);
        BasicArrayList nameSpaceWithPropertiesVector = sepTokenizer.getTokensFromString(packages, new BasicArrayListD());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("\nSep Tokens: " + nameSpaceWithPropertiesVector.ToString(), this, "NameSpaceRequestParam()");
        }
        Tokenizer nameSpaceAndPropertiesTokenizer = new Tokenizer(NameSpaceRequestParamData.PROPERTIES);
        int packageIndex = 0;
        BasicArrayList list = new BasicArrayListD();
        int index = 0;
        int size = nameSpaceWithPropertiesVector.size();
        while (index < size) {
            string nameSpaceWithProperties = ((string) nameSpaceWithPropertiesVector.get(index++));
            list.clear();
            BasicArrayList nameSpaceAndPropertiesVector = nameSpaceAndPropertiesTokenizer.getTokensFromString(nameSpaceWithProperties, list);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                this.logUtil.putF("\nPackageName and PackageName Properties Tokens: " + nameSpaceAndPropertiesVector.ToString(), this, "NameSpaceRequestParam()");
            }
            if (nameSpaceAndPropertiesVector.size() > 0) {
                string packageName = ((string) nameSpaceAndPropertiesVector.get(0));
                if (packageName == null) {
                    throw new Exception("Package Name Is Null");
                }
                this.nameSpaceVector.add(packageName);
                if (nameSpaceAndPropertiesVector.size() > 1) {
                    string properties = ((string) nameSpaceAndPropertiesVector.get(1));
                    HashMap<object, object> packagePropertiesHashMap = this.generatePackagePropertiesHashMap(properties);
                    this.nameSpacePropertiesHashMap.put((packageIndex).ToString(), packagePropertiesHashMap);
                }
                packageIndex++;
            }
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("NameSpace: " + this.nameSpaceVector.ToString(), this, "NameSpaceRequestParam()");
        }
    }

    public virtual BasicArrayList getPackages()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("NameSpace: " + this.nameSpaceVector.ToString(), this, "getPackages()");
        }
        return this.nameSpaceVector;
    }

    public virtual HashMap<object, object> getPackageProperties(int packageIndex)
    {
        HashMap<object, object> packagePropertiesHashMap = ((HashMap<object, object>) this.nameSpacePropertiesHashMap.get((packageIndex).ToString()));
        if (packagePropertiesHashMap == null) {
            packagePropertiesHashMap = StdUtil.getInstance().createHashMap();
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("Package Properties: " + packagePropertiesHashMap.ToString(), this, "getPackagesProperties()");
        }
        return packagePropertiesHashMap;
    }

    public virtual string getValue()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("\nValue: " + this.value, this, "getValue()");
        }
        return this.value;
    }

    // throws Exception
    private HashMap<object, object> generatePackagePropertiesHashMap(string properties)
    {
        Tokenizer propertiesTokenizer = new Tokenizer(NameSpaceRequestParamData.PROPERTIESSEPARATOR);
        HashMap<object, object> packagePropertiesHashMap = StdUtil.getInstance().createHashMap();
        BasicArrayList propertyVector = propertiesTokenizer.getTokensFromString(properties, new BasicArrayListD());
        BasicArrayList list = new BasicArrayListD();
        Tokenizer propertyTokenizer = new Tokenizer(HtmlNameMathData.getInstance().EQUALS);
        int index = 0;
        int size = propertyVector.size();
        while (index < size) {
            string property = ((string) propertyVector.get(index));
            list.clear();
            BasicArrayList propertyNameValueVector = propertyTokenizer.getTokensFromString(property, list);
            int index2 = 0;
            while (index2 < propertyNameValueVector.size()) {
                string propertyName = ((string) propertyNameValueVector.get(index2++));
                if (propertyNameValueVector.size() > 1) {
                    string propertyValue = ((string) propertyNameValueVector.get(index2++));
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                        this.logUtil.putF("\nProperty Name: " + propertyName + "\nProperty Value: " + propertyValue, this, "generatePackagePropertiesHashMap()");
                    }
                    packagePropertiesHashMap.put(propertyName, propertyValue);
                } else {
                    packagePropertiesHashMap.put(propertyName, StringUtil.getInstance().EMPTY_STRING);
                }
            }
        }
        return packagePropertiesHashMap;
    }

}

