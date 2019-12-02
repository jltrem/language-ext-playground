using System;
using LanguageExt;
using System.Linq;
using static LanguageExt.Prelude;

namespace language_ext_playground.option
{
   public static class OrOperator
   {

      public static Option<int> FirstSome() =>
         None || Some(42) || Foobar();

      public static Option<int> Foobar() =>
         throw new Exception("foobar");
   }
}
