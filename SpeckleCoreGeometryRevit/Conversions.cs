using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using SpeckleCore;
using SpeckleCoreGeometryClasses;

namespace SpeckleCoreGeometryRevit
{

  public class Initialiser : ISpeckleInitializer
  {
    public Initialiser() { }

    /// <summary>
    /// Revit doc will be injected in here by the revit plugin. 
    /// To create a similar kit, make sure you declare this property in your initialiser class. 
    /// </summary>
    public static UIApplication RevitApp { get; set; }

    /// <summary>
    /// Local revit state (existing objects coming from a bake) will be injected here.
    /// </summary>
    public static List<SpeckleStream> LocalRevitState { get; set; }

    /// <summary>
    /// Scale will be set here by each individual stream bake. 
    /// TODO: Potential race condition when we simulatenously start baking two or more streams that have different scales.
    /// </summary>
    public static double RevitScale { get; set; } = 3.2808399;
  }

  // TODO: 
  // Handle scale on ToSpeckleConversions
  public static partial class Conversions
  {
    static double Scale { get => Initialiser.RevitScale; }
    static Document Doc { get => Initialiser.RevitApp.ActiveUIDocument.Document; }

    public static XYZ ToNative( this SpecklePoint pt )
    {
      return new XYZ( pt.Value[ 0 ] * Scale, pt.Value[ 1 ] * Scale, pt.Value[ 2 ] * Scale );
    }

    public static SpecklePoint ToSpeckle( this XYZ pt )
    {
      return new SpecklePoint( pt.X / Scale, pt.Y / Scale, pt.Z / Scale );
    }

    public static XYZ ToNative( this SpeckleVector pt )
    {
      return new XYZ( pt.Value[ 0 ] * Scale, pt.Value[ 1 ] * Scale, pt.Value[ 2 ] * Scale );
    }

    public static Plane ToNative( this SpecklePlane plane )
    {
      return Plane.CreateByOriginAndBasis( plane.Origin.ToNative(), plane.Xdir.ToNative().Normalize(), plane.Ydir.ToNative().Normalize() );
    }

    public static SpecklePlane ToSpeckle( this Plane plane )
    {
      var origin = plane.Origin.ToSpeckle();
      var normal = new SpeckleVector( plane.Normal.X / Scale, plane.Normal.Y, plane.Normal.Z / Scale );
      var xdir = new SpeckleVector( plane.XVec.X / Scale, plane.XVec.Y / Scale, plane.XVec.Z / Scale );
      var ydir = new SpeckleVector( plane.YVec.X / Scale, plane.YVec.Y / Scale, plane.YVec.Z / Scale );

      return new SpecklePlane( origin, normal, xdir, ydir );
    }

    public static Line ToNative( this SpeckleLine line )
    {
      return Line.CreateBound( new XYZ( line.Value[ 0 ] * Scale, line.Value[ 1 ] * Scale, line.Value[ 2 ] * Scale ), new XYZ( line.Value[ 3 ] * Scale, line.Value[ 4 ] * Scale, line.Value[ 5 ] * Scale ) );
    }

    public static SpeckleLine ToSpeckle( this Line line )
    {
      var l = new SpeckleLine() { Value = new List<double>() };
      l.Value.AddRange( line.GetEndPoint( 0 ).ToSpeckle().Value );
      l.Value.AddRange( line.GetEndPoint( 1 ).ToSpeckle().Value );
      l.GenerateHash();
      return l;
    }



    public static Arc ToNative( this SpeckleArc arc )
    {
      double startAngle, endAngle;
      if( arc.StartAngle > arc.EndAngle ) { startAngle = (double) arc.EndAngle; endAngle = (double) arc.StartAngle; }
      else { startAngle = (double) arc.StartAngle; endAngle = (double) arc.EndAngle; }
      var plane = arc.Plane.ToNative();
      return Arc.Create( arc.StartPoint.ToNative(), arc.EndPoint.ToNative(), arc.MidPoint.ToNative() );
      //return Arc.Create( plane.Origin, (double) arc.Radius * Scale, startAngle, endAngle, plane.XVec, plane.YVec );
    }

    public static SpeckleArc ToSpeckle( this Arc arc )
    {
      // see https://forums.autodesk.com/t5/revit-api-forum/how-to-retrieve-startangle-and-endangle-of-arc-object/td-p/7637128
      var arcPlane = Plane.CreateByNormalAndOrigin( arc.Normal, arc.Center );

      XYZ center = arc.Center;
      XYZ dir0 = (arc.GetEndPoint( 0 ) - center).Normalize();
      XYZ dir1 = (arc.GetEndPoint( 1 ) - center).Normalize();

      XYZ start = arc.Evaluate( 0, true );
      XYZ end = arc.Evaluate( 1, true );
      XYZ mid = arc.Evaluate( 0.5, true );

      double startAngle = dir0.AngleOnPlaneTo( arc.XDirection, arc.Normal );
      double endAngle = dir1.AngleOnPlaneTo( arc.XDirection, arc.Normal );

      var a = new SpeckleArc( arcPlane.ToSpeckle(), arc.Radius / Scale, startAngle, endAngle, endAngle - startAngle );
      a.EndPoint = end.ToSpeckle();
      a.StartPoint = start.ToSpeckle();
      a.MidPoint = mid.ToSpeckle();
      return a;
    }


    public static Curve ToNative( this SpeckleCurve crv )
    {
      var pts = new List<XYZ>();
      for( int i = 0; i < crv.Points.Count; i += 3 )
      {
        pts.Add( new XYZ( crv.Points[ i ] * Scale, crv.Points[ i + 1 ] * Scale, crv.Points[ i + 2 ] * Scale ) );
      }
      try
      {
        var weights = crv.Weights.GetRange( 0, pts.Count );
        var curve = NurbSpline.CreateCurve( pts, weights );
        return curve;
      }
      catch( Exception e )
      {
        return null;
      }
    }

  }
}
