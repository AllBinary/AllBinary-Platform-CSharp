// Hand-maintained C# source. Preserve during Java regeneration.
extern alias LegacyMIDP;

using System.Runtime.CompilerServices;
using DesktopImage = javax.microedition.lcdui.Image;
using LegacyImage = LegacyMIDP::javax.microedition.lcdui.Image;
using OpenGLUtil = org.allbinary.graphics.opengles.OpenGLUtil;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;
using OpenGLESImageExclusionUtil = org.allbinary.image.opengles.OpenGLESImageExclusionUtil;

namespace org.allbinary.media.image;

internal static class SwtOpenGLESImageBridge
{
    private static readonly ConditionalWeakTable<DesktopImage, LegacyImageView> legacyViews = new();
    private static readonly ConditionalWeakTable<LegacyImage, DesktopImageView> desktopViews = new();

    internal static DesktopImage addImage(OpenGLUtil util, DesktopImage image)
    {
        return ToDesktop(util.addImage(ToLegacy(image)));
    }

    internal static bool isCustomScaling(OpenGLESImageExclusionUtil util, DesktopImage image)
    {
        return util.isCustomScaling(ToLegacy(image));
    }

    internal static OpenGLESImage getOpenGLESImage(DesktopImage image)
    {
        return (OpenGLESImage) ToLegacy(image);
    }

    internal static DesktopImage getBitmapImage(OpenGLESImage image)
    {
        return ToDesktop(image.openGLBitmap.getImage());
    }

    internal static DesktopImage asImage(OpenGLESImage image)
    {
        return ToDesktop(image);
    }

    private static LegacyImage ToLegacy(DesktopImage image)
    {
        if (image is null)
        {
            return null;
        }
        return image is DesktopImageView view
            ? view.Image
            : legacyViews.GetValue(image, value => new LegacyImageView(value));
    }

    private static DesktopImage ToDesktop(LegacyImage image)
    {
        if (image is null)
        {
            return null;
        }
        return image is LegacyImageView view
            ? view.Image
            : desktopViews.GetValue(image, value => new DesktopImageView(value));
    }

    // The legacy OpenGL bitmap reads the original SWT image without copying its pixels.
    private sealed class LegacyImageView : LegacyImage
    {
        internal LegacyImageView(DesktopImage image)
        {
            Image = image;
        }

        internal DesktopImage Image { get; }

        public override int getWidth() => Image.getWidth();
        public override int getHeight() => Image.getHeight();
        public override int getType() => Image.getType();
        public override bool isMutable() => Image.isMutable();
        public override object getImage() => Image.getImage();
        public override string getName() => Image.getName();
        public override void setName(string name) => Image.setName(name);
        public override void getRGB(int[] pixels, int offset, int stride, int x, int y, int width, int height)
            => Image.getRGB(pixels, offset, stride, x, y, width, height);
    }

    // Scaling and processing modify the OpenGLESImage held by the legacy renderer.
    private sealed class DesktopImageView : DesktopImage
    {
        internal DesktopImageView(LegacyImage image)
        {
            Image = image;
        }

        internal LegacyImage Image { get; }

        public override int getWidth() => Image.getWidth();
        public override int getHeight() => Image.getHeight();
        public override int getWidth2() => Image.getWidth();
        public override int getHeight2() => Image.getHeight();
        public override int getType() => Image.getType();
        public override bool isMutable() => Image.isMutable();
        public override object getImage() => Image.getImage();
        public override string getName() => Image.getName();
        public override void setName(string name) => Image.setName(name);
        public override void getRGB(int[] pixels, int offset, int stride, int x, int y, int width, int height)
            => Image.getRGB(pixels, offset, stride, x, y, width, height);
    }
}
