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

public class TimeIntervalActionScriptConditionJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private TimeIntervalActionScriptConditionInterface timeIntervalActionScriptConditionInterface;
    public TimeIntervalActionScriptConditionJPanel(TimeIntervalActionScriptConditionInterface timeIntervalActionScriptConditionInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
        this.timeIntervalActionScriptConditionInterface = timeIntervalActionScriptConditionInterface;
        this.set();
    }

    private void set()
    {
        this.getTimeIntervalJTextField().setText((this.timeIntervalActionScriptConditionInterface.getTimeDelayHelper().delay).ToString());
        this.timeIntervalActionScriptConditionInterface.log();
    }

    private void update()
    {
        this.timeIntervalActionScriptConditionInterface.getTimeDelayHelper().delay = (this.getTimeIntervalJTextField().getText()).ToString();
        this.timeIntervalActionScriptConditionInterface.log();
    }

    public virtual javax.swing.JTextField getTimeIntervalJTextField()
    {
        return this.timeIntervalJTextField;
    }

    public virtual void setTimeIntervalJTextField(javax.swing.JTextField timeIntervalJTextField)
    {
        this.timeIntervalJTextField = timeIntervalJTextField;
    }

    public virtual javax.swing.JDialog getTimeIntervalActionJDialog()
    {
        return this.timeIntervalActionJDialog;
    }

    public virtual void setTimeIntervalActionJDialog(javax.swing.JDialog timeIntervalActionJDialog)
    {
        this.timeIntervalActionJDialog = timeIntervalActionJDialog;
    }

    private void initComponents()
    {
        this.timeIntervalActionJDialog = new javax.swing.JDialog();
        this.titleJLabel = new javax.swing.JLabel();
        this.okJButton = new javax.swing.JButton();
        this.jLabel2 = new javax.swing.JLabel();
        this.timeIntervalJTextField = new javax.swing.JTextField();
        this.timeIntervalActionJButton = new javax.swing.JButton();
        this.jLabel1 = new javax.swing.JLabel();
        this.timeIntervalActionJDialog.setMinimumSize(new java.awt.Dimension(250, 150));
        this.titleJLabel.setText("Time Interval Condition Options");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Time (ms):");
        javax.swing.GroupLayout timeIntervalActionJDialogLayout = new javax.swing.GroupLayout(this.timeIntervalActionJDialog.getContentPane());
        this.timeIntervalActionJDialog.getContentPane().setLayout(timeIntervalActionJDialogLayout);
        timeIntervalActionJDialogLayout.setHorizontalGroup(timeIntervalActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(timeIntervalActionJDialogLayout.createSequentialGroup().addGroup(timeIntervalActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addGroup(javax.swing.GroupLayout.Alignment.LEADING, timeIntervalActionJDialogLayout.createSequentialGroup().addGap(82, 82, 82).addComponent(okJButton)).addGroup(javax.swing.GroupLayout.Alignment.LEADING, timeIntervalActionJDialogLayout.createSequentialGroup().addGap(32, 32, 32).addGroup(timeIntervalActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(timeIntervalActionJDialogLayout.createSequentialGroup().addComponent(jLabel2).addGap(16, 16, 16).addComponent(timeIntervalJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 85, Short.MAX_VALUE)).addComponent(titleJLabel)))).addContainerGap(36, Short.MAX_VALUE)));
        timeIntervalActionJDialogLayout.setVerticalGroup(timeIntervalActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(timeIntervalActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(titleJLabel).addGap(20, 20, 20).addGroup(timeIntervalActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel2).addComponent(timeIntervalJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addGap(15, 15, 15).addComponent(okJButton).addContainerGap()));
        setMinimumSize(new java.awt.Dimension(100, 0));
        this.timeIntervalActionJButton.setText("Edit");
        this.timeIntervalActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                timeIntervalActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Time Interval:");
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(timeIntervalActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(timeIntervalActionJButton)));
    }

    private void okJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.update();
        this.getTimeIntervalActionJDialog().setVisible(false);
    }

    private void timeIntervalActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.getTimeIntervalActionJDialog().setVisible(true);
    }

    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JLabel jLabel2 = null;
    private javax.swing.JButton okJButton = null;
    private javax.swing.JButton timeIntervalActionJButton = null;
    private javax.swing.JDialog timeIntervalActionJDialog = null;
    private javax.swing.JTextField timeIntervalJTextField = null;
    private javax.swing.JLabel titleJLabel = null;
}

