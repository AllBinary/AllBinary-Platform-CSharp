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
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace views.generic.inventory;

public class InventorySearchLoopInfo
{
    public int lastPage = -1;
    public int currentPage = -1;
    public int numberOfResultsOnCurrentPage = 0;
    public int numberOfResults = 0;
    private readonly string CURRENT = "current: ";
    private readonly string NUM = " num: ";
    private readonly string LAST = " last: ";
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.CURRENT);
        stringBuffer.appendint(this.currentPage);
        stringBuffer.append(this.NUM);
        stringBuffer.appendint(this.numberOfResults);
        stringBuffer.append(this.LAST);
        stringBuffer.appendint(this.lastPage);
        return stringBuffer.ToString();
    }

}

