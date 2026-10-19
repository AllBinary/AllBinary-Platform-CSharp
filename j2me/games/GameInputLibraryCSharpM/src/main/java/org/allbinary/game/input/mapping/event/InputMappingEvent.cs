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
using InputToGameKeyMapping = org.allbinary.game.input.mapping.InputToGameKeyMapping;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.input.mapping.@event;

public class InputMappingEvent : AllBinaryEventObject
{
    private InputToGameKeyMapping inputToGameKeyMapping = InputToGameKeyMapping.getNullInstance();
    public InputMappingEvent(object anyType) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
    }

    public virtual void setInputToGameKeyMapping(InputToGameKeyMapping inputToGameKeyMapping)
    {
        this.inputToGameKeyMapping = inputToGameKeyMapping;
    }

    public virtual InputToGameKeyMapping getInputToGameKeyMapping()
    {
        return this.inputToGameKeyMapping;
    }

}

