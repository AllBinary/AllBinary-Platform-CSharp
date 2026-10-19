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
using ContextConfigurationInterface = org.allbinary.business.context.configuration.ContextConfigurationInterface;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.business.context.modules.storefront;

public interface StoreFrontInterface : TableMappingInterface
{
    bool? isNameValid();

    bool? isValid();

    string nameValidationInfo();

    string validationInfo();

    string getTestHtmlPath();

    string getCurrentHostName();

    string getCurrentHostNamePath();

    string getCurrentHomeHostName();

    string getCurrentHomeHostNamePath();

    string getName();

    string getBasketName();

    string getHomeHostName();

    string getHomeHostNamePath();

    string getHostName();

    string getHostNamePath();

    string getTestHomeHostName();

    string getTestHomeHostNamePath();

    string getTestHostName();

    string getTestHostNamePath();

    string getStaticPath();

    string getCategoryPath();

    // throws Exception
    BasicArrayList getSubStores();

    string getTagLocation();

    string getPackageLocation();

    string getInventoryControl();

    ContextConfigurationInterface getContextConfigurationInterface();

    void setContextConfigurationInterface(ContextConfigurationInterface contextConfigurationInterface);

    string getFtp();

    string getFtpPath();

    string getFtpUserName();

    string getFtpPassword();

    string getTestFtp();

    string getTestFtpPath();

    string getTestFtpUserName();

    string getTestFtpPassword();

    string getTimeCreated();

    string getLastModified();

    void setName(string value);

    void setBasketName(string value);

    void setHomeHostName(string value);

    // throws Exception
    void setHomeHostNamePath(string value);

    void setHostName(string value);

    // throws Exception
    void setHostNamePath(string value);

    void setTestHomeHostName(string value);

    // throws Exception
    void setTestHomeHostNamePath(string value);

    void setTestHostName(string value);

    // throws Exception
    void setTestHostNamePath(string value);

    // throws Exception
    void setImagePath(string value);

    // throws Exception
    void setStaticPath(string value);

    // throws Exception
    void setCategoryPath(string value);

    void setPackageLocation(string value);

    void setInventoryControl(string value);

    void setFtp(string value);

    // throws Exception
    void setFtpPath(string value);

    void setFtpUserName(string value);

    void setFtpPassword(string value);

    void setTestFtp(string value);

    // throws Exception
    void setTestFtpPath(string value);

    void setTestFtpUserName(string value);

    void setTestFtpPassword(string value);

    void setTimeCreated(string value);

    void setLastModified(string value);

    // throws Exception
    void install(int current, int total);

}

