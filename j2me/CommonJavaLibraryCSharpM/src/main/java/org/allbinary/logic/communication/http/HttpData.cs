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
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.communication.http;

public class HttpData
{
    private static readonly HttpData instance = new HttpData();
    public static HttpData getInstance()
    {
        return HttpData.instance;
    }

    public readonly string EQUALS;
    public readonly string PARAM_SEP;
    public readonly string URL_PARAM_SEP;
    public readonly string URL_LABEL = "Url: ";
    private HttpData()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        this.EQUALS = commonSeps.EQUALS;
        this.PARAM_SEP = commonSeps.AMPERSAND;
        this.URL_PARAM_SEP = commonSeps.QUESTION;
    }

}

