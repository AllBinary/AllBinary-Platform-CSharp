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
//using Image = javax.microedition.lcdui.Image;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using PlaynImage = org.microemu.device.playn.PlaynImage;
using CoreImage = playn.core.CoreImage;

namespace org.allbinary.media.image;

public class ImageCompleteUtil
{
    private static readonly ImageCompleteUtil instance = new ImageCompleteUtil();
    public static ImageCompleteUtil getInstance()
    {
        return ImageCompleteUtil.instance;
    }

    public readonly string ISREADY = "isReady";
    // throws Exception
    public virtual void waitForImage(Image image, string name)
    {
    }

    private readonly string COMPLETE = "Image loading complete for: ";
    // throws Exception
    public virtual bool isReady(Image image, string name, TimeDelayHelper timeDelayHelper)
    {
        PlaynImage playnImage = ((PlaynImage) image);
        CoreImage playnCoreImage = ((CoreImage) playnImage.getImage());
        if (!playnCoreImage.isReady() || playnCoreImage.width() + playnCoreImage.height() <= 0) {
            this.handleTimeout(name);
            return false;
        }
        if (!image.isReady()) {
            image.init(image.getImage());
            if (!image.isReady()) {
                PreLogUtil.put("Waiting for Not Ready Image: " + image.getName(), this, this.ISREADY);
            }
        }
        CommonStrings commonStrings = CommonStrings.getInstance();
        PreLogUtil.put(this.COMPLETE + image.getName(), this, commonStrings.SUCCESS);
        return true;
    }

    // throws Exception
    public virtual void handleTimeout(string name)
    {
    }

    // throws Exception
    public virtual void waitForAll()
    {
    }

}

