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
using GenericProfileActionData = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActionData;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.module.generic.configuration.profile;

public class GenericProfiles : DomNodeInterface, DomDocumentMappingInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly string DEFAULT_PROFILES_PATH = "./modules/configs/profiles/";
    public static readonly string DEFAULT_PROFILE_ACTIONS_PATH = GenericProfiles.DEFAULT_PROFILES_PATH + "actions/";
    public static readonly string DEFAULT_FILE = GenericProfiles.DEFAULT_PROFILES_PATH + "profiles.xml";
    private HashMap hashMap;
    private DefaultListModelHelper profilesDefaultListModelHelper;
    private readonly string fileName;
    public GenericProfiles(string fileName)
    {
        this.fileName = fileName;
        this.profilesDefaultListModelHelper = new DefaultListModelHelper();
        this.hashMap = StdUtil.getInstance().createHashMap();
        if (new File(fileName).isFile()) {
            sbyte[] bytes = new sbyte[100000];
            FileInputStream idFile = new FileInputStream(fileName);
            int length = idFile.read(bytes);
            string data = System.Text.Encoding.UTF8.GetString((byte[]) (Array) bytes);
            int endIndex = data.LastIndexOf('>');
            Document document = DomDocumentHelper.create(data.Substring(0, (endIndex + 1) - (0)));
            NodeList nodeList = document.getElementsByTagName(GenericProfilesData.NAME);
            this.logUtil.putF("Number Of Profiles Specified: " + nodeList.getLength(), this, "Contructor");
            if (nodeList != null) {
                this.initProfiles(nodeList.item(0));
            } else {
                throw new Exception(GenericProfileActionData.NAME + " Name Node Node Children");
            }
            this.logUtil.putF("Loaded: " + this.hashMap.size() + " Configuration Profile Actions", this, "Contructor");
        } else {
            this.logUtil.putF("No Generic Profile: " + fileName, this, "Contructor");
        }
        this.getDefaultListModelHelper().initDefaultModelList();
    }

    // throws Exception
    private void initProfiles(Node node)
    {
        NodeList nodeList = node.getChildNodes();
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node profileNameNode = nodeList.item(index);
            if (profileNameNode.getNodeName().compareTo(GenericProfileData.NAME) == 0) {
                GenericProfile genericProfile = new GenericProfile(profileNameNode);
                this.hashMap.put(genericProfile.getName(), genericProfile);
                this.getDefaultListModelHelper().add(genericProfile.getName());
            }
        }
    }

    public virtual DefaultListModelHelper getDefaultListModelHelper()
    {
        return this.profilesDefaultListModelHelper;
    }

    // throws Exception
    public virtual GenericProfile get(string name)
    {
        GenericProfile genericProfile = ((GenericProfile) this.hashMap.get(name));
        if (genericProfile == null) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF("No Generic Profile Named: " + name + " availability was: " + this.hashMap, this, commonStrings.GET);
        }
        return genericProfile;
    }

    // throws Exception
    public virtual void add(string name)
    {
        this.hashMap.put(name, new GenericProfile(name));
        this.getDefaultListModelHelper().add(name);
        this.getDefaultListModelHelper().initDefaultModelList();
        this.save();
    }

    // throws Exception
    public virtual void remove(string name)
    {
        this.hashMap.remove(name);
        this.getDefaultListModelHelper().remove(name);
        this.getDefaultListModelHelper().initDefaultModelList();
        this.save();
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(GenericProfilesData.NAME);
        Set set = this.hashMap.keySet();
        object[] nameArray = set.toArray();
        int size = nameArray.Length;
        for (int index = 0; index < size; index++) {
            GenericProfile genericProfile = ((GenericProfile) this.hashMap.get(((string) nameArray[index])));
            node.appendChild(genericProfile.toXmlNode(document));
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

    // throws Exception
    public virtual void save()
    {
        FileOutputStream idFile = new FileOutputStream(this.fileName);
        DataOutputStream idOutData = new DataOutputStream(idFile);
        string documentString = XmlDocumentHelper.toString(this.toXmlDoc());
        idOutData.writeBytes(documentString);
    }

}

