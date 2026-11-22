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
using CssProperty = org.allbinary.logic.visual.dhtml.style.css.property.CssProperty;
using CssPropertyView = org.allbinary.logic.visual.dhtml.style.css.property.CssPropertyView;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.dhtml.style.css.property.font;

public class FontFamilyView : CssPropertyView
{
    public FontFamilyView() : base(new CssProperty(FontFamilyData.getInstance().VALUE))
    {
        // Constructor invocation emitted in the initializer.
    }

    public FontFamilyView(Node node) : base(new CssProperty(node))
    {
        // Constructor invocation emitted in the initializer.
    }

}

