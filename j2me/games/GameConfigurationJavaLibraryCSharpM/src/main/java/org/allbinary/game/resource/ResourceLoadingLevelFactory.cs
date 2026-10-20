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

namespace org.allbinary.game.resource;

public class ResourceLoadingLevelFactory
{
    private static readonly ResourceLoadingLevelFactory instance = new ResourceLoadingLevelFactory();
    public static ResourceLoadingLevelFactory getInstance()
    {
        return ResourceLoadingLevelFactory.instance;
    }

    public readonly ResourceLoadingLevel LOAD_EARLY = new ResourceLoadingLevel("Load Early", int.MaxValue);
    public readonly ResourceLoadingLevel LOAD_TOUCH = new ResourceLoadingLevel("Load Touch", int.MaxValue - 1);
    public readonly ResourceLoadingLevel LOAD_GAME = new ResourceLoadingLevel("Load Game", int.MaxValue - 2);
    public readonly ResourceLoadingLevel LEVEL = new ResourceLoadingLevel("Level", int.MaxValue - 99);
    public readonly ResourceLoadingLevel MAX_LEVEL = new ResourceLoadingLevel("Max Level", int.MaxValue - 100);
    public readonly ResourceLoadingLevel LOAD_ALL = new ResourceLoadingLevel("Load All", -1);
    private readonly ResourceLoadingLevel[] RESOURCE_LOADING_LEVEL_ARRAY;
    public virtual string getLevelString(int level)
    {
        for (int index = 0; index < this.RESOURCE_LOADING_LEVEL_ARRAY.Length; index++) {
            if (level == this.RESOURCE_LOADING_LEVEL_ARRAY[index].getLevel()) {
                return this.RESOURCE_LOADING_LEVEL_ARRAY[index].getName();
            }
        }
        return (level).ToString();
    }

    public ResourceLoadingLevelFactory()
    {
        this.RESOURCE_LOADING_LEVEL_ARRAY = new ResourceLoadingLevel[] { this.LOAD_ALL, this.MAX_LEVEL, this.LEVEL, this.LOAD_GAME, this.LOAD_TOUCH, this.LOAD_EARLY };
    }

}

