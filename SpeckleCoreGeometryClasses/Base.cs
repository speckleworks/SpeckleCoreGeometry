extern alias SpeckleNewtonsoft;
using SNJ = SpeckleNewtonsoft.Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeckleCore;

namespace SpeckleCoreGeometryClasses
{

  [Serializable]
  public partial class SpeckleBoolean : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Boolean"; set => base.Type = value; }

    [SNJ.JsonProperty( "value", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool? Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleNumber : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Number"; set => base.Type = value; }

    /// <summary>A number. Can be float, double, etc.</summary>
    [SNJ.JsonProperty( "value", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleString : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]

    public override string Type { get => "String"; set => base.Type = value; }

    /// <summary>A string.</summary>
    [SNJ.JsonProperty( "value", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public string Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleInterval : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Interval"; set => base.Type = value; }

    [SNJ.JsonProperty( "start", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? Start { get; set; }

    [SNJ.JsonProperty( "end", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? End { get; set; }
  }


  [Serializable]
  public partial class SpeckleInterval2d : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Interval2d"; set => base.Type = value; }

    /// <summary>U interval.</summary>
    [SNJ.JsonProperty( "U", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval U { get; set; }

    /// <summary>V interval.</summary>
    [SNJ.JsonProperty( "V", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval V { get; set; }

  }


  [Serializable]
  public partial class SpecklePoint : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Point"; set => base.Type = value; }

    /// <summary>An array containing the X, Y and Z coords of the point.</summary>
    [SNJ.JsonProperty( "value", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

  }


  [Serializable]
  public partial class SpeckleVector : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Vector"; set => base.Type = value; }

    /// <summary>An array containing the X, Y and Z coords of the vector.</summary>
    [SNJ.JsonProperty( "value", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

  }


  [Serializable]
  public partial class SpecklePlane : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Plane"; set => base.Type = value; }

    /// <summary>The origin of the plane.</summary>
    [SNJ.JsonProperty( "origin", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePoint Origin { get; set; }

    /// <summary>The normal of the plane.</summary>
    [SNJ.JsonProperty( "normal", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleVector Normal { get; set; }

    /// <summary>The X axis of the plane.</summary>
    [SNJ.JsonProperty( "xdir", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleVector Xdir { get; set; }

    /// <summary>The Y axis of the plane.</summary>
    [SNJ.JsonProperty( "ydir", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleVector Ydir { get; set; }

  }


  [Serializable]
  public partial class SpeckleCircle : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Circle"; set => base.Type = value; }

    [SNJ.JsonProperty( "radius", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? Radius { get; set; }

    [Obsolete( "Will be deprecated. Use this circle's plane origin to get its center." )]
    [SNJ.JsonProperty( "center", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePoint Center { get { return Plane?.Origin; } }

    [Obsolete( "Will be deprecated. Use this circle's plane normal." )]
    [SNJ.JsonProperty( "normal", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleVector Normal { get { return Plane?.Normal; } }

    [SNJ.JsonProperty( "plane", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [SNJ.JsonProperty( "domain", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpeckleArc : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Arc"; set => base.Type = value; }

    [SNJ.JsonProperty( "radius", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? Radius { get; set; }

    [SNJ.JsonProperty( "startAngle", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? StartAngle { get; set; }

    [SNJ.JsonProperty( "endAngle", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? EndAngle { get; set; }

    [SNJ.JsonProperty( "angleRadians", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? AngleRadians { get; set; }

    [SNJ.JsonProperty( "plane", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [SNJ.JsonProperty( "domain", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }
  }


  [Serializable]
  public partial class SpeckleEllipse : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Ellipse"; set => base.Type = value; }

    [SNJ.JsonProperty( "firstRadius", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? FirstRadius { get; set; }

    [SNJ.JsonProperty( "secondRadius", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? SecondRadius { get; set; }

    [SNJ.JsonProperty( "plane", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [SNJ.JsonProperty( "domain", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpecklePolycurve : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Polycurve"; set => base.Type = value; }

    [SNJ.JsonProperty( "segments", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<SpeckleObject> Segments { get; set; }

    [SNJ.JsonProperty( "domain", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    [SNJ.JsonProperty( "closed", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool Closed { get; set; }
  }


  [Serializable]
  public partial class SpeckleBox : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Box"; set => base.Type = value; }

    [SNJ.JsonProperty( "basePlane", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePlane BasePlane { get; set; }

    [SNJ.JsonProperty( "xSize", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval XSize { get; set; }

    [SNJ.JsonProperty( "ySize", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval YSize { get; set; }

    [SNJ.JsonProperty( "zSize", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval ZSize { get; set; }

  }


  [Serializable]
  public partial class SpeckleLine : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Line"; set => base.Type = value; }

    [SNJ.JsonProperty( "value", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    [SNJ.JsonProperty( "domain", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpecklePolyline : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Polyline"; set => base.Type = value; }

    [SNJ.JsonProperty( "value", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    [SNJ.JsonProperty( "closed", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool Closed { get; set; }

    [SNJ.JsonProperty( "domain", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

  }


  [Serializable]
  public partial class SpeckleCurve : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Curve"; set => base.Type = value; }

    [SNJ.JsonProperty( "degree", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public int Degree { get; set; }

    [SNJ.JsonProperty( "periodic", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool Periodic { get; set; }

    [SNJ.JsonProperty( "rational", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool Rational { get; set; }

    [SNJ.JsonProperty( "points", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> Points { get; set; }

    [SNJ.JsonProperty( "weights", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> Weights { get; set; }

    [SNJ.JsonProperty( "knots", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> Knots { get; set; }

    [SNJ.JsonProperty( "domain", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    [SNJ.JsonProperty( "displayValue", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePolyline DisplayValue { get; set; }

    [SNJ.JsonProperty( "closed", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool Closed { get; set; }

  }


  [Serializable]
  public partial class SpeckleMesh : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Mesh"; set => base.Type = value; }

    /// <summary>The mesh's vertices array, in a flat array (ie, `x1, y1, z1, x2, y2, ...`)</summary>
    [SNJ.JsonProperty( "vertices", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> Vertices { get; set; }

    /// <summary>The faces array.</summary>
    [SNJ.JsonProperty( "faces", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<int> Faces { get; set; }

    /// <summary>If any, the colours per vertex.</summary>
    [SNJ.JsonProperty( "colors", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<int> Colors { get; set; }

    /// <summary>If any, the colours per vertex.</summary>
    [SNJ.JsonProperty( "textureCoordinates", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<double> TextureCoordinates { get; set; }

  }


  [Serializable]
  public partial class SpeckleBrep : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Brep"; set => base.Type = value; }

    /// <summary>The brep's raw (serialisation) data.</summary>
    [SNJ.JsonProperty( "rawData", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public object RawData { get; set; }

    /// <summary>A short prefix of where the base64 comes from.</summary>
    [SNJ.JsonProperty( "provenance", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public string Provenance { get; set; }

    /// <summary>Contains a speckle mesh representation of this brep.</summary>
    [SNJ.JsonProperty( "displayValue", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleMesh DisplayValue { get; set; }

  }


  [Serializable]
  public partial class SpeckleExtrusion : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Extrusion"; set => base.Type = value; }

    [SNJ.JsonProperty( "capped", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool? Capped { get; set; }

    [SNJ.JsonProperty( "profile", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleObject Profile { get; set; }

    [SNJ.JsonProperty( "pathStart", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePoint PathStart { get; set; }

    [SNJ.JsonProperty( "pathEnd", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePoint PathEnd { get; set; }

    [SNJ.JsonProperty( "pathCurve", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleObject PathCurve { get; set; }

    [SNJ.JsonProperty( "pathTangent", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpeckleObject PathTangent { get; set; }

    [SNJ.JsonProperty( "profiles", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<SpeckleObject> Profiles { get; set; }

    [SNJ.JsonProperty( "length", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? Length;
  }


  [Serializable]
  public partial class SpeckleAnnotation : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Annotation"; set => base.Type = value; }

    [SNJ.JsonProperty( "text", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public string Text { get; set; }

    [SNJ.JsonProperty( "textHeight", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public double? TextHeight { get; set; }

    [SNJ.JsonProperty( "fontName", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public string FontName { get; set; }

    [SNJ.JsonProperty( "bold", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool? Bold { get; set; }

    [SNJ.JsonProperty( "italic", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public bool? Italic { get; set; }

    [SNJ.JsonProperty( "location", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePoint Location { get; set; }

    [SNJ.JsonProperty( "plane", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

  }


  [Serializable]
  public partial class SpeckleBlock : SpeckleObject
  {
    [SNJ.JsonProperty( "type", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public override string Type { get => "Block"; set => base.Type = value; }

    [SNJ.JsonProperty( "description", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public string Description { get; set; }

    [SNJ.JsonProperty( "objects", Required = SNJ.Required.Default, NullValueHandling = SNJ.NullValueHandling.Ignore )]
    public List<SpeckleObject> Objects { get; set; }

  }
}
