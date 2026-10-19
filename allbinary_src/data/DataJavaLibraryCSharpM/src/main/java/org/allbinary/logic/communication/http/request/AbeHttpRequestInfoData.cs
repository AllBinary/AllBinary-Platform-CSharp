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

namespace org.allbinary.logic.communication.http.request;

public class AbeHttpRequestInfoData
{
    private static readonly AbeHttpRequestInfoData instance = new AbeHttpRequestInfoData();
    public static AbeHttpRequestInfoData getInstance()
    {
        return AbeHttpRequestInfoData.instance;
    }

    private AbeHttpRequestInfoData()
    {
    }

    public readonly string HTTP_USER_AGENT = "HTTP_USER_AGENT";
    public readonly string REMOTE_ADDRESS = "REMOTE_ADDRESS";
    public readonly string REMOTE_HOST = "REMOTE_HOST";
    public readonly string REMOTE_HOST_BY_ADDRESS = "REMOTE_HOST_BY_ADDRESS";
    public readonly string REMOTE_PORT = "REMOTE_PORT";
    public readonly string REQUEST_FILE_PATH = "REQUEST_FILE_PATH";
}

