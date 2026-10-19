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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.data;

public class TransformDocument : TransformDocumentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private Node baseNode = null;
    private Document document = null;
    public TransformDocument()
    {
        try {
            this.document = DomDocumentHelper.create();
            Node allbinaryNode = this.document.createElement("allbinary");
            this.baseNode = allbinaryNode;
            this.document.appendChild(this.baseNode);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.putF(this.log(), this, this.commonStrings.CONSTRUCTOR);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
            }
            throw e;
        }
    }

    public virtual Node getBaseNode()
    {
        return this.baseNode;
    }

    public virtual Document getDoc()
    {
        return this.document;
    }

    // throws Exception
    public virtual string log()
    {
        StringMaker stringBuffer = new StringMaker();
        if (this.baseNode != null) {
            stringBuffer.append("BaseNode: ");
            stringBuffer.append(this.baseNode.getNodeName());
        } else {
            stringBuffer.append("Log-Error: BaseNode is Null");
        }
        stringBuffer.append("\nDocument: ");
        stringBuffer.append(XmlDocumentHelper.toString(this.document));
        return stringBuffer.ToString();
    }

}

