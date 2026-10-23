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
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using Paintable = org.allbinary.graphics.paint.Paintable;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.input.motion.button;

public class TouchButtonsPaintable : Paintable
{
    public readonly BasicColor foregroundBasicColor;
    public readonly int foregroundColor;
    public readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    private readonly TouchButtonFactory touchButtonFactory = TouchButtonFactory.getInstance();
    public TouchButtonsPaintable(BasicColor basicColor)
    {
        this.foregroundBasicColor = basicColor;
        this.foregroundColor = basicColor.intValue();
    }

    public override void paint(Graphics graphics)
    {
        BasicArrayList list = this.touchButtonFactory.getList();
        this.basicSetColorUtil.setBasicColorP3(graphics, this.foregroundBasicColor, this.foregroundColor);
        TouchButton touchButton = null;
        for (int index = list.size(); --index >= 0; ) {
            touchButton = ((TouchButton) list.objectArray[index]);
            touchButton.paint(graphics);
        }
        for (int index = list.size(); --index >= 0; ) {
            touchButton = ((TouchButton) list.objectArray[index]);
            touchButton.paintHint(graphics);
        }
    }

}

