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

namespace org.allbinary.business.quoterequest;

public class QuoteRequestData
{
    private static readonly QuoteRequestData instance = new QuoteRequestData();
    public static QuoteRequestData getInstance()
    {
        return QuoteRequestData.instance;
    }

    private QuoteRequestData()
    {
    }

    public readonly string ID = "QUOTEREQUEST_ID";
    public readonly string PROJECT_INFO = "QUOTEREQUEST_PROJECT_INFO";
    public readonly string CUSTOMER_COMMENTS = "QUOTEREQUEST_CUSTOMER_COMMENTS";
    public readonly string BUDGET = "QUOTEREQUEST_BUDGET";
    public readonly string TIMEFRAME = "QUOTEREQUEST_TIMEFRAME";
    public readonly string COMMENTS = "QUOTEREQUEST_COMMENTS";
}

