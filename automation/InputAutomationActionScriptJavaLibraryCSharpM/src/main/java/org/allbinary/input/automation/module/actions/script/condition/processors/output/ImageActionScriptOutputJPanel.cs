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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using javax.swing;
using InputImageType = org.allbinary.input.media.image.InputImageType;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using Dimension = java.awt.Dimension;
//using Insets = java.awt.Insets;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using AbstractListModel = javax.swing.AbstractListModel;
//using BorderFactory = javax.swing.BorderFactory;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JCheckBox = javax.swing.JCheckBox;
//using JDialog = javax.swing.JDialog;
//using JLabel = javax.swing.JLabel;
//using JList = javax.swing.JList;
//using JPanel = javax.swing.JPanel;
//using JScrollPane = javax.swing.JScrollPane;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.input.automation.module.actions.script.condition.processors.output;

public class ImageActionScriptOutputJPanel : JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private ImageActionScriptOutputInterface capturedImageActionScriptOutputInterface;
    public ImageActionScriptOutputJPanel(ImageActionScriptOutputInterface capturedImageActionScriptOutputInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
        this.capturedImageActionScriptOutputInterface = capturedImageActionScriptOutputInterface;
        this.set();
    }

    private void set()
    {
        this.setImageTypeJlistModel();
        ImageTypes imageTypes = this.capturedImageActionScriptOutputInterface.getImageTypes();
        BasicArrayList vector = imageTypes.getVector();
        int[] selectedArray = new int[vector.size()];
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            InputImageType imageType = ((InputImageType) vector.get(index));
            selectedArray[index++] = imageType.getIndex();
        }
        this.itemTypesJList.setSelectedIndices(selectedArray);
        if (this.capturedImageActionScriptOutputInterface.isSaved()) {
            this.saveJCheckBox.setSelected(true);
        }
        if (this.capturedImageActionScriptOutputInterface.isSaved()) {
            this.displayJCheckBox.setSelected(true);
        }
        this.capturedImageActionScriptOutputInterface.log();
    }

    private void update()
    {
        object[] anyType = this.itemTypesJList.getSelectedValues();
        ImageTypes imageTypes = ImageTypes.valueOf(anyType);
        this.capturedImageActionScriptOutputInterface.setImageTypes(imageTypes);
        if (this.saveJCheckBox.isSelected()) {
            this.capturedImageActionScriptOutputInterface.setSaved(true);
        } else {
            this.capturedImageActionScriptOutputInterface.setSaved(false);
        }
        if (this.displayJCheckBox.isSelected()) {
            this.capturedImageActionScriptOutputInterface.setDisplay(true);
        } else {
            this.capturedImageActionScriptOutputInterface.setDisplay(false);
        }
        this.capturedImageActionScriptOutputInterface.log();
    }

    private void setImageTypeJlistModel()
    {
        DefaultListModel defaultListModel = new DefaultListModel();
        BasicArrayList vector = InputImageType.getAllAsVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            InputImageType imageType = ((InputImageType) vector.get(index));
            defaultListModel.addElement(imageType.getName());
        }
        this.itemTypesJList.setModel(defaultListModel);
    }

    public virtual JDialog getCapturedImageActionJDialog()
    {
        return this.capturedImageActionJDialog;
    }

    public virtual void setCapturedImageActionJDialog(JDialog capturedImageActionJDialog)
    {
        this.capturedImageActionJDialog = capturedImageActionJDialog;
    }

    private void initComponents()
    {
        this.capturedImageActionJDialog = new JDialog();
        this.titleJLabel = new JLabel();
        this.okJButton = new JButton();
        this.saveJCheckBox = new JCheckBox();
        this.displayJCheckBox = new JCheckBox();
        this.jScrollPane1 = new JScrollPane();
        this.itemTypesJList = new JList();
        this.capturedImageActionJButton = new JButton();
        this.jLabel1 = new JLabel();
        this.capturedImageActionJDialog.setMinimumSize(new Dimension(250, 250));
        this.titleJLabel.setText("Image Output Options");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.saveJCheckBox.setText("Save To File");
        this.saveJCheckBox.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.saveJCheckBox.setMargin(new Insets(0, 0, 0, 0));
        this.displayJCheckBox.setText("Display");
        this.displayJCheckBox.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.displayJCheckBox.setMargin(new Insets(0, 0, 0, 0));
        this.displayJCheckBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                displayJCheckBoxActionPerformed(evt);
            }

#endif
);
        this.itemTypesJList.setModel(new AbstractListModel()
#if JAVA_ANONYMOUS_CLASS_BODY
            public string[] strings = new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            public virtual int getSize()
            {
                return strings.Length;
            }

            public virtual object getElementAt(int i)
            {
                return strings[i];
            }

#endif
);
        this.jScrollPane1.setViewportView(this.itemTypesJList);
        GroupLayout capturedImageActionJDialogLayout = new GroupLayout(this.capturedImageActionJDialog.getContentPane());
        this.capturedImageActionJDialog.getContentPane().setLayout(capturedImageActionJDialogLayout);
        capturedImageActionJDialogLayout.setHorizontalGroup(capturedImageActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addGroup(capturedImageActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addGap(61, 61, 61).addComponent(titleJLabel)).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addContainerGap().addGroup(capturedImageActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(capturedImageActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(displayJCheckBox).addComponent(saveJCheckBox, GroupLayout.Alignment.TRAILING)).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addGap(84, 84, 84).addComponent(okJButton)))).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(jScrollPane1, GroupLayout.DEFAULT_SIZE, 216, short.MaxValue))).addContainerGap()));
        capturedImageActionJDialogLayout.setVerticalGroup(capturedImageActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addGap(5, 5, 5).addComponent(jScrollPane1, GroupLayout.DEFAULT_SIZE, 105, short.MaxValue).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(saveJCheckBox).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(displayJCheckBox).addGap(9, 9, 9).addComponent(okJButton).addContainerGap()));
        setMinimumSize(new Dimension(100, 0));
        this.capturedImageActionJButton.setText("Edit");
        this.capturedImageActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                capturedImageActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Capture Image:");
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(capturedImageActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(capturedImageActionJButton)));
    }

    private void displayJCheckBoxActionPerformed(ActionEvent evt)
    {
    }

    private void okJButtonActionPerformed(ActionEvent evt)
    {
        this.update();
        this.getCapturedImageActionJDialog().setVisible(false);
    }

    private void capturedImageActionJButtonActionPerformed(ActionEvent evt)
    {
        this.getCapturedImageActionJDialog().setVisible(true);
    }

    private JButton capturedImageActionJButton = null;
    private JDialog capturedImageActionJDialog = null;
    private JCheckBox displayJCheckBox = null;
    private JList itemTypesJList = null;
    private JLabel jLabel1 = null;
    private JScrollPane jScrollPane1 = null;
    private JButton okJButton = null;
    private JCheckBox saveJCheckBox = null;
    private JLabel titleJLabel = null;
}

