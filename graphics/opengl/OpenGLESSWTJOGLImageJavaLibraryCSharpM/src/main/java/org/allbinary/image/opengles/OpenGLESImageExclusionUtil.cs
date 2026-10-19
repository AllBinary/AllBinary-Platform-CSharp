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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.image.opengles;

public class OpenGLESImageExclusionUtil
{
    private static readonly OpenGLESImageExclusionUtil instance = new OpenGLESImageExclusionUtil();
    public static OpenGLESImageExclusionUtil getInstance()
    {
        return OpenGLESImageExclusionUtil.instance;
    }

    private readonly string EXCLUSION = "font";
    public readonly BasicArrayList list = new BasicArrayListD();
    private OpenGLESImageExclusionUtil()
    {
    }

    public virtual bool isCustomScaling(Image image)
    {
        string imageName = image.getName();
        bool isNormalScaling = this.list.size() == 0 || imageName.StartsWith(this.EXCLUSION);
        if (isNormalScaling) {
            return false;
        } else {
            int size = this.list.size();
            string name = null;
            for (int index = 0; index < size; index++) {
                name = ((string) this.list.get(index));
                if (imageName.StartsWith(name)) {
                    isNormalScaling = true;
                }
            }
        }
        if (isNormalScaling) {
            return false;
        } else {
            return true;
        }
    }

}

