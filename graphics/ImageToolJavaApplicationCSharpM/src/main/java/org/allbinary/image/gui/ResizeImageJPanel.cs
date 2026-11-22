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
using File = java.io.File;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using FileWrapperUtil = org.allbinary.logic.io.file.FileWrapperUtil;
using ImagePersistanceUtil = org.allbinary.media.image.ImagePersistanceUtil;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageProcessorInputCompositeInterface = org.allbinary.media.image.ImageProcessorInputCompositeInterface;
using ImageUtil = org.allbinary.media.image.ImageUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using Dimension = java.awt.Dimension;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using javax.swing;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using javax.swing;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.image.gui;

public class ResizeImageJPanel : JPanel, ImageProcessorInputCompositeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private ImageProcessorInput imageProcessorInput;
    public ResizeImageJPanel(ImageProcessorInput imageProcessorInput) : base()
    {
        // Constructor invocation emitted in the initializer.
        initComponents();
        this.imageProcessorInput = imageProcessorInput;
        string[] numberStringArray = new string[101];
        numberStringArray[0] = (-1).ToString();
        for (int index = 1; index < 100; index++) {
            numberStringArray[index] = (index).ToString();
        }
        this.jComboBox1.setModel(new DefaultComboBoxModel(numberStringArray));
        Raster araster = this.imageProcessorInput.getBufferedImageArray()[0].getAlphaRaster();
        if (araster == null) {
            global::System.Console.Out.WriteLine("there is no Alpha channel!!!!!!!!!");
        } else {
            global::System.Console.Out.WriteLine("Alpha channel found !");
        }
    }

    public virtual void process()
    {
        new __SwtClosure_N66834((__swtSelf_N66834) => {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    ImageUtil imageUtil = ImageUtil.getInstance();
                    int? percent = int.Parse((((string) this.jComboBox1.getSelectedItem())).ToString());
                    float? percentAsFloat = float.Parse(this.floatPercentJTextField.getText());
                    ImageProcessorInput imageProcessorInput = this.getImageProcessorInput();
                    File[] files = imageProcessorInput.getFiles();
                    BufferedImage[] generatedBufferedImageArray = null;
                    if (((int) percentAsFloat) != -1) {
                        generatedBufferedImageArray = imageUtil.createBufferedImage2(imageProcessorInput.getBufferedImageArray(), percentAsFloat, true);
                    } else if (((int) percent) != -1) {
                        generatedBufferedImageArray = imageUtil.createBufferedImageForResize(imageProcessorInput.getBufferedImageArray(), percent, true);
                    } else {
                        int? width = int.Parse((((string) this.jTextField1.getText())).ToString());
                        int? height = int.Parse((((string) this.jTextField2.getText())).ToString());
                        generatedBufferedImageArray = imageUtil.createBufferedImage3(imageProcessorInput.getBufferedImageArray(), width, height, true);
                    }
                    Raster araster = generatedBufferedImageArray[0].getAlphaRaster();
                    if (araster == null) {
                        global::System.Console.Out.WriteLine("No Alpha Channel In Result");
                    } else {
                        global::System.Console.Out.WriteLine("Found Alpha Channel In Result");
                    }
                    ImagePersistanceUtil imagePersistanceUtil = ImagePersistanceUtil.getInstance();
                    for (int index = 0; index < generatedBufferedImageArray.Length; index++) {
                        imagePersistanceUtil.saveWithBatik(FileWrapperUtil.wrapFile(files[index]), generatedBufferedImageArray[index]);
                    }
                    this.getParent().repaint();
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, __swtSelf_N66834, commonStrings.RUN, e);
                }
            }).start();
    }

    public virtual void update()
    {
        new __SwtClosure_N68307((__swtSelf_N68307) => {
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
                    logUtil.put(commonStrings.EXCEPTION, __swtSelf_N68307, commonStrings.RUN, e);
                }
            }).start();
    }

    public virtual void updateFor16Above()
    {
        new __SwtClosure_N69006((__swtSelf_N69006) => {
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
                    logUtil.put(commonStrings.EXCEPTION, __swtSelf_N69006, commonStrings.RUN, e);
                }
            }).start();
    }

    public virtual void updateFor16Below()
    {
        new __SwtClosure_N69741((__swtSelf_N69741) => {
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
                    logUtil.put(commonStrings.EXCEPTION, __swtSelf_N69741, commonStrings.RUN, e);
                }
            }).start();
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
        this.jLabel1 = new JLabel();
        this.jComboBox1 = new JComboBox();
        this.aboveJButton = new JButton();
        this.jTextField1 = new JTextField();
        this.jLabel2 = new JLabel();
        this.jLabel3 = new JLabel();
        this.jTextField2 = new JTextField();
        this.updateJButton = new JButton();
        this.floatPercentJTextField = new JTextField();
        this.adjustFor16AboveJButton = new JButton();
        this.adjustFor16BelowJButton = new JButton();
        this.jLabel1.setText("Percent:");
        this.jComboBox1.setModel(new DefaultComboBoxModel(new string[] { "Item 1", "Item 2", "Item 3", "Item 4" }));
        this.aboveJButton.setText("Process");
        this.aboveJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                aboveJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Width:");
        this.jLabel3.setText("Height:");
        this.updateJButton.setText("Update");
        this.updateJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                updateJButtonActionPerformed(evt);
            }

