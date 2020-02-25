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

  public static partial class Conversions
  {


    // Insipred by
    // https://github.com/DynamoDS/DynamoRevit/blob/master/src/Libraries/RevitNodes/GeometryConversion/ProtoToRevitMesh.cs
    // and by
    // 
    public static IList<GeometryObject> ToNative(this SpeckleMesh mesh)
    {

        TessellatedShapeBuilderTarget target = TessellatedShapeBuilderTarget.Mesh;
        TessellatedShapeBuilderFallback fallback = TessellatedShapeBuilderFallback.Salvage;

        var tsb = new TessellatedShapeBuilder() { Fallback = fallback, Target = target, GraphicsStyleId = ElementId.InvalidElementId };
        tsb.OpenConnectedFaceSet(false);

        var vertices = mesh.Vertices.ToPoints();

        int i = 0;

        while (i < mesh.Faces.Count)
        {
          var points = new List<XYZ>();

          if (mesh.Faces[i] == 0)
          { // triangle
            points = new List<XYZ> { vertices[mesh.Faces[i + 1]], vertices[mesh.Faces[i + 2]], vertices[mesh.Faces[i + 3]] };
            i += 4;
          }
          else
          { // quad
            points = new List<XYZ> { vertices[mesh.Faces[i + 1]], vertices[mesh.Faces[i + 2]], vertices[mesh.Faces[i + 3]], vertices[mesh.Faces[i + 4]] };
            i += 5;
          }

          var face = new TessellatedFace(points, ElementId.InvalidElementId);
          tsb.AddFace(face);
        }


        tsb.CloseConnectedFaceSet();
        tsb.Build();
        var result = tsb.GetBuildResult();
        return result.GetGeometricalObjects();
      

    }

    public static XYZ[] ToPoints(this IEnumerable<double> arr)
    {
      if (arr.Count() % 3 != 0) throw new Exception("Array malformed: length%3 != 0.");

      XYZ[] points = new XYZ[arr.Count() / 3];
      var asArray = arr.ToArray();
      for (int i = 2, k = 0; i < arr.Count(); i += 3)
        points[k++] = new XYZ(asArray[i - 2] *Scale , asArray[i - 1] * Scale, asArray[i] * Scale);

      return points;
    }


  }
}
