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
//using File = java.io.File;
//using FileInputStream = java.io.FileInputStream;
//using java.util;
//using JAXBContext = javax.xml.bind.JAXBContext;
//using javax.xml.bind;
//using Unmarshaller = javax.xml.bind.Unmarshaller;
//using StreamSource = javax.xml.transform.stream.StreamSource;
using InputAutomationModuleConfiguration = org.allbinary.input.automation.module.configuration.InputAutomationModuleConfiguration;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.configuration;

public class InputAutomationConfigurationFactory
{
    private static readonly InputAutomationConfigurationFactory instance = new InputAutomationConfigurationFactory();
    public static InputAutomationConfigurationFactory getInstance()
    {
        return InputAutomationConfigurationFactory.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public InputAutomationConfiguration inputAutomationConfiguration = null;
    private InputAutomationConfigurationFactory()
    {
    }

    // throws Exception
    public virtual void init(AbeClientInformationInterface abeClientInformation)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        string INPUT_AUTOMATION_CONFIGURATION = "InputAutomationConfiguration";
        File file = InputAutomationConfiguration.getFile();
        if (file.isFile()) {
            logUtil.putF("LoadingConfiguration", INPUT_AUTOMATION_CONFIGURATION, commonStrings.INIT);
            JAXBContext jaxbContext = JAXBContext.newInstance(typeof(InputAutomationConfiguration));
            Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();
            JAXBElement<InputAutomationConfiguration> root = unmarshaller.unmarshal(new StreamSource(new FileInputStream(file)), typeof(InputAutomationConfiguration));
            this.inputAutomationConfiguration = ((InputAutomationConfiguration) root.getValue());
            List<InputAutomationModuleConfiguration> inputAutomationModuleConfigurationList = this.inputAutomationConfiguration.getInputAutomationModuleConfigurationList();
            logUtil.putF("isInstalled: " + this.inputAutomationConfiguration.isInstalled() + " inputAutomationModuleConfigurationList: " + inputAutomationModuleConfigurationList, INPUT_AUTOMATION_CONFIGURATION, commonStrings.INIT);
            if (inputAutomationModuleConfigurationList != null) {
                int size = inputAutomationModuleConfigurationList.size();
                InputAutomationModuleConfiguration inputAutomationModuleConfiguration = null;
                for (int index = 0; index < size; index++) {
                    inputAutomationModuleConfiguration = inputAutomationModuleConfigurationList.get(index);
                    inputAutomationModuleConfiguration.init(abeClientInformation);
                }
            }
            logUtil.putF("LoadedConfiguration", INPUT_AUTOMATION_CONFIGURATION, commonStrings.INIT);
        } else {
            logUtil.putF("New Configuration", INPUT_AUTOMATION_CONFIGURATION, commonStrings.INIT);
            this.inputAutomationConfiguration = new InputAutomationConfiguration();
        }
    }

}

