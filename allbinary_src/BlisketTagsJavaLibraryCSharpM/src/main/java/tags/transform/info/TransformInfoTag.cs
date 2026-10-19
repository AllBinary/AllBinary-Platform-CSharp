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
//using JspTagException = javax.servlet.jsp.JspTagException;
using TagHelperFactoryInterface = admin.taghelpers.TagHelperFactoryInterface;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using OutputTypeData = org.allbinary.logic.io.OutputTypeData;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoRequestHelperFactory = taghelpers.transform.info.TransformInfoRequestHelperFactory;
using ModifyTag = tags.ModifyTag;

namespace tags.transform.info;

public class TransformInfoTag : ModifyTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string name = null;
    private string storeName = null;
    private string objectFile = null;
    private string anyType = null;
    private string objectConfigFile = null;
    private string objectConfig = null;
    private string templateFile = null;
    private string template = null;
    private string dataFile = null;
    private string data = null;
    private string type = null;
    public TransformInfoTag() : base(new TransformInfoRequestHelperFactory())
    {
        // base(new TransformInfoRequestHelperFactory()) is called from the constructor declaration
    }

    public TransformInfoTag(TagHelperFactoryInterface tagHelperFactoryInterface) : base(tagHelperFactoryInterface)
    {
        // base(tagHelperFactoryInterface) is called from the constructor declaration
    }

    public virtual void setName(string value)
    {
        this.name = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().NAME, this.name);
    }

    public virtual void setStoreName(string value)
    {
        this.storeName = value;
        this.getPropertiesHashMap().put(StoreFrontData.getInstance().NAME, this.storeName);
    }

    public virtual void setObjectFile(string value)
    {
        this.objectFile = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().OBJECTFILENAME, this.objectFile);
    }

    public virtual void setObject(string value)
    {
        this.anyType = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().OBJECT, this.anyType);
    }

    public virtual void setTemplateFile(string value)
    {
        this.templateFile = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().TEMPLATEFILENAME, this.templateFile);
    }

    public virtual void setTemplate(string value)
    {
        this.template = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().TEMPLATE, this.template);
    }

    public virtual void setDataFile(string value)
    {
        this.dataFile = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().DATAFILENAME, this.dataFile);
    }

    public virtual void setData(string value)
    {
        this.data = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().DATA, this.data);
    }

    public virtual void setObjectConfigFile(string value)
    {
        this.objectConfigFile = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().OBJECTCONFIGFILENAME, this.objectConfigFile);
    }

    public virtual void setObjectConfig(string value)
    {
        this.objectConfig = value;
        this.getPropertiesHashMap().put(TransformInfoData.getInstance().OBJECTCONFIG, this.objectConfig);
    }

    public virtual void setType(string value)
    {
        this.type = value;
        this.getPropertiesHashMap().put(OutputTypeData.getInstance().NAME, this.type);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
            this.logUtil.putF("TransformInfoTag type set: " + this.type, this, "setType");
        }
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getObjectFile()
    {
        return this.objectFile;
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            return base.doStartTag();
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

