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
using java.util;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using InputImageType = org.allbinary.input.media.image.InputImageType;
using StdUtil = org.allbinary.logic.StdUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.input.automation.module.generic.configuration.profile;

public class GenericProfileDataWorkerType : GenericProfileDataWorkerTypeInterface
{
    private static HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
    public static GenericProfileDataWorkerType SAVED_CAPTURE = SavedCaptureGenericProfileDataWorkerType.SAVED_CAPTURE;
    public static GenericProfileDataWorkerType SCREEN_CAPTURE = new GenericProfileDataWorkerType("Screen " + InputImageType.CAPTURE.getName());
    public static GenericProfileDataWorkerType COMPARISON = new GenericProfileDataWorkerType(InputImageType.COMPARISON.getName());
    public static GenericProfileDataWorkerType MOTION = new GenericProfileDataWorkerType(InputImageType.MOTION.getName());
    private string name = null;
    public GenericProfileDataWorkerType(string name)
    {
        this.setName(name);
        GenericProfileDataWorkerType.hashMap.put(this.getName(), this);
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createTextNode(document, GenericProfileDataWorkerData.NAME, this.name);
        return node;
    }

    public override string ToString()
    {
        return "GenericProfileDataWorkerType: " + this.getName();
    }

    public static GenericProfileDataWorkerType getInstance(Node node)
    {
        string name = DomNodeHelper.getTextNodeValue(node);
        return ((GenericProfileDataWorkerType) GenericProfileDataWorkerType.hashMap.get(name));
    }

}

