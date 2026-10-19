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

namespace org.allbinary.game.configuration.feature;

public class GameFeatureFactory
{
    private static readonly GameFeatureFactory instance = new GameFeatureFactory();
    public static GameFeatureFactory getInstance()
    {
        return GameFeatureFactory.instance;
    }

    private GameFeatureFactory()
    {
    }

    public readonly GameFeature SOUND = new GameFeature("Sound");
    public readonly GameFeature MUSIC = new GameFeature("Music");
    public readonly Feature SCREEN_SHAKE = new Feature("Screen Shake");
    public readonly Feature POST_IMAGE_LOADING_MODIFICATION = new Feature("Post Image Loading Modification (Scaling, Rotation, or Other)");
    public readonly GameFeature HEALTH_BARS = new GameFeature("Health Bars");
    public readonly GameFeature DAMAGE_FLOATERS = new GameFeature("Damage Floaters");
    public readonly GameFeature GAME_INPUT_LAYER_PROCESSOR = new GameFeature("Game Input Layer Processor");
    public readonly GameFeature ARTIFICIAL_INTELLEGENCE_PROCESSOR = new GameFeature("Artificial Intelligence Layer Processor");
    public readonly GameFeature COLLIDABLE_INTERFACE_LAYER_PROCESSOR = new GameFeature("Collidable Interface Layer Processor");
    public readonly GameFeature TICKABLE_LAYER_PROCESSOR = new GameFeature("Tickable Layer Processor");
    public readonly GameFeature CHEATING = new GameFeature("Cheating");
    public readonly GameFeature DROPPED_ITEMS = new GameFeature("Drops");
    public readonly GameFeature DROPPED_ITEMS_FROM_DEATH = new GameFeature("Drops from Dead");
    public readonly GameFeature TEST_DESTROYED_LAYER_PROCESSOR = new GameFeature("Destroyed Layer Processor");
    public readonly GameFeature COLLISIONS_WITH_SOURCE = new GameFeature("Allow Collisions With Source");
    public readonly GameFeature COLLISIONS_FORCED_TWO_DIMENSIONAL = new GameFeature("Collisions Forced Two Dimensional");
}

