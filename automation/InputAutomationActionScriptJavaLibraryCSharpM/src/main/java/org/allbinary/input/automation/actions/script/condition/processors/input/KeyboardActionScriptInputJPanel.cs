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
//using javax.swing;
using KeySingletonFactory = org.allbinary.input.KeySingletonFactory;
using InputRobot = org.allbinary.input.automation.robot.InputRobot;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using TempInputRobotNames = org.allbinary.input.automation.robot.TempInputRobotNames;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using Dimension = java.awt.Dimension;
//using Insets = java.awt.Insets;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using BorderFactory = javax.swing.BorderFactory;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JComboBox = javax.swing.JComboBox;
//using JDialog = javax.swing.JDialog;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JRadioButton = javax.swing.JRadioButton;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;
//using SwingConstants = javax.swing.SwingConstants;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class KeyboardActionScriptInputJPanel : JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private KeyboardActionScriptInputInterface keyActionScriptInputInterface;
    public KeyboardActionScriptInputJPanel(KeyboardActionScriptInputInterface keyActionScriptInputInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
        this.keyActionScriptInputInterface = keyActionScriptInputInterface;
        DefaultComboBoxModel defaultComboBoxModel = new DefaultComboBoxModel();
        defaultComboBoxModel.addElement(TempInputRobotNames.DX_NAME);
        defaultComboBoxModel.addElement(InputRobot.NAME);
        this.inputAutomationTypeJComboBox.setModel(defaultComboBoxModel);
        this.keyNameJComboBox.setModel(KeyNameDefaultComboBoxModelFactory.getInstance());
        this.keyIntegerJComboBox.setModel(KeyCharDefaultComboBoxModelFactory.getInstance());
        if (this.keyActionScriptInputInterface.isNormal()) {
            this.normalJRadioButton.setSelected(true);
            this.pressJRadioButton.setSelected(false);
            this.releaseJRadioButton.setSelected(false);
        } else if (this.keyActionScriptInputInterface.isPress()) {
            this.normalJRadioButton.setSelected(false);
            this.pressJRadioButton.setSelected(true);
            this.releaseJRadioButton.setSelected(false);
        } else if (this.keyActionScriptInputInterface.isRelease()) {
            this.normalJRadioButton.setSelected(false);
            this.pressJRadioButton.setSelected(false);
            this.releaseJRadioButton.setSelected(true);
        }
        this.set();
    }

    private void set()
    {
        ComboBoxModel inputTypeComboBoxModel = this.inputAutomationTypeJComboBox.getModel();
        inputTypeComboBoxModel.setSelectedItem(this.keyActionScriptInputInterface.getInputRobotInterface().getName());
        this.textJTextField.setText(this.keyActionScriptInputInterface.getText());
        this.delayJTextField.setText((this.keyActionScriptInputInterface.getDelayBetweenKeys()).ToString());
        this.timeJTextField.setText((this.keyActionScriptInputInterface.getTime()).ToString());
        this.keyActionScriptInputInterface.log();
    }

    // throws Exception
    private void updateInputType()
    {
        ComboBoxModel comboBoxModel = this.inputAutomationTypeJComboBox.getModel();
        string selectedItem = ((string) comboBoxModel.getSelectedItem());
        if (!StringValidationUtil.getInstance().isEmpty(selectedItem)) {
            this.keyActionScriptInputInterface.setInputRobotInterface(InputRobotFactory.getInstance().get(selectedItem));
        }
    }

    private int? getSelectedKey()
    {
        ComboBoxModel comboBoxModel = this.keyNameJComboBox.getModel();
        string selectedItem = ((string) comboBoxModel.getSelectedItem());
        if (!StringValidationUtil.getInstance().isEmpty(selectedItem)) {
            return ((int?) KeySingletonFactory.getHashtable().get(selectedItem));
        }
        return null;
    }

    private void updateKeys()
    {
        string text = this.textJTextField.getText();
        this.keyActionScriptInputInterface.setText(text);
    }

    // throws Exception
    private void update()
    {
        this.updateInputType();
        this.updateKeys();
        this.keyActionScriptInputInterface.setTime(global::java.lang.JavaNumber.intValue(int.Parse((this.timeJTextField.getText()).ToString())));
        this.keyActionScriptInputInterface.log();
    }

    public virtual JDialog getKeyActionJDialog()
    {
        return this.keyActionJDialog;
    }

    public virtual void setKeyActionJDialog(JDialog keyActionJDialog)
    {
        this.keyActionJDialog = keyActionJDialog;
    }

    private void initComponents()
    {
        this.keyActionJDialog = new JDialog();
        this.titleJLabel = new JLabel();
        this.addKeyJLabel = new JLabel();
        this.keyNameJComboBox = new JComboBox();
        this.timeJTextField = new JTextField();
        this.holdTimeJLabel = new JLabel();
        this.inputAutomationTypeJComboBox = new JComboBox();
        this.inputTypeJLabel = new JLabel();
        this.delayJTextField = new JTextField();
        this.delayBetweenJLabel = new JLabel();
        this.testJLabel = new JLabel();
        this.textJTextField = new JTextField();
        this.pressJRadioButton = new JRadioButton();
        this.releaseJRadioButton = new JRadioButton();
        this.normalJRadioButton = new JRadioButton();
        this.simultaneousJRadioButton = new JRadioButton();
        this.sequenceJRadioButton = new JRadioButton();
        this.jPanel1 = new JPanel();
        this.okJButton = new JButton();
        this.keyIntegerJComboBox = new JComboBox();
        this.keyActionJButton = new JButton();
        this.jLabel1 = new JLabel();
        this.keyActionJDialog.setMinimumSize(new Dimension(255, 280));
        this.titleJLabel.setHorizontalAlignment(SwingConstants.CENTER);
        this.titleJLabel.setText("Keyboard Input Options");
        this.addKeyJLabel.setText("Add Key:");
        this.keyNameJComboBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                keyNameJComboBoxActionPerformed(evt);
            }

