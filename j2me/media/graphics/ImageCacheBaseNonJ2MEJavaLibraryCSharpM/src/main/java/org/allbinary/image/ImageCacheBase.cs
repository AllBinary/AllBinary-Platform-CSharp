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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.image;

public class ImageCacheBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly ImageFactory imageFactory = ImageFactory.getInstance();
    public readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    public readonly int SIZE = 128;
    public readonly int[] widths;
    public readonly int[] heights;
    public readonly BasicArrayList[] listOfList;
    public readonly BasicArrayList[] availableListOfList;
    public int volume = 0;
    public int nextIndex = 0;
    public ImageCacheBase()
    {
        this.widths = new int[this.SIZE];
        this.heights = new int[this.SIZE];
        this.listOfList = new BasicArrayList[this.SIZE];
        this.availableListOfList = new BasicArrayList[this.SIZE];
        for (int index = this.listOfList.Length - 1; index >= 0; index--) {
            this.listOfList[index] = new BasicArrayListD();
        }
        for (int index = this.availableListOfList.Length - 1; index >= 0; index--) {
            this.availableListOfList[index] = new BasicArrayListD();
        }
    }

    protected virtual Image getImage(object resourceId)
    {
        object imageCanBeNull = this.hashtable.get(resourceId);
        if (imageCanBeNull == null) {
            return NullImage.NULL_IMAGE;
        }
        return ((Image) imageCanBeNull);
    }

    public virtual void releaseAll()
    {
        for (int index = this.listOfList.Length - 1; index >= 0; index--) {
            this.availableListOfList[index].clear();
            this.availableListOfList[index].addAllList(this.listOfList[index]);
        }
        this.logUtil.putF(new StringMaker().append("ImageCache: ").append(this.ToString()).ToString(), this, "releaseAll");
    }

    protected virtual int getIndexWH(int width, int height)
    {
        int foundIndex = -1;
        int size = this.widths.Length;
        for (int index = 0; index < size; index++) {
            if (this.widths[index] == width && this.heights[index] == height) {
                foundIndex = index;
                return foundIndex;
            }
        }
        return foundIndex;
    }

    protected virtual Image getFromAvailable(int foundIndex, int width, int height)
    {
        if (foundIndex != -1) {
            if (this.availableListOfList[foundIndex].size() > 0) {
                BasicArrayList list = this.availableListOfList[foundIndex];
                return ((Image) list.removeAt(list.size() - 1));
            }
        }
        return NullImage.NULL_IMAGE;
    }

    // throws Exception
    public virtual Image get(string caller, int width, int height)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual Image getWithKey(object key)
    {
        throw new SystemException();
    }

    // throws Exception
    protected virtual Image createImage(string caller, int width, int height)
    {
        return this.imageFactory.createImage(caller, width, height);
    }

    // throws Exception
    protected virtual Image createImageFromInputStream(object key, InputStream inputStream)
    {
        return this.imageFactory.createImageFromInputStream(key, inputStream);
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        for (int index = this.nextIndex - 1; index >= 0; index--) {
            int width = this.widths[index];
            int height = this.heights[index];
            int total = this.listOfList[index].size();
            int totalAvailable = this.availableListOfList[index].size();
            stringBuffer.append(" w: ");
            stringBuffer.appendint(width);
            stringBuffer.append(" h: ");
            stringBuffer.appendint(height);
            stringBuffer.append(CommonSeps.getInstance().SPACE);
            stringBuffer.append(CommonLabels.getInstance().TOTAL_LABEL);
            stringBuffer.appendint(total);
            stringBuffer.append(" available: ");
            stringBuffer.appendint(totalAvailable);
        }
        return stringBuffer.ToString();
    }

    public virtual ABHashtable<object, object> getHashtableP()
    {
        return this.hashtable;
    }

    public virtual void init(Image image)
    {
    }

    public virtual void initProgress()
    {
    }

}

