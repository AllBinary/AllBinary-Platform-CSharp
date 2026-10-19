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

namespace org.allbinary.graphics.displayable;

public class BaseScalable : ScalableListener
{
    public virtual float getRatio(float ratio)
    {
        return 1f;
    }

    public virtual int getLeft(int xOffset)
    {
        return -1;
    }

    public virtual int getTop(int yOffset)
    {
        return -1;
    }

    public virtual void scale(float ratio)
    {
    }

}

