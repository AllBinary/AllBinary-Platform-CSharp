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
using GraphicsFeature = org.allbinary.game.configuration.feature.GraphicsFeature;
using GraphicsFeatureFactory = org.allbinary.game.configuration.feature.GraphicsFeatureFactory;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using OpenGLFeatureUtil = org.allbinary.graphics.opengles.OpenGLFeatureUtil;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.layer.resources;

public class GameGraphicsResourceUtil
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameGraphicsResourceUtil getInstance()
    {
        if (GameGraphicsResourceUtil.instance == NullUtil.getInstance().NULL_OBJECT) {
            GameGraphicsResourceUtil.instance = new GameGraphicsResourceUtil();
        }
        return ((GameGraphicsResourceUtil) GameGraphicsResourceUtil.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string SPRITE = "_sprite";
    public readonly string QUARTER = "_quarter";
    private string name = StringUtil.getInstance().EMPTY_STRING;
    public GameGraphicsResourceUtil()
    {
        try {
            this.name = this.getString();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
    }

    // throws Exception
    private string getString()
    {
        GraphicsFeatureFactory graphicsFeatureFactory = GraphicsFeatureFactory.getInstance();
        GraphicsFeature graphicsFeature = graphicsFeatureFactory.NONE;
        Features features = Features.getInstance();
        if (features.isFeature(graphicsFeatureFactory.IMAGE_TO_ARRAY_GRAPHICS)) {
            graphicsFeature = graphicsFeatureFactory.IMAGE_TO_ARRAY_GRAPHICS;
        } else if (features.isFeature(graphicsFeatureFactory.SPRITE_FULL_GRAPHICS)) {
            graphicsFeature = graphicsFeatureFactory.SPRITE_FULL_GRAPHICS;
        } else if (features.isFeature(graphicsFeatureFactory.SPRITE_QUARTER_ROTATION_GRAPHICS)) {
            graphicsFeature = graphicsFeatureFactory.SPRITE_QUARTER_ROTATION_GRAPHICS;
        } else if (features.isFeature(graphicsFeatureFactory.IMAGE_ROTATION_ON_THE_FLY)) {
            graphicsFeature = graphicsFeatureFactory.IMAGE_ROTATION_ON_THE_FLY;
        }
        return this.getStringForFeature(graphicsFeature);
    }

    // throws Exception
    public virtual string getStringForFeature(GraphicsFeature graphicsFeature)
    {
        StringMaker stringBuffer = new StringMaker();
        GraphicsFeatureFactory graphicsFeatureFactory = GraphicsFeatureFactory.getInstance();
        stringBuffer.delete(0, stringBuffer.length());
        Features features = Features.getInstance();
        if (features.isFeature(graphicsFeatureFactory.VECTOR_GRAPHICS)) {
        } else if (features.isFeature(graphicsFeatureFactory.IMAGE_GRAPHICS)) {
            if (graphicsFeature == graphicsFeatureFactory.IMAGE_TO_ARRAY_GRAPHICS || graphicsFeature == graphicsFeatureFactory.IMAGE_ROTATION_ON_THE_FLY) {
            } else if (graphicsFeature == graphicsFeatureFactory.SPRITE_FULL_GRAPHICS) {
                stringBuffer.append(this.SPRITE);
            } else if (graphicsFeature == graphicsFeatureFactory.SPRITE_QUARTER_ROTATION_GRAPHICS) {
                stringBuffer.append(this.QUARTER);
                stringBuffer.append(this.SPRITE);
            } else {
                throw new Exception("None/Unknown Sub Image Resource Type Specified");
            }
        } else if (OpenGLFeatureUtil.getInstance().isAnyThreed()) {
            stringBuffer.append(CanvasStrings.getInstance().OBJ_MODEL);
        } else {
            throw new Exception("None/Unknown Main Image Resource Type Specified");
        }
        return stringBuffer.ToString();
    }

    public virtual string getName()
    {
        return this.name;
    }

}

