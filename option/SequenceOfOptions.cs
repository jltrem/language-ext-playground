using System;
using LanguageExt;
using System.Linq;
using static LanguageExt.Prelude;

namespace language_ext_playground.option
{
   public static class SequenceOfOptions
   {
      /// <summary>
      /// see https://github.com/louthy/language-ext/issues/672
      /// </summary>
      /// <param name="foos"></param>
      /// <returns></returns>
      public static Seq<Foo> GetSomeFoos(params Option<Foo>[] foos) =>
         Optional(foos).Match(
            Some: x => x.Somes().ToSeq(),
            None: () => Lst<Foo>.Empty.ToSeq());
   }
}
