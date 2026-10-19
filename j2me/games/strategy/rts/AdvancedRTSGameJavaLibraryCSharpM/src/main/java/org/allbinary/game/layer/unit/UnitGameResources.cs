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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.layer.unit;

public class UnitGameResources : BasicGameResources
{
    public string NAME = StringUtil.getInstance().EMPTY_STRING;
    public string RESOURCE_ICON_ANIMATION = StringUtil.getInstance().EMPTY_STRING;
    public string RESOURCE_ICON_BUILD = StringUtil.getInstance().EMPTY_STRING;
    public string RESOURCE_ICON = StringUtil.getInstance().EMPTY_STRING;
    protected UnitGameResources()
    {
    }

    private static readonly string ICON = "_icon";
    private static readonly string BUILD = "_build";
    private static readonly string DESTROY = "_destroy";
    private static readonly string ICON_BUILD = "_icon" + UnitGameResources.BUILD;
    private readonly string ICON_SIZE = "_64_by_64.png";
    // throws Exception
    protected override void append(string ROOT, string sizeString)
    {
        base.append(ROOT, sizeString);
        string @string = GameGraphicsResourceUtil.getInstance().getName();
        BasicGameResources.stringBuffer.delete(0, BasicGameResources.stringBuffer.length());
        BasicGameResources.stringBuffer.append(ROOT);
        BasicGameResources.stringBuffer.append(UnitGameResources.DESTROY);
        BasicGameResources.stringBuffer.append(@string);
        BasicGameResources.stringBuffer.append(sizeString);
        this.RESOURCE_DESTROY = BasicGameResources.stringBuffer.ToString();
        BasicGameResources.stringBuffer.delete(0, BasicGameResources.stringBuffer.length());
        BasicGameResources.stringBuffer.append(UnitGameResources.ICON);
        BasicGameResources.stringBuffer.append(ROOT);
        this.RESOURCE_ICON_ANIMATION = BasicGameResources.stringBuffer.ToString();
        BasicGameResources.stringBuffer.delete(0, BasicGameResources.stringBuffer.length());
        BasicGameResources.stringBuffer.append(ROOT);
        BasicGameResources.stringBuffer.append(UnitGameResources.ICON);
        BasicGameResources.stringBuffer.append(@string);
        BasicGameResources.stringBuffer.append(this.ICON_SIZE);
        this.RESOURCE_ICON = BasicGameResources.stringBuffer.ToString();
        BasicGameResources.stringBuffer.delete(0, BasicGameResources.stringBuffer.length());
        BasicGameResources.stringBuffer.append(ROOT);
        BasicGameResources.stringBuffer.append(UnitGameResources.ICON_BUILD);
        BasicGameResources.stringBuffer.append(@string);
        BasicGameResources.stringBuffer.append(this.ICON_SIZE);
        this.RESOURCE_ICON_BUILD = BasicGameResources.stringBuffer.ToString();
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

}

