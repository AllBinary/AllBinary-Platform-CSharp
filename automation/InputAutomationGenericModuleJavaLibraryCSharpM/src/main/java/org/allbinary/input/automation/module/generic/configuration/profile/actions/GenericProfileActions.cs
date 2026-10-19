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
//using DataOutputStream = java.io.DataOutputStream;
//using File = java.io.File;
//using FileInputStream = java.io.FileInputStream;
//using FileOutputStream = java.io.FileOutputStream;
using java.util;
//using Set = java.util.Set;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using DomDocumentMappingInterface = org.allbinary.data.tree.dom.document.mapping.DomDocumentMappingInterface;
using DefaultListModelHelper = org.allbinary.input.automation.module.DefaultListModelHelper;
using GenericProfiles = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfiles;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonDataFileStrings = org.allbinary.logic.io.file.CommonDataFileStrings;
using AbPath = org.allbinary.logic.io.path.AbPath;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions;

public class GenericProfileActions : DomNodeInterface, DomDocumentMappingInterface
{
    public static readonly string DEFAULT_PROFILE_ACTIONS_PATH = GenericProfiles.DEFAULT_PROFILES_PATH + "actions/";
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonDataFileStrings commonFileStrings = CommonDataFileStrings.getInstance();
    private string name = null;
    private GenericProfileActionsJPanel genericProfileActionsJPanel = null;
    private DefaultListModelHelper actionsDefaultListModelHelper = null;
    private HashMap hashMap = null;
    public GenericProfileActions(GenericProfileActionsJPanel genericProfileActionsJPanel, string name)
    {
        this.setName(name);
        this.init(genericProfileActionsJPanel);
        this.load();
    }

    public GenericProfileActions(GenericProfileActionsJPanel genericProfileActionsJPanel, AbPath abPath, string name)
    {
        this.setName(name);
        this.init(genericProfileActionsJPanel);
        this.load();
    }

    public GenericProfileActions(GenericProfileActionsJPanel genericProfileActionsJPanel, FileInputStream fileInputStream, string name)
    {
        this.setName(name);
        this.init(genericProfileActionsJPanel);
        this.fileInit(fileInputStream);
    }

    // throws Exception
    private void init(GenericProfileActionsJPanel genericProfileActionsJPanel)
    {
        this.setGenericProfileActionsJPanel(genericProfileActionsJPanel);
        this.actionsDefaultListModelHelper = new DefaultListModelHelper();
        this.setHashMap(new HashMap());
    }

    // throws Exception
    public virtual void save()
    {
        FileOutputStream idFile = new FileOutputStream(GenericProfileActions.DEFAULT_PROFILE_ACTIONS_PATH + getName() + this.commonFileStrings._XML);
        DataOutputStream idOutData = new DataOutputStream(idFile);
        idOutData.writeBytes(XmlDocumentHelper.toString(this.toXmlDoc()));
    }

    public virtual File getFile(string name)
    {
        string fileName = DEFAULT_PROFILE_ACTIONS_PATH + name + this.commonFileStrings._XML;
        return new File(fileName);
    }

    // throws Exception
    private void load()
    {
        File file = this.getFile(getName());
        if (file.isFile()) {
            FileInputStream idFile = new FileInputStream(file);
            this.fileInit(idFile);
        } else {
            this.logUtil.putF("No Profile: " + file.getAbsolutePath(), this, "Contructor");
        }
    }

    // throws Exception
    private void fileInit(FileInputStream fileInputStream)
    {
        sbyte[] bytes = new sbyte[100000];
        int length = fileInputStream.read(bytes);
        string data = System.Text.Encoding.UTF8.GetString((byte[]) (Array) bytes);
        int endIndex = data.LastIndexOf('>');
        Document document = DomDocumentHelper.create(data.Substring(0, (endIndex + 1) - (0)));
        NodeList nameNodeList = document.getElementsByTagName(GenericProfileActionsData.NAME);
        this.logUtil.putF("Number Of Profiles Specified: " + nameNodeList.getLength(), this, "Contructor");
        for (int index = 0; index < nameNodeList.getLength(); index++) {
            Node node = nameNodeList.item(index);
            NodeList nodeList = node.getChildNodes();
            if (nodeList != null) {
                this.initActions(nodeList);
            } else {
                throw new Exception(GenericProfileActionData.NAME + " Name Node Node Children");
            }
        }
        this.logUtil.putF("Loaded: " + this.getHashMap().size() + " Configuration Profile Action(s)", this, "Contructor");
        this.getDefaultListModelHelper().initDefaultModelList();
    }

    // throws Exception
    private void initActions(NodeList nodeList)
    {
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node actionNode = nodeList.item(index);
            if (actionNode != null) {
                GenericProfileAction genericConfigurationProfileAction = new GenericProfileAction(this.getGenericProfileActionsJPanel().getGenericProfileActionJPanel(), actionNode);
                this.getHashMap().put(genericConfigurationProfileAction.getName(), genericConfigurationProfileAction);
                this.getDefaultListModelHelper().add(genericConfigurationProfileAction.getName());
            } else {
                throw new Exception(GenericProfileActionData.NAME + " Node Null");
            }
        }
    }

    public virtual DefaultListModelHelper getDefaultListModelHelper()
    {
        return this.actionsDefaultListModelHelper;
    }

    public virtual GenericProfileAction getAction(string @string)
    {
        return ((GenericProfileAction) this.getHashMap().get(@string));
    }

    // throws Exception
    public virtual void add(string name)
    {
        GenericProfileAction genericProfileAction = new GenericProfileAction(name);
        this.getHashMap().put(genericProfileAction.getName(), genericProfileAction);
        this.getDefaultListModelHelper().add(genericProfileAction.getName());
        this.getDefaultListModelHelper().initDefaultModelList();
        this.save();
    }

    // throws Exception
    public virtual void remove(string name)
    {
        this.getHashMap().remove(name);
        this.getDefaultListModelHelper().remove(name);
        this.getDefaultListModelHelper().initDefaultModelList();
        this.save();
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(GenericProfileActionsData.NAME);
        Set set = this.getHashMap().keySet();
        object[] actionNameArray = set.toArray();
        int size = actionNameArray.Length;
        for (int index = 0; index < size; index++) {
            string nextActionName = ((string) actionNameArray[index]);
            GenericProfileAction nextGenericProfileAction = ((GenericProfileAction) this.getAction(nextActionName));
            node.appendChild(nextGenericProfileAction.toXmlNode(document));
        }
        return node;
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        Document document = DomDocumentHelper.create();
        Node node = this.toXmlNode(document);
        document.appendChild(node);
        return document;
    }

    public virtual GenericProfileActionsJPanel getGenericProfileActionsJPanel()
    {
        return this.genericProfileActionsJPanel;
    }

    public virtual void setGenericProfileActionsJPanel(GenericProfileActionsJPanel genericProfileActionsJPanel)
    {
        this.genericProfileActionsJPanel = genericProfileActionsJPanel;
    }

    public virtual HashMap getHashMap()
    {
        return this.hashMap;
    }

    public virtual void setHashMap(HashMap hashMap)
    {
        this.hashMap = hashMap;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

}

