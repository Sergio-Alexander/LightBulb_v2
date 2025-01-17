using LightBulb;
using NUnit.Framework;
using standard;

namespace LightBulbTest
{
    public class lumenTest
    {
        private Lumen lumen;

        [SetUp]
        public void Setup()
        {
            lumen = new Lumen(10, 2, 50, 10, 5, 4);
        }

        [Test]
        public void TestGlowWhenActive()
        {
            int result = lumen.glow();
            Assert.AreEqual(20, result, "Glow should return brightness * size when active.");
        }

        [Test]
        public void TestGlowWhenInactive()
        {
            for (int i = 0; i < 50; i++)
            {
                lumen.glow();
            }
            int result = lumen.glow();
            Assert.AreEqual(10, result, "Glow should return dimming_value when inactive.");
        }

        [Test]
        public void TestGlowWhenUnstable()
        {
            for (int i = 0; i < 9; i++)
            {
                lumen.glow();
            }
            int result = lumen.glow();
            Assert.IsTrue(result >= 0 && result < 50, "Glow should return an erratic value associated with power when unstable.");
        }

        [Test]
        public void TestResetWhenValid()
        {
            for (int i = 0; i < 6; i++)
            {
                lumen.glow();
            }
            lumen.reset();
            int result = lumen.glow();
            Assert.AreEqual(20, result, "Glow should return brightness * size after a valid reset.");
        }

        [Test]
        public void TestResetWhenInvalid()
        {
            lumen.reset();
            int result = lumen.glow();
            Assert.AreEqual(18, result, "Glow should return (brightness - 1) * size after an invalid reset.");
        }

        [Test]
        public void TestResetWhenPowerIsExactlyThreshold()
        {
            for (int i = 0; i < 4; i++)
            {
                lumen.glow();
            }
            lumen.reset(); // Attempting an invalid reset
            int result = lumen.glow();
            Assert.IsTrue(result >= 0 && result < 40, "Glow should return an erratic value associated with power when power is exactly at the threshold and reset is invalid.");
        }

        [Test]
        public void TestResetWhenPowerIsOneBelowThreshold()
        {
            for (int i = 0; i < 5; i++)
            {
                lumen.glow();
            }
            lumen.reset();
            int result = lumen.glow();
            Assert.IsTrue(result >= 0 && result < 50, "Glow should return an erratic value when power is one below the threshold and reset is invalid.");
        }
    }
}
