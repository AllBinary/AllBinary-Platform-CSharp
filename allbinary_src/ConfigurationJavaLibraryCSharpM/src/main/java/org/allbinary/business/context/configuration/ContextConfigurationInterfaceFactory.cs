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
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbPath = org.allbinary.logic.io.path.AbPath;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.context.configuration;

public class ContextConfigurationInterfaceFactory
{
    private static readonly ContextConfigurationInterfaceFactory instance = new ContextConfigurationInterfaceFactory();
    public static ContextConfigurationInterfaceFactory getInstance()
    {
        return ContextConfigurationInterfaceFactory.instance;
    }

    private ContextConfigurationInterfaceFactory()
    {
    }

    // throws Exception
    public virtual ContextConfigurationInterface getInstance(Document document)
    {
        ContextConfigurationData contextConfigurationData = ContextConfigurationData.getInstance();
        Node contextConfigurationNode = DomSearchHelper.getNode(contextConfigurationData.NAME, document.getChildNodes());
        return ((ContextConfigurationInterface) new ContextConfigurationView(contextConfigurationNode).getContextConfigurationInterface());
    }

    // throws Exception
    public virtual ContextConfigurationInterface getInstance(string contextName)
    {
        AbPath abPath = ContextConfigurationPathUtil.getAbPath(contextName);
        ContextConfigurationData contextConfigurationData = ContextConfigurationData.getInstance();
        string documentString = new CryptFileReader(contextConfigurationData.UNCRYPTED_EXTENSION, contextConfigurationData.ENCRYPTED_EXTENSION).get(abPath);
        Document document = DomDocumentHelper.create(documentString);
        return this.getInstance(document);
    }

}