#endif
);
        this.floatPercentJTextField.setText("-1.000000");
        this.floatPercentJTextField.setMinimumSize(new Dimension(120, 22));
        this.adjustFor16AboveJButton.setText("Adjust for 16 Above");
        this.adjustFor16AboveJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                adjustFor16AboveJButtonActionPerformed(evt);
            }

#endif
);
        this.adjustFor16BelowJButton.setText("Adjust for 16 Below");
        this.adjustFor16BelowJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                adjustFor16BelowJButtonActionPerformed(evt);
            }

#endif
);
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jLabel1).addComponent(jLabel2).addComponent(jLabel3)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING, false).addComponent(jComboBox1, 0, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(jTextField1).addComponent(jTextField2)).addPreferredGap(LayoutStyle.ComponentPlacement.UNRELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(floatPercentJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(adjustFor16AboveJButton).addComponent(adjustFor16BelowJButton)).addContainerGap(GroupLayout.DEFAULT_SIZE, short.MaxValue)).addGroup(layout.createSequentialGroup().addComponent(updateJButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(aboveJButton).addGap(0, 250, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(jComboBox1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(floatPercentJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jTextField1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel2).addComponent(adjustFor16AboveJButton)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel3).addComponent(jTextField2, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(adjustFor16BelowJButton)).addGap(18, 18, 18).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(aboveJButton).addComponent(updateJButton)).addContainerGap(175, short.MaxValue)));
    }

    private void aboveJButtonActionPerformed(ActionEvent evt)
    {
        this.process();
    }

    private void updateJButtonActionPerformed(ActionEvent evt)
    {
        this.update();
    }

    private void adjustFor16AboveJButtonActionPerformed(ActionEvent evt)
    {
        this.updateFor16Above();
    }

    private void adjustFor16BelowJButtonActionPerformed(ActionEvent evt)
    {
        this.updateFor16Below();
    }

    private JButton aboveJButton = null;
    private JButton adjustFor16AboveJButton = null;
    private JButton adjustFor16BelowJButton = null;
    private JTextField floatPercentJTextField = null;
    private JComboBox<string> jComboBox1 = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JLabel jLabel3 = null;
    private JTextField jTextField1 = null;
    private JTextField jTextField2 = null;
    private JButton updateJButton = null;
    private sealed class __SwtClosure_N66834 : global::org.allbinary.thread.NullThread
    {
        private readonly global::System.Action<__SwtClosure_N66834> callback1;

        public __SwtClosure_N66834(global::System.Action<__SwtClosure_N66834> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run() => callback1(this);
    }

    private sealed class __SwtClosure_N68307 : global::org.allbinary.thread.NullThread
    {
        private readonly global::System.Action<__SwtClosure_N68307> callback1;

        public __SwtClosure_N68307(global::System.Action<__SwtClosure_N68307> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run() => callback1(this);
    }

    private sealed class __SwtClosure_N69006 : global::org.allbinary.thread.NullThread
    {
        private readonly global::System.Action<__SwtClosure_N69006> callback1;

        public __SwtClosure_N69006(global::System.Action<__SwtClosure_N69006> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run() => callback1(this);
    }

    private sealed class __SwtClosure_N69741 : global::org.allbinary.thread.NullThread
    {
        private readonly global::System.Action<__SwtClosure_N69741> callback1;

        public __SwtClosure_N69741(global::System.Action<__SwtClosure_N69741> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run() => callback1(this);
    }

}

