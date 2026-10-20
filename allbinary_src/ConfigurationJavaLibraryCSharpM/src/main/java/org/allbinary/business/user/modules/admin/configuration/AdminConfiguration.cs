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
using System.Runtime.CompilerServices;
using java.util;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using ContextConfiguration = org.allbinary.business.context.configuration.ContextConfiguration;
using ContextConfigurationData = org.allbinary.business.context.configuration.ContextConfigurationData;
using ContextConfigurationDomDocumentMapping = org.allbinary.business.context.configuration.ContextConfigurationDomDocumentMapping;
using ContextConfigurationInterface = org.allbinary.business.context.configuration.ContextConfigurationInterface;
using ContextConfigurationInterfaceFactory = org.allbinary.business.context.configuration.ContextConfigurationInterfaceFactory;
using ContextConfigurationPathUtil = org.allbinary.business.context.configuration.ContextConfigurationPathUtil;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CryptFileWriter = org.allbinary.logic.control.crypt.file.CryptFileWriter;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.modules.admin.configuration;

public class AdminConfiguration : AdminConfigurationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private ContextConfigurationInterface contextConfigurationInterface;
    public AdminConfiguration()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.contextConfigurationInterface = ContextConfigurationInterfaceFactory.getInstance().getInstance(AdminConfigurationData.CONTEXTNAME);
    }

    public AdminConfiguration(HttpServletRequest request)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.getFormData(new RequestParams(request).toHashMap());
    }

    public AdminConfiguration(HashMap<object, object> storeHashMap)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.getFormData(storeHashMap);
    }

    // throws Exception
    private void getFormData(HashMap<object, object> storeHashMap)
    {
        this.logUtil.putF(this.commonStrings.START, this, "getFormData");
        this.setContextConfigurationInterface(((ContextConfigurationInterface) new ContextConfiguration(storeHashMap)));
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void write()
    {
        ContextConfigurationDomDocumentMapping contextConfigurationDomDocumentMapping = new ContextConfigurationDomDocumentMapping(this.getContextConfigurationInterface());
        CryptFileWriter cryptFileWriter = new CryptFileWriter(ContextConfigurationData.getInstance().UNCRYPTED_EXTENSION, ContextConfigurationData.getInstance().ENCRYPTED_EXTENSION);
        cryptFileWriter.write(ContextConfigurationPathUtil.getAbPath(AdminConfigurationData.CONTEXTNAME), contextConfigurationDomDocumentMapping.toXmlDoc());
    }

    public virtual ContextConfigurationInterface getContextConfigurationInterface()
    {
        return this.contextConfigurationInterface;
    }

    public virtual void setContextConfigurationInterface(ContextConfigurationInterface contextConfigurationInterface)
    {
        this.contextConfigurationInterface = contextConfigurationInterface;
    }

}

