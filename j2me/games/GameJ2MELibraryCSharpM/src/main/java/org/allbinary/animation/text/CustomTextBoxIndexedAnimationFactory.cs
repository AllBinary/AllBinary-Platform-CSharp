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
//using Font = javax.microedition.lcdui.Font;
//using TextField = javax.microedition.lcdui.TextField;
using CustomTextBox = org.allbinary.graphics.form.item.CustomTextBox;
using Animation = org.allbinary.animation.Animation;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using ABToGBUtil = org.allbinary.game.canvas.ABToGBUtil;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation.text;

public class CustomTextBoxIndexedAnimationFactory : AnimationInterfaceFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public ScaleProperties scaleProperties;
    private readonly int maxLength;
    public CustomTextBoxIndexedAnimationFactory(int fontSize, int maxLength)
    {
        this.scaleProperties = new ScaleProperties();
        this.scaleProperties.scaleHeight = fontSize;
        this.maxLength = maxLength;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        ABToGBUtil abToGBUtil = ABToGBUtil.getInstance();
        AllBinaryGameCanvas abCanvas = ((AllBinaryGameCanvas) abToGBUtil.abCanvas);
        Font font = Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, this.scaleProperties.scaleHeight);
        CustomTextBox customTextBox = new CustomTextBox2(abCanvas.getCustomCommandListener(), StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING, this.maxLength, TextField.ANY, font, abCanvas.getLayerManager().getBackgroundBasicColor(), abCanvas.getLayerManager().getForegroundBasicColor());
        return new CustomTextBoxIndexedAnimation(customTextBox);
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
        int fontSize = this.scaleProperties.scaleHeight;
        this.scaleProperties = scaleProperties;
        if (this.scaleProperties.scaleHeight < 6) {
            this.scaleProperties.scaleHeight = fontSize;
        }
    }

}

