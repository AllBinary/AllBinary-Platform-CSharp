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
using Direction = org.allbinary.direction.Direction;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using CellPosition = org.allbinary.graphics.CellPosition;

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapDirectionUtil
{
    private static readonly GeographicMapDirectionUtil instance = new GeographicMapDirectionUtil();
    public static GeographicMapDirectionUtil getInstance()
    {
        return GeographicMapDirectionUtil.instance;
    }

    private GeographicMapDirectionUtil()
    {
    }

    private readonly string MESSAGE = "Cell Position should have been cached!!!";
    // throws Exception
    public virtual Direction getDirectionFromCellPositionToAdjacentCellPosition(GeographicMapCellPosition fromGeographicMapCellPosition, GeographicMapCellPosition toGeographicMapCellPosition)
    {
        int fromColumn = fromGeographicMapCellPosition.getColumn();
        int fromRow = fromGeographicMapCellPosition.getRow();
        int goColumn = toGeographicMapCellPosition.getColumn();
        int goRow = toGeographicMapCellPosition.getRow();
        DirectionFactory directionFactory = DirectionFactory.getInstance();
        if (fromColumn - 1 == goColumn) {
            return directionFactory.LEFT;
        } else if (fromColumn + 1 == goColumn) {
            return directionFactory.RIGHT;
        } else if (fromRow - 1 == goRow) {
            return directionFactory.UP;
        } else if (fromRow + 1 == goRow) {
            return directionFactory.DOWN;
        } else if (fromGeographicMapCellPosition == toGeographicMapCellPosition) {
            return directionFactory.NO_DIRECTION;
        } else if (fromRow == goRow && fromColumn == goColumn) {
            throw new Exception(this.MESSAGE);
        }
        return directionFactory.NOT_BORDERED_WITH;
    }

    // throws Exception
    public virtual Direction getEightDirectionFromCellPositionToAdjacentCellPosition(GeographicMapCellPosition fromGeographicMapCellPosition, GeographicMapCellPosition toGeographicMapCellPosition)
    {
        int fromColumn = fromGeographicMapCellPosition.getColumn();
        int fromRow = fromGeographicMapCellPosition.getRow();
        int goColumn = toGeographicMapCellPosition.getColumn();
        int goRow = toGeographicMapCellPosition.getRow();
        DirectionFactory directionFactory = DirectionFactory.getInstance();
        if (fromRow == goRow) {
            if (fromColumn - 1 == goColumn) {
                return directionFactory.LEFT;
            } else if (fromColumn + 1 == goColumn) {
                return directionFactory.RIGHT;
            }
        } else if (fromRow - 1 == goRow) {
            if (fromColumn == goColumn) {
                return directionFactory.UP;
            }
            if (fromColumn - 1 == goColumn) {
                return directionFactory.UP_LEFT;
            } else if (fromColumn + 1 == goColumn) {
                return directionFactory.UP_RIGHT;
            }
        } else if (fromRow + 1 == goRow) {
            if (fromColumn == goColumn) {
                return directionFactory.DOWN;
            }
            if (fromColumn - 1 == goColumn) {
                return directionFactory.DOWN_LEFT;
            } else if (fromColumn + 1 == goColumn) {
                return directionFactory.DOWN_RIGHT;
            }
        } else if (fromGeographicMapCellPosition == toGeographicMapCellPosition) {
            return directionFactory.NO_DIRECTION;
        } else if (fromRow == goRow && fromColumn == goColumn) {
            throw new Exception(this.MESSAGE);
        }
        return directionFactory.NOT_BORDERED_WITH;
    }

    // throws Exception
    public virtual Direction getDirectionFromCellPositionToCellPosition(GeographicMapCellPosition fromGeographicMapCellPosition, GeographicMapCellPosition toGeographicMapCellPosition)
    {
        int fromColumn = fromGeographicMapCellPosition.getColumn();
        int fromRow = fromGeographicMapCellPosition.getRow();
        int goColumn = toGeographicMapCellPosition.getColumn();
        int goRow = toGeographicMapCellPosition.getRow();
        DirectionFactory directionFactory = DirectionFactory.getInstance();
        if (fromColumn > goColumn) {
            return directionFactory.LEFT;
        } else if (fromColumn < goColumn) {
            return directionFactory.RIGHT;
        } else if (fromRow > goRow) {
            return directionFactory.UP;
        } else if (fromRow < goRow) {
            return directionFactory.DOWN;
        }
        StringMaker stringMaker = new StringMaker();
        string @string = stringMaker.append(CellPosition.toStringCellPosition(fromGeographicMapCellPosition)).append(" == ").append(CellPosition.toStringCellPosition(toGeographicMapCellPosition)).ToString();
        stringMaker.delete(0, stringMaker.length());
        throw new Exception(stringMaker.append("Error: ").append(@string).ToString());
    }

    private readonly string ERROR = "Error: ";
    private readonly string EQUAL = " == ";
    // throws Exception
    public virtual Direction getEightDirectionFromCellPositionToCellPosition(GeographicMapCellPosition fromGeographicMapCellPosition, GeographicMapCellPosition toGeographicMapCellPosition)
    {
        int fromColumn = fromGeographicMapCellPosition.getColumn();
        int fromRow = fromGeographicMapCellPosition.getRow();
        int goColumn = toGeographicMapCellPosition.getColumn();
        int goRow = toGeographicMapCellPosition.getRow();
        DirectionFactory directionFactory = DirectionFactory.getInstance();
        if (fromGeographicMapCellPosition == toGeographicMapCellPosition) {
            return directionFactory.NO_DIRECTION;
        } else if (fromRow == goRow) {
            if (fromColumn > goColumn) {
                return directionFactory.LEFT;
            } else if (fromColumn < goColumn) {
                return directionFactory.RIGHT;
            }
        } else if (fromRow > goRow) {
            if (fromColumn > goColumn) {
                return directionFactory.UP_LEFT;
            } else if (fromColumn < goColumn) {
                return directionFactory.UP_RIGHT;
            } else if (fromColumn == goColumn) {
                return directionFactory.UP;
            }
        } else if (fromRow < goRow) {
            if (fromColumn > goColumn) {
                return directionFactory.DOWN_LEFT;
            } else if (fromColumn < goColumn) {
                return directionFactory.DOWN_RIGHT;
            } else if (fromColumn == goColumn) {
                return directionFactory.DOWN;
            }
        }
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.ERROR);
        stringBuffer.append(CellPosition.toStringCellPosition(fromGeographicMapCellPosition));
        stringBuffer.append(this.EQUAL);
        stringBuffer.append(CellPosition.toStringCellPosition(toGeographicMapCellPosition));
        throw new Exception(stringBuffer.ToString());
    }

}

