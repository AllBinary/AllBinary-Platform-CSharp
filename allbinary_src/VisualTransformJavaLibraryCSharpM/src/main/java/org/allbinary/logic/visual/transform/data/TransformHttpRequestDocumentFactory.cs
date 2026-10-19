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

namespace org.allbinary.logic.visual.transform.data;

public class TransformHttpRequestDocumentFactory
{
    private TransformHttpRequestDocumentFactory()
    {
    }

    // throws Exception
    public static TransformDocumentInterface getInstance(PageContext pageContext, WeblisketSession weblisketSession)
    {
        return ((TransformDocumentInterface) new TransformHttpRequestDocument(pageContext, weblisketSession));
    }

}

