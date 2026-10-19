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
//using GL = javax.microedition.khronos.opengles.GL;
//using Graphics = javax.microedition.lcdui.Graphics;
using Animation = org.allbinary.animation.Animation;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using CollidableBaseBehavior = org.allbinary.game.collision.CollidableBaseBehavior;
using DestroyedLayerProcessor = org.allbinary.game.combat.destroy.DestroyedLayerProcessor;
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using GameConfigurationUtil = org.allbinary.game.configuration.GameConfigurationUtil;
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;
using MultiPlayerGameLayer = org.allbinary.game.multiplayer.layer.MultiPlayerGameLayer;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using NoScoreable = org.allbinary.game.score.NoScoreable;
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using TickableInterface = org.allbinary.game.tick.TickableInterface;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using Movement = org.allbinary.physics.movement.Movement;
using ViewPosition = org.allbinary.view.ViewPosition;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.weapon;

public class WeaponLayer : MultiPlayerGameLayer, TickableInterface
{
    private Animation animationInterface = NullAnimationFactory.getFactoryInstance().getInstance(0);
    public Animation initAnimationInterface;
    private Animation destroyedAnimationInterface;
    private AllBinaryLayer sourceLayerInterface = AllBinaryLayer.NULL_ALLBINARY_LAYER;
    public int totalDamage = 0;
    private int initDamage = 0;
    private bool destroyed = true;
    public ScoreableInterface scoreableInterface = NoScoreable.getInstance();
    private Movement movement;
    private WeaponProperties weaponProperties = WeaponProperties.NULL_WEAPON_PROPERTIES;
    private readonly int multiPlayerType;
    protected WeaponLayer(string name, RemoteInfo remoteInfo, int multiPlayerType, Movement movement, Animation animationInterface, Animation destroyedAnimationInterface, Rectangle rectangle, ViewPositionBase viewPosition) : base(remoteInfo, BasicGroupFactory.getInstance().NONE_ARRAY, name, rectangle, viewPosition)
    {
        // base(remoteInfo, BasicGroupFactory.getInstance().NONE_ARRAY, name, rectangle, viewPosition) is called from the constructor declaration
        this.initAnimationInterface = animationInterface;
        this.setAnimationInterface(animationInterface);
        this.destroyedAnimationInterface = destroyedAnimationInterface;
        this.movement = movement;
        this.multiPlayerType = multiPlayerType;
    }

    private CollidableWeaponBehavior collidableWeaponBehavior = CollidableWeaponBehavior.getNullInstance();
    public override void setCollidableInferface(CollidableBaseBehavior collidableInferface)
    {
        base.setCollidableInferface(collidableInferface);
        this.collidableWeaponBehavior = ((CollidableWeaponBehavior) this.getCollidableInferface());
    }

