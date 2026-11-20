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
//using DefaultComboBoxModel = javax.swing.DefaultComboBoxModel;
//using GroupLayout = javax.swing.GroupLayout;
//using JComboBox = javax.swing.JComboBox;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class InputAutomationTypeJPanel : JPanel
{
    public InputAutomationTypeJPanel()
    {
        this.initComponents();
    }

    public virtual JComboBox getInputAutomationTypeJComboBox()
    {
        return this.inputAutomationTypeJComboBox;
    }

    public virtual void setInputAutomationTypeJComboBox(JComboBox inputAutomationTypeJComboBox)
    {
        this.inputAutomationTypeJComboBox = inputAutomationTypeJComboBox;
    }

    private void initComponents()
    {
        this.inputAutomationTypeJComboBox = new JComboBox();
        this.jLabel1 = new JLabel();
        this.inputAutomationTypeJComboBox.setModel(new DefaultComboBoxModel(new string[] { "DirectX", "DirectX 8", "Low Level", "Java Robot" }));
        this.jLabel1.setText("Input Type:");
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(inputAutomationTypeJComboBox, 0, 98, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(inputAutomationTypeJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)));
    }

    private JComboBox inputAutomationTypeJComboBox = null;
    private JLabel jLabel1 = null;
}

