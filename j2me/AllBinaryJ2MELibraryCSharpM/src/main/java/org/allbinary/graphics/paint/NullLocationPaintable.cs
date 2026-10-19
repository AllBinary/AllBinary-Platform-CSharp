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

namespace org.allbinary.graphics.paint;

public class NullLocationPaintable : LocationPaintable
{
    private static readonly NullLocationPaintable instanceC = new NullLocationPaintable();
    public static NullLocationPaintable getInstance()
    {
        return NullLocationPaintable.instanceC;
    }

}

