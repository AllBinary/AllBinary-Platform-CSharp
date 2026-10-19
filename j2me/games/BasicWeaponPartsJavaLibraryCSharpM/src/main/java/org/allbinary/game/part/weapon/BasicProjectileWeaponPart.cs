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
using Animation = org.allbinary.animation.Animation;
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using WeaponLayer = org.allbinary.game.layer.weapon.WeaponLayer;
using WeaponLayerCircularPool = org.allbinary.game.layer.weapon.WeaponLayerCircularPool;
using NoScoreable = org.allbinary.game.score.NoScoreable;
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using RelativeRelationship = org.allbinary.graphics.RelativeRelationship;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.part.weapon;

public class BasicProjectileWeaponPart : BasicWeaponPart
{
    public static BasicProjectileWeaponPart createBasicProjectileWeaponPart(Animation animationInterface, WeaponLayerCircularPool weaponLayerCircularStaticPool)
    {
        return new BasicProjectileWeaponPart(animationInterface, AllBinaryLayer.NULL_ALLBINARY_LAYER, weaponLayerCircularStaticPool, WeaponProperties.NULL_WEAPON_PROPERTIES, NoScoreable.getInstance(), RelativeRelationship.NULL_RELATIVE_RELATIONSHIP);
    }

    private WeaponLayerCircularPool weaponLayerCircularStaticPool;
    public BasicProjectileWeaponPart(Animation animationInterface, AllBinaryLayer sourceLayerInterface, WeaponLayerCircularPool weaponLayerCircularStaticPool, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface, RelativeRelationship relativeRelationship) : base(animationInterface, sourceLayerInterface, weaponProperties, scoreableInterface, relativeRelationship)
    {
        // base(animationInterface, sourceLayerInterface, weaponProperties, scoreableInterface, relativeRelationship) is called from the constructor declaration
        this.weaponLayerCircularStaticPool = weaponLayerCircularStaticPool;
    }

    // throws Exception
    public override void processScore(AllBinaryLayerManager allbinaryLayerManager, short angle, short otherAngle, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface)
    {
        WeaponLayer weaponLayer = this.weaponLayerCircularStaticPool.getInstanceWeaponLayer(this.getOwnerLayerInterface(), this.relativeRelationship.getX(), this.relativeRelationship.getY(), this.relativeRelationship.getZ(), ((int) angle), ((int) otherAngle), weaponProperties, scoreableInterface);
        allbinaryLayerManager.append(weaponLayer);
    }

}

