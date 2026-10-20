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
//using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image.gui;

public class ImageJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CanvasStrings canvasStrings = CanvasStrings.getInstance();
    private bool isDrawn = false;
    private BufferedImage bufferedImage;
    public ImageJPanel(BufferedImage bufferedImage)
    {
        this.initComponents();
        this.bufferedImage = bufferedImage;
        this.setSize(this.bufferedImage.getWidth(null), this.bufferedImage.getHeight(null));
    }

    public virtual void paint(Graphics graphics)
    {
        if (!this.isDrawn) {
            this.logUtil.putF(this.commonStrings.START, this, this.canvasStrings.PAINT);
            graphics.drawImage(bufferedImage, 0, 0, this.bufferedImage.getWidth(null), this.bufferedImage.getHeight(null), null);
            this.isDrawn = true;
        }
    }

    private void initComponents()
    {
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 400, short.MaxValue));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 300, short.MaxValue));
    }

}

