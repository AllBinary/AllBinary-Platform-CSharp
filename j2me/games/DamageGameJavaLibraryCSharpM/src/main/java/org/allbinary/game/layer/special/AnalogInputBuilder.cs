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
//using Canvas = javax.microedition.lcdui.Canvas;
using GameInputProcessor = org.allbinary.game.input.GameInputProcessor;

namespace org.allbinary.game.layer.special;

public class AnalogInputBuilder
{
    private static readonly AnalogInputBuilder instance = new AnalogInputBuilder();
    public static AnalogInputBuilder getInstance()
    {
        return AnalogInputBuilder.instance;
    }

    public virtual void disable(GameInputProcessor[] inputProcessorArray, CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer)
    {
        inputProcessorArray[Canvas.UP] = new SpecialUpGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.DOWN] = new SpecialDownGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.RIGHT] = new SpecialRightGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.LEFT] = new SpecialLeftGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.KEY_NUM0] = new Special1GameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.KEY_NUM5] = new Special3GameInputProcessor(collidableDestroyableDamageableLayer);
    }

    public virtual void enable(GameInputProcessor[] inputProcessorArray, CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer)
    {
        inputProcessorArray[Canvas.UP] = new SpecialAnalogUpGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.DOWN] = new SpecialAnalogDownGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.RIGHT] = new SpecialAnalogRightGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.LEFT] = new SpecialAnalogLeftGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.KEY_NUM0] = new SpecialAnalogLeftTriggerGameInputProcessor(collidableDestroyableDamageableLayer);
        inputProcessorArray[Canvas.KEY_NUM5] = new SpecialAnalogRightTriggerGameInputProcessor(collidableDestroyableDamageableLayer);
    }

}

