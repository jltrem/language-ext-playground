using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace language_ext_playground
{

   class Program
   {
      static void Main(string[] args)
      {
         discriminated_union.ShapeExample.Run()
            .Iter(Log);
      }


      static void Log(string message) =>
         Console.WriteLine(message);
   }
}
