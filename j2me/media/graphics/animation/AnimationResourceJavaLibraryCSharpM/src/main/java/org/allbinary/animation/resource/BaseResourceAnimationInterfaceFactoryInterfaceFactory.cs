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
using BasicAnimationInterfaceFactoryInterface = org.allbinary.animation.BasicAnimationInterfaceFactoryInterface;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using ImageCache = org.allbinary.image.ImageCache;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;

namespace org.allbinary.animation.resource;

public class BaseResourceAnimationInterfaceFactoryInterfaceFactory : FeatureResourceAnimationInterfaceFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ABHashtable<object, object> hashtable;
    private readonly ABHashtable<object, object> rectangleHashtable;
    private readonly ABHashtable<object, object> rectangleArrayOfArraysHashtable;
    private readonly string name;
    private bool initialized = false;
    public BaseResourceAnimationInterfaceFactoryInterfaceFactory(string name, ABHashtable<object, object> hashtable, ABHashtable<object, object> rectangleHashtable, ABHashtable<object, object> rectangleArrayHashtable)
    {
        this.hashtable = hashtable;
        this.rectangleHashtable = rectangleHashtable;
        this.rectangleArrayOfArraysHashtable = rectangleArrayHashtable;
        this.name = name;
    }

    public virtual string getName()
    {
        return this.name;
    }

    // throws Exception
    public virtual void init(int level)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(new StringMaker().append("Available List of Animations: ").append(this.hashtable.ToString()).ToString(), this, commonStrings.INIT);
        this.setInitialized(true);
    }

    // throws Exception
    public virtual void initImageCache(ImageCache imageCache, int level)
    {
    }

    // throws Exception
    public virtual void add(string resource, BasicAnimationInterfaceFactoryInterface animationInterfaceFactoryInterface)
    {
        if (this.hashtable.containsKey(((object) resource))) {
            throw new Exception(new StringMaker().append("Resource Already Created: ").append(resource).ToString());
        }
        this.hashtable.put(resource, animationInterfaceFactoryInterface);
    }

    // throws Exception
    public virtual BasicAnimationInterfaceFactoryInterface getBasicAnimationInterfaceFactoryInstance(string resource)
    {
        object basicAnimationInterfaceFactoryInterfaceCanBeNull = this.hashtable.get(resource);
        if (basicAnimationInterfaceFactoryInterfaceCanBeNull == null) {
            return NullAnimationFactory.NULL_NOT_FOR_USE_ANIMATION_FACTORY;
        }
        return ((BasicAnimationInterfaceFactoryInterface) basicAnimationInterfaceFactoryInterfaceCanBeNull);
    }

    // throws Exception
    public virtual Rectangle getRectangle(string resource)
    {
        object rectangleCanBeNull = this.rectangleHashtable.get(resource);
        if (rectangleCanBeNull == null) {
            return RectangleFactory.SINGLETON;
        }
        return ((Rectangle) rectangleCanBeNull);
    }

    // throws Exception
    public virtual void addRectangle(string resource, Rectangle rectangle)
    {
        this.rectangleHashtable.put(resource, rectangle);
    }

    // throws Exception
    public virtual Rectangle[][] getRectangleArrayOfArrays(string resource)
    {
        return ((Rectangle[][]) this.rectangleArrayOfArraysHashtable.get(resource));
    }

    // throws Exception
    public virtual void addRectangleArrayOfArrays(string resource, Rectangle[][] rectangleArrayOfArrays)
    {
        this.rectangleArrayOfArraysHashtable.put(resource, rectangleArrayOfArrays);
    }

    public virtual bool isFeature()
    {
        return false;
    }

    public virtual bool isLoadingLevel(int level)
    {
        ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
        if (level == resourceLoadingLevelFactory.LOAD_ALL.getLevel()) {
            return true;
        } else {
            return false;
        }
    }

    public override string ToString()
    {
        return new StringMaker().append(this.GetType().FullName).append(CommonSeps.getInstance().SEMICOLON).append(CommonSeps.getInstance().SPACE).append(this.name).ToString();
    }

    public virtual ABHashtable<object, object> getHashtable()
    {
        return this.hashtable;
    }

    public virtual ABHashtable<object, object> getRectangleHashtable()
    {
        return this.rectangleHashtable;
    }

    public virtual ABHashtable<object, object> getRectangleArrayOfArraysHashtable()
    {
        return this.rectangleArrayOfArraysHashtable;
    }

    public virtual void setInitialized(bool initialized)
    {
        this.initialized = initialized;
    }

    public virtual bool isInitialized()
    {
        return this.initialized;
    }

}

