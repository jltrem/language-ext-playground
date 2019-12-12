using System;
using LanguageExt;
using System.Linq;
using static LanguageExt.Prelude;

namespace language_ext_playground.either
{
    public static class OneThingOrAnother
    {
        public static Either<string, int> TryCheck42(int value) =>
            Try<Either<string, int>>(() =>

                value == 42
                    ? 42
                    : throw new Exception("the value was not 42")
            )
            .IfFail(ex => ex.Message);

        public static Either<string, int> Check42(int value)
        {
            if (value == 42)
            {
                return 42;
            }
            else
            {
                return "the value was not 42";
            }
        }
    }
}
