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
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using DomDocumentMappingInterface = org.allbinary.data.tree.dom.document.mapping.DomDocumentMappingInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.context.configuration;

public class ContextConfigurationDomDocumentMapping : DomDocumentMappingInterface
{
    private ContextConfigurationInterface contextConfigurationInterface;
    public ContextConfigurationDomDocumentMapping(ContextConfigurationInterface contextConfigurationInterface)
    {
        this.contextConfigurationInterface = contextConfigurationInterface;
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        Document document = DomDocumentHelper.create();
        Node node = new ContextConfigurationView(this.contextConfigurationInterface).toXmlNode(document);
        document.appendChild(node);
        return document;
    }

    // throws Exception
    public virtual string toDomDocumentString()
    {
        return XmlDocumentHelper.toString(this.toXmlDoc());
    }

}

