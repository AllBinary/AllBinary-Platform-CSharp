/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;

namespace org.allbinary.game.displayable.canvas;

public class BaseMenuBehavior
{
    private static readonly BaseMenuBehavior instance = new BaseMenuBehavior();
    public static BaseMenuBehavior getInstance()
    {
        return BaseMenuBehavior.instance;
    }

    // throws Exception
    public virtual void onDisplayChangeEvent(AllBinaryGameCanvas allBinaryGameCanvas, DisplayChangeEvent displayChangeEvent)
    {
    }

    public virtual void initSpecialPaint(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.setNonBotPaintableP(NullPaintable.getInstance());
    }

    // throws Exception
    public virtual void initMenu(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    // throws Exception
    public virtual void updateMenu(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    // throws Exception
    public virtual void popupMenu(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    public virtual void closeMenu(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

}

