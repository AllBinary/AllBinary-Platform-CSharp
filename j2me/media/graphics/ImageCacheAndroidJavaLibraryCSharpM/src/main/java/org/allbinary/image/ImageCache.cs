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
//using InputStream = java.io.InputStream;
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using TsUtil = org.allbinary.TsUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using GDResources = org.allbinary.game.gd.resource.GDResources;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Memory = org.allbinary.system.Memory;

namespace org.allbinary.image;

public class ImageCache : ImageCacheBase
{
    public static readonly ImageCache NULL_IMAGE_CACHE = new ImageCache();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ABSystemWrapper systemWrapper = ABSystemWrapper.getInstance();
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    public ImageCache()
    {
    }

    public virtual void addListener(object renderer)
    {
    }

    public virtual int getIndex(object key)
    {
        GDResources gdResources = GDResources.getInstance();
        string[] resourceStringArray = gdResources.resourceStringArray;
        int size = resourceStringArray.Length;
        for (int index = 0; index < size; index++) {
            if (resourceStringArray[index] == key) {
                return index;
            }
        }
        this.logUtil.putF(new StringMaker().append("unable to find key: ").append(StringUtil.getInstance().toString(key)).ToString(), this, this.commonStrings.RUN);
        throw new SystemException();
    }

    // throws Exception
    public override Image get(string caller, int width, int height)
    {
        int foundIndex = this.getIndexWH(width, height);
        Image image = this.getFromAvailable(foundIndex, width, height);
        if (image == NullImage.NULL_IMAGE) {
            this.volume += width * height;
            if (this.volume > 32000) {
                this.tsUtil.gc();
                this.volume = 0;
            }
            image = this.createImage(caller, width, height);
            if (foundIndex == -1) {
                foundIndex = this.nextIndex;
                this.widths[this.nextIndex] = width;
                this.heights[this.nextIndex] = height;
                this.nextIndex++;
            }
            this.listOfList[foundIndex].add(image);
        }
        return image;
    }

    // throws Exception
    public override Image getWithKey(object key)
    {
        ResourceUtil resourceUtil = ResourceUtil.getInstance();
        int? resourceId = resourceUtil.getResourceId(((string) key));
        Image image = this.getImage(resourceId);
        if (image == NullImage.NULL_IMAGE) {
            InputStream inputStream = resourceUtil.getResourceAsStream(((string) key));
            try {
                this.logUtil.putF(Memory.getInfo(), this, this.commonStrings.GET);
                image = this.createImageFromInputStream(key, inputStream);
            } catch (Exception e) {
                this.logUtil.put("Exception: Trying Again After GC", this, this.commonStrings.GET, e);
                this.logUtil.putF(new StringMaker().append("InputStream: ").append(StringUtil.getInstance().toString(inputStream)).ToString(), this, this.commonStrings.GET);
                this.tsUtil.gc();
                this.tsUtil.gc();
                this.logUtil.putF(Memory.getInfo(), this, this.commonStrings.GET);
                System.Threading.Thread.Sleep((int) (100));
                image = this.createImageFromInputStream(key, inputStream);
            }
            inputStream.close();
            this.hashtable.put(resourceId, image);
        }
        return image;
    }

    public virtual void runTask()
    {
    }

    public virtual bool isLazy()
    {
        return false;
    }

}

