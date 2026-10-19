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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using AllBinaryEventObjectFactoryInterface = org.allbinary.logic.util.@event.AllBinaryEventObjectFactoryInterface;

namespace org.allbinary.game.combat.destroy.@event;

public class DestroyEventFactory : AllBinaryEventObjectFactoryInterface
{
    private AllBinaryGameCanvas combatGameCanvas;
    public DestroyEventFactory(AllBinaryGameCanvas combatGameCanvas)
    {
        this.combatGameCanvas = combatGameCanvas;
    }

    public virtual AllBinaryEventObject getInstance()
    {
        return new DestroyedEvent(this.combatGameCanvas);
    }

}

