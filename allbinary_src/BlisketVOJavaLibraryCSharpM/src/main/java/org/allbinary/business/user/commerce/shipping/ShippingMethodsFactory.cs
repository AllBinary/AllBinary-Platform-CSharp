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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasicWeightShippingModuleView = org.allbinary.business.user.commerce.shipping.modules.BasicWeightShippingModuleView;
using NoShippingModuleView = org.allbinary.business.user.commerce.shipping.modules.NoShippingModuleView;
using ShippingInterface = org.allbinary.business.user.commerce.shipping.modules.ShippingInterface;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoObjectConfigData = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigData;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.business.user.commerce.shipping;

public class ShippingMethodsFactory
{
    private ShippingInterface defaultShippingMethodInterface = null;
    private static readonly string SHIPPINGMETHODSFILEPATHSTRING = null;
    static ShippingMethodsFactory()
    {
        StringMaker stringBuffer = new StringMaker();
        string sep = AbPathData.getInstance().SEPARATOR;
        stringBuffer.append(sep);
        stringBuffer.append("generic");
        stringBuffer.append(sep);
        stringBuffer.append("shipping");
        stringBuffer.append(sep);
        SHIPPINGMETHODSFILEPATHSTRING = stringBuffer.ToString();
    }
    private static readonly string SHIPPINGMETHODSFILENAME = "shippingMethods.xml";
    private Document document;
    private BasicArrayList shippingVector;
    public ShippingMethodsFactory(AbeClientInformationInterface abeClientInformation, StoreFrontInterface storeFrontInterface)
    {
        StringMaker stringBuffer = new StringMaker();
        string sep = AbPathData.getInstance().SEPARATOR;
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
        stringBuffer.append(storeFrontInterface.getName());
        stringBuffer.append(sep);
        stringBuffer.append(ShippingMethodsFactory.SHIPPINGMETHODSFILEPATHSTRING);
        AbPath abPath = ((AbPath) new AbPath(stringBuffer.ToString(), this.SHIPPINGMETHODSFILENAME));
        string data = new CryptFileReader(TransformInfoObjectConfigData.getInstance().UNCRYPTED_EXTENSION, TransformInfoObjectConfigData.getInstance().ENCRYPTED_EXTENSION).get(abPath);
        this.document = DomDocumentHelper.create(data);
        this.shippingVector = new BasicArrayListD();
        NodeList nodeList = this.document.getElementsByTagName(ShippingMethodsData.NAME);
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node node = nodeList.item(index);
            NodeList shippingMethodNodeChildren = node.getChildNodes();
            Node shippingMethodNameNode = DomSearchHelper.getNode(ShippingMethodData.NAME, shippingMethodNodeChildren);
            Node classNameNode = DomSearchHelper.getNode(DynamicObjectData.NAME, shippingMethodNameNode.getChildNodes());
            string shippingMethodClassName = DomNodeHelper.getTextNodeValue(classNameNode);
            ShippingInterface shippingMethodInterface = ((ShippingInterface) AbeFactory.getInstance().getInstance(abeClientInformation, shippingMethodClassName));
            this.shippingVector.add(shippingMethodInterface);
            Node defaultShippingMethodNameNode = DomSearchHelper.getNode(ShippingMethodData.DEFAULT, shippingMethodNameNode.getChildNodes());
            string defaultShippingMethodNameNodeValue = DomNodeHelper.getTextNodeValue(defaultShippingMethodNameNode);
            if (defaultShippingMethodNameNodeValue != null && string.CompareOrdinal(defaultShippingMethodNameNodeValue, ShippingMethodData.DEFAULT) == 0) {
                this.defaultShippingMethodInterface = shippingMethodInterface;
            }
        }
        if (this.shippingVector.size() < 1) {
            this.defaultShippingMethodInterface = new BasicWeightShippingModuleView();
            this.shippingVector.add(this.defaultShippingMethodInterface);
            this.shippingVector.add(new NoShippingModuleView());
        }
    }

    // throws Exception
    public virtual BasicArrayList getInstance()
    {
        return this.shippingVector;
    }

    public virtual ShippingInterface getDefaultInstance()
    {
        return this.defaultShippingMethodInterface;
    }

}

