using System;
using LanguageExt;
using System.Linq;
using static LanguageExt.Prelude;
using System.Collections.Generic;

namespace language_ext_playground.either
{
   public static class EitherMightBottom
   {
      public static IEnumerable<Either<string, int>> StupidFilterForOddEithers(IEnumerable<int> values, IEnumerable<int> allowed) =>
         values
         .Select(CheckOdd)
         .Where(x => allowed.Contains(x));

      private static Either<string, int> CheckOdd(int value) =>
         (value % 2 == 1) ? value : $"the value {value} is not odd".ToError();

      public static Either<string, int> MightBottom(Func<Either<string, int>> getNumber, Func<int, bool> isNumberAllowed) =>
         from value in getNumber()
         where isNumberAllowed(value)
         select value;

      public static Either<string, int> NeverBottoms(Func<Either<string, int>> getNumber, Func<int, bool> isNumberAllowed) =>
         from value in getNumber()
         from result in isNumberAllowed(value) ? value : $"value {value} is not allowed".ToError()
         select result;

      public static Either<string, int> ToError(this string message) =>
         Left<string, int>(message);
   }
}
