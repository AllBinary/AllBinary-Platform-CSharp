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
using CanvasExpandUtil = org.allbinary.media.image.CanvasExpandUtil;
using CanvasTrimUtil = org.allbinary.media.image.CanvasTrimUtil;
using ImageProcessedVisitor = org.allbinary.media.image.ImageProcessedVisitor;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageStrings = org.allbinary.media.image.ImageStrings;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JCheckBox = javax.swing.JCheckBox;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.image.gui;

public class CanvasImageJPanel : JPanel, ImageProcessedVisitor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly ImageStrings imageStrings = ImageStrings.getInstance();
    private ImageProcessorInput imageProcessorInput;
    private BufferedImage result = null;
    public CanvasImageJPanel(ImageProcessorInput imageProcessorInput) : base()
    {
        // base() is called from the constructor declaration
        initComponents();
        this.imageProcessorInput = imageProcessorInput;
    }

    public virtual void process()
    {
        new global::org.allbinary.thread.NullThread()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    CanvasTrimUtil canvasTrimUtil = CanvasTrimUtil.getInstance();
                    CanvasExpandUtil canvasExpandUtil = CanvasExpandUtil.getInstance();
                    int leftReduction = int.Parse((widthReductionTextField1.getText()).ToString());
                    int topReduction = int.Parse((heightReductionTextField1.getText()).ToString());
                    int widthReduction = int.Parse((widthReductionTextField.getText()).ToString());
                    int heightReduction = int.Parse((heightReductionTextField.getText()).ToString());
                    if (leftReduction <= 0 || topReduction <= 0 || widthReduction <= 0 || heightReduction <= 0) {
                        canvasTrimUtil.process(this.getImageProcessorInput(), -leftReduction, -topReduction, -widthReduction, -heightReduction, this);
                    } else {
                        canvasExpandUtil.process(this.getImageProcessorInput(), leftReduction, topReduction, this);
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
        this.writeOverOriginalJCheckBox = new JCheckBox();
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
        this.generateJButton = new JButton();
        this.jLabel4 = new JLabel();
        this.jPanel2 = new JPanel();
        this.jLabel5 = new JLabel();
        this.widthReductionTextField = new JTextField();
        this.jLabel6 = new JLabel();
        this.heightReductionTextField = new JTextField();
        this.widthReductionTextField1 = new JTextField();
        this.jLabel7 = new JLabel();
        this.jLabel8 = new JLabel();
        this.heightReductionTextField1 = new JTextField();
        this.writeOverOriginalJCheckBox.setSelected(true);
        this.writeOverOriginalJCheckBox.setText("Write Over Original");
        this.writeOverOriginalJCheckBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                writeOverOriginalJCheckBoxActionPerformed(evt);
            }

#endif
);
        GroupLayout jPanel1Layout = new GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 0, short.MaxValue));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 196, short.MaxValue));
        this.generateJButton.setText("Generate");
        this.generateJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                generateJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel4.setText("Results:");
        this.jLabel5.setText("Right:");
        this.widthReductionTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.widthReductionTextField.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                widthReductionTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel6.setText("Bottom");
        this.heightReductionTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.widthReductionTextField1.setText(CommonPhoneStrings.getInstance().ZERO);
        this.widthReductionTextField1.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                widthReductionTextField1ActionPerformed(evt);
            }

#endif
);
        this.jLabel7.setText("Top");
        this.jLabel8.setText("Left:");
        this.heightReductionTextField1.setText(CommonPhoneStrings.getInstance().ZERO);
        GroupLayout jPanel2Layout = new GroupLayout(this.jPanel2);
        this.jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel2Layout.createSequentialGroup().addContainerGap().addComponent(jLabel8).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(widthReductionTextField1, GroupLayout.PREFERRED_SIZE, 41, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel5).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(widthReductionTextField, GroupLayout.PREFERRED_SIZE, 41, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel7).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(heightReductionTextField1, GroupLayout.PREFERRED_SIZE, 46, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel6).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(heightReductionTextField, GroupLayout.PREFERRED_SIZE, 46, GroupLayout.PREFERRED_SIZE).addContainerGap(140, short.MaxValue)));
        jPanel2Layout.setVerticalGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(GroupLayout.Alignment.TRAILING, jPanel2Layout.createSequentialGroup().addGap(0, 16, short.MaxValue).addGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel6).addComponent(heightReductionTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel8).addComponent(widthReductionTextField1, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE).addComponent(jLabel7).addComponent(heightReductionTextField1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addGroup(jPanel2Layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel5).addComponent(widthReductionTextField, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE)))));
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jPanel2, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue).addGap(78, 78, 78)).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addComponent(jPanel1, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue)).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jLabel4).addGroup(layout.createSequentialGroup().addComponent(writeOverOriginalJCheckBox).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(generateJButton))).addGap(0, 0, short.MaxValue))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jPanel2, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(generateJButton).addComponent(writeOverOriginalJCheckBox)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel4).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jPanel1, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue)));
    }

    private void writeOverOriginalJCheckBoxActionPerformed(ActionEvent evt)
    {
    }

    private void generateJButtonActionPerformed(ActionEvent evt)
    {
        this.process();
    }

    private void widthReductionTextFieldActionPerformed(ActionEvent evt)
    {
    }

    private void widthReductionTextField1ActionPerformed(ActionEvent evt)
    {
    }

    private JButton generateJButton = null;
    private JTextField heightReductionTextField = null;
    private JTextField heightReductionTextField1 = null;
    private JLabel jLabel4 = null;
    private JLabel jLabel5 = null;
    private JLabel jLabel6 = null;
    private JLabel jLabel7 = null;
    private JLabel jLabel8 = null;
    private JPanel jPanel1 = null;
    private JPanel jPanel2 = null;
    private JTextField widthReductionTextField = null;
    private JTextField widthReductionTextField1 = null;
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

}

