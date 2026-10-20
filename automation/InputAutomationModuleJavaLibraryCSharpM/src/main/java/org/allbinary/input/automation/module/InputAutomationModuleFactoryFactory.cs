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
//using Collection = java.util.Collection;
using java.util;
//using Iterator = java.util.Iterator;
//using HelpSet = javax.help.HelpSet;
//using HelpSetEvent = javax.help.@event.HelpSetEvent;
//using HelpSetListener = javax.help.@event.HelpSetListener;
//using ListModel = javax.swing.ListModel;
using InputAutomationModuleConfiguration = org.allbinary.input.automation.module.configuration.InputAutomationModuleConfiguration;
using InputAutomationModuleConfigurations = org.allbinary.input.automation.module.configuration.InputAutomationModuleConfigurations;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using JavaHelpSetNotifier = org.allbinary.logic.java.help.JavaHelpSetNotifier;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.module;

public class InputAutomationModuleFactoryFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HashMap<object, object> hashMap;
    private DefaultListModelHelper defaultListModelHelper;
    private HelpSetListener helpSetListenerInterface;
    public InputAutomationModuleFactoryFactory(InputAutomationModuleConfigurations inputAutomationModuleConfigurations, HelpSetListener helpSetListenerInterface)
    {
        this.helpSetListenerInterface = helpSetListenerInterface;
        this.defaultListModelHelper = new DefaultListModelHelper();
        this.hashMap = StdUtil.getInstance().createHashMap();
        Collection collection = inputAutomationModuleConfigurations.getHashMap().values();
        Iterator iterator = collection.iterator();
        InputAutomationModuleConfiguration inputAutomationModuleConfiguration = null;
        while (iterator.hasNext()) {
            inputAutomationModuleConfiguration = ((InputAutomationModuleConfiguration) iterator.next());
            this.add(inputAutomationModuleConfiguration);
        }
        this.defaultListModelHelper.initDefaultModelList();
        this.logUtil.putF("Loaded " + this.hashMap.size() + "/" + this.defaultListModelHelper.getListModel().getSize() + " Input Automation Modules", this, "Contructor");
    }

    private void add(InputAutomationModuleConfiguration inputAutomationModuleConfiguration)
    {
        InputAutomationModuleFactoryInterface inputAutomationModuleInterface = inputAutomationModuleConfiguration.getInputAutomationModuleInterface();
        this.hashMap.put(inputAutomationModuleConfiguration.getName(), inputAutomationModuleInterface);
        this.defaultListModelHelper.add(inputAutomationModuleConfiguration.getName());
        HelpSet helpSet = inputAutomationModuleInterface.getHelpSet();
        if (!JavaHelpSetNotifier.isNotified(helpSet)) {
            HelpSetEvent helpSetEvent = new HelpSetEvent(this, helpSet, HelpSetEvent.HELPSET_ADDED);
            this.helpSetListenerInterface.helpSetAdded(helpSetEvent);
        }
    }

    public virtual ListModel getListModel()
    {
        return ((ListModel) this.defaultListModelHelper.getListModel());
    }

    public virtual InputAutomationModuleFactoryInterface getInstance(string moduleName)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF("Getting Module: " + moduleName, this, commonStrings.GET_INSTANCE);
        InputAutomationModuleFactoryInterface inputAutomationModuleFactoryInterface = ((InputAutomationModuleFactoryInterface) this.hashMap.get(moduleName));
        if (inputAutomationModuleFactoryInterface == null) {
            this.logUtil.putF("Module: " + moduleName + " was null", this, commonStrings.GET_INSTANCE);
        }
        return inputAutomationModuleFactoryInterface;
    }

}

