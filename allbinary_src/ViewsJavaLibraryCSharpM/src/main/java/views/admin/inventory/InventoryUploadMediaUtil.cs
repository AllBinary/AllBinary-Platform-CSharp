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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using UploadMediaSingleton = org.allbinary.logic.communication.http.file.upload.media.UploadMediaSingleton;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using MediaData = org.allbinary.logic.visual.media.MediaData;
using MediaTypeData = org.allbinary.logic.visual.media.MediaTypeData;
using MediaUtil = org.allbinary.logic.visual.media.MediaUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace views.admin.inventory;

public class InventoryUploadMediaUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly MediaUtil mediaUtil = MediaUtil.getInstance();
    private readonly int LARGEWIDTH = 1024;
    private readonly int LARGEHEIGHT = 1024;
    private readonly int MEDIUMWIDTH = 256;
    private readonly int MEDIUMHEIGHT = 256;
    private readonly int SMALLWIDTH = 128;
    private readonly int SMALLHEIGHT = 128;
    private readonly string SMALL = "Small";
    private readonly string MEDIUM = "Medium";
    private readonly string LARGE = "Large";
    private StoreFrontInterface storeFrontInterface;
    private ItemInterface itemInterface;
    public InventoryUploadMediaUtil(StoreFrontInterface storeFrontInterface, ItemInterface itemInterface)
    {
        this.storeFrontInterface = storeFrontInterface;
        this.itemInterface = itemInterface;
    }

    // throws Exception
    public virtual ItemInterface saveFiles(sbyte[] byteArray, string fileName, MediaData mediaData)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF("Start FileName: " + fileName, this, "saveFiles()");
        }
        if (StringValidationUtil.getInstance().isEmpty(fileName)) {
            throw new Exception("Image File Name Was Null");
        }
        FileUtil fileUtil = FileUtil.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getWebappPath());
        stringBuffer.append(this.storeFrontInterface.getCurrentHostNamePath());
        stringBuffer.append(this.itemInterface.getCategory());
        string fullPath = stringBuffer.ToString();
        AbFile imageDirectoryFile = AbFile.createAbFile(fullPath);
        if (!imageDirectoryFile.isDirectory()) {
            throw new Exception("Unable to save file to non existant directory");
        }
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(fullPath);
        stringBuffer.append(fileName);
        stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
        stringBuffer.append(mediaData.getName());
        AbFile originalImageFile = AbFile.createAbFile(stringBuffer.ToString());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF("Saving Original Image: " + originalImageFile, this, "saveFiles()");
        }
        originalImageFile.createNewFile();
        fileUtil.write(new ByteArrayInputStream(byteArray), originalImageFile);
        UploadMediaSingleton uploadMedia = UploadMediaSingleton.getInstance();
        bool isMediaSupported = uploadMedia.isWriterSupported(mediaData.getName()) || uploadMedia.isReaderSupported(mediaData.getName());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append("Is Image Type: ");
            stringBuffer.append(mediaData.getName());
            stringBuffer.append(" supported: ");
            stringBuffer.appendboolean(isMediaSupported);
            this.logUtil.putF(stringBuffer.ToString(), this, "saveFiles()");
        }
        MediaData defaultMediaData = MediaData.getDefault();
        this.setFileNames(fileName);
        if (isMediaSupported) {
            bool isMediaResizable = uploadMedia.isWriterMedia(mediaData.getName(), MediaTypeData.getInstance().RESIZABLE_MEDIA);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append("Is ");
                stringBuffer.append(mediaData.ToString());
                stringBuffer.append(" Image Resize Supported:");
                stringBuffer.appendboolean(uploadMedia.isSupported(mediaData.getName()));
                stringBuffer.append(" WriterMedia: ");
                stringBuffer.appendboolean(isMediaResizable);
                this.logUtil.putF(stringBuffer.ToString(), this, "saveFiles()");
            }
            if (isMediaResizable) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                    this.logUtil.putF("Saving Small Image: " + this.itemInterface.getSmallImage(), this, "saveFiles()");
                }
                this.mediaUtil.saveImageFile(originalImageFile, this.itemInterface.getSmallImage(), fullPath, mediaData, this.SMALLWIDTH, this.SMALLHEIGHT);
                this.mediaUtil.saveImageFile(originalImageFile, this.itemInterface.getMediumImage(), fullPath, mediaData, this.MEDIUMWIDTH, this.MEDIUMHEIGHT);
                this.mediaUtil.saveImageFile(originalImageFile, this.itemInterface.getLargeImage(), fullPath, mediaData, this.LARGEWIDTH, this.LARGEHEIGHT);
            } else {
                bool isConvertable = mediaData.isConvertableTo(defaultMediaData);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append("Converting: ");
                    stringBuffer.append(defaultMediaData.getName());
                    stringBuffer.append(" into ");
                    stringBuffer.append(mediaData.getName());
                    stringBuffer.append(" if Convertable is it: ");
                    stringBuffer.appendboolean(isConvertable);
                    this.logUtil.putF(stringBuffer.ToString(), this, "saveFiles()");
                }
                if (isConvertable) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                        this.logUtil.putF("Saving Small Image: " + this.itemInterface.getSmallImage(), this, "saveFiles()");
                    }
                    this.mediaUtil.saveImageFile(originalImageFile, this.itemInterface.getSmallImage(), fullPath, defaultMediaData, this.SMALLWIDTH, this.SMALLHEIGHT);
                    this.mediaUtil.saveImageFile(originalImageFile, this.itemInterface.getMediumImage(), fullPath, defaultMediaData, this.MEDIUMWIDTH, this.MEDIUMHEIGHT);
                    this.mediaUtil.saveImageFile(originalImageFile, this.itemInterface.getLargeImage(), fullPath, defaultMediaData, this.LARGEWIDTH, this.LARGEHEIGHT);
                } else {
                    AbFile smallImageFile = AbFile.createAbFile(this.itemInterface.getSmallImage());
                    smallImageFile.createNewFile();
                    fileUtil.write(new ByteArrayInputStream(byteArray), smallImageFile);
                    AbFile mediumImageFile = AbFile.createAbFile(this.itemInterface.getMediumImage());
                    smallImageFile.createNewFile();
                    fileUtil.write(new ByteArrayInputStream(byteArray), mediumImageFile);
                    AbFile largeImageFile = AbFile.createAbFile(this.itemInterface.getSmallImage());
                    largeImageFile.createNewFile();
                    fileUtil.write(new ByteArrayInputStream(byteArray), largeImageFile);
                }
            }
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.END, this, "saveFiles()");
        }
        return this.itemInterface;
    }

    private void setFileNames(string fileName)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.itemInterface.getId());
        stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
        stringBuffer.append(MediaData.getDefault().getName());
        string END = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(fileName);
        stringBuffer.append(this.SMALL);
        stringBuffer.append(END);
        string newImageFileName = stringBuffer.ToString();
        this.itemInterface.setSmallImage(newImageFileName);
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(fileName);
        stringBuffer.append(this.MEDIUM);
        stringBuffer.append(END);
        newImageFileName = stringBuffer.ToString();
        this.itemInterface.setMediumImage(newImageFileName);
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(fileName);
        stringBuffer.append(this.LARGE);
        stringBuffer.append(END);
        newImageFileName = stringBuffer.ToString();
        this.itemInterface.setLargeImage(newImageFileName);
    }

}

