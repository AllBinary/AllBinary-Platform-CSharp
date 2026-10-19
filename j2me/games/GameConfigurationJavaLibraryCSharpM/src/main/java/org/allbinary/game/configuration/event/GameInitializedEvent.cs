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
using ResourceLoadingLevel = org.allbinary.game.resource.ResourceLoadingLevel;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.configuration.@event;

public class GameInitializedEvent : AllBinaryEventObject
{
    private ResourceLoadingLevel resourceLoadingLevel = ResourceLoadingLevelFactory.getInstance().LEVEL;
    private int level = 0;
    public GameInitializedEvent(object anyType) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
    }

    public virtual void setLevel(int level)
    {
        this.level = level;
        this.resourceLoadingLevel = ResourceLoadingLevelFactory.getInstance().LEVEL;
    }

    public virtual int getLevel()
    {
        return this.level;
    }

    public virtual void setResourceLoadingLevel(ResourceLoadingLevel resourceLoadingLevel)
    {
        this.resourceLoadingLevel = resourceLoadingLevel;
        this.level = this.resourceLoadingLevel.getLevel();
    }

    public virtual ResourceLoadingLevel getResourceLoadingLevel()
    {
        return this.resourceLoadingLevel;
    }

}

