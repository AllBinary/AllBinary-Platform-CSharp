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
using AnimationInterface = org.allbinary.animation.AnimationInterface;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;

namespace org.allbinary.animation.compound;

public interface CompoundAnimationInterface : AnimationInterface
{
    void nextAnimation();

    void previousAnimation();

    void setAnimation(int index);

    IndexedAnimation getCurrentAnimation();

}

