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
using J2MEUtil = org.allbinary.J2MEUtil;
using TsUtil = org.allbinary.TsUtil;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using GDResources = org.allbinary.game.gd.resource.GDResources;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Memory = org.allbinary.system.Memory;

namespace org.allbinary.image;

public class ImageCache : ImageCacheBase
{
    public static readonly ImageCache NULL_IMAGE_CACHE = new ImageCache();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
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
            int[] widths = this.widths;
            if (this.nextIndex > widths.Length - 1) {
                if (foundIndex == -1) {
                    foundIndex = this.nextIndex;
                    widths[this.nextIndex] = width;
                    this.heights[this.nextIndex] = height;
                    this.nextIndex++;
                }
                this.listOfList[foundIndex].add(image);
            }
        }
        return image;
    }

    // throws Exception
    public override Image getWithKey(object key)
    {
        Image image = this.getImage(key);
        if (image == NullImage.NULL_IMAGE) {
            ResourceUtil resourceUtil = ResourceUtil.getInstance();
            InputStream resourceInputStream = resourceUtil.getResourceAsStream(((string) key));
            if (resourceInputStream == null) {
                throw new SystemException(new StringMaker().append("Image resource is not available for key: ").append(StringUtil.getInstance().toString(key)).ToString());
            }
            try {
                image = this.createImageFromInputStream(key, resourceInputStream);
            } catch (Exception e) {
                this.logUtil.put("Exception: Trying Again After GC", this, this.commonStrings.GET, e);
                this.logUtil.putF(new StringMaker().append("InputStream: ").append(StringUtil.getInstance().toString(resourceInputStream)).ToString(), this, this.commonStrings.GET);
                this.tsUtil.gc();
                this.tsUtil.gc();
                this.logUtil.putF(Memory.getInfo(), this, this.commonStrings.GET);
                System.Threading.Thread.Sleep((int) (100));
                image = this.createImageFromInputStream(key, resourceInputStream);
            }
            if (J2MEUtil.isHTML()) {
            } else {
                resourceInputStream.close();
            }
            this.hashtable.put(key, image);
        }
        return image;
    }

    // throws Exception
    public virtual void loadImageForAnimation()
    {
    }

    public virtual void progressEnded()
    {
    }

    public virtual void runTask()
    {
    }

    public virtual bool isLazy()
    {
        return false;
    }

}

