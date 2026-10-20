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
using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using EntryData = org.allbinary.business.entry.EntryData;
using QuoteRequestData = org.allbinary.business.quoterequest.QuoteRequestData;
using UserData = org.allbinary.business.user.UserData;
using QuoteRequestIdGenerator = org.allbinary.data.generator.QuoteRequestIdGenerator;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlData = org.allbinary.logic.communication.sql.AbSqlData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.quoterequest;

public class QuoteRequest
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private string id;
    private string userName = null;
    private string projectInfo = null;
    private string userComments = null;
    private string budget = null;
    private string timeFrame = null;
    private string comments = null;
    public QuoteRequest(string userName, HttpServletRequest request)
    {
        QuoteRequestData quoteRequestData = QuoteRequestData.getInstance();
        this.id = new QuoteRequestIdGenerator().getNext();
        this.setUserName(userName);
        this.setProjectInfo(((string) request.getParameter(quoteRequestData.PROJECT_INFO)));
        this.setUserComments(((string) request.getParameter(quoteRequestData.CUSTOMER_COMMENTS)));
        this.setBudget(((string) request.getParameter(quoteRequestData.BUDGET)));
        this.setTimeFrame(((string) request.getParameter(quoteRequestData.TIMEFRAME)));
        this.setComments(((string) request.getParameter(quoteRequestData.COMMENTS)));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
            this.logUtil.putF("Created with: " + this.toHashMap(), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public QuoteRequest(HashMap<object, object> hashMap)
    {
        QuoteRequestData quoteRequestData = QuoteRequestData.getInstance();
        this.id = ((string) hashMap.get(quoteRequestData.ID));
        this.setUserName(((string) hashMap.get(UserData.USERNAME)));
        this.setProjectInfo(((string) hashMap.get(quoteRequestData.PROJECT_INFO)));
        this.setUserComments(((string) hashMap.get(quoteRequestData.CUSTOMER_COMMENTS)));
        this.setBudget(((string) hashMap.get(quoteRequestData.BUDGET)));
        this.setTimeFrame(((string) hashMap.get(quoteRequestData.TIMEFRAME)));
        this.setComments(((string) hashMap.get(quoteRequestData.COMMENTS)));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
            this.logUtil.putF("Created with: " + this.toHashMap(), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public virtual bool? isValid()
    {
        try {
            bool? valid = true;
            if (this.userName == null || this.userName.Length < 4 || this.userName.Length > 250) {
                valid = false;
            }
            if (this.projectInfo == null || this.projectInfo.Length < 0 || this.projectInfo.Length > AbSqlData.MAXBLOB) {
                valid = false;
            }
            if (this.userComments == null || this.userComments.Length < 0 || this.userComments.Length > AbSqlData.MAXBLOB) {
                valid = false;
            }
            if (this.budget == null || this.budget.Length < 0 || this.budget.Length > AbSqlData.MAXBLOB) {
                valid = false;
            }
            if (this.timeFrame == null || this.timeFrame.Length < 0 || this.timeFrame.Length > AbSqlData.MAXBLOB) {
                valid = false;
            }
            if (this.comments == null || this.comments.Length < 0 || this.comments.Length > AbSqlData.MAXBLOB) {
                valid = false;
            }
            return valid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            if (this.userName == null || this.userName.Length < 4 || this.userName.Length > 250) {
                stringBuffer.append("Please enter a User Name with more than 4 characters.<br>");
            }
            if (this.projectInfo == null || this.projectInfo.Length < 0 || this.projectInfo.Length > AbSqlData.MAXBLOB) {
                stringBuffer.append("Please enter Project Info with less than " + AbSqlData.MAXBLOB + " characters.<br>");
            }
            if (this.userComments == null || this.userComments.Length < 0 || this.userComments.Length > AbSqlData.MAXBLOB) {
                stringBuffer.append("Please enter User Comments with less than " + AbSqlData.MAXBLOB + " characters.<br>");
            }
            if (this.budget == null || this.budget.Length < 0 || this.budget.Length > AbSqlData.MAXBLOB) {
                stringBuffer.append("Please enter Budget with less than " + AbSqlData.MAXBLOB + " characters.<br>");
            }
            if (this.timeFrame == null || this.timeFrame.Length < 0 || this.timeFrame.Length > AbSqlData.MAXBLOB) {
                stringBuffer.append("Please enter time frame with less than " + AbSqlData.MAXBLOB + " characters.<br>");
            }
            if (this.comments == null || this.comments.Length < 0 || this.comments.Length > AbSqlData.MAXBLOB) {
                stringBuffer.append("Please enter comments with less than " + AbSqlData.MAXBLOB + " characters.<br>");
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
        }
    }

    public virtual BasicArrayList toVector()
    {
        BasicArrayList values = new BasicArrayListD();
        values.add(this.id);
        values.add(this.userName);
        values.add(this.projectInfo);
        values.add(this.userComments);
        values.add(this.budget);
        values.add(this.timeFrame);
        values.add(this.comments);
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        values.add(time);
        values.add(time);
        return values;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        QuoteRequestData quoteRequestData = QuoteRequestData.getInstance();
        HashMap<object, object> values = StdUtil.getInstance().createHashMap();
        values.put(UserData.USERNAME, userName);
        values.put(quoteRequestData.PROJECT_INFO, this.projectInfo);
        values.put(quoteRequestData.CUSTOMER_COMMENTS, this.userComments);
        values.put(quoteRequestData.BUDGET, this.budget);
        values.put(quoteRequestData.TIMEFRAME, this.timeFrame);
        values.put(quoteRequestData.COMMENTS, this.comments);
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        values.put(EntryData.getInstance().LASTMODIFIED, time);
        return values;
    }

    public virtual void setUserName(string value)
    {
        this.userName = value;
    }

    public virtual void setProjectInfo(string value)
    {
        this.projectInfo = value;
    }

    public virtual void setUserComments(string value)
    {
        this.userComments = value;
    }

    public virtual void setBudget(string value)
    {
        this.budget = value;
    }

    public virtual void setTimeFrame(string value)
    {
        this.timeFrame = value;
    }

    public virtual void setComments(string value)
    {
        this.comments = value;
        StringUtil stringUtil = StringUtil.getInstance();
        if (this.comments == null) {
            this.comments = stringUtil.EMPTY_STRING;
        }
    }

    public virtual string getUserName()
    {
        return this.userName;
    }

    public virtual string getProjectInfo()
    {
        return this.projectInfo;
    }

    public virtual string getUserComments()
    {
        return this.userComments;
    }

    public virtual string getBudget()
    {
        return this.budget;
    }

    public virtual string getTimeFrame()
    {
        return this.timeFrame;
    }

    public virtual string getComments()
    {
        return this.comments;
    }

}

