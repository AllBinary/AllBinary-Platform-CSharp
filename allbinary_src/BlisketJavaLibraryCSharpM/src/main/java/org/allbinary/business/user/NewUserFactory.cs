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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using User = org.allbinary.business.user.modules.User;
using UserRoleData = org.allbinary.business.user.role.UserRoleData;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;

namespace org.allbinary.business.user;

public class NewUserFactory
{
    private NewUserFactory()
    {
    }

    // throws Exception
    public static UserInterface getInstance()
    {
        return new User();
    }

    // throws Exception
    public static UserInterface getInstance(TransformInfoInterface transformInfoInterface)
    {
        TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) transformInfoInterface);
        HttpServletRequest httpServletRequest = ((HttpServletRequest) httpTransformInfoInterface.getPageContext().getRequest());
        HashMap hashMap = new RequestParams(httpServletRequest).toHashMap();
        string role = ((string) httpTransformInfoInterface.getPropertiesHashMap().get(UserRoleData.NAME.ToString()));
        hashMap.put(UserRoleData.NAME.ToString(), role);
        return CreateUserFactory.getInstance(hashMap);
    }

    // throws Exception
    public static UserInterface getInstance(HttpServletRequest httpServletRequest, HashMap propertiesHashMap)
    {
        if (propertiesHashMap != null) {
            HashMap requestHashMap = new RequestParams(httpServletRequest).toHashMap();
            string roleString = ((string) propertiesHashMap.get(UserRoleData.NAME.ToString()));
            requestHashMap.put(UserRoleData.NAME.ToString(), roleString);
            return CreateUserFactory.getInstance(requestHashMap);
        } else {
            throw new Exception("Null HashMap");
        }
    }

}

