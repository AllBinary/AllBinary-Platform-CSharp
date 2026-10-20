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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.communication.http.request;

//Note: if request is destroyed or messed up this will not work. Use fileRequestParams
public class RequestParams
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private Map<object, object> map;
    public RequestParams()
    {
        this.logUtil.putF("New RequestParams Size: 0", this, this.commonStrings.CONSTRUCTOR);
    }

    public RequestParams(HttpServletRequest request)
    {
        this.map = request.getParameterMap();
        this.logUtil.putF("RequestParams Size: " + this.getMap().keySet().size(), this, this.commonStrings.CONSTRUCTOR);
    }

    public RequestParams(PageContext pageContext)
    {
        this.map = pageContext.getRequest().getParameterMap();
        this.logUtil.putF("Request Params Size: " + this.getMap().keySet().size(), this, this.commonStrings.CONSTRUCTOR);
    }

    protected virtual void setMap(Map<object, object> map)
    {
        this.map = map;
    }

    protected virtual Map<object, object> getMap()
    {
        return this.map;
    }

    private readonly string KEY = "Key: ";
    private readonly string VALUE = " Value: ";
    public virtual Node toXmlNode(Document document)
    {
        try {
            Node node = document.createElement(RequestData.REQUEST);
            StringMaker stringBuffer = new StringMaker();
            Set<object> keys = this.map.keySet();
            object[] keyArray = keys.toArray();
            int size = keyArray.Length;
            for (int i = 0; i < size; i++) {
                string key = ((string) keyArray[i]);
                string[] values = ((string[]) this.map.get(key));
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(this.KEY);
                stringBuffer.append(key);
                stringBuffer.append(this.VALUE);
                stringBuffer.append(values[0]);
                this.logUtil.putF(stringBuffer.ToString(), this, "toXmlNode(document)");
                node.appendChild(ModDomHelper.createNameValueNodes(document, RequestData.PARAMETER, new string((key).ToCharArray()), new string((values[0]).ToCharArray())));
            }
            return node;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "toXmlNode(document)", e);
            return null;
        }
    }

    // throws Exception
    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        Set<object> keys = this.map.keySet();
        object[] keyArray = keys.toArray();
        int size = keyArray.Length;
        StringMaker stringBuffer = new StringMaker();
        for (int i = 0; i < size; i++) {
            string key = ((string) keyArray[i]);
            string[] values = ((string[]) this.map.get(key));
            hashMap.put(new string((key).ToCharArray()), new string((values[0]).ToCharArray()));
        }
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append("RequestParams: ");
        stringBuffer.append(this.map.ToString());
        stringBuffer.append("\ntoHashMap: ");
        stringBuffer.append(hashMap.ToString());
        this.logUtil.putF(stringBuffer.ToString(), this, "toHashMap()");
        return hashMap;
    }

}

