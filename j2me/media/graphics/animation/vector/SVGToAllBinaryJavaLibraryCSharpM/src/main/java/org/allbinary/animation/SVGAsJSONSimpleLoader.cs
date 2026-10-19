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
using java.util;
using GraphicsStrings = org.allbinary.graphics.GraphicsStrings;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using JSONArray = org.json.me.JSONArray;
using JSONException = org.json.me.JSONException;
using JSONObject = org.json.me.JSONObject;

namespace org.allbinary.animation;

public class SVGAsJSONSimpleLoader
{
    private static readonly SVGAsJSONSimpleLoader instance = new SVGAsJSONSimpleLoader();
    public static SVGAsJSONSimpleLoader getInstance()
    {
        return SVGAsJSONSimpleLoader.instance;
    }

    private readonly GraphicsStrings graphicsStrings = GraphicsStrings.getInstance();
    private readonly ShapeTypeFactory shapeTypeFactory = ShapeTypeFactory.getInstance();
    private readonly string KEY_SVG = "svg";
    private readonly string KEY_X1 = "x1";
    private readonly string KEY_Y1 = "y1";
    private readonly string KEY_X2 = "x2";
    private readonly string KEY_Y2 = "y2";
    private readonly string KEY_CX = "cx";
    private readonly string KEY_CY = "cy";
    private readonly string KEY_R = "r";
    private readonly string KEY_X = PositionStrings.getInstance().X;
    private readonly string KEY_Y = PositionStrings.getInstance().Y;
    private readonly string ERROR_PARSE_SVG_JSON = "Unable to parse SVG JSON";
    private readonly string ERROR_MISSING_KEY_PREFIX = "Missing key: ";
    private readonly string ERROR_INVALID_NUMBER_PREFIX = "Invalid number for key: ";
    private readonly string ERROR_EXPECTED_OBJECT_PREFIX = "Expected object for: ";
    private readonly int[][] EMPTY_POINTS = PrimitiveIntUtil.getTwoDimensionalArrayInstance();
    private readonly int[] SHAPE_SEPARATOR = new int[] { 1000, 1000 };
    private readonly int CIRCLE_SEGMENTS = 16;
    // throws Exception
    public virtual int[][] load(string svgAsJson)
    {
        if (svgAsJson == null) {
            return EMPTY_POINTS;
        }
        try {
            JSONObject root = new JSONObject(svgAsJson);
            object svgValue = root.opt(KEY_SVG);
            JSONObject svg = (svgValue == null ? root : this.asObject(svgValue, KEY_SVG));
            BasicArrayList pointVector = new BasicArrayListD();
            Enumeration keys = svg.keys();
            while (keys.hasMoreElements()) {
                string key = ((string) keys.nextElement());
                object value = svg.opt(key);
                if (this.shapeTypeFactory.KEY_LINE.Equals(key)) {
                    this.addShapes(pointVector, value, this.shapeTypeFactory.LINE);
                } else if (this.shapeTypeFactory.Equals(key)) {
                    this.addShapes(pointVector, value, this.shapeTypeFactory.CIRCLE);
                } else if (this.shapeTypeFactory.KEY_RECT.Equals(key) || this.shapeTypeFactory.KEY_RECTANGLE.Equals(key)) {
                    this.addShapes(pointVector, value, this.shapeTypeFactory.RECTANGLE);
                }
            }
            return this.toPoints(pointVector);
        } catch (JSONException e) {
            throw new ArgumentException(ERROR_PARSE_SVG_JSON, e);
        }
    }

    // throws Exception
    private void addShapes(BasicArrayList pointVector, object value, ShapeType shapeType)
    {
        if (value is JSONArray) {
            JSONArray array = ((JSONArray) value);
            int size = array.length();
            for (int index = 0; index < size; index++) {
                this.addShape(pointVector, array.opt(index), shapeType);
            }
        } else {
            this.addShape(pointVector, value, shapeType);
        }
    }

    // throws Exception
    private void addShape(BasicArrayList pointVector, object value, ShapeType shapeType)
    {
        JSONObject shape = this.asObject(value, shapeType.getName());
        if (shapeType == this.shapeTypeFactory.LINE) {
            this.addLine(pointVector, shape);
        } else if (shapeType == this.shapeTypeFactory.CIRCLE) {
            this.addCircle(pointVector, shape);
        } else {
            this.addRectangle(pointVector, shape);
        }
    }

