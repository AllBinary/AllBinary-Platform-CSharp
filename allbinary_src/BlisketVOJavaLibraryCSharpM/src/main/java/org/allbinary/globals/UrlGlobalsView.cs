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
using java.util;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.globals;

public class UrlGlobalsView : DomNodeInterface
{
    public UrlGlobalsView()
    {
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(UrlGlobalsData.WEBAPPPATH, org.allbinary.globals.URLGLOBALS.getWebappPath());
        Node node = ModDomHelper.createNameValueNodes(document, UrlGlobalsData.NAME, hashMap);
        return node;
    }

}

