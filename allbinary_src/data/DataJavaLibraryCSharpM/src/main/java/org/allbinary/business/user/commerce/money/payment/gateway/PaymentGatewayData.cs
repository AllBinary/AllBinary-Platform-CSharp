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

namespace org.allbinary.business.user.commerce.money.payment.gateway;

public class PaymentGatewayData
{
    public static readonly int CRYPTNUM = 5;
    private string key;
    public static readonly PaymentGatewayData ID = new PaymentGatewayData("PAYMENTGATEWAY_ID");
    public static readonly PaymentGatewayData NAME = new PaymentGatewayData("PAYMENTGATEWAY_NAME");
    public static readonly PaymentGatewayData VALUE = new PaymentGatewayData("PAYMENTGATEWAY_VALUE");
    public static readonly PaymentGatewayData PAYMENTTRANSACTIONINTERFACEFACTORYINTERFACE = new PaymentGatewayData("PAYMENTGATEWAY_PAYMENTTRANSACTIONINTERFACEFACTORYINTERFACE");
    public static readonly PaymentGatewayData PAYMENTPROCESSORINTERFACEFACTORYINTERFACE = new PaymentGatewayData("PAYMENTGATEWAY_PAYMENTPROCESSORINTERFACEFACTORYINTERFACE");
    public static readonly PaymentGatewayData MODE = new PaymentGatewayData("MODE");
    public static readonly PaymentGatewayData SERVERPROTOCOL = new PaymentGatewayData("SERVERPROTOCOL");
    public static readonly PaymentGatewayData SERVER = new PaymentGatewayData("SERVER");
    public static readonly PaymentGatewayData SERVERPORT = new PaymentGatewayData("SERVERPORT");
    public static readonly PaymentGatewayData SERVERPATH = new PaymentGatewayData("SERVERPATH");
    public static readonly PaymentGatewayData TESTPROTOCOL = new PaymentGatewayData("TESTSERVERPROTOCOL");
    public static readonly PaymentGatewayData TESTSERVER = new PaymentGatewayData("TESTSERVER");
    public static readonly PaymentGatewayData TESTPORT = new PaymentGatewayData("TESTPORT");
    public static readonly PaymentGatewayData TESTPATH = new PaymentGatewayData("TESTSERVERPATH");
    public static readonly PaymentGatewayData TIMEOUT = new PaymentGatewayData("TIMEOUT");
    public static readonly PaymentGatewayData PROXYPROTOCOL = new PaymentGatewayData("PROXYPROTOCOL");
    public static readonly PaymentGatewayData PROXYSERVER = new PaymentGatewayData("PROXYSERVER");
    public static readonly PaymentGatewayData PROXYPATH = new PaymentGatewayData("PROXYPATH");
    public static readonly PaymentGatewayData PROXYUSERNAME = new PaymentGatewayData("PROXYUSERNAME");
    public static readonly PaymentGatewayData PROXYPASSWORD = new PaymentGatewayData("PROXYPASSWORD");
    public static readonly PaymentGatewayData PROXYPORT = new PaymentGatewayData("PROXYPORT");
    public static readonly PaymentGatewayData PROXYTIMEOUT = new PaymentGatewayData("PROXYTIMEOUT");
    public static readonly PaymentGatewayData SPECIAL1 = new PaymentGatewayData("SPECIAL1");
    public static readonly PaymentGatewayData SPECIAL2 = new PaymentGatewayData("SPECIAL2");
    public static readonly PaymentGatewayData SPECIAL3 = new PaymentGatewayData("SPECIAL3");
    public static readonly PaymentGatewayData SPECIAL4 = new PaymentGatewayData("SPECIAL4");
    public static readonly PaymentGatewayData SPECIAL5 = new PaymentGatewayData("SPECIAL5");
    public static readonly PaymentGatewayData SPECIAL6 = new PaymentGatewayData("SPECIAL6");
    public static readonly PaymentGatewayData SPECIAL7 = new PaymentGatewayData("SPECIAL7");
    public static readonly PaymentGatewayData SPECIAL8 = new PaymentGatewayData("SPECIAL8");
    public static readonly PaymentGatewayData SPECIAL9 = new PaymentGatewayData("SPECIAL9");
    private PaymentGatewayData(string value)
    {
        this.key = value;
    }

    public override string ToString()
    {
        return this.key;
    }

}

