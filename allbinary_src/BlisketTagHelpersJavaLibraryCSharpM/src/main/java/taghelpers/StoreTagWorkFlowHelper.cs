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
using TagHelper = admin.taghelpers.TagHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StoreTagWorkFlowFactory = org.allbinary.logic.control.workflow.StoreTagWorkFlowFactory;
using StoreWorkFlowInterface = org.allbinary.logic.control.workflow.StoreWorkFlowInterface;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace taghelpers;

public class StoreTagWorkFlowHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private StoreWorkFlowInterface storeWorkFlowInterface;
    public StoreTagWorkFlowHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
            this.logUtil.putF("Properties: " + hashMap.ToString(), this, "StoreTagWorkFlowHelper()");
        }
        this.storeWorkFlowInterface = StoreTagWorkFlowFactory.getInstance().getInstance(this.abeClientInformation, hashMap, pageContext);
    }

    // throws Exception
    public virtual int? process()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                this.logUtil.putF("Process", this, this.commonStrings.PROCESS);
            }
            return this.storeWorkFlowInterface.process();
        } catch (Exception e) {
            string error = "Failed to process workflow: ";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

