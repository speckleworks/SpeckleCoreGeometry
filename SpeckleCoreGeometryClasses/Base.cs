using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeckleCore;

namespace SpeckleCoreGeometryClasses
{

  [Serializable]
  public partial class SpeckleBoolean : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Boolean"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleNumber : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Number"; set => base.Type = value; }

    /// <summary>A number. Can be float, double, etc.</summary>
    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleString : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]

    public override string Type { get => "String"; set => base.Type = value; }

    /// <summary>A string.</summary>
    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleInterval : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Interval"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "start", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Start { get; set; }

    [Newtonsoft.Json.JsonProperty( "end", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? End { get; set; }
  }


  [Serializable]
  public partial class SpeckleInterval2d : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Interval2d"; set => base.Type = value; }

    /// <summary>U interval.</summary>
    [Newtonsoft.Json.JsonProperty( "U", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval U { get; set; }

    /// <summary>V interval.</summary>
    [Newtonsoft.Json.JsonProperty( "V", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval V { get; set; }

  }


  [Serializable]
  public partial class SpecklePoint : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Point"; set => base.Type = value; }

    /// <summary>An array containing the X, Y and Z coords of the point.</summary>
    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleVector : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Vector"; set => base.Type = value; }

    /// <summary>An array containing the X, Y and Z coords of the vector.</summary>
    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

  }


  [Serializable]
  public partial class SpecklePlane : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Plane"; set => base.Type = value; }

    /// <summary>The origin of the plane.</summary>
    [Newtonsoft.Json.JsonProperty( "origin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint Origin { get; set; }

    /// <summary>The normal of the plane.</summary>
    [Newtonsoft.Json.JsonProperty( "normal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleVector Normal { get; set; }

    /// <summary>The X axis of the plane.</summary>
    [Newtonsoft.Json.JsonProperty( "xdir", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleVector Xdir { get; set; }

    /// <summary>The Y axis of the plane.</summary>
    [Newtonsoft.Json.JsonProperty( "ydir", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleVector Ydir { get; set; }

  }


  [Serializable]
  public partial class SpeckleCircle : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Circle"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "radius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Radius { get; set; }

    [Obsolete( "Will be deprecated. Use this circle's plane origin to get its center." )]
    [Newtonsoft.Json.JsonProperty( "center", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint Center { get { return Plane?.Origin; } }

    [Obsolete( "Will be deprecated. Use this circle's plane normal." )]
    [Newtonsoft.Json.JsonProperty( "normal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleVector Normal { get { return Plane?.Normal; } }

    [Newtonsoft.Json.JsonProperty( "plane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpeckleArc : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Arc"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "radius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Radius { get; set; }

    [Newtonsoft.Json.JsonProperty( "startAngle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? StartAngle { get; set; }

    [Newtonsoft.Json.JsonProperty( "endAngle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? EndAngle { get; set; }

    [Newtonsoft.Json.JsonProperty( "angleRadians", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? AngleRadians { get; set; }

    [Newtonsoft.Json.JsonProperty( "plane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }
  }


  [Serializable]
  public partial class SpeckleEllipse : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Ellipse"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "firstRadius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? FirstRadius { get; set; }

    [Newtonsoft.Json.JsonProperty( "secondRadius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? SecondRadius { get; set; }

    [Newtonsoft.Json.JsonProperty( "plane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpecklePolycurve : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Polycurve"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "segments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<SpeckleObject> Segments { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    [Newtonsoft.Json.JsonProperty( "closed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool Closed { get; set; }
  }


  [Serializable]
  public partial class SpeckleBox : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Box"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "basePlane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane BasePlane { get; set; }

    [Newtonsoft.Json.JsonProperty( "xSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval XSize { get; set; }

    [Newtonsoft.Json.JsonProperty( "ySize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval YSize { get; set; }

    [Newtonsoft.Json.JsonProperty( "zSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval ZSize { get; set; }

  }


  [Serializable]
  public partial class SpeckleLine : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Line"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpecklePolyline : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Polyline"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    [Newtonsoft.Json.JsonProperty( "closed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool Closed { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpeckleCurve : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Curve"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "degree", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public int Degree { get; set; }

    [Newtonsoft.Json.JsonProperty( "periodic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool Periodic { get; set; }

    [Newtonsoft.Json.JsonProperty( "rational", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool Rational { get; set; }

    [Newtonsoft.Json.JsonProperty( "points", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Points { get; set; }

    [Newtonsoft.Json.JsonProperty( "weights", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Weights { get; set; }

    [Newtonsoft.Json.JsonProperty( "knots", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Knots { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    [Newtonsoft.Json.JsonProperty( "displayValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePolyline DisplayValue { get; set; }

    [Newtonsoft.Json.JsonProperty( "closed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool Closed { get; set; }

  }


  [Serializable]
  public partial class SpeckleMesh : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Mesh"; set => base.Type = value; }

    /// <summary>The mesh's vertices array, in a flat array (ie, `x1, y1, z1, x2, y2, ...`)</summary>
    [Newtonsoft.Json.JsonProperty( "vertices", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Vertices { get; set; }

    /// <summary>The faces array.</summary>
    [Newtonsoft.Json.JsonProperty( "faces", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<int> Faces { get; set; }

    /// <summary>If any, the colours per vertex.</summary>
    [Newtonsoft.Json.JsonProperty( "colors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<int> Colors { get; set; }

    /// <summary>If any, the colours per vertex.</summary>
    [Newtonsoft.Json.JsonProperty( "textureCoordinates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> TextureCoordinates { get; set; }

  }


  [Serializable]
  public partial class SpeckleBrep : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Brep"; set => base.Type = value; }

    /// <summary>The brep's raw (serialisation) data.</summary>
    [Newtonsoft.Json.JsonProperty( "rawData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public object RawData { get; set; }

    /// <summary>A short prefix of where the base64 comes from.</summary>
    [Newtonsoft.Json.JsonProperty( "provenance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Provenance { get; set; }

    /// <summary>Contains a speckle mesh representation of this brep.</summary>
    [Newtonsoft.Json.JsonProperty( "displayValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleMesh DisplayValue { get; set; }

  }


  [Serializable]
  public partial class SpeckleExtrusion : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Extrusion"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "capped", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Capped { get; set; }

    [Newtonsoft.Json.JsonProperty( "profile", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleObject Profile { get; set; }

    [Newtonsoft.Json.JsonProperty( "pathStart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint PathStart { get; set; }

    [Newtonsoft.Json.JsonProperty( "pathEnd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint PathEnd { get; set; }

    [Newtonsoft.Json.JsonProperty( "pathCurve", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleObject PathCurve { get; set; }

    [Newtonsoft.Json.JsonProperty( "pathTangent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleObject PathTangent { get; set; }

    [Newtonsoft.Json.JsonProperty( "profileTransformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public Object ProfileTransformation { get; set; }

    [Newtonsoft.Json.JsonProperty( "profiles", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<SpeckleObject> Profiles { get; set; }

    [Newtonsoft.Json.JsonProperty( "length", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Length;
  }


  [Serializable]
  public partial class SpeckleAnnotation : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Annotation"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "text", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Text { get; set; }

    [Newtonsoft.Json.JsonProperty( "textHeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? TextHeight { get; set; }

    [Newtonsoft.Json.JsonProperty( "fontName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string FontName { get; set; }

    [Newtonsoft.Json.JsonProperty( "bold", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Bold { get; set; }

    [Newtonsoft.Json.JsonProperty( "italic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Italic { get; set; }

    [Newtonsoft.Json.JsonProperty( "location", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint Location { get; set; }

    [Newtonsoft.Json.JsonProperty( "plane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

  }


  [Serializable]
  public partial class SpeckleBlock : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get => "Block"; set => base.Type = value; }

    [Newtonsoft.Json.JsonProperty( "description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Description { get; set; }

    [Newtonsoft.Json.JsonProperty( "objects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<SpeckleObject> Objects { get; set; }

  }
}
