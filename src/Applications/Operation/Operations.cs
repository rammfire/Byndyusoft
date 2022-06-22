namespace Applications.AllOperation;

public class Operations
{
    // Универсальная операция
    public abstract class Operation
    {
        public abstract float Eval();
    }

    // Просто число
    public class Number : Operation
    {
        public Number(float f) { value = f; }
        public override float Eval() { return value; }

        private float value;
    }

    // Один операнд
    public abstract class Unary : Operation
    {
        public Unary(Operation op) { one = op; }

        protected Operation one;
    }

    // Два операнда
    public abstract class Binary : Operation
    {
        public Binary(Operation l, Operation r) { left = l; right = r; }

        protected Operation left, right;
    }

    // Одинокий минус
    public class Negation : Unary
    {
        public Negation(Operation n) : base(n) { }
        public override float Eval() { return -one.Eval(); }
    }

    // Сложение
    public class Plus : Binary
    {
        public Plus(Operation l, Operation r) : base(l, r) { }
        public override float Eval() { return left.Eval() + right.Eval(); }
    }

    // Вычитание
    public class Minus : Binary
    {
        public Minus(Operation l, Operation r) : base(l, r) { }
        public override float Eval() { return left.Eval() - right.Eval(); }
    }

    // Умножение
    public class Multiply : Binary
    {
        public Multiply(Operation l, Operation r) : base(l, r) { }
        public override float Eval() { return left.Eval() * right.Eval(); }
    }

    // Деление
    public class Divide : Binary
    {
        public Divide(Operation l, Operation r) : base(l, r) { }
        public override float Eval()
        {
            float right_eval = right.Eval();
            if (right_eval == 0.0f)
                System.Console.WriteLine("Деление на 0");
            return (right_eval != 0.0f) ? (left.Eval() / right_eval) : float.MaxValue;
        }
    }

}
