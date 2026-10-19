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

namespace org.allbinary.business.user.role;

public class AdminRoleFactory
{
    private static readonly AdminRoleFactory instance = new AdminRoleFactory();
    public static AdminRoleFactory getInstance()
    {
        return AdminRoleFactory.instance;
    }

    private readonly BasicArrayList adminRoles = new BasicArrayListD();
    private readonly BasicArrayList storeAdminRoles = new BasicArrayListD();
    private readonly BasicArrayList storeManagementRoles = new BasicArrayListD();
    private readonly BasicArrayList productManagementRoles = new BasicArrayListD();
    private readonly BasicArrayList reviewManagementRoles = new BasicArrayListD();
    private readonly BasicArrayList customerManagementRoles = new BasicArrayListD();
    private readonly BasicArrayList workflowManagementRoles = new BasicArrayListD();
    private readonly BasicArrayList orderManagementRoles = new BasicArrayListD();
    private readonly BasicArrayList adjusterManagementRoles = new BasicArrayListD();
    private readonly BasicArrayList shippingManagementRoles = new BasicArrayListD();
    private readonly BasicArrayList webManagementRoles = new BasicArrayListD();
    private AdminRoleFactory()
    {
        BasicUserRoleFactory basicUserRoleFactory = BasicUserRoleFactory.getInstance();
        this.adminRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.storeAdminRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.storeAdminRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.storeManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.storeManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.storeManagementRoles.add(basicUserRoleFactory.CUSTOMERMANAGER);
        this.storeManagementRoles.add(basicUserRoleFactory.ADJUSTER);
        this.storeManagementRoles.add(basicUserRoleFactory.PRODUCTMANAGER);
        this.storeManagementRoles.add(basicUserRoleFactory.REVIEWER);
        this.storeManagementRoles.add(basicUserRoleFactory.SHIPPING);
        this.productManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.productManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.productManagementRoles.add(basicUserRoleFactory.PRODUCTMANAGER);
        this.reviewManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.reviewManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.reviewManagementRoles.add(basicUserRoleFactory.REVIEWER);
        this.customerManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.customerManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.customerManagementRoles.add(basicUserRoleFactory.CUSTOMERMANAGER);
        this.workflowManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.workflowManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.workflowManagementRoles.add(basicUserRoleFactory.WORKFLOWEDITOR);
        this.orderManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.orderManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.adjusterManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.adjusterManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.adjusterManagementRoles.add(basicUserRoleFactory.ADJUSTER);
        this.shippingManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.shippingManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.shippingManagementRoles.add(basicUserRoleFactory.SHIPPING);
        this.webManagementRoles.add(basicUserRoleFactory.ADMINISTRATOR);
        this.webManagementRoles.add(basicUserRoleFactory.STOREMANAGER);
        this.webManagementRoles.add(basicUserRoleFactory.WEBMANAGER);
        this.webManagementRoles.add(basicUserRoleFactory.WORKFLOWEDITOR);
        this.webManagementRoles.add(basicUserRoleFactory.VIEWEDITOR);
    }

    public virtual BasicArrayList getProductManagementRoles()
    {
        return this.productManagementRoles;
    }

    public virtual BasicArrayList getAdminRoles()
    {
        return this.adminRoles;
    }

    public virtual BasicArrayList getStoreAdminRoles()
    {
        return this.storeAdminRoles;
    }

    public virtual BasicArrayList getStoreManagementRoles()
    {
        return this.storeManagementRoles;
    }

    public virtual BasicArrayList getReviewManagementRoles()
    {
        return this.reviewManagementRoles;
    }

    public virtual BasicArrayList getCustomerManagementRoles()
    {
        return this.customerManagementRoles;
    }

    public virtual BasicArrayList getWorkflowManagementRoles()
    {
        return this.workflowManagementRoles;
    }

    public virtual BasicArrayList getWebManagementRoles()
    {
        return this.webManagementRoles;
    }

    public virtual BasicArrayList getShippingManagementRoles()
    {
        return this.shippingManagementRoles;
    }

    public virtual BasicArrayList getAdjusterManagementRoles()
    {
        return this.adjusterManagementRoles;
    }

    public virtual BasicArrayList getOrderManagementRoles()
    {
        return this.orderManagementRoles;
    }

}

