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
using PickedUpLayerInterfaceFactoryInterface = org.allbinary.game.layer.pickup.PickedUpLayerInterfaceFactoryInterface;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.part;

public class CountedLayersHudPaintable : PaintableInterface, UpdateMyFontInterface
{
    private static int XXStringWidth = 0;
    private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    private readonly PartInterface[] partInterfaceArray;
    private readonly int countedTotalStringColor;
    private readonly int countedPartsBorder;
    private readonly int startIndex;
    private readonly int dropSize;
    private MyFontProcessor myFontProcessor;
    private int height = 0;
    public CountedLayersHudPaintable(PartInterface[] partInterfaceArray, int dropSize, int startIndex, int countedTotalStringColor, int countedPartsBorder)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.partInterfaceArray = partInterfaceArray;
        this.startIndex = startIndex;
        this.countedTotalStringColor = countedTotalStringColor;
        this.countedPartsBorder = countedPartsBorder;
        this.dropSize = dropSize;
    }

    public virtual void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.height = font.getHeight();
        if (this.dropSize > font.getHeight()) {
            this.height = this.dropSize;
        }
        if (CountedLayersHudPaintable.XXStringWidth == 0) {
            string XXString = "XX";
            CountedLayersHudPaintable.XXStringWidth = font.stringWidth(XXString);
        }
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        int lastWidth = this.displayInfoSingleton.getLastWidth();
        int widthEdge = lastWidth - this.dropSize;
        int size = this.partInterfaceArray.Length;
        int count = 0;
        int y = 0;
        CountedLayerInterfaceFactoryPart countedLayerInterfaceFactory = null;
        PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface = null;
        AllBinaryLayer layerInterface = null;
        char[] charArray = null;
        for (int index = this.startIndex; index < size; index++) {
            countedLayerInterfaceFactory = ((CountedLayerInterfaceFactoryPart) this.partInterfaceArray[index]);
            if (countedLayerInterfaceFactory.getTotal() > 0) {
                pickedUpLayerInterfaceFactoryInterface = countedLayerInterfaceFactory.getCountedPickedUpLayerInterfaceFactory();
                layerInterface = pickedUpLayerInterfaceFactoryInterface.getIconLayer();
                y = 40 + (count * this.height);
                layerInterface.setPosition(widthEdge, y, layerInterface.getZP());
                layerInterface.paint(graphics);
                graphics.setColor(this.countedTotalStringColor);
                countedLayerInterfaceFactory.paint(graphics);
                charArray = countedLayerInterfaceFactory.getTotalString();
                graphics.drawChars(charArray, 0, charArray.Length, widthEdge - countedLayerInterfaceFactory.getXOffset(), y, 0);
                count++;
            }
        }
        if (count > 0) {
            graphics.setColor(this.countedPartsBorder);
            graphics.drawRect(lastWidth - (CountedLayersHudPaintable.XXStringWidth + this.dropSize), 40, CountedLayersHudPaintable.XXStringWidth + this.dropSize, (count * this.height) + 3);
        }
    }

    public virtual void paintThreed(Graphics graphics)
    {
    }

}

