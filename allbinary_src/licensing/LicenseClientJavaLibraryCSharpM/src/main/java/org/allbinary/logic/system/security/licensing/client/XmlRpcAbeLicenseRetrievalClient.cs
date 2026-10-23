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
using AbeClientLicense = org.allbinary.logic.system.security.licensing.AbeClientLicense;
using AbeLicenseInterface = org.allbinary.logic.system.security.licensing.AbeLicenseInterface;
using CommonLabels = org.allbinary.@string.CommonLabels;
using org.allbinary.util;
using XmlRpcClient = org.apache.xmlrpc.XmlRpcClient;
using XmlRpcException = org.apache.xmlrpc.XmlRpcException;

namespace org.allbinary.logic.system.security.licensing.client;

public class XmlRpcAbeLicenseRetrievalClient : XmlRpcAbeClient
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public XmlRpcAbeLicenseRetrievalClient(AbeClientInformationInterface clientInfo) : base(clientInfo, "LicServ.getLicense")
    {
        // base(clientInfo, "LicServ.getLicense") is called from the constructor declaration
    }

    // throws Exception
    public virtual object get(object anyType, CryptInterface cryptInterface)
    {
        try {
            string server = getClientInfo().getLicenseServer(this.getServer());
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(TRYING);
            stringBuffer.appendint(((int) this.getServer()));
            stringBuffer.append(SEP);
            stringBuffer.append(server);
            this.logUtil.putF(CommonLabels.getInstance().START_LABEL + stringBuffer.ToString(), this, this.commonStrings.GET);
            BasicArrayList param = new BasicArrayListD();
            XmlRpcClient xmlRpcClient = new XmlRpcClient(server);
            this.setClient(xmlRpcClient);
            xmlRpcClient.setBasicAuthentication(null, null);
            ABHashtable<object, object> hashtable = this.getClientInfo().toHashtable();
            this.logUtil.putF(CLIENT_INFO + hashtable.ToString(), this, this.commonStrings.GET);
            param.add(hashtable);
            object result = xmlRpcClient.execute(this.getRemoteMethod(), param, cryptInterface);
            this.logUtil.putF(RESULT + result.ToString(), this, this.commonStrings.GET);
            ABHashtable<object, object> resultHashtable = ((ABHashtable<object, object>) result);
            if (!AbeClientLicense.hasRequiredKeys(resultHashtable)) {
                this.logUtil.putF(INVALID, this, this.commonStrings.GET);
                return this.tryAnother(anyType);
            }
            AbeLicenseInterface abeLicenseInterface = new AbeClientLicense(resultHashtable);
            this.logUtil.putF(this.commonStrings.END + stringBuffer.ToString(), this, this.commonStrings.GET);
            isOnline = true;
            return abeLicenseInterface;
        } catch (IOException e) {
            this.logUtil.put(EXCEPTION_IN_CLIENT, this, this.commonStrings.GET, e);
            this.logUtil.putF(TRYING_OTHER_SERVERS + ExceptionUtil.getInstance().getStackTrace(e), this, this.commonStrings.GET);
            if (!e.Message.StartsWith(HOST_NOT_RESOLVED)) {
                return this.tryAnother(anyType);
            } else {
                isOnline = false;
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

