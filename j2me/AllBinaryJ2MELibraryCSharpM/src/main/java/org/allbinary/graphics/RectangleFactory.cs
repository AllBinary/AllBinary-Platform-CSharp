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

namespace org.allbinary.graphics;

public class RectangleFactory
{
    public static readonly Rectangle SINGLETON = new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0);
    public static readonly Rectangle[][] ARRAY_OF_ARRAYS = System.Linq.Enumerable.Range(0, 0).Select(_ => new Rectangle[0]).ToArray();
}

