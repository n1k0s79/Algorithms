namespace Codility.BetssonTest
{
    public interface InterfaceA { }
    public interface InterfaceB { }
    public abstract class ClassA { }
    public abstract class ClassB { }

    //public class Foo1: ClassA, ClassB, InterfaceA { }
    //public class Foo2: ClassA, ClassB, InterfaceA, InterfaceB { }
    public class Foo3 : ClassA, InterfaceA, InterfaceB { }
}
