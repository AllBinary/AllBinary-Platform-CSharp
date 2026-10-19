/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using GPoint = org.allbinary.graphics.GPoint;

namespace org.allbinary.graphics.displayable.screen;

public class DisplayPointScalar
{
    private static readonly DisplayPointScalar instance = new DisplayPointScalar();
    public static DisplayPointScalar getInstance()
    {
        return DisplayPointScalar.instance;
    }

    public virtual GPoint process(GPoint point)
    {
        return point;
    }

}

