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
using CollidableNeverCollideBehaviorFactory = org.allbinary.game.collision.CollidableNeverCollideBehaviorFactory;
using DamageableInterface = org.allbinary.game.combat.damage.DamageableInterface;
using DestroyableInterface = org.allbinary.game.combat.destroy.DestroyableInterface;
using DestroyedEvent = org.allbinary.game.combat.destroy.@event.DestroyedEvent;
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;
using Group = org.allbinary.game.identification.Group;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using PickedUpLayerInterfaceFactoryInterface = org.allbinary.game.layer.pickup.PickedUpLayerInterfaceFactoryInterface;
using PickupBehavior = org.allbinary.game.layer.pickup.PickupBehavior;
using PickupCompositeInterface = org.allbinary.game.layer.pickup.PickupCompositeInterface;
using PartInterface = org.allbinary.game.part.PartInterface;
using PartInterfaceUtil = org.allbinary.game.part.PartInterfaceUtil;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using NullUtil = org.allbinary.logic.NullUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.special;

public class CollidableDestroyableDamageableLayer : CollidableCompositeLayer, DestroyableInterface, DamageableInterface, PickupCompositeInterface, SpecialGameInputInterface
{
    private static object NULL_COLLIDABLE_DESTROYABLE_DAMAGE_LAYER = NullUtil.getInstance().NULL_OBJECT;
    public static CollidableDestroyableDamageableLayer getNullInstance()
    {
        if (CollidableDestroyableDamageableLayer.NULL_COLLIDABLE_DESTROYABLE_DAMAGE_LAYER == NullUtil.getInstance().NULL_OBJECT) {
            CollidableDestroyableDamageableLayer.NULL_COLLIDABLE_DESTROYABLE_DAMAGE_LAYER = new CollidableDestroyableDamageableLayer(BasicGroupFactory.getInstance().NONE_ARRAY, StringUtil.getInstance().EMPTY_STRING, RectangleFactory.SINGLETON, ViewPositionBase.NULL_VIEW_POSITION);
        }
        return ((CollidableDestroyableDamageableLayer) CollidableDestroyableDamageableLayer.NULL_COLLIDABLE_DESTROYABLE_DAMAGE_LAYER);
    }

    private Group[] groupInterface;
    private bool readyForExplosion = false;
    private int initWidth;
    private int initHeight;
    private int initX = 0;
    private int initY = 0;
    private int initZ = 0;
    public PartInterface[] partInterfaceArrayP = PartInterfaceUtil.getZeroArray();
    private PickupBehavior pickupBehavior;
    public AllBinaryGameLayerManager allBinaryGameLayerManagerP = AllBinaryGameLayerManager.getNullInstance();
    public bool isDraggable = false;
    public bool isDragged = false;
    public bool isDropped = false;
    public CollidableDestroyableDamageableLayer(Group[] groupInterface, string name, Rectangle layerInfo, ViewPositionBase viewPosition) : base(name, layerInfo, viewPosition, CollidableNeverCollideBehaviorFactory.getInstance())
    {
        // base(name, layerInfo, viewPosition, CollidableNeverCollideBehaviorFactory.getInstance()) is called from the constructor declaration
        this.initWidth = layerInfo.getWidth();
        this.initHeight = layerInfo.getHeight();
        this.groupInterface = groupInterface;
        this.pickupBehavior = PickupBehavior.getNullInstance();
    }

    // throws Exception
    public virtual void initPosition()
    {
        this.setPosition(this.initX, this.initY, this.initZ);
    }

    // throws Exception
    public virtual void initPositionXYZ(int x, int y, int z)
    {
        this.initX = x;
        this.initY = y;
        this.initZ = z;
    }

    public override void paint(Graphics graphics)
    {
        base.paint(graphics);
    }

    // throws Exception
    public override void damage(int damage, int damageType)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public override int getDamage(int damageType)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public override bool isDestroyed()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public override Group[] getGroupInterface()
    {
        return this.groupInterface;
    }

    public virtual void setGroupInterface(Group[] teamInterface)
    {
        this.groupInterface = teamInterface;
    }

