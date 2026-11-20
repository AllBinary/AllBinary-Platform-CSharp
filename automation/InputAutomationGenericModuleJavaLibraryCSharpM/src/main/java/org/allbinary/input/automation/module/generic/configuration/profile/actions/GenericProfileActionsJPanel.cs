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
using DefaultListModelHelper = org.allbinary.input.automation.module.DefaultListModelHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using Dimension = java.awt.Dimension;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JDialog = javax.swing.JDialog;
//using JLabel = javax.swing.JLabel;
//using JList = javax.swing.JList;
//using JPanel = javax.swing.JPanel;
//using JScrollPane = javax.swing.JScrollPane;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;
//using ListSelectionEvent = javax.swing.@event.ListSelectionEvent;
//using ListSelectionListener = javax.swing.@event.ListSelectionListener;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions;

public class GenericProfileActionsJPanel : JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private GenericProfileActions genericProfileActions = null;
    private GenericProfileActionJPanel genericProfileActionJPanel = null;
    public GenericProfileActionsJPanel()
    {
        this.initComponents();
    }

    private void initComponents()
    {
        this.newProfileActionJDialog = new JDialog();
        this.newProfileActionJLabel = new JLabel();
        this.okNewProfileActionJButton = new JButton();
        this.newProfileActionJTextField = new JTextField();
        this.genericProfileActionsJPanel = new JPanel();
        this.genericProfileActionsJScrollPane = new JScrollPane();
        this.genericProfileActionsJList = new JList();
        this.newActionJButton = new JButton();
        this.deleteActionJButton = new JButton();
        this.saveJButton = new JButton();
        this.blankGenericProfileActionJPanel = new JPanel();
        this.newProfileActionJDialog.setMinimumSize(new Dimension(250, 150));
        this.newProfileActionJDialog.setResizable(false);
        this.newProfileActionJLabel.setText("New Action Name");
        this.okNewProfileActionJButton.setText("Ok");
        this.okNewProfileActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okNewProfileActionJButtonActionPerformed(evt);
            }

#endif
);
        GroupLayout newProfileActionJDialogLayout = new GroupLayout(this.newProfileActionJDialog.getContentPane());
        this.newProfileActionJDialog.getContentPane().setLayout(newProfileActionJDialogLayout);
        newProfileActionJDialogLayout.setHorizontalGroup(newProfileActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(newProfileActionJDialogLayout.createSequentialGroup().addGroup(newProfileActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(newProfileActionJDialogLayout.createSequentialGroup().addGap(93, 93, 93).addComponent(okNewProfileActionJButton)).addGroup(newProfileActionJDialogLayout.createSequentialGroup().addGap(75, 75, 75).addComponent(newProfileActionJLabel)).addGroup(newProfileActionJDialogLayout.createSequentialGroup().addGap(29, 29, 29).addComponent(newProfileActionJTextField, GroupLayout.PREFERRED_SIZE, 178, GroupLayout.PREFERRED_SIZE))).addContainerGap(34, short.MaxValue)));
        newProfileActionJDialogLayout.setVerticalGroup(newProfileActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(GroupLayout.Alignment.TRAILING, newProfileActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(newProfileActionJLabel).addGap(21, 21, 21).addComponent(newProfileActionJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 20, short.MaxValue).addComponent(okNewProfileActionJButton).addContainerGap()));
        this.genericProfileActionsJPanel.setPreferredSize(new Dimension(10000, 10000));
        this.genericProfileActionsJList.addListSelectionListener(new ListSelectionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void valueChanged(ListSelectionEvent evt)
            {
                genericProfileActionsJListValueChanged(evt);
            }

#endif
);
        this.genericProfileActionsJScrollPane.setViewportView(this.genericProfileActionsJList);
        this.newActionJButton.setText("New");
        this.newActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                newActionJButtonActionPerformed(evt);
            }

#endif
);
        this.deleteActionJButton.setText("Delete");
        this.deleteActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                deleteActionJButtonActionPerformed(evt);
            }

#endif
);
        this.saveJButton.setText("Save");
        this.saveJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                saveJButtonActionPerformed(evt);
            }

