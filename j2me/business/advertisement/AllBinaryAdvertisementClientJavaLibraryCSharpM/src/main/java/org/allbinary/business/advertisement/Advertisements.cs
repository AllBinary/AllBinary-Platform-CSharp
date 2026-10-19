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
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using LockedUtil = org.allbinary.logic.system.security.licensing.LockedUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.advertisement;

public class Advertisements
{
    private readonly BasicArrayList bannerList = new BasicArrayListD();
    private readonly BasicArrayList pageList = new BasicArrayListD();
    public virtual void addPage(AdvertisementProcessorInterface advertisementProcessorInterface)
    {
        if (!this.pageList.contains(advertisementProcessorInterface)) {
            this.pageList.add(advertisementProcessorInterface);
        }
    }

    public virtual void startRandomPage()
    {
        int size = this.pageList.size();
        if (size > 0) {
            int random = this.myRandomFactory.getAbsoluteNextInt(size);
            AdvertisementProcessorInterface advertisementProcessorInterface = ((AdvertisementProcessorInterface) this.pageList.objectArray[random]);
            advertisementProcessorInterface.start();
        }
    }

    private readonly MyRandomFactory myRandomFactory = MyRandomFactory.getInstance();
    public virtual void processRandomPage()
    {
        if (LockedUtil.getInstance().isLocked()) {
            int size = this.pageList.size();
            if (size > 0) {
                int random = this.myRandomFactory.getAbsoluteNextInt(size);
                AdvertisementProcessorInterface advertisementProcessorInterface = ((AdvertisementProcessorInterface) this.pageList.objectArray[random]);
                advertisementProcessorInterface.process();
            }
        }
    }

    public virtual void stopAllPage()
    {
        for (int index = this.pageList.size(); --index >= 0; ) {
            AdvertisementProcessorInterface advertisementProcessorInterface = ((AdvertisementProcessorInterface) this.pageList.objectArray[index]);
            advertisementProcessorInterface.stop();
        }
    }

    public virtual void addBanner(AdvertisementProcessorInterface advertisementProcessorInterface)
    {
        if (!this.bannerList.contains(advertisementProcessorInterface)) {
            this.bannerList.add(advertisementProcessorInterface);
        }
    }

    public virtual void startAll()
    {
        for (int index = this.bannerList.size(); --index >= 0; ) {
            AdvertisementProcessorInterface advertisementProcessorInterface = ((AdvertisementProcessorInterface) this.bannerList.objectArray[index]);
            advertisementProcessorInterface.start();
        }
    }

    public virtual void stopAllBanner()
    {
        for (int index = this.bannerList.size(); --index >= 0; ) {
            AdvertisementProcessorInterface advertisementProcessorInterface = ((AdvertisementProcessorInterface) this.bannerList.objectArray[index]);
            advertisementProcessorInterface.stop();
        }
    }

    public virtual AdvertisementProcessorInterface getBanner(int index)
    {
        AdvertisementProcessorInterface advertisementProcessorInterface = ((AdvertisementProcessorInterface) this.bannerList.objectArray[index]);
        return advertisementProcessorInterface;
    }

    public virtual void stopAll()
    {
        this.stopAllBanner();
        this.stopAllPage();
    }

}