#endif
);
        this.timeJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.holdTimeJLabel.setText("Hold Time (ms):");
        this.inputTypeJLabel.setText("Input Type:");
        this.delayJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.delayBetweenJLabel.setText("Delay Between Keys (ms):");
        this.testJLabel.setText("Text:");
        this.textJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.pressJRadioButton.setText("Press");
        this.pressJRadioButton.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.pressJRadioButton.setMargin(new Insets(0, 0, 0, 0));
        this.pressJRadioButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                pressJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.releaseJRadioButton.setText("Release");
        this.releaseJRadioButton.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.releaseJRadioButton.setMargin(new Insets(0, 0, 0, 0));
        this.releaseJRadioButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                releaseJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.normalJRadioButton.setSelected(true);
        this.normalJRadioButton.setText("Normal");
        this.normalJRadioButton.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.normalJRadioButton.setMargin(new Insets(0, 0, 0, 0));
        this.normalJRadioButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                normalJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.simultaneousJRadioButton.setSelected(true);
        this.simultaneousJRadioButton.setText("Simultaneous");
        this.simultaneousJRadioButton.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.simultaneousJRadioButton.setMargin(new Insets(0, 0, 0, 0));
        this.simultaneousJRadioButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                simultaneousJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.sequenceJRadioButton.setText("Sequence");
        this.sequenceJRadioButton.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.sequenceJRadioButton.setMargin(new Insets(0, 0, 0, 0));
        this.sequenceJRadioButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                sequenceJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.okJButton.setText("OK");
        this.okJButton.setHorizontalTextPosition(SwingConstants.CENTER);
        this.okJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.jPanel1.add(this.okJButton);
        this.keyIntegerJComboBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                keyIntegerJComboBoxActionPerformed(evt);
            }

