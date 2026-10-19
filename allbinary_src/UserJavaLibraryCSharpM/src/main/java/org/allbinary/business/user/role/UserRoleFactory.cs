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
using UserFactory = org.allbinary.business.user.modules.UserFactory;
using AdminUserFactory = org.allbinary.business.user.modules.admin.AdminUserFactory;
using StoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.StoreAdminUserFactory;
using CustomerStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.customer.CustomerStoreAdminUserFactory;
using OrderStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.order.OrderStoreAdminUserFactory;
using AdjustOrderStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.order.adjust.AdjustOrderStoreAdminUserFactory;
using ReviewOrderStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.order.review.ReviewOrderStoreAdminUserFactory;
using ShipOrderStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.order.ship.ShipOrderStoreAdminUserFactory;
using PaymentStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.payment.PaymentStoreAdminUserFactory;
using ProductStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.product.ProductStoreAdminUserFactory;
using WebStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.web.WebStoreAdminUserFactory;
using ViewEditorWebStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.web.view.editor.ViewEditorWebStoreAdminUserFactory;
using WizardWebStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.web.wizard.WizardWebStoreAdminUserFactory;
using WorkflowEditorWebStoreAdminUserFactory = org.allbinary.business.user.modules.admin.store.web.workflow.editor.WorkflowEditorWebStoreAdminUserFactory;
using SubscriberUserFactory = org.allbinary.business.user.modules.customer.subscriber.SubscriberUserFactory;
using WholesaleUserFactory = org.allbinary.business.user.modules.customer.wholesale.WholesaleUserFactory;

namespace org.allbinary.business.user.role;

public class UserRoleFactory
{
    private static readonly UserRoleFactory instance = new UserRoleFactory();
    public static UserRoleFactory getInstance()
    {
        return UserRoleFactory.instance;
    }

    private readonly BasicUserRoleFactory basicUserRoleFactory = BasicUserRoleFactory.getInstance();
    public readonly UserRole INSTALLER;
    public readonly UserRole ADMINISTRATOR;
    public readonly UserRole CUSTOMER;
    public readonly UserRole SUBSCRIBERCUSTOMER;
    public readonly UserRole WHOLESALECUSTOMER;
    public readonly UserRole STOREMANAGER;
    public readonly UserRole PRODUCTMANAGER;
    public readonly UserRole CUSTOMERMANAGER;
    public readonly UserRole PAYMENTMANAGER;
    public readonly UserRole ORDERMANAGER;
    public readonly UserRole WEBMANAGER;
    public readonly UserRole REVIEWER;
    public readonly UserRole SHIPPING;
    public readonly UserRole ADJUSTER;
    public readonly UserRole WORKFLOWEDITOR;
    public readonly UserRole WIZARD;
    public readonly UserRole VIEWEDITOR;
    public UserRoleFactory()
    {
        this.INSTALLER = new UserRoleB(this.basicUserRoleFactory.INSTALLER, null);
        this.ADMINISTRATOR = new UserRoleB(this.basicUserRoleFactory.ADMINISTRATOR, new AdminUserFactory());
        this.CUSTOMER = new UserRoleB(this.basicUserRoleFactory.CUSTOMER, new UserFactory());
        this.SUBSCRIBERCUSTOMER = new UserRoleB(this.basicUserRoleFactory.SUBSCRIBERCUSTOMER, new SubscriberUserFactory());
        this.WHOLESALECUSTOMER = new UserRoleB(this.basicUserRoleFactory.WHOLESALECUSTOMER, new WholesaleUserFactory());
        this.STOREMANAGER = new UserRoleB(this.basicUserRoleFactory.STOREMANAGER, new StoreAdminUserFactory());
        this.PRODUCTMANAGER = new UserRoleB(this.basicUserRoleFactory.PRODUCTMANAGER, new ProductStoreAdminUserFactory());
        this.CUSTOMERMANAGER = new UserRoleB(this.basicUserRoleFactory.CUSTOMERMANAGER, new CustomerStoreAdminUserFactory());
        this.PAYMENTMANAGER = new UserRoleB(this.basicUserRoleFactory.PAYMENTMANAGER, new PaymentStoreAdminUserFactory());
        this.ORDERMANAGER = new UserRoleB(this.basicUserRoleFactory.ORDERMANAGER, new OrderStoreAdminUserFactory());
        this.WEBMANAGER = new UserRoleB(this.basicUserRoleFactory.WEBMANAGER, new WebStoreAdminUserFactory());
        this.REVIEWER = new UserRoleB(this.basicUserRoleFactory.REVIEWER, new ReviewOrderStoreAdminUserFactory());
        this.SHIPPING = new UserRoleB(this.basicUserRoleFactory.SHIPPING, new ShipOrderStoreAdminUserFactory());
        this.ADJUSTER = new UserRoleB(this.basicUserRoleFactory.ADJUSTER, new AdjustOrderStoreAdminUserFactory());
        this.WORKFLOWEDITOR = new UserRoleB(this.basicUserRoleFactory.WORKFLOWEDITOR, new WorkflowEditorWebStoreAdminUserFactory());
        this.WIZARD = new UserRoleB(this.basicUserRoleFactory.WIZARD, new WizardWebStoreAdminUserFactory());
        this.VIEWEDITOR = new UserRoleB(this.basicUserRoleFactory.VIEWEDITOR, new ViewEditorWebStoreAdminUserFactory());
    }

}

