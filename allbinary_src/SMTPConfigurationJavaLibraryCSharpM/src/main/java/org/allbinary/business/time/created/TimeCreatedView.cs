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
using EntryData = org.allbinary.business.entry.EntryData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.time.created;

public class TimeCreatedView : DomNodeInterface
{
    private TimeCreated timeCreated = null;
    public TimeCreatedView(TimeCreated timeCreated)
    {
        this.setTimeCreated(timeCreated);
    }

    public TimeCreatedView(Node node)
    {
        this.setTimeCreated(new TimeCreated(DomNodeHelper.getTextNodeValue(node)));
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        return ModDomHelper.createTextNode(document, EntryData.getInstance().TIMECREATED, this.getTimeCreated().ToString());
    }

    public virtual TimeCreated getTimeCreated()
    {
        return this.timeCreated;
    }

    public virtual void setTimeCreated(TimeCreated timeCreated)
    {
        this.timeCreated = timeCreated;
    }

}

