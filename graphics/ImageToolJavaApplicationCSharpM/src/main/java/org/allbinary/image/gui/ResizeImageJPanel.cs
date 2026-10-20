/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using BufferedImage = java.awt.image.BufferedImage;
//using Raster = java.awt.image.Raster;
//using File = java.io.File;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using FileWrapperUtil = org.allbinary.logic.io.file.FileWrapperUtil;
using ImagePersistanceUtil = org.allbinary.media.image.ImagePersistanceUtil;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageProcessorInputCompositeInterface = org.allbinary.media.image.ImageProcessorInputCompositeInterface;
using ImageUtil = org.allbinary.media.image.ImageUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image.gui;

public class ResizeImageJPanel : javax.swing.JPanel, ImageProcessorInputCompositeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private ImageProcessorInput imageProcessorInput;
    public ResizeImageJPanel(ImageProcessorInput imageProcessorInput) : base()
    {
        // base() is called from the constructor declaration
        initComponents();
        this.imageProcessorInput = imageProcessorInput;
        string[] numberStringArray = new string[101];
        numberStringArray[0] = (-1).ToString();
        for (int index = 1; index < 100; index++) {
            numberStringArray[index] = (index).ToString();
        }
        this.jComboBox1.setModel(new javax.swing.DefaultComboBoxModel(numberStringArray));
        Raster araster = this.imageProcessorInput.getBufferedImageArray()[0].getAlphaRaster();
        if (araster == null) {
            Console.WriteLine("there is no Alpha channel!!!!!!!!!");
        } else {
            Console.WriteLine("Alpha channel found !");
        }
    }

    public virtual void process()
    {
        new Thread()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    ImageUtil imageUtil = ImageUtil.getInstance();
                    int? percent = (((string) this.jComboBox1.getSelectedItem())).ToString();
                    float? percentAsFloat = float.Parse(this.floatPercentJTextField.getText());
                    ImageProcessorInput imageProcessorInput = this.getImageProcessorInput();
                    File[] files = imageProcessorInput.getFiles();
                    BufferedImage[] generatedBufferedImageArray = null;
                    if (((int) percentAsFloat) != -1) {
                        generatedBufferedImageArray = imageUtil.createBufferedImage2(imageProcessorInput.getBufferedImageArray(), percentAsFloat, true);
                    } else if (((int) percent) != -1) {
                        generatedBufferedImageArray = imageUtil.createBufferedImageForResize(imageProcessorInput.getBufferedImageArray(), percent, true);
                    } else {
                        int? width = (((string) this.jTextField1.getText())).ToString();
                        int? height = (((string) this.jTextField2.getText())).ToString();
                        generatedBufferedImageArray = imageUtil.createBufferedImage3(imageProcessorInput.getBufferedImageArray(), width, height, true);
                    }
                    Raster araster = generatedBufferedImageArray[0].getAlphaRaster();
                    if (araster == null) {
                        Console.WriteLine("No Alpha Channel In Result");
                    } else {
                        Console.WriteLine("Found Alpha Channel In Result");
                    }
                    ImagePersistanceUtil imagePersistanceUtil = ImagePersistanceUtil.getInstance();
                    for (int index = 0; index < generatedBufferedImageArray.Length; index++) {
                        imagePersistanceUtil.saveWithBatik(FileWrapperUtil.wrapFile(files[index]), generatedBufferedImageArray[index]);
                    }
                    this.getParent().repaint();
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
.start();
    }

    public virtual void update()
    {
        new Thread()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    ImageProcessorInput imageProcessorInput = this.getImageProcessorInput();
                    int size = imageProcessorInput.getBufferedImageArray().Length;
                    BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
                    BufferedImage bufferedImage = null;
                    for (int index = 0; index < size; index++) {
                        bufferedImage = bufferedImageArray[0];
                        this.jTextField1.setText((bufferedImage.getWidth()).ToString());
                        this.jTextField2.setText((bufferedImage.getHeight()).ToString());
                    }
                    this.getParent().repaint();
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
.start();
    }

    public virtual void updateFor16Above()
    {
        new Thread()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    ImageProcessorInput imageProcessorInput = this.getImageProcessorInput();
                    int size = imageProcessorInput.getBufferedImageArray().Length;
                    BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
                    BufferedImage bufferedImage = null;
                    for (int index = 0; index < size; index++) {
                        bufferedImage = bufferedImageArray[0];
                        this.jTextField1.setText((bufferedImage.getWidth() / 16 * 16).ToString());
                        this.jTextField2.setText((bufferedImage.getHeight() / 16 * 16).ToString());
                    }
                    this.getParent().repaint();
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
.start();
    }

    public virtual void updateFor16Below()
    {
        new Thread()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    ImageProcessorInput imageProcessorInput = this.getImageProcessorInput();
                    int size = imageProcessorInput.getBufferedImageArray().Length;
                    BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
                    BufferedImage bufferedImage = null;
                    for (int index = 0; index < size; index++) {
                        bufferedImage = bufferedImageArray[0];
                        this.jTextField1.setText((((bufferedImage.getWidth() / 16) + 1) * 16).ToString());
                        this.jTextField2.setText((((bufferedImage.getHeight() / 16) + 1) * 16).ToString());
                    }
                    this.getParent().repaint();
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
.start();
    }

    public virtual ImageProcessorInput getImageProcessorInput()
    {
        return this.imageProcessorInput;
    }

    public virtual void setImageProcessorInput(ImageProcessorInput imageProcessorInput)
    {
        this.imageProcessorInput = imageProcessorInput;
    }

    private void initComponents()
    {
        this.jLabel1 = new javax.swing.JLabel();
        this.jComboBox1 = new javax.swing.JComboBox();
        this.aboveJButton = new javax.swing.JButton();
        this.jTextField1 = new javax.swing.JTextField();
        this.jLabel2 = new javax.swing.JLabel();
        this.jLabel3 = new javax.swing.JLabel();
        this.jTextField2 = new javax.swing.JTextField();
        this.updateJButton = new javax.swing.JButton();
        this.floatPercentJTextField = new javax.swing.JTextField();
        this.adjustFor16AboveJButton = new javax.swing.JButton();
        this.adjustFor16BelowJButton = new javax.swing.JButton();
        this.jLabel1.setText("Percent:");
        this.jComboBox1.setModel(new javax.swing.DefaultComboBoxModel(new string[] { "Item 1", "Item 2", "Item 3", "Item 4" }));
        this.aboveJButton.setText("Process");
        this.aboveJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                aboveJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Width:");
        this.jLabel3.setText("Height:");
        this.updateJButton.setText("Update");
        this.updateJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                updateJButtonActionPerformed(evt);
            }

