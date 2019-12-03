using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace language_ext_playground
{

   class Program
   {
      static void Main(string[] args)
      {
         LogHeader("option.OrOperator.FirstSome()");
         option.OrOperator
            .FirstSome()
            .Do(x => Log($"{x}"));

         LogHeader("option.SequenceOfOptions.GetSomeFoos(...)");
         option.SequenceOfOptions
            .GetSomeFoos(Foo.Cons(), Foo.Cons(42), null, Foo.Cons(12))
            .Iter((ndx, x) => Log($"[{ndx}] = {x.Value}"));

         LogHeader("discriminated_union.ShapeExample.Run()");
         discriminated_union.ShapeExample.Run()
            .Iter(Log);
      }

      static void LogHeader(string message) =>
         Console.WriteLine(Environment.NewLine + (message ?? ""));

      static void Log(string message) =>
         Console.WriteLine("\t" + (message ?? ""));
   }
}
