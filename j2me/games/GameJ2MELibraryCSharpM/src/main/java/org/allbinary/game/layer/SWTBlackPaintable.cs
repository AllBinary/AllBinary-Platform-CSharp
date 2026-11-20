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

extern alias GameLicensingNullJavaLibraryCSharp;
extern alias OpenGLNoneOtherJavaLibraryCSharp;
using System;
using System.Linq;
using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.game.layer;

public class SWTBlackPaintable : Paintable
{
    private readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    private readonly BasicColor BLACK = BasicColorFactory.getInstance().BLACK;
    public override void paint(Graphics graphics)
    {
        this.basicSetColorUtil.setBasicColorP(graphics, this.BLACK);
    }

}

