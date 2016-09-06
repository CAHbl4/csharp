namespace Operators_overloading
{
    public class TestClass
    {
        public int A { get; set; }

        public static TestClass operator ++(TestClass test)
        {
            test.A++;
            return test;
        }

        protected bool Equals(TestClass other)
        {
            return A == other.A;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TestClass) obj);
        }

        public override int GetHashCode()
        {
            return A;
        }

        public static bool operator ==(TestClass left, TestClass right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TestClass left, TestClass right)
        {
            return !Equals(left, right);
        }
        



        public override string ToString()
        {
            return string.Format("A: {0}", A);
        }
    }
}