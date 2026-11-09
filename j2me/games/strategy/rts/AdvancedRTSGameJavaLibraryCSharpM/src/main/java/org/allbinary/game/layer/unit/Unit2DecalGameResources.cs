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
using BasicGameResources = org.allbinary.game.layer.resources.BasicGameResources;
using GameGraphicsResourceUtil = org.allbinary.game.layer.resources.GameGraphicsResourceUtil;
using AndroidUtil = org.allbinary.AndroidUtil;
using GraphicsFeatureFactory = org.allbinary.game.configuration.feature.GraphicsFeatureFactory;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.layer.unit;

public class Unit2DecalGameResources : BasicGameResources
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static BasicGameResources getInstance()
    {
        if (Unit2DecalGameResources.instance == NullUtil.getInstance().NULL_OBJECT) {
            Unit2DecalGameResources.instance = new Unit2DecalGameResources();
        }
        return ((Unit2DecalGameResources) Unit2DecalGameResources.instance);
    }

    private Unit2DecalGameResources()
    {
        string ROOT = "/unit_decal";
        string SMALL = "_30_by_30.png";
        string MEDIUM = SMALL;
        string SIZE_FOUR = SMALL;
        string SIZE_FIVE = SMALL;
        string SIZE_SIX = SMALL;
        string[] SIZE = new string[] { SMALL, MEDIUM, SIZE_FOUR, SIZE_FIVE, SIZE_SIX };
        base.init(ROOT, SIZE);
    }

    // throws Exception
    public override void append(string ROOT, string sizeString)
    {
        base.append(ROOT, sizeString);
    }

    // throws Exception
    public override string getString()
    {
        if (AndroidUtil.isAndroid()) {
            return GameGraphicsResourceUtil.getInstance().getStringForFeature(GraphicsFeatureFactory.getInstance().SPRITE_QUARTER_ROTATION_GRAPHICS);
        } else {
            return base.getString();
        }
    }

}

