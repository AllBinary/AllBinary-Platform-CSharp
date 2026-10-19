// Generated Code Do Not Modify

using System;
using System.Linq;
//using Image = javax.microedition.lcdui.Image;
using DisposalUtil = org.allbinary.DisposalUtil;
using PlatformBitmapBase = org.allbinary.platform.graphics.PlatformBitmapBase;
using SwtImmutableImage = org.microemu.device.swt.SwtImmutableImage;
using SwtMutableImage = org.microemu.device.swt.SwtMutableImage;

namespace org.allbinary.graphics;

public class OpenGLBitmap : PlatformBitmapBase
{
    public readonly Image image;
    public OpenGLBitmap(object bitmap)
    {
        this.image = ((Image) bitmap);
    }

    public virtual Image getImage()
    {
        return this.image;
    }

    public virtual int getDepth()
    {
        if (this.image.isMutable()) {
            SwtMutableImage mutableImage = ((SwtMutableImage) this.image);
            return mutableImage.getDepth();
        } else {
            SwtImmutableImage immutableImage = ((SwtImmutableImage) this.image);
            return immutableImage.getDepth();
        }
    }

    public virtual void getPixels(int[] pixels, int offset, int stride, int x, int y, int width, int height)
    {
        if (this.image.isMutable()) {
            SwtMutableImage mutableImage = ((SwtMutableImage) this.image);
            mutableImage.getRGB(pixels, offset, stride, x, y, width, height);
        } else {
            SwtImmutableImage immutableImage = ((SwtImmutableImage) this.image);
            immutableImage.getRGB(pixels, offset, stride, x, y, width, height);
        }
    }

    public virtual void setPixels(int[] pixels, int offset, int stride, int x, int y, int width, int height)
    {
        this.image.setRGB2(pixels, offset, height, x, y, width, height);
    }

    public override int getWidth()
    {
        return this.image.getWidth();
    }

    public override int getHeight()
    {
        return this.image.getHeight();
    }

    public virtual void recycle()
    {
        DisposalUtil.getInstance().disposeImage(this.image);
    }

}

