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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using TransformFactory = org.allbinary.logic.visual.transform.TransformFactory;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using TransformDocumentInterface = org.allbinary.logic.visual.transform.data.TransformDocumentInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;

namespace taghelpers;

public class ViewHelper : TransformInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private TransformInterface componentInterface;
    public ViewHelper(HashMap hashMap, PageContext pageContext)
    {
        this.componentInterface = TransformFactory.getInstance().getInstance(this.abeClientInformation, hashMap, pageContext);
    }

    public int NO_TYPE = 0;
    public virtual int getTypeId()
    {
        return this.NO_TYPE;
    }

    // throws Exception
    public virtual string view()
    {
        try {
            return this.componentInterface.view();
        } catch (Exception e) {
            string error = "Failed to View: ";
            if (this.componentInterface != null) {
                error += this.componentInterface.GetType().FullName;
            } else {
                error += "Unknown";
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        try {
            throw new Exception("Hmm: " + this.componentInterface.getTransformDocumentInterface().getDoc());
        } catch (Exception e) {
            string error = "Failed to View: ";
            if (this.componentInterface != null) {
                error += this.componentInterface.GetType().FullName;
            } else {
                error += "Unknown";
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

    public virtual TransformInterface getViewObject()
    {
        return this.componentInterface;
    }

    // throws Exception
    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return this.componentInterface.getTransformInfoInterface();
    }

    public virtual TransformDocumentInterface getTransformDocumentInterface()
    {
        return null;
    }

    public virtual void setTransformDocumentInterface(TransformDocumentInterface viewDocumentInterface)
    {
        return;
    }

}