    // throws Exception
    public virtual void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        this.allBinaryGameLayerManagerP = allBinaryGameLayerManager;
        if (this.allBinaryGameLayerManagerP == null) {
            throw new SystemException();
        }
    }

    public bool isReadyForExplosion()
    {
        return this.readyForExplosion;
    }

    protected void setReadyForExplosion(bool isReadyForExplosion)
    {
        this.readyForExplosion = isReadyForExplosion;
    }

    public virtual int getInitWidth()
    {
        return this.initWidth;
    }

    public virtual int getInitHeight()
    {
        return this.initHeight;
    }

    public virtual int getInitX()
    {
        return this.initX;
    }

    public virtual int getInitY()
    {
        return this.initY;
    }

    // throws Exception
    public override void up()
    {
    }

    // throws Exception
    public override void down()
    {
    }

    // throws Exception
    public override void right()
    {
    }

    // throws Exception
    public override void left()
    {
    }

    // throws Exception
    public override void strafeLeft()
    {
    }

    // throws Exception
    public override void strafeRight()
    {
    }

    // throws Exception
    public override void fire(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent)
    {
    }

    // throws Exception
    public override void special1(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent)
    {
    }

    // throws Exception
    public override void special2(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent)
    {
    }

    // throws Exception
    public override void special3(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent)
    {
    }

    // throws Exception
    public override void special4(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent)
    {
    }

    // throws Exception
    public override void special5(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent)
    {
    }

    // throws Exception
    public virtual void upAnalog(int yAnalogValue)
    {
    }

    // throws Exception
    public virtual void downAnalog(int yAnalogValue)
    {
    }

    // throws Exception
    public virtual void rightAnalog(int xAnalogValue)
    {
    }

    // throws Exception
    public virtual void leftAnalog(int xAnalogValue)
    {
    }

    // throws Exception
    public virtual void rightTrigger(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent, int xAnalogValue)
    {
    }

    // throws Exception
    public virtual void leftTrigger(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent, int xAnalogValue)
    {
    }

    public virtual void onDestroyed(DestroyedEvent destroyedEvent)
    {
    }

    public override PickupBehavior getPickupBehavior()
    {
        return this.pickupBehavior;
    }

    public override void setPickupBehavior(PickupBehavior pickupBehavior)
    {
        this.pickupBehavior = pickupBehavior;
    }

    // throws Exception
    public virtual void addPart(PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface)
    {
    }

    public virtual void setPartInterfaceArray(PartInterface[] partInterfaceArray)
    {
        this.partInterfaceArrayP = partInterfaceArray;
    }

    public virtual PartInterface[] getPartInterfaceArray()
    {
        return this.partInterfaceArrayP;
    }

    private static readonly string READYFOREXPLOSION = "ReadyForExplosion: ";
    public override void toStringAppend(StringMaker stringBuffer)
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        PositionStrings positionStrings = PositionStrings.getInstance();
        base.toStringAppend(stringBuffer);
        stringBuffer.append(commonSeps.NEW_LINE);
        Group[] groupInterfaceArray = this.getGroupInterface();
        int size = groupInterfaceArray.Length;
        for (int index = 0; index < size; index++) {
            stringBuffer.append(groupInterfaceArray[index].ToString());
            stringBuffer.append(commonSeps.COMMA);
        }
        PickupBehavior pickupBehavior = this.getPickupBehavior();
        if (pickupBehavior != null) {
            stringBuffer.append(commonSeps.NEW_LINE);
            stringBuffer.append(pickupBehavior.ToString());
        }
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(CollidableDestroyableDamageableLayer.READYFOREXPLOSION);
        stringBuffer.appendboolean(this.readyForExplosion);
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(this.commonStrings.INIT);
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(positionStrings.X_LABEL);
        stringBuffer.appendint(this.initX);
        stringBuffer.append(positionStrings.Y_LABEL);
        stringBuffer.appendint(this.initX);
        stringBuffer.append(positionStrings.Z_LABEL);
        stringBuffer.appendint(this.initZ);
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        this.toStringAppend(stringBuffer);
        return stringBuffer.ToString();
    }

}

