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
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureControlledInterface = org.allbinary.game.configuration.feature.GameFeatureControlledInterface;
using GraphicsFeatureFactory = org.allbinary.game.configuration.feature.GraphicsFeatureFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.resource;

public class FeaturedResourceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly BasicArrayList list = new BasicArrayListD();
    public FeaturedResourceFactory()
    {
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string ANIMATION_FEATURES = "Animation Features: Vector: ";
    private readonly string IMAGE_LABEL = " Image: ";
    private readonly string IMAGE_GRAPHICS_ARRAY = "Image Array: ";
    private readonly string IMAGE_GRAPHICS_ROTATION = "Image Rotate: ";
    private readonly string SPRITE_QUARTER = " Sprite Quarter: ";
    private readonly string SPRITE_FULL = " Sprite Full: ";
    private readonly string IS_LOADING_LEVEL_LABEL = " isLoadingLevel ";
    private readonly string IS_FEATURE = " isFeature: ";
    private readonly string GAME_FEATURE_CONTROLLED = "GameFeatureControlledInterface: ";
    // throws Exception
    public virtual void init(int level)
    {
        int size = this.list.size();
        for (int index = 0; index < size; index++) {
            GameFeatureControlledInterface featureInterface = ((GameFeatureControlledInterface) this.list.objectArray[index]);
            bool isLoadingLevel = featureInterface.isLoadingLevel(level);
            bool isFeature = featureInterface.isFeature();
            this.logUtil.putF(new StringMaker().append(this.GAME_FEATURE_CONTROLLED).append(featureInterface.ToString()).append(this.IS_LOADING_LEVEL_LABEL).append(ResourceLoadingLevelFactory.getInstance().getLevelString(level)).append(CommonSeps.getInstance().COLON_SEP).appendboolean(isLoadingLevel).append(this.IS_FEATURE).appendboolean(isFeature).ToString(), this, this.commonStrings.INIT);
            if (isLoadingLevel && isFeature) {
                featureInterface.init(level);
            }
        }
        Features features = Features.getInstance();
        GraphicsFeatureFactory graphicsFeatureFactory = GraphicsFeatureFactory.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.ANIMATION_FEATURES);
        stringBuffer.appendboolean(features.isFeature(graphicsFeatureFactory.VECTOR_GRAPHICS));
        stringBuffer.append(this.IMAGE_LABEL);
        stringBuffer.appendboolean(features.isFeature(graphicsFeatureFactory.IMAGE_GRAPHICS));
        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.INIT);
        if (features.isFeature(graphicsFeatureFactory.IMAGE_GRAPHICS)) {
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(this.IMAGE_GRAPHICS_ARRAY);
            stringBuffer.appendboolean(features.isFeature(graphicsFeatureFactory.IMAGE_TO_ARRAY_GRAPHICS));
            stringBuffer.append(this.IMAGE_GRAPHICS_ROTATION);
            stringBuffer.appendboolean(features.isFeature(graphicsFeatureFactory.IMAGE_TO_ARRAY_GRAPHICS));
            stringBuffer.append(this.SPRITE_QUARTER);
            stringBuffer.appendboolean(features.isFeature(graphicsFeatureFactory.SPRITE_QUARTER_ROTATION_GRAPHICS));
            stringBuffer.append(this.SPRITE_FULL);
            stringBuffer.appendboolean(features.isFeature(graphicsFeatureFactory.SPRITE_FULL_GRAPHICS));
            this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.INIT);
        }
    }

    public virtual void clear()
    {
        this.list.clear();
    }

    public virtual void add(GameFeatureControlledInterface featureInterface)
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).append(StringUtil.getInstance().toString(featureInterface)).ToString(), this, this.commonStrings.ADD);
        this.list.add(featureInterface);
    }

    public virtual BasicArrayList getList()
    {
        return this.list;
    }

}

