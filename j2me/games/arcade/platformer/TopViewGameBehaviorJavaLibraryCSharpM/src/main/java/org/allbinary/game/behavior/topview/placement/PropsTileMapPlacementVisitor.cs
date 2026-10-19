/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TileLayer = org.mapeditor.core.TileLayer;
using TiledMap = org.mapeditor.core.TiledMap;

namespace org.allbinary.game.behavior.topview.placement;

public class PropsTileMapPlacementVisitor : TileMapPlacementVisitor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly MyRandomFactory randomFactory = MyRandomFactory.getInstance();
    public override void visit(TiledMap lastMap, int[][] mapData)
    {
        int layerIndex = 0;
        TileLayer tileLayer = (((TileLayer) lastMap.getLayer(layerIndex)));
        int[][] mapArray = tileLayer.getMapArray();
        int size = mapData.Length;
        int size2 = mapData[0].Length;
        for (int index = 0; index < size; index++) {
            for (int index2 = 0; index2 < size2; index2++) {
                if (mapArray[index][index2] == 14) {
                } else {
                    this.visit2(mapArray, mapData, index, index2);
                }
                if (index % 7 == 0) {
                    if (mapArray[index][index2] == 19) {
                        int randomInt = this.randomFactory.getAbsoluteNextIntAllowZero(3);
                        if (randomInt == 0) {
                            mapData[index][index2] = 1;
                        } else if (randomInt == 1) {
                            mapData[index][index2] = 81;
                        } else if (randomInt == 2) {
                            mapData[index][index2] = 97;
                        }
                    } else if (mapArray[index][index2] == 17) {
                        int randomInt = this.randomFactory.getAbsoluteNextIntAllowZero(3);
                        if (randomInt == 0) {
                            mapData[index][index2] = 17;
                        } else if (randomInt == 1) {
                            mapData[index][index2] = 81;
                        } else if (randomInt == 2) {
                            mapData[index][index2] = 97;
                        }
                    }
                }
                if (index2 % 7 == 0) {
                    if (mapArray[index][index2] == 34) {
                        int randomInt = this.randomFactory.getAbsoluteNextIntAllowZero(4);
                        if (randomInt == 0) {
                            mapData[index][index2] = 33;
                        } else if (randomInt == 1) {
                            mapData[index][index2] = 65;
                        } else if (randomInt == 2) {
                            mapData[index][index2] = 81;
                        } else if (randomInt == 3) {
                            mapData[index][index2] = 97;
                        }
                    }
                }
            }
        }
    }

    public virtual void visit2(int[][] mapArray, int[][] mapData, int index, int index2)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        int countX = 0;
        int countY = 0;
        int index3 = index - 1;
        for (int index4 = index2 - 1; index4 > 0; index4--) {
            index3--;
            if (index3 < 0 || index4 < 0) {
                return;
            }
            if (mapArray[index3][index4] != 14 || mapData[index3][index4] != 0) {
                if (countX > 10 && countY > 10) {
                    for (int index5 = index3 + 1; index5 < index - 1; index5++) {
                        for (int index6 = index4 + 1; index6 < index2 - 1; index6++) {
                            if (mapArray[index5][index6] != 14 || mapData[index5][index6] != 0) {
                                return;
                            }
                        }
                    }
                    int x = index - (countX / 2);
                    int y = index2 - (countY / 2);
                    if (x >= 0 && y >= 0 && x < mapData.Length && y < mapData[0].Length) {
                    }
                }
                return;
            }
            countY++;
            countX++;
        }
    }

}

