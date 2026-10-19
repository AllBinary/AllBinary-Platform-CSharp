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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoInterfaceView : DomNodeInterface
{
    private TransformInfoInterface transformInfoInterface;
    public TransformInfoInterfaceView(TransformInfoInterface transformInfoInterface)
    {
        this.transformInfoInterface = transformInfoInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        return ModDomHelper.createNameValueNodes(document, TransformInfoData.getInstance().NAME, this.transformInfoInterface.toHashMap());
    }

}

