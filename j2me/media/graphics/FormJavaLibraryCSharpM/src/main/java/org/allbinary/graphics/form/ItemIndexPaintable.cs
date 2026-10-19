/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
//using Graphics = javax.microedition.lcdui.Graphics;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;

namespace org.allbinary.graphics.form;

public class ItemIndexPaintable
{
    private static readonly ItemIndexPaintable instance = new ItemIndexPaintable();
    public static ItemIndexPaintable getInstance()
    {
        return ItemIndexPaintable.instance;
    }

    // throws Exception
    public virtual int paint(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
    {
        return 0;
    }

}

