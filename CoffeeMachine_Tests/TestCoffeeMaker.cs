using CoffeeMachine.Listing_20_5;

namespace CoffeeMachine_Tests
{
    [TestFixture]

    public class TestCoffeeMaker
    {
        private M4UserInterface ui;
        private M4HotWaterSource hws;
        private M4ContainmentVessel cv;
        private CoffeeMakerStub api;
        [SetUp]
        public void SetUp()
        {
            api = new CoffeeMakerStub();
            ui = new M4UserInterface(api);
            hws = new M4HotWaterSource(api);
            cv = new M4ContainmentVessel(api);
            ui.Init(hws, cv);
            hws.Init(ui, cv);
            cv.Init(ui, hws);
        }
        private void Poll()
        {
            ui.Poll();
            hws.Poll();
            cv.Poll();
        }
        [Test]
        public void InitialConditions()
        {
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void StartNoPot()
        {
            Poll();
            api.buttonPressed = true;
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void StartNoWater()
        {
            Poll();
            api.buttonPressed = true;
            api.boilerEmpty = true;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void GoodStart()
        {
            NormalStart();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        private void NormalStart()
        {
            Poll();
            api.boilerEmpty = false;
            api.buttonPressed = true;
            Poll();
        }
        [Test]
        public void StartedPotNotEmpty()
        {
            NormalStart();
            api.potNotEmpty = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void PotRemovedAndReplacedWhileEmpty()
        {
            NormalStart();
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsFalse(api.valveClosed);
            api.potPresent = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedEmpty()
        {
            NormalFill();
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsFalse(api.valveClosed);
            api.potPresent = true;
            api.potNotEmpty = false;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        private void NormalFill()
        {
            NormalStart();
            api.potNotEmpty = true;
            Poll();
        }
        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedNotEmpty()
        {
            NormalFill();
            api.potPresent = false;
            Poll();
            api.potPresent = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void BoilerEmptyPotNotEmpty()
        {
            NormalBrew();
            Assert.IsFalse(api.boilerOn);
            Assert.IsTrue(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        private void NormalBrew()
        {
            NormalFill();
            api.boilerEmpty = true;
            Poll();
        }
        [Test]
        public void BoilerEmptiesWhilePotRemoved()
        {
            NormalFill();
            api.potPresent = false;
            Poll();
            api.boilerEmpty = true;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsTrue(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
            api.potPresent = true;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsTrue(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void EmptyPotReturnedAfter()
        {
            NormalBrew();
            api.
            potNotEmpty = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
    }
}
