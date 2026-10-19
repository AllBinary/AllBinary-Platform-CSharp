// Generated Code Do Not Modify

using System;
using System.Linq;
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.animation;

public class FillAnimation : IndexedAnimation
{
    private readonly int[] pixelBuffer;
    private readonly int width;
    private readonly int height;
    public FillAnimation(int[] pixelBuffer, int width, int height, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.width = 100;
        this.height = 100;
        this.pixelBuffer = pixelBuffer;
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getBasicColorP() == null || ((int) this.getBasicColorP()) != ((int) basicColor)) {
            changed = true;
        }
        base.setBasicColorP(basicColor);
        if (changed) {
            this.updateModifiers();
        }
    }

    public override void changeBasicColor(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getChangeBasicColor() == null || ((int) this.getChangeBasicColor()) != ((int) basicColor)) {
            changed = true;
        }
        base.changeBasicColor(basicColor);
        if (changed) {
            this.updateModifiers();
        }
    }

    public override void setAlpha(int alpha)
    {
        bool changed = false;
        if (this.alphaP != alpha) {
            changed = true;
        }
        base.setAlpha(alpha);
        if (changed) {
            this.updateModifiers();
        }
    }

    public override void setScale(float scaleX, float scaleY)
    {
    }

    public override void setMaxScale(float maxScaleX, float maxScaleY)
    {
    }

    private void updateModifiers()
    {
    }

    protected virtual void paint(Graphics g)
    {
        g.drawRGB(pixelBuffer, 0, width, 0, 0, width, height, true);
    }

}

