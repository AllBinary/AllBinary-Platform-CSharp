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
using CellPositionFactory = org.allbinary.graphics.CellPositionFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using Paintable = org.allbinary.graphics.paint.Paintable;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.motion.button;

public class TouchButtonsMappingPaintable : Paintable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public int foregroundColor;
    private Paintable[][] paintableTable = System.Linq.Enumerable.Range(0, 0).Select(_ => new Paintable[0]).ToArray();
    private TouchButtonLocationHelper touchButtonLocationHelper = new TouchButtonLocationHelper();
    public TouchButtonsMappingPaintable(BasicColor basicColor)
    {
        this.foregroundColor = basicColor.intValue();
        this.init();
    }

    private void init()
    {
        try {
            this.paintableTable = this.createPaintableTable();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "updateRectangle", e);
        }
    }

    // throws Exception
    private Paintable[][] createPaintableTable()
    {
        int totalColumns = this.touchButtonLocationHelper.getTotalColumns();
        int totalRows = this.touchButtonLocationHelper.getTotalRows();
        Paintable[][] paintableTable = System.Linq.Enumerable.Range(0, totalColumns).Select(_ => new Paintable[totalRows]).ToArray();
        CellPositionFactory cellPositionFactory = CellPositionFactory.getInstance();
        CommonButtons commonButtons = CommonButtons.getInstance();
        for (int index = totalColumns - 1; index >= 0; index--) {
            for (int rowIndex = totalRows - 1; rowIndex >= 0; rowIndex--) {
                this.paintableTable[index][rowIndex] = TouchButton.createButton(BasicTouchInputFactory.getInstance().NONE, TouchButtonBlankResource.getInstance(), commonButtons.NORMAL_BUTTON, cellPositionFactory.getInstanceColRow(index, rowIndex), this.touchButtonLocationHelper.getColumnsRemainderHalf(), this.touchButtonLocationHelper.getRowsRemainderHalf());
            }
        }
        return paintableTable;
    }

    public override void paint(Graphics graphics)
    {
        int totalColumns = this.touchButtonLocationHelper.getTotalColumns();
        int totalRows = this.touchButtonLocationHelper.getTotalRows();
        for (int index = totalColumns - 1; index >= 0; index--) {
            for (int rowIndex = totalRows - 1; rowIndex >= 0; rowIndex--) {
                this.paintableTable[index][rowIndex].paint(graphics);
            }
        }
    }

}

