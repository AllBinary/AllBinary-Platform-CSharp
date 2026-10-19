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
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoHttpFactory
{
    private TransformInfoHttpFactory()
    {
    }

    // throws Exception
    public static TransformInfoInterface getInstance(HashMap propertiesHashMap, PageContext pageContext)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            WeblisketSession weblisketSession = new WeblisketSession(propertiesHashMap, pageContext);
            if (!StringValidationUtil.getInstance().isEmpty(weblisketSession.getStoreName())) {
                StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(weblisketSession.getStoreName());
                if (storeFrontInterface != null) {
                    return ((TransformInfoInterface) new TransformInfoHttpStore(storeFrontInterface, propertiesHashMap, pageContext));
                } else {
                    throw new Exception("No StoreFront with: " + weblisketSession.getStoreName());
                }
            } else {
                return ((TransformInfoInterface) new TransformInfoHttpContext(propertiesHashMap, pageContext));
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, "TransformInfoFactory", commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

