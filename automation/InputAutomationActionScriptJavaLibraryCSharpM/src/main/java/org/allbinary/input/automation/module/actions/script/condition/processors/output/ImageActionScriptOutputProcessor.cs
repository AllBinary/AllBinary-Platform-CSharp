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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using InputImageIOInterfaceFactory = org.allbinary.input.media.image.InputImageIOInterfaceFactory;
using InputImageType = org.allbinary.input.media.image.InputImageType;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ImageIOInterface = org.allbinary.media.image.io.ImageIOInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.module.actions.script.condition.processors.output;

public class ImageActionScriptOutputProcessor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private ImageActionScriptOutputProcessor()
    {
    }

    // throws Exception
    public static void process(ImageActionScriptOutputInterface imageActionScriptOutputInterface, long? frame)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        logUtil.putF("Start - Processing at: " + imageActionScriptOutputInterface.ToString(), "ImageActionScriptOutputProcessor", commonStrings.PROCESS);
        ImageTypes imageTypes = imageActionScriptOutputInterface.getImageTypes();
        BasicArrayList vector = imageTypes.getVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            InputImageType imageType = ((InputImageType) vector.get(index));
            ImageIOInterface imageIOInterface = InputImageIOInterfaceFactory.getInstance(imageType);
            imageIOInterface.save(frame);
        }
    }

}

