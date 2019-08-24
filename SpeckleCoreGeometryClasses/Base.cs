using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeckleCore;
using Newtonsoft.Json;

namespace SpeckleCoreGeometryClasses
{

  /// <summary>
  /// TODO
  /// </summary>
  public interface ICurve { }

  [Serializable]
  public partial class SpeckleBoolean : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Boolean"; set => base.Type = value; }

    [JsonProperty( "value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool? Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleNumber : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Number"; set => base.Type = value; }

    /// <summary>A number. Can be float, double, etc.</summary>
    [JsonProperty( "value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleString : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]

    public override string Type { get => "String"; set => base.Type = value; }

    /// <summary>A string.</summary>
    [JsonProperty( "value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public string Value { get; set; }

  }

  [Serializable]
  public partial class SpeckleInterval : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Interval"; set => base.Type = value; }

    [JsonProperty( "start", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? Start { get; set; }

    [JsonProperty( "end", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? End { get; set; }
  }


  [Serializable]
  public partial class SpeckleInterval2d : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Interval2d"; set => base.Type = value; }

    /// <summary>U interval.</summary>
    [JsonProperty( "U", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval U { get; set; }

    /// <summary>V interval.</summary>
    [JsonProperty( "V", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval V { get; set; }

  }


  [Serializable]
  public partial class SpecklePoint : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Point"; set => base.Type = value; }

    /// <summary>An array containing the X, Y and Z coords of the point.</summary>
    [JsonProperty( "value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleVector : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Vector"; set => base.Type = value; }

    /// <summary>An array containing the X, Y and Z coords of the vector.</summary>
    [JsonProperty( "value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

  }


  [Serializable]
  public partial class SpecklePlane : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Plane"; set => base.Type = value; }

    /// <summary>The origin of the plane.</summary>
    [JsonProperty( "origin", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePoint Origin { get; set; }

    /// <summary>The normal of the plane.</summary>
    [JsonProperty( "normal", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleVector Normal { get; set; }

    /// <summary>The X axis of the plane.</summary>
    [JsonProperty( "xdir", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleVector Xdir { get; set; }

    /// <summary>The Y axis of the plane.</summary>
    [JsonProperty( "ydir", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleVector Ydir { get; set; }

  }


  [Serializable]
  public partial class SpeckleCircle : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Circle"; set => base.Type = value; }

    [JsonProperty( "radius", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? Radius { get; set; }

    [Obsolete( "Will be deprecated. Use this circle's plane origin to get its center." )]
    [JsonProperty( "center", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePoint Center { get { return Plane?.Origin; } }

    [Obsolete( "Will be deprecated. Use this circle's plane normal." )]
    [JsonProperty( "normal", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleVector Normal { get { return Plane?.Normal; } }

    [JsonProperty( "plane", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [JsonProperty( "domain", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpeckleArc : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Arc"; set => base.Type = value; }

    [JsonProperty( "radius", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? Radius { get; set; }

    [JsonProperty( "startAngle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? StartAngle { get; set; }

    [JsonProperty( "endAngle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? EndAngle { get; set; }

    [JsonProperty( "angleRadians", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? AngleRadians { get; set; }

    [JsonProperty( "plane", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [JsonProperty( "domain", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    [JsonProperty( "startPoint", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePoint StartPoint { get; set; }

    [JsonProperty( "midPoint", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePoint MidPoint { get; set; }

    [JsonProperty( "endPoint", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePoint EndPoint { get; set; }
  }


  [Serializable]
  public partial class SpeckleEllipse : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Ellipse"; set => base.Type = value; }

    [JsonProperty( "firstRadius", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? FirstRadius { get; set; }

    [JsonProperty( "secondRadius", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? SecondRadius { get; set; }

    [JsonProperty( "plane", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [JsonProperty( "domain", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpecklePolycurve : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Polycurve"; set => base.Type = value; }

    [JsonProperty( "segments", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<SpeckleObject> Segments { get; set; }

    [JsonProperty( "domain", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    [JsonProperty( "closed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool Closed { get; set; }
  }


  [Serializable]
  public partial class SpeckleBox : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Box"; set => base.Type = value; }

    [JsonProperty( "basePlane", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePlane BasePlane { get; set; }

    [JsonProperty( "xSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval XSize { get; set; }

    [JsonProperty( "ySize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval YSize { get; set; }

    [JsonProperty( "zSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval ZSize { get; set; }

  }


  [Serializable]
  public partial class SpeckleLine : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Line"; set => base.Type = value; }

    [JsonProperty( "value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    [JsonProperty( "domain", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpecklePolyline : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Polyline"; set => base.Type = value; }

    [JsonProperty( "value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    [JsonProperty( "closed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool Closed { get; set; }

    [JsonProperty( "domain", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpeckleCurve : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Curve"; set => base.Type = value; }

    [JsonProperty( "degree", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public int Degree { get; set; }

    [JsonProperty( "periodic", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool Periodic { get; set; }

    [JsonProperty( "rational", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool Rational { get; set; }

    [JsonProperty( "points", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> Points { get; set; }

    [JsonProperty( "weights", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> Weights { get; set; }

    [JsonProperty( "knots", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> Knots { get; set; }

    [JsonProperty( "domain", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    [JsonProperty( "displayValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePolyline DisplayValue { get; set; }

    [JsonProperty( "closed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool Closed { get; set; }

  }


  [Serializable]
  public partial class SpeckleMesh : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Mesh"; set => base.Type = value; }

    /// <summary>The mesh's vertices array, in a flat array (ie, `x1, y1, z1, x2, y2, ...`)</summary>
    [JsonProperty( "vertices", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> Vertices { get; set; }

    /// <summary>The faces array.</summary>
    [JsonProperty( "faces", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<int> Faces { get; set; }

    /// <summary>If any, the colours per vertex.</summary>
    [JsonProperty( "colors", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<int> Colors { get; set; }

    /// <summary>If any, the colours per vertex.</summary>
    [JsonProperty( "textureCoordinates", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<double> TextureCoordinates { get; set; }

  }


  [Serializable]
  public partial class SpeckleBrep : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Brep"; set => base.Type = value; }

    /// <summary>The brep's raw (serialisation) data.</summary>
    [JsonProperty( "rawData", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public object RawData { get; set; }

    /// <summary>A short prefix of where the base64 comes from.</summary>
    [JsonProperty( "provenance", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public string Provenance { get; set; }

    /// <summary>Contains a speckle mesh representation of this brep.</summary>
    [JsonProperty( "displayValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleMesh DisplayValue { get; set; }

  }


  [Serializable]
  public partial class SpeckleExtrusion : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Extrusion"; set => base.Type = value; }

    [JsonProperty( "capped", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool? Capped { get; set; }

    [JsonProperty( "profile", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleObject Profile { get; set; }

    [JsonProperty( "pathStart", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePoint PathStart { get; set; }

    [JsonProperty( "pathEnd", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePoint PathEnd { get; set; }

    [JsonProperty( "pathCurve", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleObject PathCurve { get; set; }

    [JsonProperty( "pathTangent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpeckleObject PathTangent { get; set; }

    [JsonProperty( "profiles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<SpeckleObject> Profiles { get; set; }

    [JsonProperty( "length", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? Length;
  }


  [Serializable]
  public partial class SpeckleAnnotation : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Annotation"; set => base.Type = value; }

    [JsonProperty( "text", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public string Text { get; set; }

    [JsonProperty( "textHeight", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public double? TextHeight { get; set; }

    [JsonProperty( "fontName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public string FontName { get; set; }

    [JsonProperty( "bold", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool? Bold { get; set; }

    [JsonProperty( "italic", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public bool? Italic { get; set; }

    [JsonProperty( "location", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePoint Location { get; set; }

    [JsonProperty( "plane", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

  }


  [Serializable]
  public partial class SpeckleBlock : SpeckleObject
  {
    [JsonProperty( "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public override string Type { get => "Block"; set => base.Type = value; }

    [JsonProperty( "description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public string Description { get; set; }

    [JsonProperty( "objects", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore )]
    public List<SpeckleObject> Objects { get; set; }

  }
}
