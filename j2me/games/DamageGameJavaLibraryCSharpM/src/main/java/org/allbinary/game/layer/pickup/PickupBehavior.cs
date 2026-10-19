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
using HealthInterfaceCompositeInterface = org.allbinary.game.health.HealthInterfaceCompositeInterface;
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using CountedLayerInterfaceFactoryPart = org.allbinary.game.part.CountedLayerInterfaceFactoryPart;
using PartInterface = org.allbinary.game.part.PartInterface;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.layer.pickup;

public class PickupBehavior : PickupBehaviorInterface
{
    public static object NULL_PICKUP_BEHAVIOR = NullUtil.getInstance().NULL_OBJECT;
    public static PickupBehavior getNullInstance()
    {
        if (PickupBehavior.NULL_PICKUP_BEHAVIOR == NullUtil.getInstance().NULL_OBJECT) {
            PickupBehavior.NULL_PICKUP_BEHAVIOR = new PickupBehavior(CollidableCompositeLayer.getNullInstance(), 0);
        }
        return ((PickupBehavior) PickupBehavior.NULL_PICKUP_BEHAVIOR);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly int countedIndex;
    private readonly CollidableCompositeLayer ownerLayerInterface;
    public PickupBehavior(CollidableCompositeLayer ownerLayerInterface, int countedIndex)
    {
        this.ownerLayerInterface = ownerLayerInterface;
        this.countedIndex = countedIndex;
    }

    public virtual void doPickup(PickupProcessorInterface pickupProcessorInterface)
    {
        try {
            HealthInterfaceCompositeInterface healthInterfaceCompositeInterface = ((HealthInterfaceCompositeInterface) this.ownerLayerInterface);
            if (healthInterfaceCompositeInterface.getHealthInterface().isAlive()) {
                pickupProcessorInterface.process(this.ownerLayerInterface);
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "doPickup", e);
        }
    }

    public virtual void doPickupLayer(PickedUpLayerInterface pickupLayerInterface)
    {
        try {
            PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface = pickupLayerInterface.getPickedUpLayerInterfaceFactoryInterface();
            PickedUpLayerType pickedUpLayerType = pickedUpLayerInterfaceFactoryInterface.getPickedUpLayerType();
            PickedUpLayerTypeFactory pickedUpLayerTypeFactory = PickedUpLayerTypeFactory.getInstance();
            if (pickedUpLayerType == pickedUpLayerTypeFactory.BEAM || pickedUpLayerType == pickedUpLayerTypeFactory.MINE || pickedUpLayerType == pickedUpLayerTypeFactory.PROJECTILE || pickedUpLayerType == pickedUpLayerTypeFactory.ENHANCEMENT) {
                this.add(((CountedPickedUpLayerInterfaceFactoryInterface) pickedUpLayerInterfaceFactoryInterface));
            } else if (pickedUpLayerInterfaceFactoryInterface.getPickedUpLayerType() == pickedUpLayerTypeFactory.PART) {
                CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer = ((CollidableDestroyableDamageableLayer) this.ownerLayerInterface);
                collidableDestroyableDamageableLayer.addPart(pickedUpLayerInterfaceFactoryInterface);
            } else if (pickedUpLayerType == pickedUpLayerTypeFactory.NONE) {
            } else {
                PickupProcessorInterface pickupProcessorInterface = ((PickupProcessorInterface) pickedUpLayerInterfaceFactoryInterface);
                this.doPickup(pickupProcessorInterface);
            }
            pickupLayerInterface.setPickedUp();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, this, "doPickup", e);
        }
    }

    protected virtual void add(CountedPickedUpLayerInterfaceFactoryInterface countedPickedUpLayerInterfaceFactoryInterface)
    {
        int partIndex = countedPickedUpLayerInterfaceFactoryInterface.getId() + this.countedIndex;
        this.addAt(countedPickedUpLayerInterfaceFactoryInterface, partIndex);
    }

    protected virtual void addAt(CountedPickedUpLayerInterfaceFactoryInterface countedPickedUpLayerInterfaceFactoryInterface, int partIndex)
    {
        CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer = ((CollidableDestroyableDamageableLayer) this.ownerLayerInterface);
        CountedLayerInterfaceFactoryPart countedLayerInterfaceFactory = ((CountedLayerInterfaceFactoryPart) collidableDestroyableDamageableLayer.getPartInterfaceArray()[partIndex]);
        countedLayerInterfaceFactory.setTotal(countedLayerInterfaceFactory.getTotal() + countedPickedUpLayerInterfaceFactoryInterface.getTotal());
    }

    public virtual CountedLayerInterfaceFactoryPart getFirstAvailableCountedLayerInterfaceFactory(PickedUpLayerType[] pickedUpLayerTypeArray)
    {
        CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer = ((CollidableDestroyableDamageableLayer) this.ownerLayerInterface);
        PartInterface[] partInterfaceArray = collidableDestroyableDamageableLayer.getPartInterfaceArray();
        int size = partInterfaceArray.Length;
        CountedLayerInterfaceFactoryPart nextCountedLayerInterfaceFactory = null;
        CountedPickedUpLayerInterfaceFactory countedPickedUpLayerInterfaceFactory = null;
        for (int index = this.countedIndex; index < size; index++) {
            nextCountedLayerInterfaceFactory = ((CountedLayerInterfaceFactoryPart) collidableDestroyableDamageableLayer.getPartInterfaceArray()[index]);
            countedPickedUpLayerInterfaceFactory = nextCountedLayerInterfaceFactory.getCountedPickedUpLayerInterfaceFactory();
            for (int index2 = pickedUpLayerTypeArray.Length; --index2 >= 0; ) {
                if (countedPickedUpLayerInterfaceFactory.getPickedUpLayerType() == pickedUpLayerTypeArray[index2]) {
                    if (nextCountedLayerInterfaceFactory.getTotal() > 0) {
                        return nextCountedLayerInterfaceFactory;
                    }
                }
            }
        }
        return CountedLayerInterfaceFactoryPart.NULL_COUNTED_LAYER_INTERFACE_FACTORY;
    }

    // throws Exception
    public virtual CountedLayerInterfaceFactoryPart getCountedLayerInterfaceFactoryForSlot(int slotIndex)
    {
        int currentSlot = 0;
        CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer = ((CollidableDestroyableDamageableLayer) this.ownerLayerInterface);
        PartInterface[] partInterfaceArray = collidableDestroyableDamageableLayer.getPartInterfaceArray();
        int size = partInterfaceArray.Length;
        CountedLayerInterfaceFactoryPart nextCountedLayerInterfaceFactory = null;
        for (int index = this.countedIndex; index < size; index++) {
            nextCountedLayerInterfaceFactory = ((CountedLayerInterfaceFactoryPart) collidableDestroyableDamageableLayer.getPartInterfaceArray()[index]);
            if (nextCountedLayerInterfaceFactory.getTotal() > 0) {
                if (currentSlot == slotIndex) {
                    return nextCountedLayerInterfaceFactory;
                } else {
                    currentSlot++;
                }
            }
        }
        return CountedLayerInterfaceFactoryPart.NULL_COUNTED_LAYER_INTERFACE_FACTORY;
    }

    public virtual int getCountedIndex()
    {
        return this.countedIndex;
    }

}

