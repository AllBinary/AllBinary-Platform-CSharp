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
//using Calendar = java.util.Calendar;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using OrderHistoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityFactory;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TimeUtil = org.allbinary.time.TimeUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.admin.orderhistory;

public class DateRangeOrderHistoryView : HttpStoreComponentView, ValidationComponentInterface, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string VIEWALLORDERS = "View All";
    private readonly string VIEWORDERSINLASTHOUR = "Last Hour";
    private readonly string VIEWORDERSINLASTDAY = "Last Day";
    private readonly string VIEWORDERSINLASTWEEK = "Last Week";
    private readonly string VIEWORDERSINLAST30DAYS = "30 Days";
    private HttpServletRequest request;
    private string shipped = null;
    private string partiallyShipped = null;
    private string processing = null;
    private string preprocessing = null;
    private string cancelled = null;
    private string dateType = null;
    private string toDate = null;
    private string fromDate = null;
    private string fromYear = null;
    private string fromMonth = null;
    private string fromDay = null;
    private string fromHour = null;
    private string toYear = null;
    private string toMonth = null;
    private string toDay = null;
    private string toHour = null;
    private string command = null;
    private readonly string ON = "on";
    private int MAXLEN = 15;
    public DateRangeOrderHistoryView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.request = ((HttpServletRequest) this.getPageContext().getRequest());
        this.getFormData();
    }

    private void getFormData()
    {
        this.dateType = this.request.getParameter(OrderHistoryData.DATETYPE);
        this.preprocessing = this.request.getParameter(OrderHistoryData.PREPROCESSINGNAME);
        this.shipped = this.request.getParameter(OrderHistoryData.SHIPPEDNAME);
        this.partiallyShipped = this.request.getParameter(OrderHistoryData.PARTIALLYSHIPPEDNAME);
        this.processing = this.request.getParameter(OrderHistoryData.PROCESSINGNAME);
        this.cancelled = this.request.getParameter(OrderHistoryData.CANCELLEDNAME);
        this.fromYear = this.request.getParameter(OrderHistoryData.FROMYEAR);
        this.fromMonth = this.request.getParameter(OrderHistoryData.FROMMONTH);
        this.fromDay = this.request.getParameter(OrderHistoryData.FROMDAY);
        this.fromHour = this.request.getParameter(OrderHistoryData.FROMHOUR);
        this.toYear = this.request.getParameter(OrderHistoryData.TOYEAR);
        this.toMonth = this.request.getParameter(OrderHistoryData.TOMONTH);
        this.toDay = this.request.getParameter(OrderHistoryData.TODAY);
        this.toHour = this.request.getParameter(OrderHistoryData.TOHOUR);
        this.command = this.request.getParameter(GLOBALS2.ADMINCOMMAND);
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this));
    }

    // throws Exception
    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

    public virtual Node toXmlNode(Document document)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Attempt to View orders in (fromDate=");
                stringBuffer.append(this.fromDate);
                stringBuffer.append(",toDate=");
                stringBuffer.append(this.toDate);
                stringBuffer.append(") and status");
                this.logUtil.putF(stringBuffer.ToString(), this, "view");
            }
            Node node = document.createElement(OrderData.ORDERS);
            if (this.preprocessing != null && string.CompareOrdinal(this.preprocessing, this.ON) == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Adding Preprocessing Orders", this, "toXmlNode");
                }
                BasicArrayList orderHistoryVector = OrderHistoryEntityFactory.getInstance().getOrders(OrderHistoryData.PREPROCESSING, fromDate, toDate);
                int size = orderHistoryVector.size();
                for (int index = 0; index < size; index++) {
                    OrderHistory orderHistory = ((OrderHistory) orderHistoryVector.get(index));
                    node.appendChild(orderHistory.toXmlNode(document));
                }
            }
            if (this.shipped != null && string.CompareOrdinal(this.shipped, this.ON) == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Adding Shipped Orders", this, "toXmlNode");
                }
                BasicArrayList orderHistoryVector = OrderHistoryEntityFactory.getInstance().getOrders(OrderHistoryData.SHIPPED, fromDate, toDate);
                int size = orderHistoryVector.size();
                for (int index = 0; index < size; index++) {
                    OrderHistory orderHistory = ((OrderHistory) orderHistoryVector.get(index));
                    node.appendChild(orderHistory.toXmlNode(document));
                }
            }
            if (this.partiallyShipped != null && string.CompareOrdinal(this.partiallyShipped, this.ON) == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Adding Partially Shipped Orders", this, "toDomNode");
                }
                BasicArrayList orderHistoryVector = OrderHistoryEntityFactory.getInstance().getOrders(OrderHistoryData.PARTIALLYSHIPPED, fromDate, toDate);
                int size = orderHistoryVector.size();
                for (int index = 0; index < size; index++) {
                    OrderHistory orderHistory = ((OrderHistory) orderHistoryVector.get(index));
                    node.appendChild(orderHistory.toXmlNode(document));
                }
            }
            if (this.processing != null && string.CompareOrdinal(this.processing, this.ON) == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Adding Processing Orders", this, "toXmlNode");
                }
                BasicArrayList orderHistoryVector = OrderHistoryEntityFactory.getInstance().getOrders(OrderHistoryData.PROCESSING, fromDate, toDate);
                int size = orderHistoryVector.size();
                for (int index = 0; index < size; index++) {
                    OrderHistory orderHistory = ((OrderHistory) orderHistoryVector.get(index));
                    node.appendChild(orderHistory.toXmlNode(document));
                }
            }
            if (this.cancelled != null && string.CompareOrdinal(this.cancelled, this.ON) == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("Adding Cancelled Orders", this, "view");
                }
                BasicArrayList orderHistoryVector = OrderHistoryEntityFactory.getInstance().getOrders(OrderHistoryData.CANCELLED, fromDate, toDate);
                int size = orderHistoryVector.size();
                for (int index = 0; index < size; index++) {
                    OrderHistory orderHistory = ((OrderHistory) orderHistoryVector.get(index));
                    node.appendChild(orderHistory.toXmlNode(document));
                }
            }
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.PREPROCESSINGNAME, OrderHistoryData.PREPROCESSING));
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.PROCESSINGNAME, OrderHistoryData.PROCESSING));
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.CANCELLEDNAME, OrderHistoryData.CANCELLED));
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.PARTIALLYSHIPPEDNAME, OrderHistoryData.PARTIALLYSHIPPED));
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.SHIPPEDNAME, OrderHistoryData.SHIPPED));
            node.appendChild(ModDomHelper.createNameValueNodes(document, GLOBALS2.VIEWNAME, GLOBALS2.VIEW));
            return node;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XSLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            return null;
        }
    }

    public virtual bool? isValid()
    {
        try {
            bool? isValid = true;
            if (this.dateType == null || (string.CompareOrdinal(this.dateType, OrderHistoryData.TYPELONG) != 0 && string.CompareOrdinal(this.dateType, OrderHistoryData.TYPECAESAR) != 0)) {
                isValid = false;
            }
            if (this.dateType != null) {
                if (string.CompareOrdinal(this.dateType, OrderHistoryData.TYPELONG) == 0) {
                    Calendar calendar = Calendar.getInstance();
                    long currentTime = calendar.getTimeInMillis();
                    string rangeDate = StringUtil.getInstance().EMPTY_STRING;
                    if (string.CompareOrdinal(this.command, this.VIEWORDERSINLASTHOUR) == 0) {
                        long oneHour = 60L * 60L * 1000L;
                        rangeDate = oneHour.ToString();
                    } else if (string.CompareOrdinal(this.command, this.VIEWORDERSINLASTDAY) == 0) {
                        long oneDay = 24L * 60L * 60L * 1000L;
                        rangeDate = oneDay.ToString();
                    } else if (string.CompareOrdinal(this.command, this.VIEWORDERSINLASTWEEK) == 0) {
                        long oneWeek = 7L * 24L * 60L * 60L * 1000L;
                        rangeDate = oneWeek.ToString();
                    } else if (string.CompareOrdinal(this.command, this.VIEWORDERSINLAST30DAYS) == 0) {
                        long thirtyDays = 30L * 24L * 60L * 60L * 1000L;
                        rangeDate = thirtyDays.ToString();
                    } else if (string.CompareOrdinal(this.command, this.VIEWALLORDERS) == 0) {
                        rangeDate = currentTime.ToString();
                    }
                    long rangeDateLong = ((long) rangeDate);
                    this.fromDate = currentTime - rangeDateLong.ToString();
                    string time = new string((currentTime.ToString()).ToCharArray());
                    this.toDate = time;
                } else if (string.CompareOrdinal(this.dateType, OrderHistoryData.TYPECAESAR) == 0) {
                    Calendar calendar = Calendar.getInstance();
                    TimeUtil.getInstance().setCalendar(calendar, this.fromYear, this.fromMonth, this.fromDay, this.fromHour);
                    this.fromDate = calendar.getTimeInMillis().ToString();
                    TimeUtil.getInstance().setCalendar(calendar, this.toYear, this.toMonth, this.toDay, this.toHour);
                    this.toDate = calendar.getTimeInMillis().ToString();
                }
                if (StringValidationUtil.getInstance().isEmpty(this.toDate) || this.toDate.Length > this.MAXLEN) {
                    isValid = false;
                }
                if (StringValidationUtil.getInstance().isEmpty(this.fromDate) || this.fromDate.Length > this.MAXLEN) {
                    isValid = false;
                }
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Attempt to View orders in (fromDate=");
                stringBuffer.append(this.fromDate);
                stringBuffer.append(",toDate=");
                stringBuffer.append(this.toDate);
                stringBuffer.append(")");
                this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
            }
            return isValid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.put("Exception in validation", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    // throws Exception
    public virtual string validationInfo()
    {
        try {
            StringMaker result = new StringMaker();
            if (this.dateType == null || (string.CompareOrdinal(this.dateType, OrderHistoryData.TYPELONG) != 0 && string.CompareOrdinal(this.dateType, OrderHistoryData.TYPECAESAR) != 0)) {
                result.append("DATETYPE not recognized");
            }
            if (StringValidationUtil.getInstance().isEmpty(this.toDate) || this.toDate.Length > this.MAXLEN) {
                result.append("Invalid To Date");
            }
            if (StringValidationUtil.getInstance().isEmpty(this.fromDate) || this.fromDate.Length > this.MAXLEN) {
                result.append("Invalid From Date");
            }
            return result.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Getting Validation Info";
        }
    }

}

