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

namespace org.allbinary.input.automation.module.actions.script.condition.processors.output;

public class ImageActionScriptOutputJPanel : javax.swing.JPanel
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

    public virtual javax.swing.JDialog getCapturedImageActionJDialog()
    {
        return this.capturedImageActionJDialog;
    }

    public virtual void setCapturedImageActionJDialog(javax.swing.JDialog capturedImageActionJDialog)
    {
        this.capturedImageActionJDialog = capturedImageActionJDialog;
    }

    private void initComponents()
    {
        this.capturedImageActionJDialog = new javax.swing.JDialog();
        this.titleJLabel = new javax.swing.JLabel();
        this.okJButton = new javax.swing.JButton();
        this.saveJCheckBox = new javax.swing.JCheckBox();
        this.displayJCheckBox = new javax.swing.JCheckBox();
        this.jScrollPane1 = new javax.swing.JScrollPane();
        this.itemTypesJList = new javax.swing.JList();
        this.capturedImageActionJButton = new javax.swing.JButton();
        this.jLabel1 = new javax.swing.JLabel();
        this.capturedImageActionJDialog.setMinimumSize(new java.awt.Dimension(250, 250));
        this.titleJLabel.setText("Image Output Options");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.saveJCheckBox.setText("Save To File");
        this.saveJCheckBox.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.saveJCheckBox.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.displayJCheckBox.setText("Display");
        this.displayJCheckBox.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.displayJCheckBox.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.displayJCheckBox.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                displayJCheckBoxActionPerformed(evt);
            }

#endif
);
        this.itemTypesJList.setModel(new javax.swing.AbstractListModel()
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
        javax.swing.GroupLayout capturedImageActionJDialogLayout = new javax.swing.GroupLayout(this.capturedImageActionJDialog.getContentPane());
        this.capturedImageActionJDialog.getContentPane().setLayout(capturedImageActionJDialogLayout);
        capturedImageActionJDialogLayout.setHorizontalGroup(capturedImageActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addGroup(capturedImageActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addGap(61, 61, 61).addComponent(titleJLabel)).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addContainerGap().addGroup(capturedImageActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(capturedImageActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(displayJCheckBox).addComponent(saveJCheckBox, javax.swing.GroupLayout.Alignment.TRAILING)).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addGap(84, 84, 84).addComponent(okJButton)))).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 216, Short.MAX_VALUE))).addContainerGap()));
        capturedImageActionJDialogLayout.setVerticalGroup(capturedImageActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(capturedImageActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addGap(5, 5, 5).addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 105, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(saveJCheckBox).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(displayJCheckBox).addGap(9, 9, 9).addComponent(okJButton).addContainerGap()));
        setMinimumSize(new java.awt.Dimension(100, 0));
        this.capturedImageActionJButton.setText("Edit");
        this.capturedImageActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                capturedImageActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Capture Image:");
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(capturedImageActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(capturedImageActionJButton)));
    }

    private void displayJCheckBoxActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void okJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.update();
        this.getCapturedImageActionJDialog().setVisible(false);
    }

    private void capturedImageActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.getCapturedImageActionJDialog().setVisible(true);
    }

    private javax.swing.JButton capturedImageActionJButton = null;
    private javax.swing.JDialog capturedImageActionJDialog = null;
    private javax.swing.JCheckBox displayJCheckBox = null;
    private javax.swing.JList itemTypesJList = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JScrollPane jScrollPane1 = null;
    private javax.swing.JButton okJButton = null;
    private javax.swing.JCheckBox saveJCheckBox = null;
    private javax.swing.JLabel titleJLabel = null;
}

