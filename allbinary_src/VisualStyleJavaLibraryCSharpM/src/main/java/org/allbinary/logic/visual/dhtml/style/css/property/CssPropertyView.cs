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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.dhtml.style.css.property;

public class CssPropertyView : DomNodeInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private CssProperty cssProperty;
    public CssPropertyView(string name)
    {
        this.cssProperty = new CssProperty(name);
    }

    public CssPropertyView(Node node)
    {
        this.cssProperty = new CssProperty(node);
    }

    public virtual CssProperty getProperty()
    {
        return this.cssProperty;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        return this.cssProperty.toXmlNode(document);
    }

}

