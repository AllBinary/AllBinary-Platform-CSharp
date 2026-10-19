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

namespace org.allbinary.logic.communication.http;

public class AcceptableResponseFactory
{
    private static readonly AcceptableResponseFactory instance = new AcceptableResponseFactory();
    public static AcceptableResponseFactory getInstance()
    {
        return AcceptableResponseFactory.instance;
    }

    public readonly AcceptableResponse HTML = new AcceptableResponse("text/html", "html", 0);
    public readonly AcceptableResponse WML = new AcceptableResponse("text/wml", "wml", 1);
    public readonly AcceptableResponse VXML = new AcceptableResponse("text/vxml", "vxml", 2);
}

