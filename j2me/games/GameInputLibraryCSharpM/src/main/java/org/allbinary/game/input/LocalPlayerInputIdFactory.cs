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
using AnalogLocationInputFactory = org.allbinary.game.input.analog.AnalogLocationInputFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.game.input;

public class LocalPlayerInputIdFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly LocalPlayerInputIdFactory instance = new LocalPlayerInputIdFactory();
    public readonly int MAX_NUMBER_OF_PLAYERS = 6;
    private readonly int MAX_FAST_DEVICEID = 65;
    private readonly int[] deviceIdToplayerId;
    private readonly int[] playerIdToDeviceId;
    private readonly bool[] playersInPlay;
    private int totalDevicesMapped = 0;
    private LocalPlayerInputIdFactory()
    {
        this.deviceIdToplayerId = new int[this.MAX_FAST_DEVICEID];
        this.playerIdToDeviceId = new int[this.MAX_NUMBER_OF_PLAYERS];
        this.playersInPlay = new bool[this.MAX_NUMBER_OF_PLAYERS];
        for (int index = this.deviceIdToplayerId.Length - 1; index >= 0; index--) {
            this.deviceIdToplayerId[index] = -1;
        }
    }

    public static LocalPlayerInputIdFactory getInstance()
    {
        return LocalPlayerInputIdFactory.instance;
    }

    public virtual int getDeviceId(int playerInputId)
    {
        return this.playerIdToDeviceId[playerInputId];
    }

    public virtual int getPlayerForDevice(int deviceId)
    {
        int index = 0;
        if (deviceId < this.MAX_FAST_DEVICEID) {
            int playerInputId = this.deviceIdToplayerId[deviceId];
            if (playerInputId != -1) {
                return playerInputId;
            }
        } else {
            for (index = this.totalDevicesMapped - 1; index >= 0; index--) {
                if (this.playerIdToDeviceId[index] == deviceId) {
                    return index;
                }
            }
        }
        index = this.totalDevicesMapped;
        if (deviceId < this.MAX_FAST_DEVICEID) {
            this.deviceIdToplayerId[deviceId] = index;
        } else {
            this.logUtil.putF(new StringMaker().append("Added DeviceId: ").appendint(deviceId).append(" beyond fast Id list").ToString(), this, "getPlayerForDevice");
        }
        this.playerIdToDeviceId[index] = deviceId;
        AnalogLocationInputFactory.getInstance().addPlayer(this.totalDevicesMapped);
        this.totalDevicesMapped++;
        this.logUtil.putF(new StringMaker().append("Added DeviceId: ").appendint(deviceId).append(" at: ").appendint(index).append(" Total: ").appendint(this.totalDevicesMapped).ToString(), this, "getPlayerForDevice");
        return index;
    }

    public virtual int getTotalDevicesInPlay()
    {
        int total = 0;
        for (int index = this.totalDevicesMapped - 1; index >= 0; index--) {
            if (this.playersInPlay[index] == true) {
                total++;
            }
        }
        return total;
    }

    public virtual bool isPlayerInPlay(int playerInputId)
    {
        return this.playersInPlay[playerInputId];
    }

    public virtual void setPlayerInPlay(int playerInputId)
    {
        this.logUtil.putF(new StringMaker().append("Setting PlayerInPlay with playerInputId: ").appendint(playerInputId).ToString(), this, "setPlayerInPlay");
        this.playersInPlay[playerInputId] = true;
    }

    public virtual void setPlayerOutOfPlay(int playerInputId)
    {
        this.logUtil.putF(new StringMaker().append("Setting PlayerOutOfPlay with playerInputId: ").appendint(playerInputId).ToString(), this, "setPlayerOutOfPlay");
        this.playersInPlay[playerInputId] = false;
    }

    public virtual bool[] getPlayersInPlay()
    {
        return this.playersInPlay;
    }

}

