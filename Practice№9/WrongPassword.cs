namespace Practice9
{
    public class WrongPassword : System.Exception
    {
        public WrongPassword() { }
        public WrongPassword(string message) : base(message) { }
        public WrongPassword(string message, Exception inner) : base(message, inner) { }
    }
}