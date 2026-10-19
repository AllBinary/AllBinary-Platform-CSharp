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
using GameFeatureChoiceGroups = org.allbinary.game.configuration.feature.GameFeatureChoiceGroups;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.opengles;

public class OpenGLOptions
{
    public virtual void init()
    {
        OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
        if (Features.getInstance().isFeature(openGLFeatureFactory.OPENGL_OPTIONS)) {
            BasicArrayList openGLMultipleList = new BasicArrayListD();
            openGLMultipleList.add(openGLFeatureFactory.OPENGL);
            GameFeatureChoiceGroups.getMultipleInstance().add("OpenGL (Complete Restart)", openGLMultipleList);
            BasicArrayList openGLVersionSelectorMultipleList = new BasicArrayListD();
            openGLVersionSelectorMultipleList.add(openGLFeatureFactory.OPENGL_AUTO_SELECT);
            openGLVersionSelectorMultipleList.add(openGLFeatureFactory.OPENGL_MINIMUM);
            GameFeatureChoiceGroups.getExclusiveInstance().add("OpenGL Version Selector", openGLVersionSelectorMultipleList);
            BasicArrayList openGLImageColorMultipleList = new BasicArrayListD();
            openGLImageColorMultipleList.add(openGLFeatureFactory.IMAGE_COLOR_DEPTH_4444);
            openGLImageColorMultipleList.add(openGLFeatureFactory.IMAGE_COLOR_DEPTH_8888);
            GameFeatureChoiceGroups.getExclusiveInstance().add("OpenGL Image Color RGBA", openGLImageColorMultipleList);
        }
    }

}

