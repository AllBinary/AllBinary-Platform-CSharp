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
using PointFactory = org.allbinary.graphics.PointFactory;
using RelativeRelationship = org.allbinary.graphics.RelativeRelationship;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using RelativeLayerRelationship = org.allbinary.layer.relationship.RelativeLayerRelationship;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.resource;

public class FeaturedResourceRelativeRelationshipFactory : FeaturedResourceFactory
{
    private static FeaturedResourceRelativeRelationshipFactory INSTANCE = new FeaturedResourceRelativeRelationshipFactory();
    private FeaturedResourceRelativeRelationshipFactory()
    {
    }

    public static FeaturedResourceRelativeRelationshipFactory getInstance()
    {
        return FeaturedResourceRelativeRelationshipFactory.INSTANCE;
    }

    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    // throws Exception
    public virtual BasicArrayList getRelativeRelationshipList(string resource, AllBinaryLayer layer)
    {
        BasicArrayList featureReleaseList = this.getList();
        int size = this.getList().size();
        for (int index = 0; index < size; index++) {
            ResourceRelativeRelationshipFactoryInterface featureInterface = ((ResourceRelativeRelationshipFactoryInterface) featureReleaseList.objectArray[index]);
            if (featureInterface.isFeature()) {
                BasicArrayList list = featureInterface.getResourceRelativeRelationshipList(resource);
                if (list != this.basicArrayListUtil.getImmutableInstance()) {
                    return this.duplicate(list, layer);
                }
            }
        }
        throw new Exception(new StringMaker().append("Not available for current feature selection or Resource: ").append(resource).ToString());
    }

    // throws Exception
    private BasicArrayList duplicate(BasicArrayList list, AllBinaryLayer layer)
    {
        PointFactory pointFactory = PointFactory.getInstance();
        BasicArrayList newList = new BasicArrayListD();
        int size = list.size();
        for (int index = 0; index < size; index++) {
            RelativeRelationship relativeRelationship = ((RelativeRelationship) list.objectArray[index]);
            newList.add(new RelativeLayerRelationship(layer, pointFactory.createXY(relativeRelationship.getX(), relativeRelationship.getY()), BasicArrayListUtil.getInstance().getImmutableInstance()));
        }
        return newList;
    }

}

