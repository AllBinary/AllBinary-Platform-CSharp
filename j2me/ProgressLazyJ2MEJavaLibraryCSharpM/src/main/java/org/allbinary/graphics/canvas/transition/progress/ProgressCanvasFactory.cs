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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.graphics.canvas.transition.progress;

public class ProgressCanvasFactory
{
    private static object PROGRESS_FORM_SCREEN = NullUtil.getInstance().NULL_OBJECT;
    public static ProgressCanvas getInstance()
    {
        if (ProgressCanvasFactory.PROGRESS_FORM_SCREEN == NullUtil.getInstance().NULL_OBJECT) {
            ProgressCanvasFactory.PROGRESS_FORM_SCREEN = new LazyProgressCanvas(StringUtil.getInstance().EMPTY_STRING, BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE);
        }
        return ((ProgressCanvas) ProgressCanvasFactory.PROGRESS_FORM_SCREEN);
    }

    public static PaintableInterface getLazyInstance()
    {
        return ProgressCanvasFactory.getInstance();
    }

}

