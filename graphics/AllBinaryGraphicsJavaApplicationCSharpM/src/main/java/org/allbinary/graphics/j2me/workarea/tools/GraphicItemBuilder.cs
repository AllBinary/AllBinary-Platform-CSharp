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
using Node = org.w3c.dom.Node;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class GraphicItemBuilder
{
    private GraphicItemBuilder()
    {
    }

    // throws Exception
    public static GraphicItemInterface getInstance(Node node)
    {
        string graphicItemName = node.getNodeName();
        if (string.CompareOrdinal(graphicItemName, PointsDomUtil.getInstance().LINES) == 0) {
            return new LinesGraphicItem(node);
        } else {
            throw new Exception("Graphic Item Does Not Exist: " + graphicItemName);
        }
    }

}

