/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using Group = org.allbinary.game.identification.Group;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPositionTracking = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionTracking;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer;

public class NullVehicleLayer : VehicleLayerInterface
{
    public static readonly NullVehicleLayer NULL_VEHICLE_LAYER = new NullVehicleLayer();
    public virtual string getName()
    {
        throw new SystemException();
    }

    public virtual Group[] getGroupInterface()
    {
        throw new SystemException();
    }

    public virtual void setPosition(int x, int y, int z)
    {
        throw new SystemException();
    }

    public virtual int getHeight()
    {
        throw new SystemException();
    }

    public virtual int getWidth()
    {
        throw new SystemException();
    }

    public virtual int getHalfHeight()
    {
        throw new SystemException();
    }

    public virtual int getHalfWidth()
    {
        throw new SystemException();
    }

    public virtual int getXP()
    {
        throw new SystemException();
    }

    public virtual int getYP()
    {
        throw new SystemException();
    }

    public virtual int getZP()
    {
        throw new SystemException();
    }

    public virtual int getX2()
    {
        throw new SystemException();
    }

    public virtual int getY2()
    {
        throw new SystemException();
    }

    public virtual int getZ2()
    {
        throw new SystemException();
    }

    public virtual bool isVisible()
    {
        throw new SystemException();
    }

    public virtual void moveDXYZ(int dx, int dy, int dz)
    {
        throw new SystemException();
    }

    public virtual void setVisible(bool visible)
    {
        throw new SystemException();
    }

    public virtual bool implmentsTickableInterface()
    {
        throw new SystemException();
    }

    public virtual bool implmentsCollidableInterface()
    {
        throw new SystemException();
    }

    public virtual bool implmentsGameInputInterface()
    {
        throw new SystemException();
    }

    public virtual bool implmentsArtificialIntelligenceCompositeInterface()
    {
        throw new SystemException();
    }

    public virtual int getType()
    {
        throw new SystemException();
    }

    public virtual VehicleProperties getVehicleProperties()
    {
        throw new SystemException();
    }

    public virtual BasicArrayList getGameKeyEventList()
    {
        throw new SystemException();
    }

    public virtual BasicDecimal getSpeedBasicDecimal()
    {
        throw new SystemException();
    }

    public virtual bool isReadyForExplosion()
    {
        throw new SystemException();
    }

    public virtual RotationAnimation getRotationAnimationInterface()
    {
        throw new SystemException();
    }

    public virtual void setRotationAnimationInterface(RotationAnimation animationInterface)
    {
        throw new SystemException();
    }

    public virtual bool isDestroyed()
    {
        throw new SystemException();
    }

    public virtual bool isFinish()
    {
        throw new SystemException();
    }

    public virtual int getFinalPosition()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void handleFinish()
    {
        throw new SystemException();
    }

    public virtual GeographicMapCellPositionTracking getGeographicMapCellPositionTracking()
    {
        throw new SystemException();
    }

    public virtual GeographicMapCellHistory[] getGeographicMapCellHistoryArray()
    {
        throw new SystemException();
    }

    public virtual void setGeographicMapCellHistoryArray(GeographicMapCellHistory[] geographicMapCellHistory)
    {
        throw new SystemException();
    }

    public virtual void paint(Graphics graphics)
    {
    }

    public virtual void paintThreed(Graphics graphics)
    {
    }

}

