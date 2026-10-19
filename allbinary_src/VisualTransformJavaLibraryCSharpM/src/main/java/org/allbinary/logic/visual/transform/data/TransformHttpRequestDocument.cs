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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using AcceptableResponseGenerator = org.allbinary.logic.communication.http.AcceptableResponseGenerator;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.data;

public class TransformHttpRequestDocument : TransformDocumentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private Node baseNode = null;
    private Document document = null;
    private static readonly string language = "en";
    private static readonly string local = "US";
    public TransformHttpRequestDocument(PageContext pageContext, WeblisketSession weblisketSession)
    {
        try {
            string contentType = AcceptableResponseGenerator.getInstance().get(((HttpServletRequest) pageContext.getRequest()));
            this.document = DomDocumentHelper.create();
            Node contentTypeNode = this.document.createElement(contentType);
            Node languageTypeNode = this.document.createElement(language);
            Node localTypeNode = this.document.createElement(local);
            this.baseNode = localTypeNode;
            languageTypeNode.appendChild(localTypeNode);
            contentTypeNode.appendChild(languageTypeNode);
            this.document.appendChild(contentTypeNode);
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

    public TransformHttpRequestDocument(SearchRequest searchRequest)
    {
        try {
            string contentType = searchRequest.getContentType();
            this.document = DomDocumentHelper.create();
            Node contentTypeNode = this.document.createElement(contentType);
            Node languageTypeNode = this.document.createElement(language);
            Node localTypeNode = this.document.createElement(local);
            this.baseNode = localTypeNode;
            languageTypeNode.appendChild(localTypeNode);
            contentTypeNode.appendChild(languageTypeNode);
            this.document.appendChild(contentTypeNode);
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

