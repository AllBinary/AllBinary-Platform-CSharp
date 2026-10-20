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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.actions.script.condition;

public class AlwaysActionScriptConditionJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private AlwaysActionScriptConditionInterface alwaysActionScriptConditionInterface;
    public AlwaysActionScriptConditionJPanel(AlwaysActionScriptConditionInterface alwaysActionScriptConditionInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
        this.alwaysActionScriptConditionInterface = alwaysActionScriptConditionInterface;
        this.set();
    }

    private void set()
    {
        if (this.alwaysActionScriptConditionInterface.isIsOn()) {
            this.alwaysJComboBox.setSelectedIndex(0);
        } else {
            this.alwaysJComboBox.setSelectedIndex(1);
        }
        this.alwaysActionScriptConditionInterface.log();
    }

    private void update()
    {
        if (this.alwaysJComboBox.getSelectedIndex() == 0) {
            this.alwaysActionScriptConditionInterface.setIsOn(true);
        } else {
            this.alwaysActionScriptConditionInterface.setIsOn(false);
        }
        this.alwaysActionScriptConditionInterface.log();
    }

    public virtual javax.swing.JDialog getAlwaysActionJDialog()
    {
        return this.alwaysActionJDialog;
    }

    public virtual void setAlwaysActionJDialog(javax.swing.JDialog alwaysActionJDialog)
    {
        this.alwaysActionJDialog = alwaysActionJDialog;
    }

    private void initComponents()
    {
        this.alwaysActionJDialog = new javax.swing.JDialog();
        this.titleJLabel = new javax.swing.JLabel();
        this.okJButton = new javax.swing.JButton();
        this.jLabel2 = new javax.swing.JLabel();
        this.alwaysJComboBox = new javax.swing.JComboBox();
        this.alwaysActionJButton = new javax.swing.JButton();
        this.jLabel1 = new javax.swing.JLabel();
        this.alwaysActionJDialog.setMinimumSize(new java.awt.Dimension(250, 150));
        this.titleJLabel.setText("Always Condition Options");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("On:");
        this.alwaysJComboBox.setModel(new javax.swing.DefaultComboBoxModel(new string[] { "true", "false" }));
        javax.swing.GroupLayout alwaysActionJDialogLayout = new javax.swing.GroupLayout(this.alwaysActionJDialog.getContentPane());
        this.alwaysActionJDialog.getContentPane().setLayout(alwaysActionJDialogLayout);
        alwaysActionJDialogLayout.setHorizontalGroup(alwaysActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(alwaysActionJDialogLayout.createSequentialGroup().addGroup(alwaysActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(alwaysActionJDialogLayout.createSequentialGroup().addGap(47, 47, 47).addGroup(alwaysActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, alwaysActionJDialogLayout.createSequentialGroup().addComponent(jLabel2).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(alwaysJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(titleJLabel))).addGroup(alwaysActionJDialogLayout.createSequentialGroup().addGap(79, 79, 79).addComponent(okJButton))).addContainerGap(45, short.MaxValue)));
        alwaysActionJDialogLayout.setVerticalGroup(alwaysActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(alwaysActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(titleJLabel).addGap(20, 20, 20).addGroup(alwaysActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(alwaysJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel2)).addGap(15, 15, 15).addComponent(okJButton).addContainerGap()));
        setMinimumSize(new java.awt.Dimension(100, 0));
        this.alwaysActionJButton.setText("Edit");
        this.alwaysActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                alwaysActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Always:");
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 33, short.MaxValue).addComponent(alwaysActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(alwaysActionJButton)));
    }

    private void okJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.update();
        this.getAlwaysActionJDialog().setVisible(false);
    }

    private void alwaysActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.getAlwaysActionJDialog().setVisible(true);
    }

    private javax.swing.JButton alwaysActionJButton = null;
    private javax.swing.JDialog alwaysActionJDialog = null;
    private javax.swing.JComboBox alwaysJComboBox = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JLabel jLabel2 = null;
    private javax.swing.JButton okJButton = null;
    private javax.swing.JLabel titleJLabel = null;
}

