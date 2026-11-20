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
//using Dimension = java.awt.Dimension;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JDialog = javax.swing.JDialog;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.input.automation.actions.script.condition;

public class TimeIntervalActionScriptConditionJPanel : JPanel
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
        this.timeIntervalActionScriptConditionInterface.getTimeDelayHelper().delay = int.Parse((this.getTimeIntervalJTextField().getText()).ToString());
        this.timeIntervalActionScriptConditionInterface.log();
    }

    public virtual JTextField getTimeIntervalJTextField()
    {
        return this.timeIntervalJTextField;
    }

    public virtual void setTimeIntervalJTextField(JTextField timeIntervalJTextField)
    {
        this.timeIntervalJTextField = timeIntervalJTextField;
    }

    public virtual JDialog getTimeIntervalActionJDialog()
    {
        return this.timeIntervalActionJDialog;
    }

    public virtual void setTimeIntervalActionJDialog(JDialog timeIntervalActionJDialog)
    {
        this.timeIntervalActionJDialog = timeIntervalActionJDialog;
    }

    private void initComponents()
    {
        this.timeIntervalActionJDialog = new JDialog();
        this.titleJLabel = new JLabel();
        this.okJButton = new JButton();
        this.jLabel2 = new JLabel();
        this.timeIntervalJTextField = new JTextField();
        this.timeIntervalActionJButton = new JButton();
        this.jLabel1 = new JLabel();
        this.timeIntervalActionJDialog.setMinimumSize(new Dimension(250, 150));
        this.titleJLabel.setText("Time Interval Condition Options");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Time (ms):");
        GroupLayout timeIntervalActionJDialogLayout = new GroupLayout(this.timeIntervalActionJDialog.getContentPane());
        this.timeIntervalActionJDialog.getContentPane().setLayout(timeIntervalActionJDialogLayout);
        timeIntervalActionJDialogLayout.setHorizontalGroup(timeIntervalActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(timeIntervalActionJDialogLayout.createSequentialGroup().addGroup(timeIntervalActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.TRAILING).addGroup(GroupLayout.Alignment.LEADING, timeIntervalActionJDialogLayout.createSequentialGroup().addGap(82, 82, 82).addComponent(okJButton)).addGroup(GroupLayout.Alignment.LEADING, timeIntervalActionJDialogLayout.createSequentialGroup().addGap(32, 32, 32).addGroup(timeIntervalActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(timeIntervalActionJDialogLayout.createSequentialGroup().addComponent(jLabel2).addGap(16, 16, 16).addComponent(timeIntervalJTextField, GroupLayout.DEFAULT_SIZE, 85, short.MaxValue)).addComponent(titleJLabel)))).addContainerGap(36, short.MaxValue)));
        timeIntervalActionJDialogLayout.setVerticalGroup(timeIntervalActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(timeIntervalActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(titleJLabel).addGap(20, 20, 20).addGroup(timeIntervalActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel2).addComponent(timeIntervalJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addGap(15, 15, 15).addComponent(okJButton).addContainerGap()));
        setMinimumSize(new Dimension(100, 0));
        this.timeIntervalActionJButton.setText("Edit");
        this.timeIntervalActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                timeIntervalActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Time Interval:");
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(timeIntervalActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(timeIntervalActionJButton)));
    }

    private void okJButtonActionPerformed(ActionEvent evt)
    {
        this.update();
        this.getTimeIntervalActionJDialog().setVisible(false);
    }

    private void timeIntervalActionJButtonActionPerformed(ActionEvent evt)
    {
        this.getTimeIntervalActionJDialog().setVisible(true);
    }

    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JButton okJButton = null;
    private JButton timeIntervalActionJButton = null;
    private JDialog timeIntervalActionJDialog = null;
    private JTextField timeIntervalJTextField = null;
    private JLabel titleJLabel = null;
}

