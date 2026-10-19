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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.http;

public class AcceptableResponseGenerator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AcceptableResponseGenerator instance = new AcceptableResponseGenerator();
    public static AcceptableResponseGenerator getInstance()
    {
        return AcceptableResponseGenerator.instance;
    }

    private AcceptableResponseGenerator()
    {
    }

    // throws Exception
    public virtual string get(HttpServletRequest httpServletRequest)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            AcceptableResponseUtil acceptableResponseUtil = AcceptableResponseUtil.getInstance();
            string acceptable = httpServletRequest.getHeader("accept");
            string result = acceptableResponseUtil.getTagName(0);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTP)) {
                this.logUtil.putF("Request Type: " + acceptable, this, commonStrings.GET);
            }
            if (acceptable != null) {
                int size = acceptableResponseUtil.size();
                for (int index = 0; index < size; index++) {
                    if (string.CompareOrdinal(acceptable, acceptableResponseUtil.get(index)) == 0) {
                        result = acceptableResponseUtil.getTagName(index);
                    }
                }
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTP)) {
                this.logUtil.putF("Response Type: " + result, this, commonStrings.GET);
            }
            return result;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET, e);
            }
            throw e;
        }
    }

}

