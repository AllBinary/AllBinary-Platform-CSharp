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
using System.Runtime.CompilerServices;
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using RelativeRelationship = org.allbinary.graphics.RelativeRelationship;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.part.weapon;

public class BasicWeaponPartCircularPool
{
    public static readonly BasicWeaponPartCircularPool NULL_BASIC_WEAPON_PART_CIRCULAR_POOL = new BasicWeaponPartCircularPool();
    private BasicWeaponPart basicWeaponPart = BasicWeaponPart.NULL_BASIC_WEAPON_PART;
    // throws Exception
    public virtual void init(BasicWeaponPartFactoryInterface basicWeaponPartFactoryInterface)
    {
        this.basicWeaponPart = basicWeaponPartFactoryInterface.getInstance();
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual BasicWeaponPart getInstance(AllBinaryLayer sourceLayerInterface, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface, RelativeRelationship relativeRelationship)
    {
        this.basicWeaponPart.init(sourceLayerInterface, weaponProperties, scoreableInterface, relativeRelationship);
        return this.basicWeaponPart;
    }

}

