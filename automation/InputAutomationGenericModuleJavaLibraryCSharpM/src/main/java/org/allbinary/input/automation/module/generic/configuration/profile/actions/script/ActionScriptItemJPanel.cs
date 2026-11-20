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
//using Dimension = java.awt.Dimension;
//using GridLayout = java.awt.GridLayout;
//using GroupLayout = javax.swing.GroupLayout;
//using JPanel = javax.swing.JPanel;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions.script;

public class ActionScriptItemJPanel : JPanel
{
    public ActionScriptItemJPanel()
    {
        this.initComponents();
    }

    public virtual JPanel getNewActionScriptInputJPanel()
    {
        return this.newActionScriptInputJPanel;
    }

    public virtual void setNewActionScriptInputJPanel(JPanel newActionScriptInputJPanel)
    {
        this.newActionScriptInputJPanel = newActionScriptInputJPanel;
    }

    public virtual JPanel getRemoveJPanel()
    {
        return this.removeJPanel;
    }

    public virtual void setRemoveJPanel(JPanel removeJPanel)
    {
        this.removeJPanel = removeJPanel;
    }

    public virtual JPanel getScriptItemJPanel()
    {
        return this.scriptItemJPanel;
    }

    public virtual void setScriptItemJPanel(JPanel scriptItemJPanel)
    {
        this.scriptItemJPanel = scriptItemJPanel;
    }

    public virtual JPanel getNewActionScriptConditionJPanel()
    {
        return this.newActionScriptConditionJPanel;
    }

    public virtual void setNewActionScriptConditionJPanel(JPanel newActionScriptConditionJPanel)
    {
        this.newActionScriptConditionJPanel = newActionScriptConditionJPanel;
    }

    public virtual JPanel getChildActionScriptConditionJPanel()
    {
        return this.childActionScriptConditionJPanel;
    }

    public virtual void setChildActionScriptConditionJPanel(JPanel childActionScriptConditionJPanel)
    {
        this.childActionScriptConditionJPanel = childActionScriptConditionJPanel;
    }

    private void initComponents()
    {
        this.newActionScriptInputJPanel = new JPanel();
        this.childActionScriptConditionJPanel = new JPanel();
        this.newActionScriptConditionJPanel = new JPanel();
        this.scriptItemJPanel = new JPanel();
        this.removeJPanel = new JPanel();
        this.newActionScriptInputJPanel.setLayout(new GridLayout(1, 0));
        GroupLayout childActionScriptConditionJPanelLayout = new GroupLayout(this.childActionScriptConditionJPanel);
        this.childActionScriptConditionJPanel.setLayout(childActionScriptConditionJPanelLayout);
        childActionScriptConditionJPanelLayout.setHorizontalGroup(childActionScriptConditionJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 229, short.MaxValue));
        childActionScriptConditionJPanelLayout.setVerticalGroup(childActionScriptConditionJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 8, short.MaxValue));
        this.newActionScriptConditionJPanel.setLayout(new GridLayout(1, 0));
        this.scriptItemJPanel.setLayout(new GridLayout(1, 1));
        this.removeJPanel.setLayout(new GridLayout(1, 1));
        this.removeJPanel.setMinimumSize(new Dimension(30, 20));
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(scriptItemJPanel, GroupLayout.PREFERRED_SIZE, 167, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(removeJPanel, GroupLayout.DEFAULT_SIZE, 56, short.MaxValue)).addComponent(newActionScriptInputJPanel, GroupLayout.DEFAULT_SIZE, 229, short.MaxValue).addComponent(newActionScriptConditionJPanel, GroupLayout.DEFAULT_SIZE, 229, short.MaxValue).addComponent(childActionScriptConditionJPanel, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(scriptItemJPanel, GroupLayout.DEFAULT_SIZE, 31, short.MaxValue).addComponent(removeJPanel, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 31, short.MaxValue)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(childActionScriptConditionJPanel, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(newActionScriptConditionJPanel, GroupLayout.PREFERRED_SIZE, 28, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(newActionScriptInputJPanel, GroupLayout.PREFERRED_SIZE, 30, GroupLayout.PREFERRED_SIZE)));
    }

    private JPanel childActionScriptConditionJPanel = null;
    private JPanel newActionScriptConditionJPanel = null;
    private JPanel newActionScriptInputJPanel = null;
    private JPanel removeJPanel = null;
    private JPanel scriptItemJPanel = null;
}

