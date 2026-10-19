/*
 * 
 * To change this license header, choose License Headers in Project Properties. 
 * To change this template file, choose Tools | Templates 
 * and open the template in the editor.  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
//using BufferedImage = java.awt.image.BufferedImage;
//using File = java.io.File;
//using IOException = java.io.IOException;
//using Iterator = java.util.Iterator;
//using IIOImage = javax.imageio.IIOImage;
//using ImageIO = javax.imageio.ImageIO;
//using ImageWriteParam = javax.imageio.ImageWriteParam;
//using ImageWriter = javax.imageio.ImageWriter;
//using ImageOutputStream = javax.imageio.stream.ImageOutputStream;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFileOutputStream = org.allbinary.logic.io.AbFileOutputStream;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using CommonStrings = org.allbinary.@string.CommonStrings;
using PNGImageWriter = org.apache.batik.ext.awt.image.codec.png.PNGImageWriter;

namespace org.allbinary.media.image;

public class ImagePersistanceUtil
{
    private static readonly ImagePersistanceUtil instance = new ImagePersistanceUtil();
    public static ImagePersistanceUtil getInstance()
    {
        return ImagePersistanceUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception
    public virtual void saveWithBatik(AbFile file, BufferedImage bufferedImage)
    {
        PNGImageWriter batikPNGImageWriter = new PNGImageWriter();
        AbFileOutputStream fileOutputStream = AbFileOutputStream.createFromAbFile(file);
        try {
            batikPNGImageWriter.writeImage(bufferedImage, fileOutputStream);
        } finally {
            fileOutputStream.flush();
            StreamUtil.getInstance().close(fileOutputStream);
        }
        this.logUtil.putF("Wrote Image: " + file.getAbsolutePath(), this, this.commonStrings.SAVE);
    }

    public virtual void saveWithImageIO(string filePath, BufferedImage bufferedImage)
    {
        this.saveWithImageIO(new File(filePath), bufferedImage);
    }

    public virtual void saveWithImageIO(File file, BufferedImage bufferedImage)
    {
        ImageWriter writer = null;
        ImageOutputStream ios = null;
        try {
            Iterator iter = ImageIO.getImageWritersByFormatName("jpeg");
            if (!iter.hasNext()) {
                this.logUtil.putF("Unable to save image to jpeg file type.", this, this.commonStrings.SAVE);
                return;
            }
            writer = ((ImageWriter) iter.next());
            ios = ImageIO.createImageOutputStream(file);
            writer.setOutput(ios);
            ImageWriteParam iwp = writer.getDefaultWriteParam();
            iwp.setCompressionMode(ImageWriteParam.MODE_EXPLICIT);
            iwp.setCompressionQuality(0.95f);
            writer.write(null, new IIOImage(bufferedImage, null, null), iwp);
            this.logUtil.putF("Wrote Image: " + file.getAbsolutePath(), this, this.commonStrings.SAVE);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.SAVE, e);
        } finally {
            try {
                if (ios != null) {
                    ios.flush();
                    try {
                        if (ios != null) {
                            this.logUtil.putF(ios.ToString(), ios, this.commonStrings.CLOSE);
                            ios.close();
                        }
                    } catch (Exception e) {
                        this.logUtil.put(commonStrings.EXCEPTION, ios, commonStrings.CLOSE, e);
                    }
                }
                if (writer != null) {
                    writer.dispose();
                }
            } catch (IOException e2) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.SAVE, e2);
            }
        }
    }

}

