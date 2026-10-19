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
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using Anchor = org.allbinary.graphics.Anchor;
using PaintableToImageUtil = org.allbinary.image.PaintableToImageUtil;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.geographic.map;

public class ImageMiniMapLayer : MiniMapLayer
{
    private Image image = NullImage.NULL_IMAGE;
    public ImageMiniMapLayer(BasicGeographicMap geographicMapInterface, ViewPositionBase viewPosition) : base(geographicMapInterface, viewPosition)
    {
        // base(geographicMapInterface, viewPosition) is called from the constructor declaration
    }

    // throws Exception
    protected override void init()
    {
        int aWidth = this.allBinaryTiledLayer.getWidth();
        int aHeight = this.allBinaryTiledLayer.getHeight();
        this.image = PaintableToImageUtil.getImage(this.allBinaryTiledLayer, aWidth, aHeight);
    }

    private int anchor = Anchor.TOP_LEFT;
    public override void paint(Graphics graphics)
    {
        graphics.drawImage(this.image, this.x, this.y, this.anchor);
        this.paintDots(graphics);
    }

}

