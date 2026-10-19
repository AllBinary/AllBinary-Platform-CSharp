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
//using PageContext = javax.servlet.jsp.PageContext;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;

namespace org.allbinary.logic.visual.transform.data;

public class TransformStoreDocumentFactory
{
    private TransformStoreDocumentFactory()
    {
    }

    // throws Exception
    public static TransformDocumentInterface getInstance(PageContext pageContext, WeblisketSession weblisketSession)
    {
        return ((TransformDocumentInterface) new TransformStoreDocument(pageContext, weblisketSession));
    }

    // throws Exception
    public static TransformDocumentInterface getInstance(SearchRequest searchRequest)
    {
        return ((TransformDocumentInterface) new TransformStoreDocument(searchRequest));
    }

}

