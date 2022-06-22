using Applications.PrimaryOperation;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Проверяю Сложение
        /// </summary>
        [Test]
        public void Addition()
        {
            Calculate calculate = new Calculate("5+5");
            float test = calculate.Calc();

            Assert.AreEqual(10, test, message:"Ответ должен быть 10");
        }

        /// <summary>
        /// Проверяю Вычитание
        /// </summary>
        [Test]
        public void Subtraction()
        {
            Calculate calculate = new Calculate("6-5");
            float test = calculate.Calc();

            Assert.AreEqual(1, test, message: "Ответ должен быть 1");
        }

        /// <summary>
        /// Проверяю умножение
        /// </summary>
        [Test]
        public void Multiplication()
        {
            Calculate calculate = new Calculate("2*2");
            float test = calculate.Calc();

            Assert.AreEqual(4, test, message: "Ответ должен быть 4");
        }
        
        /// <summary>
        /// Проверяю деление
        /// </summary>
        [Test]
        public void Division()
        {
            Calculate calculate = new Calculate("9/3");
            float test = calculate.Calc();

            Assert.AreEqual(3, test, message: "Ответ должен быть 3");
        }


        /// <summary>
        /// Проверяю чуть более сложный запрос
        /// </summary>
        [Test]
        public void ASlightlyComplicatedQuery()
        {
            Calculate calculate = new Calculate("1+2-3+(5*2)");
            float test = calculate.Calc();

            Assert.AreEqual(10, test, message:"Ответ должен быть 10");
        }

        /// <summary>
        /// Проверяю на потерю скобки
        /// </summary>
        [Test]
        public void MissStamples()
        {
            Calculate calculate = new Calculate("2+(");
            float test = calculate.Calc();

            Assert.AreEqual(2, test, message: "Ответ должен быть 2");
        }

    }
}