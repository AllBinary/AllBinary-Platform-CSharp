/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using InitUpdatePaintable = org.allbinary.graphics.paint.InitUpdatePaintable;
using NullInitUpdatePaintable = org.allbinary.graphics.paint.NullInitUpdatePaintable;

namespace org.allbinary.game.layer;

public class RTSLayerInfoPaintable : InitUpdatePaintable
{
    private InitUpdatePaintable initUpdatePaintable = NullInitUpdatePaintable.getInstance();
    public RTSLayerInfoPaintable()
    {
    }

    public override void update()
    {
        this.initUpdatePaintable.update();
    }

    public override void paint(Graphics graphics)
    {
        this.initUpdatePaintable.paint(graphics);
    }

    public virtual void updateRTSLayerInfoInit(InitUpdatePaintable hudPaintable)
    {
        this.initUpdatePaintable = hudPaintable;
    }

    public virtual void updateRTSLayerInfoSelection(SelectionHudPaintable hudPaintable)
    {
        hudPaintable.updateSelectionInfo();
        this.initUpdatePaintable = hudPaintable;
    }

}

