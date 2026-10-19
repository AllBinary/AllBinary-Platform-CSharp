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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerCircularPool = org.allbinary.layer.AllBinaryLayerCircularPool;

namespace org.allbinary.game.layer.weapon;

public class WeaponLayerCircularPool : AllBinaryLayerCircularPool
{
    public WeaponLayerCircularPool()
    {
    }

    // throws Exception
    public virtual WeaponLayer getInstanceWeaponLayer(AllBinaryLayer sourceLayerInterface, int x, int y, int z, int angle, int otherAngle, WeaponProperties weaponProperties, ScoreableInterface scoreable)
    {
        WeaponLayer weaponLayer = ((WeaponLayer) base.getNextInstance());
        weaponLayer.initXYZ(x, y, z);
        weaponLayer.init(sourceLayerInterface, angle, otherAngle, weaponProperties, scoreable);
        return weaponLayer;
    }

}

