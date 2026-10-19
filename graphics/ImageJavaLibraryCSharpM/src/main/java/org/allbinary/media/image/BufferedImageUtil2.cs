// Generated Code Do Not Modify

using System;
using System.Linq;
//using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;

namespace org.allbinary.media.image;

public class BufferedImageUtil2
{
    private static readonly BufferedImageUtil2 instance = new BufferedImageUtil2();
    public static BufferedImageUtil2 getInstance()
    {
        return BufferedImageUtil2.instance;
    }

    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    public virtual BufferedImage createSpriteImage(BufferedImage[] bufferedImageArray)
    {
        int columns = bufferedImageArray.Length;
        int max = columns;
        int rows = 0;
        if (bufferedImageArray.Length < columns) {
            columns = bufferedImageArray.Length;
        }
        rows = (bufferedImageArray.Length / columns);
        if (bufferedImageArray.Length % columns != 0) {
            rows++;
        }
        BufferedImage bufferedImage = this.imageUtil.create(bufferedImageArray[0].getWidth(null) * columns, bufferedImageArray[0].getHeight(null) * rows);
        Graphics2D g = bufferedImage.createGraphics();
        int columnIndex = 0;
        int rowIndex = 0;
        for (int index = 0; index < bufferedImageArray.Length; index++) {
            if (index / max != 0 && index % max == 0) {
                rowIndex++;
                columnIndex = 0;
            }
            g.drawImage(bufferedImageArray[index], bufferedImageArray[index].getWidth(null) * columnIndex, bufferedImageArray[index].getHeight(null) * rowIndex, bufferedImageArray[index].getWidth(null), bufferedImageArray[index].getHeight(null), null);
            columnIndex++;
        }
        g.dispose();
        return bufferedImage;
    }

}

