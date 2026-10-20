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
//using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
//using RenderedImage = java.awt.image.RenderedImage;
//using File = java.io.File;
//using IOException = java.io.IOException;
//using ImageIO = javax.imageio.ImageIO;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ImageProcessedVisitor = org.allbinary.media.image.ImageProcessedVisitor;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageStrings = org.allbinary.media.image.ImageStrings;
using SpriteSplitterUtil = org.allbinary.media.image.SpriteSplitterUtil;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image.gui;

public class SpriteSplitterImageJPanel : javax.swing.JPanel, ImageProcessedVisitor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly ImageStrings imageStrings = ImageStrings.getInstance();
    private ImageProcessorInput imageProcessorInput;
    private BufferedImage result = null;
    public SpriteSplitterImageJPanel(ImageProcessorInput imageProcessorInput) : base()
    {
        // base() is called from the constructor declaration
        initComponents();
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
                    SpriteSplitterUtil spriteSplitterUtil = SpriteSplitterUtil.getInstance();
                    string spriteType = ((string) spriteTypeJComboBox.getSelectedItem());
                    int? totalFrames = (((string) totalFramesJComboBox.getSelectedItem())).ToString();
                    int? totalAnimations = (((string) totalAnimationsJComboBox.getSelectedItem())).ToString();
                    int widthReduction = (widthReductionTextField.getText()).ToString();
                    int heightReduction = (heightReductionTextField.getText()).ToString();
                    int increaseWidth = (increaseWidthTextField.getText()).ToString();
                    int increaseHeight = (increaseHeightTextField.getText()).ToString();
                    spriteSplitterUtil.process(this.getImageProcessorInput(), totalFrames, totalAnimations, widthReduction, heightReduction, increaseWidth, increaseHeight, spriteType, this);
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
.start();
    }

    private void initComponents()
    {
        this.writeOverOriginalJCheckBox = new javax.swing.JCheckBox();
        this.widthReductionTextField = new javax.swing.JTextField();
        this.jLabel5 = new javax.swing.JLabel();
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
        this.jLabel4 = new javax.swing.JLabel();
        this.jLabel6 = new javax.swing.JLabel();
        this.heightReductionTextField = new javax.swing.JTextField();
        this.generateJButton = new javax.swing.JButton();
        this.jPanel2 = new javax.swing.JPanel();
        this.jLabel1 = new javax.swing.JLabel();
        this.totalFramesJComboBox = new javax.swing.JComboBox();
        int size = 70;
        string[] animationStringArray2 = new string[size - 1];
        for (int index = 1; index < size; index++) {
            animationStringArray2[index - 1] = (index).ToString();
        }
        this.totalFramesJComboBox.setModel(new javax.swing.DefaultComboBoxModel(animationStringArray2));
        this.jLabel2 = new javax.swing.JLabel();
        this.totalAnimationsJComboBox = new javax.swing.JComboBox();
        string[] animationStringArray = new string[size - 1];
        for (int index = 1; index < size; index++) {
            animationStringArray[index - 1] = (index).ToString();
        }
        this.totalAnimationsJComboBox.setModel(new javax.swing.DefaultComboBoxModel(animationStringArray));
        this.jLabel3 = new javax.swing.JLabel();
        this.spriteTypeJComboBox = new javax.swing.JComboBox();
        this.spriteTypeJComboBox.setModel(new javax.swing.DefaultComboBoxModel(new string[] { org.allbinary.media.image.SpriteSplitterUtil.getInstance().DIRECTIONAL_ANIMATIONS, org.allbinary.media.image.SpriteSplitterUtil.getInstance().HORIZONTAL_ANIMATIONS, org.allbinary.media.image.SpriteSplitterUtil.getInstance().HORIZONTAL_SPRITE }));
        jLabel7 = new javax.swing.JLabel();
        this.increaseWidthTextField = new javax.swing.JTextField();
        this.jLabel8 = new javax.swing.JLabel();
        this.increaseHeightTextField = new javax.swing.JTextField();
        this.writeOverOriginalJCheckBox.setText("Write Over Original");
        this.writeOverOriginalJCheckBox.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                writeOverOriginalJCheckBoxActionPerformed(evt);
            }

#endif
);
        this.widthReductionTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.widthReductionTextField.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                widthReductionTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel5.setText("Less Width:");
        this.jLabel4.setText("Results:");
        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addComponent(jLabel4).addGap(0, 0, short.MaxValue)));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addComponent(jLabel4).addGap(0, 184, short.MaxValue)));
        this.jLabel6.setText("Less Height:");
        this.heightReductionTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.generateJButton.setText("Generate");
        this.generateJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                generateJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Row Total:");
        this.totalFramesJComboBox.setSelectedIndex(1);
        this.totalFramesJComboBox.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                totalFramesJComboBoxActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Column Total :");
        this.totalAnimationsJComboBox.setSelectedIndex(3);
        this.totalAnimationsJComboBox.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                totalAnimationsJComboBoxActionPerformed(evt);
            }

