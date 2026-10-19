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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicPaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentTypeUtil;
using PaymentGatewayEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.gateway.PaymentGatewayEntityFactory;
using PaymentGatewayEntityInterface = org.allbinary.data.tables.user.commerce.money.payment.gateway.PaymentGatewayEntityInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using PaymentGatewayViewAbstract = views.admin.payment.gateway.PaymentGatewayViewAbstract;

namespace views.admin.payment.gateways;

public class SelectNewView : PaymentGatewayViewAbstract
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public SelectNewView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual string view()
    {
        try {
            PaymentGatewayEntityInterface paymentGatewayEntityInterface = PaymentGatewayEntityFactory.getInstance();
            BasicArrayList existingGateways = paymentGatewayEntityInterface.findPaymentTypeVectorByStore(this.getPaymentGatewayPrimaryKey().getStoreName());
            BasicArrayList allGatewaysLessExisting = BasicPaymentTypeUtil.getInstance().difference(existingGateways);
            return new PaymentGatewaysView(this.getTransformInfoInterface(), allGatewaysLessExisting).view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view", e);
            }
            throw e;
        }
    }

}

