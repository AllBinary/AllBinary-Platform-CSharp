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

namespace org.allbinary.business.context.modules.storefronts;

public interface BasicStoreFrontInterface
{
    string getTestHtmlPath();

    string getCurrentHostName();

    string getCurrentHostNamePath();

    string getCurrentHomeHostName();

    string getCurrentHomeHostNamePath();

    string getName();

    string getUserName();

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

}

