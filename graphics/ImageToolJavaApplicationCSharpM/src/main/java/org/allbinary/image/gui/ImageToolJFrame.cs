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
using File = java.io.File;
using Arrays = java.util.Arrays;
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
//using Dimension = java.awt.Dimension;
//using GridLayout = java.awt.GridLayout;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using JButton = javax.swing.JButton;
//using JDialog = javax.swing.JDialog;
//using JFrame = javax.swing.JFrame;
//using JLabel = javax.swing.JLabel;
//using JMenu = javax.swing.JMenu;
//using JMenuBar = javax.swing.JMenuBar;
//using JMenuItem = javax.swing.JMenuItem;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using WindowConstants = javax.swing.WindowConstants;

namespace org.allbinary.image.gui;

public class ImageToolJFrame : JFrame, FileJDialogListenerInterface
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
        analysisActionJDialog = new JDialog();
        this.titleJLabel = new JLabel();
        this.colorRangeJLabel = new JLabel();
        this.redJLabel = new JLabel();
        this.minJLabel = new JLabel();
        this.maxJLabel = new JLabel();
        this.greenJLabel = new JLabel();
        this.blueJLabel = new JLabel();
        this.minRedJTextField = new JTextField();
        this.maxRedJTextField = new JTextField();
        this.maxGreenJTextField = new JTextField();
        this.minBlueJTextField = new JTextField();
        this.maxBlueJTextField = new JTextField();
        this.okJButton = new JButton();
        this.minGreenJTextField = new JTextField();
        this.jPanel1 = new JPanel();
        this.mainJMenuBar = new JMenuBar();
        this.fileJMenu = new JMenu();
        this.openImageJMenuItem = new JMenuItem();
        this.processingJMenu = new JMenu();
        this.analyzeJMenuItem = new JMenuItem();
        this.generateSpriteSplitterMenuItem = new JMenuItem();
        this.generateRotationMenuItem = new JMenuItem();
        this.generateMirrorSpriteMenuItem = new JMenuItem();
        this.generateRotationSpriteJMenuItem = new JMenuItem();
        this.createStripImageJMenuItem = new JMenuItem();
        this.mirrorJMenuItem = new JMenuItem();
        this.scaleImagesJMenuItem = new JMenuItem();
        this.canvasImagesJMenuItem = new JMenuItem();
        this.createIconImagesJMenuItem = new JMenuItem();
        this.analysisActionJDialog.setMinimumSize(new Dimension(350, 250));
        this.titleJLabel.setText("              Color At Action Options            ");
        this.colorRangeJLabel.setText("Color Range");
        this.redJLabel.setText("Red:");
        this.minJLabel.setText("Minimum");
        this.maxJLabel.setText("Maximum");
        this.greenJLabel.setText("Green:");
        this.blueJLabel.setText("Blue:");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        org.jdesktop.layout.GroupLayout analysisActionJDialogLayout = new org.jdesktop.layout.GroupLayout(this.analysisActionJDialog.getContentPane());
        this.analysisActionJDialog.getContentPane().setLayout(analysisActionJDialogLayout);
        analysisActionJDialogLayout.setHorizontalGroup(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(analysisActionJDialogLayout.createSequentialGroup().addContainerGap().add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(analysisActionJDialogLayout.createSequentialGroup().add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(blueJLabel).add(greenJLabel).add(redJLabel).add(colorRangeJLabel)).add(29, 29, 29).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(org.jdesktop.layout.GroupLayout.TRAILING, minJLabel, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 58, short.MaxValue).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING, false).add(org.jdesktop.layout.GroupLayout.LEADING, minBlueJTextField).add(org.jdesktop.layout.GroupLayout.LEADING, minGreenJTextField).add(org.jdesktop.layout.GroupLayout.LEADING, minRedJTextField, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 42, short.MaxValue).add(org.jdesktop.layout.GroupLayout.LEADING, okJButton))).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING).add(org.jdesktop.layout.GroupLayout.LEADING, analysisActionJDialogLayout.createSequentialGroup().add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING, false).add(org.jdesktop.layout.GroupLayout.LEADING, maxRedJTextField).add(org.jdesktop.layout.GroupLayout.LEADING, analysisActionJDialogLayout.createSequentialGroup().add(1, 1, 1).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(maxBlueJTextField).add(maxGreenJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 43, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)))).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, 17, short.MaxValue)).add(org.jdesktop.layout.GroupLayout.LEADING, maxJLabel, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 61, short.MaxValue)).addContainerGap()).add(org.jdesktop.layout.GroupLayout.TRAILING, analysisActionJDialogLayout.createSequentialGroup().add(titleJLabel).add(25, 25, 25)))));
        analysisActionJDialogLayout.setVerticalGroup(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(analysisActionJDialogLayout.createSequentialGroup().add(titleJLabel).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(minJLabel).add(colorRangeJLabel).add(maxJLabel)).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING).add(redJLabel).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(minRedJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).add(maxRedJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING).add(greenJLabel).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(minGreenJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).add(maxGreenJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING).add(blueJLabel).add(analysisActionJDialogLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(minBlueJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).add(maxBlueJTextField, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))).add(16, 16, 16).add(okJButton).addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        getContentPane().setLayout(new GridLayout(1, 0));
        this.jPanel1.setLayout(new GridLayout(1, 0));
        getContentPane().add(this.jPanel1);
        this.fileJMenu.setText("File");
        this.fileJMenu.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                fileJMenuActionPerformed(evt);
            }

