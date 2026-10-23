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
using BaseResourceAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.resource.BaseResourceAnimationInterfaceFactoryInterfaceFactory;
using ImageCache = org.allbinary.image.ImageCache;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.layer.resources;

public class OnDemandResources
{
    public static readonly OnDemandResources NULL_ON_DEMAND_RESOURCES = new OnDemandResources();
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public OnDemandResources()
    {
    }

    // throws Exception
    public virtual void waitFor()
    {
    }

    // throws Exception
    public virtual void init()
    {
    }

    // throws Exception
    public virtual int initAt(ImageCache imageCache, BaseResourceAnimationInterfaceFactoryInterfaceFactory resourceAnimationInterfaceFactoryInterfaceFactory, int portion, string loadingString, int index)
    {
        return 0;
    }

}

