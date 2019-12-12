using System;
using LanguageExt;
using System.Linq;
using static LanguageExt.Prelude;

namespace language_ext_playground.either
{
    public static class OneThingOrAnother
    {
        public static Either<string, int> TryCheck42(int value) =>
            Try(() =>

                value == 42
                    ? 42
                    : throw new Exception("the value was not 42")
            )
            .ToEither(ex => ex.Message);

        public static Either<string, int> PreludeCheck42(int value) =>
            value == 42
                ? Right<string, int>(42)
                : Left<string, int>("the value was not 42");

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
