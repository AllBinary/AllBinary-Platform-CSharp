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
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.control.search;

public class TableSearchRequest
{
    private string xslFile;
    private string pageName;
    private string contentType;
    private string keywords;
    private SearchParams searchParams;
    public TableSearchRequest(string keywords, SearchParams searchParams, string xslFile, string contentType)
    {
        this.keywords = keywords;
        this.searchParams = searchParams;
        this.xslFile = xslFile;
        this.pageName = this.pageName;
        this.contentType = contentType;
    }

    public virtual void setKeywords(string value)
    {
        this.keywords = value;
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

    public virtual string getKeywords()
    {
        return this.keywords;
    }

    public virtual SearchParams getParams()
    {
        return this.searchParams;
    }

    // throws Exception
    public virtual string getXslFile()
    {
        string path = URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH + this.xslFile;
        return path;
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

