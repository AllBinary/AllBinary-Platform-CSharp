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
using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Encoder = org.allbinary.logic.control.crypt.Encoder;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using OutputTypeData = org.allbinary.logic.io.OutputTypeData;
using AbFilePath = org.allbinary.logic.io.path.AbFilePath;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using TransformInfoDataData = org.allbinary.logic.visual.transform.info.data.TransformInfoDataData;
using TransformInfoObjectConfig = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfig;
using TransformInfoObjectConfigAndManipulatorFactory = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigAndManipulatorFactory;
using TransformInfoObjectConfigInterface = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigInterface;
using TransformInfoTemplateData = org.allbinary.logic.visual.transform.info.template.TransformInfoTemplateData;
using TransformInfoObjectData = org.allbinary.logic.visual.transform.info.viewObject.TransformInfoObjectData;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfo : TransformInfoInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private bool isChild = false;
    private string name = null;
    private string storeName = null;
    private string objectFileName = null;
    private object anyType = null;
    private string objectConfigFileName = null;
    private TransformInfoObjectConfigInterface objectConfigInterface = null;
    private string template = null;
    private string templateFileName = null;
    private string dataFileName = null;
    private string data = StringUtil.getInstance().EMPTY_STRING;
    public TransformInfo()
    {
    }

    public TransformInfo(string name)
    {
        this.setName(name);
    }

    public TransformInfo(string name, string objectFileName, string objectConfigFileName, string templateFileName, string dataFileName)
    {
        this.setName(name);
        this.setObjectFile(objectFileName);
        this.setObjectConfigFile(objectConfigFileName);
        this.setTemplateFile(templateFileName);
        this.setDataFile(dataFileName);
    }

    // throws Exception
    public virtual void @override(HashMap<object, object> hashMap)
    {
        TransformInfoData transformInfoData = TransformInfoData.getInstance();
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        string aName = ((string) hashMap.get(transformInfoData.NAME));
        if (!stringValidationUtil.isEmpty(aName)) {
            this.name = aName;
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("TransformInfo properties overridden for: ");
            stringBuffer.append(this.getName());
            stringBuffer.append("\n properties: ");
            stringBuffer.append(hashMap.ToString());
            this.logUtil.putF(stringBuffer.ToString(), this, "override(HashMap hashMap)");
        }
        string aStoreName = ((string) hashMap.get(StoreFrontData.getInstance().NAME));
        if (!stringValidationUtil.isEmpty(aStoreName)) {
            this.storeName = aStoreName;
        }
        string aObjectFileName = ((string) hashMap.get(transformInfoData.OBJECTFILENAME));
        if (!stringValidationUtil.isEmpty(aObjectFileName)) {
            this.objectFileName = aObjectFileName;
        }
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
        stringBuffer.append(this.storeName);
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        AbPath fileAbPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
        string aObject = ((string) hashMap.get(transformInfoData.OBJECT));
        if (!stringValidationUtil.isEmpty(aObject)) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TransformInfo override view Object for: " + this.getName(), this, "override(HashMap hashMap)");
            }
            string fileDataString = new CryptFileReader(TransformInfoObjectData.getInstance().UNCRYPTED_EXTENSION, TransformInfoObjectData.getInstance().ENCRYPTED_EXTENSION).get(new AbPath(fileAbPath.ToString(), aObject));
            if (fileDataString != null) {
                this.anyType = fileDataString;
            }
        }
        if (!stringValidationUtil.isEmpty(((string) hashMap.get(transformInfoData.OBJECTCONFIG)))) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TransformInfo override ObjectConfig for: " + this.getName(), this, "override(HashMap hashMap)");
            }
            this.setObjectConfig(((string) hashMap.get(transformInfoData.OBJECTCONFIG)));
        }
        string objectConfigFileName = ((string) hashMap.get(transformInfoData.OBJECTCONFIGFILENAME));
        if (!stringValidationUtil.isEmpty(objectConfigFileName)) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TransformInfo override ObjectConfig File for: " + this.getName(), this, "override(HashMap hashMap)");
            }
            this.setObjectConfigFile(objectConfigFileName);
        }
        string type = ((string) hashMap.get(OutputTypeData.getInstance().NAME));
        if (!stringValidationUtil.isEmpty(type)) {
            if (this.getObjectConfigInterface() == null) {
                this.setObjectConfigInterface(new TransformInfoObjectConfig(this));
            }
            this.getObjectConfigInterface().setOutputTypeName(type);
        }
        string aTemplateFileName = ((string) hashMap.get(transformInfoData.TEMPLATEFILENAME));
        if (!stringValidationUtil.isEmpty(aTemplateFileName)) {
            this.templateFileName = aTemplateFileName;
        }
        string aTemplate = ((string) hashMap.get(transformInfoData.TEMPLATE));
        if (!stringValidationUtil.isEmpty(aTemplate)) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TransformInfo override Template for: " + this.getName(), this, "override(HashMap hashMap)");
            }
            string fileDataString = new CryptFileReader(TransformInfoTemplateData.getInstance().UNCRYPTED_EXTENSION, TransformInfoTemplateData.getInstance().ENCRYPTED_EXTENSION).get(new AbPath(fileAbPath.ToString(), aTemplate));
            if (!stringValidationUtil.isEmpty(fileDataString)) {
                this.template = fileDataString;
            }
        }
        string aDataFileName = ((string) hashMap.get(transformInfoData.DATAFILENAME));
        if (!stringValidationUtil.isEmpty(aDataFileName)) {
            this.dataFileName = aDataFileName;
        }
        string aData = ((string) hashMap.get(transformInfoData.DATA));
        if (!stringValidationUtil.isEmpty(aData)) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TransformInfo override Data for: " + this.getName(), this, "override(HashMap hashMap)");
            }
            string fileDataString = new CryptFileReader(TransformInfoDataData.getInstance().UNCRYPTED_EXTENSION, TransformInfoDataData.getInstance().ENCRYPTED_EXTENSION).get(new AbPath(fileAbPath.ToString(), aData));
            if (!stringValidationUtil.isEmpty(fileDataString)) {
                this.data = fileDataString;
            }
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            stringBuffer = new StringMaker();
            stringBuffer.append("Name: ");
            stringBuffer.append(aName);
            stringBuffer.append("\nTemp Object File: ");
            stringBuffer.append(aObject);
            stringBuffer.append("\nTemp Object Config File: ");
            stringBuffer.append(this.getObjectConfigFilePath().ToString());
            stringBuffer.append("\nTemp Template File: ");
            stringBuffer.append(aTemplate);
            stringBuffer.append("\nTemp Data File: ");
            stringBuffer.append(aData);
            stringBuffer.append("\nStore Name: ");
            stringBuffer.append(aStoreName);
            stringBuffer.append("\nObjectFile: ");
            stringBuffer.append(this.getObjectFile());
            stringBuffer.append("->TransformInfo");
            this.logUtil.putF(stringBuffer.ToString(), this, "TransformInfoInterface(HashMap)");
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
            this.logUtil.putF(this.log(), this, "override");
        }
    }

    public virtual string log()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Name: ");
        stringBuffer.append(this.name);
        stringBuffer.append("\nObject File: ");
        stringBuffer.append(this.objectFileName);
        stringBuffer.append("\nObject Config File Path: ");
        stringBuffer.append(this.getObjectConfigFile());
        stringBuffer.append("\nTemplate File: ");
        stringBuffer.append(this.templateFileName);
        stringBuffer.append("\nData File: ");
        stringBuffer.append(this.dataFileName);
        stringBuffer.append("\nStore Name: ");
        stringBuffer.append(this.storeName);
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append(this.getObjectFile());
        stringBuffer.append("->TransformInfo");
        stringBuffer.append("TransformInfoInterface(HashMap)");
        return stringBuffer.ToString();
    }

    public virtual void setName(string value)
    {
        this.name = value;
    }

    public virtual void setStoreName(string value)
    {
        this.storeName = value;
    }

    public virtual string getStoreName()
    {
        return this.storeName;
    }

    public virtual void setObject(object anyType)
    {
        this.anyType = anyType;
    }

    public virtual void setObjectFile(string value)
    {
        this.objectFileName = value;
    }

    public virtual void setTemplate(string value)
    {
        this.template = value;
    }

    public virtual void setTemplateFile(string value)
    {
        this.templateFileName = value;
    }

    // throws Exception
    public virtual void setObjectConfigFileName(string value)
    {
        this.objectConfigFileName = value;
    }

    // throws Exception
    public virtual void setObjectConfigFile(string value)
    {
        this.objectConfigFileName = value;
        this.setObjectConfigInterface(TransformInfoObjectConfigAndManipulatorFactory.getInstance().getInstance(this.abeClientInformation, this, this.getObjectConfigFilePath()));
    }

    // throws Exception
    public virtual void setObjectConfig(string value)
    {
        Document document = DomDocumentHelper.create(value);
        this.setObjectConfigInterface(TransformInfoObjectConfigAndManipulatorFactory.getInstance().getInstance(this.abeClientInformation, this, document));
    }

    public virtual void setDataFile(string value)
    {
        this.dataFileName = value;
    }

    public virtual void setData(string value)
    {
        this.data = value;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual object getObject()
    {
        return this.anyType;
    }

    public virtual string getObjectFile()
    {
        return this.objectFileName;
    }

    public virtual string getTemplate()
    {
        return this.template;
    }

    public virtual string getTemplateFile()
    {
        return this.templateFileName;
    }

    // throws Exception
    public virtual AbPath getTemplateFilePath()
    {
        return new AbFilePath(this.getTemplateFile());
    }

    // throws Exception
    public virtual AbPath getObjectConfigFilePath()
    {
        return new AbFilePath(this.getObjectConfigFile());
    }

    // throws Exception
    public virtual AbPath getDataFilePath()
    {
        return new AbFilePath(this.getDataFile());
    }

    public virtual string getObjectConfigFile()
    {
        return this.objectConfigFileName;
    }

    private string getData()
    {
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        string dataFileString = this.getDataFile();
        if (!stringValidationUtil.isEmpty(dataFileString)) {
            try {
                string fileData = new CryptFileReader(TransformInfoDataData.getInstance().UNCRYPTED_EXTENSION, TransformInfoDataData.getInstance().ENCRYPTED_EXTENSION).get(this.getDataFilePath());
                if (!stringValidationUtil.isEmpty(this.data)) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                        this.logUtil.putF("Data File overriding existing data: " + this.getDataFilePath(), this, "getData()");
                    }
                }
                this.data = fileData;
            } catch (Exception e) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                    this.logUtil.put("Could Not Load Data from: " + this.getDataFile(), this, "getData()", e);
                }
            }
        }
        try {
            if (!stringValidationUtil.isEmpty(this.data)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                    this.logUtil.putF("Data: " + XmlDocumentHelper.toString(DomDocumentHelper.create(data)), this, "getData()");
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("Name: ");
                    stringBuffer.append(this.name);
                    stringBuffer.append("\nEmpty Data For: ");
                    stringBuffer.append(dataFileString);
                    stringBuffer.append("\nPath: ");
                    stringBuffer.append(this.getDataFilePath().toFileSystemString());
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                        this.logUtil.putF(stringBuffer.ToString(), this, "getData()");
                    }
                }
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Could Not Preview Data: " + this.data, this, "getData()", e);
            }
        }
        return this.data;
    }

    // throws Exception
    public virtual Document getDataDocument()
    {
        string localData = this.getData();
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (stringValidationUtil.isEmpty(localData)) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.putF("No Data So Creating New Document", this, "getDataDocument()");
            }
            return DomDocumentHelper.create();
        } else {
            Document document = DomDocumentHelper.create(localData);
            return document;
        }
    }

    public virtual string getDataFile()
    {
        return this.dataFileName;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        TransformInfoData transformInfoData = TransformInfoData.getInstance();
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(transformInfoData.NAME, this.name);
        hashMap.put(StoreFrontData.getInstance().NAME, this.storeName);
        hashMap.put(transformInfoData.OBJECTFILENAME, this.objectFileName);
        hashMap.put(transformInfoData.OBJECT, this.anyType);
        hashMap.put(transformInfoData.OBJECTCONFIGFILENAME, this.getObjectConfigFile());
        hashMap.put(transformInfoData.OBJECTCONFIG, Encoder.encode(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(this.getObjectConfigInterface().ToString()), value => unchecked((sbyte) value))));
        hashMap.put(transformInfoData.TEMPLATEFILENAME, this.templateFileName);
        hashMap.put(transformInfoData.TEMPLATE, this.template);
        hashMap.put(transformInfoData.DATAFILENAME, this.dataFileName);
        hashMap.put(transformInfoData.DATA, Encoder.encode(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(this.data), value => unchecked((sbyte) value))));
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        hashMap.put(EntryData.getInstance().LASTMODIFIED, time);
        return hashMap;
    }

    public virtual BasicArrayList toVector()
    {
        BasicArrayList vector = new BasicArrayListD();
        vector.add(this.name);
        vector.add(this.storeName);
        vector.add(this.objectFileName);
        vector.add(this.anyType);
        vector.add(this.getObjectConfigFile());
        vector.add(Encoder.encode(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(this.getObjectConfigInterface().ToString()), value => unchecked((sbyte) value))));
        vector.add(this.templateFileName);
        vector.add(this.template);
        vector.add(this.dataFileName);
        vector.add(Encoder.encode(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(this.data), value => unchecked((sbyte) value))));
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        vector.add(time);
        vector.add(time);
        return vector;
    }

    public virtual object getKey()
    {
        return ((object) this.getName());
    }

    public virtual void setChild()
    {
        this.isChild = true;
    }

    public virtual bool isChild()
    {
        return this.isChild;
    }

    public virtual TransformInfoObjectConfigInterface getObjectConfigInterface()
    {
        return this.objectConfigInterface;
    }

    public virtual void setObjectConfigInterface(TransformInfoObjectConfigInterface objectConfigInterface)
    {
        this.objectConfigInterface = objectConfigInterface;
    }

}

