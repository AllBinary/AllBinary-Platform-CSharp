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
//using Tag = javax.servlet.jsp.tagext.Tag;
using InventoryHelperFactory = admin.taghelpers.InventoryHelperFactory;
using InventoryRequestHelperFactory = admin.taghelpers.InventoryRequestHelperFactory;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;

namespace admin.tags;

public class InventoryTag : TableTag
{
    private string storeName = null;
    public InventoryTag() : base()
    {
        // base() is called from the constructor declaration
        this.setTagHelperFactory(new InventoryHelperFactory());
        this.setTagRequestHelperFactory(new InventoryRequestHelperFactory());
    }

    public virtual void setStoreName(string value)
    {
        this.storeName = value;
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.isEnabled()) {
                if (this.getCommand() != null) {
                    if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.BACKUP) != 0 && this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.RESTORE) != 0 && this.getCommand().compareTo(this.commonStrings.CREATE) != 0 && this.getCommand().compareTo(this.commonStrings.DROP) != 0) {
                        Tag parentTag = this.getParent();
                        ParentInventoryTagHelper.getInstance().isValid(this, parentTag);
                        this.getPropertiesHashMap().put(AbTagData.PARENT, parentTag);
                        this.getPropertiesHashMap().put(StoreFrontData.getInstance().NAME, this.storeName);
                    }
                    return base.doStartTag();
                }
            }
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

