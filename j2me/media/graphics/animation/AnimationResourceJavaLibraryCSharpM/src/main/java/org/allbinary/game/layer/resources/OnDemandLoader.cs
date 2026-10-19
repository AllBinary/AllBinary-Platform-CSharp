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
using Features = org.allbinary.game.configuration.feature.Features;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using GameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory = org.allbinary.game.layer.GameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory;
using LayerPlacementInterfaceBasicArrayListFactoryInterface = org.allbinary.game.layer.LayerPlacementInterfaceBasicArrayListFactoryInterface;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using ImageCache = org.allbinary.image.ImageCache;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.layer.resources;

public class OnDemandLoader
{
    private readonly OnDemandResourcesFactory onDemandResourcesFactory;
    private readonly GameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory gameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory;
    private readonly BaseResourceAnimationInterfaceFactoryInterfaceFactory resourceAnimationInterfaceFactoryInterfaceFactory;
    public OnDemandLoader(OnDemandResourcesFactory onDemandResourcesFactory, GameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory gameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory, BaseResourceAnimationInterfaceFactoryInterfaceFactory resourceAnimationInterfaceFactoryInterfaceFactory)
    {
        this.onDemandResourcesFactory = onDemandResourcesFactory;
        this.gameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory = gameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory;
        this.resourceAnimationInterfaceFactoryInterfaceFactory = resourceAnimationInterfaceFactoryInterfaceFactory;
    }

    // throws Exception
    public virtual void init(ImageCache imageCache, int level, string loadingString)
    {
        ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
        if (Features.getInstance().isFeature(MainFeatureFactory.getInstance().LOAD_ALL)) {
            if (this.resourceAnimationInterfaceFactoryInterfaceFactory.isInitialized()) {
                return;
            }
            this.initAll(imageCache, loadingString);
        } else if (level != resourceLoadingLevelFactory.LOAD_ALL.getLevel()) {
            LayerPlacementInterfaceBasicArrayListFactoryInterface layerPlacementInterfaceBasicArrayListFactoryInterface = this.gameLayerPlacementInterfaceBasicArrayListFactoryInterfaceFactory.getInstance(level);
            this.initLevel(layerPlacementInterfaceBasicArrayListFactoryInterface, imageCache, level, loadingString);
        }
    }

    // throws Exception
    private void initAll(ImageCache imageCache, string loadingString)
    {
        int index = 0;
        int portion = 120;
        OnDemandResources onDemandResources = null;
        for (int onDemandIndex = this.onDemandResourcesFactory.size(); --onDemandIndex >= 0; ) {
            onDemandResources = this.onDemandResourcesFactory.remove(onDemandIndex);
            if (onDemandResources != OnDemandResources.NULL_ON_DEMAND_RESOURCES) {
                index = onDemandResources.initAt(imageCache, this.resourceAnimationInterfaceFactoryInterfaceFactory, portion, loadingString, index);
            }
        }
    }

    // throws Exception
    private void initLevel(LayerPlacementInterfaceBasicArrayListFactoryInterface layerPlacementInterfaceBasicArrayListFactoryInterface, ImageCache imageCache, int level, string loadingString)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        int portion = 120;
        int index = 0;
        int[] onDemandArray = layerPlacementInterfaceBasicArrayListFactoryInterface.getOnDemandResources();
        PreLogUtil.put(new StringMaker().append(commonStrings.START).appendint(onDemandArray.Length).ToString(), this, "initLevel");
        OnDemandResources onDemandResources = null;
        for (int onDemandIndex = onDemandArray.Length; --onDemandIndex >= 0; ) {
            onDemandResources = this.onDemandResourcesFactory.remove(onDemandArray[onDemandIndex]);
            if (onDemandResources != OnDemandResources.NULL_ON_DEMAND_RESOURCES) {
                index = onDemandResources.initAt(imageCache, this.resourceAnimationInterfaceFactoryInterfaceFactory, portion, loadingString, index);
            }
        }
    }

}

