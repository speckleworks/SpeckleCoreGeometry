using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeckleCore;
using SpeckleCoreGeometryClasses;

namespace SpeckleCoreGeometryRhino
{
  public class Initialiser : ISpeckleInitializer
  {
    public Initialiser( ) { }
  }

  public static partial class Conversions
  {
    // numbers
    public static SpeckleNumber ToSpeckle( this float num )
    {
      return new SpeckleNumber( num );
    }

    public static SpeckleNumber ToSpeckle( this long num )
    {
      return new SpeckleNumber( num );
    }

    public static SpeckleNumber ToSpeckle( this int num )
    {
      return new SpeckleNumber( num );
    }

    public static SpeckleNumber ToSpeckle( this double num )
    {
      return new SpeckleNumber( num );
    }

    public static double? ToNative( this SpeckleNumber num )
    {
      return num.Value;
    }

    // booleans 
    public static SpeckleBoolean ToSpeckle( this bool b )
    {
      return new SpeckleBoolean( b );
    }

    public static bool? ToNative( this SpeckleBoolean b )
    {
      return b.Value;
    }

    // strings
    public static SpeckleString ToSpeckle( this string b )
    {
      return new SpeckleString( b );
    }

    public static string ToNative( this SpeckleString b )
    {
      return b.Value;
    }

  }
}
