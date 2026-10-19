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
using Input = org.allbinary.game.input.Input;
using InputFactory = org.allbinary.game.input.InputFactory;

namespace org.allbinary.input.motion.gesture;

public class MotionGestureInput : Input
{
    public MotionGestureInput(int id, string name) : base(id, name)
    {
        // base(id, name) is called from the constructor declaration
        InputFactory inputFactory = InputFactory.getInstance();
        inputFactory.add(this.getId(), this);
    }

}

