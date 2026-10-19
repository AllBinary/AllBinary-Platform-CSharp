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

namespace org.allbinary.view;

public class StaticViewPosition : ViewPosition
{
    public StaticViewPosition(int x, int y, int z) : base(x, y, z)
    {
        // base(x, y, z) is called from the constructor declaration
    }

    public override int getX()
    {
        return this.getRawX();
    }

    public override int getY()
    {
        return this.getRawY();
    }

    public override int getZ()
    {
        return this.getRawZ();
    }

}

