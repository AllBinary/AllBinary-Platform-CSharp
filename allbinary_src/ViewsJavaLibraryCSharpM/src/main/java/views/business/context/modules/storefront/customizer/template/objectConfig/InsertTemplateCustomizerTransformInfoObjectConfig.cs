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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoDomNodeView = org.allbinary.logic.visual.transform.info.TransformInfoDomNodeView;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfosData = org.allbinary.logic.visual.transform.info.TransformInfosData;
using TransformInfoObjectConfigData = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigData;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace views.business.context.modules.storefront.customizer.template.objectConfig;

public class InsertTemplateCustomizerTransformInfoObjectConfig : NoTemplateTransformInfoObjectConfig
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public InsertTemplateCustomizerTransformInfoObjectConfig(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public InsertTemplateCustomizerTransformInfoObjectConfig(TransformInfoInterface transformInfoInterface, Document document) : base(transformInfoInterface, document)
    {
        // base(transformInfoInterface, document) is called from the constructor declaration
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    public InsertTemplateCustomizerTransformInfoObjectConfig(TransformInfoInterface transformInfoInterface, string name, string type) : base(transformInfoInterface, name, type)
    {
        // base(transformInfoInterface, name, type) is called from the constructor declaration
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    // throws Exception
    public virtual void set(string aParentViewName)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Setting: " + aParentViewName, this, "set()");
        }
        Document document = this.toXmlDoc();
        NodeList parentComponentsNodeList = document.getElementsByTagName(TransformInfosData.getInstance().NAME);
        if (parentComponentsNodeList != null && parentComponentsNodeList.getLength() > 0) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Replacing", this, "set()");
            }
            Node componentNode = parentComponentsNodeList.item(0).getChildNodes().item(0);
            if (componentNode != null) {
                document.removeChild(componentNode);
            }
            parentComponentsNodeList.item(0).appendChild(new TransformInfoDomNodeView(aParentViewName).toXmlNode(document));
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Setting", this, "set()");
            }
            Node objectConfigNode = document.getElementsByTagName(TransformInfoObjectConfigData.getInstance().NAME).item(0);
            Node parentComponentsNode = document.createElement(TransformInfosData.getInstance().NAME);
            objectConfigNode.appendChild(parentComponentsNode);
            TransformInfoDomNodeView transformInfoDomNodeView = new TransformInfoDomNodeView(aParentViewName);
            parentComponentsNode.appendChild(transformInfoDomNodeView.toXmlNode(document));
        }
    }

}

