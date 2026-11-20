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
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Memory = org.allbinary.system.Memory;

namespace org.allbinary.canvas;

public class SpecialMessageUtil
{
    private static readonly SpecialMessageUtil SINGLETON = new SpecialMessageUtil();
    public static SpecialMessageUtil getInstance()
    {
        return SpecialMessageUtil.SINGLETON;
    }

    public virtual string get()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(Memory.getInfo());
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(GameStatisticsFactory.getInstance().ToString());
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(" Option: ");
        if (Features.getInstance().isDefault(OpenGLFeatureFactory.getInstance().OPENGL_AUTO_SELECT)) {
            stringBuffer.append(OpenGLFeatureFactory.getInstance().OPENGL_AUTO_SELECT.getName());
        } else {
            stringBuffer.append(OpenGLFeatureFactory.getInstance().OPENGL_MINIMUM.getName());
        }
        return stringBuffer.ToString();
    }

}

