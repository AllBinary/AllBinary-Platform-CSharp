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
using EntryData = org.allbinary.business.entry.EntryData;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user;

public class UserDomNode : DomNodeInterface
{
    private TableMappingInterface dataMappingInterface;
    public UserDomNode(TableMappingInterface dataMappingInterface)
    {
        this.dataMappingInterface = dataMappingInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
        HashMap<object, object> hashMap = this.dataMappingInterface.toHashMap();
        hashMap.put(EntryData.getInstance().LASTMODIFIED, EMPTY_STRING);
        hashMap.put(EntryData.getInstance().ENCRYPTION, EMPTY_STRING);
        hashMap.put(UserData.PASSWORD, EMPTY_STRING);
        return ModDomHelper.createNameValueNodes(document, UserData.NAME, hashMap);
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        return null;
    }

    // throws Exception
    public virtual string view()
    {
        return null;
    }

}

