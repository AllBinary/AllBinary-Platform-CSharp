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
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using NullXmlRpcHandler = org.apache.xmlrpc.NullXmlRpcHandler;
using XmlRpcClient = org.apache.xmlrpc.XmlRpcClient;
using XmlRpcHandler = org.apache.xmlrpc.XmlRpcHandler;

namespace org.allbinary.logic.communication.xmlrpc;

public class XmlRpcAbeClient
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string remoteMethod;
    private readonly AbeClientInformationInterface clientInfo;
    private XmlRpcHandler client = NullXmlRpcHandler.NULL_XML_RPC_HANDLER;
    private int server;
    private int start = 0;
    private int maxServers = 0;
    private bool isDone;
    private readonly string START_SERVER = "Start With Server #";
    public readonly string TRYING = "Trying Server #";
    public readonly string SEP = CommonLabels.getInstance().COLON_SEP;
    public readonly string CLIENT_INFO = "Client Info: \n";
    public readonly string RESULT = CommonLabels.getInstance().RESULT_ + CommonSeps.getInstance().NEW_LINE;
    public readonly string INVALID = "License data is Invalid Trying Other Servers";
    public readonly string EXCEPTION_IN_CLIENT = "Exception in client";
    public readonly string SERVER_REPORTED_ERROR = "Server reported error";
    public readonly string UNKNOWN_ERROR = "Unknown License Retrieval Failure";
    public readonly string TRYING_OTHER_SERVERS = "IOException Trying Other Servers";
    public readonly string HOST_NOT_RESOLVED_MSG = "Not Trying Again Since Host Unresolved";
    public readonly string HOST_NOT_RESOLVED = "Host is unresolved";
    public static bool isOnline = true;
    private readonly MyRandomFactory myRandomFactory = MyRandomFactory.getInstance();
    public XmlRpcAbeClient(AbeClientInformationInterface clientInfo, string remoteMethod)
    {
        this.remoteMethod = remoteMethod;
        this.clientInfo = clientInfo;
        if (clientInfo.getNumberOfLicenseServers() > 1) {
            this.maxServers = clientInfo.getNumberOfLicenseServers() - 2;
            this.start = this.myRandomFactory.getAbsoluteNextInt(this.maxServers) + 1;
        } else if (clientInfo.getNumberOfLicenseServers() == 1) {
            this.maxServers = 0;
            this.start = 0;
        }
        this.isDone = false;
        this.server = this.start;
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.START_SERVER);
        stringBuffer.appendint(this.getServer());
        stringBuffer.append(this.SEP);
        stringBuffer.append(clientInfo.getLicenseServer(this.getServer()));
        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.CONSTRUCTOR);
    }

    // throws Exception
    public virtual object get(object anyType)
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, this);
        return NullUtil.getInstance().NULL_OBJECT;
    }

    // throws Exception
    protected virtual object tryAnother(object anyType)
    {
        if (getServer() < getMaxServers()) {
            this.setServer(getServer() + 1);
        } else {
            this.setServer(0);
        }
        if (getServer() != getStart() && !isIsDone()) {
            return this.get(anyType);
        } else {
            this.setIsDone(true);
        }
        throw new Exception("Tried All Servers But Still Failed");
    }

    protected virtual AbeClientInformationInterface getClientInfo()
    {
        return this.clientInfo;
    }

    protected virtual XmlRpcHandler getClient()
    {
        return this.client;
    }

    protected virtual void setClient(XmlRpcClient client)
    {
        this.client = client;
    }

    protected virtual int getServer()
    {
        return this.server;
    }

    protected virtual void setServer(int server)
    {
        this.server = server;
    }

    protected virtual int getStart()
    {
        return this.start;
    }

    protected virtual void setStart(int start)
    {
        this.start = start;
    }

    protected virtual int getMaxServers()
    {
        return this.maxServers;
    }

    protected virtual void setMaxServers(int maxServers)
    {
        this.maxServers = maxServers;
    }

    protected virtual bool isIsDone()
    {
        return this.isDone;
    }

    protected virtual void setIsDone(bool isDone)
    {
        this.isDone = isDone;
    }

    protected virtual string getRemoteMethod()
    {
        return this.remoteMethod;
    }

}

