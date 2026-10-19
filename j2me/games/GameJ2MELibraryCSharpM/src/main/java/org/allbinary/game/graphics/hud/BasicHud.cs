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
using J2MEUtil = org.allbinary.J2MEUtil;
using Anchor = org.allbinary.graphics.Anchor;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.graphics.hud;

public class BasicHud : UpdateMyFontInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly CanvasStrings canvasStrings = CanvasStrings.getInstance();
    public readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    private readonly DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
    public readonly MyFontProcessor updateMyFontProcessor;
    public MyFontProcessor myFontProcessor;
    private int location = 0;
    private int direction = 0;
    private int bufferZone = 0;
    private int bufferZoneY = 0;
    private HudGraphicsPosition hudGraphicsPosition = HudGraphicsPosition.NULL_HUD_GRAPHICS_POSITION;
    private int x = 0;
    private int y = 0;
    private BasicColor basicColor = BasicColorFactory.getInstance().BLACK;
    private int color;
    public int updateMaxWidth = 0;
    public int updateMaxHeight = 0;
    public int offsetY = 0;
    public BasicHud(int location, int direction, int bufferZone, BasicColor basicColor)
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.setLocation(location);
        this.setDirection(direction);
        this.setBufferZone(bufferZone);
        this.onDisplayChangeEvent(DisplayInfoSingleton.getInstance().displayChangeEvent);
        this.setBasicColorP(basicColor);
        this.color = ((int) basicColor);
    }

    public virtual void updateMeasurement(Graphics graphics)
    {
        try {
            this.hudGraphicsPosition = this.getHudGraphicsPositionWH(this.displayInfo.getLastWidth(), this.displayInfo.getLastHeight(), this.updateMaxWidth, this.updateMaxHeight);
            this.x = this.hudGraphicsPosition.getPoint().getX();
            this.setY(this.hudGraphicsPosition.getPoint().getY());
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, this.canvasStrings.ON_DISPLAY_CHANGE_EVENT, e);
        }
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual int getLocation()
    {
        return this.location;
    }

    public virtual int getDirection()
    {
        return this.direction;
    }

    // throws Exception
    protected virtual HudGraphicsPosition getHudGraphicsPositionWH(int width, int height, int maxWidth, int maxHeight)
    {
        int x = 0;
        int y = 0;
        int anchor = 0;
        BasicHudFactory basicHudFactory = BasicHudFactory.getInstance();
        if (basicHudFactory.BOTTOMLEFT == this.getLocation()) {
            x = this.bufferZone + 2;
            y = height - maxHeight - this.bufferZone;
            anchor = Graphics.BOTTOM & Graphics.LEFT;
        } else if (basicHudFactory.BOTTOMRIGHT == this.getLocation()) {
            x = width - maxWidth;
            y = height - maxHeight - this.bufferZone;
            anchor = Graphics.BOTTOM & Graphics.RIGHT;
        } else if (basicHudFactory.TOPLEFT == this.getLocation()) {
            x = this.bufferZone + 2;
            y = this.bufferZoneY;
            anchor = Anchor.TOP_LEFT;
        } else if (basicHudFactory.TOPRIGHT == this.getLocation()) {
            x = width - maxWidth;
            y = this.bufferZoneY;
            anchor = Graphics.TOP & Graphics.RIGHT;
        } else if (basicHudFactory.TOPCENTER == this.getLocation()) {
            x = ((width - maxWidth) / 2);
            y = this.bufferZoneY;
            anchor = Graphics.TOP & Graphics.HCENTER;
        } else if (basicHudFactory.BOTTOMCENTER == this.getLocation()) {
            x = ((width - maxWidth) / 2);
            y = height - maxHeight - this.bufferZone;
            anchor = Graphics.BOTTOM & Graphics.HCENTER;
        } else if (basicHudFactory.ABSOLUTE == this.getLocation()) {
            x = maxHeight;
            y = maxWidth;
            anchor = 0;
        }
        return new HudGraphicsPosition(this.getPoint(x, y), anchor);
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public virtual void onDisplayChangeEvent(DisplayChangeEvent displayChangeEvent)
    {
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    protected virtual GPoint getPoint(int x, int y)
    {
        return PointFactory.getInstance().createXY(x, y);
    }

    public virtual int getBufferZone()
    {
        return this.bufferZone;
    }

    public virtual void setBufferZone(int bufferZone)
    {
        this.bufferZone = bufferZone;
        if (J2MEUtil.isHTML()) {
            this.bufferZoneY = this.bufferZone;
        } else {
            this.bufferZoneY = this.bufferZone + 5;
        }
    }

    public virtual void setLocation(int location)
    {
        this.location = location;
    }

    public virtual void setDirection(int direction)
    {
        this.direction = direction;
    }

    protected virtual HudGraphicsPosition getHudGraphicsPosition()
    {
        return this.hudGraphicsPosition;
    }

    public virtual int getColor()
    {
        return this.color;
    }

    public virtual int getX()
    {
        return this.x;
    }

    public virtual void setX(int x)
    {
        this.x = x;
    }

    public virtual void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
    }

    public virtual BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

    protected virtual void setY(int y)
    {
        this.y = y;
    }

    protected virtual int getY()
    {
        return this.y;
    }

    public virtual void paintSSO(Graphics graphics, string @string, string string2, int offset)
    {
        this.myFontProcessor.process(graphics);
        this.basicSetColorUtil.setBasicColorP(graphics, this.getBasicColorP());
        graphics.drawString(@string, this.x, this.getY(), this.hudGraphicsPosition.getAnchor());
        graphics.drawString(string2, this.x + offset, this.getY(), this.hudGraphicsPosition.getAnchor());
    }

    public virtual void paintSSOO(Graphics graphics, string @string, string string2, int offset, int offset2)
    {
        this.myFontProcessor.process(graphics);
        graphics.setColor(this.getColor());
        graphics.drawString(@string, this.x + offset, this.getY(), this.hudGraphicsPosition.getAnchor());
        graphics.drawString(string2, this.x + offset2, this.getY(), this.hudGraphicsPosition.getAnchor());
    }

    public virtual void paintDXY(Graphics graphics, char[] charArray, int offset, int len, char[] charArray2, int offset2, int len2, int xOffset, int xOffset2)
    {
        this.myFontProcessor.process(graphics);
        this.basicSetColorUtil.setBasicColorP(graphics, this.getBasicColorP());
        int y = this.getY();
        graphics.drawChars(charArray, offset, len, this.x + xOffset, y, this.hudGraphicsPosition.getAnchor());
        graphics.drawChars(charArray2, offset2, len2, this.x + xOffset2, y, this.hudGraphicsPosition.getAnchor());
    }

    public virtual void paintDX(Graphics graphics, char[] charArray, int offset, int len, char[] charArray2, int offset2, int len2, int xOffset)
    {
        this.myFontProcessor.process(graphics);
        this.basicSetColorUtil.setBasicColorP(graphics, this.getBasicColorP());
        int y = this.getY();
        graphics.drawChars(charArray, offset, len, this.x, y, this.hudGraphicsPosition.getAnchor());
        graphics.drawChars(charArray2, offset2, len2, this.x + xOffset, y, this.hudGraphicsPosition.getAnchor());
    }

    public virtual void paintOffsetAndLength(Graphics graphics, char[] charArray, int offset, int len)
    {
        this.myFontProcessor.process(graphics);
        this.basicSetColorUtil.setBasicColorP(graphics, this.getBasicColorP());
        int y = this.getY();
        graphics.drawChars(charArray, offset, len, this.x, y, this.hudGraphicsPosition.getAnchor());
    }

    public virtual void paintString(Graphics graphics, string @string)
    {
        this.myFontProcessor.process(graphics);
        this.basicSetColorUtil.setBasicColorP(graphics, this.getBasicColorP());
        int y = this.getY() + this.offsetY;
        graphics.drawString(@string, this.x, y, this.hudGraphicsPosition.getAnchor());
    }

}

