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
//using RenderedImage = java.awt.image.RenderedImage;
//using File = java.io.File;
//using ImageIO = javax.imageio.ImageIO;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageProcessorInputCompositeInterface = org.allbinary.media.image.ImageProcessorInputCompositeInterface;
using ImageStrings = org.allbinary.media.image.ImageStrings;
using MirrorImageUtil = org.allbinary.media.image.MirrorImageUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image.gui;

public class MirrorImageJPanel : javax.swing.JPanel, ImageProcessorInputCompositeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ImageStrings imageStrings = ImageStrings.getInstance();
    private ImageProcessorInput imageProcessorInput;
    private BufferedImage result = null;
    public MirrorImageJPanel(ImageProcessorInput imageProcessorInput) : base()
    {
        // base() is called from the constructor declaration
        this.logUtil.putF("Starting", this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
        this.imageProcessorInput = imageProcessorInput;
    }

    public virtual void process()
    {
        new Thread()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    ImageProcessorInput imageProcessorInput = this.getImageProcessorInput();
                    BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
                    for (int index = 0; index < bufferedImageArray.Length; index++) {
                        this.result = MirrorImageUtil.getInstance().getImage(bufferedImageArray[index], this.verticleJCheckBox.isSelected(), this.horizontalJCheckBox.isSelected());
                        File file = imageProcessorInput.getFiles()[index];
                        if (this.writeOverOriginalJRadioButton.isSelected()) {
                        } else if (this.renameJRadioButton.isSelected()) {
                            string filePath = file.getAbsolutePath();
                            int extensionIndex = filePath.IndexOf(imageStrings.PNG_EXTENSION);
                            filePath = filePath.Substring(0, (extensionIndex) - (0)) + "_mirror" + imageStrings.PNG_EXTENSION;
                            logUtil.putF("Renamed File: " + filePath, this, commonStrings.RUN);
                            file = new File(filePath);
                        }
                        bool isWritten = ImageIO.write(((RenderedImage) this.result), imageStrings.PNG, file);
                        logUtil.putF("File: " + file + " Wrote: " + isWritten, this, commonStrings.RUN);
                        this.getParent().repaint();
                    }
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
.start();
    }

    private void initComponents()
    {
        jLayeredPane1 = new javax.swing.JLayeredPane();
        this.buttonGroup = new javax.swing.ButtonGroup();
        this.jPanel1 = new javax.swing.JPanel()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void paint(Graphics graphics)
            {
                if (this.result != null) {
                    graphics.drawImage(this.result, 0, 0, this.result.getWidth(null), this.result.getHeight(null), null);
                }
            }

#endif
;
        this.jPanel2 = new javax.swing.JPanel();
        this.horizontalJCheckBox = new javax.swing.JCheckBox();
        this.verticleJCheckBox = new javax.swing.JCheckBox();
        this.generateJButton = new javax.swing.JButton();
        this.renameJRadioButton = new javax.swing.JRadioButton();
        this.writeOverOriginalJRadioButton = new javax.swing.JRadioButton();
        this.jPanel3 = new javax.swing.JPanel();
        this.jLabel2 = new javax.swing.JLabel();
        org.jdesktop.layout.GroupLayout jPanel1Layout = new org.jdesktop.layout.GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(0, 522, short.MaxValue));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(0, 230, short.MaxValue));
        this.horizontalJCheckBox.setSelected(true);
        this.horizontalJCheckBox.setText("Horizontal");
        this.horizontalJCheckBox.setEnabled(false);
        this.verticleJCheckBox.setText("Verticle");
        this.verticleJCheckBox.setEnabled(false);
        this.generateJButton.setText("Generate");
        this.generateJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                generateJButtonActionPerformed(evt);
            }

#endif
);
        this.renameJRadioButton.setText("Save As filename_mirror");
        this.renameJRadioButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                renameJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.writeOverOriginalJRadioButton.setText("Write Over Original");
        org.jdesktop.layout.GroupLayout jPanel2Layout = new org.jdesktop.layout.GroupLayout(this.jPanel2);
        this.jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(jPanel2Layout.createSequentialGroup().addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue).add(verticleJCheckBox).addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED).add(horizontalJCheckBox).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(writeOverOriginalJRadioButton).addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED).add(renameJRadioButton).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(generateJButton).add(37, 37, 37)));
        jPanel2Layout.setVerticalGroup(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(jPanel2Layout.createSequentialGroup().add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(horizontalJCheckBox).add(verticleJCheckBox).add(writeOverOriginalJRadioButton).add(renameJRadioButton).add(generateJButton)).addContainerGap()));
        this.jLabel2.setText("Results:");
        org.jdesktop.layout.GroupLayout jPanel3Layout = new org.jdesktop.layout.GroupLayout(this.jPanel3);
        this.jPanel3.setLayout(jPanel3Layout);
        jPanel3Layout.setHorizontalGroup(jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(jPanel3Layout.createSequentialGroup().add(jLabel2).addContainerGap(433, short.MaxValue)));
        jPanel3Layout.setVerticalGroup(jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(jLabel2));
        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup().addContainerGap().add(jPanel3, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue).addContainerGap()).add(jPanel1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue).add(layout.createSequentialGroup().add(jPanel2, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue).addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(layout.createSequentialGroup().add(jPanel2, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 25, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(jPanel3, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(jPanel1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
    }

    private void generateJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.process();
    }

    private void renameJRadioButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private javax.swing.ButtonGroup buttonGroup = null;
    private javax.swing.JButton generateJButton = null;
    private javax.swing.JCheckBox horizontalJCheckBox = null;
    private javax.swing.JLabel jLabel2 = null;
    private javax.swing.JLayeredPane jLayeredPane1 = null;
    private javax.swing.JPanel jPanel1 = null;
    private javax.swing.JPanel jPanel2 = null;
    private javax.swing.JPanel jPanel3 = null;
    private javax.swing.JRadioButton renameJRadioButton = null;
    private javax.swing.JCheckBox verticleJCheckBox = null;
    private javax.swing.JRadioButton writeOverOriginalJRadioButton = null;
    public virtual ImageProcessorInput getImageProcessorInput()
    {
        return this.imageProcessorInput;
    }

    public virtual void setImageProcessorInput(ImageProcessorInput imageProcessorInput)
    {
        this.imageProcessorInput = imageProcessorInput;
    }

}

