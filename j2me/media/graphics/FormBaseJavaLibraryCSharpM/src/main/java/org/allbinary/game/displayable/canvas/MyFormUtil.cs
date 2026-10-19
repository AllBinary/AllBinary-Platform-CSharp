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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using Features = org.allbinary.game.configuration.feature.Features;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using SWTJOGLProcessor = org.allbinary.graphics.threed.SWTJOGLProcessor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class MyFormUtil
{
    private static readonly MyFormUtil instance = new MyFormUtil();
    public static MyFormUtil getInstance()
    {
        return MyFormUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private Rectangle popupMenuRectangle = RectangleFactory.SINGLETON;
    public virtual void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        Features features = Features.getInstance();
        bool isOpenGL = features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL);
        int TOTAL_CHAR_WIDTH = (SWTJOGLProcessor.getInstance().isJOGL() && isOpenGL ? 2 : 3);
        int width = MyFontProcessor.defaultStringWidth(font, TOTAL_CHAR_WIDTH);
        PointFactory pointFactory = PointFactory.getInstance();
        if (displayInfo.getLastHeight() < 320) {
            this.popupMenuRectangle = new Rectangle(pointFactory.createXY(0, 25), width, (font.getHeight() * 4) + 2);
        } else {
            this.popupMenuRectangle = new Rectangle(pointFactory.createXY(0, displayInfo.getLastHalfHeight() - 70), width, (font.getHeight() * 5));
        }
    }

    public virtual Rectangle getPopupMenuRectangle()
    {
        return this.popupMenuRectangle;
    }

}