#endif
);
        this.floatPercentJTextField.setText("-1.000000");
        this.floatPercentJTextField.setMinimumSize(new java.awt.Dimension(120, 22));
        this.adjustFor16AboveJButton.setText("Adjust for 16 Above");
        this.adjustFor16AboveJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                adjustFor16AboveJButtonActionPerformed(evt);
            }

#endif
);
        this.adjustFor16BelowJButton.setText("Adjust for 16 Below");
        this.adjustFor16BelowJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                adjustFor16BelowJButtonActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(jLabel1).addComponent(jLabel2).addComponent(jLabel3)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addComponent(jComboBox1, 0, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(jTextField1).addComponent(jTextField2)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(floatPercentJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(adjustFor16AboveJButton).addComponent(adjustFor16BelowJButton)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue)).addGroup(layout.createSequentialGroup().addComponent(updateJButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(aboveJButton).addGap(0, 250, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(jComboBox1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(floatPercentJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jTextField1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel2).addComponent(adjustFor16AboveJButton)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel3).addComponent(jTextField2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(adjustFor16BelowJButton)).addGap(18, 18, 18).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(aboveJButton).addComponent(updateJButton)).addContainerGap(175, short.MaxValue)));
    }

    private void aboveJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.process();
    }

    private void updateJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.update();
    }

    private void adjustFor16AboveJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.updateFor16Above();
    }

    private void adjustFor16BelowJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.updateFor16Below();
    }

    private javax.swing.JButton aboveJButton = null;
    private javax.swing.JButton adjustFor16AboveJButton = null;
    private javax.swing.JButton adjustFor16BelowJButton = null;
    private javax.swing.JTextField floatPercentJTextField = null;
    private javax.swing.JComboBox<string> jComboBox1 = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JLabel jLabel2 = null;
    private javax.swing.JLabel jLabel3 = null;
    private javax.swing.JTextField jTextField1 = null;
    private javax.swing.JTextField jTextField2 = null;
    private javax.swing.JButton updateJButton = null;
}

