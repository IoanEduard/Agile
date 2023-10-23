using CoffeeMachine.Listing_20_1;

namespace CoffeeMachine.Listing_20_5
{
    public class M4HotWaterSource : HotWaterSource, IPollable
    {
        private ICoffeeMakerAPI _coffeeMaker;

        public M4HotWaterSource(ICoffeeMakerAPI coffeeMaker)
        {
            _coffeeMaker = coffeeMaker;
        }

        public override bool IsReady()
        {
            BoilerStatus status = _coffeeMaker.GetBoilerStatus();
            return status == BoilerStatus.NOT_EMPTY;
        }

        public override void StartBrewing()
        {
            _coffeeMaker.SetReliefValveState(ReliefValveState.CLOSED);
            _coffeeMaker.SetBoilerState(BoilerState.ON);
        }

        public void Poll()
        {
            BoilerStatus boilerStatus = _coffeeMaker.GetBoilerStatus();
            if(isBrewing)
            {
                if(boilerStatus == BoilerStatus.EMPTY)
                {
                    _coffeeMaker.SetBoilerState(BoilerState.OFF);
                    _coffeeMaker.SetReliefValveState(ReliefValveState.CLOSED);
                    DeclareDone();
                }
            }
        }

        public override void Pause()
        {
            _coffeeMaker.SetBoilerState(BoilerState.OFF);
            _coffeeMaker.SetReliefValveState(ReliefValveState.OPEN);
        }

        public override void Resume()
        {
            _coffeeMaker.SetBoilerState(BoilerState.ON);
            _coffeeMaker.SetReliefValveState(ReliefValveState.CLOSED);
        }
    }
}
