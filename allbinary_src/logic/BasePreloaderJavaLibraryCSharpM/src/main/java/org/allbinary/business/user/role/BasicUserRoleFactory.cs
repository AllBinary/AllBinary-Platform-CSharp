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

namespace org.allbinary.business.user.role;

public class BasicUserRoleFactory
{
    private static readonly BasicUserRoleFactory instance = new BasicUserRoleFactory();
    public static BasicUserRoleFactory getInstance()
    {
        return BasicUserRoleFactory.instance;
    }

    private readonly long INACTIVITYTIMEOUT = 360000000L;
    private readonly long CUSTOMERTIMEOUT = 360000000L;
    private readonly long CUSTOMERMAXSESSIONTIME = 360000000L;
    private readonly long MAXSESSIONTIME = 360000000L;
    public readonly BasicUserRole INSTALLER;
    public readonly BasicUserRole ADMINISTRATOR;
    public readonly BasicUserRole CUSTOMER;
    public readonly BasicUserRole SUBSCRIBERCUSTOMER;
    public readonly BasicUserRole WHOLESALECUSTOMER;
    public readonly BasicUserRole STOREMANAGER;
    public readonly BasicUserRole PRODUCTMANAGER;
    public readonly BasicUserRole CUSTOMERMANAGER;
    public readonly BasicUserRole PAYMENTMANAGER;
    public readonly BasicUserRole ORDERMANAGER;
    public readonly BasicUserRole WEBMANAGER;
    public readonly BasicUserRole REVIEWER;
    public readonly BasicUserRole SHIPPING;
    public readonly BasicUserRole ADJUSTER;
    public readonly BasicUserRole WORKFLOWEDITOR;
    public readonly BasicUserRole WIZARD;
    public readonly BasicUserRole VIEWEDITOR;
    public BasicUserRoleFactory()
    {
        this.INSTALLER = new BasicUserRole("Installer", 16, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.ADMINISTRATOR = new BasicUserRole("Administrator", 0, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.CUSTOMER = new BasicUserRole("CustomerUser", "Customer User", 1, this.CUSTOMERTIMEOUT, this.CUSTOMERMAXSESSIONTIME);
        this.SUBSCRIBERCUSTOMER = new BasicUserRole("SubscriberUser", "Subscriber User", 2, this.CUSTOMERTIMEOUT, this.CUSTOMERMAXSESSIONTIME);
        this.WHOLESALECUSTOMER = new BasicUserRole("WholesaleUser", "Wholesale User", 3, this.CUSTOMERTIMEOUT, this.CUSTOMERMAXSESSIONTIME);
        this.STOREMANAGER = new BasicUserRole("StoreManager", "Store Manager", 4, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.PRODUCTMANAGER = new BasicUserRole("ProductManager", "Product Manager", 5, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.CUSTOMERMANAGER = new BasicUserRole("UserManager", "User Manager", 6, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.PAYMENTMANAGER = new BasicUserRole("PaymentManager", "Payment Manager", 7, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.ORDERMANAGER = new BasicUserRole("OrderManager", "Order Manager", 8, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.WEBMANAGER = new BasicUserRole("WebManager", "Web Manager", 9, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.REVIEWER = new BasicUserRole("Reviewer", 10, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.SHIPPING = new BasicUserRole("Shipping", 11, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.ADJUSTER = new BasicUserRole("Adjuster", 12, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.WORKFLOWEDITOR = new BasicUserRole("WorkFlowEditor", "WorkFlow Editor", 13, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.WIZARD = new BasicUserRole("WizardUser", "Wizard User", 14, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
        this.VIEWEDITOR = new BasicUserRole("ViewEditor", "View Editor", 15, this.MAXSESSIONTIME, this.INACTIVITYTIMEOUT);
    }

}

