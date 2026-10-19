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
//using PageContext = javax.servlet.jsp.PageContext;
using AbContext = org.allbinary.business.context.AbContext;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.control.search;

public class SearchRequest : AbContext
{
    private string xslFile;
    private string pageName;
    private string contentType;
    private SearchParams searchParams;
    private StoreFrontInterface storeFront;
    public SearchRequest(StoreFrontInterface storeFront, SearchParams searchParams, string xslFile, string contentType, HashMap propertiesHashMap, PageContext pageContext) : base(propertiesHashMap, pageContext)
    {
        // base(propertiesHashMap, pageContext) is called from the constructor declaration
        this.storeFront = storeFront;
        this.searchParams = searchParams;
        this.xslFile = xslFile;
        this.pageName = this.pageName;
        this.contentType = contentType;
    }

    public virtual void setStoreFront(StoreFrontInterface storeFront)
    {
        this.storeFront = storeFront;
    }

    public virtual void setParams(SearchParams searchParams)
    {
        this.searchParams = searchParams;
    }

    public virtual void setXslFile(string value)
    {
        this.xslFile = value;
    }

    public virtual void setFileBaseName(string value)
    {
        this.pageName = value;
    }

    public virtual void setContentType(string value)
    {
        this.contentType = value;
    }

    public virtual StoreFrontInterface getStoreFront()
    {
        return this.storeFront;
    }

    public virtual SearchParams getParams()
    {
        return this.searchParams;
    }

    public virtual string getXslFile()
    {
        return this.xslFile;
    }

    public virtual string getFileBaseName()
    {
        return this.pageName;
    }

    public virtual string getContentType()
    {
        return this.contentType;
    }

    // throws Exception
    public virtual Node getFileBaseNameNode(Document document)
    {
        return ModDomHelper.createNameValueNodes(document, SearchData.FILENAME, this.getFileBaseName());
    }

}

