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

namespace org.allbinary.math;

public class AngleIncrementInfoFactory
{
    private static readonly AngleIncrementInfoFactory instance = new AngleIncrementInfoFactory();
    public static AngleIncrementInfoFactory getInstance()
    {
        return AngleIncrementInfoFactory.instance;
    }

    private readonly AngleIncrementInfo[] angleIncrementInfo = new AngleIncrementInfo[((int) AngleFactory.getInstance().TOTAL_ANGLE)];
    public virtual AngleIncrementInfo getAt(short angleIncrement)
    {
        int halfAngleIncrement = (((int) angleIncrement) >> 1);
        AngleIncrementInfo angleIncrementInfo = null;
        AngleIncrementInfo angleIncrementInfoCanBeNull = this.angleIncrementInfo[halfAngleIncrement];
        if (angleIncrementInfoCanBeNull == null) {
            angleIncrementInfo = new AngleIncrementInfo(angleIncrement);
            this.angleIncrementInfo[halfAngleIncrement] = angleIncrementInfo;
            return angleIncrementInfo;
        } else {
            angleIncrementInfo = angleIncrementInfoCanBeNull;
        }
        return angleIncrementInfo;
    }

}

