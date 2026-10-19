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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using NameSpaceRequestParamData = org.allbinary.logic.communication.http.request.NameSpaceRequestParamData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CssElementData = org.allbinary.logic.visual.dhtml.style.css.CssElementData;
using CssElementsValidationFactory = org.allbinary.logic.visual.dhtml.style.css.CssElementsValidationFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.dhtml.style;

public class StylesValidationFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly StylesValidationFactory instance = new StylesValidationFactory();
    public static StylesValidationFactory getInstance()
    {
        return StylesValidationFactory.instance;
    }

    private StylesValidationFactory()
    {
    }

    // throws Exception
    public virtual BasicArrayList getInstance(Document document)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        NodeList nodeList = document.getElementsByTagName(StylesData.getInstance().NAME);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Style Present: " + XmlDocumentHelper.toString(document), this, commonStrings.GET_INSTANCE);
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Styles Present: " + nodeList.getLength(), this, commonStrings.GET_INSTANCE);
        }
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node stylesNode = nodeList.item(index);
            BasicArrayList styleNodeList = DomSearchHelper.getAllNodes(StyleData.getInstance().NAME, stylesNode.getChildNodes());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Number Of Style Nodes Present: " + styleNodeList.size(), this, commonStrings.GET_INSTANCE);
            }
            for (int styleNodesIndex = 0; styleNodesIndex < styleNodeList.size(); styleNodesIndex++) {
                Node styleNode = ((Node) styleNodeList.get(styleNodesIndex));
                BasicArrayList cssElementStyleNodeList = DomSearchHelper.getAllNodes(CssElementData.getInstance().NAME, styleNode.getChildNodes());
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Number Of Element Nodes Present: " + cssElementStyleNodeList.size(), this, commonStrings.GET_INSTANCE);
                }
                return CssElementsValidationFactory.getInstance(cssElementStyleNodeList);
            }
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("No Style Present", this, commonStrings.GET_INSTANCE);
        }
        return new BasicArrayListD();
    }

    // throws Exception
    public static BasicArrayList getInstance(HashMap hashMap)
    {
        Document stylesDocument = ((Document) hashMap.get(NameSpaceRequestParamData.DOCUMENT));
        return StylesValidationFactory.getInstance().getInstance(stylesDocument);
    }

}

