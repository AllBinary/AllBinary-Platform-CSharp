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
using UserHelperFactory = admin.taghelpers.UserHelperFactory;
using EntryData = org.allbinary.business.entry.EntryData;
using UserRoleData = org.allbinary.business.user.role.UserRoleData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;

namespace admin.tags;

public class UserTag : TableTag
{
    private string role = null;
    private string enable = null;
    public UserTag()
    {
        this.setTagHelperFactory(new UserHelperFactory());
        this.setTagRequestHelperFactory(new UserHelperFactory());
    }

    public virtual void setRole(string value)
    {
        this.role = value;
        this.getPropertiesHashMap().put(UserRoleData.NAME, this.role);
    }

    public virtual void setEnable(string value)
    {
        this.enable = value;
        this.getPropertiesHashMap().put(EntryData.getInstance().ENABLE, this.enable);
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.isEnabled()) {
                return base.doStartTag();
            }
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

