// Generated Code Do Not Modify

using System;
using System.Linq;
//using BufferedImage = java.awt.image.BufferedImage;
//using RenderedImage = java.awt.image.RenderedImage;
using java.util;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using AbFile = org.allbinary.logic.io.file.AbFile;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ImageUtil = org.allbinary.media.image.ImageUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.logic.visual.media;

//import com.sun.imageio.plugins.common.ImageUtil;
public class MediaUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly MediaUtil instance = new MediaUtil();
    public static MediaUtil getInstance()
    {
        return MediaUtil.instance;
    }

    private MediaUtil()
    {
    }

    // throws Exception
    public virtual void saveImageFile(AbFile originalImageFile, string newImageFileName, string category, MediaData mediaData, int newWidth, int newHeight)
    {
        if (originalImageFile == null || !originalImageFile.isFile()) {
            throw new Exception("Original Image File Does Not Exist.");
        }
        BufferedImage bufferedImage = ImageIOUtil.read(originalImageFile);
        if (bufferedImage == null) {
            throw new Exception("Unable to find ImageReader for this file.");
        }
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
            HashMap hashMap = this.getImageBufferPropertyHashMap(bufferedImage);
            this.logUtil.putF("Image Properties: " + hashMap.ToString(), this, "saveImageFile()");
        }
        AbFile imageFile = AbFile.createAbFile(category + newImageFileName);
        imageFile.createNewFile();
        ImageUtil imageUtil = ImageUtil.getInstance();
        BufferedImage newBufferedImage = imageUtil.createBufferedImageForSave(bufferedImage, newWidth, newHeight);
        bool isWritten = ImageIOUtil.write(((RenderedImage) newBufferedImage), mediaData.getName(), imageFile);
        if (!isWritten) {
            throw new Exception("Unable to write.");
        }
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
            CommonLabels commonLabels = CommonLabels.getInstance();
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Get Path: ");
            stringBuffer.append(originalImageFile.getPath());
            stringBuffer.append("\nNewImageFileName: ");
            stringBuffer.append(newImageFileName);
            stringBuffer.append("\nCategory: ");
            stringBuffer.append(category);
            stringBuffer.append("\nSave File Type: ");
            stringBuffer.append(mediaData.getName());
            stringBuffer.append("\nNew").append(commonLabels.WIDTH_LABEL);
            stringBuffer.appendint(newWidth);
            stringBuffer.append("\nNew").append(commonLabels.HEIGHT_LABEL);
            stringBuffer.appendint(newHeight);
            stringBuffer.append("\nFile Length: ");
            stringBuffer.appendlong(((long) originalImageFile.length()));
            stringBuffer.append("\nNew File Length: ");
            stringBuffer.appendlong(((long) imageFile.length()));
            this.logUtil.putF(stringBuffer.ToString(), this, "saveImageFile()");
        }
    }

    private static HashMap getImageBufferPropertyHashMap(BufferedImage bufferedImage)
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        string[] propertyStringArray = bufferedImage.getPropertyNames();
        if (propertyStringArray != null) {
            for (int index = 0; index < propertyStringArray.Length; index++) {
                object propertyObject = bufferedImage.getProperty(propertyStringArray[index]);
                hashMap.put(propertyStringArray[index], propertyObject.ToString());
            }
        }
        return hashMap;
    }

}

