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
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.shipping.modules;

public class BasicWeightShippingModuleView : BasicWeightShippingModule, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public BasicWeightShippingModuleView()
    {
    }

    public virtual bool? isValid()
    {
        return null;
    }

    public virtual org.w3c.dom.Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual org.w3c.dom.Node toValidationInfoNode(org.w3c.dom.Document document)
    {
        return null;
    }

    public virtual string validationInfo()
    {
        return null;
    }

    public virtual org.w3c.dom.Node toXmlNode(org.w3c.dom.Document document)
    {
        try {
            Node shippingMethodNode = document.createElement(ShippingMethodData.NAME);
            shippingMethodNode.appendChild(ModDomHelper.createNameValueNodes(document, ShippingMethodData.NAME, this.getName()));
            shippingMethodNode.appendChild(ModDomHelper.createNameValueNodes(document, ShippingMethodData.DESCRIPTION, this.getDescription()));
            return shippingMethodNode;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toXmlNode", e);
            }
            return null;
        }
    }

    public virtual org.w3c.dom.Document toXmlDoc()
    {
        try {
            Document document = DomDocumentHelper.create();
            return document;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toXmlDoc", e);
            }
            return null;
        }
    }

    public virtual string view()
    {
        try {
            return commonStrings.NOT_IMPLEMENTED;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view", e);
            }
            return null;
        }
    }

}