    // throws Exception
    public virtual void initXYZ(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // throws Exception
    public virtual void init(AllBinaryLayer sourceLayerInterface, int angle, int otherAngle, WeaponProperties weaponProperties, ScoreableInterface scoreable)
    {
        this.setWeaponPropertiesP(weaponProperties);
        this.setReadyForExplosion(false);
        this.setAnimationInterface(this.getInitAnimationInterfaceP());
        this.setOwnerLayerInterface(sourceLayerInterface);
        this.collidableWeaponBehavior.init(sourceLayerInterface);
        this.setGroupInterfaces();
        if (scoreable != null) {
            this.scoreableInterface = scoreable;
        }
        this.totalDamage = 0;
        this.initDamage = weaponProperties.getDamage();
        this.setDestroyed(false);
        this.movement.init(weaponProperties.getSpeed(), angle, otherAngle);
    }

    protected virtual void setGroupInterfaces()
    {
        BasicGroupFactory basicGroupFactory = BasicGroupFactory.getInstance();
        if (this.sourceLayerInterface.getGroupInterface()[0] == basicGroupFactory.ENEMY) {
            this.setGroupInterface(basicGroupFactory.ENEMY_ARRAY);
        } else {
            this.setGroupInterface(this.sourceLayerInterface.getGroupInterface());
        }
    }

    // throws Exception
    public override void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.isExhausted() && !this.isDestroyed()) {
            if (this.isReadyForExplosion()) {
                IndexedAnimation indexedAnimationInterface = ((IndexedAnimation) this.getAnimationInterface());
                int currentFrame = indexedAnimationInterface.getFrame();
                if (currentFrame < indexedAnimationInterface.getAnimationSize() - 1) {
                    indexedAnimationInterface.nextFrame();
                } else {
                    this.setDestroyed(true);
                }
            } else {
                CollidableWeaponBehavior collidableWeaponBehavior = ((CollidableWeaponBehavior) this.getCollidableInferface());
                if (collidableWeaponBehavior.isCollided()) {
                    this.setAnimationInterface(this.destroyedAnimationInterface);
                    this.getMovement().stop();
                    this.setReadyForExplosion(true);
                } else {
                    this.setDestroyed(true);
                }
            }
        }
        this.movement.process(this);
        this.totalDamage += this.weaponProperties.getDissipation();
    }

    public override bool isDestroyed()
    {
        return this.destroyed;
    }

    public override void damage(int damage, int damageType)
    {
        this.totalDamage += damage * damage;
    }

    protected virtual void givePoints(int total)
    {
        this.scoreableInterface.addPoints(GameConfigurationUtil.getInstance().getCompetitionValue() * total);
    }

    protected virtual bool isExhausted()
    {
        if (this.totalDamage > this.getInitDamage() || this.totalDamage < 0) {
            return true;
        } else {
            return false;
        }
    }

    public override int getDamage(int damageType)
    {
        if (!this.isExhausted()) {
            int total = this.getInitDamage() - this.totalDamage;
            this.givePoints(total);
            return total;
        }
        return 0;
    }

    public virtual void setDestroyed(bool destroyed)
    {
        this.destroyed = destroyed;
        if (this.isDestroyed()) {
            this.scoreableInterface = NoScoreable.getInstance();
            DestroyedLayerProcessor.getInstance().add(this);
        }
    }

    protected virtual int getInitDamage()
    {
        return this.initDamage;
    }

    protected virtual void setAnimationInterface(Animation animationInterface)
    {
        this.animationInterface = animationInterface;
    }

    protected virtual Animation getAnimationInterface()
    {
        return this.animationInterface;
    }

    public virtual Animation getInitAnimationInterfaceP()
    {
        return this.initAnimationInterface;
    }

    public virtual void setInitAnimationInterfaceP(Animation initAnimationInterface)
    {
        this.initAnimationInterface = initAnimationInterface;
    }

    public virtual Animation getDestroyedAnimationInterface()
    {
        return this.destroyedAnimationInterface;
    }

    public virtual AllBinaryLayer getOwnerLayerInterface()
    {
        return this.sourceLayerInterface;
    }

    public virtual void setOwnerLayerInterface(AllBinaryLayer sourceLayerInterface)
    {
        this.sourceLayerInterface = sourceLayerInterface;
    }

    public override void paint(Graphics graphics)
    {
        ViewPositionBase viewPosition = this.getViewPosition();
        this.animationInterface.paintXY(graphics, viewPosition.getX() - this.getHalfWidth(), viewPosition.getY() - this.getHalfHeight());
    }

    public override void paintThreed(Graphics graphics)
    {
        ViewPositionBase viewPosition = this.getViewPosition();
        this.animationInterface.paintThreedXYZ(graphics, viewPosition.getX() - this.getHalfWidth(), viewPosition.getY() - this.getHalfHeight(), viewPosition.getZ() - this.getHalfDepth());
    }

    public virtual Movement getMovement()
    {
        return this.movement;
    }

    public virtual void setMovement(Movement movement)
    {
        this.movement = movement;
    }

    public override int getType()
    {
        return WeaponLayer.getStaticType();
    }

    public static int getStaticType()
    {
        return 0;
    }

    public override int getMultiPlayerType()
    {
        return this.multiPlayerType;
    }

    public virtual void setWeaponPropertiesP(WeaponProperties weaponProperties)
    {
        this.weaponProperties = weaponProperties;
    }

    public virtual WeaponProperties getWeaponPropertiesP()
    {
        return this.weaponProperties;
    }

    public override bool implmentsTickableInterface()
    {
        return true;
    }

    // throws Exception
    public override void set(GL gl)
    {
        this.initAnimationInterface.set(gl);
    }

}

