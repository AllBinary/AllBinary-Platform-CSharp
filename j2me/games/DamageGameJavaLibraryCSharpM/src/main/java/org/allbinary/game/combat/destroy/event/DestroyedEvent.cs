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
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using NullGameCanvas = org.allbinary.game.displayable.canvas.NullGameCanvas;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.combat.destroy.@event;

public class DestroyedEvent : AllBinaryEventObject
{
    private AllBinaryGameCanvas allBinaryGameCanvas = NullGameCanvas.getInstance();
    private AllBinaryLayer allBinaryLayerInterface = AllBinaryLayer.NULL_ALLBINARY_LAYER;
    public DestroyedEvent(AllBinaryGameCanvas combatGameCanvas) : base(DestroyedEventHandler.getInstance())
    {
        // base(DestroyedEventHandler.getInstance()) is called from the constructor declaration
        this.setAllBinaryGameCanvas(combatGameCanvas);
    }

    public virtual AllBinaryGameCanvas getAllBinaryGameCanvas()
    {
        return this.allBinaryGameCanvas;
    }

    public virtual AllBinaryLayer getLayerInterface()
    {
        return this.allBinaryLayerInterface;
    }

    private void setAllBinaryGameCanvas(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        this.allBinaryGameCanvas = allBinaryGameCanvas;
    }

    public virtual void setLayerInterfaceForCircularStaticPool(AllBinaryLayer allBinaryLayerInterface)
    {
        this.allBinaryLayerInterface = allBinaryLayerInterface;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("DestroyedEvent: \n");
        stringBuffer.append("AllBinaryLayerInterface: ");
        stringBuffer.append(this.allBinaryLayerInterface.ToString());
        stringBuffer.append("\nAllBinaryGameCanvas: ");
        stringBuffer.append(StringUtil.getInstance().toString(this.getAllBinaryGameCanvas()));
        return stringBuffer.ToString();
    }

}

