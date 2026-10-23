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
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ImagePersistanceUtil = org.allbinary.media.image.ImagePersistanceUtil;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageProcessorInputCompositeInterface = org.allbinary.media.image.ImageProcessorInputCompositeInterface;
using ImageUtil = org.allbinary.media.image.ImageUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.image.gui;

public class CreateIconImagesJPanel : javax.swing.JPanel, ImageProcessorInputCompositeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private ImageProcessorInput imageProcessorInput;
    public CreateIconImagesJPanel(ImageProcessorInput imageProcessorInput) : base()
    {
        // base() is called from the constructor declaration
        initComponents();
        this.imageProcessorInput = imageProcessorInput;
        string[] numberStringArray = new string[101];
        numberStringArray[0] = (-1).ToString();
        for (int index = 1; index < 100; index++) {
            numberStringArray[index] = (index).ToString();
        }
        Raster araster = this.imageProcessorInput.getBufferedImageArray()[0].getAlphaRaster();
        if (araster == null) {
            Console.WriteLine("there is no Alpha channel!!!!!!!!!");
        } else {
            Console.WriteLine("Alpha channel found !");
        }
    }

    public virtual void process()
    {
        new global::org.allbinary.thread.NullThread()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    ImageUtil imageUtil = ImageUtil.getInstance();
                    StringMaker stringMaker = new StringMaker();
                    ImageProcessorInput imageProcessorInput = this.getImageProcessorInput();
                    File[] files = imageProcessorInput.getFiles();
                    BasicArrayList iconWidthList = new BasicArrayListD();
                    BasicArrayList iconHeightList = new BasicArrayListD();
                    iconWidthList.add(864);
                    iconHeightList.add(864);
                    string ANDROID = "android-icon-";
                    string IOS = "ios-icon-";
                    int size = iconWidthList.size();
                    int width = 0;
                    int height = 0;
                    for (int index2 = 0; index2 < size; index2++) {
                        width = ((int) (((int?) iconWidthList.get(index2))));
                        height = ((int) (((int?) iconHeightList.get(index2))));
                        BufferedImage[] generatedBufferedImageArray = imageUtil.createBufferedImage3(imageProcessorInput.getBufferedImageArray(), width, height, true);
                        ImagePersistanceUtil imagePersistanceUtil = ImagePersistanceUtil.getInstance();
                        for (int index = 0; index < generatedBufferedImageArray.Length; index++) {
                            string filePath = files[index].getAbsolutePath();
                            int endIndex = filePath.LastIndexOf('\\');
                            string path = filePath.Substring(0, (endIndex + 1) - (0));
                            stringMaker.delete(0, stringMaker.length());
                            stringMaker.append(path).append(ANDROID).appendint(width).append(CanvasStrings.getInstance()._PNG);
                            string newFilePath = stringMaker.ToString();
                            imagePersistanceUtil.saveWithBatik(AbFile.createAbFile(newFilePath), generatedBufferedImageArray[index]);
                            stringMaker.delete(0, stringMaker.length());
                            stringMaker.append(path).append(IOS).appendint(width).append(CanvasStrings.getInstance()._PNG);
                            newFilePath = stringMaker.ToString();
                            imagePersistanceUtil.saveWithBatik(AbFile.createAbFile(newFilePath), generatedBufferedImageArray[index]);
                        }
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
        this.aboveJButton = new javax.swing.JButton();
        this.aboveJButton.setText("Process");
        this.aboveJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                aboveJButtonActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(aboveJButton).addGap(0, 335, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addComponent(aboveJButton).addContainerGap(286, short.MaxValue)));
    }

    private void aboveJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.process();
    }

    private javax.swing.JButton aboveJButton = null;
}

