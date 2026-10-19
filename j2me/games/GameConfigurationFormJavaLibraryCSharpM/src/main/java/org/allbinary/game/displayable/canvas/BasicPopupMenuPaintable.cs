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
using AndroidUtil = org.allbinary.AndroidUtil;
using J2MEUtil = org.allbinary.J2MEUtil;
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using RectangleFilledAnimation = org.allbinary.animation.vector.RectangleFilledAnimation;
using Features = org.allbinary.game.configuration.feature.Features;
using SWTUtil = org.allbinary.game.layer.SWTUtil;
using GPoint = org.allbinary.graphics.GPoint;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using DrawVerticalStringUtil = org.allbinary.graphics.draw.DrawVerticalStringUtil;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using OpenGLFeatureUtil = org.allbinary.graphics.opengles.OpenGLFeatureUtil;
using Paintable = org.allbinary.graphics.paint.Paintable;
using SWTJOGLProcessor = org.allbinary.graphics.threed.SWTJOGLProcessor;

namespace org.allbinary.game.displayable.canvas;

public class BasicPopupMenuPaintable : Paintable, UpdateMyFontInterface
{
    private static readonly string NAME = "MENU";
    public readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    private readonly DrawVerticalStringUtil drawStringUtil = DrawVerticalStringUtil.getInstance();
    private readonly string label;
    private readonly BasicColor foregroundBasicColor;
    private MyFontProcessor myFontProcessor;
    private Rectangle rectangle;
    private int BORDER = 0;
    private int heightOffset = 0;
    private int offset = 0;
    private Animation animationInterface = null;
    public BasicPopupMenuPaintable(Rectangle rectangle, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.foregroundBasicColor = foregroundBasicColor;
        this.label = BasicPopupMenuPaintable.NAME;
        this.rectangle = rectangle;
        if (J2MEUtil.isJ2ME() || J2MEUtil.isHTML()) {
            this.animationInterface = NullAnimationFactory.getFactoryInstance().getInstance(0);
        } else {
            this.animationInterface = new RectangleFilledAnimation(this.rectangle.getWidth(), this.rectangle.getHeight(), BasicColorFactory.getInstance().TRANSPARENT_GREY);
        }
        this.init(rectangle);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        Features features = Features.getInstance();
        bool isOpenGL = features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL);
        this.drawStringUtil.updateMeasurement(graphics, this.label);
        int BORDER = 0;
        if (J2MEUtil.isHTML() || isOpenGL) {
            BORDER = MyFontProcessor.defaultCharWidth(font) / 2;
        } else if (AndroidUtil.isAndroid() || J2MEUtil.isJ2SE() || SWTUtil.isSWT) {
            BORDER = MyFontProcessor.defaultCharWidth(font);
        } else {
            BORDER = MyFontProcessor.defaultCharWidth(font) * 2;
        }
        this.BORDER = BORDER;
        this.heightOffset = this.rectangle.getHeight() - (font.getHeight() * BasicPopupMenuPaintable.NAME.length());
        if (OpenGLFeatureUtil.getInstance().isAnyThreed()) {
            this.heightOffset -= font.getHeight() + 2;
            if (AndroidUtil.isAndroid()) {
                this.heightOffset = font.getHeight();
            } else {
                this.heightOffset -= font.getHeight() + 2;
            }
        }
        this.offset = (this.heightOffset >> 1) + ((SWTJOGLProcessor.getInstance().isJOGL() ? 4 : 0));
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    // throws Exception
    public virtual void init(Rectangle rectangle)
    {
        this.rectangle = rectangle;
        int width = this.rectangle.getWidth();
        int height = this.rectangle.getHeight();
        if (J2MEUtil.isJ2ME() || J2MEUtil.isHTML()) {
        } else {
            RectangleFilledAnimation rectangleFilledAnimation = ((RectangleFilledAnimation) this.animationInterface);
            rectangleFilledAnimation.setWidth(width);
            rectangleFilledAnimation.setHeight(height);
        }
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        GPoint point = this.rectangle.getPoint();
        int x = point.getX();
        int y = point.getY();
        int width = this.rectangle.getWidth();
        int height = this.rectangle.getHeight();
        this.animationInterface.paintXY(graphics, x, y);
        this.basicSetColorUtil.setBasicColorP(graphics, this.foregroundBasicColor);
        this.drawStringUtil.paintVerticle(graphics, this.label, x + this.BORDER, y + this.offset, 0);
        graphics.drawRect(x, y, width, height);
    }

}

