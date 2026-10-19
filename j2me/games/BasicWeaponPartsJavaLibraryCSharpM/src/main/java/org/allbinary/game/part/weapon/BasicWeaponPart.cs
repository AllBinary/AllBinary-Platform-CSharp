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
//using Graphics = javax.microedition.lcdui.Graphics;
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using PartInterface = org.allbinary.game.part.PartInterface;
using NoScoreable = org.allbinary.game.score.NoScoreable;
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using RelativeRelationship = org.allbinary.graphics.RelativeRelationship;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using CommonStrings = org.allbinary.@string.CommonStrings;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.part.weapon;

public class BasicWeaponPart : PartInterface, SalvoInterface
{
    public static BasicWeaponPart createBasicWeaponPart(Animation animationInterface)
    {
        return new BasicWeaponPart(animationInterface, AllBinaryLayer.NULL_ALLBINARY_LAYER, WeaponProperties.NULL_WEAPON_PROPERTIES, NoScoreable.getInstance(), RelativeRelationship.NULL_RELATIVE_RELATIONSHIP);
    }

    public static readonly BasicWeaponPart NULL_BASIC_WEAPON_PART = BasicWeaponPart.createBasicWeaponPart(NullAnimationFactory.getFactoryInstance().getInstance(0));
    private Animation animationInterface = NullAnimationFactory.getFactoryInstance().getInstance(0);
    private AllBinaryLayer ownerLayerInterface = AllBinaryLayer.NULL_ALLBINARY_LAYER;
    private WeaponProperties weaponProperties = WeaponProperties.NULL_WEAPON_PROPERTIES;
    private ScoreableInterface scoreableInterface = NoScoreable.getInstance();
    public RelativeRelationship relativeRelationship = RelativeRelationship.NULL_RELATIVE_RELATIONSHIP;
    public BasicWeaponPart(Animation animationInterface, AllBinaryLayer sourceLayerInterface, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface, RelativeRelationship relativeRelationship)
    {
        this.init(sourceLayerInterface, weaponProperties, scoreableInterface, relativeRelationship);
        this.setAnimationInterface(animationInterface);
    }

    public virtual void init(AllBinaryLayer sourceLayerInterface, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface, RelativeRelationship relativeRelationship)
    {
        this.setOwnerLayerInterface(sourceLayerInterface);
        this.setWeaponProperties(weaponProperties);
        this.scoreableInterface = scoreableInterface;
        this.relativeRelationship = relativeRelationship;
    }

    // throws Exception
    public virtual void process(AllBinaryLayerManager allbinaryLayerManager, short angle, short otherAngle)
    {
        this.processScore(allbinaryLayerManager, angle, otherAngle, this.getWeaponProperties(), this.scoreableInterface);
    }

    // throws Exception
    public virtual void processScore(AllBinaryLayerManager allbinaryLayerManager, short angle, short otherAngle, WeaponProperties weaponProperties, ScoreableInterface scoreableInterface)
    {
        throw new Exception(CommonStrings.getInstance().NOT_IMPLEMENTED);
    }

    public virtual AllBinaryLayer getOwnerLayerInterface()
    {
        return this.ownerLayerInterface;
    }

    public virtual void setOwnerLayerInterface(AllBinaryLayer ownerLayerInterface)
    {
        this.ownerLayerInterface = ownerLayerInterface;
    }

    public virtual Animation getAnimationInterface()
    {
        return this.animationInterface;
    }

    public virtual void setAnimationInterface(Animation animationInterface)
    {
        this.animationInterface = animationInterface;
    }

    public virtual void paint(Graphics graphics)
    {
        ViewPositionBase viewPosition = this.getOwnerLayerInterface().getViewPosition();
        int viewX = viewPosition.getX();
        int viewY = viewPosition.getY();
        this.animationInterface.paintXY(graphics, viewX, viewY);
    }

    public virtual void paintThreed(Graphics graphics)
    {
    }

    public virtual WeaponProperties getWeaponProperties()
    {
        return this.weaponProperties;
    }

    public virtual void setWeaponProperties(WeaponProperties weaponProperties)
    {
        this.weaponProperties = weaponProperties;
    }

}

