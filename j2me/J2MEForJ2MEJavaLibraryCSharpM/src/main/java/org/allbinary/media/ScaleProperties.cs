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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.media;

public class ScaleProperties
{
    public static readonly ScaleProperties instance = new ScaleProperties();
    public float scaleX = 1.0f;
    public float scaleY = 1.0f;
    public int scaleWidth = 0;
    public int scaleHeight = 0;
    public bool shouldScale = false;
    public override string ToString()
    {
        return new StringMaker().append(CommonLabels.getInstance().COLON_SEP).appendboolean(this.shouldScale).append("scaleX: ").appendfloat(this.scaleX).append("scaleY: ").appendfloat(this.scaleY).append("scaleWidth: ").appendint(this.scaleWidth).append("scaleHeight: ").appendint(this.scaleHeight).ToString();
    }

}

