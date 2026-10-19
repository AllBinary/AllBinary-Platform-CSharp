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
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using BasicTransformer = org.allbinary.logic.visual.transform.BasicTransformer;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using TransformDocumentInterface = org.allbinary.logic.visual.transform.data.TransformDocumentInterface;
using TransformHttpRequestDocumentFactory = org.allbinary.logic.visual.transform.data.TransformHttpRequestDocumentFactory;
using TransformInfoHttpComposite = org.allbinary.logic.visual.transform.info.TransformInfoHttpComposite;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views;

public class HttpComponentView : TransformInfoHttpComposite, TransformInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private BasicArrayList domNodeInterfaceVector;
    private TransformDocumentInterface transformDocumentInterface = null;
    public HttpComponentView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.domNodeInterfaceVector = new BasicArrayListD();
        this.setTransformDocumentInterface(TransformHttpRequestDocumentFactory.getInstance(this.getPageContext(), this.getWeblisketSession()));
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

    public virtual void addDomNodeInterface(DomNodeInterface domNodeInterface)
    {
        this.domNodeInterfaceVector.add(domNodeInterface);
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        try {
            int size = this.domNodeInterfaceVector.size();
            for (int index = 0; index < size; index++) {
                DomNodeInterface domNodeInterface = ((DomNodeInterface) this.domNodeInterfaceVector.get(index));
                this.transformDocumentInterface.getBaseNode().appendChild(domNodeInterface.toXmlNode(this.transformDocumentInterface.getDoc()));
            }
            return this.getTransformDocumentInterface().getDoc();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toXmlDoc()", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual Document getDoc()
    {
        Document document = this.getTransformInfoInterface().getDataDocument();
        Node node = DomNodeHelper.getFirstChildElement(document);
        if (node != null) {
            Node dataNode = this.getTransformDocumentInterface().getDoc().importNode(node, true);
            if (dataNode != null) {
                this.getTransformDocumentInterface().getBaseNode().appendChild(dataNode);
            }
        }
        return this.getTransformDocumentInterface().getDoc();
    }

    // throws Exception
    public virtual string view()
    {
        try {
            this.toXmlDoc();
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

