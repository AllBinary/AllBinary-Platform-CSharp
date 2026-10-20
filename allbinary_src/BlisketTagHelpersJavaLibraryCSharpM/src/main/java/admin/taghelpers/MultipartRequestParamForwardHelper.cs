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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using PageContext = javax.servlet.jsp.PageContext;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using RequestMapInterface = org.allbinary.logic.communication.http.request.RequestMapInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using HelperTag = tags.HelperTag;

namespace admin.taghelpers;

public class MultipartRequestParamForwardHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly PageContext pageContext;
    private readonly RequestMapInterface requestMapInterface;
    private readonly string page;
    private readonly string command;
    private readonly BasicArrayList paramVector;
    public MultipartRequestParamForwardHelper(HelperTag parentHelperTag, string page, string command, BasicArrayList paramVector, PageContext pageContext)
    {
        this.pageContext = pageContext;
        this.page = page;
        this.command = command;
        this.paramVector = paramVector;
        this.requestMapInterface = InventoryItemViewParentTagHelper.getInstance().getRequestMapInterface(parentHelperTag);
    }

    // throws Exception
    public virtual void forward()
    {
        try {
            if (this.shouldForward()) {
                string @params = this.getParams();
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append(this.page);
                stringBuffer.append(@params);
                this.pageContext.forward(stringBuffer.ToString());
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "forward()", e);
            }
        }
    }

    private string getParams()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        string AMP = commonSeps.AMPERSAND;
        string QUESTION = commonSeps.QUESTION;
        string EQUALS = commonSeps.EQUALS;
        HashMap<object, object> hashMap = this.requestMapInterface.getRequestHashMap();
        StringMaker stringBuffer = new StringMaker();
        int size = this.paramVector.size();
        for (int index = 0; index < size; index++) {
            string key = ((string) this.paramVector.get(index));
            string value = ((string) hashMap.get(key));
            if (index != 0) {
                stringBuffer.append(AMP);
            } else {
                stringBuffer.append(QUESTION);
            }
            stringBuffer.append(key);
            stringBuffer.append(EQUALS);
            stringBuffer.append(value);
        }
        return stringBuffer.ToString();
    }

    private bool shouldForward()
    {
        HashMap<object, object> hashMap = this.requestMapInterface.getRequestHashMap();
        string requestCommand = ((string) hashMap.get(GLOBALS2.ADMINCOMMAND));
        if (StringValidationUtil.getInstance().isEmpty(this.command) || (!StringValidationUtil.getInstance().isEmpty(requestCommand) && string.CompareOrdinal(this.command, requestCommand) == 0)) {
            return true;
        }
        return false;
    }

}

