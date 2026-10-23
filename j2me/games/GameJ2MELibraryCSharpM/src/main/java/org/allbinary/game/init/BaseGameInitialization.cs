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
//using CommandListener = javax.microedition.lcdui.CommandListener;
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using ChangedGameFeatureListener = org.allbinary.game.configuration.@event.ChangedGameFeatureListener;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using PlatformInputMappingFactory = org.allbinary.game.input.PlatformInputMappingFactory;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using FeaturedResourceRelativeRelationshipFactory = org.allbinary.game.resource.FeaturedResourceRelativeRelationshipFactory;
using ResourceInitialization = org.allbinary.game.resource.ResourceInitialization;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;
using CompleteMotionGestureInputToGameMotionGestureInput = org.allbinary.input.motion.CompleteMotionGestureInputToGameMotionGestureInput;
using BasicTouchInputFactory = org.allbinary.input.motion.button.BasicTouchInputFactory;
using CancelTouchButtonInputFactory = org.allbinary.input.motion.button.CancelTouchButtonInputFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.game.init;

public class BaseGameInitialization : GameInitializationInterface
{
    public static readonly BaseGameInitialization NULL_BASE_GAME_INITIALIZATION = new BaseGameInitialization(new ResourceInitialization[0], 0);
    public readonly ResourceInitialization[] resourceInitializationArray;
    private readonly int portion;
    private bool initialized = false;
    public readonly int EARLY_RESOURCES = 0;
    public readonly int GAME_RESOURCES = 1;
    public readonly int EARLY_CHANGABLE_RESOURCES = 2;
    public readonly int GAME_CHANGABLE_RESOURCES = 3;
    public BaseGameInitialization(ResourceInitialization[] resourceInitializationArray, int portion)
    {
        this.resourceInitializationArray = resourceInitializationArray;
        this.portion = portion;
    }

    // throws Exception
    public virtual void initKey(int portion)
    {
    }

    // throws Exception
    public virtual void initKeyMapping(AbeClientInformationInterface abeClientInformation, int portion)
    {
        if (ChangedGameFeatureListener.getInstance().isChangedFeature(InputFeatureFactory.getInstance().INPUT_MAPPING)) {
            PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().init(abeClientInformation);
            ProgressCanvasFactory.getInstance().addNormalPortion(50, "Game Keys");
            ChangedGameFeatureListener.getInstance().remove(InputFeatureFactory.getInstance().INPUT_MAPPING);
        }
    }

    // throws Exception
    public virtual void init(AbeClientInformationInterface abeClientInformation, CommandListener commandListener, int level)
    {
        ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
        if (!this.isInitialized() && (level == resourceLoadingLevelFactory.LOAD_ALL.getLevel() || level == resourceLoadingLevelFactory.LOAD_EARLY.getLevel())) {
            int localPortion = 40;
            if (level == resourceLoadingLevelFactory.LOAD_EARLY.getLevel()) {
                localPortion = 8;
            }
            this.setInitialized(true);
            this.initKey(this.getPortion());
            this.initKeyMapping(abeClientInformation, this.getPortion());
            GameKeyEventFactory.getInstance().init();
            ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
            progressCanvas.addNormalPortion(localPortion, "Game Key Events");
            BasicTouchInputFactory.getInstance().init(PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping());
            CancelTouchButtonInputFactory.getInstance();
            progressCanvas.addNormalPortion(localPortion, "Touch Input");
            CompleteMotionGestureInputToGameMotionGestureInput.getInstance().init();
            progressCanvas.addNormalPortion(localPortion, "Motion Input");
            GameFeatureImageCacheFactory.init();
            progressCanvas.addNormalPortion(localPortion, "Image Cache");
            this.resourceInitializationArray[this.EARLY_RESOURCES].init();
        }
    }

    private bool gameInitialized = false;
    private bool allLoaded = false;
    // throws Exception
    public virtual void resourceInitialization(int level)
    {
        ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
        if (this.resourceAnimationChange() && level == resourceLoadingLevelFactory.LOAD_EARLY.getLevel()) {
            this.clearResources();
            this.resourceInitializationArray[this.EARLY_CHANGABLE_RESOURCES].init();
        }
        if (this.resourceAnimationChange() && level == resourceLoadingLevelFactory.LOAD_ALL.getLevel()) {
            if (this.allLoaded) {
                this.clearResources();
            }
            if (FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().getList().size() == 0) {
                this.resourceInitializationArray[this.EARLY_CHANGABLE_RESOURCES].init();
            }
            this.resourceInitializationArray[this.GAME_CHANGABLE_RESOURCES].init();
            this.allLoaded = true;
        }
    }

    public virtual bool resourceAnimationChange()
    {
        ChangedGameFeatureListener changedGameFeatureListener = ChangedGameFeatureListener.getInstance();
        GameConfigurationCentral gameConfigurationCentral = GameConfigurationCentral.getInstance();
        if (changedGameFeatureListener.isChangedGameConfiguration(gameConfigurationCentral.SCALE)) {
            return true;
        }
        if (ChangedGameFeatureListener.getInstance().isChangedFeature(MainFeatureFactory.getInstance().STATIC)) {
            return true;
        }
        return false;
    }

    private void clearResources()
    {
        this.allLoaded = false;
        GameFeatureImageCacheFactory.releaseAll();
        FeaturedAnimationInterfaceFactoryInterfaceFactory featuredAnimationInterfaceFactoryInterfaceFactory = FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance();
        featuredAnimationInterfaceFactoryInterfaceFactory.clear();
        FeaturedResourceRelativeRelationshipFactory.getInstance().clear();
    }

    public virtual void setGameInitialized(bool gameInitialized)
    {
        this.gameInitialized = gameInitialized;
    }

    public virtual bool isGameInitialized()
    {
        return this.gameInitialized;
    }

    public virtual int getPortion()
    {
        return this.portion;
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