#endif
);
        this.jLabel3.setText("Type:");
        this.spriteTypeJComboBox.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                spriteTypeJComboBoxActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout jPanel2Layout = new javax.swing.GroupLayout(this.jPanel2);
        this.jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel2Layout.createSequentialGroup().addContainerGap().addComponent(jLabel1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(totalFramesJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 48, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel2).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(totalAnimationsJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 39, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel3).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(spriteTypeJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 172, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        jPanel2Layout.setVerticalGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(jPanel2Layout.createSequentialGroup().addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue).addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(totalFramesJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel2).addComponent(totalAnimationsJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel3).addComponent(spriteTypeJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))));
        this.jLabel7.setText("More Width:");
        this.increaseWidthTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.increaseWidthTextField.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                increaseWidthTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel8.setText("More Height:");
        this.increaseHeightTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jPanel2, javax.swing.GroupLayout.PREFERRED_SIZE, 415, short.MaxValue).addGap(78, 78, 78)).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(writeOverOriginalJCheckBox).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(generateJButton)).addGroup(layout.createSequentialGroup().addComponent(jLabel5).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(widthReductionTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 41, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel6).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(heightReductionTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 46, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel7).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(increaseWidthTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 41, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel8).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(increaseHeightTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 46, javax.swing.GroupLayout.PREFERRED_SIZE))).addGap(0, 0, short.MaxValue))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jPanel2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel7).addComponent(increaseWidthTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 22, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel8).addComponent(increaseHeightTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel5).addComponent(widthReductionTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 22, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel6).addComponent(heightReductionTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(writeOverOriginalJCheckBox).addComponent(generateJButton)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
    }

    private void writeOverOriginalJCheckBoxActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void generateJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.process();
    }

    private void spriteTypeJComboBoxActionPerformed(java.awt.event.ActionEvent evt)
    {
        SpriteSplitterUtil spriteSplitterUtil = SpriteSplitterUtil.getInstance();
        this.jLabel1.setText(spriteSplitterUtil.ANIMATIONS_LABELS[this.spriteTypeJComboBox.getSelectedIndex()]);
        this.jLabel2.setText(spriteSplitterUtil.ANIMATIONS_LABELS[this.spriteTypeJComboBox.getSelectedIndex() + 1]);
    }

    private void totalAnimationsJComboBoxActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void totalFramesJComboBoxActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void widthReductionTextFieldActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void increaseWidthTextFieldActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private javax.swing.JButton generateJButton = null;
    private javax.swing.JTextField heightReductionTextField = null;
    private javax.swing.JTextField increaseHeightTextField = null;
    private javax.swing.JTextField increaseWidthTextField = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JLabel jLabel2 = null;
    private javax.swing.JLabel jLabel3 = null;
    private javax.swing.JLabel jLabel4 = null;
    private javax.swing.JLabel jLabel5 = null;
    private javax.swing.JLabel jLabel6 = null;
    private javax.swing.JLabel jLabel7 = null;
    private javax.swing.JLabel jLabel8 = null;
    private javax.swing.JPanel jPanel1 = null;
    private javax.swing.JPanel jPanel2 = null;
    private javax.swing.JComboBox<string> spriteTypeJComboBox = null;
    private javax.swing.JComboBox<string> totalAnimationsJComboBox = null;
    private javax.swing.JComboBox<string> totalFramesJComboBox = null;
    private javax.swing.JTextField widthReductionTextField = null;
    private javax.swing.JCheckBox writeOverOriginalJCheckBox = null;
    public virtual ImageProcessorInput getImageProcessorInput()
    {
        return this.imageProcessorInput;
    }

    public virtual void setImageProcessorInput(ImageProcessorInput imageProcessorInput)
    {
        this.imageProcessorInput = imageProcessorInput;
    }

    // throws IOException
    public override void visit(BufferedImage generatedBufferedImage, string name, int index)
    {
        this.logUtil.putF(this.commonStrings.VISIT, this, this.commonStrings.VISIT);
        this.result = generatedBufferedImage;
        this.getParent().repaint();
        File file = this.imageProcessorInput.getFiles()[index];
        if (!this.writeOverOriginalJCheckBox.isSelected()) {
            string filePath = file.getAbsolutePath();
            int extensionIndex = filePath.IndexOf(this.imageStrings.PNG_EXTENSION);
            filePath = new StringMaker().append(filePath.Substring(0, (extensionIndex) - (0))).append(this.commonSeps.UNDERSCORE).append(name).append(this.imageStrings.PNG_EXTENSION).ToString();
            file = new File(filePath);
        }
        bool isWritten = ImageIO.write(((RenderedImage) this.result), imageStrings.PNG, file);
        this.logUtil.putF(new StringMaker().append("File: ").append(StringUtil.getInstance().toString(file)).append(" Wrote: ").appendboolean(isWritten).ToString(), this, this.commonStrings.RUN);
    }

}

