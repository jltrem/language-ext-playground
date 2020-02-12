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

         LogHeader("either.OneThingOrAnother.TryCheck42(42)");
         either.OneThingOrAnother
             .TryCheck42(42)
             .Match(
                 Right: x => Some($"{x}"),
                 Left: err => Some(err))
             .Do(Log);

         LogHeader("either.OneThingOrAnother.TryCheck42(5)");
         either.OneThingOrAnother
             .TryCheck42(5)
             .Match(
                 Right: x => Some($"{x}"),
                 Left: err => Some(err))
             .Do(Log);

         LogHeader("either.OneThingOrAnother.PreludeCheck42(42)");
         either.OneThingOrAnother
             .PreludeCheck42(42)
             .Match(
                 Right: x => Some($"{x}"),
                 Left: err => Some(err))
             .Do(Log);

         LogHeader("either.OneThingOrAnother.PreludeCheck42(5)");
         either.OneThingOrAnother
             .PreludeCheck42(5)
             .Match(
                 Right: x => Some($"{x}"),
                 Left: err => Some(err))
             .Do(Log);

         LogHeader("either.OneThingOrAnother.Check42(42)");
         either.OneThingOrAnother
             .Check42(42)
             .Match(
                 Right: x => Some($"{x}"),
                 Left: err => Some(err))
             .Do(Log);

         LogHeader("either.OneThingOrAnother.Check42(5)");
         either.OneThingOrAnother
             .Check42(5)
             .Match(
                 Right: x => Some($"{x}"),
                 Left: err => Some(err))
             .Do(Log);

         LogHeader("either.EitherMightBottom.StupidFilterForOddEithers(Range(10, 7, 1), Seq(11, 13)).Iter");
         either.EitherMightBottom
            .StupidFilterForOddEithers(Range(10, 7, 1), Seq(11, 13))
            .Iter((ndx, either) =>
            {
               Log($"[{ndx}] left={either.IsLeft} right={either.IsRight} bottom={either.IsBottom}");

               Try(() => Some(either.Match(Right: x => $"{x}", Left: msg => msg)))
               .IfFail(ex => Some($"[{ndx}] threw exception: {ex.Message}"))
               .Do(x => Log($"\t{x}"));
            });

         LogHeader("either.EitherMightBottom.StupidFilterForOddEithers(Range(10, 7, 1), Seq(11, 13)).Apply discards bottoms");
         either.EitherMightBottom
            .StupidFilterForOddEithers(Range(10, 7, 1), Seq(11, 13))
            .Apply(x => x.Match(Right: x => $"{x}", Left: msg => msg))
            .Iter(Log);

         LogHeader("either.EitherMightBottom.MightBottom for Range(10, 7, 1): even=right, odd=left, 14=bottom handled in Match");
         Range(10, 7, 1).Iter(value =>

            either.EitherMightBottom
               .MightBottom(
                  () => value % 2 == 0 ? value : Left<string, int>($"skipping odd value {value}"),
                  x => x != 14)
               .Match(
                  Right: x => Some($"Right for {value} = {x}"),
                  Left: err => Some($"Left for {value} = {err}"),
                  Bottom: () => Some($"Bottom for {value}"))
               .Do(Log)               
         );

         LogHeader("either.EitherMightBottom.NeverBottoms for Range(10, 7, 1): even=right, odd=left, 14=left handled by 'NeverBottoms'");
         Range(10, 7, 1).Iter(value =>

            either.EitherMightBottom
               .NeverBottoms(
                  () => value % 2 == 0 ? value : Left<string, int>($"skipping odd value {value}"),
                  x => x != 14)
               .Match(
                  Right: x => Some($"Right for {value} = {x}"),
                  Left: err => Some($"Left for {value} = {err}"),
                  Bottom: () => Some($"Bottom for {value}"))
               .Do(Log)
         );

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
