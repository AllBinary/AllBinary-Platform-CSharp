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
//using Set = java.util.Set;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using ToDomHelper = org.allbinary.data.tree.dom.ToDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.control.search;

public class SearchParams
{
    private HashMap columnsAndSearchValues;
    private string order = null;
    private string sortBy = null;
    private string listLength = null;
    private string startPage = null;
    private string endPage = null;
    public SearchParams(HttpServletRequest request)
    {
        this.columnsAndSearchValues = StdUtil.getInstance().createHashMap();
        this.setLength(request.getParameter(SearchData.LENGTH));
        this.setOrder(request.getParameter(SearchData.ORDER));
        string page = request.getParameter(SearchData.PAGE);
        this.setStartPage(page);
        this.setEndPage(page);
        this.setSortBy(request.getParameter(SearchData.SORTBY));
        int index = 0;
        string columnName = request.getParameter(SearchData.COLUMNNAME + "[0]");
        string columnValue = request.getParameter(SearchData.COLUMNVALUE + "[0]");
        while (columnName != null) {
            this.add(columnName, columnValue);
            index++;
            columnName = request.getParameter(SearchData.COLUMNNAME + "[" + index + "]");
            columnValue = request.getParameter(SearchData.COLUMNVALUE + "[" + index + "]");
        }
    }

    public virtual void add(string column, string value)
    {
        this.columnsAndSearchValues.put(column, value);
    }

    public virtual void setOrder(string value)
    {
        this.order = value;
    }

    public virtual void setSortBy(string value)
    {
        this.sortBy = value;
    }

    public virtual void setLength(string value)
    {
        this.listLength = value;
    }

    public virtual void setStartPage(string value)
    {
        this.startPage = value;
    }

    public virtual void setEndPage(string value)
    {
        this.endPage = value;
    }

    public virtual HashMap get()
    {
        return this.columnsAndSearchValues;
    }

    public virtual string getOrder()
    {
        return this.order;
    }

    public virtual string getSortBy()
    {
        return this.sortBy;
    }

    public virtual string getLength()
    {
        return this.listLength;
    }

    public virtual int? getLengthInt()
    {
        if (this.listLength != null) {
            return this.listLength;
        } else {
            return 0;
        }
    }

    public virtual string getStartPage()
    {
        return this.startPage;
    }

    public virtual string getEndPage()
    {
        return this.endPage;
    }

    public virtual int? getStartPageInt()
    {
        if (this.startPage != null) {
            return this.startPage;
        } else {
            return 0;
        }
    }

    public virtual int? getEndPageInt()
    {
        if (this.endPage != null) {
            return this.endPage;
        } else {
            return 0;
        }
    }

    // throws Exception
    public virtual Node getParamsNode(Document document)
    {
        Node paramsNode = ModDomHelper.createNameValueNodes(document, SearchData.PARAMS, SearchData.PARAMS);
        paramsNode.appendChild(this.getFieldsNode(document));
        paramsNode.appendChild(this.getOrderNode(document));
        paramsNode.appendChild(this.getSortByNode(document));
        paramsNode.appendChild(this.getLengthNode(document));
        return paramsNode;
    }

    // throws Exception
    private Node getFieldsNode(Document document)
    {
        Node fieldsNode = ModDomHelper.createNameValueNodes(document, SearchData.FIELDS, this.columnsAndSearchValues.size().ToString());
        Set set = this.columnsAndSearchValues.keySet();
        object[] searchValueArray = set.toArray();
        int size = searchValueArray.Length;
        for (int index = 0; index < size; index++) {
            string key = ((string) searchValueArray[index]);
            string searchValue = ((string) this.columnsAndSearchValues.get(key));
            fieldsNode.appendChild(ModDomHelper.createNameValueNodes(document, SearchData.FIELD, key, ToDomHelper.convertNull(searchValue)));
        }
        return fieldsNode;
    }

    // throws Exception
    private Node getOrderNode(Document document)
    {
        return ModDomHelper.createNameValueNodes(document, SearchData.ORDER, ToDomHelper.convertNull(this.getOrder()));
    }

    // throws Exception
    private Node getSortByNode(Document document)
    {
        return ModDomHelper.createNameValueNodes(document, SearchData.SORTBY, ToDomHelper.convertNull(this.getSortBy()));
    }

    // throws Exception
    private Node getLengthNode(Document document)
    {
        return ModDomHelper.createNameValueNodes(document, SearchData.LENGTH, ToDomHelper.convertNull(this.getLength()));
    }

}

