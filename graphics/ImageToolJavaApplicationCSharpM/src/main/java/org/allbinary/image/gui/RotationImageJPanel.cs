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
using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
//using RenderedImage = java.awt.image.RenderedImage;
using File = java.io.File;
//using IOException = java.io.IOException;
//using ImageIO = javax.imageio.ImageIO;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ImageArrayRotationUtil = org.allbinary.media.image.ImageArrayRotationUtil;
using ImageProcessedVisitor = org.allbinary.media.image.ImageProcessedVisitor;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageStrings = org.allbinary.media.image.ImageStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using DefaultComboBoxModel = javax.swing.DefaultComboBoxModel;
//using JButton = javax.swing.JButton;
//using JCheckBox = javax.swing.JCheckBox;
//using JComboBox = javax.swing.JComboBox;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;

namespace org.allbinary.image.gui;

public class RotationImageJPanel : JPanel, ImageProcessedVisitor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ImageStrings imageStrings = ImageStrings.getInstance();
    private ImageProcessorInput imageProcessorInput;
    private BufferedImage result = null;
    public RotationImageJPanel(ImageProcessorInput imageProcessorInput) : base()
    {
        // base() is called from the constructor declaration
        this.initComponents();
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
                    string angleAsString = ((string) this.totalAngleJComboBox.getSelectedItem());
                    ImageArrayRotationUtil.getInstance().process(this.getImageProcessorInput(), angleAsString, this);
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
.start();
    }

    private void initComponents()
    {
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
        this.jPanel2 = new JPanel();
        this.jLabel1 = new JLabel();
        this.generateJButton = new JButton();
        this.totalAngleJComboBox = new JComboBox();
        this.jLabel3 = new JLabel();
        this.writeOverOriginalJCheckBox = new JCheckBox();
        this.jPanel3 = new JPanel();
        this.jLabel2 = new JLabel();
        org.jdesktop.layout.GroupLayout jPanel1Layout = new org.jdesktop.layout.GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(0, 436, short.MaxValue));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(0, 227, short.MaxValue));
        this.generateJButton.setText("Generate");
        this.generateJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                generateJButtonActionPerformed(evt);
            }

#endif
);
        this.totalAngleJComboBox.setModel(new DefaultComboBoxModel(new string[] { this.commonStrings.UP, this.commonStrings.DOWN, "-90", "90" }));
        this.totalAngleJComboBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                totalAngleJComboBoxActionPerformed(evt);
            }

#endif
);
        this.jLabel3.setText("Total Angle:");
        this.writeOverOriginalJCheckBox.setText("Write Over Original");
        org.jdesktop.layout.GroupLayout jPanel2Layout = new org.jdesktop.layout.GroupLayout(this.jPanel2);
        this.jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(jPanel2Layout.createSequentialGroup().add(8, 8, 8).add(jLabel1).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(jLabel3).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(totalAngleJComboBox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(writeOverOriginalJCheckBox).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(generateJButton).addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        jPanel2Layout.setVerticalGroup(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE).add(jLabel1).add(generateJButton).add(totalAngleJComboBox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).add(jLabel3).add(writeOverOriginalJCheckBox)));
        this.jLabel2.setText("Results:");
        org.jdesktop.layout.GroupLayout jPanel3Layout = new org.jdesktop.layout.GroupLayout(this.jPanel3);
        this.jPanel3.setLayout(jPanel3Layout);
        jPanel3Layout.setHorizontalGroup(jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(jPanel3Layout.createSequentialGroup().add(jLabel2).addContainerGap(377, short.MaxValue)));
        jPanel3Layout.setVerticalGroup(jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(jLabel2));
        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(org.jdesktop.layout.GroupLayout.TRAILING, jPanel2, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue).add(layout.createSequentialGroup().addContainerGap().add(jPanel3, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue).addContainerGap()).add(jPanel1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue));
        layout.setVerticalGroup(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(layout.createSequentialGroup().add(jPanel2, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED).add(jPanel3, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED).add(jPanel1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
    }

    private void generateJButtonActionPerformed(ActionEvent evt)
    {
        this.process();
    }

    private void totalAngleJComboBoxActionPerformed(ActionEvent evt)
    {
    }

    private JButton generateJButton = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JLabel jLabel3 = null;
    private JPanel jPanel1 = null;
    private JPanel jPanel2 = null;
    private JPanel jPanel3 = null;
    private JComboBox totalAngleJComboBox = null;
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
    public virtual void visit(BufferedImage generatedBufferedImage, string name, int index)
    {
        this.result = generatedBufferedImage;
        this.getParent().repaint();
        File file = this.imageProcessorInput.getFiles()[index];
        if (!this.writeOverOriginalJCheckBox.isSelected()) {
            string filePath = file.getAbsolutePath();
            int extensionIndex = filePath.IndexOf(this.imageStrings.PNG_EXTENSION);
            filePath = new StringMaker().append(filePath.Substring(0, (extensionIndex) - (0))).append(CommonSeps.getInstance().UNDERSCORE).append(name).append(this.imageStrings.PNG_EXTENSION).ToString();
            file = new File(filePath);
        }
        bool isWritten = ImageIO.write(((RenderedImage) this.result), imageStrings.PNG, file);
        this.logUtil.putF("File: " + file + " Wrote: " + isWritten, this, this.commonStrings.RUN);
    }

}

