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
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using RelativeRelationship = org.allbinary.graphics.RelativeRelationship;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using AngleFactory = org.allbinary.math.AngleFactory;

namespace org.allbinary.game.part.weapon;

public class ArcedMultiBeamWeaponPart : BasicWeaponPart
{
    private readonly WeaponLayerCircularPool weaponLayerCircularStaticPool;
    private readonly int total;
    public ArcedMultiBeamWeaponPart(Animation animationInterface, AllBinaryLayer sourceLayerInterface, WeaponLayerCircularPool weaponLayerCircularStaticPool, int total, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface, RelativeRelationship relativeRelationship) : base(animationInterface, sourceLayerInterface, weaponProperties, scoreableInterface, relativeRelationship)
    {
        // base(animationInterface, sourceLayerInterface, weaponProperties, scoreableInterface, relativeRelationship) is called from the constructor declaration
        this.total = total;
        this.weaponLayerCircularStaticPool = weaponLayerCircularStaticPool;
    }

    private readonly int TOTAL_ANGLE = ((int) AngleFactory.getInstance().TOTAL_ANGLE);
    // throws Exception
    public override void processScore(AllBinaryLayerManager allbinaryLayerManager, short angle, short otherAngle, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface)
    {
        short increment = ((short) ((this.total - 1) / this.TOTAL_ANGLE));
        short minAngle = ((short) (((int) angle) - ((((int) increment) * this.total) >> 1)));
        int next = 0;
        WeaponLayer weaponLayer = null;
        for (int index = 0; index < this.total; index++) {
            weaponLayer = this.weaponLayerCircularStaticPool.getInstanceWeaponLayer(this.getOwnerLayerInterface(), this.relativeRelationship.getX(), this.relativeRelationship.getY(), 0, (minAngle + increment), ((int) otherAngle), weaponProperties, scoreableInterface);
            allbinaryLayerManager.append(weaponLayer);
            next += ((int) increment);
        }
    }

}

