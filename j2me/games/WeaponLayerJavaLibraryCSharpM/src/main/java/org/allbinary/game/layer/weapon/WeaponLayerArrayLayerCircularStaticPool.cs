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
using System.Runtime.CompilerServices;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.game.layer.weapon;

public class WeaponLayerArrayLayerCircularStaticPool
{
    private static readonly WeaponLayerArrayLayerCircularStaticPool instance = new WeaponLayerArrayLayerCircularStaticPool();
    public static WeaponLayerArrayLayerCircularStaticPool getInstance()
    {
        return WeaponLayerArrayLayerCircularStaticPool.instance;
    }

    private readonly int MAX = 5;
    private CircularIndexUtil circularIndexUtil;
    private object[][][] ALL_WEAPONLAYER_ARRAY = new object[4][][];
    public virtual void init()
    {
        object[][] WEAPONLAYER_ARRAY = new object[this.MAX * 2][];
        object[][] TWO_WEAPONLAYER_ARRAY = new object[this.MAX][];
        object[][] THREE_WEAPONLAYER_ARRAY = new object[this.MAX][];
        for (int index = 0; index < this.MAX; index++) {
            WEAPONLAYER_ARRAY[index] = new object[1];
            TWO_WEAPONLAYER_ARRAY[index] = new object[2];
            THREE_WEAPONLAYER_ARRAY[index] = new object[3];
        }
        this.ALL_WEAPONLAYER_ARRAY[1] = WEAPONLAYER_ARRAY;
        this.ALL_WEAPONLAYER_ARRAY[2] = TWO_WEAPONLAYER_ARRAY;
        this.ALL_WEAPONLAYER_ARRAY[3] = THREE_WEAPONLAYER_ARRAY;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual WeaponLayer[] getInstanceArray(int size)
    {
        WeaponLayer[] weaponLayerArray = ((WeaponLayer[]) this.ALL_WEAPONLAYER_ARRAY[size][this.circularIndexUtil.getIndex()]);
        this.circularIndexUtil.next();
        return weaponLayerArray;
    }

    public WeaponLayerArrayLayerCircularStaticPool()
    {
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.MAX);
    }

}

