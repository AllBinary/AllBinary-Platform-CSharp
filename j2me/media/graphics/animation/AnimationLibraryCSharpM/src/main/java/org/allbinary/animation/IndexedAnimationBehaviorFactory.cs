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

namespace org.allbinary.animation;

public class IndexedAnimationBehaviorFactory : AnimationBehaviorFactory
{
    public long frameDelayTime;
    public int loopTotal;
    public IndexedAnimationBehaviorFactory(int loopTotal, long frameDelayTime)
    {
        this.loopTotal = loopTotal;
        this.frameDelayTime = frameDelayTime;
    }

    public override AnimationBehavior getOrCreateInstance()
    {
        return new IndexedAnimationBehavior(this.loopTotal, this.frameDelayTime);
    }

}

