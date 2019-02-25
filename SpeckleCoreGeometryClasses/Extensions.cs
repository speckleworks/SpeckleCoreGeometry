using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeckleCore;

namespace SpeckleCoreGeometryClasses
{
  public partial class SpeckleBoolean
  {
    public SpeckleBoolean( ) { }

    public SpeckleBoolean( bool value, Dictionary<string, object> properties = null )
    {
      this.Value = value;
      this.Properties = properties;

      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += this.Value.ToString();
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpeckleNumber
  {
    public SpeckleNumber( ) { }

    public SpeckleNumber( double value, Dictionary<string, object> properties = null )
    {
      this.Value = value;
      this.Properties = properties;

      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += this.Value.ToString();
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

    public static implicit operator double? ( SpeckleNumber n )
    {
      return n.Value;
    }

    public static implicit operator SpeckleNumber( double n )
    {
      return new SpeckleNumber( n );
    }
  }

  public partial class SpeckleString
  {
    public SpeckleString( ) { }

    public SpeckleString( string value, Dictionary<string, object> properties = null )
    {
      this.Value = value;
      this.Properties = properties;

      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

    public static implicit operator string( SpeckleString s )
    {
      return s.Value;
    }

    public static implicit operator SpeckleString( string s )
    {
      return new SpeckleString( s );
    }
  }

  public partial class SpeckleInterval
  {
    public SpeckleInterval( ) { }

    public SpeckleInterval( double start, double end, Dictionary<string, object> properties = null )
    {
      this.Start = start;
      this.End = end;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Start *= factor;
      this.End *= factor;

      this.Properties = ScaleProperties( this.Properties, factor );
      this.GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Start + End );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleInterval2d
  {
    public SpeckleInterval2d( ) { }

    public SpeckleInterval2d( SpeckleInterval U, SpeckleInterval V, Dictionary<string, object> properties = null )
    {
      this.U = U;
      this.V = V;
      this.Properties = properties;

      GenerateHash();
    }

    public SpeckleInterval2d( double start_u, double end_u, double start_v, double end_v, Dictionary<string, object> properties = null )
    {
      this.U = new SpeckleInterval( start_u, end_u );
      this.V = new SpeckleInterval( start_v, end_v );
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.U.Scale( factor );
      this.V.Scale( factor );

      this.Properties = ScaleProperties( this.Properties, factor );
      this.GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( U.GeometryHash + V.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpecklePoint
  {
    public SpecklePoint( ) { }

    public SpecklePoint( double x, double y, double z = 0, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Value = new List<double>() { x, y, z };
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Value.Count; i++ ) Value[ i ] *= factor;

      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleVector
  {
    public SpeckleVector( ) { }

    public SpeckleVector( double x, double y, double z = 0, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Value = new List<double>() { x, y, z };
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Value.Count; i++ ) Value[ i ] *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpecklePlane
  {
    public SpecklePlane( ) { }

    public SpecklePlane( SpecklePoint origin, SpeckleVector normal, SpeckleVector XDir, SpeckleVector YDir, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Origin = origin;
      this.Normal = normal;
      this.Xdir = XDir;
      this.Ydir = YDir;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Origin.Scale( factor );
      this.Normal.Scale( factor );
      this.Xdir.Scale( factor );
      this.Ydir.Scale( factor );

      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Origin.GeometryHash + Normal.GeometryHash + Xdir.GeometryHash + Ydir.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleLine
  {
    public SpeckleLine( ) { }

    public SpeckleLine( IEnumerable<double> coordinatesArray, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Value = coordinatesArray.ToList();
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Value.Count; i++ ) Value[ i ] *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleCircle
  {
    public SpeckleCircle( ) { }

    public SpeckleCircle( SpecklePlane plane, double radius, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Plane = plane;
      this.Radius = radius;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Plane.Scale( factor );
      this.Radius *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Plane.GeometryHash + Radius );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleArc
  {
    public SpeckleArc( ) { }

    public SpeckleArc( SpecklePlane plane, double radius, double startAngle, double endAngle, double angleRadians, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Plane = plane;
      this.Radius = radius;
      this.StartAngle = startAngle;
      this.EndAngle = endAngle;
      this.AngleRadians = angleRadians;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Radius *= factor;
      this.Plane.Scale( factor );
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Plane.GeometryHash + Radius + StartAngle + EndAngle );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleEllipse
  {
    public SpeckleEllipse( ) { }

    public SpeckleEllipse( SpecklePlane plane, double radius1, double radius2, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Plane = plane;
      this.FirstRadius = radius1;
      this.SecondRadius = radius2;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Plane.Scale( factor );
      this.FirstRadius *= factor; this.SecondRadius *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Plane.GeometryHash + FirstRadius + SecondRadius );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleBox
  {
    public SpeckleBox( ) { }

    public SpeckleBox( SpecklePlane basePlane, SpeckleInterval xSize, SpeckleInterval ySize, SpeckleInterval zSize, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.BasePlane = basePlane;
      this.XSize = xSize;
      this.YSize = ySize;
      this.ZSize = zSize;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.BasePlane.Scale( factor );
      this.XSize.Scale( factor );
      this.YSize.Scale( factor );
      this.ZSize.Scale( factor );
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( BasePlane.ToJson() + XSize.ToJson() + YSize.ToJson() + ZSize.ToJson() );
      this.Hash = GetMd5FromObject( this );
    }

  }

  public partial class SpecklePolyline
  {
    public SpecklePolyline( ) { }

    public SpecklePolyline( IEnumerable<double> coordinatesArray, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Value = coordinatesArray.ToList();
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Value.Count; i++ ) Value[ i ] *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpecklePolycurve
  {
    public SpecklePolycurve( ) { }

    public override void Scale( double factor )
    {
      foreach ( var segment in this.Segments )
      {
        var scaleMethod = segment.GetType().GetMethod( "Scale" );
        scaleMethod.Invoke( segment, new object[ ] { factor } );
      }
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Segments.Select( obj => obj.Hash ).ToArray() );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleCurve
  {
    public SpeckleCurve( ) { }

    public SpeckleCurve( SpecklePolyline poly, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.DisplayValue = poly;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Points.Count; i++ ) Points[ i ] *= factor;
      this.DisplayValue.Scale( factor );
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.DisplayValue.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpeckleMesh
  {
    public SpeckleMesh( ) { }

    public SpeckleMesh( double[ ] vertices, int[ ] faces, int[ ] colors, double[ ] texture_coords, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Vertices = vertices.ToList();
      this.Faces = faces.ToList();
      this.Colors = colors.ToList();
      this.ApplicationId = applicationId;

      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Vertices.Count; i++ ) Vertices[ i ] *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleBrep
  {
    public SpeckleBrep( ) { }

    public SpeckleBrep( object rawData, string provenance, SpeckleMesh displayValue, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.RawData = rawData;
      this.Provenance = provenance;
      this.DisplayValue = displayValue;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.DisplayValue.Scale( factor );
      this.Properties = ScaleProperties( this.Properties, factor );

      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.DisplayValue.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpeckleExtrusion
  {
    public SpeckleExtrusion( ) { }

    public SpeckleExtrusion( SpeckleObject profile, double length, bool capped, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Profile = profile;
      this.Length = length;
      this.Capped = capped;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Length *= factor;
      switch ( this.Profile )
      {
        case SpeckleCurve c:
          c.Scale( factor );
          break;
        case SpecklePolycurve p:
          p.Scale( factor );
          break;
        case SpecklePolyline p:
          p.Scale( factor );
          break;
        case SpeckleCircle c:
          c.Scale( factor );
          break;
        case SpeckleArc a:
          a.Scale( factor );
          break;
        case SpeckleEllipse e:
          e.Scale( factor );
          break;
        case SpeckleLine l:
          l.Scale( factor );
          break;
        default:
          break;
      }

      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Profile.GeometryHash + Length + Capped );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleAnnotation : SpeckleObject
  {
    public SpeckleAnnotation( ) { }

    public SpeckleAnnotation( string text, double textHeight, string fontName, bool bold, bool italic, SpecklePlane plane, SpecklePoint location, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Text = text;
      this.TextHeight = textHeight;
      this.FontName = fontName;
      this.Bold = bold;
      this.Italic = italic;
      this.Plane = plane;
      this.Location = location;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Plane.Scale( factor );
      this.Location.Scale( factor );
      this.TextHeight *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

}
