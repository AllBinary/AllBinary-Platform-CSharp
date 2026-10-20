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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;

namespace org.allbinary.business.user.commerce.money.payment.gateway;

public interface PaymentGatewayInterface : TableMappingInterface
{
    string getEnable();

    string getStoreName();

    string getName();

    string getPaymentMethod();

    string getMode();

    string getTestProtocol();

    string getTestServer();

    string getTestPort();

    string getTestPath();

    string getServerProtocol();

    string getServer();

    string getServerPort();

    string getServerPath();

    string getUserName();

    string getPassword();

    string getProxyProtocol();

    string getProxyServer();

    string getProxyPath();

    string getProxyPort();

    string getProxyUserName();

    string getProxyPassword();

    string getTimeout();

    string getProxyTimeout();

    string getSpecial1();

    string getSpecial2();

    string getSpecial3();

    string getSpecial4();

    string getSpecial5();

    string getSpecial6();

    string getSpecial7();

    string getSpecial8();

    string getSpecial9();

    string getLastModified();

    string getTimeEntered();

    void setEnable(string value);

    void setStoreName(string value);

    void setName(string value);

    void setPaymentMethod(string value);

    void setMode(string value);

    void setTestProtocol(string value);

    void setTestServer(string value);

    void setTestPort(string value);

    void setTestPath(string value);

    void setServerProtocol(string value);

    void setServer(string value);

    void setServerPort(string value);

    void setServerPath(string value);

    void setUserName(string value);

    void setPassword(string value);

    void setProxyProtocol(string value);

    void setProxyServer(string value);

    void setProxyPath(string value);

    void setProxyPort(string value);

    void setProxyUserName(string value);

    void setProxyPassword(string value);

    void setTimeout(string value);

    void setProxyTimeout(string value);

    void setSpecial1(string value);

    void setSpecial2(string value);

    void setSpecial3(string value);

    void setSpecial4(string value);

    void setSpecial5(string value);

    void setSpecial6(string value);

    void setSpecial7(string value);

    void setSpecial8(string value);

    void setSpecial9(string value);

    void setLastModified(string value);

    void setTimeEntered(string value);

    // throws Exception
    HashMap<object, object> toHashMap(bool isEncrypted);

    BasicArrayList toVector(bool isEncrypted);

}

