using System;
using System.Collections.Generic;
using System.Text;

namespace language_ext_playground
{
   public class Foo
   {
      public int Value { get; }

      private Foo() { }
      private Foo(int value) { Value = value; }

      public static Foo Cons() => new Foo();
      public static Foo Cons(int value) => new Foo(value);
   }
}
