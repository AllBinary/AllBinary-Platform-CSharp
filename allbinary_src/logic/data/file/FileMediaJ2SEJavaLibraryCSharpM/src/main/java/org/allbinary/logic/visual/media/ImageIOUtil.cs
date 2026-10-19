// Generated Code Do Not Modify

using System;
using System.Linq;
//using BufferedImage = java.awt.image.BufferedImage;
//using RenderedImage = java.awt.image.RenderedImage;
//using ImageIO = javax.imageio.ImageIO;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;

namespace org.allbinary.logic.visual.media;

public class ImageIOUtil
{
    // throws Exception
    public static BufferedImage read(AbFile file)
    {
        return ImageIO.read(AbFileNativeUtil.get(file));
    }

    // throws Exception
    public static bool write(RenderedImage renderedImage, string name, AbFile file)
    {
        return ImageIO.write(renderedImage, name, AbFileNativeUtil.get(file));
    }

}

