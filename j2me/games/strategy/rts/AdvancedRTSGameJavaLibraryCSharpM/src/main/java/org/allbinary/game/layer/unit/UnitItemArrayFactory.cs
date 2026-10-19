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
//using Image = javax.microedition.lcdui.Image;
//using ImageItem = javax.microedition.lcdui.ImageItem;
using RTSGameStrings = org.allbinary.game.layer.RTSGameStrings;
using LayerInterfaceFactoryImageItem = org.allbinary.game.layer.item.LayerInterfaceFactoryImageItem;
using RTSLayerTextAnimation = org.allbinary.game.layer.item.RTSLayerTextAnimation;
using BasicGameResources = org.allbinary.game.layer.resources.BasicGameResources;
using FlagGameResources = org.allbinary.game.layer.waypoint.FlagGameResources;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Animation = org.allbinary.animation.Animation;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using CustomItemUtil = org.allbinary.graphics.form.item.CustomItemUtil;
using ItemArraySingletonFactoryInterface = org.allbinary.graphics.form.item.ItemArraySingletonFactoryInterface;
using ImageCache = org.allbinary.image.ImageCache;
using LayerInterfaceFactoryInterface = org.allbinary.layer.LayerInterfaceFactoryInterface;

namespace org.allbinary.game.layer.unit;

public class UnitItemArrayFactory : ItemArraySingletonFactoryInterface
{
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private BasicColor basicColor = BasicColorFactory.getInstance().WHITE;
    private static readonly ABCustomItem[] ITEMS = CustomItemUtil.getInstance().CUSTOM_ITEM_ARRAY;
    private readonly BasicGameResources[] resources;
    protected UnitItemArrayFactory(BasicGameResources[] resources)
    {
        this.resources = resources;
    }

    // throws Exception
    protected virtual ABCustomItem createFlagItem(FlagGameResources flagResources, LayerInterfaceFactoryInterface layerInterfaceFactoryInterface)
    {
        string name = flagResources.NAME;
        int index = name.IndexOf(this.commonSeps.SPACE);
        if (index >= 0) {
            name = name.Substring(index);
        }
        return this.createNamedFlagItem(flagResources, name, layerInterfaceFactoryInterface);
    }

    // throws Exception
    protected virtual ABCustomItem createNamedFlagItem(FlagGameResources flagResources, string name, LayerInterfaceFactoryInterface layerInterfaceFactoryInterface)
    {
        ImageCache IMAGE_CACHE = GameFeatureImageCacheFactory.getInstance();
        Image image = IMAGE_CACHE.getWithKey(flagResources.RESOURCE_ICON);
        ABCustomItem item = new LayerInterfaceFactoryImageItem(name, image, ImageItem.LAYOUT_DEFAULT, flagResources.NAME, this.basicColor, new Animation[] { new RTSLayerTextAnimation(RTSGameStrings.getInstance().DRAGGABLE, image) }, layerInterfaceFactoryInterface);
        return item;
    }

    // throws Exception
    public virtual ABCustomItem[] getItems()
    {
        return UnitItemArrayFactory.ITEMS;
    }

    public virtual BasicGameResources[] getResources()
    {
        return this.resources;
    }

    public virtual int indexOf(BasicGameResources basicGameResources)
    {
        for (int index = this.resources.Length - 1; index >= 0; index--) {
            if (this.resources[index] == basicGameResources) {
                return index;
            }
        }
        return -1;
    }

}

