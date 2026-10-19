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
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using org.allbinary.util;
using HashtableUtil = org.allbinary.util.HashtableUtil;
using PlaynImage = org.microemu.device.playn.PlaynImage;
using CoreImage = playn.core.CoreImage;

namespace org.allbinary.media.image;

public class ImageWaitCompleteUtil : ImageCompleteUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(18000);
    private readonly TimeDelayHelper allTimeDelayHelper = new TimeDelayHelper(120000);
    public ImageWaitCompleteUtil()
    {
    }

    // throws Exception
    public override void waitForImage(Image image, string name)
    {
        this.timeDelayHelper.setStartTimeTNT();
        this.waitForATime(image, name, this.timeDelayHelper);
    }

    // throws Exception
    public virtual void handleTimeout(string name)
    {
        if (this.timeDelayHelper.isTimeTNT()) {
            throw new Exception("isReady: Timeout Waiting or GameHtmlHasLoadedResourcesProcessor does not have this Image: " + name);
        }
    }

    // throws Exception
    private void waitForATime(Image image, string name, TimeDelayHelper timeDelayHelper)
    {
        PlaynImage playnImage = ((PlaynImage) image);
        CoreImage playnCoreImage = ((CoreImage) playnImage.getImage());
        while (!playnCoreImage.isReady() || playnCoreImage.width() + playnCoreImage.height() <= 0) {
            if (timeDelayHelper.isTimeTNT()) {
                throw new Exception("waitFor: Timeout Waiting or GameHtmlHasLoadedResourcesProcessor does not have this Image: " + name);
            }
        }
        if (!image.isReady()) {
            image.init(image.getImage());
        }
    }

    // throws Exception
    public virtual void waitForAll()
    {
        this.allTimeDelayHelper.setStartTimeTNT();
        ABHashtable<object, object> hashtable = GameFeatureImageCacheFactory.getInstance().getHashtableP();
        object[] objectArray = HashtableUtil.getInstance().getKeysAsArray(hashtable);
        int size = objectArray.Length;
        PreLogUtil.put("Image Total: " + size, this, "waitForAll");
        for (int index = 0; index < size; index++) {
            this.waitForATime(((Image) hashtable.get(objectArray[index])), ((string) objectArray[index]), this.allTimeDelayHelper);
        }
    }

}