    // throws Exception
    private void addLine(BasicArrayList pointVector, JSONObject line)
    {
        this.addPoint(pointVector, this.readInt(line, KEY_X1), this.readInt(line, KEY_Y1));
        this.addPoint(pointVector, this.readInt(line, KEY_X2), this.readInt(line, KEY_Y2));
        this.addSeparator(pointVector);
    }

    // throws Exception
    private void addCircle(BasicArrayList pointVector, JSONObject circle)
    {
        int cx = this.readInt(circle, KEY_CX);
        int cy = this.readInt(circle, KEY_CY);
        int radius = this.readInt(circle, KEY_R);
        for (int index = 0; index <= CIRCLE_SEGMENTS; index++) {
            double angle = (Math.PI * 2.0d * index) / CIRCLE_SEGMENTS;
            int x = ((int) Math.Round(cx + (Math.Cos(angle) * radius)));
            int y = ((int) Math.Round(cy + (Math.Sin(angle) * radius)));
            this.addPoint(pointVector, x, y);
        }
        this.addSeparator(pointVector);
    }

    // throws Exception
    private void addRectangle(BasicArrayList pointVector, JSONObject rectangle)
    {
        int x = this.readInt(rectangle, KEY_X, 0);
        int y = this.readInt(rectangle, KEY_Y, 0);
        int width = this.readInt(rectangle, graphicsStrings.WIDTH);
        int height = this.readInt(rectangle, graphicsStrings.HEIGHT);
        this.addPoint(pointVector, x, y);
        this.addPoint(pointVector, x + width, y);
        this.addPoint(pointVector, x + width, y + height);
        this.addPoint(pointVector, x, y + height);
        this.addPoint(pointVector, x, y);
        this.addSeparator(pointVector);
    }

    private void addPoint(BasicArrayList pointVector, int x, int y)
    {
        pointVector.add(new int[] { x, y });
    }

    private void addSeparator(BasicArrayList pointVector)
    {
        pointVector.add(new int[] { SHAPE_SEPARATOR[0], SHAPE_SEPARATOR[1] });
    }

    // throws Exception
    private int readInt(JSONObject anyType, string key)
    {
        object value = anyType.get(key);
        if (value == null) {
            throw new ArgumentException(ERROR_MISSING_KEY_PREFIX + key);
        }
        return this.toInt(value, key);
    }

    private int readInt(JSONObject anyType, string key, int defaultValue)
    {
        try {
            if (anyType.has(key)) {
                object value = anyType.get(key);
                return this.toInt(value, key);
            }
        } catch (Exception e) {
            Console.WriteLine(e);
        }
        return defaultValue;
    }

    private int toInt(object value, string key)
    {
        if (value is Number) {
            return ((int) Math.Round(((double) (((Number) value)))));
        }
        if (value is string) {
            return ((int) Math.Round(double.Parse(((string) value))));
        }
        throw new ArgumentException(ERROR_INVALID_NUMBER_PREFIX + key);
    }

    private JSONObject asObject(object value, string name)
    {
        if (value is JSONObject) {
            return ((JSONObject) value);
        }
        throw new ArgumentException(ERROR_EXPECTED_OBJECT_PREFIX + name);
    }

    private int[][] toPoints(BasicArrayList pointVector)
    {
        if (pointVector.size() == 0) {
            return EMPTY_POINTS;
        }
        int[][] points = System.Linq.Enumerable.Range(0, pointVector.size()).Select(_ => new int[2]).ToArray();
        for (int index = 0; index < pointVector.size(); index++) {
            int[] point = ((int[]) pointVector.get(index));
            points[index] = point;
        }
        return points;
    }

    // throws Exception
    public static void main(string[] args)
    {
        string svgAsJson = "{\"svg\": {\n" + "    \"rect\": {\n" + "        \"width\": 20,\n" + "        \"fill\": \"#008c00\",\n" + "        \"height\": 20\n" + "    },\n" + "    \"xmlns\": \"http://www.w3.org/2000/svg\",\n" + "    \"width\": 20,\n" + "    \"height\": 20\n" + "}}\n";
        int[][] points = SVGAsJSONSimpleLoader.getInstance().load(svgAsJson);
        StringMaker stringBuilder = new StringMaker();
        int size = points.Length;
        for (int index = 0; index < size; index++) {
            int size2 = points[index].Length;
            for (int index2 = 0; index2 < size2; index2++) {
                stringBuilder.appendint(((int) points[index][index2]));
                stringBuilder.append(CommonSeps.getInstance().COMMA);
            }
        }
        Console.WriteLine(stringBuilder.ToString());
    }

}

