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

namespace org.allbinary.business.init.db;

public interface DatabaseConnectionInfoInterface
{
    string getUrl();

    string getJdbcDriver();

    string getName();

    string getUserName();

    string getPassword();

    string getHost();

    string getSchema();

    string getServer();

    string getPort();

    void setJdbcDriver(string value);

    void setName(string value);

    void setUserName(string value);

    void setPassword(string value);

    void setSchema(string value);

    void setServer(string value);

    void setPort(string value);

    string getUserNameKey();

    string getPasswordKey();

}

