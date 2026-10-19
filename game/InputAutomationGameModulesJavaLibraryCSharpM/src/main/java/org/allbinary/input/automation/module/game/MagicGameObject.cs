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
//using BufferedImage = java.awt.image.BufferedImage;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.input.automation.module.game;

public class MagicGameObject : MeteredGameObject, MagicGameObjectInterface
{
    private readonly string MP_LABEL = "MP:";
    public MagicGameObject(BufferedImage[] bufferedImage, int? minX, int? maxX, int? y) : base(bufferedImage, minX, maxX, y)
    {
        // base(bufferedImage, minX, maxX, y) is called from the constructor declaration
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append(this.MP_LABEL);
        stringBuffer.append(base.ToString());
        return stringBuffer.ToString();
    }

}

