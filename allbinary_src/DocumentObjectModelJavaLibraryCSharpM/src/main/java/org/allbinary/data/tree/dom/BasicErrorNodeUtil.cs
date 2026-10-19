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
using ErrorData = org.allbinary.business.error.ErrorData;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.data.tree.dom;

public class BasicErrorNodeUtil
{
    private BasicErrorNodeUtil()
    {
    }

    // throws Exception
    public static Node get(Document document, string errorText)
    {
        try {
            Node node = document.createElement(ErrorData.getInstance().NAME);
            node.appendChild(ModDomHelper.createNameValueNodes(document, ErrorData.getInstance().TEXT, errorText));
            return node;
        } catch (Exception e) {
            throw new Exception("Error Node Creation Failure");
        }
    }

}

