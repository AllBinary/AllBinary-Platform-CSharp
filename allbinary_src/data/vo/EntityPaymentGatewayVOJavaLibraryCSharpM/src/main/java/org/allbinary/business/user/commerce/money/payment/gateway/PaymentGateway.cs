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
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserData = org.allbinary.business.user.UserData;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using StdUtil = org.allbinary.logic.StdUtil;
using SuperCrypt = org.allbinary.logic.control.crypt.SuperCrypt;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.business.user.commerce.money.payment.gateway;

public class PaymentGateway : PaymentGatewayInterface
{
    private string storeName = null;
    private string name = null;
    private string enable = null;
    private string paymentMethod = null;
    private string mode = null;
    private string testProtocol = null;
    private string testServer = null;
    private string testPort = null;
    private string testPath = null;
    private string serverProtocol = null;
    private string server = null;
    private string serverPort = null;
    private string serverPath = null;
    private string timeout = null;
    private string userName = null;
    private string password = null;
    private string proxyProtocol = null;
    private string proxyServer = null;
    private string proxyPort = null;
    private string proxyPath = null;
    private string proxyUserName = null;
    private string proxyPassword = null;
    private string proxyTimeout = null;
    private string special1 = null;
    private string special2 = null;
    private string special3 = null;
    private string special4 = null;
    private string special5 = null;
    private string special6 = null;
    private string special7 = null;
    private string special8 = null;
    private string special9 = null;
    private string lastModified = null;
    private string timeEntered = null;
    public PaymentGateway(HashMap hashMap)
    {
        this.getFormData(hashMap);
    }

