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
using NamedInterface = org.allbinary.layer.NamedInterface;

namespace org.allbinary.game.combat.damage;

public interface DamageableInterface : NamedInterface
{
    // throws Exception
    void damage(int damage, int damageType);

    // throws Exception
    int getDamage(int damageType);

}

