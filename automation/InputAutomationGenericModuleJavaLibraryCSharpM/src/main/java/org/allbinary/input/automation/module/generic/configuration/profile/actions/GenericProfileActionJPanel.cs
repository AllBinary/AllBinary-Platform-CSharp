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
using JTreeInterfaceFactory = org.allbinary.input.automation.actions.script.JTreeInterfaceFactory;
using AlwaysActionScriptCondition = org.allbinary.input.automation.actions.script.condition.AlwaysActionScriptCondition;
using ColorAtActionScriptCondition = org.allbinary.input.automation.actions.script.condition.ColorAtActionScriptCondition;
using ProfileActionScriptConditionInterface = org.allbinary.input.automation.actions.script.condition.ProfileActionScriptConditionInterface;
using TimeIntervalActionScriptCondition = org.allbinary.input.automation.actions.script.condition.TimeIntervalActionScriptCondition;
using GenericProfileActionScriptJPanel = org.allbinary.input.automation.module.generic.configuration.profile.actions.script.GenericProfileActionScriptJPanel;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions;

public class GenericProfileActionJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private GenericProfileAction genericProfileAction = null;
    private GenericProfileActionScriptJPanel genericProfileActionScriptJPanel = null;
    public GenericProfileActionJPanel()
    {
        this.initComponents();
    }

    public virtual void updateProfileActionUI()
    {
        this.blankProfileActionScriptJPanel.removeAll();
        GenericProfileActionScriptJPanel genericProfileActionScriptJPanel = new GenericProfileActionScriptJPanel();
        JTreeInterfaceFactory.getInstance().set(genericProfileActionScriptJPanel);
        this.setGenericProfileActionScriptJPanel(genericProfileActionScriptJPanel);
        this.getGenericProfileActionScriptJPanel().setGenericProfileActionScript(this.getGenericProfileAction().getGenericProfileActionScript());
        this.getGenericProfileActionScriptJPanel().updateJTree();
        javax.swing.GroupLayout layout = ((javax.swing.GroupLayout) this.blankProfileActionScriptJPanel.getLayout());
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 395, short.MaxValue).addComponent(this.getGenericProfileActionScriptJPanel(), javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 256, short.MaxValue).addComponent(this.getGenericProfileActionScriptJPanel(), javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE));
        this.logUtil.putF("Updated UI", this, "updateUI");
    }

    public virtual GenericProfileAction getGenericProfileAction()
    {
        return this.genericProfileAction;
    }

    public virtual void setGenericProfileAction(GenericProfileAction genericProfileAction)
    {
        this.genericProfileAction = genericProfileAction;
    }

    public virtual GenericProfileActionScriptJPanel getGenericProfileActionScriptJPanel()
    {
        return this.genericProfileActionScriptJPanel;
    }

    public virtual void setGenericProfileActionScriptJPanel(GenericProfileActionScriptJPanel genericProfileActionScriptJPanel)
    {
        this.genericProfileActionScriptJPanel = genericProfileActionScriptJPanel;
    }

    private void initComponents()
    {
        this.genericProfileActionScriptJScrollPane = new javax.swing.JScrollPane();
        this.blankProfileActionScriptJPanel = new javax.swing.JPanel();
        this.ifJLabel = new javax.swing.JLabel();
        this.newColorAtJButton = new javax.swing.JButton();
        this.newTimeIntervalJButton = new javax.swing.JButton();
        this.newAlwaysJButton = new javax.swing.JButton();
        setMinimumSize(new java.awt.Dimension(440, 275));
        setPreferredSize(new java.awt.Dimension(440, 275));
        this.genericProfileActionScriptJScrollPane.setPreferredSize(new java.awt.Dimension(474, 270));
        this.blankProfileActionScriptJPanel.setMinimumSize(new java.awt.Dimension(400, 200));
        javax.swing.GroupLayout blankProfileActionScriptJPanelLayout = new javax.swing.GroupLayout(this.blankProfileActionScriptJPanel);
        this.blankProfileActionScriptJPanel.setLayout(blankProfileActionScriptJPanelLayout);
        blankProfileActionScriptJPanelLayout.setHorizontalGroup(blankProfileActionScriptJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 9996, short.MaxValue));
        blankProfileActionScriptJPanelLayout.setVerticalGroup(blankProfileActionScriptJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 9967, short.MaxValue));
        this.genericProfileActionScriptJScrollPane.setViewportView(this.blankProfileActionScriptJPanel);
        this.ifJLabel.setText("Conditions:");
        this.newColorAtJButton.setText("Color Range At");
        this.newColorAtJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                newColorAtJButtonActionPerformed(evt);
            }

#endif
);
        this.newTimeIntervalJButton.setText("Time Interval");
        this.newTimeIntervalJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                newTimeIntervalJButtonActionPerformed(evt);
            }

#endif
);
        this.newAlwaysJButton.setText("Always On/Off");
        this.newAlwaysJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                newAlwaysJButtonActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(ifJLabel).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(newColorAtJButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(newTimeIntervalJButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(newAlwaysJButton).addContainerGap(61, short.MaxValue)).addComponent(genericProfileActionScriptJScrollPane, javax.swing.GroupLayout.DEFAULT_SIZE, 440, short.MaxValue));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ifJLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 14, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(newColorAtJButton).addComponent(newTimeIntervalJButton).addComponent(newAlwaysJButton)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(genericProfileActionScriptJScrollPane, javax.swing.GroupLayout.DEFAULT_SIZE, 246, short.MaxValue)));
    }

    private void newTimeIntervalJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.logUtil.putF("New Time Interval Action Condition", this, "newTimeIntervalJButtonActionPerformed");
        this.getGenericProfileAction().getGenericProfileActionScript().addCondition(((ProfileActionScriptConditionInterface) new TimeIntervalActionScriptCondition()));
        this.updateProfileActionUI();
    }

    private void newAlwaysJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.logUtil.putF("New EveryTime Action Condition", this, "newEveryTimeJButtonActionPerformed");
        this.getGenericProfileAction().getGenericProfileActionScript().addCondition(((ProfileActionScriptConditionInterface) new AlwaysActionScriptCondition()));
        this.updateProfileActionUI();
    }

    private void newColorAtJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.logUtil.putF("New Color At Action Condition", this, "newColorAtJButtonActionPerformed");
        this.getGenericProfileAction().getGenericProfileActionScript().addCondition(((ProfileActionScriptConditionInterface) new ColorAtActionScriptCondition()));
        this.updateProfileActionUI();
    }

    private javax.swing.JPanel blankProfileActionScriptJPanel = null;
    private javax.swing.JScrollPane genericProfileActionScriptJScrollPane = null;
    private javax.swing.JLabel ifJLabel = null;
    private javax.swing.JButton newAlwaysJButton = null;
    private javax.swing.JButton newColorAtJButton = null;
    private javax.swing.JButton newTimeIntervalJButton = null;
}

