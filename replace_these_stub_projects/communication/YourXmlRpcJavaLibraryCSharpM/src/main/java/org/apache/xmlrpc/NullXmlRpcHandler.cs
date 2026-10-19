/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.apache.xmlrpc;

public class NullXmlRpcHandler : XmlRpcHandler
{
    public static readonly NullXmlRpcHandler NULL_XML_RPC_HANDLER = new NullXmlRpcHandler();
    // throws Exception
    public virtual object execute(string method, BasicArrayList @params)
    {
        return NullUtil.getInstance().NULL_OBJECT;
    }

}

