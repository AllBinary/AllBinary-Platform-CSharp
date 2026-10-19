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
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.input.automation.module.actions.script.condition.processors.output;

public class BasicProfileActionScriptOutputNode
{
    public BasicProfileActionScriptOutputNode(Node node)
    {
        Node actionNode = DomSearchHelper.getNode(GenericProfileActionScriptOutputData.NAME, node.getChildNodes());
    }

    public BasicProfileActionScriptOutputNode()
    {
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(GenericProfileActionScriptOutputData.NAME);
        return node;
    }

}

