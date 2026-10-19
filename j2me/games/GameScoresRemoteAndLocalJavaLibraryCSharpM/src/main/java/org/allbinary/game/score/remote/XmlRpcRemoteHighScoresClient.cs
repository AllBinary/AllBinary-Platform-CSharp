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
//using IOException = java.io.IOException;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CryptInterface = org.allbinary.init.crypt.jcehelper.CryptInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using XmlRpcAbeClient = org.allbinary.logic.communication.xmlrpc.XmlRpcAbeClient;
using ExceptionUtil = org.allbinary.logic.java.exception.ExceptionUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using org.allbinary.util;
using XmlRpcClient = org.apache.xmlrpc.XmlRpcClient;
using XmlRpcException = org.apache.xmlrpc.XmlRpcException;

namespace org.allbinary.game.score.remote;

public class XmlRpcRemoteHighScoresClient : XmlRpcAbeClient
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string page;
    public XmlRpcRemoteHighScoresClient(AbeClientInformationInterface clientInfo, string page, string remoteMethod) : base(clientInfo, remoteMethod)
    {
        // base(clientInfo, remoteMethod) is called from the constructor declaration
        this.page = page;
        this.setServer(0);
    }

    // throws Exception
    public virtual object get(object anyType, CryptInterface cryptInterface)
    {
        try {
            BasicArrayList param = new BasicArrayListD();
            string serverUrl = getClientInfo().getLicenseServer(this.getServer());
            int index = serverUrl.LastIndexOf('/');
            serverUrl = serverUrl.Substring(0, (index + 1) - (0)) + this.page;
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(TRYING);
            stringBuffer.appendint(((int) this.getServer()));
            stringBuffer.append(SEP);
            stringBuffer.append(serverUrl);
            this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.GET);
            XmlRpcClient xmlRpcClient = new XmlRpcClient(serverUrl);
            this.setClient(xmlRpcClient);
            xmlRpcClient.setBasicAuthentication(null, null);
            ABHashtable<object, object> hashtable = ((ABHashtable<object, object>) anyType);
            this.logUtil.putF(CLIENT_INFO + hashtable.ToString(), this, this.commonStrings.GET);
            param.add(hashtable);
            object result = xmlRpcClient.execute(this.getRemoteMethod(), param, cryptInterface);
            this.logUtil.putF(RESULT + result.ToString(), this, this.commonStrings.GET);
            isOnline = true;
            return result;
        } catch (IOException e) {
            this.logUtil.put(TRYING_OTHER_SERVERS + ExceptionUtil.getInstance().getStackTrace(e), this, this.commonStrings.GET, e);
            if (!e.Message.startsWith(HOST_NOT_RESOLVED)) {
                return this.tryAnother(anyType);
            } else {
                throw new Exception(HOST_NOT_RESOLVED_MSG);
            }
        } catch (XmlRpcException e) {
            this.logUtil.put(SERVER_REPORTED_ERROR, this, this.commonStrings.GET, e);
            return this.tryAnother(anyType);
        } catch (Exception e) {
            this.logUtil.put(UNKNOWN_ERROR, this, this.commonStrings.GET, e);
            return this.tryAnother(anyType);
        }
    }

}

