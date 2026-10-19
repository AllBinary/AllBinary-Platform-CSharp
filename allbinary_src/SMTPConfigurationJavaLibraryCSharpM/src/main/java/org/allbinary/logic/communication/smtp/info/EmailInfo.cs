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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.smtp.info;

public class EmailInfo
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private BasicEmailInfo basicEmailInfo = null;
    private string htmlAttachment = null;
    private string contentBase = null;
    public EmailInfo(BasicEmailInfo basicEmailInfo)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, commonStrings.CONSTRUCTOR);
        }
        this.init(basicEmailInfo, null, null);
    }

    public EmailInfo(BasicEmailInfo basicEmailInfo, string htmlAttachment, string contentBase)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, commonStrings.CONSTRUCTOR);
        }
        this.init(basicEmailInfo, null, null);
    }

    private void init(BasicEmailInfo basicEmailInfo, string htmlAttachment, string contentBase)
    {
        this.basicEmailInfo = basicEmailInfo;
        this.htmlAttachment = htmlAttachment;
        this.contentBase = contentBase;
    }

    public virtual BasicEmailInfo getBasicEmailInfo()
    {
        return this.basicEmailInfo;
    }

    public virtual string getHtmlAttachment()
    {
        return this.htmlAttachment;
    }

    public virtual string getContentBase()
    {
        return this.contentBase;
    }

    public override string ToString()
    {
        return "Email Info: \n " + this.getBasicEmailInfo().ToString();
    }

}

