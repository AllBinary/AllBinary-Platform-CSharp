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
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using BasicTransformer = org.allbinary.logic.visual.transform.BasicTransformer;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using TransformDocumentFactory = org.allbinary.logic.visual.transform.data.TransformDocumentFactory;
using TransformDocumentInterface = org.allbinary.logic.visual.transform.data.TransformDocumentInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views;

public class BasicComponentView : TransformInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private TransformDocumentInterface transformDocumentInterface = null;
    private TransformInfoInterface transformInfoInterface = null;
    public BasicComponentView(TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.setTransformInfoInterface(transformInfoInterface);
        this.setTransformDocumentInterface(TransformDocumentFactory.getInstance());
    }

    public int NO_TYPE = 0;
    public virtual int getTypeId()
    {
        return this.NO_TYPE;
    }

    public virtual TransformDocumentInterface getTransformDocumentInterface()
    {
        return this.transformDocumentInterface;
    }

    public virtual void setTransformDocumentInterface(TransformDocumentInterface transformDocumentInterface)
    {
        this.transformDocumentInterface = transformDocumentInterface;
    }

    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return this.transformInfoInterface;
    }

    public virtual void setTransformInfoInterface(TransformInfoInterface transformInfoInterface)
    {
        this.transformInfoInterface = transformInfoInterface;
    }

    public virtual Document toXmlDoc()
    {
        return this.transformDocumentInterface.getDoc();
    }

    // throws Exception
    public virtual Document getDoc()
    {
        Document document = this.getTransformInfoInterface().getDataDocument();
        Node dataNode = this.getTransformDocumentInterface().getDoc().importNode(document.getFirstChild(), true);
        if (dataNode != null) {
            this.getTransformDocumentInterface().getBaseNode().appendChild(dataNode);
        }
        return this.getTransformDocumentInterface().getDoc();
    }

    // throws Exception
    public virtual string view()
    {
        try {
            string success = XmlDocumentHelper.toString(this.getDoc());
            string result = new BasicTransformer(this.abeClientInformation, this.getTransformInfoInterface()).translate(success);
            return result;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

