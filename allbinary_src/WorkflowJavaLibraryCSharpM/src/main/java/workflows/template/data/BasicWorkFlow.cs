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
//using PageContext = javax.servlet.jsp.PageContext;
//using TagSupport = javax.servlet.jsp.tagext.TagSupport;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using WorkFlowData = org.allbinary.logic.control.workflow.WorkFlowData;
using WorkFlowInterface = org.allbinary.logic.control.workflow.WorkFlowInterface;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using TransformFactory = org.allbinary.logic.visual.transform.TransformFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace workflows.template.data;

public class BasicWorkFlow : WorkFlowInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private ValidationComponentInterface validationDomNodeInterface;
    private HashMap<object, object> propertiesHashMap;
    private PageContext pageContext;
    public BasicWorkFlow(HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().WORKFLOW)) {
            this.logUtil.putF("Properties: " + propertiesHashMap.ToString(), this, "BasicWorkFlow()");
        }
        this.propertiesHashMap = propertiesHashMap;
        this.pageContext = pageContext;
        this.validationDomNodeInterface = ((ValidationComponentInterface) TransformFactory.getInstance().getInstance(this.abeClientInformation, propertiesHashMap, pageContext));
    }

    // throws Exception
    public virtual string getName()
    {
        return ((string) this.getPropertiesHashMap().get(WorkFlowData.getInstance().NAME));
    }

    protected virtual HashMap<object, object> getPropertiesHashMap()
    {
        return this.propertiesHashMap;
    }

    protected virtual PageContext getPageContext()
    {
        return this.pageContext;
    }

    // throws Exception
    public virtual int? process()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().WORKFLOW)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.PROCESS);
        }
        if (this.validationDomNodeInterface.isValid()) {
            this.pageContext.getOut().print(this.validationDomNodeInterface.view());
            return (TagSupport.EVAL_BODY_INCLUDE).ToString();
        } else {
            this.pageContext.getOut().print(this.validationDomNodeInterface.validationInfo());
            return (TagSupport.SKIP_BODY).ToString();
        }
    }

}

