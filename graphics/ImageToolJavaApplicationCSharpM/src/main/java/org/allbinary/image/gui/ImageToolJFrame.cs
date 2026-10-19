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
//using BufferedImage = java.awt.image.BufferedImage;
//using File = java.io.File;
//using Arrays = java.util.Arrays;
//using java.util;
//using ImageIO = javax.imageio.ImageIO;
using FileJDialog = org.allbinary.gui.dialog.FileJDialog;
using FileJDialogListenerInterface = org.allbinary.gui.dialog.FileJDialogListenerInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageProcessorInputCompositeInterface = org.allbinary.media.image.ImageProcessorInputCompositeInterface;
using ColorRange = org.allbinary.media.image.analysis.ColorRange;
using ColorRangeInterface = org.allbinary.media.image.analysis.ColorRangeInterface;
using ImageAnalysis = org.allbinary.media.image.analysis.ImageAnalysis;
using ImageAnalysisResults = org.allbinary.media.image.analysis.ImageAnalysisResults;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image.gui;

public class ImageToolJFrame : javax.swing.JFrame, FileJDialogListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private static ImageProcessorInputCompositeInterface imageProcessorInputCompositeInterface = null;
    private FileJDialog fileJDialog;
    private ImageProcessorInput imageProcessorInput = null;
    public ImageToolJFrame()
    {
        this.initComponents();
        CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
        this.setSize(640, 480);
        this.getMaxRedJTextField().setText("255");
        this.getMaxGreenJTextField().setText("255");
        this.getMaxBlueJTextField().setText("255");
        this.getMinRedJTextField().setText(commonPhoneStrings.ZERO);
        this.getMinGreenJTextField().setText(commonPhoneStrings.ZERO);
        this.getMinBlueJTextField().setText(commonPhoneStrings.ZERO);
        this.fileJDialog = new FileJDialog();
        this.fileJDialog.addFinishedListener(this);
    }

    private void initComponents()
    {
        analysisActionJDialog = new javax.swing.JDialog();
        this.titleJLabel = new javax.swing.JLabel();
        this.colorRangeJLabel = new javax.swing.JLabel();
        this.redJLabel = new javax.swing.JLabel();
        this.minJLabel = new javax.swing.JLabel();
        this.maxJLabel = new javax.swing.JLabel();
        this.greenJLabel = new javax.swing.JLabel();
        this.blueJLabel = new javax.swing.JLabel();
        this.minRedJTextField = new javax.swing.JTextField();
        this.maxRedJTextField = new javax.swing.JTextField();
        this.maxGreenJTextField = new javax.swing.JTextField();
        this.minBlueJTextField = new javax.swing.JTextField();
        this.maxBlueJTextField = new javax.swing.JTextField();
        this.okJButton = new javax.swing.JButton();
        this.minGreenJTextField = new javax.swing.JTextField();
        this.jPanel1 = new javax.swing.JPanel();
        this.mainJMenuBar = new javax.swing.JMenuBar();
        this.fileJMenu = new javax.swing.JMenu();
        this.openImageJMenuItem = new javax.swing.JMenuItem();
        this.processingJMenu = new javax.swing.JMenu();
        this.analyzeJMenuItem = new javax.swing.JMenuItem();
        this.generateSpriteSplitterMenuItem = new javax.swing.JMenuItem();
        this.generateRotationMenuItem = new javax.swing.JMenuItem();
        this.generateMirrorSpriteMenuItem = new javax.swing.JMenuItem();
        this.generateRotationSpriteJMenuItem = new javax.swing.JMenuItem();
        this.createStripImageJMenuItem = new javax.swing.JMenuItem();
        this.mirrorJMenuItem = new javax.swing.JMenuItem();
        this.scaleImagesJMenuItem = new javax.swing.JMenuItem();
        this.canvasImagesJMenuItem = new javax.swing.JMenuItem();
        this.createIconImagesJMenuItem = new javax.swing.JMenuItem();
        this.analysisActionJDialog.setMinimumSize(new java.awt.Dimension(350, 250));
        this.titleJLabel.setText("              Color At Action Options            ");
        this.colorRangeJLabel.setText("Color Range");
        this.redJLabel.setText("Red:");
        this.minJLabel.setText("Minimum");
        this.maxJLabel.setText("Maximum");
        this.greenJLabel.setText("Green:");
        this.blueJLabel.setText("Blue:");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        org.jdesktop.layout.GroupLayout analysisActionJDialogLayout = new org.jdesktop.layout.GroupLayout(this.analysisActionJDialog.getContentPane());
        this.analysisActionJDialog.getContentPane().setLayout(analysisActionJDialogLayout);
        analysisActionJDialogLayout.setHorizontalGroup(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(analysisActionJDialogLayout.createSequentialGroup().addContainerGap().add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(analysisActionJDialogLayout.createSequentialGroup().add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(blueJLabel).add(greenJLabel).add(redJLabel).add(colorRangeJLabel)).add(29, 29, 29).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(org.jdesktop.layout.GroupLayout.TRAILING, minJLabel, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 58, Short.MAX_VALUE).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING, false).add(org.jdesktop.layout.GroupLayout.LEADING, minBlueJTextField).add(org.jdesktop.layout.GroupLayout.LEADING, minGreenJTextField).add(org.jdesktop.layout.GroupLayout.LEADING, minRedJTextField, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 42, Short.MAX_VALUE).add(org.jdesktop.layout.GroupLayout.LEADING, okJButton))).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING).add(org.jdesktop.layout.GroupLayout.LEADING, analysisActionJDialogLayout.createSequentialGroup().add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING, false).add(org.jdesktop.layout.GroupLayout.LEADING, maxRedJTextField).add(org.jdesktop.layout.GroupLayout.LEADING, analysisActionJDialogLayout.createSequentialGroup().add(1, 1, 1).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(maxBlueJTextField).add(maxGreenJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 43, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)))).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, 17, Short.MAX_VALUE)).add(org.jdesktop.layout.GroupLayout.LEADING, maxJLabel, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 61, Short.MAX_VALUE)).addContainerGap()).add(org.jdesktop.layout.GroupLayout.TRAILING, analysisActionJDialogLayout.createSequentialGroup().add(titleJLabel).add(25, 25, 25)))));
        analysisActionJDialogLayout.setVerticalGroup(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(analysisActionJDialogLayout.createSequentialGroup().add(titleJLabel).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(minJLabel).add(colorRangeJLabel).add(maxJLabel)).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING).add(redJLabel).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(minRedJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).add(maxRedJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING).add(greenJLabel).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(minGreenJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).add(maxGreenJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING).add(blueJLabel).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(minBlueJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).add(maxBlueJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))).add(16, 16, 16).add(okJButton).addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        getContentPane().setLayout(new java.awt.GridLayout(1, 0));
        this.jPanel1.setLayout(new java.awt.GridLayout(1, 0));
        getContentPane().add(this.jPanel1);
        this.fileJMenu.setText("File");
        this.fileJMenu.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                fileJMenuActionPerformed(evt);
            }

