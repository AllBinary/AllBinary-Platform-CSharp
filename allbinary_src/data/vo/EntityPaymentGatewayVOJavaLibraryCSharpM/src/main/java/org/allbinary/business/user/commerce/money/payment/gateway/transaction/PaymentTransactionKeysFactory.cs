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

namespace org.allbinary.business.user.commerce.money.payment.gateway.transaction;

public class PaymentTransactionKeysFactory
{
    private static readonly PaymentTransactionKeysFactory instance = new PaymentTransactionKeysFactory();
    public static PaymentTransactionKeysFactory getInstance()
    {
        return PaymentTransactionKeysFactory.instance;
    }

    public readonly PaymentTransactionKeys TRXTYPE = new PaymentTransactionKeys("TRXTYPE");
    public readonly PaymentTransactionKeys TENDER = new PaymentTransactionKeys("TENDER");
    public readonly PaymentTransactionKeys ACCT = new PaymentTransactionKeys("ACCT");
    public readonly PaymentTransactionKeys EXPDATE = new PaymentTransactionKeys("EXPDATE");
    public readonly PaymentTransactionKeys AMT = new PaymentTransactionKeys("AMT");
    public readonly PaymentTransactionKeys AUTHCODE = new PaymentTransactionKeys("AUTHCODE");
    public readonly PaymentTransactionKeys MICR = new PaymentTransactionKeys("MICR");
    public readonly PaymentTransactionKeys CHECKNUM = new PaymentTransactionKeys("CHECKNUM");
    public readonly PaymentTransactionKeys NAME = new PaymentTransactionKeys("NAME");
    public readonly PaymentTransactionKeys STREET = new PaymentTransactionKeys("STREET");
    public readonly PaymentTransactionKeys CITY = new PaymentTransactionKeys("CITY");
    public readonly PaymentTransactionKeys STATE = new PaymentTransactionKeys("STATE");
    public readonly PaymentTransactionKeys ZIP = new PaymentTransactionKeys("ZIP");
    public readonly PaymentTransactionKeys DL = new PaymentTransactionKeys("DL");
    public readonly PaymentTransactionKeys EMAIL = new PaymentTransactionKeys("EMAIL");
    public readonly PaymentTransactionKeys COMMENT1 = new PaymentTransactionKeys("COMMENT1");
    public readonly PaymentTransactionKeys COMMENT2 = new PaymentTransactionKeys("COMMENT2");
    public readonly PaymentTransactionKeys ORIGID = new PaymentTransactionKeys("ORIGID");
    public readonly PaymentTransactionKeys PONUM = new PaymentTransactionKeys("PONUM");
    public readonly PaymentTransactionKeys DESC = new PaymentTransactionKeys("PaymentTransactionDESC");
    public readonly PaymentTransactionKeys DESC1TO4 = new PaymentTransactionKeys("DESC1TO4");
    public readonly PaymentTransactionKeys INVNUM = new PaymentTransactionKeys("INVNUM");
    public readonly PaymentTransactionKeys SHIPTOZIP = new PaymentTransactionKeys("SHIPTOZIP");
    public readonly PaymentTransactionKeys SWIPE = new PaymentTransactionKeys("SWIPE");
    public readonly PaymentTransactionKeys TAXAMT = new PaymentTransactionKeys("TAXAMT");
    public readonly PaymentTransactionKeys COMMCARD = new PaymentTransactionKeys("COMMCARD");
    public readonly PaymentTransactionKeys DUTYAMT = new PaymentTransactionKeys("DUTYAMT");
    public readonly PaymentTransactionKeys FRIEGHTAMT = new PaymentTransactionKeys("FRIEGHTAMT");
    public readonly PaymentTransactionKeys ORDERDATE = new PaymentTransactionKeys("ORDERDATE");
    public readonly PaymentTransactionKeys TAXEXEMPT = new PaymentTransactionKeys("TAXEXEMPT");
    public readonly PaymentTransactionKeys COUNTRYCODE = new PaymentTransactionKeys("COUNTRYCODE");
    public readonly PaymentTransactionKeys CUSTCODE = new PaymentTransactionKeys("CUSTCODE");
    public readonly PaymentTransactionKeys CVV2 = new PaymentTransactionKeys("CVV2");
    public readonly PaymentTransactionKeys ABA = new PaymentTransactionKeys("ABA");
    public readonly PaymentTransactionKeys ACCTTYPE = new PaymentTransactionKeys("ACCTTYPE");
    public readonly PaymentTransactionKeys DISCOUNT = new PaymentTransactionKeys("DISCOUNT");
    public readonly PaymentTransactionKeys FIRSTNAME = new PaymentTransactionKeys("FIRSTNAME");
    public readonly PaymentTransactionKeys LASTNAME = new PaymentTransactionKeys("LASNAME");
    public readonly PaymentTransactionKeys SHIPFROMZIP = new PaymentTransactionKeys("SHIPFROMZIP");
    public readonly PaymentTransactionKeys PRENOTE = new PaymentTransactionKeys("PRENOTE");
    public readonly PaymentTransactionKeys CHKTYPE = new PaymentTransactionKeys("CHKTYPE");
    public readonly PaymentTransactionKeys DOB = new PaymentTransactionKeys("DOB");
    public readonly PaymentTransactionKeys PHONENUM = new PaymentTransactionKeys("PHONENUM");
    public readonly PaymentTransactionKeys SS = new PaymentTransactionKeys("SS");
    public readonly PaymentTransactionKeys COMPANYNAME = new PaymentTransactionKeys("COMPANYNAME");
    public readonly PaymentTransactionKeys COUNTRY = new PaymentTransactionKeys("COUNTRY");
    public readonly PaymentTransactionKeys FREIGHTAMT = new PaymentTransactionKeys("FREIGHTAMT");
    public readonly PaymentTransactionKeys SHIPTOCITY = new PaymentTransactionKeys("SHIPTOCITY");
    public readonly PaymentTransactionKeys SHIPTOFIRSTNAME = new PaymentTransactionKeys("SHIPTOFIRSTNAME");
    public readonly PaymentTransactionKeys SHIPTOLASTNAME = new PaymentTransactionKeys("SHIPTOLASTNAME");
    public readonly PaymentTransactionKeys SHIPTOSTATE = new PaymentTransactionKeys("SHIPTOSTATE");
    public readonly PaymentTransactionKeys SHIPTOSTREET = new PaymentTransactionKeys("SHIPTOSTREET");
    public readonly PaymentTransactionKeys SPECIAL1 = new PaymentTransactionKeys("SPECIAL1");
    public readonly PaymentTransactionKeys SPECIAL2 = new PaymentTransactionKeys("SPECIAL2");
    public readonly PaymentTransactionKeys SPECIAL3 = new PaymentTransactionKeys("SPECIAL3");
    public readonly PaymentTransactionKeys PARTNER = new PaymentTransactionKeys("PARTNER");
    public readonly PaymentTransactionKeys VENDOR = new PaymentTransactionKeys("VENDOR");
    public readonly PaymentTransactionKeys USER = new PaymentTransactionKeys("USER");
    public readonly PaymentTransactionKeys PWD = new PaymentTransactionKeys("PWD");
    public readonly PaymentTransactionKeys CHKNUM = new PaymentTransactionKeys("CHKNUM");
    public readonly PaymentTransactionKeys AVSADDR = new PaymentTransactionKeys("AVSADDR");
    public readonly PaymentTransactionKeys AVSZIP = new PaymentTransactionKeys("AVSZIP");
    public readonly PaymentTransactionKeys PNREF = new PaymentTransactionKeys("PNREF");
    public readonly PaymentTransactionKeys RESPMSG = new PaymentTransactionKeys("RESPMSG");
    public readonly PaymentTransactionKeys RESULT = new PaymentTransactionKeys("RESULT");
    public readonly PaymentTransactionKeys ORIGRESULT = new PaymentTransactionKeys("ORIGRESULT");
    public readonly PaymentTransactionKeys STATUS = new PaymentTransactionKeys("STATUS");
    public readonly PaymentTransactionKeys FRAUDCODE = new PaymentTransactionKeys("FRAUDCODE");
    public readonly PaymentTransactionKeys FRAUDMSG = new PaymentTransactionKeys("FRAUDMSG");
    public readonly PaymentTransactionKeys ERRCODE = new PaymentTransactionKeys("ERRCODE");
    public readonly PaymentTransactionKeys SCORE = new PaymentTransactionKeys("SCORE");
    public readonly PaymentTransactionKeys REASON1 = new PaymentTransactionKeys("REASON1");
    public readonly PaymentTransactionKeys REASON2 = new PaymentTransactionKeys("REASON2");
    public readonly PaymentTransactionKeys REASON3 = new PaymentTransactionKeys("REASON3");
    public readonly PaymentTransactionKeys EXCEPTION1 = new PaymentTransactionKeys("EXCEPTION1");
    public readonly PaymentTransactionKeys EXCEPTION2 = new PaymentTransactionKeys("EXCEPTION2");
    public readonly PaymentTransactionKeys EXCEPTION3 = new PaymentTransactionKeys("EXCEPTION3");
    public readonly PaymentTransactionKeys EXCEPTION4 = new PaymentTransactionKeys("EXCEPTION4");
    public readonly PaymentTransactionKeys EXCEPTION5 = new PaymentTransactionKeys("EXCEPTION5");
    public readonly PaymentTransactionKeys EXCEPTION6 = new PaymentTransactionKeys("EXCEPTION6");
    public readonly PaymentTransactionKeys EXCEPTION7 = new PaymentTransactionKeys("EXCEPTION7");
}

