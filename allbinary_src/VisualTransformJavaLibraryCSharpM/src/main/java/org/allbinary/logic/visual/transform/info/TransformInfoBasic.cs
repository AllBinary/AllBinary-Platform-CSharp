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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using PageContext = javax.servlet.jsp.PageContext;
using AbContext = org.allbinary.business.context.AbContext;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using AbPath = org.allbinary.logic.io.path.AbPath;
using TransformInfoObjectConfigInterface = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigInterface;
using Document = org.w3c.dom.Document;

namespace org.allbinary.logic.visual.transform.info;

//Hack class should not exist
public class TransformInfoBasic : AbContext, TransformInfoHttpInterface
{
    private StoreFrontInterface storeFrontInterface;
    public TransformInfoBasic(StoreFrontInterface storeFrontInterface, HashMap propertiesHashMap, PageContext pageContext) : base(propertiesHashMap, pageContext)
    {
        // base(propertiesHashMap, pageContext) is called from the constructor declaration
        this.storeFrontInterface = storeFrontInterface;
    }

    public virtual string getStoreName()
    {
        return this.storeFrontInterface.getName();
    }

    public virtual string log()
    {
        return commonStrings.NOT_IMPLEMENTED;
    }

    public virtual void @override(HashMap hashMap)
    {
    }

    public virtual string getName()
    {
        return null;
    }

    public virtual string getObjectFile()
    {
        return null;
    }

    public virtual object getObject()
    {
        return null;
    }

    public virtual TransformInfoObjectConfigInterface getObjectConfigInterface()
    {
        return null;
    }

    public virtual void setObjectConfigInterface(TransformInfoObjectConfigInterface transformInfoObjectConfigInterface)
    {
    }

    public virtual AbPath getTemplateFilePath()
    {
        return null;
    }

    public virtual string getTemplateFile()
    {
        return null;
    }

    public virtual string getTemplate()
    {
        return null;
    }

    public virtual AbPath getDataFilePath()
    {
        return null;
    }

    public virtual string getDataFile()
    {
        return null;
    }

    // throws Exception
    public virtual Document getDataDocument()
    {
        throw new Exception(commonStrings.NOT_IMPLEMENTED);
    }

    public virtual void setName(string value)
    {
    }

    public virtual void setStoreName(string value)
    {
    }

    public virtual void setObjectFile(string value)
    {
    }

    public virtual void setObject(object anyType)
    {
    }

    public virtual void setObjectConfigFile(string value)
    {
    }

    public virtual void setTemplateFile(string value)
    {
    }

    public virtual void setTemplate(string value)
    {
    }

    public virtual void setDataFile(string value)
    {
    }

    public virtual void setData(string value)
    {
    }

    public virtual void setChild()
    {
    }

    public virtual bool isChild()
    {
        return true;
    }

    public virtual string getImportUriPath()
    {
        return null;
    }

    public virtual void setImportUriPath(string importUriPath)
    {
    }

    // throws Exception
    public virtual object getKey()
    {
        return null;
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        return null;
    }

    // throws Exception
    public virtual HashMap toHashMap()
    {
        return null;
    }

}

