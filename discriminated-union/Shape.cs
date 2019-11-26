using System;
using LanguageExt;
using System.Linq;
using static LanguageExt.Prelude;

namespace language_ext_playground.discriminated_union
{
   [Union]
   public interface Shape
   {
      Shape Rectangle(float width, float length);
      Shape Circle(float radius);
      Shape Prism(float width, float height);
   }

   public static class ShapeExample
   {
      public static Lst<string> Run()
      {
         var s1 = ShapeCon.Rectangle(100, 20);
         var s2 = ShapeCon.Circle(50);
         var s3 = ShapeCon.Prism(25, 300);

         return List(s1, s2, s3)
            .Map(GetDescription);
      }

      static string GetDescription(Shape s) =>
         s switch
         {
            Rectangle rectangle => $"rectangle: w={rectangle.Width} l={rectangle.Length}",
            Circle circle => $"circle: r={circle.Radius}",
            Prism prism => $"prism: w={prism.Width} h={prism.Height}",
            _ => "unknown shape"
         };
   }
}
