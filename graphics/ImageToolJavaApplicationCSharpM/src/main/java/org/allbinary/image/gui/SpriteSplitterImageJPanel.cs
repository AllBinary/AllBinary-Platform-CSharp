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
using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
//using RenderedImage = java.awt.image.RenderedImage;
using File = java.io.File;
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
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using javax.swing;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JCheckBox = javax.swing.JCheckBox;
//using javax.swing;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.image.gui;

public class SpriteSplitterImageJPanel : JPanel, ImageProcessedVisitor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly ImageStrings imageStrings = ImageStrings.getInstance();
    private ImageProcessorInput imageProcessorInput;
    private BufferedImage result = null;
    public SpriteSplitterImageJPanel(ImageProcessorInput imageProcessorInput) : base()
    {
        // Constructor invocation emitted in the initializer.
        initComponents();
        this.imageProcessorInput = imageProcessorInput;
    }

    public virtual void process()
    {
        new __SwtClosure_N66636((__swtSelf_N66636) => {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    SpriteSplitterUtil spriteSplitterUtil = SpriteSplitterUtil.getInstance();
                    string spriteType = ((string) spriteTypeJComboBox.getSelectedItem());
                    int? totalFrames = int.Parse((((string) totalFramesJComboBox.getSelectedItem())).ToString());
                    int? totalAnimations = int.Parse((((string) totalAnimationsJComboBox.getSelectedItem())).ToString());
                    int widthReduction = int.Parse((widthReductionTextField.getText()).ToString());
                    int heightReduction = int.Parse((heightReductionTextField.getText()).ToString());
                    int increaseWidth = int.Parse((increaseWidthTextField.getText()).ToString());
                    int increaseHeight = int.Parse((increaseHeightTextField.getText()).ToString());
                    spriteSplitterUtil.process(this.getImageProcessorInput(), totalFrames, totalAnimations, widthReduction, heightReduction, increaseWidth, increaseHeight, spriteType, this);
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, __swtSelf_N66636, commonStrings.RUN, e);
                }
            }).start();
    }

    private void initComponents()
    {
        this.writeOverOriginalJCheckBox = new JCheckBox();
        this.widthReductionTextField = new JTextField();
        this.jLabel5 = new JLabel();
        this.jPanel1 = new JPanel()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void paint(Graphics graphics)
            {
                if (this.result != null) {
                    graphics.drawImage(this.result, 0, 0, this.result.getWidth(null), this.result.getHeight(null), null);
                }
            }

#endif
;
        this.jLabel4 = new JLabel();
        this.jLabel6 = new JLabel();
        this.heightReductionTextField = new JTextField();
        this.generateJButton = new JButton();
        this.jPanel2 = new JPanel();
        this.jLabel1 = new JLabel();
        this.totalFramesJComboBox = new JComboBox();
        int size = 70;
        string[] animationStringArray2 = new string[size - 1];
        for (int index_0 = 1; index_0 < size; index_0++) {
            animationStringArray2[index_0 - 1] = (index_0).ToString();
        }
        this.totalFramesJComboBox.setModel(new DefaultComboBoxModel(animationStringArray2));
        this.jLabel2 = new JLabel();
        this.totalAnimationsJComboBox = new JComboBox();
        string[] animationStringArray = new string[size - 1];
        for (int index_1 = 1; index_1 < size; index_1++) {
            animationStringArray[index_1 - 1] = (index_1).ToString();
        }
        this.totalAnimationsJComboBox.setModel(new DefaultComboBoxModel(animationStringArray));
        this.jLabel3 = new JLabel();
        this.spriteTypeJComboBox = new JComboBox();
        this.spriteTypeJComboBox.setModel(new DefaultComboBoxModel(new string[] { SpriteSplitterUtil.getInstance().DIRECTIONAL_ANIMATIONS, SpriteSplitterUtil.getInstance().HORIZONTAL_ANIMATIONS, SpriteSplitterUtil.getInstance().HORIZONTAL_SPRITE }));
        jLabel7 = new JLabel();
        this.increaseWidthTextField = new JTextField();
        this.jLabel8 = new JLabel();
        this.increaseHeightTextField = new JTextField();
        this.writeOverOriginalJCheckBox.setText("Write Over Original");
        this.writeOverOriginalJCheckBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                writeOverOriginalJCheckBoxActionPerformed(evt);
            }

#endif
);
        this.widthReductionTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.widthReductionTextField.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                widthReductionTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel5.setText("Less Width:");
        this.jLabel4.setText("Results:");
        GroupLayout jPanel1Layout = new GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addComponent(jLabel4).addGap(0, 0, short.MaxValue)));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addComponent(jLabel4).addGap(0, 184, short.MaxValue)));
        this.jLabel6.setText("Less Height:");
        this.heightReductionTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.generateJButton.setText("Generate");
        this.generateJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                generateJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Row Total:");
        this.totalFramesJComboBox.setSelectedIndex(1);
        this.totalFramesJComboBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                totalFramesJComboBoxActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Column Total :");
        this.totalAnimationsJComboBox.setSelectedIndex(3);
        this.totalAnimationsJComboBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                totalAnimationsJComboBoxActionPerformed(evt);
            }

