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
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserData = org.allbinary.business.user.UserData;
using Tokenizer = org.allbinary.logic.@string.tokens.Tokenizer;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.context.modules.storefronts;

public class BasicStoreFront : BasicStoreFrontInterface
{
    private string name;
    private string userName;
    private string basketName;
    private string homeHostName;
    private string homeHostNamePath;
    private string hostName;
    private string hostNamePath;
    private string testHomeHostName;
    private string testHomeHostNamePath;
    private string testHostName;
    private string testHostNamePath;
    private string imagePath;
    private string staticPath;
    private string categoryPath;
    private string inventoryControl;
    private string subStores;
    private string tagLocation;
    private string packageLocation;
    private string ftp;
    private string ftpPath;
    private string ftpUserName;
    private string ftpPassword;
    private string testFtp;
    private string testFtpPath;
    private string testFtpUserName;
    private string testFtpPassword;
    private string timeCreated;
    private string lastModified;
    public BasicStoreFront()
    {
    }

    public BasicStoreFront(HashMap<object, object> storeHashMap)
    {
        StoreFrontData storeFrontData = StoreFrontData.getInstance();
        this.name = ((string) storeHashMap.get(storeFrontData.NAME));
        this.userName = ((string) storeHashMap.get(UserData.USERNAME));
        this.basketName = ((string) storeHashMap.get(storeFrontData.NAME));
        this.homeHostName = ((string) storeHashMap.get(storeFrontData.HOMEHOSTNAME));
        this.homeHostNamePath = ((string) storeHashMap.get(storeFrontData.HOMEHOSTNAMEPATH));
        this.hostName = ((string) storeHashMap.get(storeFrontData.HOSTNAME));
        this.hostNamePath = ((string) storeHashMap.get(storeFrontData.HOSTNAMEPATH));
        this.testHomeHostName = ((string) storeHashMap.get(storeFrontData.TESTHOMEHOSTNAME));
        this.testHomeHostNamePath = ((string) storeHashMap.get(storeFrontData.TESTHOMEHOSTNAMEPATH));
        this.testHostName = ((string) storeHashMap.get(storeFrontData.TESTHOSTNAME));
        this.testHostNamePath = ((string) storeHashMap.get(storeFrontData.TESTHOSTNAMEPATH));
        this.imagePath = ((string) storeHashMap.get(storeFrontData.IMAGEPATH));
        this.staticPath = ((string) storeHashMap.get(storeFrontData.STATICPATH));
        this.categoryPath = ((string) storeHashMap.get(storeFrontData.CATEGORYPATH));
        this.inventoryControl = ((string) storeHashMap.get(storeFrontData.INVENTORYCONTROL));
        this.subStores = ((string) storeHashMap.get(storeFrontData.SUBSTORES));
        this.tagLocation = ((string) storeHashMap.get(storeFrontData.TAGLOCATION));
        this.packageLocation = ((string) storeHashMap.get(storeFrontData.PACKAGELOCATION));
        this.ftp = ((string) storeHashMap.get(storeFrontData.FTP));
        this.ftpPath = ((string) storeHashMap.get(storeFrontData.FTPPATH));
        this.ftpUserName = ((string) storeHashMap.get(storeFrontData.FTPUSERNAME));
        this.ftpPassword = ((string) storeHashMap.get(storeFrontData.FTPPASSWORD));
        this.testFtp = ((string) storeHashMap.get(storeFrontData.TESTFTP));
        this.testFtpPath = ((string) storeHashMap.get(storeFrontData.TESTFTPPATH));
        this.testFtpUserName = ((string) storeHashMap.get(storeFrontData.TESTFTPUSERNAME));
        this.testFtpPassword = ((string) storeHashMap.get(storeFrontData.TESTFTPPASSWORD));
        this.timeCreated = ((string) storeHashMap.get(EntryData.getInstance().TIMECREATED));
        this.lastModified = ((string) storeHashMap.get(EntryData.getInstance().LASTMODIFIED));
    }

    public virtual string getTestHtmlPath()
    {
        return org.allbinary.globals.URLGLOBALS.getTestHtmlPath() + this.getCurrentHostNamePath();
    }

    public virtual string getCurrentHostName()
    {
        string location = null;
        if (org.allbinary.globals.URLGLOBALS.isTestingMode()) {
            location = this.getTestHostName();
        } else {
            location = this.getHostName();
        }
        return location;
    }

    public virtual string getCurrentHostNamePath()
    {
        string location = null;
        if (org.allbinary.globals.URLGLOBALS.isTestingMode()) {
            location = this.getTestHostNamePath();
        } else {
            location = this.getHostNamePath();
        }
        return location;
    }

    public virtual string getCurrentHomeHostName()
    {
        string location = null;
        if (org.allbinary.globals.URLGLOBALS.isTestingMode()) {
            location = this.getTestHomeHostName();
        } else {
            location = this.getHomeHostName();
        }
        return location;
    }

    public virtual string getCurrentHomeHostNamePath()
    {
        string location = null;
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

    public virtual string getUserName()
    {
        return this.userName;
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
        return this.homeHostNamePath;
    }

    public virtual string getHostName()
    {
        return this.hostName;
    }

    public virtual string getHostNamePath()
    {
        return this.hostNamePath;
    }

    public virtual string getTestHomeHostName()
    {
        return this.testHomeHostName;
    }

    public virtual string getTestHomeHostNamePath()
    {
        return this.testHomeHostNamePath;
    }

    public virtual string getTestHostName()
    {
        return this.testHostName;
    }

    public virtual string getTestHostNamePath()
    {
        return this.testHostNamePath;
    }

    public virtual string getStaticPath()
    {
        return this.staticPath;
    }

    public virtual string getCategoryPath()
    {
        return this.categoryPath;
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
        return this.ftpPath;
    }

    public virtual string getTestFtpPath()
    {
        return this.testFtpPath;
    }

    public virtual string getTimeCreated()
    {
        return this.timeCreated;
    }

    public virtual string getLastModified()
    {
        return this.lastModified;
    }

}

