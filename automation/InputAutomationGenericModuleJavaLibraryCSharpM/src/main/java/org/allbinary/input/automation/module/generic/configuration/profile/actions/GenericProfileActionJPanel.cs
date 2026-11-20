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
//using Dimension = java.awt.Dimension;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JScrollPane = javax.swing.JScrollPane;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions;

public class GenericProfileActionJPanel : JPanel
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
        GroupLayout layout = ((GroupLayout) this.blankProfileActionScriptJPanel.getLayout());
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 395, short.MaxValue).addComponent(this.getGenericProfileActionScriptJPanel(), GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 256, short.MaxValue).addComponent(this.getGenericProfileActionScriptJPanel(), GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE));
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
        this.genericProfileActionScriptJScrollPane = new JScrollPane();
        this.blankProfileActionScriptJPanel = new JPanel();
        this.ifJLabel = new JLabel();
        this.newColorAtJButton = new JButton();
        this.newTimeIntervalJButton = new JButton();
        this.newAlwaysJButton = new JButton();
        setMinimumSize(new Dimension(440, 275));
        setPreferredSize(new Dimension(440, 275));
        this.genericProfileActionScriptJScrollPane.setPreferredSize(new Dimension(474, 270));
        this.blankProfileActionScriptJPanel.setMinimumSize(new Dimension(400, 200));
        GroupLayout blankProfileActionScriptJPanelLayout = new GroupLayout(this.blankProfileActionScriptJPanel);
        this.blankProfileActionScriptJPanel.setLayout(blankProfileActionScriptJPanelLayout);
        blankProfileActionScriptJPanelLayout.setHorizontalGroup(blankProfileActionScriptJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 9996, short.MaxValue));
        blankProfileActionScriptJPanelLayout.setVerticalGroup(blankProfileActionScriptJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 9967, short.MaxValue));
        this.genericProfileActionScriptJScrollPane.setViewportView(this.blankProfileActionScriptJPanel);
        this.ifJLabel.setText("Conditions:");
        this.newColorAtJButton.setText("Color Range At");
        this.newColorAtJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                newColorAtJButtonActionPerformed(evt);
            }

#endif
);
        this.newTimeIntervalJButton.setText("Time Interval");
        this.newTimeIntervalJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                newTimeIntervalJButtonActionPerformed(evt);
            }

#endif
);
        this.newAlwaysJButton.setText("Always On/Off");
        this.newAlwaysJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                newAlwaysJButtonActionPerformed(evt);
            }

#endif
);
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(ifJLabel).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(newColorAtJButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(newTimeIntervalJButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(newAlwaysJButton).addContainerGap(61, short.MaxValue)).addComponent(genericProfileActionScriptJScrollPane, GroupLayout.DEFAULT_SIZE, 440, short.MaxValue));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(ifJLabel, GroupLayout.PREFERRED_SIZE, 14, GroupLayout.PREFERRED_SIZE).addComponent(newColorAtJButton).addComponent(newTimeIntervalJButton).addComponent(newAlwaysJButton)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(genericProfileActionScriptJScrollPane, GroupLayout.DEFAULT_SIZE, 246, short.MaxValue)));
    }

    private void newTimeIntervalJButtonActionPerformed(ActionEvent evt)
    {
        this.logUtil.putF("New Time Interval Action Condition", this, "newTimeIntervalJButtonActionPerformed");
        this.getGenericProfileAction().getGenericProfileActionScript().addCondition(((ProfileActionScriptConditionInterface) new TimeIntervalActionScriptCondition()));
        this.updateProfileActionUI();
    }

    private void newAlwaysJButtonActionPerformed(ActionEvent evt)
    {
        this.logUtil.putF("New EveryTime Action Condition", this, "newEveryTimeJButtonActionPerformed");
        this.getGenericProfileAction().getGenericProfileActionScript().addCondition(((ProfileActionScriptConditionInterface) new AlwaysActionScriptCondition()));
        this.updateProfileActionUI();
    }

    private void newColorAtJButtonActionPerformed(ActionEvent evt)
    {
        this.logUtil.putF("New Color At Action Condition", this, "newColorAtJButtonActionPerformed");
        this.getGenericProfileAction().getGenericProfileActionScript().addCondition(((ProfileActionScriptConditionInterface) new ColorAtActionScriptCondition()));
        this.updateProfileActionUI();
    }

    private JPanel blankProfileActionScriptJPanel = null;
    private JScrollPane genericProfileActionScriptJScrollPane = null;
    private JLabel ifJLabel = null;
    private JButton newAlwaysJButton = null;
    private JButton newColorAtJButton = null;
    private JButton newTimeIntervalJButton = null;
}