#endif
);
        this.openImageJMenuItem.setText("Open");
        this.openImageJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                openImageJMenuItemActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.openImageJMenuItem);
        this.mainJMenuBar.add(this.fileJMenu);
        this.processingJMenu.setText("Processing");
        this.processingJMenu.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                processingJMenuActionPerformed(evt);
            }

#endif
);
        this.analyzeJMenuItem.setText("Image Analyze");
        this.analyzeJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                analyzeJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.analyzeJMenuItem);
        this.generateMirrorSpriteMenuItem.setText("Mirror Sprite Generator");
        this.generateMirrorSpriteMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                generateMirrorSpriteMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.generateMirrorSpriteMenuItem);
        this.generateRotationSpriteJMenuItem.setText("Rotation Sprite Generator");
        this.generateRotationSpriteJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                generateRotationSpriteJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.generateRotationSpriteJMenuItem);
        this.generateSpriteSplitterMenuItem.setText("Sprite Splitter Generator");
        this.generateSpriteSplitterMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                generateSpriteSplitterMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.generateSpriteSplitterMenuItem);
        this.generateRotationMenuItem.setText("Rotate Image Generator");
        this.generateRotationMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                generateRotationMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.generateRotationMenuItem);
        this.createStripImageJMenuItem.setText("Multi Image Unifier");
        this.createStripImageJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                createStripImageJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.createStripImageJMenuItem);
        this.mirrorJMenuItem.setText("Mirror Image(s)");
        this.mirrorJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mirrorJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.mirrorJMenuItem);
        this.scaleImagesJMenuItem.setText("Scale Image(s)");
        this.scaleImagesJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                scaleImagesJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.scaleImagesJMenuItem);
        this.canvasImagesJMenuItem.setText("Canvas Image(s)");
        this.canvasImagesJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                canvasImagesJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.canvasImagesJMenuItem);
        this.createIconImagesJMenuItem.setText("Create Icon Image(s)");
        this.createIconImagesJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                createIconsJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.createIconImagesJMenuItem);
        this.mainJMenuBar.add(this.processingJMenu);
        setJMenuBar(this.mainJMenuBar);
        pack();
    }

    private void createStripImageJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            ImageUnifierJPanel imageUnifierJPanel = new ImageUnifierJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(imageUnifierJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = imageUnifierJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "createStripImageJMenuItemActionPerformed", e);
        }
    }

    private void okJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "okJButtonActionPerformed");
            ImageAnalysisResults[] imageAnalysisResultsArray = ImageAnalysis.getInstance().process(this.imageProcessorInput.getBufferedImageArray(), this.getColorRangeInterface());
            this.jPanel1.removeAll();
            this.jPanel1.add(new ImageAnalysisResultsJPanel(imageAnalysisResultsArray));
            this.jPanel1.updateUI();
            this.analysisActionJDialog.setVisible(false);
            ImageToolJFrame.imageProcessorInputCompositeInterface = null;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "okJButtonActionPerformed", e);
        }
    }

    private void processingJMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void openImageJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "openImageJMenuItemActionPerformed");
            this.fileJDialog.setVisible(true);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "openImageJMenuItemActionPerformed", e);
        }
    }

    public virtual void onFiles(File[] files)
    {
        try {
            this.logUtil.putF("Reading " + files.Length + " files.", this, "onFiles");
            Arrays.sort(files, new Comparator<File>()
#if JAVA_ANONYMOUS_CLASS_BODY
                public virtual int compare(File file1, File file2)
                {
                    int fileNameIndexValue1 = extractIndexNumberIfAnyFromFileName(file1.getName());
                    int fileNameIndexValue2 = extractIndexNumberIfAnyFromFileName(file2.getName());
                    return fileNameIndexValue1 - fileNameIndexValue2;
                }

                private int extractIndexNumberIfAnyFromFileName(string name)
                {
                    int i = 0;
                    try {
                        int start = name.LastIndexOf('_') + 1;
                        int end = name.LastIndexOf('.');
                        string number = name.Substring(start, (end) - (start));
                        i = int.Parse(number);
                    } catch (Exception e) {
                        i = 0;
                    }
                    return i;
                }

#endif
);
            BufferedImage[] bufferedImageArray = new BufferedImage[files.Length];
            for (int index = 0; index < files.Length; index++) {
                bufferedImageArray[index] = ImageIO.read(files[index]);
                if (bufferedImageArray[index] == null) {
                    throw new Exception("Unable to read file: " + files[index].getPath());
                }
            }
            this.imageProcessorInput = new ImageProcessorInput(files, bufferedImageArray);
            this.fileJDialog.setVisible(false);
            if (ImageToolJFrame.imageProcessorInputCompositeInterface != null) {
                ImageToolJFrame.imageProcessorInputCompositeInterface.setImageProcessorInput(this.imageProcessorInput);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onFiles", e);
        }
    }

    private void fileJMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void analyzeJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "analyzeJMenuItemActionPerformed");
            this.analysisActionJDialog.setVisible(true);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "analyzeJMenuItemActionPerformed", e);
        }
    }

    private void generateRotationSpriteJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "generateRotationSpriteJMenuItemActionPerformed");
            RotationSpriteImageJPanel spriteImageJPanel = new RotationSpriteImageJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(spriteImageJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = spriteImageJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateRotationSpriteJMenuItemActionPerformed", e);
        }
    }

    private void generateSpriteSplitterMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "generateRotationSpriteJMenuItemActionPerformed");
            SpriteSplitterImageJPanel imageJPanel = new SpriteSplitterImageJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(imageJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = imageJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateRotationMenuItemActionPerformed", e);
        }
    }

    private void generateRotationMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "generateRotationSpriteJMenuItemActionPerformed");
            RotationImageJPanel rotationImageJPanel = new RotationImageJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(rotationImageJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = rotationImageJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateRotationMenuItemActionPerformed", e);
        }
    }

    private void scaleImagesJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "scaleImagesJMenuItemActionPerformed");
            ResizeImageJPanel resizeImageJPanel = new ResizeImageJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(resizeImageJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = resizeImageJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "scaleImagesJMenuItemActionPerformed", e);
        }
    }

    private void createIconsJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "createIconsJMenuItemActionPerformed");
            CreateIconImagesJPanel createIconImagesJPanel = new CreateIconImagesJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(createIconImagesJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = createIconImagesJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "scaleImagesJMenuItemActionPerformed", e);
        }
    }

    private void canvasImagesJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "canvasImagesJMenuItemActionPerformed");
            CanvasImageJPanel resizeImageJPanel = new CanvasImageJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(resizeImageJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = resizeImageJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "scaleImagesJMenuItemActionPerformed", e);
        }
    }

    private void generateMirrorSpriteMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "generateMirrorSpriteJMenuItemActionPerformed");
            MirrorSpriteImageJPanel spriteImageJPanel = new MirrorSpriteImageJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(spriteImageJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = spriteImageJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateMirrorSpriteJMenuItemActionPerformed", e);
        }
    }

    private void mirrorJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "generateMirrorJMenuItemActionPerformed");
            MirrorImageJPanel mirrorImageJPanel = new MirrorImageJPanel(this.imageProcessorInput);
            this.jPanel1.removeAll();
            this.jPanel1.add(mirrorImageJPanel);
            this.jPanel1.updateUI();
            ImageToolJFrame.imageProcessorInputCompositeInterface = mirrorImageJPanel;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateMirrorJMenuItemActionPerformed", e);
        }
    }

    private ColorRangeInterface getColorRangeInterface()
    {
        ColorRangeInterface colorRangeInterface = ((ColorRangeInterface) new ColorRange());
        colorRangeInterface.setMinRed(((int) this.getMinRedJTextField().getText()));
        colorRangeInterface.setMaxRed(((int) this.getMaxRedJTextField().getText()));
        colorRangeInterface.setMinGreen(((int) this.getMinGreenJTextField().getText()));
        colorRangeInterface.setMaxGreen(((int) this.getMaxGreenJTextField().getText()));
        colorRangeInterface.setMinBlue(((int) this.getMinBlueJTextField().getText()));
        colorRangeInterface.setMaxBlue(((int) this.getMaxBlueJTextField().getText()));
        return colorRangeInterface;
    }

    public virtual javax.swing.JTextField getMaxBlueJTextField()
    {
        return this.maxBlueJTextField;
    }

    public virtual void setMaxBlueJTextField(javax.swing.JTextField maxBlueJTextField)
    {
        this.maxBlueJTextField = this.maxBlueJTextField;
    }

    public virtual javax.swing.JTextField getMaxGreenJTextField()
    {
        return this.maxGreenJTextField;
    }

    public virtual void setMaxGreenJTextField(javax.swing.JTextField maxGreenJTextField)
    {
        this.maxGreenJTextField = this.maxGreenJTextField;
    }

    public virtual javax.swing.JTextField getMaxRedJTextField()
    {
        return this.maxRedJTextField;
    }

    public virtual void setMaxRedJTextField(javax.swing.JTextField maxRedJTextField)
    {
        this.maxRedJTextField = this.maxRedJTextField;
    }

    public virtual javax.swing.JTextField getMinBlueJTextField()
    {
        return this.minBlueJTextField;
    }

    public virtual void setMinBlueJTextField(javax.swing.JTextField minBlueJTextField)
    {
        this.minBlueJTextField = this.minBlueJTextField;
    }

    public virtual javax.swing.JTextField getMinGreenJTextField()
    {
        return this.minGreenJTextField;
    }

    public virtual void setMinGreenJTextField(javax.swing.JTextField minGreenJTextField)
    {
        this.minGreenJTextField = this.minGreenJTextField;
    }

    public virtual javax.swing.JTextField getMinRedJTextField()
    {
        return this.minRedJTextField;
    }

    public virtual void setMinRedJTextField(javax.swing.JTextField minRedJTextField)
    {
        this.minRedJTextField = this.minRedJTextField;
    }

    private javax.swing.JDialog analysisActionJDialog = null;
    private javax.swing.JMenuItem analyzeJMenuItem = null;
    private javax.swing.JLabel blueJLabel = null;
    private javax.swing.JLabel colorRangeJLabel = null;
    private javax.swing.JMenuItem createStripImageJMenuItem = null;
    private javax.swing.JMenu fileJMenu = null;
    private javax.swing.JMenuItem generateSpriteSplitterMenuItem = null;
    private javax.swing.JMenuItem generateRotationMenuItem = null;
    private javax.swing.JMenuItem generateMirrorSpriteMenuItem = null;
    private javax.swing.JMenuItem generateRotationSpriteJMenuItem = null;
    private javax.swing.JLabel greenJLabel = null;
    private javax.swing.JPanel jPanel1 = null;
    private javax.swing.JMenuBar mainJMenuBar = null;
    private javax.swing.JTextField maxBlueJTextField = null;
    private javax.swing.JTextField maxGreenJTextField = null;
    private javax.swing.JLabel maxJLabel = null;
    private javax.swing.JTextField maxRedJTextField = null;
    private javax.swing.JTextField minBlueJTextField = null;
    private javax.swing.JTextField minGreenJTextField = null;
    private javax.swing.JLabel minJLabel = null;
    private javax.swing.JTextField minRedJTextField = null;
    private javax.swing.JMenuItem mirrorJMenuItem = null;
    private javax.swing.JButton okJButton = null;
    private javax.swing.JMenuItem openImageJMenuItem = null;
    private javax.swing.JMenu processingJMenu = null;
    private javax.swing.JLabel redJLabel = null;
    private javax.swing.JMenuItem scaleImagesJMenuItem = null;
    private javax.swing.JMenuItem canvasImagesJMenuItem = null;
    private javax.swing.JMenuItem createIconImagesJMenuItem = null;
    private javax.swing.JLabel titleJLabel = null;
}

