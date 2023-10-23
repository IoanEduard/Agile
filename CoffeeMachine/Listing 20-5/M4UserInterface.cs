using CoffeeMachine.Listing_20_1;

namespace CoffeeMachine.Listing_20_5
{
    public class M4UserInterface : UserInterface, IPollable
    {
        private ICoffeeMakerAPI _coffeeMaker;
        public M4UserInterface(ICoffeeMakerAPI coffeeMaker)
        {
            _coffeeMaker = coffeeMaker;
        }

        public void Poll()
        {
            BrewButtonStatus status = _coffeeMaker.GetBrewButtonStatus();
            if (status == BrewButtonStatus.PUSHED)
            {
                StartBrewing();
            }
        }

        public override void Done()
        {
            _coffeeMaker.SetIndicatorState(IndicatorState.ON);
        }

        public override void CompleteCycle()
        {
            _coffeeMaker.SetIndicatorState(IndicatorState.OFF);
        }
    }
}
