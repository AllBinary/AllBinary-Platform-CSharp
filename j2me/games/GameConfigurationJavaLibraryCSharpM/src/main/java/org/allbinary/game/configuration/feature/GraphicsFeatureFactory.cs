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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.configuration.feature;

public class GraphicsFeatureFactory
{
    private static readonly GraphicsFeatureFactory instance = new GraphicsFeatureFactory();
    public static GraphicsFeatureFactory getInstance()
    {
        return GraphicsFeatureFactory.instance;
    }

    private GraphicsFeatureFactory()
    {
    }

    public readonly GraphicsFeature NONE = new GraphicsFeature(StringUtil.getInstance().NULL_STRING);
    public readonly GraphicsFeature TRANSPARENT_IMAGE_CREATION = new GraphicsFeature("Transparent Image Creation");
    public readonly GraphicsFeature IMAGE_GRAPHICS = new GraphicsFeature("Image Graphics");
    public readonly GraphicsFeature IMAGE_ROTATION_ON_THE_FLY = new GraphicsFeature("Image Rotated On The Fly");
    public readonly GraphicsFeature IMAGE_TO_ARRAY_GRAPHICS = new GraphicsFeature("Image To Array Graphics");
    public readonly GraphicsFeature SPRITE_QUARTER_ROTATION_GRAPHICS = new GraphicsFeature("Sprite Quarter Rotation Graphics");
    public readonly GraphicsFeature SPRITE_FULL_GRAPHICS = new GraphicsFeature("Sprite Full Rotation Graphics");
    public readonly GraphicsFeature VECTOR_GRAPHICS = new GraphicsFeature("BasicArrayList Graphics");
    public readonly GraphicsFeature VECTOR_TO_IMAGE_GRAPHICS = new GraphicsFeature("BasicArrayList To Image Graphics");
}

