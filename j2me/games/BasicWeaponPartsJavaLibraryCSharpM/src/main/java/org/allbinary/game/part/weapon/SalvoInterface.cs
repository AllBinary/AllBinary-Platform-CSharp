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
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.part.weapon;

public interface SalvoInterface
{
    // throws Exception
    void process(AllBinaryLayerManager allbinaryLayerManager, short angle, short otherAngle);

    // throws Exception
    void processScore(AllBinaryLayerManager allbinaryLayerManager, short angle, short otherAngle, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface);

}