#endif
);
        this.openImageJMenuItem.setText("Open");
        this.openImageJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                openImageJMenuItemActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.openImageJMenuItem);
        this.mainJMenuBar.add(this.fileJMenu);
        this.processingJMenu.setText("Processing");
        this.processingJMenu.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                processingJMenuActionPerformed(evt);
            }

#endif
);
        this.analyzeJMenuItem.setText("Image Analyze");
        this.analyzeJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                analyzeJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.analyzeJMenuItem);
        this.generateMirrorSpriteMenuItem.setText("Mirror Sprite Generator");
        this.generateMirrorSpriteMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                generateMirrorSpriteMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.generateMirrorSpriteMenuItem);
        this.generateRotationSpriteJMenuItem.setText("Rotation Sprite Generator");
        this.generateRotationSpriteJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                generateRotationSpriteJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.generateRotationSpriteJMenuItem);
        this.generateSpriteSplitterMenuItem.setText("Sprite Splitter Generator");
        this.generateSpriteSplitterMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                generateSpriteSplitterMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.generateSpriteSplitterMenuItem);
        this.generateRotationMenuItem.setText("Rotate Image Generator");
        this.generateRotationMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                generateRotationMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.generateRotationMenuItem);
        this.createStripImageJMenuItem.setText("Multi Image Unifier");
        this.createStripImageJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                createStripImageJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.createStripImageJMenuItem);
        this.mirrorJMenuItem.setText("Mirror Image(s)");
        this.mirrorJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                mirrorJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.mirrorJMenuItem);
        this.scaleImagesJMenuItem.setText("Scale Image(s)");
        this.scaleImagesJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                scaleImagesJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.scaleImagesJMenuItem);
        this.canvasImagesJMenuItem.setText("Canvas Image(s)");
        this.canvasImagesJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                canvasImagesJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.canvasImagesJMenuItem);
        this.createIconImagesJMenuItem.setText("Create Icon Image(s)");
        this.createIconImagesJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
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

    private void createStripImageJMenuItemActionPerformed(ActionEvent evt)
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

    private void okJButtonActionPerformed(ActionEvent evt)
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

    private void processingJMenuActionPerformed(ActionEvent evt)
    {
    }

    private void openImageJMenuItemActionPerformed(ActionEvent evt)
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

    private void fileJMenuActionPerformed(ActionEvent evt)
    {
    }

    private void analyzeJMenuItemActionPerformed(ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "analyzeJMenuItemActionPerformed");
            this.analysisActionJDialog.setVisible(true);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "analyzeJMenuItemActionPerformed", e);
        }
    }

    private void generateRotationSpriteJMenuItemActionPerformed(ActionEvent evt)
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

    private void generateSpriteSplitterMenuItemActionPerformed(ActionEvent evt)
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

    private void generateRotationMenuItemActionPerformed(ActionEvent evt)
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

    private void scaleImagesJMenuItemActionPerformed(ActionEvent evt)
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

    private void createIconsJMenuItemActionPerformed(ActionEvent evt)
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

    private void canvasImagesJMenuItemActionPerformed(ActionEvent evt)
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

    private void generateMirrorSpriteMenuItemActionPerformed(ActionEvent evt)
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

    private void mirrorJMenuItemActionPerformed(ActionEvent evt)
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
        colorRangeInterface.setMinRed(global::java.lang.JavaNumber.intValue(this.getMinRedJTextField().getText()));
        colorRangeInterface.setMaxRed(global::java.lang.JavaNumber.intValue(this.getMaxRedJTextField().getText()));
        colorRangeInterface.setMinGreen(global::java.lang.JavaNumber.intValue(this.getMinGreenJTextField().getText()));
        colorRangeInterface.setMaxGreen(global::java.lang.JavaNumber.intValue(this.getMaxGreenJTextField().getText()));
        colorRangeInterface.setMinBlue(global::java.lang.JavaNumber.intValue(this.getMinBlueJTextField().getText()));
        colorRangeInterface.setMaxBlue(global::java.lang.JavaNumber.intValue(this.getMaxBlueJTextField().getText()));
        return colorRangeInterface;
    }

    public virtual JTextField getMaxBlueJTextField()
    {
        return this.maxBlueJTextField;
    }

    public virtual void setMaxBlueJTextField(JTextField maxBlueJTextField)
    {
        this.maxBlueJTextField = this.maxBlueJTextField;
    }

    public virtual JTextField getMaxGreenJTextField()
    {
        return this.maxGreenJTextField;
    }

    public virtual void setMaxGreenJTextField(JTextField maxGreenJTextField)
    {
        this.maxGreenJTextField = this.maxGreenJTextField;
    }

    public virtual JTextField getMaxRedJTextField()
    {
        return this.maxRedJTextField;
    }

    public virtual void setMaxRedJTextField(JTextField maxRedJTextField)
    {
        this.maxRedJTextField = this.maxRedJTextField;
    }

    public virtual JTextField getMinBlueJTextField()
    {
        return this.minBlueJTextField;
    }

    public virtual void setMinBlueJTextField(JTextField minBlueJTextField)
    {
        this.minBlueJTextField = this.minBlueJTextField;
    }

    public virtual JTextField getMinGreenJTextField()
    {
        return this.minGreenJTextField;
    }

    public virtual void setMinGreenJTextField(JTextField minGreenJTextField)
    {
        this.minGreenJTextField = this.minGreenJTextField;
    }

    public virtual JTextField getMinRedJTextField()
    {
        return this.minRedJTextField;
    }

    public virtual void setMinRedJTextField(JTextField minRedJTextField)
    {
        this.minRedJTextField = this.minRedJTextField;
    }

    private JDialog analysisActionJDialog = null;
    private JMenuItem analyzeJMenuItem = null;
    private JLabel blueJLabel = null;
    private JLabel colorRangeJLabel = null;
    private JMenuItem createStripImageJMenuItem = null;
    private JMenu fileJMenu = null;
    private JMenuItem generateSpriteSplitterMenuItem = null;
    private JMenuItem generateRotationMenuItem = null;
    private JMenuItem generateMirrorSpriteMenuItem = null;
    private JMenuItem generateRotationSpriteJMenuItem = null;
    private JLabel greenJLabel = null;
    private JPanel jPanel1 = null;
    private JMenuBar mainJMenuBar = null;
    private JTextField maxBlueJTextField = null;
    private JTextField maxGreenJTextField = null;
    private JLabel maxJLabel = null;
    private JTextField maxRedJTextField = null;
    private JTextField minBlueJTextField = null;
    private JTextField minGreenJTextField = null;
    private JLabel minJLabel = null;
    private JTextField minRedJTextField = null;
    private JMenuItem mirrorJMenuItem = null;
    private JButton okJButton = null;
    private JMenuItem openImageJMenuItem = null;
    private JMenu processingJMenu = null;
    private JLabel redJLabel = null;
    private JMenuItem scaleImagesJMenuItem = null;
    private JMenuItem canvasImagesJMenuItem = null;
    private JMenuItem createIconImagesJMenuItem = null;
    private JLabel titleJLabel = null;
}

