using System;
using LanguageExt;
using System.Linq;
using static LanguageExt.Prelude;

namespace language_ext_playground.option
{
   public static class OrOperator
   {

      /// <summary>
      /// Option coalescing with ||
      /// See https://github.com/louthy/language-ext/blob/master/LanguageExt.Tests/OptionCoalesceTests.cs
      /// </summary>
      /// <returns></returns>
      public static Option<int> FirstSome() =>
         None || Some(42) || Foobar();

      private static Option<int> Foobar() =>
         throw new Exception("foobar");
   }
}
