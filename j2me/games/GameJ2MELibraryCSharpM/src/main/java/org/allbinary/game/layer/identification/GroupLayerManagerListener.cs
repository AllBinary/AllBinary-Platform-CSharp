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
using Group = org.allbinary.game.identification.Group;
using GroupInterfaceCompositeInterface = org.allbinary.game.identification.GroupInterfaceCompositeInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using LayerManagerEvent = org.allbinary.layer.@event.LayerManagerEvent;
using LayerManagerEventHandler = org.allbinary.layer.@event.LayerManagerEventHandler;
using LayerManagerEventListener = org.allbinary.layer.@event.LayerManagerEventListener;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.layer.identification;

public class GroupLayerManagerListener : LayerManagerEventListener
{
    private static GroupLayerManagerListener SINGLETON = new GroupLayerManagerListener();
    public static GroupLayerManagerListener getInstance()
    {
        return GroupLayerManagerListener.SINGLETON;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly BasicArrayList list = new BasicArrayListD();
    private GroupLayerManagerListener()
    {
        LayerManagerEventHandler.getInstance().addListener(this);
    }

    public virtual void clear()
    {
        BasicArrayList groupList = null;
        int size = this.list.size();
        for (int index = size - 1; index >= 0; index--) {
            groupList = ((BasicArrayList) this.list.objectArray[index]);
            groupList.clear();
        }
    }

    public virtual int getGroupSizeFromInterface(GroupInterfaceCompositeInterface groupInterfaceCompositeInterface)
    {
        Group[] groupInterfaceArray = groupInterfaceCompositeInterface.getGroupInterface();
        return this.getGroupSize(groupInterfaceArray[0]);
    }

    public virtual int getGroupSize(Group groupInterface)
    {
        int id = ((int) groupInterface.getGroupId());
        return this.getGroupSizeById(id);
    }

    public virtual BasicArrayList getList(Group groupInterface)
    {
        int id = ((int) groupInterface.getGroupId());
        return this.getListById(id);
    }

    private BasicArrayList getListById(int groupId)
    {
        BasicArrayList groupList = ((BasicArrayList) this.list.objectArray[groupId]);
        return groupList;
    }

    private int getGroupSizeById(int groupId)
    {
        BasicArrayList groupList = ((BasicArrayList) this.list.objectArray[groupId]);
        int size = groupList.size();
        return size;
    }

    public virtual bool areAllOtherGroupsEmpty(Group groupInterface)
    {
        int id = ((int) groupInterface.getGroupId());
        int size = this.list.size();
        for (int index = size - 1; index >= 0; index--) {
            if (id != index) {
                int groupSize = this.getGroupSizeById(index);
                if (groupSize != 0) {
                    this.logUtil.putF(new StringMaker().append("Group Size: ").appendint(groupSize).ToString(), this, "areAllOtherGroupsEmpty");
                    return false;
                }
            }
        }
        return true;
    }

    private bool isIdInList(int id, BasicArrayList excludeGroupList)
    {
        int size = excludeGroupList.size();
        Group[] groupInterfaceArray = null;
        Group groupInterface = null;
        int groupId = 0;
        for (int index = size - 1; index >= 0; index--) {
            groupInterfaceArray = ((Group[]) excludeGroupList.objectArray[index]);
            int size2 = groupInterfaceArray.Length;
            for (int index2 = 0; index2 < size2; index2++) {
                groupInterface = groupInterfaceArray[index2];
                groupId = ((int) groupInterface.getGroupId());
                if (groupId == id) {
                    return true;
                }
            }
        }
        return false;
    }

    public virtual bool areAllOtherGroupsLessThan(BasicArrayList excludeGroupList, int maxSize)
    {
        int size = this.list.size();
        for (int index = size - 1; index >= 0; index--) {
            if (!this.isIdInList(index, excludeGroupList)) {
                int groupSize = this.getGroupSizeById(index);
                if (groupSize >= maxSize) {
                    return false;
                }
            }
        }
        return true;
    }

    public virtual void init(int total)
    {
        while (this.list.size() <= total + 1) {
            this.list.add(new BasicArrayListD());
        }
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    // throws Exception
    public override void onCreateLayerManagerEvent(LayerManagerEvent layerManagerEvent)
    {
        AllBinaryLayer layerInterface = layerManagerEvent.getLayerInterface();
        Group[] groupInterfaceArray = layerInterface.getGroupInterface();
        int size = groupInterfaceArray.Length;
        int id = 0;
        BasicArrayList groupList = null;
        for (int index = 0; index < size; index++) {
            id = ((int) groupInterfaceArray[index].getGroupId());
            groupList = ((BasicArrayList) this.list.objectArray[id]);
            if (groupList == null) {
                this.logUtil.putF(new StringMaker().append("id: ").appendint(id).ToString(), this, "onCreateLayerManagerEvent");
            }
            if (!groupList.contains(layerInterface)) {
                groupList.add(layerInterface);
            } else {
            }
        }
    }

    // throws Exception
    public override void onDeleteLayerManagerEvent(LayerManagerEvent layerManagerEvent)
    {
        AllBinaryLayer layerInterface = layerManagerEvent.getLayerInterface();
        Group[] groupInterfaceArray = layerInterface.getGroupInterface();
        int size = groupInterfaceArray.Length;
        int id = 0;
        BasicArrayList groupList = null;
        for (int index = 0; index < size; index++) {
            id = ((int) groupInterfaceArray[index].getGroupId());
            groupList = ((BasicArrayList) this.list.objectArray[id]);
            groupList.remove(layerInterface);
        }
    }

    public virtual void log()
    {
        StringMaker stringBuffer = new StringMaker();
        string GROUP = "Group: ";
        string SPACE = CommonSeps.getInstance().SPACE;
        string TOTAL_LABEL = CommonLabels.getInstance().TOTAL_LABEL;
        int size = this.list.size();
        for (int index = size - 1; index >= 0; index--) {
            BasicArrayList groupList = ((BasicArrayList) this.list.objectArray[index]);
            stringBuffer.append(GROUP);
            stringBuffer.appendint(index);
            stringBuffer.append(SPACE);
            stringBuffer.append(TOTAL_LABEL);
            stringBuffer.appendint(groupList.size());
            stringBuffer.append(SPACE);
        }
        this.logUtil.putF(stringBuffer.ToString(), this, "log");
    }

}

