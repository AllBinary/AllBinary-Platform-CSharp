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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using ContextConfiguration = org.allbinary.business.context.configuration.ContextConfiguration;
using ContextConfigurationDomDocumentMapping = org.allbinary.business.context.configuration.ContextConfigurationDomDocumentMapping;
using ContextConfigurationInterface = org.allbinary.business.context.configuration.ContextConfigurationInterface;
using ContextConfigurationInterfaceFactory = org.allbinary.business.context.configuration.ContextConfigurationInterfaceFactory;
using EntryData = org.allbinary.business.entry.EntryData;
using UserData = org.allbinary.business.user.UserData;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using AbPathUtil = org.allbinary.logic.io.path.AbPathUtil;
using SpecialCharacterUtil = org.allbinary.logic.@string.SpecialCharacterUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using Tokenizer = org.allbinary.logic.@string.tokens.Tokenizer;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StringEscapeUtils = org.apache.commons.lang3.StringEscapeUtils;
using Document = org.w3c.dom.Document;

namespace org.allbinary.business.context.modules.storefront;

public class StoreFront : StoreFrontInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly Directory directory = Directory.getInstance();
    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private readonly AbPathUtil abPathUtil = AbPathUtil.getInstance();
    private string name;
    private string basketName;
    private string homeHostName;
    private AbPath homeHostNamePath;
    private string hostName;
    private AbPath hostNamePath;
    private string testHomeHostName;
    private AbPath testHomeHostNamePath;
    private string testHostName;
    private AbPath testHostNamePath;
    private AbPath imagePath;
    private AbPath staticPath;
    private AbPath categoryPath;
    private string inventoryControl;
    private ContextConfigurationInterface contextConfigurationInterface;
    private string subStores;
    private string tagLocation;
    private string packageLocation;
    private string ftp;
    private AbPath ftpPath;
    private string ftpUserName;
    private string ftpPassword;
    private string testFtp;
    private AbPath testFtpPath;
    private string testFtpUserName;
    private string testFtpPassword;
    private string timeCreated;
    private string lastModified;
    private readonly int MINCHAR = 0;
    private readonly int MINSTORENAMELENGTH = 1;
    private readonly int MAXCHAR = 255;
    private static readonly string RESOURCES = " Resources" + AbPathData.getInstance().SEPARATOR;
    private readonly string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
    private readonly string[] ONE_EMPTY_STRING_ARRAY = StringUtil.getInstance().ONE_EMPTY_STRING_ARRAY;
    public StoreFront()
    {
        this.name = this.stringUtil.EMPTY_STRING;
        this.basketName = this.stringUtil.EMPTY_STRING;
        this.homeHostName = this.stringUtil.EMPTY_STRING;
        this.homeHostNamePath = this.abPathUtil.NO_ABPATH;
        this.hostName = this.stringUtil.EMPTY_STRING;
        this.hostNamePath = this.abPathUtil.NO_ABPATH;
        this.testHomeHostName = this.stringUtil.EMPTY_STRING;
        this.testHomeHostNamePath = this.abPathUtil.NO_ABPATH;
        this.testHostName = this.stringUtil.EMPTY_STRING;
        this.testHostNamePath = this.abPathUtil.NO_ABPATH;
        this.imagePath = this.abPathUtil.NO_ABPATH;
        this.staticPath = this.abPathUtil.NO_ABPATH;
        this.categoryPath = this.abPathUtil.NO_ABPATH;
        this.inventoryControl = this.stringUtil.EMPTY_STRING;
        this.subStores = this.stringUtil.EMPTY_STRING;
        this.tagLocation = this.stringUtil.EMPTY_STRING;
        this.packageLocation = this.stringUtil.EMPTY_STRING;
        this.ftp = this.stringUtil.EMPTY_STRING;
        this.ftpPath = this.abPathUtil.NO_ABPATH;
        this.ftpUserName = this.stringUtil.EMPTY_STRING;
        this.ftpPassword = this.stringUtil.EMPTY_STRING;
        this.testFtp = this.stringUtil.EMPTY_STRING;
        this.testFtpPath = this.abPathUtil.NO_ABPATH;
        this.testFtpUserName = this.stringUtil.EMPTY_STRING;
        this.testFtpPassword = this.stringUtil.EMPTY_STRING;
        this.timeCreated = this.stringUtil.EMPTY_STRING;
        this.lastModified = this.stringUtil.EMPTY_STRING;
        this.contextConfigurationInterface = new ContextConfiguration();
    }

    public StoreFront(HttpServletRequest request)
    {
        this.name = this.stringUtil.EMPTY_STRING;
        this.basketName = this.stringUtil.EMPTY_STRING;
        this.homeHostName = this.stringUtil.EMPTY_STRING;
        this.homeHostNamePath = this.abPathUtil.NO_ABPATH;
        this.hostName = this.stringUtil.EMPTY_STRING;
        this.hostNamePath = this.abPathUtil.NO_ABPATH;
        this.testHomeHostName = this.stringUtil.EMPTY_STRING;
        this.testHomeHostNamePath = this.abPathUtil.NO_ABPATH;
        this.testHostName = this.stringUtil.EMPTY_STRING;
        this.testHostNamePath = this.abPathUtil.NO_ABPATH;
        this.imagePath = this.abPathUtil.NO_ABPATH;
        this.staticPath = this.abPathUtil.NO_ABPATH;
        this.categoryPath = this.abPathUtil.NO_ABPATH;
        this.inventoryControl = this.stringUtil.EMPTY_STRING;
        this.subStores = this.stringUtil.EMPTY_STRING;
        this.tagLocation = this.stringUtil.EMPTY_STRING;
        this.packageLocation = this.stringUtil.EMPTY_STRING;
        this.ftp = this.stringUtil.EMPTY_STRING;
        this.ftpPath = this.abPathUtil.NO_ABPATH;
        this.ftpUserName = this.stringUtil.EMPTY_STRING;
        this.ftpPassword = this.stringUtil.EMPTY_STRING;
        this.testFtp = this.stringUtil.EMPTY_STRING;
        this.testFtpPath = this.abPathUtil.NO_ABPATH;
        this.testFtpUserName = this.stringUtil.EMPTY_STRING;
        this.testFtpPassword = this.stringUtil.EMPTY_STRING;
        this.timeCreated = this.stringUtil.EMPTY_STRING;
        this.lastModified = this.stringUtil.EMPTY_STRING;
        this.getFormData(new RequestParams(request).toHashMap());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF("TWB- needs update for adding and updating context configuration - currently defaults to admin context config", this, "StoreFront");
        }
        this.setContextConfigurationInterface(ContextConfigurationInterfaceFactory.getInstance().getInstance("Admin"));
    }

    public StoreFront(HashMap hashMap)
    {
        this.name = this.stringUtil.EMPTY_STRING;
        this.basketName = this.stringUtil.EMPTY_STRING;
        this.homeHostName = this.stringUtil.EMPTY_STRING;
        this.homeHostNamePath = this.abPathUtil.NO_ABPATH;
        this.hostName = this.stringUtil.EMPTY_STRING;
        this.hostNamePath = this.abPathUtil.NO_ABPATH;
        this.testHomeHostName = this.stringUtil.EMPTY_STRING;
        this.testHomeHostNamePath = this.abPathUtil.NO_ABPATH;
        this.testHostName = this.stringUtil.EMPTY_STRING;
        this.testHostNamePath = this.abPathUtil.NO_ABPATH;
        this.imagePath = this.abPathUtil.NO_ABPATH;
        this.staticPath = this.abPathUtil.NO_ABPATH;
        this.categoryPath = this.abPathUtil.NO_ABPATH;
        this.inventoryControl = this.stringUtil.EMPTY_STRING;
        this.subStores = this.stringUtil.EMPTY_STRING;
        this.tagLocation = this.stringUtil.EMPTY_STRING;
        this.packageLocation = this.stringUtil.EMPTY_STRING;
        this.ftp = this.stringUtil.EMPTY_STRING;
        this.ftpPath = this.abPathUtil.NO_ABPATH;
        this.ftpUserName = this.stringUtil.EMPTY_STRING;
        this.ftpPassword = this.stringUtil.EMPTY_STRING;
        this.testFtp = this.stringUtil.EMPTY_STRING;
        this.testFtpPath = this.abPathUtil.NO_ABPATH;
        this.testFtpUserName = this.stringUtil.EMPTY_STRING;
        this.testFtpPassword = this.stringUtil.EMPTY_STRING;
        this.timeCreated = this.stringUtil.EMPTY_STRING;
        this.lastModified = this.stringUtil.EMPTY_STRING;
        this.getFormData(hashMap);
        string domDocumentString = ((string) hashMap.get(StoreFrontData.getInstance().CONFIGURATION));
        if (domDocumentString == null) {
            Document document = DomDocumentHelper.create(domDocumentString);
            this.setContextConfigurationInterface(ContextConfigurationInterfaceFactory.getInstance().getInstance(document));
        }
    }

    private bool isColumn(string columnName)
    {
        if (string.CompareOrdinal(columnName, StoreFrontData.getInstance().NAME) == 0 || string.CompareOrdinal(columnName, UserData.MAINEMAIL) == 0) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    private AbPath createPath(string key, HashMap hashMap)
    {
        return new AbPath(this.create(this.EMPTY_STRING, key, hashMap), StringUtil.getInstance().EMPTY_STRING);
    }

    // throws Exception
    private AbPath createPath(string append, string key, HashMap hashMap)
    {
        return new AbPath(this.create(append, key, hashMap), StringUtil.getInstance().EMPTY_STRING);
    }

    private string get(string key, HashMap hashMap)
    {
        return this.create(this.EMPTY_STRING, key, hashMap);
    }

    private string create(string append, string key, HashMap hashMap)
    {
        string path = ((string) hashMap.get(key));
        if (StringValidationUtil.getInstance().isEmpty(path)) {
            return this.EMPTY_STRING;
        } else {
            if (this.isColumn(path)) {
                return ((string) hashMap.get(path)) + append;
            } else {
                return path;
            }
        }
    }

    // throws Exception
    private void getFormData(HashMap storeHashMap)
    {
        StoreFrontData storeFrontData = StoreFrontData.getInstance();
        this.name = ((string) storeHashMap.get(storeFrontData.NAME));
        this.basketName = ((string) storeHashMap.get(storeFrontData.NAME));
        this.homeHostName = ((string) storeHashMap.get(storeFrontData.HOMEHOSTNAME));
        this.homeHostNamePath = this.createPath(storeFrontData.HOMEHOSTNAMEPATH, storeHashMap);
        this.hostName = ((string) storeHashMap.get(storeFrontData.HOSTNAME));
        this.hostNamePath = this.createPath(storeFrontData.HOSTNAMEPATH, storeHashMap);
        this.testHomeHostName = ((string) storeHashMap.get(storeFrontData.TESTHOMEHOSTNAME));
        this.testHomeHostNamePath = this.createPath(storeFrontData.TESTHOMEHOSTNAMEPATH, storeHashMap);
        this.testHostName = ((string) storeHashMap.get(storeFrontData.TESTHOSTNAME));
        this.testHostNamePath = this.createPath(storeFrontData.TESTHOSTNAMEPATH, storeHashMap);
        this.imagePath = this.createPath(StoreFront.RESOURCES, storeFrontData.IMAGEPATH, storeHashMap);
        this.staticPath = this.createPath(" Products" + AbPathData.getInstance().SEPARATOR, storeFrontData.STATICPATH, storeHashMap);
        this.categoryPath = this.createPath(StoreFront.RESOURCES, storeFrontData.CATEGORYPATH, storeHashMap);
        this.inventoryControl = ((string) storeHashMap.get(storeFrontData.INVENTORYCONTROL));
        this.subStores = ((string) storeHashMap.get(storeFrontData.SUBSTORES));
        this.tagLocation = ((string) storeHashMap.get(storeFrontData.TAGLOCATION));
        this.packageLocation = ((string) storeHashMap.get(storeFrontData.PACKAGELOCATION));
        this.ftp = ((string) storeHashMap.get(storeFrontData.FTP));
        this.ftpPath = this.createPath(storeFrontData.FTPPATH, storeHashMap);
        this.ftpUserName = ((string) storeHashMap.get(storeFrontData.FTPUSERNAME));
        this.ftpPassword = ((string) storeHashMap.get(storeFrontData.FTPPASSWORD));
        this.testFtp = ((string) storeHashMap.get(storeFrontData.TESTFTP));
        this.testFtpPath = this.createPath(storeFrontData.TESTFTPPATH, storeHashMap);
        this.testFtpUserName = ((string) storeHashMap.get(storeFrontData.TESTFTPUSERNAME));
        this.testFtpPassword = ((string) storeHashMap.get(storeFrontData.TESTFTPPASSWORD));
        this.timeCreated = ((string) storeHashMap.get(EntryData.getInstance().TIMECREATED));
        this.lastModified = ((string) storeHashMap.get(EntryData.getInstance().LASTMODIFIED));
    }

    public virtual bool? isNameValid()
    {
        if (!StringValidationUtil.getInstance().isValidRequired(this.name, this.MINSTORENAMELENGTH, this.MAXCHAR)) {
            return false;
        } else {
            bool isEscapedCharactersContained = false;
            string storeNameEscaped = StringEscapeUtils.escapeHtml3(this.name);
            if (string.CompareOrdinal(this.name, storeNameEscaped) != 0) {
                isEscapedCharactersContained = true;
            }
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            bool isSpacesContained = false;
            if (stringValidationUtil.containsSpaces(this.name)) {
                isSpacesContained = true;
            }
            if (isSpacesContained || isEscapedCharactersContained) {
                HashMap hashMap = SpecialCharacterUtil.getHashMap();
                hashMap.put(new string[] { CommonSeps.getInstance().SPACE }, this.ONE_EMPTY_STRING_ARRAY);
                this.name = new Replace(hashMap).all(this.name);
            }
        }
        return true;
    }

    public virtual bool? isValid()
    {
        bool? valid = true;
        valid = this.isNameValid();
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isValidRequired(this.basketName, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.homeHostName, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.homeHostNamePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.hostName, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.hostNamePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.testHomeHostName, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.testHomeHostNamePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.testHostName, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.testHostNamePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.imagePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.staticPath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.categoryPath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.inventoryControl, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.subStores, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.tagLocation, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.packageLocation, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.ftp, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.ftpPath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.ftpUserName, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.ftpPassword, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.testFtp, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.testFtpPath.ToString(), this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.testFtpUserName, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.testFtpPassword, this.MINCHAR, this.MAXCHAR)) {
            valid = false;
        }
        if (valid == true) {
            return true;
        } else {
            return false;
        }
    }

    public virtual string nameValidationInfo()
    {
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isValidRequired(this.name, this.MINCHAR, this.MAXCHAR)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Name is invalid. Must be < ");
            stringBuffer.appendint(this.MAXCHAR);
            stringBuffer.append(" and > 0 characters.<br>");
            return stringBuffer.ToString();
        }
        return this.EMPTY_STRING;
    }

    public virtual string validationInfo()
    {
        try {
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.nameValidationInfo());
            if (!stringValidationUtil.isValidRequired(this.basketName, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Basket name is invalid. Must be < ");
                stringBuffer.appendint(this.MAXCHAR);
                stringBuffer.append(" and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidRequired(this.homeHostName, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Home host name is invalid. Must be < ");
                stringBuffer.appendint(this.MAXCHAR);
                stringBuffer.append(" and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.homeHostNamePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Home host name path is invalid. Must be < ");
                stringBuffer.appendint(this.MAXCHAR);
                stringBuffer.append(" and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidRequired(this.hostName, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Host name is invalid. Must be < ");
                stringBuffer.appendint(this.MAXCHAR);
                stringBuffer.append(" and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidRequired(this.hostNamePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Host name path is invalid. Must be < ");
                stringBuffer.appendint(this.MAXCHAR);
                stringBuffer.append(" and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.testHomeHostName, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Test home host name is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.testHomeHostNamePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Test home host name path is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.testHostName, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Test host name is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.testHostNamePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Test host name path is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidRequired(this.imagePath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Image path is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidRequired(this.staticPath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Static path is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidRequired(this.categoryPath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Category path is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidRequired(this.inventoryControl, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Inventory control is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.subStores, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Sub stores is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.tagLocation, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Tag location is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidRequired(this.packageLocation, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Package location is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.ftp, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Ftp is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.ftpPath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Ftp path is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.ftpUserName, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Ftp username is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.ftpPassword, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Ftp password is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.testFtp, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Test ftp is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.testFtpPath.ToString(), this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Test ftp Path is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.testFtpUserName, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Test ftp username is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            if (!stringValidationUtil.isValidNotRequired(this.testFtpPassword, this.MINCHAR, this.MAXCHAR)) {
                stringBuffer.append("Test ftp password is invalid. Must be < " + this.MAXCHAR + " and > 0 characters.<br>");
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
        }
    }

    public virtual string getTestHtmlPath()
    {
        return org.allbinary.globals.URLGLOBALS.getTestHtmlPath() + this.getCurrentHostNamePath();
    }

    public virtual string getCurrentHostName()
    {
        string location = this.EMPTY_STRING;
        if (org.allbinary.globals.URLGLOBALS.isTestingMode()) {
            location = this.getTestHostName();
        } else {
            location = this.getHostName();
        }
        return location;
    }

    public virtual string getCurrentHostNamePath()
    {
        string location = this.EMPTY_STRING;
        if (org.allbinary.globals.URLGLOBALS.isTestingMode()) {
            location = this.getTestHostNamePath();
        } else {
            location = this.getHostNamePath();
        }
        return location;
    }

    public virtual string getCurrentHomeHostName()
    {
        string location = this.EMPTY_STRING;
        if (org.allbinary.globals.URLGLOBALS.isTestingMode()) {
            location = this.getTestHomeHostName();
        } else {
            location = this.getHomeHostName();
        }
        return location;
    }

    public virtual string getCurrentHomeHostNamePath()
    {
        string location = this.EMPTY_STRING;
        if (org.allbinary.globals.URLGLOBALS.isTestingMode()) {
            location = this.getTestHomeHostNamePath();
        } else {
            location = this.getHomeHostNamePath();
        }
        return location;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getBasketName()
    {
        return this.basketName;
    }

    public virtual string getHomeHostName()
    {
        return this.homeHostName;
    }

    public virtual string getHomeHostNamePath()
    {
        return this.homeHostNamePath.ToString();
    }

    public virtual string getHostName()
    {
        return this.hostName;
    }

    public virtual string getHostNamePath()
    {
        return this.hostNamePath.ToString();
    }

    public virtual string getTestHomeHostName()
    {
        return this.testHomeHostName;
    }

    public virtual string getTestHomeHostNamePath()
    {
        return this.testHomeHostNamePath.ToString();
    }

    public virtual string getTestHostName()
    {
        return this.testHostName;
    }

    public virtual string getTestHostNamePath()
    {
        return this.testHostNamePath.ToString();
    }

    public virtual string getStaticPath()
    {
        return this.staticPath.ToString();
    }

    public virtual string getCategoryPath()
    {
        return this.categoryPath.ToString();
    }

    public virtual string getInventoryControl()
    {
        return this.inventoryControl;
    }

    // throws Exception
    public virtual BasicArrayList getSubStores()
    {
        try {
            Tokenizer tokenizer = new Tokenizer(CommonSeps.getInstance().SEMICOLON);
            BasicArrayList subStoreVector = tokenizer.getTokensFromString(this.subStores, new BasicArrayListD());
            return subStoreVector;
        } catch (Exception e) {
            throw e;
        }
    }

    public virtual string getTagLocation()
    {
        return this.tagLocation;
    }

    public virtual string getPackageLocation()
    {
        return this.packageLocation;
    }

    public virtual string getFtp()
    {
        return this.ftp;
    }

    public virtual string getFtpUserName()
    {
        return this.ftpUserName;
    }

    public virtual string getFtpPassword()
    {
        return this.ftpPassword;
    }

    public virtual string getTestFtp()
    {
        return this.testFtp;
    }

    public virtual string getTestFtpUserName()
    {
        return this.testFtpUserName;
    }

    public virtual string getTestFtpPassword()
    {
        return this.testFtpPassword;
    }

    public virtual string getFtpPath()
    {
        return this.ftpPath.ToString();
    }

    public virtual string getTestFtpPath()
    {
        return this.testFtpPath.ToString();
    }

    public virtual string getTimeCreated()
    {
        return this.timeCreated;
    }

    public virtual string getLastModified()
    {
        return this.lastModified;
    }

    public virtual void setName(string value)
    {
        this.name = value;
    }

    public virtual void setBasketName(string value)
    {
        this.basketName = value;
    }

    public virtual void setHomeHostName(string value)
    {
        this.homeHostName = value;
    }

    // throws Exception
    public virtual void setHomeHostNamePath(string value)
    {
        this.homeHostNamePath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    public virtual void setHostName(string value)
    {
        this.hostName = value;
    }

    // throws Exception
    public virtual void setHostNamePath(string value)
    {
        this.hostNamePath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    public virtual void setTestHomeHostName(string value)
    {
        this.testHomeHostName = value;
    }

    // throws Exception
    public virtual void setTestHomeHostNamePath(string value)
    {
        this.testHomeHostNamePath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    public virtual void setTestHostName(string value)
    {
        this.testHostName = value;
    }

    // throws Exception
    public virtual void setTestHostNamePath(string value)
    {
        this.testHostNamePath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    // throws Exception
    public virtual void setImagePath(string value)
    {
        this.imagePath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    // throws Exception
    public virtual void setStaticPath(string value)
    {
        this.staticPath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    // throws Exception
    public virtual void setCategoryPath(string value)
    {
        this.categoryPath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    public virtual void setSubStores(string value)
    {
        this.subStores = value;
    }

    public virtual void setTagLocation(string value)
    {
        this.tagLocation = value;
    }

    public virtual void setPackageLocation(string value)
    {
        this.packageLocation = value;
    }

    public virtual void setInventoryControl(string value)
    {
        this.inventoryControl = value;
    }

    public virtual void getPackageLocation(string value)
    {
        this.packageLocation = value;
    }

    public virtual void setFtp(string value)
    {
        this.ftp = value;
    }

    public virtual void setFtpUserName(string value)
    {
        this.ftpUserName = value;
    }

    public virtual void setFtpPassword(string value)
    {
        this.ftpPassword = value;
    }

    public virtual void setTestFtp(string value)
    {
        this.testFtp = value;
    }

    public virtual void setTestFtpUserName(string value)
    {
        this.testFtpUserName = value;
    }

    public virtual void setTestFtpPassword(string value)
    {
        this.testFtpPassword = value;
    }

    public virtual void setTimeCreated(string value)
    {
        this.timeCreated = value;
    }

    public virtual void setLastModified(string value)
    {
        this.lastModified = value;
    }

    // throws Exception
    public virtual void setFtpPath(string value)
    {
        this.ftpPath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    // throws Exception
    public virtual void setTestFtpPath(string value)
    {
        this.testFtpPath = new AbPath(value, StringUtil.getInstance().EMPTY_STRING);
    }

    // throws Exception
    private bool createDirectories()
    {
        AbPath storeAbPath = new AbPath(URLGLOBALS.getWebappPath() + this.getCurrentHomeHostNamePath(), StringUtil.getInstance().EMPTY_STRING);
        if (!this.directory.create(storeAbPath)) {
            return false;
        }
        if (!this.directory.create(new AbPath(storeAbPath + this.getCategoryPath(), StringUtil.getInstance().EMPTY_STRING))) {
            return false;
        }
        if (!this.directory.create(new AbPath(storeAbPath + this.getStaticPath(), StringUtil.getInstance().EMPTY_STRING))) {
            return false;
        }
        return true;
    }

    // throws Exception
    public virtual void install(int current, int total)
    {
        try {
            if (!this.createDirectories()) {
                throw new Exception("Unable to create store directories");
            }
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(URLGLOBALS.getMainPath());
            stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
            string viewPath = stringBuffer.ToString();
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(viewPath);
            stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().INSTALLPATH);
            AbPath fromDirectoryAbPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(viewPath);
            stringBuffer.append("special");
            stringBuffer.append(AbPathData.getInstance().SEPARATOR);
            AbPath fromSpecialDirectoryAbPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(viewPath);
            stringBuffer.append(this.getName());
            stringBuffer.append(AbPathData.getInstance().SEPARATOR);
            AbPath toDirectoryAbPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
            if (current == 0) {
                if (!this.directory.create(toDirectoryAbPath)) {
                    throw new Exception("Unable to create store view directory: " + toDirectoryAbPath.ToString());
                }
            }
            int viewTotal = (total * 85) / 100;
            int installTotal = (total * 93) / 100;
            if (current < viewTotal) {
                AbFile file = AbFile.createAbFileFromAbPath(fromSpecialDirectoryAbPath);
                if (file.isDirectory()) {
                    int halfViewTotal = viewTotal / 2;
                    if (current < halfViewTotal) {
                        this.installViews(fromSpecialDirectoryAbPath, toDirectoryAbPath, current, halfViewTotal);
                    } else if (current < viewTotal) {
                        this.installViews(fromDirectoryAbPath, toDirectoryAbPath, current - halfViewTotal, viewTotal - halfViewTotal);
                    }
                } else {
                    this.installViews(fromDirectoryAbPath, toDirectoryAbPath, current, viewTotal);
                }
            } else if (current < installTotal) {
                this.installResources(fromDirectoryAbPath, current - viewTotal, installTotal - viewTotal);
            } else {
                this.installMedia(fromDirectoryAbPath, current - installTotal, total - installTotal);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "install()", e);
            }
            throw e;
        }
    }

    // throws Exception
    private void installViews(AbPath fromDirectoryAbPath, AbPath toDirectoryAbPath, int current, int total)
    {
        FileUtil.getInstance().copyDirectoryPortion(fromDirectoryAbPath, toDirectoryAbPath, true, false, current, total);
    }

    // throws Exception
    private void installResources(AbPath fromDirectoryAbPath, int current, int total)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(fromDirectoryAbPath.ToString());
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        stringBuffer.append("Resources");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        AbPath installCategoryAbPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(this.getCurrentHomeHostNamePath());
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        stringBuffer.append(this.getCategoryPath());
        AbPath categoryAbPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
        FileUtil.getInstance().copyDirectoryPortion(installCategoryAbPath, categoryAbPath, true, false, current, total);
    }

    // throws Exception
    private void installMedia(AbPath fromDirectoryAbPath, int current, int total)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(fromDirectoryAbPath.ToString());
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().TEMPLATEPATH);
        stringBuffer.append("images");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        AbPath viewStoreImagesDirectoryAbPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
        AbPath storeAbPath = new AbPath(URLGLOBALS.getWebappPath() + this.getCurrentHomeHostNamePath(), StringUtil.getInstance().EMPTY_STRING);
        FileUtil.getInstance().copyDirectoryPortion(viewStoreImagesDirectoryAbPath, storeAbPath, true, false, current, total);
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        BasicArrayList dataVector = new BasicArrayListD();
        dataVector.add(this.name);
        dataVector.add(this.homeHostName);
        dataVector.add(this.homeHostNamePath.ToString());
        dataVector.add(this.hostName);
        dataVector.add(this.hostNamePath.ToString());
        dataVector.add(this.testHomeHostName);
        dataVector.add(this.testHomeHostNamePath.ToString());
        dataVector.add(this.testHostName);
        dataVector.add(this.testHostNamePath.ToString());
        dataVector.add(this.imagePath.ToString());
        dataVector.add(this.staticPath.ToString());
        dataVector.add(this.categoryPath.ToString());
        dataVector.add(this.inventoryControl);
        ContextConfigurationDomDocumentMapping contextConfigurationDomDocumentMapping = new ContextConfigurationDomDocumentMapping(this.getContextConfigurationInterface());
        dataVector.add(contextConfigurationDomDocumentMapping.toDomDocumentString());
        dataVector.add(this.subStores);
        dataVector.add(this.tagLocation);
        dataVector.add(this.packageLocation);
        dataVector.add(this.ftp);
        dataVector.add(this.ftpPath.ToString());
        dataVector.add(this.ftpUserName);
        dataVector.add(this.ftpPassword);
        dataVector.add(this.testFtp);
        dataVector.add(this.testFtpPath.ToString());
        dataVector.add(this.testFtpUserName);
        dataVector.add(this.testFtpPassword);
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        dataVector.add(time);
        dataVector.add(time);
        return dataVector;
    }

    // throws Exception
    public virtual HashMap toHashMap()
    {
        StoreFrontData storeFrontData = StoreFrontData.getInstance();
        HashMap dataHashMap = StdUtil.getInstance().createHashMap();
        dataHashMap.put(storeFrontData.NAME, this.name);
        dataHashMap.put(storeFrontData.HOMEHOSTNAME, this.homeHostName);
        dataHashMap.put(storeFrontData.HOMEHOSTNAMEPATH, this.homeHostNamePath.ToString());
        dataHashMap.put(storeFrontData.HOSTNAME, this.hostName);
        dataHashMap.put(storeFrontData.HOSTNAMEPATH, this.hostNamePath.ToString());
        dataHashMap.put(storeFrontData.TESTHOMEHOSTNAME, this.testHomeHostName);
        dataHashMap.put(storeFrontData.TESTHOMEHOSTNAMEPATH, this.testHomeHostNamePath.ToString());
        dataHashMap.put(storeFrontData.TESTHOSTNAME, this.testHostName);
        dataHashMap.put(storeFrontData.TESTHOSTNAMEPATH, this.testHostNamePath.ToString());
        dataHashMap.put(storeFrontData.IMAGEPATH, this.imagePath.ToString());
        dataHashMap.put(storeFrontData.STATICPATH, this.staticPath.ToString());
        dataHashMap.put(storeFrontData.CATEGORYPATH, this.categoryPath.ToString());
        dataHashMap.put(storeFrontData.INVENTORYCONTROL, this.inventoryControl);
        ContextConfigurationDomDocumentMapping contextConfigurationDomDocumentMapping = new ContextConfigurationDomDocumentMapping(this.getContextConfigurationInterface());
        dataHashMap.put(storeFrontData.CONFIGURATION, contextConfigurationDomDocumentMapping.toDomDocumentString());
        dataHashMap.put(storeFrontData.SUBSTORES, this.subStores);
        dataHashMap.put(storeFrontData.TAGLOCATION, this.tagLocation);
        dataHashMap.put(storeFrontData.PACKAGELOCATION, this.packageLocation);
        dataHashMap.put(storeFrontData.FTP, this.ftp);
        dataHashMap.put(storeFrontData.FTPPATH, this.ftpPath.ToString());
        dataHashMap.put(storeFrontData.FTPUSERNAME, this.ftpUserName);
        dataHashMap.put(storeFrontData.FTPPASSWORD, this.ftpPassword);
        dataHashMap.put(storeFrontData.TESTFTP, this.testFtp);
        dataHashMap.put(storeFrontData.TESTFTPPATH, this.testFtpPath.ToString());
        dataHashMap.put(storeFrontData.TESTFTPUSERNAME, this.testFtpUserName);
        dataHashMap.put(storeFrontData.TESTFTPPASSWORD, this.testFtpPassword);
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        dataHashMap.put(EntryData.getInstance().LASTMODIFIED, time);
        return dataHashMap;
    }

    public virtual object getKey()
    {
        return ((object) this.getName());
    }

    public virtual ContextConfigurationInterface getContextConfigurationInterface()
    {
        return this.contextConfigurationInterface;
    }

    public virtual void setContextConfigurationInterface(ContextConfigurationInterface contextConfigurationInterface)
    {
        this.contextConfigurationInterface = contextConfigurationInterface;
    }

}

