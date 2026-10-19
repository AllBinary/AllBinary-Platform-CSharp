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

namespace org.allbinary.game.layer.unit;

public class Unit3DecalGameResources : BasicGameResources
{
    private static readonly Unit3DecalGameResources instance = new Unit3DecalGameResources();
    private Unit3DecalGameResources()
    {
        string ROOT = "/unit_decal";
        string SMALL = "_40_by_40.png";
        string MEDIUM = SMALL;
        string SIZE_FOUR = SMALL;
        string SIZE_FIVE = SMALL;
        string SIZE_SIX = SMALL;
        string[] SIZE = new string[] { SMALL, MEDIUM, SIZE_FOUR, SIZE_FIVE, SIZE_SIX };
        base.init(ROOT, SIZE);
    }

    // throws Exception
    protected override void append(string ROOT, string sizeString)
    {
        base.append(ROOT, sizeString);
    }

    // throws Exception
    protected override string getString()
    {
        if (AndroidUtil.isAndroid()) {
            return GameGraphicsResourceUtil.getInstance().getStringForFeature(GraphicsFeatureFactory.getInstance().SPRITE_QUARTER_ROTATION_GRAPHICS);
        } else {
            return base.getString();
        }
    }

    public static BasicGameResources getInstance()
    {
        return Unit3DecalGameResources.instance;
    }

}

