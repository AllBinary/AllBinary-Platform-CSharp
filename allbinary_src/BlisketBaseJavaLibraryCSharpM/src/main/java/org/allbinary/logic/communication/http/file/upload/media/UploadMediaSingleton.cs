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
using System.Runtime.CompilerServices;
using java.util;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using MediaData = org.allbinary.logic.visual.media.MediaData;
using MediaIOUtil = org.allbinary.logic.visual.media.MediaIOUtil;
using MediaTypeData = org.allbinary.logic.visual.media.MediaTypeData;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.communication.http.file.upload.media;

public class UploadMediaSingleton
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private HashMap<object, object> readerFileTypesHashMap;
    private HashMap<object, object> writerFileTypesHashMap;
    private static UploadMediaSingleton uploadMedia = null;
    private UploadMediaSingleton()
    {
        this.readerFileTypesHashMap = StdUtil.getInstance().createHashMap();
        this.writerFileTypesHashMap = StdUtil.getInstance().createHashMap();
        HashMap<object, object> hashMap = MediaData.toHashMap();
        Set<object> set = hashMap.keySet();
        object[] mediaDataNameArray = set.toArray();
        int size = mediaDataNameArray.Length;
        for (int index_0 = 0; index_0 < size; index_0++) {
            string mediaDataName = ((string) mediaDataNameArray[index_0]);
            MediaData mediaData = ((MediaData) hashMap.get(mediaDataName));
            this.readerFileTypesHashMap.put(mediaData.getName(), mediaData.getType());
        }
        MediaIOUtil mediaIOUtil = MediaIOUtil.getInstance();
        string RESIZABLE_MEDIA = MediaTypeData.getInstance().RESIZABLE_MEDIA;
        string[] readerFileTypes = mediaIOUtil.getReaderFormatNames();
        for (int index_1 = 0; index_1 < readerFileTypes.Length; index_1++) {
            this.readerFileTypesHashMap.put(readerFileTypes[index_1], RESIZABLE_MEDIA);
        }
        string[] writerFileTypes = mediaIOUtil.getWriterFormatNames();
        for (int index_2 = 0; index_2 < writerFileTypes.Length; index_2++) {
            this.writerFileTypesHashMap.put(writerFileTypes[index_2], RESIZABLE_MEDIA);
        }
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Supported Media Readers: ");
            stringBuffer.append(this.readerFileTypesHashMap.ToString());
            stringBuffer.append(" Writers: ");
            stringBuffer.append(this.writerFileTypesHashMap.ToString());
            this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static UploadMediaSingleton getInstance()
    {
        if (UploadMediaSingleton.uploadMedia == null) {
            UploadMediaSingleton.uploadMedia = new UploadMediaSingleton();
        }
        return UploadMediaSingleton.uploadMedia;
    }

    public virtual bool isReaderSupported(string mediaFileType)
    {
        return this.readerFileTypesHashMap.containsKey(mediaFileType);
    }

    public virtual bool isWriterSupported(string mediaFileType)
    {
        return this.readerFileTypesHashMap.containsKey(mediaFileType);
    }

    public virtual bool isSupported(string mediaFileType)
    {
        return this.isReaderSupported(mediaFileType) && this.isWriterSupported(mediaFileType);
    }

    public virtual bool isMedia(string mediaFileType, string aMediaType)
    {
        return this.isReaderMedia(mediaFileType, aMediaType) && this.isWriterMedia(mediaFileType, aMediaType);
    }

    public virtual bool isReaderMedia(string mediaFileType, string aMediaType)
    {
        return this.isMedia(mediaFileType, aMediaType, this.readerFileTypesHashMap);
    }

    public virtual bool isWriterMedia(string mediaFileType, string aMediaType)
    {
        return this.isMedia(mediaFileType, aMediaType, this.writerFileTypesHashMap);
    }

    private bool isMedia(string mediaFileType, string aMediaType, HashMap<object, object> hashMap)
    {
        if (hashMap.containsKey(mediaFileType)) {
            string mediaType = ((string) hashMap.get(mediaFileType));
            if (string.CompareOrdinal(mediaType, aMediaType) == 0) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

}

