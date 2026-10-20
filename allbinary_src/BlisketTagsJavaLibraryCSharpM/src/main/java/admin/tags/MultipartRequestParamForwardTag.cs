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
//using JspTagException = javax.servlet.jsp.JspTagException;
//using Tag = javax.servlet.jsp.tagext.Tag;
using MultipartRequestParamForwardHelper = admin.taghelpers.MultipartRequestParamForwardHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CustomTagSupport = tags.CustomTagSupport;
using HelperTag = tags.HelperTag;

namespace admin.tags;

public class MultipartRequestParamForwardTag : CustomTagSupport
{
    private string page = null;
    private string command = null;
    private BasicArrayList paramVector = null;
    public virtual void setPage(string page)
    {
        this.page = page;
    }

    public virtual void setCommand(string command)
    {
        this.command = command;
    }

    public virtual void setParamVector(BasicArrayList paramVector)
    {
        this.paramVector = paramVector;
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            HelperTag parentTag = ((HelperTag) this.getParent());
            ParentInventoryTagHelper.getInstance().isValid(this, parentTag);
            HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
            hashMap.put(AbTagData.PARENT, parentTag);
            MultipartRequestParamForwardHelper multipartRequestParamForwardHelper = new MultipartRequestParamForwardHelper(parentTag, this.page, this.command, this.paramVector, this.pageContext);
            multipartRequestParamForwardHelper.forward();
            return Tag.SKIP_BODY;
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return Tag.SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return Tag.SKIP_BODY;
        }
    }

}

