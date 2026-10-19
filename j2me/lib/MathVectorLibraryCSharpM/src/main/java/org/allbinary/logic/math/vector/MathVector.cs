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
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;

namespace org.allbinary.logic.math.vector;

public class MathVector : MathVectorInterface
{
    private BasicDecimal magnitudeBasicDecimal;
    private int direction;
    public BasicDecimal resultBasicDecimal = null;
    public MathVector(BasicDecimal magnitudeBasicDecimal, int direction)
    {
        this.magnitudeBasicDecimal = magnitudeBasicDecimal;
        this.direction = direction;
    }

    public virtual BasicDecimal getMagnitude()
    {
        return this.magnitudeBasicDecimal;
    }

    public virtual int getDirection()
    {
        return this.direction;
    }

    public virtual BasicDecimal getResult()
    {
        return this.resultBasicDecimal;
    }

}