#endif
);
        GroupLayout keyActionJDialogLayout = new GroupLayout(this.keyActionJDialog.getContentPane());
        this.keyActionJDialog.getContentPane().setLayout(keyActionJDialogLayout);
        keyActionJDialogLayout.setHorizontalGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(keyActionJDialogLayout.createSequentialGroup().addContainerGap().addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(keyActionJDialogLayout.createSequentialGroup().addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING, false).addComponent(addKeyJLabel, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(inputTypeJLabel, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.TRAILING).addComponent(inputAutomationTypeJComboBox, 0, 148, short.MaxValue).addComponent(textJTextField, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 148, short.MaxValue).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(keyNameJComboBox, 0, 101, short.MaxValue).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(keyIntegerJComboBox, GroupLayout.PREFERRED_SIZE, 41, GroupLayout.PREFERRED_SIZE)))).addComponent(testJLabel, GroupLayout.PREFERRED_SIZE, 60, GroupLayout.PREFERRED_SIZE).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(normalJRadioButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(pressJRadioButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(releaseJRadioButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 48, GroupLayout.PREFERRED_SIZE)).addGroup(GroupLayout.Alignment.TRAILING, keyActionJDialogLayout.createSequentialGroup().addComponent(holdTimeJLabel).addGap(22, 22, 22).addComponent(timeJTextField, GroupLayout.DEFAULT_SIZE, 113, short.MaxValue)).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(delayBetweenJLabel).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 15, short.MaxValue).addComponent(delayJTextField, GroupLayout.PREFERRED_SIZE, 68, GroupLayout.PREFERRED_SIZE)).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(simultaneousJRadioButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(sequenceJRadioButton))).addContainerGap()).addComponent(titleJLabel, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 229, short.MaxValue).addComponent(jPanel1, GroupLayout.DEFAULT_SIZE, 229, short.MaxValue));
        keyActionJDialogLayout.setVerticalGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(inputTypeJLabel).addComponent(inputAutomationTypeJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(addKeyJLabel).addComponent(keyIntegerJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(keyNameJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(testJLabel).addComponent(textJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(pressJRadioButton).addComponent(normalJRadioButton).addComponent(releaseJRadioButton)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(holdTimeJLabel).addComponent(timeJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(delayBetweenJLabel).addComponent(delayJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(simultaneousJRadioButton).addComponent(sequenceJRadioButton)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jPanel1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addContainerGap()));
        setMinimumSize(new Dimension(100, 0));
        this.keyActionJButton.setText("Edit");
        this.keyActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                keyActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Key:");
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 49, short.MaxValue).addComponent(keyActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(keyActionJButton)));
    }

    private void prependText(int? integer)
    {
        if (integer != null) {
            string newKey = "&#" + integer.ToString() + ";";
            this.textJTextField.setText(newKey + this.textJTextField.getText());
        }
    }

    private void keyIntegerJComboBoxActionPerformed(ActionEvent evt)
    {
        this.keyIntegerJComboBox.getSelectedIndex();
        this.keyNameJComboBox.setSelectedIndex(this.keyIntegerJComboBox.getSelectedIndex());
    }

    private void sequenceJRadioButtonActionPerformed(ActionEvent evt)
    {
        if (this.sequenceJRadioButton.isSelected()) {
            this.delayJTextField.setText(CommonPhoneStrings.getInstance().ONE);
            this.simultaneousJRadioButton.setSelected(false);
        }
    }

    private void simultaneousJRadioButtonActionPerformed(ActionEvent evt)
    {
        if (this.simultaneousJRadioButton.isSelected()) {
            this.delayJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
            this.sequenceJRadioButton.setSelected(false);
        }
    }

    private void keyNameJComboBoxActionPerformed(ActionEvent evt)
    {
        int? integer = this.getSelectedKey();
        this.prependText(integer);
        this.keyIntegerJComboBox.setSelectedIndex(this.keyNameJComboBox.getSelectedIndex());
    }

    private void okJButtonActionPerformed(ActionEvent evt)
    {
        try {
            this.update();
            this.getKeyActionJDialog().setVisible(false);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "okButtonActionPerformed", e);
        }
    }

    private void keyActionJButtonActionPerformed(ActionEvent evt)
    {
        this.getKeyActionJDialog().setVisible(true);
    }

    private void normalJRadioButtonActionPerformed(ActionEvent evt)
    {
        if (this.normalJRadioButton.isSelected()) {
            this.keyActionScriptInputInterface.setNormal();
            this.pressJRadioButton.setSelected(false);
            this.releaseJRadioButton.setSelected(false);
        }
    }

    private void releaseJRadioButtonActionPerformed(ActionEvent evt)
    {
        if (this.releaseJRadioButton.isSelected()) {
            this.keyActionScriptInputInterface.setRelease(true);
            this.keyActionScriptInputInterface.setPress(false);
            this.pressJRadioButton.setSelected(false);
            this.normalJRadioButton.setSelected(false);
        }
    }

    private void pressJRadioButtonActionPerformed(ActionEvent evt)
    {
        if (this.pressJRadioButton.isSelected()) {
            this.keyActionScriptInputInterface.setPress(true);
            this.keyActionScriptInputInterface.setRelease(false);
            this.releaseJRadioButton.setSelected(false);
            this.normalJRadioButton.setSelected(false);
        }
    }

    private JLabel addKeyJLabel = null;
    private JLabel delayBetweenJLabel = null;
    private JTextField delayJTextField = null;
    private JLabel holdTimeJLabel = null;
    private JComboBox inputAutomationTypeJComboBox = null;
    private JLabel inputTypeJLabel = null;
    private JLabel jLabel1 = null;
    private JPanel jPanel1 = null;
    private JButton keyActionJButton = null;
    private JDialog keyActionJDialog = null;
    private JComboBox keyIntegerJComboBox = null;
    private JComboBox keyNameJComboBox = null;
    private JRadioButton normalJRadioButton = null;
    private JButton okJButton = null;
    private JRadioButton pressJRadioButton = null;
    private JRadioButton releaseJRadioButton = null;
    private JRadioButton sequenceJRadioButton = null;
    private JRadioButton simultaneousJRadioButton = null;
    private JLabel testJLabel = null;
    private JTextField textJTextField = null;
    private JTextField timeJTextField = null;
    private JLabel titleJLabel = null;
}

