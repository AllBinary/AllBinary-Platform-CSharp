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

namespace org.allbinary.game.displayable.canvas;

public class InGameMenuBehavior : BaseMenuBehavior
{
    private static readonly InGameMenuBehavior instanceC = new InGameMenuBehavior();
    public static InGameMenuBehavior getInstance()
    {
        return InGameMenuBehavior.instanceC;
    }

    // throws Exception
    public override void onDisplayChangeEvent(AllBinaryGameCanvas allBinaryGameCanvas, DisplayChangeEvent displayChangeEvent)
    {
        allBinaryGameCanvas.updateMenuFromEvent(displayChangeEvent);
    }

    public override void initSpecialPaint(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.setNonBotPaintableP(new GameCanvasNonBotPaintable(allBinaryGameCanvas));
    }

    // throws Exception
    public override void initMenu(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.initMenu2();
    }

    // throws Exception
    public override void updateMenu(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.initMenu2();
    }

    // throws Exception
    public override void popupMenu(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.popupMenu2();
    }

    public override void closeMenu(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.closeMenu2();
    }

}

