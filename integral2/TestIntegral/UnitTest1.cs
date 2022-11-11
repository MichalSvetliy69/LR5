

namespace Integral2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIntegral1()
        {
            bool result = false;

            Equation sinEquation = new MySin1(5);
            Integrator1 integ = new Integrator1();
            integ.Integrator(sinEquation);
            double actual = integ.Integrate(1, 2, 100);
            double[] expected = { 0.099 , 1.10};
            if (actual > expected[0] & actual < expected[1])
            {
                result = true;
            }
            Assert.IsTrue(result);
        }
    }
}