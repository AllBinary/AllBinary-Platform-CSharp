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
//using DefaultComboBoxModel = javax.swing.DefaultComboBoxModel;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JComboBox = javax.swing.JComboBox;
//using JDialog = javax.swing.JDialog;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.input.automation.actions.script.condition;

public class AlwaysActionScriptConditionJPanel : JPanel
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

    public virtual JDialog getAlwaysActionJDialog()
    {
        return this.alwaysActionJDialog;
    }

    public virtual void setAlwaysActionJDialog(JDialog alwaysActionJDialog)
    {
        this.alwaysActionJDialog = alwaysActionJDialog;
    }

    private void initComponents()
    {
        this.alwaysActionJDialog = new JDialog();
        this.titleJLabel = new JLabel();
        this.okJButton = new JButton();
        this.jLabel2 = new JLabel();
        this.alwaysJComboBox = new JComboBox();
        this.alwaysActionJButton = new JButton();
        this.jLabel1 = new JLabel();
        this.alwaysActionJDialog.setMinimumSize(new Dimension(250, 150));
        this.titleJLabel.setText("Always Condition Options");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("On:");
        this.alwaysJComboBox.setModel(new DefaultComboBoxModel(new string[] { "true", "false" }));
        GroupLayout alwaysActionJDialogLayout = new GroupLayout(this.alwaysActionJDialog.getContentPane());
        this.alwaysActionJDialog.getContentPane().setLayout(alwaysActionJDialogLayout);
        alwaysActionJDialogLayout.setHorizontalGroup(alwaysActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(alwaysActionJDialogLayout.createSequentialGroup().addGroup(alwaysActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(alwaysActionJDialogLayout.createSequentialGroup().addGap(47, 47, 47).addGroup(alwaysActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING, false).addGroup(GroupLayout.Alignment.TRAILING, alwaysActionJDialogLayout.createSequentialGroup().addComponent(jLabel2).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(alwaysJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addComponent(titleJLabel))).addGroup(alwaysActionJDialogLayout.createSequentialGroup().addGap(79, 79, 79).addComponent(okJButton))).addContainerGap(45, short.MaxValue)));
        alwaysActionJDialogLayout.setVerticalGroup(alwaysActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(alwaysActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(titleJLabel).addGap(20, 20, 20).addGroup(alwaysActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(alwaysJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel2)).addGap(15, 15, 15).addComponent(okJButton).addContainerGap()));
        setMinimumSize(new Dimension(100, 0));
        this.alwaysActionJButton.setText("Edit");
        this.alwaysActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                alwaysActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Always:");
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 33, short.MaxValue).addComponent(alwaysActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(alwaysActionJButton)));
    }

    private void okJButtonActionPerformed(ActionEvent evt)
    {
        this.update();
        this.getAlwaysActionJDialog().setVisible(false);
    }

    private void alwaysActionJButtonActionPerformed(ActionEvent evt)
    {
        this.getAlwaysActionJDialog().setVisible(true);
    }

    private JButton alwaysActionJButton = null;
    private JDialog alwaysActionJDialog = null;
    private JComboBox alwaysJComboBox = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JButton okJButton = null;
    private JLabel titleJLabel = null;
}

