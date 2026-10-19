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
//using HashMap = java.util.HashMap;
//using PageContext = javax.servlet.jsp.PageContext;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace admin.taghelpers;

public class PaymentProcessHelperFactory : TagHelperFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PaymentProcessHelperFactory()
    {
    }

    // throws LicensingException
    public virtual Any getInstance(HashMap hashMap, PageContext pageContext)
    {
        try {
            return new PaymentProcessHelper(hashMap, pageContext);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

