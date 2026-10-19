// Generated Code Do Not Modify

using System;
using System.Linq;
//using IOException = java.io.IOException;
//using MalformedURLException = java.net.MalformedURLException;
//using URL = java.net.URL;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CryptInterface = org.allbinary.init.crypt.jcehelper.CryptInterface;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.apache.xmlrpc;

public class XmlRpcClient : XmlRpcHandler
{
    private readonly URL url;
    public XmlRpcClient(string url)
    {
        this.url = new URL(url);
    }

    public virtual URL getURL()
    {
        return this.url;
    }

    public virtual void setBasicAuthentication(string user, string password)
    {
    }

    // throws XmlRpcException, IOException
    public virtual object execute(string method, BasicArrayList @params)
    {
        return NullUtil.getInstance().NULL_OBJECT;
    }

    // throws XmlRpcException, IOException
    public virtual object execute(string method, BasicArrayList @params, CryptInterface cryptInterface)
    {
        return NullUtil.getInstance().NULL_OBJECT;
    }

}

