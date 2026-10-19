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
using XmlRpcClient = org.apache.xmlrpc.XmlRpcClient;
using XmlRpcException = org.apache.xmlrpc.XmlRpcException;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using XmlRpcAbeClient = org.allbinary.logic.communication.xmlrpc.XmlRpcAbeClient;
using NoCrypt = org.allbinary.logic.system.security.crypt.jcehelper.NoCrypt;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using org.allbinary.util;

namespace org.allbinary.logic.communication.log;

public class XmlRpcRemoteLogClient : XmlRpcAbeClient
{
    private readonly NoCrypt noCrypt = new NoCrypt();
    public XmlRpcRemoteLogClient(AbeClientInformationInterface clientInfo) : base(clientInfo, "SSLLogServ.logUtil")
    {
        // base(clientInfo, "SSLLogServ.logUtil") is called from the constructor declaration
    }

    // throws Exception
    public virtual object get(object anyType)
    {
        try {
            BasicArrayList param = new BasicArrayListD();
            string serverUrl = getClientInfo().getLicenseServer(this.getServer());
            int index = serverUrl.LastIndexOf("/");
            serverUrl = serverUrl.Substring(0, (index + 1) - (0)) + "logservssl.php";
            XmlRpcClient xmlRpcClient = new XmlRpcClient(serverUrl);
            this.setClient(xmlRpcClient);
            xmlRpcClient.setBasicAuthentication(null, null);
            ABHashtable<object, object> hashtable = ((ABHashtable<object, object>) anyType);
            param.add(hashtable);
            object result = xmlRpcClient.execute(this.getRemoteMethod(), param, this.noCrypt);
            Console.WriteLine(CommonLabels.getInstance().RESULT_ + CommonSeps.getInstance().NEW_LINE + result.ToString());
            return result;
        } catch (IOException e) {
            Console.WriteLine("IOException Trying Other Servers");
            if (!e.Message.startsWith(HOST_NOT_RESOLVED)) {
                return this.tryAnother(anyType);
            } else {
                throw new Exception(HOST_NOT_RESOLVED_MSG);
            }
        } catch (XmlRpcException e) {
            return this.tryAnother(anyType);
        } catch (Exception e) {
            return this.tryAnother(anyType);
        }
    }

}

