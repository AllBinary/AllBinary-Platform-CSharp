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
//using GL = javax.microedition.khronos.opengles.GL;
//using ChoiceGroupImageFactory = javax.microedition.lcdui.ChoiceGroupImageFactory;
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using Features = org.allbinary.game.configuration.feature.Features;

namespace org.allbinary.image;

public class ChoiceGroupImageUtil
{
    private static readonly ChoiceGroupImageUtil instance = new ChoiceGroupImageUtil();
    public static ChoiceGroupImageUtil getInstance()
    {
        return ChoiceGroupImageUtil.instance;
    }

    public virtual void init()
    {
        Features features = Features.getInstance();
        ChoiceGroupImageFactory choiceGroupFactory = ChoiceGroupImageFactory.getInstance();
        Image[] imageArray = choiceGroupFactory.getImageArray();
        if (features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
            PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
            int size = imageArray.Length;
            for (int index = 0; index < size; index++) {
                imageArray[index] = preResourceImageUtil.encapsulate(imageArray[index]);
            }
            choiceGroupFactory.init(imageArray);
        }
    }

    public virtual void update(GL gl)
    {
        Features features = Features.getInstance();
        ChoiceGroupImageFactory choiceGroupFactory = ChoiceGroupImageFactory.getInstance();
        Image[] imageArray = choiceGroupFactory.getImageArray();
        if (features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
            PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
            int size = imageArray.Length;
            for (int index = 0; index < size; index++) {
                preResourceImageUtil.updateGL(gl, imageArray[index]);
            }
        }
        choiceGroupFactory.init(imageArray);
    }

    public virtual void update(Graphics graphics)
    {
        Features features = Features.getInstance();
        ChoiceGroupImageFactory choiceGroupFactory = ChoiceGroupImageFactory.getInstance();
        Image[] imageArray = choiceGroupFactory.getImageArray();
        if (features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
            PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
            int size = imageArray.Length;
            for (int index = 0; index < size; index++) {
                preResourceImageUtil.update(graphics, imageArray[index]);
            }
        }
        choiceGroupFactory.init(imageArray);
    }

}

