/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using SelectionHudPaintable = org.allbinary.game.layer.SelectionHudPaintable;
using WaypointLayer = org.allbinary.game.layer.waypoint.WaypointLayer;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using Group = org.allbinary.game.identification.Group;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using Rectangle = org.allbinary.graphics.Rectangle;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;

namespace org.allbinary.game.layer.geological.resources;

public class ResourceWaypointLayer : WaypointLayer
{
    public ResourceWaypointLayer(RemoteInfo remoteInfo, PathFindingLayerInterface parentLayer, Group[] groupInterface, string rootName, string name, AnimationInterfaceFactoryInterface animationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface proceduralAnimationInterfaceFactoryInterface, Rectangle rectangle, int x, int y) : base(remoteInfo, parentLayer, groupInterface, rootName, name, animationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y)
    {
        // base(remoteInfo, parentLayer, groupInterface, rootName, name, animationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y) is called from the constructor declaration
    }

    public override SelectionHudPaintable createHudPaintable()
    {
        GeologicalResourceInfoHudPaintable rtsLayerHudPaintable = GeologicalResourceInfoHudPaintableSingleton.getInstance();
        rtsLayerHudPaintable.setBasicColorP(this.allBinaryGameLayerManagerP.getForegroundBasicColor());
        rtsLayerHudPaintable.setRtsLayer(this);
        return rtsLayerHudPaintable;
    }

    public override SelectionHudPaintable getHudPaintable()
    {
        GeologicalResourceInfoHudPaintable rtsLayerHudPaintable = GeologicalResourceInfoHudPaintableSingleton.getInstance();
        return rtsLayerHudPaintable;
    }

}

