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
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using HashtableUtil = org.allbinary.util.HashtableUtil;
using PlaynImage = org.microemu.device.playn.PlaynImage;

namespace org.allbinary.media.image;

public class ImageCompleteUtil
{
    private static readonly ImageCompleteUtil instance = new ImageCompleteUtil();
    public static ImageCompleteUtil getInstance()
    {
        return ImageCompleteUtil.instance;
    }

    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(18000);
    private readonly TimeDelayHelper allTimeDelayHelper = new TimeDelayHelper(120000);
    // throws Exception
    public virtual void waitForImage(Image image, string name)
    {
        this.timeDelayHelper.setStartTime();
        this.waitForATime(image, name, this.timeDelayHelper);
    }

    // throws Exception
    public virtual bool isReady(Image image, string name, TimeDelayHelper timeDelayHelper)
    {
        PlaynImage playnImage = ((PlaynImage) image);
        if (!playnImage.getImage().isReady() && playnImage.getImage().width() + playnImage.getImage().height() == 0) {
            if (timeDelayHelper.isTime()) {
                throw new Exception("isReady: Timeout Waiting or GameHtmlHasLoadedResourcesProcessor does not have this Image: " + name);
            }
            return false;
        }
        return true;
    }

    // throws Exception
    private void waitForATime(Image image, string name, TimeDelayHelper timeDelayHelper)
    {
        PlaynImage playnImage = ((PlaynImage) image);
        while (!playnImage.getImage().isReady() && playnImage.getImage().width() + playnImage.getImage().height() == 0) {
            if (timeDelayHelper.isTime()) {
                throw new Exception("waitFor: Timeout Waiting or GameHtmlHasLoadedResourcesProcessor does not have this Image: " + name);
            }
        }
    }

    // throws Exception
    public virtual void waitForAll()
    {
        this.allTimeDelayHelper.setStartTime();
        Hashtable hashtable = GameFeatureImageCacheFactory.getInstance().getHashtable();
        object[] objectArray = HashtableUtil.getInstance().getKeysAsArray(hashtable);
        int size = objectArray.Length;
        PreLogUtil.put("Total: " + size, this, "waitForAll");
        for (int index = 0; index < size; index++) {
            this.waitForATime(((Image) hashtable.get(objectArray[index])), ((string) objectArray[index]), this.allTimeDelayHelper);
        }
    }

}