#endif
);
        this.blankGenericProfileActionJPanel.setMinimumSize(new Dimension(500, 300));
        GroupLayout blankGenericProfileActionJPanelLayout = new GroupLayout(this.blankGenericProfileActionJPanel);
        this.blankGenericProfileActionJPanel.setLayout(blankGenericProfileActionJPanelLayout);
        blankGenericProfileActionJPanelLayout.setHorizontalGroup(blankGenericProfileActionJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 500, short.MaxValue));
        blankGenericProfileActionJPanelLayout.setVerticalGroup(blankGenericProfileActionJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 296, short.MaxValue));
        GroupLayout genericProfileActionsJPanelLayout = new GroupLayout(this.genericProfileActionsJPanel);
        this.genericProfileActionsJPanel.setLayout(genericProfileActionsJPanelLayout);
        genericProfileActionsJPanelLayout.setHorizontalGroup(genericProfileActionsJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(genericProfileActionsJPanelLayout.createSequentialGroup().addComponent(genericProfileActionsJScrollPane, GroupLayout.PREFERRED_SIZE, 95, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(blankGenericProfileActionJPanel, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue)).addGroup(genericProfileActionsJPanelLayout.createSequentialGroup().addComponent(newActionJButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(deleteActionJButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(saveJButton).addContainerGap()));
        genericProfileActionsJPanelLayout.setVerticalGroup(genericProfileActionsJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(genericProfileActionsJPanelLayout.createSequentialGroup().addGroup(genericProfileActionsJPanelLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(newActionJButton).addComponent(deleteActionJButton).addComponent(saveJButton)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(genericProfileActionsJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING, false).addComponent(blankGenericProfileActionJPanel, 0, 296, short.MaxValue).addComponent(genericProfileActionsJScrollPane, GroupLayout.DEFAULT_SIZE, 296, short.MaxValue)).addContainerGap(GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(genericProfileActionsJPanel, GroupLayout.PREFERRED_SIZE, 596, GroupLayout.PREFERRED_SIZE).addContainerGap(GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(genericProfileActionsJPanel, GroupLayout.PREFERRED_SIZE, 336, GroupLayout.PREFERRED_SIZE));
    }

    public virtual void setModel()
    {
        DefaultListModelHelper defaultListModelHelper = this.getGenericProfileActions().getDefaultListModelHelper();
        if (defaultListModelHelper.getListModel().getSize() > 0) {
            this.genericProfileActionsJList.setModel(defaultListModelHelper.getListModel());
        }
    }

    private void saveJButtonActionPerformed(ActionEvent evt)
    {
        try {
            this.getGenericProfileActions().save();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "saveJButtonActionPerformed", e);
        }
    }

    private void updateProfileActionUI(string profileActionNameString)
    {
        this.blankGenericProfileActionJPanel.removeAll();
        if (profileActionNameString != null) {
            GenericProfileAction genericProfileAction = this.getGenericProfileActions().getAction(profileActionNameString);
            this.setGenericProfileActionJPanel(new GenericProfileActionJPanel());
            this.getGenericProfileActionJPanel().setGenericProfileAction(genericProfileAction);
            this.getGenericProfileActionJPanel().updateProfileActionUI();
            GroupLayout layout = ((GroupLayout) this.blankGenericProfileActionJPanel.getLayout());
            layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 395, short.MaxValue).addComponent(this.getGenericProfileActionJPanel(), GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE));
            layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 256, short.MaxValue).addComponent(this.getGenericProfileActionJPanel(), GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE));
            this.logUtil.putF("Setting Configuration Profile Actions JPanel", this, "genericProfileActionsJListValueChanged");
        }
    }

    private void genericProfileActionsJListValueChanged(ListSelectionEvent evt)
    {
        try {
            string profileActionNameString = ((string) this.genericProfileActionsJList.getSelectedValue());
            this.updateProfileActionUI(profileActionNameString);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "genericProfileActionsJListValueChanged", e);
        }
    }

    private void okNewProfileActionJButtonActionPerformed(ActionEvent evt)
    {
        try {
            string newActionName = this.newProfileActionJTextField.getText();
            this.getGenericProfileActions().add(newActionName);
            this.setModel();
            this.genericProfileActionsJList.setSelectedValue(newActionName, true);
            this.newProfileActionJDialog.setVisible(false);
            this.updateProfileActionUI(newActionName);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "okNewProfileActionJButtonActionPerformed", e);
        }
    }

    private void deleteActionJButtonActionPerformed(ActionEvent evt)
    {
        try {
            object[] anyType = this.genericProfileActionsJList.getSelectedValues();
            for (int index = 0; index < anyType.Length; index++) {
                string nextSelectedValueString = ((string) anyType[index]);
                this.getGenericProfileActions().remove(nextSelectedValueString);
            }
            this.selectFirstElement();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "deleteActionJButtonActionPerformed", e);
        }
    }

    // throws Exception
    public virtual void selectFirstElement()
    {
        this.setModel();
        if (this.genericProfileActionsJList.getModel().getSize() > 0) {
            this.genericProfileActionsJList.setSelectedValue(this.genericProfileActionsJList.getModel().getElementAt(0), true);
            this.updateProfileActionUI(((string) this.genericProfileActionsJList.getModel().getElementAt(0)));
        } else {
            this.blankGenericProfileActionJPanel.removeAll();
            this.blankGenericProfileActionJPanel.repaint();
        }
    }

    public virtual GenericProfileActionJPanel getGenericProfileActionJPanel()
    {
        return this.genericProfileActionJPanel;
    }

    public virtual void setGenericProfileActionJPanel(GenericProfileActionJPanel genericProfileActionJPanel)
    {
        this.genericProfileActionJPanel = genericProfileActionJPanel;
    }

    public virtual GenericProfileActions getGenericProfileActions()
    {
        return this.genericProfileActions;
    }

    public virtual void setGenericProfileActions(GenericProfileActions genericProfileActions)
    {
        this.genericProfileActions = genericProfileActions;
    }

    private void newActionJButtonActionPerformed(ActionEvent evt)
    {
        this.newProfileActionJDialog.setVisible(true);
    }

    private JPanel blankGenericProfileActionJPanel = null;
    private JButton deleteActionJButton = null;
    private JList genericProfileActionsJList = null;
    private JPanel genericProfileActionsJPanel = null;
    private JScrollPane genericProfileActionsJScrollPane = null;
    private JButton newActionJButton = null;
    private JDialog newProfileActionJDialog = null;
    private JLabel newProfileActionJLabel = null;
    private JTextField newProfileActionJTextField = null;
    private JButton okNewProfileActionJButton = null;
    private JButton saveJButton = null;
}

