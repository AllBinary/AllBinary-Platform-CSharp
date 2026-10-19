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
//using java.util;
//using JAXBContext = javax.xml.bind.JAXBContext;
//using Marshaller = javax.xml.bind.Marshaller;
//using XmlAccessType = javax.xml.bind.annotation.XmlAccessType;
//using XmlAccessorType = javax.xml.bind.annotation.XmlAccessorType;
//using XmlElement = javax.xml.bind.annotation.XmlElement;
//using XmlRootElement = javax.xml.bind.annotation.XmlRootElement;
//using XmlType = javax.xml.bind.annotation.XmlType;
using DomDocumentFileHelper = org.allbinary.data.tree.dom.document.DomDocumentFileHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using InputAutomationModuleConfiguration = org.allbinary.input.automation.module.configuration.InputAutomationModuleConfiguration;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using FileWrapperUtil = org.allbinary.logic.io.file.FileWrapperUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Document = org.w3c.dom.Document;

namespace org.allbinary.input.automation.configuration;

//name="inputAutomationConfiguration", 
public class InputAutomationConfiguration
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly string FILENAME = "InputAutomationConfig.xml";
    private bool installed = false;
    private List<InputAutomationModuleConfiguration> inputAutomationModuleConfigurationList = null;
    public InputAutomationConfiguration()
    {
    }

    public static File getFile()
    {
        return new File(FILENAME);
    }

    public virtual bool isInstalled()
    {
        return this.installed;
    }

    public virtual void setInstalled(bool installed)
    {
        this.installed = installed;
        this.logUtil.putF("Installed: " + installed, this, "setIntalled");
    }

    public virtual List<InputAutomationModuleConfiguration> getInputAutomationModuleConfigurationList()
    {
        return this.inputAutomationModuleConfigurationList;
    }

    // throws Exception
    public virtual void save()
    {
        Document document = DomDocumentHelper.create();
        File file = new File(FILENAME);
        FileUtil.getInstance().copy(new AbPath(file.getAbsolutePath(), StringUtil.getInstance().EMPTY_STRING), new AbPath(file.getAbsolutePath() + ".bak.xml", StringUtil.getInstance().EMPTY_STRING));
        JAXBContext jaxbContext = JAXBContext.newInstance(typeof(InputAutomationConfiguration));
        Marshaller marshaller = jaxbContext.createMarshaller();
        marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
        marshaller.marshal(this, document);
        DomDocumentFileHelper.save(FileWrapperUtil.wrapFile(file), document);
    }

}

