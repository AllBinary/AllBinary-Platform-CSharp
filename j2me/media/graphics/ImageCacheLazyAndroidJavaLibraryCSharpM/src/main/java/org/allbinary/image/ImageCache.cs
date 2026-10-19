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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
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
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ABSystemWrapper systemWrapper = ABSystemWrapper.getInstance();
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    public ImageCache()
    {
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
    public virtual Image get(object key)
    {
        ResourceUtil resourceUtil = ResourceUtil.getInstance();
        int? resourceId = resourceUtil.getResourceId(((string) key));
        Image image = this.getImage(resourceId);
        if (image == NullImage.NULL_IMAGE) {
            InputStream inputStream = null;
            try {
                this.logUtil.putF(Memory.getInfo(), this, this.commonStrings.GET);
                image = this.createImage(key, inputStream);
            } catch (Exception e) {
                this.logUtil.put("Exception: Trying Again After GC", this, this.commonStrings.GET, e);
                this.logUtil.putF(new StringMaker().append("InputStream: ").append(inputStream.ToString()).ToString(), this, this.commonStrings.GET);
                this.tsUtil.gc();
                this.tsUtil.gc();
                this.logUtil.putF(Memory.getInfo(), this, this.commonStrings.GET);
                System.Threading.Thread.Sleep((int) (100));
                image = this.createImage(key, inputStream);
            }
            this.hashtable.put(resourceId, image);
        }
        return image;
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
    protected virtual Image createImage(object key, InputStream inputStream)
    {
        return Image.createImageLater(((string) key), -1, -1);
    }

    public virtual bool isLazy()
    {
        throw new SystemException();
    }

}

