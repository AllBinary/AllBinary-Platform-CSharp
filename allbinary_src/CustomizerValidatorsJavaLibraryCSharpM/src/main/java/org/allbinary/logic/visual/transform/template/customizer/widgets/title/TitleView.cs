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
using DomData = org.allbinary.data.tree.dom.DomData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.template.customizer.widgets.title;

public class TitleView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private string title;
    private static readonly string NAME = "None";
    public TitleView()
    {
        this.title = TitleView.NAME;
    }

    public TitleView(Node node)
    {
        Node titleTextNode = DomSearchHelper.getNode(TitleData.getInstance().TEXT, node.getChildNodes());
        Node valueNode = DomSearchHelper.getNode(DomData.VALUE, titleTextNode.getChildNodes());
        this.title = DomNodeHelper.getTextNodeValue(valueNode);
        if (StringValidationUtil.getInstance().isEmpty(this.title)) {
            this.title = TitleView.NAME;
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Title: " + this.getTitle(), this, "Consructor()");
        }
    }

    public TitleView(HashMap hashMap)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("HashMap: " + hashMap.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.getFormData(hashMap);
    }

    public virtual string getTitle()
    {
        return this.title;
    }

    public virtual void getFormData(HashMap hashMap)
    {
        this.title = ((string) hashMap.get(TitleData.getInstance().TEXT));
        if (StringValidationUtil.getInstance().isEmpty(this.title)) {
            this.title = TitleView.NAME;
        }
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(TitleData.getInstance().TEXT, this.getTitle());
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap hashMap = this.toHashMap();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("TitleView HashMap: " + hashMap.ToString(), this, "toXmlNode()");
        }
        return ModDomHelper.createNameValueNodes(document, TitleData.getInstance().NAME, hashMap);
    }

}

