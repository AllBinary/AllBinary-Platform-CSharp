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
using ChangedGameFeatureListener = org.allbinary.game.configuration.@event.ChangedGameFeatureListener;
using GameInitializedEvent = org.allbinary.game.configuration.@event.GameInitializedEvent;
using GameInitializedEventHandler = org.allbinary.game.configuration.@event.GameInitializedEventHandler;
using Features = org.allbinary.game.configuration.feature.Features;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.game.init;

public class GameInitializationUtil
{
    private static readonly GameInitializationUtil instance = new GameInitializationUtil();
    public readonly GameInitializedEvent EVENT;
    // throws Exception
    public void initDemo(AbeClientInformationInterface abeClientInformation, MyCanvas canvas, BasicBuildGameInitializerFactory gameInitializationInterfaceFactoryInterface)
    {
        MainFeatureFactory mainFeatureFactory = MainFeatureFactory.getInstance();
        if (ChangedGameFeatureListener.getInstance().isChangedFeature(mainFeatureFactory.STATIC)) {
            GameInitializationInterface gameInitializationInterface = gameInitializationInterfaceFactoryInterface.getInstance();
            Features features = Features.getInstance();
            if (features.isFeature(mainFeatureFactory.LOAD_ALL)) {
                this.initGame(abeClientInformation, canvas, gameInitializationInterfaceFactoryInterface);
            } else if (features.isFeature(mainFeatureFactory.LOAD_ONDEMAND)) {
                ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
                gameInitializationInterface.init(abeClientInformation, canvas.getCustomCommandListener(), resourceLoadingLevelFactory.LOAD_EARLY.getLevel());
                this.EVENT.setResourceLoadingLevel(resourceLoadingLevelFactory.LOAD_EARLY);
            } else {
                throw new Exception("No Loading Feature Available");
            }
            GameInitializedEventHandler.getInstance().fireEvent(this.EVENT);
        }
    }

    // throws Exception
    public void initGame(AbeClientInformationInterface abeClientInformation, MyCanvas canvas, BasicBuildGameInitializerFactory gameInitializationInterfaceFactoryInterface)
    {
        if (ChangedGameFeatureListener.getInstance().isChangedFeature(MainFeatureFactory.getInstance().STATIC)) {
            GameInitializationInterface gameInitializationInterface = gameInitializationInterfaceFactoryInterface.getInstance();
            ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
            gameInitializationInterface.init(abeClientInformation, canvas.getCustomCommandListener(), resourceLoadingLevelFactory.LOAD_ALL.getLevel());
            this.EVENT.setResourceLoadingLevel(resourceLoadingLevelFactory.LOAD_ALL);
            GameInitializedEventHandler.getInstance().fireEvent(this.EVENT);
            ChangedGameFeatureListener.getInstance().remove(MainFeatureFactory.getInstance().STATIC);
        }
    }

    public static GameInitializationUtil getInstance()
    {
        return GameInitializationUtil.instance;
    }

    public GameInitializationUtil()
    {
        this.EVENT = new GameInitializedEvent(this);
    }

}

