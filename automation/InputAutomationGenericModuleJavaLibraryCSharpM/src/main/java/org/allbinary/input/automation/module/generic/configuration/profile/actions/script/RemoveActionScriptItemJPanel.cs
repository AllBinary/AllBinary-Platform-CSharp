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
using ProfileActionScriptConditionInterface = org.allbinary.input.automation.actions.script.condition.ProfileActionScriptConditionInterface;
using GenericProfileAction = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileAction;
using GenericProfileActionJPanel = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActionJPanel;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
//using GridLayout = java.awt.GridLayout;
//using Panel = java.awt.Panel;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using JButton = javax.swing.JButton;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions.script;

public class RemoveActionScriptItemJPanel : Panel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private GenericProfileActionJPanel genericProfileActionJPanel;
    private ProfileActionScriptConditionInterface profileActionScriptConditionInterface;
    public RemoveActionScriptItemJPanel(GenericProfileActionJPanel genericProfileActionJPanel, ProfileActionScriptConditionInterface profileActionScriptConditionInterface)
    {
        this.initComponents();
        this.genericProfileActionJPanel = genericProfileActionJPanel;
        this.profileActionScriptConditionInterface = profileActionScriptConditionInterface;
    }

    private void initComponents()
    {
        this.removeJButton = new JButton();
        setLayout(new GridLayout());
        this.removeJButton.setText("Remove");
        this.removeJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                removeJButtonActionPerformed(evt);
            }

#endif
);
        add(this.removeJButton);
    }

    private void removeJButtonActionPerformed(ActionEvent evt)
    {
        GenericProfileAction genericProfileAction = this.genericProfileActionJPanel.getGenericProfileAction();
        if (genericProfileAction == null) {
            this.logUtil.putF("GenericProfileAction was null", this, "removeJButtonActionPerformed");
            return;
        }
        genericProfileAction.getGenericProfileActionScript().removeCondition(this.profileActionScriptConditionInterface);
        this.genericProfileActionJPanel.updateProfileActionUI();
    }

    private JButton removeJButton = null;
}

