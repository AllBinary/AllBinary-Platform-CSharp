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
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using TaxData = org.allbinary.business.user.commerce.money.tax.components.TaxData;
using SimpleStateTaxModule = org.allbinary.business.user.commerce.money.tax.modules.SimpleStateTaxModule;
using TaxModuleInterface = org.allbinary.business.user.commerce.money.tax.modules.TaxModuleInterface;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoObjectConfigData = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigData;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.business.user.commerce.money.tax;

public class TaxFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TaxFactory instance = new TaxFactory();
    public static TaxFactory getInstance()
    {
        return TaxFactory.instance;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string TAXATIONFILENAME = "taxationMethod.xml";
    private TaxFactory()
    {
    }

    // throws Exception
    public virtual TaxModuleInterface getInstance(AbeClientInformationInterface abeClientInformation, StoreFrontInterface storeFrontInterface)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
        stringBuffer.append(storeFrontInterface.getName());
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        stringBuffer.append("generic");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        stringBuffer.append("taxes");
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        AbPath abPath = new AbPath(stringBuffer.ToString(), TAXATIONFILENAME);
        TransformInfoObjectConfigData transformInfoObjectConfigData = TransformInfoObjectConfigData.getInstance();
        string data = new CryptFileReader(transformInfoObjectConfigData.UNCRYPTED_EXTENSION, transformInfoObjectConfigData.ENCRYPTED_EXTENSION).get(abPath);
        Document document = DomDocumentHelper.create(data);
        NodeList taxNameNodeList = document.getElementsByTagName(TaxData.NAME);
        for (int index = 0; index < taxNameNodeList.getLength(); index++) {
            Node node = taxNameNodeList.item(index);
            NodeList nodeList = node.getChildNodes();
            if (nodeList != null) {
                Node classNameNode = DomSearchHelper.getNode(DynamicObjectData.NAME, nodeList);
                if (classNameNode != null) {
                    string className = DomNodeHelper.getTextNodeValue(classNameNode);
                    return ((TaxModuleInterface) AbeFactory.getInstance().getInstance(abeClientInformation, className));
                } else {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAX)) {
                        this.logUtil.putF("Class Node Null", this, this.commonStrings.GET_INSTANCE);
                    }
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAX)) {
                    this.logUtil.putF("Tax Name Node Node Children", this, this.commonStrings.GET_INSTANCE);
                }
            }
        }
        return ((TaxModuleInterface) new SimpleStateTaxModule());
    }

}

