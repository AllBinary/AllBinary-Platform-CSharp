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
//using Calendar = java.util.Calendar;
using java.util;
//using Set = java.util.Set;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using WorkFlowData = org.allbinary.logic.control.workflow.WorkFlowData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.control.workflow.request;

public class BasicWorkFlow
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private Document workFlowDoc;
    private string workFlowName;
    private string storeName;
    public BasicWorkFlow()
    {
        this.workFlowName = StringUtil.getInstance().EMPTY_STRING;
        this.workFlowDoc = DomDocumentHelper.create();
        Node workFlowNode = this.workFlowDoc.createElement(WorkFlowData.getInstance().WORKFLOW);
        this.workFlowDoc.appendChild(workFlowNode);
    }

    public BasicWorkFlow(HashMap hashMap, PageContext pageContext)
    {
        WeblisketSession weblisketSession = new WeblisketSession(hashMap, pageContext);
        this.storeName = weblisketSession.getStoreName();
        HashMap requestHashMap = new RequestParams(pageContext).toHashMap();
        this.workFlowName = ((string) requestHashMap.get(WorkFlowData.getInstance().NAME));
        this.workFlowDoc = DomDocumentHelper.create(((string) requestHashMap.get(WorkFlowData.getInstance().DATA)));
    }

    public BasicWorkFlow(HashMap hashMap)
    {
        this.workFlowName = ((string) hashMap.get(WorkFlowData.getInstance().NAME));
        this.storeName = ((string) hashMap.get(StoreFrontData.getInstance().NAME));
        this.workFlowDoc = DomDocumentHelper.create(((string) hashMap.get(WorkFlowData.getInstance().DATA)));
    }

    public virtual string getName()
    {
        return this.workFlowName;
    }

    public virtual string getStoreName()
    {
        return this.storeName;
    }

    public virtual object getKey()
    {
        return ((object) this.getName());
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        BasicArrayList values = new BasicArrayListD();
        values.add(this.workFlowName);
        values.add(this.storeName);
        values.add(XmlDocumentHelper.toString(this.workFlowDoc));
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        values.add(time);
        values.add(time);
        return values;
    }

    // throws Exception
    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(WorkFlowData.getInstance().NAME, this.workFlowName);
        hashMap.put(StoreFrontData.getInstance().NAME, this.storeName);
        hashMap.put(WorkFlowData.getInstance().DATA, XmlDocumentHelper.toString(this.workFlowDoc));
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        hashMap.put(EntryData.getInstance().LASTMODIFIED, time);
        return hashMap;
    }

    public virtual Node toXmlNode(Document document)
    {
        try {
            HashMap hashMap = this.toHashMap();
            Set keySet = hashMap.keySet();
            Node node = document.createElement(WorkFlowData.getInstance().WORKFLOW);
            object[] nameArray = keySet.toArray();
            int size = nameArray.Length;
            for (int index = 0; index < size; index++) {
                string name = ((string) nameArray[index]);
                string value = ((string) hashMap.get(name));
                node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
            }
            return node;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toXmlNode()", e);
            }
            return null;
        }
    }

    public virtual Document toXmlDoc()
    {
        try {
            return this.workFlowDoc;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toXmlDoc()", e);
            }
            return null;
        }
    }

    public virtual bool? isValid()
    {
        try {
            bool? returnBoolean = true;
            if (this.workFlowName == null) {
                returnBoolean = false;
            }
            return returnBoolean;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to validate", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            if (this.workFlowName == null) {
                stringBuffer.append("No WorkFlow name specified.");
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Getting Validation Info";
        }
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

}

