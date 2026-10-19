// Generated Code Do Not Modify

using System;
using System.Linq;
//using ImageIO = javax.imageio.ImageIO;

namespace org.allbinary.logic.visual.media;

public class MediaIOUtil
{
    private static readonly MediaIOUtil instance = new MediaIOUtil();
    public static MediaIOUtil getInstance()
    {
        return MediaIOUtil.instance;
    }

    public virtual string[] getReaderFormatNames()
    {
        return ImageIO.getReaderFormatNames();
    }

    public virtual string[] getWriterFormatNames()
    {
        return ImageIO.getWriterFormatNames();
    }

}

