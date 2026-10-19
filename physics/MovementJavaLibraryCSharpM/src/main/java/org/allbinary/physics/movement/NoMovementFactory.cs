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

namespace org.allbinary.physics.movement;

public class NoMovementFactory
{
    private static readonly NoMovementFactory instance = new NoMovementFactory();
    public static NoMovementFactory getInstance()
    {
        return NoMovementFactory.instance;
    }

    private readonly Movement movement = new Movement();
    public Movement getMovmentInstance()
    {
        return this.movement;
    }

}

