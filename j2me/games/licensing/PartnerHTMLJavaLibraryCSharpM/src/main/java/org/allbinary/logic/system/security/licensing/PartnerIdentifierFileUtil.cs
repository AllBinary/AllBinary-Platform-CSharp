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
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.licensing;

public class PartnerIdentifierFileUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly PartnerIdentifierFileUtil instance = new PartnerIdentifierFileUtil();
    public static PartnerIdentifierFileUtil getInstance()
    {
        return PartnerIdentifierFileUtil.instance;
    }

    public readonly string FILE_NAME = "partner.txt";
    public virtual string get()
    {
        try {
            ResourceUtil resourceUtil = ResourceUtil.getInstance();
            string partnerString = StringUtil.getInstance().EMPTY_STRING;
            return partnerString;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET, e);
            return StringUtil.getInstance().NULL_STRING;
        }
    }

}

