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
using OrderHistoryFactory = org.allbinary.business.user.commerce.inventory.order.OrderHistoryFactory;
using OrderItemsEntity = org.allbinary.data.tables.user.commerce.inventory.order.OrderItemsEntity;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.order;

public class ValidationView : OrderView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public ValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        try {
            bool? valid = true;
            if (this.order.isIdValid() == false) {
                return false;
            } else {
                this.orderHistory = OrderHistoryFactory.getInstance(this.order.getId());
                if (this.orderHistory == null || this.orderHistory.isValid() == false) {
                    return false;
                }
                OrderItemsEntity orderItems = new OrderItemsEntity();
                this.basketReview = orderItems.getBasketReview(this.order.getId());
                if (this.basketReview == null || this.basketReview.isValid() == false) {
                    return false;
                }
            }
            return valid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            if (this.order.isIdValid() == false) {
                stringBuffer.append(this.order.getIdValidationInfo());
            } else {
                this.orderHistory = OrderHistoryFactory.getInstance(this.order.getId());
                if (this.orderHistory == null || this.orderHistory.isValid() == false) {
                    stringBuffer.append("Order History data error for: ");
                    stringBuffer.append(this.order.getId());
                    stringBuffer.append("<br />");
                }
                OrderItemsEntity orderItems = new OrderItemsEntity();
                this.basketReview = orderItems.getBasketReview(this.order.getId());
                if (this.basketReview == null) {
                    stringBuffer.append("Order Items data error - does not exist for: ");
                    stringBuffer.append(this.order.getId());
                    stringBuffer.append("<br />");
                } else if (this.basketReview.isValid() == false) {
                    stringBuffer.append("Order Items data error - not valid for: ");
                    stringBuffer.append(this.order.getId());
                    stringBuffer.append("<br />");
                }
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
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

}

