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
using Attr = org.w3c.dom.Attr;
using Document = org.w3c.dom.Document;
using NamedNodeMap = org.w3c.dom.NamedNodeMap;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoDomNodeView : TransformInfoDomNode, DomNodeInterface
{
    public TransformInfoDomNodeView(TransformInfoInterface transformInfoInterface, string mapping) : base(transformInfoInterface, mapping)
    {
        // base(transformInfoInterface, mapping) is called from the constructor declaration
    }

    public TransformInfoDomNodeView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public TransformInfoDomNodeView(string name, string mappedName) : base(name, mappedName)
    {
        // base(name, mappedName) is called from the constructor declaration
    }

    public TransformInfoDomNodeView(string name) : base(name, null)
    {
        // base(name, null) is called from the constructor declaration
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        TransformInfoData transformInfoData = TransformInfoData.getInstance();
        Node subViewNode = document.createElement(transformInfoData.NAME);
        Attr viewNameAttr = document.createAttribute(transformInfoData.NAME);
        viewNameAttr.setValue(this.getTransformInfoInterface().getName());
        NamedNodeMap componentNodeAttributes = subViewNode.getAttributes();
        componentNodeAttributes.setNamedItem(viewNameAttr);
        if (this.getMappedName() != null) {
            Attr mappedNameAttr = document.createAttribute(transformInfoData.MAPPED);
            mappedNameAttr.setValue(this.getMappedName());
            componentNodeAttributes.setNamedItem(mappedNameAttr);
        }
        return subViewNode;
    }

}

