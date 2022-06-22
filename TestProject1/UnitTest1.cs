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
        /// �������� ��������
        /// </summary>
        [Test]
        public void Addition()
        {
            Calculate calculate = new Calculate("5+5");
            float test = calculate.Calc();

            Assert.AreEqual(10, test, message:"����� ������ ���� 10");
        }

        /// <summary>
        /// �������� ���������
        /// </summary>
        [Test]
        public void Subtraction()
        {
            Calculate calculate = new Calculate("6-5");
            float test = calculate.Calc();

            Assert.AreEqual(1, test, message: "����� ������ ���� 1");
        }

        /// <summary>
        /// �������� ���������
        /// </summary>
        [Test]
        public void Multiplication()
        {
            Calculate calculate = new Calculate("2*2");
            float test = calculate.Calc();

            Assert.AreEqual(4, test, message: "����� ������ ���� 4");
        }
        
        /// <summary>
        /// �������� �������
        /// </summary>
        [Test]
        public void Division()
        {
            Calculate calculate = new Calculate("9/3");
            float test = calculate.Calc();

            Assert.AreEqual(3, test, message: "����� ������ ���� 3");
        }


        /// <summary>
        /// �������� ���� ����� ������� ������
        /// </summary>
        [Test]
        public void ASlightlyComplicatedQuery()
        {
            Calculate calculate = new Calculate("1+2-3+(5*2)");
            float test = calculate.Calc();

            Assert.AreEqual(10, test, message:"����� ������ ���� 10");
        }

        /// <summary>
        /// �������� �� ������ ������
        /// </summary>
        [Test]
        public void MissStamples()
        {
            Calculate calculate = new Calculate("2+(");
            float test = calculate.Calc();

            Assert.AreEqual(2, test, message: "����� ������ ���� 2");
        }

    }
}