    public virtual void getFormData(HashMap hashMap)
    {
        StringUtil stringUtil = StringUtil.getInstance();
        string empty = stringUtil.EMPTY_STRING;
        this.storeName = ((string) hashMap.get(StoreFrontData.getInstance().NAME.ToString()));
        this.name = ((string) hashMap.get(PaymentGatewayData.NAME.ToString()));
        this.enable = stringUtil.getNonNull(((string) hashMap.get(EntryData.getInstance().ENABLE.ToString())));
        this.paymentMethod = stringUtil.getNonNull(((string) hashMap.get(PaymentData.METHOD.ToString())));
        this.mode = stringUtil.getNonNull(((string) hashMap.get(PaymentGatewayData.MODE.ToString())));
        this.testProtocol = stringUtil.getNonNull(((string) hashMap.get(PaymentGatewayData.TESTPROTOCOL.ToString())));
        this.testServer = stringUtil.getNonNull(((string) hashMap.get(PaymentGatewayData.TESTSERVER.ToString())));
        this.testPort = stringUtil.getNonNull(((string) hashMap.get(PaymentGatewayData.TESTPORT.ToString())));
        this.testPath = ((string) hashMap.get(PaymentGatewayData.TESTPATH.ToString()));
        if (this.testPath == null) {
            this.testPath = empty;
        }
        this.serverProtocol = ((string) hashMap.get(PaymentGatewayData.SERVERPROTOCOL.ToString()));
        if (this.serverProtocol == null) {
            this.serverProtocol = empty;
        }
        this.server = ((string) hashMap.get(PaymentGatewayData.SERVER.ToString()));
        if (this.server == null) {
            this.server = empty;
        }
        this.serverPort = ((string) hashMap.get(PaymentGatewayData.SERVERPORT.ToString()));
        if (this.serverPort == null) {
            this.serverPort = empty;
        }
        this.serverPath = ((string) hashMap.get(PaymentGatewayData.SERVERPATH.ToString()));
        if (this.serverPath == null) {
            this.serverPath = empty;
        }
        this.userName = ((string) hashMap.get(UserData.USERNAME.ToString()));
        if (this.userName == null) {
            this.userName = empty;
        }
        this.password = ((string) hashMap.get(UserData.PASSWORD.ToString()));
        if (this.password == null) {
            this.password = empty;
        }
        this.timeout = ((string) hashMap.get(PaymentGatewayData.TIMEOUT.ToString()));
        if (this.timeout == null) {
            this.timeout = empty;
        }
        this.proxyProtocol = ((string) hashMap.get(PaymentGatewayData.PROXYPROTOCOL.ToString()));
        if (this.proxyProtocol == null) {
            this.proxyProtocol = empty;
        }
        this.proxyServer = ((string) hashMap.get(PaymentGatewayData.PROXYSERVER.ToString()));
        if (this.proxyServer == null) {
            this.proxyServer = empty;
        }
        this.proxyPort = ((string) hashMap.get(PaymentGatewayData.PROXYPORT.ToString()));
        if (this.proxyPort == null) {
            this.proxyPort = empty;
        }
        this.proxyPath = ((string) hashMap.get(PaymentGatewayData.PROXYPATH.ToString()));
        if (this.proxyPath == null) {
            this.proxyPath = empty;
        }
        this.proxyUserName = ((string) hashMap.get(PaymentGatewayData.PROXYUSERNAME.ToString()));
        if (this.proxyUserName == null) {
            this.proxyUserName = empty;
        }
        this.proxyPassword = ((string) hashMap.get(PaymentGatewayData.PROXYPASSWORD.ToString()));
        if (this.proxyPassword == null) {
            this.proxyPassword = empty;
        }
        this.proxyTimeout = ((string) hashMap.get(PaymentGatewayData.PROXYTIMEOUT.ToString()));
        if (this.proxyTimeout == null) {
            this.proxyTimeout = empty;
        }
        this.special1 = ((string) hashMap.get(PaymentGatewayData.SPECIAL1.ToString()));
        if (this.special1 == null) {
            this.special1 = empty;
        }
        this.special2 = ((string) hashMap.get(PaymentGatewayData.SPECIAL2.ToString()));
        if (this.special2 == null) {
            this.special2 = empty;
        }
        this.special3 = ((string) hashMap.get(PaymentGatewayData.SPECIAL3.ToString()));
        if (this.special3 == null) {
            this.special3 = empty;
        }
        this.special4 = ((string) hashMap.get(PaymentGatewayData.SPECIAL4.ToString()));
        if (this.special4 == null) {
            this.special4 = empty;
        }
        this.special5 = ((string) hashMap.get(PaymentGatewayData.SPECIAL5.ToString()));
        if (this.special5 == null) {
            this.special5 = empty;
        }
        this.special6 = ((string) hashMap.get(PaymentGatewayData.SPECIAL6.ToString()));
        if (this.special6 == null) {
            this.special6 = empty;
        }
        this.special7 = ((string) hashMap.get(PaymentGatewayData.SPECIAL7.ToString()));
        if (this.special7 == null) {
            this.special7 = empty;
        }
        this.special8 = ((string) hashMap.get(PaymentGatewayData.SPECIAL8.ToString()));
        if (this.special8 == null) {
            this.special8 = empty;
        }
        this.special9 = ((string) hashMap.get(PaymentGatewayData.SPECIAL9.ToString()));
        if (this.special9 == null) {
            this.special9 = empty;
        }
        this.lastModified = ((string) hashMap.get(EntryData.getInstance().LASTMODIFIED.ToString()));
        if (this.lastModified == null) {
            this.lastModified = empty;
        }
        this.timeEntered = ((string) hashMap.get(EntryData.getInstance().TIMECREATED.ToString()));
        if (this.timeEntered == null) {
            this.timeEntered = empty;
        }
    }

