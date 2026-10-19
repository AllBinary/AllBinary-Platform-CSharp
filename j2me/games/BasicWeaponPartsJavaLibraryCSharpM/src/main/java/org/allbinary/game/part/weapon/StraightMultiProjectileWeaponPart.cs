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
using NoDecimalTrigTable = org.allbinary.math.NoDecimalTrigTable;

namespace org.allbinary.game.part.weapon;

public class StraightMultiProjectileWeaponPart : BasicWeaponPart
{
    public static StraightMultiProjectileWeaponPart createStraightMultiProjectileWeaponPart(Animation animationInterface, WeaponLayerCircularPool weaponLayerCircularStaticPool)
    {
        return new StraightMultiProjectileWeaponPart(animationInterface, AllBinaryLayer.NULL_ALLBINARY_LAYER, weaponLayerCircularStaticPool, 2, WeaponProperties.NULL_WEAPON_PROPERTIES, NoScoreable.getInstance(), RelativeRelationship.NULL_RELATIVE_RELATIONSHIP);
    }

    private readonly WeaponLayerCircularPool weaponLayerCircularStaticPool;
    private readonly int total;
    public StraightMultiProjectileWeaponPart(Animation animationInterface, AllBinaryLayer sourceLayerInterface, WeaponLayerCircularPool weaponLayerCircularStaticPool, int total, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface, RelativeRelationship relativeRelationship) : base(animationInterface, sourceLayerInterface, weaponProperties, scoreableInterface, relativeRelationship)
    {
        // base(animationInterface, sourceLayerInterface, weaponProperties, scoreableInterface, relativeRelationship) is called from the constructor declaration
        this.total = total;
        this.weaponLayerCircularStaticPool = weaponLayerCircularStaticPool;
    }

    private readonly NoDecimalTrigTable noDecimalTrigTable = NoDecimalTrigTable.getInstance();
    // throws Exception
    public override void processScore(AllBinaryLayerManager allbinaryLayerManager, short angle, short otherAngle, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface)
    {
        AllBinaryLayer sourceLayerInterface = this.getOwnerLayerInterface();
        int reducedWidth = (sourceLayerInterface.getWidth() * 8 / 10);
        int halfWidth = (reducedWidth >> 1);
        int x = this.relativeRelationship.getX();
        int y = this.relativeRelationship.getY();
        long sine = 0L;
        int beamX = 0;
        long cosine = 0L;
        int beamY = 0;
        WeaponLayer weaponLayer = null;
        int increment = reducedWidth / (this.total - 1);
        int next = -halfWidth;
        for (int index = 0; index < this.total; index++) {
            sine = ((long) (next * this.noDecimalTrigTable.sin(((int) angle))));
            beamX = ((int) (sine / this.noDecimalTrigTable.SCALE));
            cosine = ((long) (next * this.noDecimalTrigTable.cos(((int) angle))));
            beamY = -((int) (cosine / this.noDecimalTrigTable.SCALE));
            weaponLayer = this.weaponLayerCircularStaticPool.getInstanceWeaponLayer(sourceLayerInterface, x + beamX, y + beamY, 0, ((int) angle), ((int) otherAngle), weaponProperties, scoreableInterface);
            allbinaryLayerManager.append(weaponLayer);
            next += increment;
        }
    }

}

