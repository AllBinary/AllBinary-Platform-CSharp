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
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using StoreValidationTransformTag = tags.StoreValidationTransformTag;

namespace tags.admin.customizers;

public class ViewCustomizersTag : StoreValidationTransformTag
{
    public ViewCustomizersTag()
    {
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            this.setName("Add Validation Customizers View");
            this.setObjectFile("views.admin.customizers.CustomizersValidationView");
            return base.doStartTag();
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