    public virtual string getStoreName()
    {
        return this.storeName;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getEnable()
    {
        return this.enable;
    }

    public virtual string getPaymentMethod()
    {
        return this.paymentMethod;
    }

    public virtual string getMode()
    {
        return this.mode;
    }

    public virtual string getTestProtocol()
    {
        return this.testProtocol;
    }

    public virtual string getTestServer()
    {
        return this.testServer;
    }

    public virtual string getTestPort()
    {
        return this.testPort;
    }

    public virtual string getTestPath()
    {
        return this.testPath;
    }

    public virtual string getServerProtocol()
    {
        return this.serverProtocol;
    }

    public virtual string getServer()
    {
        return this.server;
    }

    public virtual string getServerPort()
    {
        return this.serverPort;
    }

    public virtual string getServerPath()
    {
        return this.serverPath;
    }

    public virtual string getUserName()
    {
        return this.userName;
    }

    public virtual string getPassword()
    {
        return this.password;
    }

    public virtual string getProxyProtocol()
    {
        return this.proxyProtocol;
    }

    public virtual string getProxyServer()
    {
        return this.proxyServer;
    }

    public virtual string getProxyPath()
    {
        return this.proxyPath;
    }

    public virtual string getProxyPort()
    {
        return this.proxyPort;
    }

    public virtual string getProxyUserName()
    {
        return this.proxyUserName;
    }

    public virtual string getProxyPassword()
    {
        return this.proxyPassword;
    }

    public virtual string getTimeout()
    {
        return this.timeout;
    }

    public virtual string getProxyTimeout()
    {
        return this.proxyTimeout;
    }

    public virtual string getSpecial1()
    {
        return this.special1;
    }

    public virtual string getSpecial2()
    {
        return this.special2;
    }

    public virtual string getSpecial3()
    {
        return this.special3;
    }

    public virtual string getSpecial4()
    {
        return this.special4;
    }

    public virtual string getSpecial5()
    {
        return this.special5;
    }

    public virtual string getSpecial6()
    {
        return this.special6;
    }

    public virtual string getSpecial7()
    {
        return this.special7;
    }

    public virtual string getSpecial8()
    {
        return this.special8;
    }

    public virtual string getSpecial9()
    {
        return this.special9;
    }

    public virtual string getLastModified()
    {
        return this.lastModified;
    }

    public virtual string getTimeEntered()
    {
        return this.timeEntered;
    }

    public virtual void setEnable(string value)
    {
        this.enable = value;
    }

    public virtual void setStoreName(string value)
    {
        this.storeName = value;
    }

    public virtual void setName(string value)
    {
        this.name = value;
    }

    public virtual void setPaymentMethod(string value)
    {
        this.paymentMethod = value;
    }

    public virtual void setMode(string value)
    {
        this.mode = value;
    }

    public virtual void setTestProtocol(string value)
    {
        this.testProtocol = value;
    }

    public virtual void setTestServer(string value)
    {
        this.testServer = value;
    }

    public virtual void setTestPort(string value)
    {
        this.testPort = value;
    }

    public virtual void setTestPath(string value)
    {
        this.testPath = value;
    }

    public virtual void setServerProtocol(string value)
    {
        this.serverProtocol = value;
    }

    public virtual void setServer(string value)
    {
        this.server = value;
    }

    public virtual void setServerPort(string value)
    {
        this.serverPort = value;
    }

    public virtual void setServerPath(string value)
    {
        this.serverPath = value;
    }

    public virtual void setTimeout(string value)
    {
        this.timeout = value;
    }

    public virtual void setUserName(string value)
    {
        this.userName = value;
    }

    public virtual void setPassword(string value)
    {
        this.password = value;
    }

    public virtual void setProxyProtocol(string value)
    {
        this.proxyProtocol = value;
    }

    public virtual void setProxyServer(string value)
    {
        this.proxyServer = value;
    }

    public virtual void setProxyPort(string value)
    {
        this.proxyPort = value;
    }

    public virtual void setProxyPath(string value)
    {
        this.proxyPath = value;
    }

    public virtual void setProxyUserName(string value)
    {
        this.proxyUserName = value;
    }

    public virtual void setProxyPassword(string value)
    {
        this.proxyPassword = value;
    }

    public virtual void setProxyTimeout(string value)
    {
        this.proxyTimeout = value;
    }

    public virtual void setSpecial1(string value)
    {
        this.special1 = value;
    }

    public virtual void setSpecial2(string value)
    {
        this.special2 = value;
    }

    public virtual void setSpecial3(string value)
    {
        this.special3 = value;
    }

    public virtual void setSpecial4(string value)
    {
        this.special4 = value;
    }

    public virtual void setSpecial5(string value)
    {
        this.special5 = value;
    }

    public virtual void setSpecial6(string value)
    {
        this.special6 = value;
    }

    public virtual void setSpecial7(string value)
    {
        this.special7 = value;
    }

    public virtual void setSpecial8(string value)
    {
        this.special8 = value;
    }

    public virtual void setSpecial9(string value)
    {
        this.special9 = value;
    }

    public virtual void setLastModified(string value)
    {
        this.lastModified = value;
    }

    public virtual void setTimeEntered(string value)
    {
        this.timeEntered = value;
    }

    // throws Exception
    public virtual HashMap toHashMap()
    {
        return this.toHashMap(true);
    }

    // throws Exception
    public virtual HashMap toHashMap(bool isEncrypted)
    {
        HashMap paymentGatewayHashMap = StdUtil.getInstance().createHashMap();
        paymentGatewayHashMap.put(EntryData.getInstance().ENABLE, this.enable);
        paymentGatewayHashMap.put(StoreFrontData.getInstance().NAME.ToString(), this.storeName);
        paymentGatewayHashMap.put(PaymentGatewayData.NAME.ToString(), this.getName());
        paymentGatewayHashMap.put(PaymentData.METHOD.ToString(), this.paymentMethod);
        paymentGatewayHashMap.put(PaymentGatewayData.MODE.ToString(), this.mode);
        paymentGatewayHashMap.put(PaymentGatewayData.TESTPROTOCOL.ToString(), this.testProtocol);
        paymentGatewayHashMap.put(PaymentGatewayData.TESTSERVER.ToString(), this.testServer);
        paymentGatewayHashMap.put(PaymentGatewayData.TESTPORT.ToString(), this.testPort);
        paymentGatewayHashMap.put(PaymentGatewayData.TESTPATH.ToString(), this.testPath);
        paymentGatewayHashMap.put(PaymentGatewayData.SERVERPROTOCOL.ToString(), this.serverProtocol);
        paymentGatewayHashMap.put(PaymentGatewayData.SERVER.ToString(), this.server);
        paymentGatewayHashMap.put(PaymentGatewayData.SERVERPORT.ToString(), this.serverPort);
        paymentGatewayHashMap.put(PaymentGatewayData.SERVERPATH.ToString(), this.serverPath);
        if (isEncrypted) {
            SuperCrypt superCrypt = new SuperCrypt(PaymentGatewayData.CRYPTNUM);
            paymentGatewayHashMap.put(UserData.USERNAME.ToString(), superCrypt.encrypt(this.userName));
            paymentGatewayHashMap.put(UserData.PASSWORD.ToString(), superCrypt.encrypt(this.password));
        } else {
            paymentGatewayHashMap.put(UserData.USERNAME.ToString(), this.userName);
            paymentGatewayHashMap.put(UserData.PASSWORD.ToString(), this.password);
        }
        paymentGatewayHashMap.put(PaymentGatewayData.TIMEOUT.ToString(), this.timeout);
        paymentGatewayHashMap.put(PaymentGatewayData.PROXYPROTOCOL.ToString(), this.proxyProtocol);
        paymentGatewayHashMap.put(PaymentGatewayData.PROXYSERVER.ToString(), this.proxyServer);
        paymentGatewayHashMap.put(PaymentGatewayData.PROXYPORT.ToString(), this.proxyPort);
        paymentGatewayHashMap.put(PaymentGatewayData.PROXYPATH.ToString(), this.proxyPath);
        paymentGatewayHashMap.put(PaymentGatewayData.PROXYUSERNAME.ToString(), this.proxyUserName);
        paymentGatewayHashMap.put(PaymentGatewayData.PROXYPASSWORD.ToString(), this.proxyPassword);
        paymentGatewayHashMap.put(PaymentGatewayData.PROXYTIMEOUT.ToString(), this.proxyTimeout);
        if (isEncrypted) {
            SuperCrypt superCrypt = new SuperCrypt(PaymentGatewayData.CRYPTNUM);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL1.ToString(), superCrypt.encrypt(this.special1));
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL2.ToString(), superCrypt.encrypt(this.special2));
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL3.ToString(), superCrypt.encrypt(this.special3));
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL4.ToString(), superCrypt.encrypt(this.special4));
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL5.ToString(), superCrypt.encrypt(this.special5));
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL6.ToString(), superCrypt.encrypt(this.special6));
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL7.ToString(), superCrypt.encrypt(this.special7));
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL8.ToString(), superCrypt.encrypt(this.special8));
        } else {
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL1.ToString(), this.special1);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL2.ToString(), this.special2);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL3.ToString(), this.special3);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL4.ToString(), this.special4);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL5.ToString(), this.special5);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL6.ToString(), this.special6);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL7.ToString(), this.special7);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL8.ToString(), this.special8);
            paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL9.ToString(), this.special9);
        }
        paymentGatewayHashMap.put(EntryData.getInstance().LASTMODIFIED.ToString(), this.lastModified);
        return paymentGatewayHashMap;
    }

    public virtual BasicArrayList toVector()
    {
        return this.toVector(true);
    }

    public virtual BasicArrayList toVector(bool isEncrypted)
    {
        BasicArrayList updateVector = new BasicArrayListD();
        updateVector.add(this.enable);
        updateVector.add(this.storeName);
        updateVector.add(this.getName());
        updateVector.add(this.paymentMethod);
        updateVector.add(this.mode);
        updateVector.add(this.testProtocol);
        updateVector.add(this.testServer);
        updateVector.add(this.testPort);
        updateVector.add(this.testPath);
        updateVector.add(this.serverProtocol);
        updateVector.add(this.server);
        updateVector.add(this.serverPort);
        updateVector.add(this.serverPath);
        if (isEncrypted) {
            SuperCrypt superCrypt = new SuperCrypt(PaymentGatewayData.CRYPTNUM);
            updateVector.add(superCrypt.encrypt(this.userName));
            updateVector.add(superCrypt.encrypt(this.password));
        } else {
            updateVector.add(this.userName);
            updateVector.add(this.password);
        }
        updateVector.add(this.timeout);
        updateVector.add(this.proxyProtocol);
        updateVector.add(this.proxyServer);
        updateVector.add(this.proxyPort);
        updateVector.add(this.proxyPath);
        updateVector.add(this.proxyUserName);
        updateVector.add(this.proxyPassword);
        updateVector.add(this.proxyTimeout);
        if (isEncrypted) {
            SuperCrypt superCrypt = new SuperCrypt(PaymentGatewayData.CRYPTNUM);
            updateVector.add(superCrypt.encrypt(this.special1));
            updateVector.add(superCrypt.encrypt(this.special2));
            updateVector.add(superCrypt.encrypt(this.special3));
            updateVector.add(superCrypt.encrypt(this.special4));
            updateVector.add(superCrypt.encrypt(this.special5));
            updateVector.add(superCrypt.encrypt(this.special6));
            updateVector.add(superCrypt.encrypt(this.special7));
            updateVector.add(superCrypt.encrypt(this.special8));
            updateVector.add(superCrypt.encrypt(this.special9));
        } else {
            updateVector.add(this.special1);
            updateVector.add(this.special2);
            updateVector.add(this.special3);
            updateVector.add(this.special4);
            updateVector.add(this.special5);
            updateVector.add(this.special6);
            updateVector.add(this.special7);
            updateVector.add(this.special8);
            updateVector.add(this.special9);
        }
        return updateVector;
    }

    // throws Exception
    public virtual object getKey()
    {
        return ((object) new PaymentGatewayPrimaryKey(this.getStoreName(), this.getName()));
    }

}

