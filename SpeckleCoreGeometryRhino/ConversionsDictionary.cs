using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Collections;
using Rhino.Geometry;
using SpeckleCore;
using SpeckleCoreGeometryClasses;

namespace SpeckleCoreGeometryRhino
{

  public static partial class Conversions
  {

    // Dictionaries & ArchivableDictionaries
    public static Dictionary<string, object> ToSpeckle( this ArchivableDictionary dict, Dictionary<int, string> traversed = null, string path = "root", GeometryBase root = null )
    {
      if ( dict.Values.Length == 0 ) return null;
      if ( dict == null ) return null;

      if ( traversed == null )
      {
        traversed = new Dictionary<int, string>();
        traversed.Add( root.GetHashCode(), "root" );
      }

      Dictionary<string, object> myDictionary = new Dictionary<string, object>();

      foreach ( var key in dict.Keys )
      {
        var myObj = dict[ key ];
        if ( traversed.ContainsKey( myObj.GetHashCode() ) )
        {
          myDictionary.Add( key, new SpeckleAbstract() { _type = "ref", _ref = traversed[ myObj.GetHashCode() ] } );
          continue;
        }

        if ( !( dict[ key ] is string || dict[ key ] is double || dict[ key ] is float || dict[ key ] is int ) )
          traversed.Add( myObj.GetHashCode(), path + "/" + key );

        if ( dict[ key ] is ArchivableDictionary )
          myDictionary.Add( key, ( ( ArchivableDictionary ) dict[ key ] ).ToSpeckle( traversed, path + "/" + key, root ) );
        else if ( dict[ key ] is string || dict[ key ] is double || dict[ key ] is float || dict[ key ] is int || dict[ key ] is SpeckleObject )
          myDictionary.Add( key, dict[ key ] );
        else if ( dict[ key ] is IEnumerable )
        {
          myDictionary.Add( key, "enums not supported yet." );
        }
        else
        {
          if ( dict[ key ] is GeometryBase )
          {
            GeometryBase obj = dict[ key ] as GeometryBase;
            ArchivableDictionary dictCopy = obj.UserDictionary.Clone();
            obj.UserDictionary.Clear();
            SpeckleObject conv = SpeckleCore.Converter.Serialise( obj ) as SpeckleObject;
            conv.Properties = dictCopy.ToSpeckle( traversed, path + "/" + key, root );
            conv.GenerateHash();
            myDictionary.Add( key, conv );
            obj.UserDictionary.ReplaceContentsWith( dictCopy );
          }
          else
          {
            myDictionary.Add( key, SpeckleCore.Converter.Serialise( dict[ key ] ) );
          }
        }
      }
      return myDictionary;
    }

    public static ArchivableDictionary ToNative( this Dictionary<string, object> dict )
    {
      ArchivableDictionary myDictionary = new ArchivableDictionary();
      if ( dict == null ) return myDictionary;

      foreach ( var key in dict.Keys )
      {
        if ( dict[ key ] is Dictionary<string, object> )
        {
          myDictionary.Set( key, ( ( Dictionary<string, object> ) dict[ key ] ).ToNative() );
        }
        else if( dict[key] is IEnumerable<object> && !(dict[key] is string))
        {
          //var temp = new List<object>();
          // TODO: Quick hack to output lists
          // NOTE: Archivable Dictionaries only support IEnumberables of one declared type, so here we are ToString()-finyg everything. For the sake of whatever.
          var temp = ((IEnumerable<object>) dict[ key ]).Select( obj => obj.ToString() );
          myDictionary.Set( key, temp );
        }
        else if ( dict[ key ] is SpeckleObject )
        {
          var converted = SpeckleCore.Converter.Deserialise( ( SpeckleObject ) dict[ key ] );

          if ( converted is GeometryBase )
            myDictionary.Set( key, ( GeometryBase ) converted );
          else if ( converted is Interval )
            myDictionary.Set( key, ( Interval ) converted );
          else if ( converted is Vector3d )
            myDictionary.Set( key, ( Vector3d ) converted );
          else if ( converted is Plane )
            myDictionary.Set( key, ( Plane ) converted );
        }
        else if ( dict[ key ] is int )
          myDictionary.Set( key, Convert.ToInt32( dict[ key ] ) );
        else if ( dict[ key ] is double )
          myDictionary.Set( key, ( double ) dict[ key ] );
        else if ( dict[ key ] is bool )
          myDictionary.Set( key, ( bool ) dict[ key ] );
        else if ( dict[ key ] is string )
          myDictionary.Set( key, ( string ) dict[ key ] );
      }
      return myDictionary;
    }
  }
}