#endif
);
        this.jLabel3.setText("Type:");
        this.spriteTypeJComboBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                spriteTypeJComboBoxActionPerformed(evt);
            }

#endif
);
        GroupLayout jPanel2Layout = new GroupLayout(this.jPanel2);
        this.jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(GroupLayout.Alignment.TRAILING, jPanel2Layout.createSequentialGroup().addContainerGap().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(totalFramesJComboBox, GroupLayout.PREFERRED_SIZE, 48, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel2).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(totalAnimationsJComboBox, GroupLayout.PREFERRED_SIZE, 39, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel3).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(spriteTypeJComboBox, GroupLayout.PREFERRED_SIZE, 172, GroupLayout.PREFERRED_SIZE).addContainerGap(GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        jPanel2Layout.setVerticalGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel2Layout.createSequentialGroup().addContainerGap(GroupLayout.DEFAULT_SIZE, short.MaxValue).addGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(totalFramesJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel2).addComponent(totalAnimationsJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel3).addComponent(spriteTypeJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))));
        this.jLabel7.setText("More Width:");
        this.increaseWidthTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.increaseWidthTextField.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                increaseWidthTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel8.setText("More Height:");
        this.increaseHeightTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jPanel2, GroupLayout.PREFERRED_SIZE, 415, short.MaxValue).addGap(78, 78, 78)).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jPanel1, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(writeOverOriginalJCheckBox).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(generateJButton)).addGroup(layout.createSequentialGroup().addComponent(jLabel5).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(widthReductionTextField, GroupLayout.PREFERRED_SIZE, 41, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel6).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(heightReductionTextField, GroupLayout.PREFERRED_SIZE, 46, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel7).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(increaseWidthTextField, GroupLayout.PREFERRED_SIZE, 41, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel8).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(increaseHeightTextField, GroupLayout.PREFERRED_SIZE, 46, GroupLayout.PREFERRED_SIZE))).addGap(0, 0, short.MaxValue))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jPanel2, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel7).addComponent(increaseWidthTextField, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE).addComponent(jLabel8).addComponent(increaseHeightTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel5).addComponent(widthReductionTextField, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE).addComponent(jLabel6).addComponent(heightReductionTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(writeOverOriginalJCheckBox).addComponent(generateJButton)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jPanel1, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue)));
    }

    private void writeOverOriginalJCheckBoxActionPerformed(ActionEvent evt)
    {
    }

    private void generateJButtonActionPerformed(ActionEvent evt)
    {
        this.process();
    }

    private void spriteTypeJComboBoxActionPerformed(ActionEvent evt)
    {
        SpriteSplitterUtil spriteSplitterUtil = SpriteSplitterUtil.getInstance();
        this.jLabel1.setText(spriteSplitterUtil.ANIMATIONS_LABELS[this.spriteTypeJComboBox.getSelectedIndex()]);
        this.jLabel2.setText(spriteSplitterUtil.ANIMATIONS_LABELS[this.spriteTypeJComboBox.getSelectedIndex() + 1]);
    }

    private void totalAnimationsJComboBoxActionPerformed(ActionEvent evt)
    {
    }

    private void totalFramesJComboBoxActionPerformed(ActionEvent evt)
    {
    }

    private void widthReductionTextFieldActionPerformed(ActionEvent evt)
    {
    }

    private void increaseWidthTextFieldActionPerformed(ActionEvent evt)
    {
    }

    private JButton generateJButton = null;
    private JTextField heightReductionTextField = null;
    private JTextField increaseHeightTextField = null;
    private JTextField increaseWidthTextField = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JLabel jLabel3 = null;
    private JLabel jLabel4 = null;
    private JLabel jLabel5 = null;
    private JLabel jLabel6 = null;
    private JLabel jLabel7 = null;
    private JLabel jLabel8 = null;
    private JPanel jPanel1 = null;
    private JPanel jPanel2 = null;
    private JComboBox<string> spriteTypeJComboBox = null;
    private JComboBox<string> totalAnimationsJComboBox = null;
    private JComboBox<string> totalFramesJComboBox = null;
    private JTextField widthReductionTextField = null;
    private JCheckBox writeOverOriginalJCheckBox = null;
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

    private sealed class __SwtClosure_N66636 : global::org.allbinary.thread.NullThread
    {
        private readonly global::System.Action<__SwtClosure_N66636> callback1;

        public __SwtClosure_N66636(global::System.Action<__SwtClosure_N66636> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run() => callback1(this);
    }

}

