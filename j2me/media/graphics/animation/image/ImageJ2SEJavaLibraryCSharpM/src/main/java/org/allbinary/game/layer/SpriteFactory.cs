/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using Image = javax.microedition.lcdui.Image;
//using Sprite = javax.microedition.lcdui.game.Sprite;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.layer;

public class SpriteFactory : SpriteFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly SpriteFactory instance = new SpriteFactory();
    public static SpriteFactory getInstance()
    {
        return SpriteFactory.instance;
    }

    public virtual Sprite createSprite(Image image, int frameWidth, int frameHeight)
    {
        return new Sprite(image, frameWidth, frameHeight);
    }

}

